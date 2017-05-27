using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Reflection;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

public partial class dotNetFlexGridAsyn : System.Web.UI.Page
{
    private Dictionary<string,dotNetFlexGrid.FieldConfig> _FieldConfigs;//从父页面传递的字段配置
    private Dictionary<string, DataColumn> _LocalDataColumnsDic;//本地的数据表列字典
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["cid"]!=null&&
            Request.QueryString["class"] != null&&
            Request.QueryString["func"]!=null)
        {
            string cName = Request.QueryString["class"].Trim();//反射的类名
            string fName = Request.QueryString["func"].Trim();//反射的函数名
            string cId = Request.QueryString["cid"].Trim();//控件ID

            if (cId.Length > 0)
            {
                string cFields = GetFieldConfigs(cId);//控件的字段配置
                Newtonsoft.Json.Linq.JArray array = (Newtonsoft.Json.Linq.JArray)JsonConvert.DeserializeObject(cFields);
                _FieldConfigs = new Dictionary<string, dotNetFlexGrid.FieldConfig>();
                for (int i = 0; i < array.Count; i++)
                {
                    Newtonsoft.Json.Linq.JObject o = Newtonsoft.Json.Linq.JObject.Parse(array[i].ToString());

                    dotNetFlexGrid.FieldConfigAlign align = dotNetFlexGrid.FieldConfigAlign.Left;
                    switch (((string)o["align"]).ToLower())
                    {
                        case "left":
                            align=dotNetFlexGrid.FieldConfigAlign.Left;
                            break;
                        case "center":
                            align=dotNetFlexGrid.FieldConfigAlign.Center;
                            break;
                            case "right":
                            align=dotNetFlexGrid.FieldConfigAlign.Right;
                            break;
                    }
                    dotNetFlexGrid.FieldConfig config = new dotNetFlexGrid.FieldConfig(                        
                        (string)o["name"],
                        (string)o["display"],
                        (int)o["width"],
                        (bool)o["sortable"],
                        align,
                        (bool)o["checkField"],
                        (o["hide"] == null) ? false : (bool)o["hide"],
                        (o["toggle"] == null) ? true : (bool)o["toggle"],
                        (o["template"] == null) ? null : this.DecodeBase64Utf8((string)o["template"])

                        );
                    _FieldConfigs.Add(config._name,config);
                }
                ;
            }

            if (cName.Length > 0 && fName.Length > 0)
            {
                dotNetFlexGrid.DataHandlerParams parm = BuildGridParams(cId);
                dotNetFlexGrid.DataHandlerResult dt = InvokeTargetMothod(cName, fName, parm);
                Response.Write(BuildResultJson(dt));
            }
            else
            {
                Response.Write(BuildEmptyJson());
            }
            Response.End();
        }
    }
    private string GetFieldConfigs(string cid)
    {
        string result = string.Empty;
        if (Request.Form.Count > 0)
        {
            string fieldConfigsParamName = cid + "$FieldConfigs$";
            foreach (string key in Request.Form.AllKeys)
            {
                if (key == fieldConfigsParamName)
                {
                    result = Request.Form[key].Trim();
                    break;
                }
            }
        }
        if (result.Length > 0)
        {
            result = DecodeBase64Utf8(result);
        }
        return result;
    }
    private string BuildEmptyJson()
    {
        string txt = "{}";
        return txt;
    }
    /// <summary>
    /// 反射调用映射的方法
    /// </summary>
    /// <param name="cName"></param>
    /// <param name="fName"></param>
    /// <returns></returns>
    private dotNetFlexGrid.DataHandlerResult InvokeTargetMothod(string cName, string fName, dotNetFlexGrid.DataHandlerParams parm)
    {
        dotNetFlexGrid.DataHandlerResult dt = null;
        System.Type type = System.Type.GetType(cName,true);
        object obj = Activator.CreateInstance(type);
        MethodInfo func =
            type.GetMethod(fName, BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
        if (func != null)
        {
            object result = null;
            try
            {
                result = func.Invoke(obj, new object[] { parm });
            }
            catch (TargetInvocationException ee)
            {
                throw ee.InnerException;
            }

            if (result != null)
            {
                dt = (dotNetFlexGrid.DataHandlerResult)result;
            }
        }
        else
        {
            throw new ApplicationException("dotNetFlexiGridAsyn.InvokeTargetMothod()调用失败，调用'" + cName + "." + fName + "'时未能找到方法!");
        }
        //添加字段列表
        if (_LocalDataColumnsDic == null)
        {
            _LocalDataColumnsDic = new Dictionary<string, DataColumn>(dt.table.Columns.Count);
        }
        _LocalDataColumnsDic.Clear();
        foreach (DataColumn dc in dt.table.Columns)
        {
            _LocalDataColumnsDic.Add(dc.ColumnName, dc);
        }
        return dt;
    }
    /// <summary>
    /// 根据传递参数生成参数对象
    /// </summary>
    /// <returns></returns>
    private dotNetFlexGrid.DataHandlerParams BuildGridParams(string cid)
    {
        dotNetFlexGrid.DataHandlerParams result = null;
        if (Request.Form.Count > 0)
        {
            string defaultSearchParamName = cid + "$DefaultSearch$";
            result = new dotNetFlexGrid.DataHandlerParams();
            if (_FieldConfigs != null)
                result.fieldConfigs = _FieldConfigs;
            result.extParam = new Dictionary<string, string>();
            result.defaultSearch = new Dictionary<string, string>();
            foreach (string key in Request.Form.AllKeys)
            {
                if (key.StartsWith(defaultSearchParamName))
                {
                    //初始化传参
                    string name = key.Substring(defaultSearchParamName.Length, key.Length - defaultSearchParamName.Length);
                    string value=DecodeBase64Utf8(Request.Form[key]);
                    result.defaultSearch.Add(name,value) ;
                }
                else{
                    switch (key)
                    {

                        case "page":
                            if (!int.TryParse(Request.Form[key], out result.page))
                            {
                                result.page = -1;
                            }
                            break;
                        case "rp":
                            if (!int.TryParse(Request.Form[key], out result.rp))
                            {
                                result.rp = -1;
                            }
                            break;
                        case "qop":
                            if (Request.Form[key].ToString() == dotNetFlexGrid.SerchParamConfigOperater.Like.ToString())
                                result.qop = dotNetFlexGrid.SerchParamConfigOperater.Like;
                            else if (Request.Form[key].ToString() == dotNetFlexGrid.SerchParamConfigOperater.Eq.ToString())
                                result.qop = dotNetFlexGrid.SerchParamConfigOperater.Eq;
                            else
                                result.qop = dotNetFlexGrid.SerchParamConfigOperater.None;
                            break;
                        case "qtype":
                            result.qtype = Request.Form[key];
                            break;
                        case "query":
                            result.query = Request.Form[key];
                            break;
                        case "sortname":
                            result.sortname = Request.Form[key];
                            break;
                        case "sortorder":
                            result.sortorder = Request.Form[key];
                            break;
                        default:
                            if(!key.StartsWith(cid+"$"))//任何带了控件id前缀的ext均不作为extParam
                                result.extParam.Add(key, DecodeBase64Utf8(Request.Form[key]));
                            break;
                    }
                }
            }
        }
        return result;
    }
    private string GetTemplateColumnValue(string name,string cvalue, DataRow dr, string template)
    {
        string result = string.Empty;
        if (
            name!=null&&
            dr!=null&&
            template != null &&
            template.Length > 0)
        {
            string keyName=string.Empty;
            string colValue = template;
            colValue = colValue.Replace("[@" + name + "]", cvalue);

            foreach (string key in _LocalDataColumnsDic.Keys)
            {
                keyName = "[@" + key + "]";
                if (colValue.IndexOf(keyName) >= 0)
                {
                    colValue = colValue.Replace(keyName, dr[key].ToString());

                }
            }
            result = colValue;
        }
        else
        {
            result = cvalue;
        }
        return result;
    }
    /// <summary>
    /// 生成返回的Json数据
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private string BuildResultJson(dotNetFlexGrid.DataHandlerResult data)
    {
        DataTable dt = data.table;
        StringBuilder sb = new StringBuilder();

        StringWriter sw = new StringWriter(sb);
        //处理主键
        string key = string.Empty;
        if (dt.PrimaryKey.Length > 0)
        {
            key = dt.PrimaryKey[0].ColumnName;//第一个作为主键
        }
        else
        {
            //否则拿第一列作为主键
            key = dt.Columns[0].ColumnName;
        }
        using (JsonWriter jsonWriter = new JsonTextWriter(sw))
        {
            jsonWriter.Formatting = Formatting.Indented;
            jsonWriter.WriteStartObject();
            jsonWriter.WritePropertyName("page");
            jsonWriter.WriteValue(data.page.ToString());//当前页
            jsonWriter.WritePropertyName("total");
            jsonWriter.WriteValue(data.total.ToString());//总共的条数
            jsonWriter.WritePropertyName("rows");
            jsonWriter.WriteStartArray();
            foreach (DataRow dr in dt.Rows)
            {
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("id");
                jsonWriter.WriteValue(dr[key].ToString());


                jsonWriter.WritePropertyName("cell");
                jsonWriter.WriteStartArray();
                foreach (string field in _FieldConfigs.Keys)
                {
                    string txt=string.Empty;
                    if (!_LocalDataColumnsDic.ContainsKey(field) 
                        && (_FieldConfigs[field]._ItemTemplate == null || _FieldConfigs[field]._ItemTemplate.Length == 0)
                        && !data.FieldFormator.FormatorList.ContainsKey(field)
                        )
                    {
                        //产生默认的错误字段提示
                        txt = "<b>noset at " + field +  "</b>";
                    }
                    else
                    {
                        if (data.FieldFormator.FormatorList.ContainsKey(field)
                            &&data.FieldFormator.FormatorList[field].handle != null)
                        {
                            bool isSuccess = false;
                            try
                            {
                                txt = data.FieldFormator.FormatorList[field].handle(dr);
                                isSuccess = true;
                            }
                            catch(Exception ex)
                            {
                                txt = txt = "<b>formater error at " + field + "msg="+ex.Message+"</b>"; ;
                            }

                            if (isSuccess && txt == null && _LocalDataColumnsDic.ContainsKey(field))
                            {
                                //处理器放弃处理，继续使用原来的数据
                                txt = dr[field].ToString();
                            }
                        }
                        else if (_LocalDataColumnsDic.ContainsKey(field)
                            )
                        {
                            txt = dr[field].ToString();

                        }
                        else
                        {
                            txt = "<b>error at " + field + "</b>";
                        }
                        if (_FieldConfigs[field]._ItemTemplate != null && _FieldConfigs[field]._ItemTemplate.Length != 0)
                        {
                            //存在模板替换
                            txt = GetTemplateColumnValue(field, txt, dr, _FieldConfigs[field]._ItemTemplate);
                        }
                    }
                    jsonWriter.WriteValue(txt);
			
                }
                jsonWriter.WriteEndObject();

            }
            jsonWriter.WriteEnd();
            jsonWriter.WriteEndObject();

        }

        return sb.ToString();
    }
    private string DecodeBase64Utf8( string code)
    {
        string decode = "";
        byte[] bytes = Convert.FromBase64String(code);
        try
        {
            decode = Encoding.UTF8.GetString(bytes);
        }
        catch
        {
            decode = code;
        }
        return decode;
    }


}
