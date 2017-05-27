using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Script.Services;
using System.Web.Services;
using System.Data;
public partial class view_recipe_RecipeQuery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {



        if (!IsPostBack)
        {

            RecipeModel rm = new RecipeModel();
            SqlDataReader sdr2 = rm.findisneedcheckstatus();
            string isneedcheck = "";
            if (sdr2.Read())
            {
                isneedcheck = sdr2["isneedcheck"].ToString();
            }

            if (isneedcheck == "0")
            {
                this.recheck.Style["display"] = "block";
                
            }
            else
            {

            }

            string cTime = System.DateTime.Now.ToString("yyyy-MM-dd");//当前时间

            // string currenttime = c
            //cTime.ToString("yyyy-MM-dd");

            JTime.Value = cTime;



        }

      //  Statistics sc = new Statistics();
      //  string str = sc.countall();


      //  String[] strArr = str.Split(',');

        //count.Text = "统计: 已录入: " + strArr[9] + "  已审核: " + strArr[8] + "   已打印: " + strArr[7] + "   未打印: " + strArr[10] + "   已匹配: " + strArr[6] + "   未匹配: " + strArr[11] + "   已调剂: " + strArr[5] + "  已复核: " + strArr[4] + "  已泡药: " + strArr[0] + "  已煎药: " + strArr[1] + "  已包装：" + strArr[2] + "  已发货：" + strArr[3] + " ";
        //count.Text = "统计：已接方: " + strArr[9] + "    已审核: " + strArr[8] + "     未匹配: " + strArr[11] + "     调剂: " + strArr[5] + "    复核: " + strArr[4] + "    泡药: " + strArr[0] + "    煎药: " + strArr[1] + "     包装：" + strArr[2] + "    发货：" + strArr[3] + " ";
        this.FlexGridRecipe.InitConfig(
             new string[]{
                "title=处方信息",//标题
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
                new dotNetFlexGrid.FieldConfig("dose","贴数",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                
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
                new dotNetFlexGrid.FieldConfig("curstate","当前状态",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dotime","操作时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("doperson","操作人员",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbcompany","配送公司",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbaddress","配送地址",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbphone","联系电话",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbtype","快件类型",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
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
                new dotNetFlexGrid.FieldConfig("ID","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("delnum","委托单号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hnum","医院编号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hname","医院名称",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Pspnum","处方号",95,false,dotNetFlexGrid.FieldConfigAlign.Center),
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
        this.FlexGridDrug.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid2DataHandler);  //提供数据的方法

    }

    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        RecipeModel rm = new RecipeModel();
        //处方状态,0全部,1匹配,2未匹配
       /* int pageSize = p.rp;
        string status = "0";
        if (p.extParam.ContainsKey("status"))
        {
            status = p.extParam["status"];
        }
        string workContent = "";
        if (p.extParam.ContainsKey("workContent"))
        {
            workContent = p.extParam["workContent"];
        }
        string dateStatus = "";
        if (p.extParam.ContainsKey("dateStatus"))
        {
            dateStatus = p.extParam["dateStatus"];
        }

        pageSize = 1;
        if (status.Equals("1"))
        {
            result.table = rm.findMatchRecipeInfo("", "", "", p.page, pageSize);
            result.total = rm.findMatchRecipeTotal("", "", "");
        }
        else if (status.Equals("2"))
        {
            result.table = rm.findNotMatchRecipeInfo("", "", "", p.page, pageSize);
            result.total = rm.findNotMatchRecipeTotal("", "", "");
        }
        else
        {
            result.table = rm.findAllRecipeInfo(p.page, pageSize);
            result.total = rm.findAllRecipeTotal();
            
        }*/



        string Employeenum = "";
        if (p.extParam.ContainsKey("Employeenum"))
        {
            Employeenum = p.extParam["Employeenum"];
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
        string RecipeStatus = "";
        if (p.extParam.ContainsKey("RecipeStatus"))
        {
            RecipeStatus = p.extParam["RecipeStatus"];
        }
        string Psnum = "";
        if (p.extParam.ContainsKey("Psnum"))
        {
            Psnum = p.extParam["Psnum"];
        }


        string JTime = System.DateTime.Now.ToString("yyyy-MM-dd");
        if (p.extParam.ContainsKey("JTime"))
        {
            JTime = p.extParam["JTime"];
        }


        int pageSize = p.rp;
        result.table = rm.searchInfo(Employeenum, STime, ETime, RecipeStatus, Psnum, JTime);

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


    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid2DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        DrugModel dm = new DrugModel();
        string pspnum = "0";
        string hospitalId = "";
       // if (p.extParam.ContainsKey("drugpspnum"))
      //  {
     //       pspnum = p.extParam["drugpspnum"];
     //   }
      //  if (p.extParam.ContainsKey("hospitalId"))
      //  {
      //      hospitalId = p.extParam["hospitalId"];
      //  }
        string pid = "";
        if (p.extParam.ContainsKey("pid"))
             {
                 pid = p.extParam["pid"];
              }

        result.table = dm.findDrugByPspnum(pid);

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
    //重新审核
        [WebMethod]
    public static string  ReAuditRecipeById(string strRowIds)
    {
        string result = "";
        int sdr =0;
        string[] strRowsId = strRowIds.Split(',');
        for (int i = 0; i < strRowsId.Length; i++)
        {
            RecipeModel rm = new RecipeModel();
             sdr = rm.ReAuditRecipeInfo(Convert.ToInt16(strRowsId[i]));
        }

        if (sdr == 0)
        {
            result = "0";
        }
        else
        {
            result = "1";
        }

        return result;

    }
    //作废
    [WebMethod]
    public static string deleteRecipeById(string strRowIds)
        {
            string result = "";
            int sdr = 0;
        string[] strRowsId = strRowIds.Split(',');
        for (int i = 0; i < strRowsId.Length; i++)
        {
            RecipeModel rm = new RecipeModel();
             sdr = rm.deleteRecipeInfo1(Convert.ToInt16(strRowsId[i]));
        }
        if (sdr == 0)
        {
            result = "0";
        }
        else
        {
            result = "1";
        }

        return result;

    }
    //取消作废
   
        [WebMethod]
    public static string CloseRecipeById(string strRowIds)
        {
            string result = "";
            int sdr = 0;
        string[] strRowsId = strRowIds.Split(',');
        for (int i = 0; i < strRowsId.Length; i++)
        {
            RecipeModel rm = new RecipeModel();
            sdr = rm.CloseRecipeInfo(Convert.ToInt16(strRowsId[i]));
        }
        if (sdr == 0)
        {
            result = "0";
        }
        else
        {
            result = "1";
        }

        return result;

    }
        //导出数据
        protected void Button1_Click(object sender, EventArgs e)
        {
            string Employeenum1 = Employeenum.Value;
            string STime1 = STime.Value;
            string ETime1 = ETime.Value;
            string RecipeStatus1 = RecipeStatus.Value;
            string Psnum1 = Psnum.Value;
            string jftime1 = JTime.Value;


            RecipeModel rm = new RecipeModel();

            DataTable dt = rm.searchInfoDao(Employeenum1, STime1, ETime1, RecipeStatus1, Psnum1, jftime1);
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            string now = currentTime.ToString("yyyyMMdd");
            CreateExcel(dt, "application/ms-excel", "配方查询处方信息" + now);
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

            string ls_item = "序号\t委托单号\t医院编号\t医院名称\t处方号\t姓名\t性别\t年龄\t电话\t地址\t科室\t病区号\t 病房号\t病床号\t诊断结果"
                + " \t贴数\t次数\t取药时间\t取药序号 \t服用方式\t煎药方案\t一煎时间 \t二煎时间 \t包装量\t操作时间\t操作人员\t配送公司\t配送地址\t配送电话\t配送类型 \t浸泡加水量\t浸泡时间\t标签数量 \t备注信息\t医生\t医生脚注\t下单时间\t包装状态  \t备注A\t备注B"
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
            string Employeenum1 = Employeenum.Value;
            string STime1 = STime.Value;
            string ETime1 = ETime.Value;
            string RecipeStatus1 = RecipeStatus.Value;
            string Psnum1 = Psnum.Value;
            string jftime1 = JTime.Value;
            RecipeModel rm = new RecipeModel();

            DataTable dt = rm.findDrugInfobyCondition1(Employeenum1, STime1, ETime1, RecipeStatus1, Psnum1, jftime1);
            

            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            string now = currentTime.ToString("yyyyMMdd");
            CreateExcel1(dt, "application/ms-excel", "配方查询药品信息" + now);
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