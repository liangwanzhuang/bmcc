using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data.SqlClient;
using System.Web.Services;
using System.Data;

public partial class view_recipe_RecipeSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HospitalModel hm = new HospitalModel();
            SqlDataReader sdr = hm.findHospitalAll();

            hospitalname.Items.Add(new ListItem("  全部  ", "0"));
            if (sdr != null)
            {
                while (sdr.Read())
                {
                    this.hospitalname.Items.Add(new ListItem(sdr["Hname"].ToString(), sdr["ID"].ToString()));

                }
            }

            string cTime = System.DateTime.Now.ToString("yyyy-MM-dd");//当前时间

            JTime.Value = cTime;
        }

      this.FlexGridRecipe.InitConfig(
                new string[]{
                   
                "title=处方信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=1000",//宽度，可为auto或具体px值
                
            },
            new dotNetFlexGrid.FieldConfig[]{
                        new dotNetFlexGrid.FieldConfig("ID","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("hnum","医院编号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("hname","医院名称",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("delnum","委托单号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("hospitalId","医院ID",60,true,dotNetFlexGrid.FieldConfigAlign.Center,false,true,false),
                        new dotNetFlexGrid.FieldConfig("Pspnum","处方号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("decmothed","煎药方法",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("name","患者姓名",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("sex","性别",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("age","年龄",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("phone","手机号码",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("address","地址",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("department","科室",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("inpatientarea","病区号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("ward","病房号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("sickbed","病床号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("diagresult","诊断结果",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                       
                        new dotNetFlexGrid.FieldConfig("takemethod","服用方式",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("takenum","次数",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("decscheme","煎药方案",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("packagenum","包装量",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                       
                        new dotNetFlexGrid.FieldConfig("oncetime","煎药时间一",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("twicetime","煎药时间二",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("soakwater","浸泡加水量",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("soaktime","浸泡时间",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("labelnum","标签数量",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("remark","说明",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("doctor","医生",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("footnote","医生脚注",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("getdrugtime","取药时间",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("getdrugnum","取药号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("ordertime","下单时间",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("curstate","当前状态",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("person","操作人员",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("dotime","接方时间",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("dtbcompany","配送公司",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("dtbaddress","配送地址",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("dtbphone","快递电话",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("dtbtype","配送类型",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("takeway","服用方法",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                         new dotNetFlexGrid.FieldConfig("RemarksA","备注A",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("RemarksB","备注B",60,true,dotNetFlexGrid.FieldConfigAlign.Center),


                   },
           null
           ,
              null
          );
      this.FlexGridRecipe.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);  //提供数据的方法
      this.FlexGridDrug.InitConfig(
          new string[]{
                "title=药物信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=1000"//宽度，可为auto或具体px值
            },
          //序号、委托单号、医院编号、医院名称、处方号、药品编号、药品名称、药品描述、药品位置、药品总数量、药品重量、贴数、说明、批发价格、零售价格
          new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("id","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center,false,true,false),

                new dotNetFlexGrid.FieldConfig("yy","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("delnum","委托单号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hnum","医院编号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hname","医院名称",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Pspnum","处方号",96,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Drugnum","药品编号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Drugname","药品名称",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("DrugDescription","脚注",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("DrugPosition","药品规格",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("DrugAllNum","单剂量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("DrugWeight","总剂量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("TieNum","贴数",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Description","说明",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("WholeSalePrice","批发价格",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("RetailPrice","零售价格",60,false,dotNetFlexGrid.FieldConfigAlign.Center),

           },
       null
       ,
          null
      );

      this.FlexGridDrug.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(FlexGridFlexGridDrugDataHandler);  //提供数据的方法
    }

    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

       
        string hospitalID = "0";
        if (p.extParam.ContainsKey("hospitalID"))
        {
            hospitalID = p.extParam["hospitalID"];
        }
        string Pspnum = "0";
        if (p.extParam.ContainsKey("Pspnum"))
        {
            Pspnum = p.extParam["Pspnum"];
        }
        string time = "0";
        if (p.extParam.ContainsKey("time"))
        {
            time = p.extParam["time"];
        }
        string patient = "0";
        if (p.extParam.ContainsKey("patient"))
        {
            patient = p.extParam["patient"];
        }
        string tisaneid = "0";
        if (p.extParam.ContainsKey("tisaneid"))
        {
            tisaneid = p.extParam["tisaneid"];
        }
        string doper = "0";
        if (p.extParam.ContainsKey("doper"))
        {
            doper = p.extParam["doper"];
        }

        string jftime = System.DateTime.Now.ToString("yyyy-MM-dd");


        if (p.extParam.ContainsKey("JTime"))
        {
            jftime = p.extParam["JTime"];
        }

        if (Pspnum =="")
        {
            Pspnum = "0";
        }
        if (time == "")
        {
            time = "0";
        }
        if (patient == "")
        {
            patient = "0";
        }
        if (tisaneid == "")
        {
            tisaneid = "0";
        }
        if (doper == "")
        {
            doper = "0";
        }
        
        RecipeModel rm = new RecipeModel();
        result.table = rm.findRecipeInfo(hospitalID, Pspnum, time, patient, tisaneid, doper,jftime);

        dotNetFlexGrid.FieldFormatorHandle proc2 = delegate(DataRow dr)
        {

            int a = Convert.ToInt32(dr["sex"].ToString());
            if (a == 1)
            {
                return "男";
            }
            else
            {
                return "女";
            }
        };
        result.FieldFormator.Register("sex", proc2);
        dotNetFlexGrid.FieldFormatorHandle proc3 = delegate(DataRow dr)
        {

            int b = Convert.ToInt32(dr["decscheme"].ToString());
            if (b == 1)
            {
                return "微压（密闭）解表（15min）";
            }
            else if (b == 2)
            {
                return "微压（密闭）汤药（15min）";
            }
            else if (b == 3) { return "微压（密闭）补药（15min）"; }
            else if (b == 4) { return "常压解表（10min，10min）"; }
            else if (b == 5) { return "常压汤药（20min，15min）"; }
            else if (b == 6) { return "常压补药（25min，20min）"; }
            else if (b == 20) { return "先煎解表（10min，10min，10min）"; }
            else if (b == 21) { return "先煎汤药（10min，20min，15min）"; }
            else if (b == 22) { return "先煎补药（10min，25min，20min）"; }
            else if (b == 36) { return "后下解表（10min（3：7），10min）"; }
            else if (b == 37) { return "后下汤药（20min（13：7），15min）"; }
            else if (b == 38) { return "后下补药（25min（18：7），20min）"; }
            else if (b == 81) { return "微压自定义"; }
            else if (b == 82) { return "常压自定义"; }
            else if (b == 83) { return "先煎自定义"; }
            else { return "后下自定义"; }
        };
        result.FieldFormator.Register("decscheme", proc3);

        dotNetFlexGrid.FieldFormatorHandle proc4 = delegate(DataRow dr)
        {

            int a = Convert.ToInt32(dr["decmothed"].ToString());
            if (a == 1)
            {
                return "先煎";
            }
            else if (a == 2)
            {
                return "后下";
            }
            else
            {
                return "加糖加蜜";
            }




        };
        result.FieldFormator.Register("decmothed", proc4);
        dotNetFlexGrid.FieldFormatorHandle proc6 = delegate(DataRow dr)
        {

            int a = Convert.ToInt32(dr["takeway"].ToString());
            if (a == 1)
            {
                return "水煎餐后";
            }
            else
            {
                return "";
            }




        };
        result.FieldFormator.Register("takeway", proc6);
        dotNetFlexGrid.FieldFormatorHandle proc5 = delegate(DataRow dr)
        {

            int a = Convert.ToInt32(dr["dtbtype"].ToString());
            if (a == 1)
            {
                return "顺丰";
            }
            else if (a == 2)
            {
                return "圆通";
            }
            else
            {
                return "中通";
            }




        };
        result.FieldFormator.Register("dtbtype", proc5);
        return result;
    }
    public dotNetFlexGrid.DataHandlerResult FlexGridFlexGridDrugDataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际
        DrugModel dm = new DrugModel();

        string pid = "";
        if (p.extParam.ContainsKey("pid"))
        {
            pid = p.extParam["pid"];
        }

        result.table = dm.findDrugByPspnum1232(pid);

        return result;
    }
 

    protected void btn_Click(object sender, EventArgs e)
    {
       // this.TextBox1.Text = "voodooer";
    }
    [WebMethod]
    public static int deleteRecipeById(string strRowIds, string strRowIds2)
    {
        int result = 0;

        if(strRowIds != "0"){

            string[] strRowsId = strRowIds.Split(',');
            for (int i = 0; i < strRowsId.Length; i++)
            {
                RecipeModel rm = new RecipeModel();
                result = rm.deleteRecipeInfo(Convert.ToInt16(strRowsId[i]));
            }
        }
        if (strRowIds2 != "0")
        {
            string[] strRowsId2 = strRowIds2.Split(',');
            for (int i = 0; i < strRowsId2.Length; i++)
            {
                RecipeModel rm = new RecipeModel();
                result = rm.deleteDrugInfo(Convert.ToInt16(strRowsId2[i]));
            }

        }
        return result;

    }
    //导出数据
    protected void Button1_Click(object sender, EventArgs e)
    {
        string Pspnum1 = Pspnum.Value;
        string time1 = time.Value;
        string patient1 = patient.Value;
        string tisaneid1 = tisaneid.Value;
        string doper1 = doper.Value;
        string hospitalID1 = hospitalname.Value;


        string jftime1 = JTime.Value;
       

        if (Pspnum1 == "")
        {
            Pspnum1 = "0";
        }
        if (time1 == "")
        {
            time1 = "0";
        }
        if (patient1 == "")
        {
            patient1 = "0";
        }
        if (tisaneid1 == "")
        {
            tisaneid1 = "0";
        }
        if (doper1 == "")
        {
            doper1 = "0";
        }
       

        RecipeModel rm = new RecipeModel();

        DataTable dt = rm.findRecipeInfoDao(hospitalID1, Pspnum1, time1, patient1, tisaneid1, doper1, jftime1);
        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now;
        string now = currentTime.ToString("yyyyMMdd");
        CreateExcel(dt, "application/ms-excel", "接方查询处方信息" + now);
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

        string ls_item = "序号\t委托单号\t医院编号\t医院名称\t处方号\t煎药方式\t姓名\t性别\t年龄\t电话\t地址\t科室\t病区号\t 病房号\t病床号\t诊断结果"
            + " \t贴数\t服用方式\t次数 \t包装量\t煎药方案\t一煎时间 \t二煎时间\t浸泡加水量\t浸泡时间\t标签数量\t备注信息\t医生\t医生脚注\t取药时间\t取药序号\t下单时间\t包装状态\t操作时间\t操作人员\t配送公司\t配送地址\t配送电话\t配送类型\t服用方法  \t备注A\t备注B"
            + "\n";

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
    //导出数据
    protected void Button2_Click(object sender, EventArgs e)
    {
        string Pspnum1 = Pspnum.Value;
        string time1 = time.Value;
        string patient1 = patient.Value;
        string tisaneid1 = tisaneid.Value;
        string doper1 = doper.Value;
        string hospitalID1 = hospitalname.Value;
        string jftime1 = JTime.Value;

        if (Pspnum1 == "")
        {
            Pspnum1 = "0";
        }
        if (time1 == "")
        {
            time1 = "0";
        }
        if (patient1 == "")
        {
            patient1 = "0";
        }
        if (tisaneid1 == "")
        {
            tisaneid1 = "0";
        }
        if (doper1 == "")
        {
            doper1 = "0";
        }


        RecipeModel rm = new RecipeModel();

        DataTable dt = rm.findDrugInfobyCondition(hospitalID1, Pspnum1, time1, patient1, tisaneid1, doper1, jftime1);
        
        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now;
        string now = currentTime.ToString("yyyyMMdd");
        CreateExcel1(dt, "application/ms-excel", "接方查询药品信息" + now);
    }
    public void CreateExcel1(DataTable dt, string FileType, string FileName)
    {
        Response.Clear();
        Response.Charset = "UTF-8";
        Response.Buffer = true;
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls\"");
        Response.ContentType = FileType;
        string colHeaders = string.Empty;
        //string ls_item = string.Empty;

        string ls_item = "序号\t医院编号\t医院名称\t处方号\t药品编号\t药品名称\t脚注\t药品规格\t单剂量\t总剂量\t贴数\t说明\t批发价\t零售价\n";

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
}