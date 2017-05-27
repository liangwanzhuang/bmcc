using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;

public partial class view_central_DecoctingDisplay : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["userNamebar"] == null)
        {
            Response.Write("<script>alert('用户名已失效');window.parent.location.href='../../login.aspx'</script>");
            //Response.Write("<script>alert('用户名已失效');window.parent.loginview();</script>");

        }
        else
        {
            string usernamebar = Session["userNamebar"].ToString();


            EmployeeHandler eh = new EmployeeHandler();
            SqlDataReader sdr = eh.findrolebyname(usernamebar);
            string role = "";
            if (sdr.Read())
            {
                role = sdr["Role"].ToString();
            }
            if (role != "0")
            {
                if (!checkAuthority(role))
                {
                    Response.Write("<script>alert('没有访问权限');window.parent.location.href='../../default.aspx';</script>");
                }
            }


            
        }
      
     



        this.FlexGridDecoctingDisplay.InitConfig(
                             new string[]{
                //"title=煎药信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=false",//显示复选框
                "height=533",//高度，可为auto或具体px值
                "width=1316"//宽度，可为auto或具体px值
            },
            // 序号、委托单号、医院编号、医院名称、处方号、煎药方式、姓名、性别、年龄、电话、地址、科室、病区号、
            //病房号、病床号、诊断结果、剂数、服用方式、次数、包装量、服用方法、煎药方案、一煎时间、二煎时间、
            //浸泡加水量、浸泡时间、标签数量、备注信息、医生、医生脚注、取药时间、取药序号、下单时间、当前状态、
            //操作时间、操作人员、配送公司、配送地址、联系电话、快件类型

                             new dotNetFlexGrid.FieldConfig[]{
                 new dotNetFlexGrid.FieldConfig("ID","煎药单号",90,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hname","医院名称",120,true,dotNetFlexGrid.FieldConfigAlign.Center),

                new dotNetFlexGrid.FieldConfig("Pspnum","处方号",120,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("name","患者姓名",100,false,dotNetFlexGrid.FieldConfigAlign.Center),

                new dotNetFlexGrid.FieldConfig("getdrugnum","取药号",70,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("getdrugtime","取药时间",130,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("tisaneman","煎药人员",70,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("tisanetime","煎药时间",80,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("starttime","开始时间",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("tisanestatus","煎药状态",98,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("decscheme","煎药方案",185,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("oncetime","煎药时间一",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("twicetime","煎药时间二",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
           
           },
                          null
                          ,
                             null
                         );
        this.FlexGridDecoctingDisplay.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);//提供数据的方法


    }
    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        

        TeModel tm = new TeModel();
        result.table = tm.DecoctingDisplayInfo();

        dotNetFlexGrid.FieldFormatorHandle proc1a = delegate(DataRow dr)
        {

            string z = "";
            int bstatus = Convert.ToInt32(dr["tisanestatus"].ToString());
            string start = dr["starttime"].ToString();



            if (bstatus == 0)
            {
                System.DateTime currentTime = new System.DateTime();
                currentTime = System.DateTime.Now;
                string strtime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");//
                DateTime d1 = Convert.ToDateTime(strtime);//当前时间

                DateTime d2 = Convert.ToDateTime(start);//开始时间

                TimeSpan d3 = d1.Subtract(d2);//泡药时间

                int dT = Convert.ToInt32(d3.Days.ToString()) * 24 * 60 + Convert.ToInt32(d3.Hours.ToString()) * 60 + Convert.ToInt32(d3.Minutes.ToString());//转化为分钟数

                string dt = dT.ToString();

                z = dt;

            }
            else
            {

                z = dr["tisanetime"].ToString();

            }

            return z;


        };

        result.FieldFormator.Register("tisanetime", proc1a);


        dotNetFlexGrid.FieldFormatorHandle proc = delegate(DataRow dr)
        {
            string a = "";

            int tstatus = Convert.ToInt32(dr["tisanestatus"].ToString());

            if (tstatus == 0)
            {
                a = "开始煎药";

            }
            else if (tstatus == 1)
            {

                a = "煎药完成";
            }

            return a;

        };

        result.FieldFormator.Register("tisanestatus", proc);



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


    [WebMethod]
    public static string countstatistics()
    {
        Statistics st = new Statistics();
        string result = st.gettisaneinfo();
        return result;
    }


    public bool checkAuthority(string role)
    {
        EmployeeHandler eh = new EmployeeHandler();
        SqlDataReader sdr = eh.findEmployeelimits(role);
        string limits = "";
        if (sdr.Read())
        {
            limits = sdr["limits"].ToString();
        }
        if (limits.Length > 0)
        {
            string[] arrLimits = limits.Split('、');
            for (int i = 0; i < arrLimits.Length; i++)
            {
                string limitsName = arrLimits[i];
                if ("煎药显示".Equals(limitsName))
                {
                    return true;
                }
            }
        }

        return false;
    }
}