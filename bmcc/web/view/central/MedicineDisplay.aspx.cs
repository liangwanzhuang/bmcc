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
public partial class view_central_MedicineDisplay : System.Web.UI.Page
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







        this.FlexGridMedicineDisplay.InitConfig(
                      new string[]{
                //"title=发药信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                 "showcheckbox=false",//显示复选框
                "height=533",//高度，可为auto或具体px值
                "width=1316",//宽度，可为auto或具体px值
               "AllowUserResizing=4",
              
             "CellFontSize=50px"
            
            },
          

                      new dotNetFlexGrid.FieldConfig[]{
                 new dotNetFlexGrid.FieldConfig("DecoctingNum","煎药单号",110,true,dotNetFlexGrid.FieldConfigAlign.Center),
                   new dotNetFlexGrid.FieldConfig("hname","医院名称",140,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("name","患者姓名",140,false,dotNetFlexGrid.FieldConfigAlign.Center),

                
                 new dotNetFlexGrid.FieldConfig("Pspnum","处方号",150,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("getdrugnum","取药号",150,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("getdrugtime","取药时间",210,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("Sendpersonnel","发药人员",150,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("SendTime","发药时间",210,false,dotNetFlexGrid.FieldConfigAlign.Center),
             
                new dotNetFlexGrid.FieldConfig("Sendstate","发药状态",150,false,dotNetFlexGrid.FieldConfigAlign.Center),
              //  new dotNetFlexGrid.FieldConfig("disinfectionstatus","发药单号",140,false,dotNetFlexGrid.FieldConfigAlign.Center),
             
           },
                   null
                   ,
                      null
                  );
        this.FlexGridMedicineDisplay.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);//提供数据的方法

       
    }
    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际
        DeliveryModel rm = new DeliveryModel();

        result.table = rm.MedicineDisplayInfo();
        dotNetFlexGrid.FieldFormatorHandle proc2 = delegate(DataRow dr)
        {

            int bstatus = Convert.ToInt32(dr["Sendstate"].ToString());
            if (bstatus == 1)
            {
                return "已发货";
            }
            else
            {
                return "待发货";
            }

        };
        result.FieldFormator.Register("Sendstate", proc2);
   


        return result;
    }


    [WebMethod]
    public static string countstatistics()
    {
        Statistics st = new Statistics();
        string result = st.getdeliveryinfo();
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
                if ("发药显示".Equals(limitsName))
                {
                    return true;
                }
            }
        }

        return false;
    }
}