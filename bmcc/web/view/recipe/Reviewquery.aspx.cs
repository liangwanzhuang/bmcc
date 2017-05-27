using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

public partial class view_recipe_Reviewquery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


       // WorkrecordQuInfo wq = new WorkrecordQuInfo();
       // string warningid = wq.recheckwarning();
       // warning.Value = warningid;

       // Statistics sc = new Statistics();
      //  string str = sc.countall();

        string url = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf(Request.RawUrl)); 
        //String[] strArr = str.Split(',');

       // count.Text = "统计: 已录入: " + strArr[9] + "  已审核: " + strArr[8] + "   已打印: " + strArr[7] + "   未打印: " + strArr[10] + "   已匹配: " + strArr[6] + "   未匹配: " + strArr[11] + "   已调剂: " + strArr[5] + "  已复核: " + strArr[4] + "  已泡药: " + strArr[0] + "  已煎药: " + strArr[1] + "  已包装：" + strArr[2] + "  已发货：" + strArr[3] + " ";
       // count.Text = "统计：已接方: " + strArr[9] + "    已审核: " + strArr[8] + "     未匹配: " + strArr[11] + "     调剂: " + strArr[5] + "    复核: " + strArr[4] + "    泡药: " + strArr[0] + "    煎药: " + strArr[1] + "     包装：" + strArr[2] + "    发货：" + strArr[3] + " ";
        this.dotNetFlexGrid3.InitConfig(
             new string[]{
                "title=复核人员扫码信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=1000"//宽度，可为auto或具体px值
            },
            // 序号、委托单号、医院编号、医院名称、处方号、煎药方式、姓名、性别、年龄、电话、地址、科室、病区号、
            //病房号、病床号、诊断结果、剂数、服用方式、次数、包装量、服用方法、煎药方案、一煎时间、二煎时间、
            //浸泡加水量、浸泡时间、标签数量、备注信息、医生、医生脚注、取药时间、取药序号、下单时间、当前状态、
            //操作时间、操作人员、配送公司、配送地址、联系电话、快件类型

             new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("ID","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("AuT","复核时间",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
              
                new dotNetFlexGrid.FieldConfig("delnum","委托单号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hnum","医院编号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hname","医院名称",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Pspnum","处方号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("Hospitalid","医院ID",60,true,dotNetFlexGrid.FieldConfigAlign.Center,false,true,false),
                new dotNetFlexGrid.FieldConfig("name","患者姓名",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("sex","性别",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("age","年龄",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("phone","电话",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("address","地址",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("department","科室",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("inpatientarea","病区号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ward","病房号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("sickbed","病床号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("diagresult","诊断结果",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("takemethod","服用方式",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("takenum","次数",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("packagenum","包装量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("decscheme","煎药方案",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("oncetime","一煎时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("twicetime","二煎时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("soakwater","浸泡加水量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("soaktime","浸泡时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("labelnum","标签数量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("remark","备注信息",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("doctor","医生",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("footnote","医生脚注",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("getdrugtime","取药时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("getdrugnum","取药序号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ordertime","下单时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("AuditStatus","当前状态",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dotime","操作时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("imgname","图片",60,true,dotNetFlexGrid.FieldConfigAlign.Center,false,false,true,"<img src='"+url+"/upload/[@imgname]'height='20px' onclick='showBigImg(this);' onerror='javascript:this.src=\""+url+"/images/icon_error.png\";'/>"),
                new dotNetFlexGrid.FieldConfig("ReviewPer","操作人员",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbcompany","配送公司",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbaddress","配送地址",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbphone","联系电话",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbtype","快件类型",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("RemarksA","备注A",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("RemarksB","备注B",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("warningstatus","预警状态",60,true,dotNetFlexGrid.FieldConfigAlign.Center),

           },
          null
          ,
             null
         );


        this.dotNetFlexGrid3.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(FlexGridRecipeDataHandler);  //提供数据的方法



        this.dotNetFlexGrid4.InitConfig(
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
                new dotNetFlexGrid.FieldConfig("ID","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("delnum","委托单号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hnum","医院编号",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hname","医院名称",95,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Pspnum","处方号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
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
               // new dotNetFlexGrid.FieldConfig("WholeSaleCost","批发费用",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("retailpricecost","零售费用",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("money","含税金额",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("Fee","扣率",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
           },
          null
          ,
             null
         );

        this.dotNetFlexGrid4.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(FlexGridFlexGridDrugDataHandler);  //提供数据的方法

    }

    public dotNetFlexGrid.DataHandlerResult FlexGridRecipeDataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        RecipeModel rm = new RecipeModel();
        string StartTime = "";
        if (p.extParam.ContainsKey("StartTime"))
        {
            StartTime = p.extParam["StartTime"];
        }
        string EndTime = "";
        if (p.extParam.ContainsKey("EndTime"))
        {
            EndTime = p.extParam["EndTime"];
        }
        string AuditPer = "";
        if (p.extParam.ContainsKey("AuditPer"))
        {
            AuditPer = p.extParam["AuditPer"];
        }
        string num = "";
        if (p.extParam.ContainsKey("num"))
        {
            num = p.extParam["num"];
        }
        int pageSize = p.rp;
        result.table = rm.searchReviewInfo(StartTime, EndTime, AuditPer,num);
        dotNetFlexGrid.FieldFormatorHandle proc = delegate(DataRow dr)
        {

            int bstatus = Convert.ToInt32(dr["AuditStatus"].ToString());
            if (bstatus == 1)
            {
                return "复核";
            }
            else
            {
                return "正在复核";
            }

        };
        result.FieldFormator.Register("AuditStatus", proc);

        dotNetFlexGrid.FieldFormatorHandle proc1 = delegate(DataRow dr)
        {
            if (dr["warningstatus"].ToString() == "1")
            {
                return "<span style='color:red'>黄色预警</span>";
            }
            else
            {
                return "<span style='color:black'>暂无预警</span>";
            }


        };
     


        result.FieldFormator.Register("warningstatus", proc1);


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
        string pspnum = "0";
        string hospitalId = "";
        if (p.extParam.ContainsKey("drugpspnum"))
        {
            pspnum = p.extParam["drugpspnum"];
        }
        if (p.extParam.ContainsKey("hospitalId"))
        {
            hospitalId = p.extParam["hospitalId"];
        }


      



        
        result.table = dm.findDrugInfo(pspnum, hospitalId);


        return result;
    }

  //删除
    [WebMethod]
    public static bool deleteReviewqueryById(string strRowIds)
    {
        int a = 0;
        bool result;
        string[] strRows1Id = strRowIds.Split(',');

        for (int i = 0; i < strRows1Id.Length; i++)
        {

            ReviewAddInfo rinfo = new ReviewAddInfo();

           a = rinfo.deleteRRecipeInfo(Convert.ToInt32(strRows1Id[i]));

        }
        if (a == 0)
        {
            result = false;
        }
        else
        {
            result = true;
        }

        return result;
    }
    //重审
    [WebMethod]
    public static int recipeCheck( int id)
    {
        int  result = 0;
        RecipeModel rm = new RecipeModel();
        int num = rm.AgainCheckPres(id);
        if (num == 0)
        {
            result = 0;
        }
        else
        {
            result = 1;
        }

        return result;

    }
        //return num;
  //  }
    //导出数据
    protected void Button1_Click(object sender, EventArgs e)
    {
        string StartTime1 = StartTime.Value;
        string EndTime1 = EndTime.Value;
        string AuditPer1 = AuditPer.Value;
        string num = id.Value;
    
        RecipeModel rm = new RecipeModel();

        // DataBaseLayer db = new DataBaseLayer();
        //    string str = "select * from lossiInfor where type ='" + type + "'";
        DataTable dt = rm.searchReviewInfDao(StartTime1, EndTime1, AuditPer1, num);
        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now;
        string now = currentTime.ToString("yyyyMMdd");
        CreateExcel(dt, "application/ms-excel", "复核查询处方信息" + now);
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

        string ls_item = "序号\t委托单号\t复核人员\t 照片\t复核状态 \t复核时间\t医院编号\t医院名称\t处方号\t煎药方式\t姓名\t性别\t年龄\t电话\t地址\t科室\t病区号\t 病房号\t病床号\t诊断结果"
            + " \t贴数\t服用方式\t次数 \t包装量\t煎药方案\t一煎时间 \t二煎时间\t浸泡加水量\t浸泡时间\t标签数量\t备注信息\t医生\t医生脚注\t取药时间\t取药序号\t下单时间\t包装状态\t操作时间\t接方人员\t配送公司\t配送地址\t配送电话\t配送类型\t服用方法  \t备注A\t备注B"
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
        string StartTime1 = StartTime.Value;
        string EndTime1 = EndTime.Value;
        string AuditPer1 = AuditPer.Value;
        string num = id.Value;

        RecipeModel rm = new RecipeModel();

        // DataBaseLayer db = new DataBaseLayer();
        //    string str = "select * from lossiInfor where type ='" + type + "'";
        DataTable dt = rm.findDrugInfobyCondition(StartTime1, EndTime1, AuditPer1, num);
        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now;
        string now = currentTime.ToString("yyyyMMdd");
        CreateExcel1(dt, "application/ms-excel", "复核查询药品信息" + now);
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



    [WebMethod]
    public static string getpcwarning()
    {

        WorkrecordQuInfo wq = new WorkrecordQuInfo();
        string warningid = wq.recheckwarning();
       
        return warningid;
    }
    

}