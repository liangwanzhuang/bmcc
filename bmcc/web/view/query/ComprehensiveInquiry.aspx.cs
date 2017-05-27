using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using ModelInfo;
using System.Data.SqlClient;

public partial class view_query_ComprehensiveInquiry : System.Web.UI.Page
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

            // string currenttime = c
            //cTime.ToString("yyyy-MM-dd");

            JTime.Value = cTime;
            
        }
        this.FlexGridRecipe.InitConfig(
            new string[]{
                "title=处方信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "singleselected=true",//是否单选
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=1090"//宽度，可为auto或具体px值
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
                
                new dotNetFlexGrid.FieldConfig("dtbcompany","配送公司",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbaddress","配送地址",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbphone","联系电话",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbtype","快件类型",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("doperson1","接方人员",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dotime","接方时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
               
                new dotNetFlexGrid.FieldConfig("PartyPer","审方人员",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("PartyTime","审方时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("checkStatus","审方结果",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
               new dotNetFlexGrid.FieldConfig("refusalreason","审方说明",60,false,dotNetFlexGrid.FieldConfigAlign.Center),

         new dotNetFlexGrid.FieldConfig("SwapPer","调剂人员",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
         new dotNetFlexGrid.FieldConfig("wordDate","调剂开始",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
         new dotNetFlexGrid.FieldConfig("endDate","调剂结束",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
        
         new dotNetFlexGrid.FieldConfig("ReviewPer","复核人员",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
         new dotNetFlexGrid.FieldConfig("AuditTime","复核时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
         new dotNetFlexGrid.FieldConfig("bubbleperson","泡药人员",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
         new dotNetFlexGrid.FieldConfig("bstarttime","泡药开始",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
         new dotNetFlexGrid.FieldConfig("bendDate","泡药结束",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
         new dotNetFlexGrid.FieldConfig("tisaneman","煎药人员",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
         new dotNetFlexGrid.FieldConfig("machineid","煎药机组",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
        new dotNetFlexGrid.FieldConfig("tstarttime","煎药开始",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
        new dotNetFlexGrid.FieldConfig("tendDate","煎药结束",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
        new dotNetFlexGrid.FieldConfig("Pacpersonnel","包装人员",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
         new dotNetFlexGrid.FieldConfig("packmachine","包装机",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
        new dotNetFlexGrid.FieldConfig("PacEndTime","包装开始",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
        
        new dotNetFlexGrid.FieldConfig("PacTime","包装结束",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
        new dotNetFlexGrid.FieldConfig("Sendpersonnel","发货人员",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
       
        new dotNetFlexGrid.FieldConfig("SendTime","发货时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),

        new dotNetFlexGrid.FieldConfig("SignPer","签收人员",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
         new dotNetFlexGrid.FieldConfig("SignTime","签收时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
       //SignPer,签收人员；SignTime ，签收时间；

        
           },
         null
         ,
            null
        );
        this.FlexGridRecipe.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);
    }  //提供数据的方法
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
        string RecipeStatus = "";
        if (p.extParam.ContainsKey("RecipeStatus"))
        {
            RecipeStatus = p.extParam["RecipeStatus"];
        }
      string hospitalID = "";
        if (p.extParam.ContainsKey("hospitalID"))
        {
            hospitalID = p.extParam["hospitalID"];
        }
      string tisaneid = "";
        if (p.extParam.ContainsKey("tisaneid"))
        {
            tisaneid = p.extParam["tisaneid"];
        }
      string patient = "";
        if (p.extParam.ContainsKey("patient"))
        {
            patient = p.extParam["patient"];
        }


    //    string jftime = System.DateTime.Now.ToString("yyyy-MM-dd");
        string jftime = "";
        if (p.extParam.ContainsKey("JTime"))
        {
            jftime = p.extParam["JTime"];
        }

      


        int pageSize = p.rp;
        result.table = rm.ComprehensiveInquiryInfo(Pspnum, STime, ETime, RecipeStatus, hospitalID, tisaneid, patient, jftime);
        /*//SignPer","签收人员
        dotNetFlexGrid.FieldFormatorHandle procac = delegate(DataRow dr)
        {
            string z = "";
            if (dr["SignPer"].ToString() == "")
            {
                String az = dr["SignPer"].ToString();
                az = "3";
                if (az == "3")
                {
         
                    z = "无";

                }
            }
            else
            {
                String az = dr["SignPer"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("SignPer", procac);
        //SignTime","签收时间
        dotNetFlexGrid.FieldFormatorHandle procaz = delegate(DataRow dr)
        {
            string z = "";
            if (dr["SignTime"].ToString() == "")
            {
                String az = dr["SignTime"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";
                   

                }
            }
            else
            {
                String az = dr["SignTime"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("SignTime", procaz);
       
     //待定数据
        */
        //泡药人员
        dotNetFlexGrid.FieldFormatorHandle proc91 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["bubbleperson"].ToString() == "")
            {
                String az = dr["bubbleperson"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["bubbleperson"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("bubbleperson", proc91);
        dotNetFlexGrid.FieldFormatorHandle procy = delegate(DataRow dr)
        {
            string z = "";
            if (dr["packmachine"].ToString() == "")
            {
                String az = dr["packmachine"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["packmachine"].ToString();
                z = az;
            }

            return z;

        };
    

        result.FieldFormator.Register("packmachine", procy);
        //煎药机
        dotNetFlexGrid.FieldFormatorHandle procya = delegate(DataRow dr)
        {
            string z = "";
            if (dr["machineid"].ToString() == "")
            {
                String az = dr["machineid"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["machineid"].ToString();
                z = az;
            }

            return z;

        };


        result.FieldFormator.Register("machineid", procya);
        //泡药开始
        dotNetFlexGrid.FieldFormatorHandle proc19 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["bstarttime"].ToString() == "")
            {
                String az = dr["bstarttime"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["bstarttime"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("bstarttime", proc19);
        //泡药结束
        dotNetFlexGrid.FieldFormatorHandle proc01 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["bendDate"].ToString() == "")
            {
                String az = dr["bendDate"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["bendDate"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("bendDate", proc01);
        //煎药人员
        dotNetFlexGrid.FieldFormatorHandle proc41 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["tisaneman"].ToString() == "")
            {
                String az = dr["tisaneman"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["tisaneman"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("tisaneman", proc41);
        //tstarttime","煎药开始
        dotNetFlexGrid.FieldFormatorHandle proc42 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["tstarttime"].ToString() == "")
            {
                String az = dr["tstarttime"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["tstarttime"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("tstarttime", proc42);
        //tendDate","煎药结束
        dotNetFlexGrid.FieldFormatorHandle proc43 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["tendDate"].ToString() == "")
            {
                String az = dr["tendDate"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["tendDate"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("tendDate", proc43);
        //Pacpersonnel","包装人员
        dotNetFlexGrid.FieldFormatorHandle proc54 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["Pacpersonnel"].ToString() == "")
            {
                String az = dr["Pacpersonnel"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["Pacpersonnel"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("Pacpersonnel", proc54);
        //PacTime","包装结束
        dotNetFlexGrid.FieldFormatorHandle proc51 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["PacTime"].ToString() == "")
            {
                String az = dr["PacTime"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["PacTime"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("PacTime", proc51);
        //PacTime","包装开始
        dotNetFlexGrid.FieldFormatorHandle proc00 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["PacEndTime"].ToString() == "")
            {
                String az = dr["PacEndTime"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["PacEndTime"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("PacEndTime", proc00);
        //Sendpersonnel","发货人员
        dotNetFlexGrid.FieldFormatorHandle proc52 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["Sendpersonnel"].ToString() == "")
            {
                String az = dr["Sendpersonnel"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["Sendpersonnel"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("Sendpersonnel", proc52);
        //SendTime","发货时间
        dotNetFlexGrid.FieldFormatorHandle proc53 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["SendTime"].ToString() == "")
            {
                String az = dr["SendTime"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["SendTime"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("SendTime", proc53);
     
        //审方人员
        dotNetFlexGrid.FieldFormatorHandle proc81 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["PartyPer"].ToString() == "")
            {
                String az = dr["PartyPer"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["PartyPer"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("PartyPer", proc81);
     //审核时间
        dotNetFlexGrid.FieldFormatorHandle proc82 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["PartyTime"].ToString() == "")
            {
                String az = dr["PartyTime"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["PartyTime"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("PartyTime", proc82);
        //审方结果
        dotNetFlexGrid.FieldFormatorHandle proc83 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["checkStatus"].ToString() == "")
            {
                String az = dr["checkStatus"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["checkStatus"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("checkStatus", proc83);
        //审方说明
        dotNetFlexGrid.FieldFormatorHandle proc84 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["refusalreason"].ToString() == "")
            {
                String az = dr["refusalreason"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["refusalreason"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("refusalreason", proc84);
    
     //处方列表信息
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
        dotNetFlexGrid.FieldFormatorHandle proca = delegate(DataRow dr)
        {
            string z = "";
            if ( dr["checkStatus"].ToString() == ""   ) {
                String az =dr["checkStatus"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "未审核";

                }
            }
            else
            {
                int az = Convert.ToInt32(dr["checkStatus"].ToString());

                if (az == 1)
                {
                    z = "已审核";
                }
                if (az == 2)
                {
                    z = "审核未通过";
                }
            }
            return z;

        };
        result.FieldFormator.Register("checkStatus", proca);
     //调剂人员
        dotNetFlexGrid.FieldFormatorHandle proc7 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["SwapPer"].ToString() == "")
            {
                String az = dr["SwapPer"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else {
                String az = dr["SwapPer"].ToString();
                z = az;
            }          
            return z;

        };
        result.FieldFormator.Register("SwapPer", proc7);
     //调剂开始
        dotNetFlexGrid.FieldFormatorHandle proc71 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["wordDate"].ToString() == "")
            {
                String az = dr["wordDate"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["wordDate"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("wordDate", proc71);
     //调剂结束
        dotNetFlexGrid.FieldFormatorHandle proc72 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["endDate"].ToString() == "")
            {
                String az = dr["endDate"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["endDate"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("endDate", proc72);
     //复核人员
        dotNetFlexGrid.FieldFormatorHandle proc73 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["ReviewPer"].ToString() == "")
            {
                String az = dr["ReviewPer"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["ReviewPer"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("ReviewPer", proc73);
     //复核时间
        dotNetFlexGrid.FieldFormatorHandle proc74 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["AuditTime"].ToString() == "")
            {
                String az = dr["AuditTime"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["AuditTime"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("AuditTime", proc74);


        return result;
    }
 //作废
    [WebMethod]
 public static string deleteCompById(string strRowIds)
        {
            string result = "";
            int sdr = 0;
        string[] strRowsId = strRowIds.Split(',');
        for (int i = 0; i < strRowsId.Length; i++)
        {
            RecipeModel rm = new RecipeModel();
            sdr = rm.deleteCompInfo1(Convert.ToInt16(strRowsId[i]));
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
            string Pspnum1 = Pspnum.Value;

            string STime1 = STime.Value;
            string ETime1 = ETime.Value;
            string RecipeStatus1 = RecipeStatus.Value;
            string hospitalID1 = hospitalname.Value;
            string tisaneid1 = tisaneid.Value;
            string patient1 = patient.Value;
            string jftime1 = JTime.Value;

            if (Pspnum1 == "")
            {
                Pspnum1 = "0";
            }
            if (STime1 == "")
            {
                STime1 = "0";
            }
            if (ETime1 == "")
            {
                ETime1 = "0";
            }
            if (patient1 == "")
            {
                patient1 = "0";
            }
            if (RecipeStatus1 == "")
            {
                RecipeStatus1 = "0";
            }
            if (hospitalID1 == "")
            {
                hospitalID1 = "0";
            }
            if (tisaneid1 == "")
            {
                tisaneid1 = "0";
            }

            RecipeModel rm = new RecipeModel();

            // DataBaseLayer db = new DataBaseLayer();
            //    string str = "select * from lossiInfor where type ='" + type + "'";
            DataTable dt = rm.ComprehensiveInquiryInfoDao(Pspnum1, STime1, ETime1, RecipeStatus1, hospitalID1, tisaneid1, patient1, jftime1);

            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            string now = currentTime.ToString("yyyyMMdd");
            CreateExcel(dt, "application/ms-excel", "综合查询处方信息" + now);


          //  CreateExcel(dt, "application/ms-excel", "excel");
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

            string ls_item = "序号\t 委托单号\t 医院编号 \t医院名称\t 处方号 \t患者姓名\t性别 \t 年龄\t 电话\t地址 \t 科室 \t 病区号\t  病房号\t病床号 \t诊断结果\t贴数\t次数\t取药时间\t取药号\t服用方式\t煎药方案\t一煎时间\t二煎时间\t包装量"
                + "\t配送公司\t配送地址\t联系电话\t快件类型\t浸泡加水量\t浸泡时间\t标签数量\t备注\t医生\t脚注\t下单时间\t备注1\t备注2\t审方人员\t审方时间\t审方结果\t审方说明\t调剂人员\t调剂开始\t调剂结束\t复核人员\t复核时间\t泡药人员\t泡药开始\t泡药结束\t煎药人员\t煎药开始\t煎药结束\t包装人员\t包装开始\t包装结束"
                
                +"\t发货人员\t发货时间\t签收人员\t签收时间\n ";

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





    //得到温度数据
        [WebMethod]
        public static string gettempertureById(string tid)
        {
            TeModel am = new TeModel();
            DataTable dt = am.gettemperture(tid);
           string  chartData = DataTableToJson.ToJson(dt);

           return chartData;
        }
}