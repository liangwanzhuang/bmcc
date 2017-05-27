using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data;
using System.Web.Services;
public partial class view_recipe_SwapStatistics : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {    
        this.dotNetFlexGrid2.InitConfig(
              new string[]{
                "title=调剂信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=false",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=605"//宽度，可为auto或具体px值
            },
              new dotNetFlexGrid.FieldConfig[]{
             //   new dotNetFlexGrid.FieldConfig("id","调剂ID",60,true,dotNetFlexGrid.FieldConfigAlign.Center,false,true,false),
                new dotNetFlexGrid.FieldConfig("SwapPer","调剂人员",80,true,dotNetFlexGrid.FieldConfigAlign.Center),

                new dotNetFlexGrid.FieldConfig("wordDate","日期",100,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("wordcontent","工作内容",200,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("workload","工作量",200,false,dotNetFlexGrid.FieldConfigAlign.Center),
             
           },
           null
           ,
              null
          );
        this.dotNetFlexGrid2.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);  //提供数据的方法

      
        AdjustModel am = new AdjustModel();
        DataTable dt = am.findRecipeInfo(2,"","","");
        this.chartData.Value = DataTableToJson.ToJson(dt);


    }

    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        AdjustModel am = new AdjustModel();

        //0,未完成,1已完成,2全部
        string status = "2";
        if (p.extParam.ContainsKey("status"))
        {
            status = p.extParam["status"];
        }
        string begindate = "";
        if (p.extParam.ContainsKey("begindate"))
        {
            begindate = p.extParam["begindate"];
        }
        string enddate = "";
        if (p.extParam.ContainsKey("enddate"))
        {
            enddate = p.extParam["enddate"];
        }
        string eName = "";
        if (p.extParam.ContainsKey("eName"))
        {
            eName = p.extParam["eName"];
        }




        result.table = am.findRecipeInfo(Convert.ToInt32(status),begindate, enddate, eName);
      //  result.table = dotNetFlexGrid.DemoMemoryTable(p.page * 100, p.rp);//调用演示的数据生成函数产生模拟数据
        //如果传递的参数包含排序设置的话，通过DataView.Sort功能模拟进行当页排序
        //if (p.sortname.Length > 0 && p.sortorder.Length > 0)
        //{
        //    System.Data.DataView dv = result.table.DefaultView;
        //    dv.Sort = (p.sortname + " " + p.sortorder);
        //    result.table = dv.ToTable();
        //}
        ////处理默认查询，即Button1_Click中指定的DefaultSearch查询参数
        //if (p.defaultSearch.ContainsKey("String1"))
        //{
        //    System.Data.DataView dv = result.table.DefaultView;
        //    dv.RowFilter = "String1 Like '%" + p.defaultSearch["String1"] + "%'";
        //    result.table = dv.ToTable();
        //}

        ////如果传递的参数包含附加参数的话，再来模拟查询，原谅我真的很懒。
        //if (p.extParam.ContainsKey("String1"))
        //{
        //    System.Data.DataView dv = result.table.DefaultView;
        //    dv.RowFilter = "String1 Like '%" + p.extParam["String1"] + "%'";
        //    result.table = dv.ToTable();
        //}
        ////如果传递的参数包含快速查询参数，则进行快速查询
        //if (p.qop != dotNetFlexGrid.SerchParamConfigOperater.None && p.qtype.Length > 0 && p.query.Length > 0)
        //{
        //    System.Data.DataView dv = result.table.DefaultView;
        //    if (p.qop == dotNetFlexGrid.SerchParamConfigOperater.Like)
        //        dv.RowFilter = p.qtype + " Like '%" + p.query + "%'";
        //    else
        //        dv.RowFilter = p.qtype + " = '" + p.query + "'";
        //    result.table = dv.ToTable();
        //}

        return result;
    }
    //导出数据
    protected void Button1_Click(object sender, EventArgs e)
    {
        string status1 = status.Value;
        string begindate1 = begindate.Value;
        string enddate1 = enddate.Value;
        string eName1 = eName.Value;
        AdjustModel am = new AdjustModel();

        // DataBaseLayer db = new DataBaseLayer();
        //    string str = "select * from lossiInfor where type ='" + type + "'";
        DataTable dt = am.findRecipeInfo(Convert.ToInt32(status1), begindate1, enddate1, eName1);

        CreateExcel(dt, "application/ms-excel", "excel");
    }
    public void CreateExcel(DataTable dt, string FileType, string FileName)
    {
        Response.Clear();
        Response.Charset = "UTF-8";
        Response.Buffer = true;
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls\"");
        Response.ContentType = FileType;
        string colHeaders = string.Empty;
        //string ls_item = string.Empty;

        string ls_item = "序号\t调剂人员\t 日期\t     工作内容\t工作量\n";
           

        DataRow[] myRow = dt.Select();
        int i = 0;
        int cl = dt.Columns.Count;
        foreach (DataRow row in myRow)
        {
            for (i = 0; i < cl; i++)
            {
                if (i == (cl - 1))
                {
                    ls_item += row[i].ToString() + "\n";
                }
                else
                {
                    ls_item += row[i].ToString() + "\t";
                }
            }
            Response.Output.Write(ls_item);
            ls_item = string.Empty;
        }
        Response.Output.Flush();
        Response.End();
    }

    
    [WebMethod]
    public static string findRecipeInfo(string status, string begindate, string enddate, string eName)
    {
       
        AdjustModel am = new AdjustModel();
        DataTable table = am.findRecipeInfo(Convert.ToInt32(status),begindate, enddate, eName);

        return DataTableToJson.ToJson(table);
    }
}