using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ModelInfo;
using System.Data.SqlClient;

public partial class view_central_ComprehenWarning : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HospitalModel hm = new HospitalModel();
            SqlDataReader sdr = hm.findHospitalAll();
            hospitalSelect.Items.Add(new ListItem("  全部  ", "0"));
            if (sdr != null)
            {
                while (sdr.Read())
                {
                    this.hospitalSelect.Items.Add(new ListItem(sdr["Hname"].ToString(), sdr["ID"].ToString()));

                }
            }
            }
            this.FlexGridRecipe.InitConfig(
                new string[]{
                "title=综合预警信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=false",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=1000"//宽度，可为auto或具体px值
            },
                // 序号、委托单号、医院编号、医院名称、处方号、煎药方式、姓名、性别、年龄、电话、地址、科室、病区号、
                //病房号、病床号、诊断结果、剂数、服用方式、次数、包装量、服用方法、煎药方案、一煎时间、二煎时间、
                //浸泡加水量、浸泡时间、标签数量、备注信息、医生、医生脚注、取药时间、取药序号、下单时间、当前状态、
                //操作时间、操作人员、配送公司、配送地址、联系电话、快件类型

                new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("seq","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("id","煎药单号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               
                new dotNetFlexGrid.FieldConfig("pspnum","处方号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hname","医院名称",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("getdrugtime","取药时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("getdrugnum","取药序号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("errortime","异常时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("errorman","异常操作人",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("errortype","异常类型",80,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("errordescription","异常描述",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("doneperson","处理人",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("donetime","处理时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("doneresult","处理结果",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
                
             
            

        
           },
             null
             ,
                null
            );
            this.FlexGridRecipe.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);
        }
     //提供数据的方法
    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        RecipeModel rm = new RecipeModel();


        string Pspnum = "";
        if (p.extParam.ContainsKey("Pspnum"))
        {
            Pspnum = p.extParam["Pspnum"];
        }
        string STime = "";
        if (p.extParam.ContainsKey("STime"))
        {
            STime = p.extParam["STime"];
        }
        string ETime = "";
        if (p.extParam.ContainsKey("ETime"))
        {
            ETime = p.extParam["ETime"];
        }
        string HandleStatus = "";
        if (p.extParam.ContainsKey("HandleStatus"))
        {
            HandleStatus = p.extParam["HandleStatus"];
        }


        string EarlyWarning = "";
        if (p.extParam.ContainsKey("EarlyWarning"))
        {
            EarlyWarning = p.extParam["EarlyWarning"];
        }

        string hospitalId = "0";
        if (p.extParam.ContainsKey("hospitalId"))
        {
            hospitalId = p.extParam["hospitalId"];
        }




      
        if (Pspnum == "" || Pspnum=="0")
        {
            Pspnum = "0";
        }
        if (STime == "" || STime == "0")
        {
            STime = "0";
        }
        if (ETime == "" || ETime == "0")
        {
            ETime = "0";
        }
        if (EarlyWarning == "" || EarlyWarning == "0")
        {
            EarlyWarning = "0";
        }
        if (hospitalId == "" || hospitalId == "0")
        {
            hospitalId = "0";
        }

        if (HandleStatus == "" || HandleStatus == "0")
        {
            HandleStatus = "0";
        }


        result.table = rm.WarningInfo(Convert.ToInt32(hospitalId), Pspnum, STime, ETime, HandleStatus, EarlyWarning);

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

        result.table = rm.WarningInfo(Convert.ToInt32(hospitalId), Pspnum, STime, ETime, HandleStatus, EarlyWarning);

        dotNetFlexGrid.FieldFormatorHandle errortimeDelegate = delegate(DataRow dr)
        {

            string str = dr["errortime"].ToString();
            if ("1970/1/1 0:00:00".Equals(str))
            {
                return "";
            }
            else
            {
                return str;
            }

        };
        result.FieldFormator.Register("errortime", errortimeDelegate);

        
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


        dotNetFlexGrid.FieldFormatorHandle proc7 = delegate(DataRow dr)
        {

            string errortype =dr["errortype"].ToString();
            string doneresult = dr["doneresult"].ToString();
            if (errortype == "调剂警告" && (doneresult != ""))
            {
                return "进入调剂阶段";
            }
            else if (errortype == "审核警告" && (doneresult == "2"))
            {
                return "审核完成";
            }
            else if (errortype == "审核警告" && (doneresult != ""))
            {
                return "进入审核阶段";
            }
            else if (errortype == "复核警告" && (doneresult != ""))
            {
                return "进入复核阶段";
            }
            else if (errortype == "泡药警告" && (doneresult != ""))
            {
                return "进入泡药阶段";
            }
            else if (errortype == "煎药警告" && (doneresult != ""))
            {
                return "进入煎药阶段";
            }
            else if (errortype == "包装警告" && (doneresult != ""))
            {
                return "进入包装阶段";
            }
            else if (errortype == "发货警告" && (doneresult != ""))
            {
                return "进入发货阶段";
            }
            else
            {
                return "";
            }
           
        };
        result.FieldFormator.Register("doneresult", proc7);

        dotNetFlexGrid.FieldFormatorHandle proc8 = delegate(DataRow dr)
        {

            string errortype = dr["errortype"].ToString();
            string doneresult = dr["doneresult"].ToString();
            if (errortype == "审核警告" && (doneresult == "2"))
            {
                return "审核异常";
            }
            return errortype;

        };
        result.FieldFormator.Register("errortype", proc8);







        return result;
    }
    //导出数据
    protected void Button1_Click(object sender, EventArgs e)
    {
        string Pspnum1 = Pspnum.Value;
        string EarlyWarning1 = EarlyWarning.Value;
        string STime1 = STime.Value;
        string ETime1 = ETime.Value;
        string hospitalId1 = hospitalSelect.Value;
        string HandleStatus1 = HandleStatus.Value;

        if (Pspnum1 == "" || Pspnum1 == "0")
        {
            Pspnum1 = "0";
        }
        if (STime1 == "" || STime1 == "0")
        {
            STime1 = "0";
        }
        if (ETime1 == "" || ETime1 == "0")
        {
            ETime1 = "0";
        }
        if (EarlyWarning1 == "" || EarlyWarning1 == "0")
        {
            EarlyWarning1 = "0";
        }
        if (hospitalId1 == "" || hospitalId1 == "0")
        {
            hospitalId1 = "0";
        }

        if (HandleStatus1 == "" || HandleStatus1 == "0")
        {
            HandleStatus1 = "0";
        }


        RecipeModel rm = new RecipeModel();
        DataTable dt = rm.WarningInfo(Convert.ToInt32(hospitalId1), Pspnum1, STime1, ETime1, HandleStatus1, EarlyWarning1);

        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now;
        string now = currentTime.ToString("yyyyMMdd");
        CreateExcel(dt, "application/ms-excel", "综合预警" + now);
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

        string ls_item = "序号\t煎药单号\t 处方号\t 医院名称 \t取药时间\t取药序号 \t 异常时间\t异常操作人 \t异常类型 \t 异常描述\t处理人\t处理时间\t 处理结果 \n  ";

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