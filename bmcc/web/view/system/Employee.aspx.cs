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


public partial class view_system_Employee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
           {
            EmployeeModel hm = new EmployeeModel();
            SqlDataReader sdr = hm.findEmployeeAll();
            EmployeeModel hm1 = new EmployeeModel();
            SqlDataReader sdr1 = hm1.findEmployeeAll();
           // EName.Items.Add(new ListItem("全部", "0"));
           /*if (sdr != null)
            {
                while (sdr.Read())
                {
                    this.EName.Items.Add(new ListItem(sdr["EName"].ToString(), sdr["ID"].ToString()));

                }
            }
            */

           /* JobNum.Items.Add(new ListItem("全部", "0"));
            if (sdr1 != null)
            {
                while (sdr1.Read())
                {
                    this.JobNum.Items.Add(new ListItem(sdr1["JobNum"].ToString(), sdr1["ID"].ToString()));

                }
            }*/

        }
        this.FlexGridEmployee.InitConfig(
            new string[]{
                "title=员工信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=755"//宽度，可为auto或具体px值
            },
            new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("ID","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),

                new dotNetFlexGrid.FieldConfig("JobNum","员工工号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("EName","姓名",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Role","角色",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("Sex","性别",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Age","年龄",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("Phone","电话",60,false,dotNetFlexGrid.FieldConfigAlign.Center),  
                new dotNetFlexGrid.FieldConfig("Address","住址",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Nation","民族",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Origin","籍贯",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("pwd","密码",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
           },
         null
         ,
            null
        );
        this.FlexGridEmployee.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(FlexGridEmployeeDataHandler);  //提供数据的方法
    }

    public dotNetFlexGrid.DataHandlerResult FlexGridEmployeeDataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        EmployeeModel rm = new EmployeeModel();
        string EName = "0";
        if (p.extParam.ContainsKey("EName"))
        {
            EName = p.extParam["EName"];
        }
        string JobNum = "0";
        if (p.extParam.ContainsKey("JobNum"))
        {
            JobNum = p.extParam["JobNum"];
        }
        string role = "";
        if (p.extParam.ContainsKey("role"))
        {
            role = p.extParam["role"];
        }

        if (EName == "0" || EName=="")
        {
            EName = "0";
        }
        if (JobNum == "0" || JobNum == "")
        {
            JobNum = "0";
        }
      
        //result.table = rm.findRecipeInfo(11, "111");
        // result.table = rm.findPackingInfo(Fpactate, Pacpersonnel, PacTime);

        result.table = rm.findEmployeeInfo(EName, JobNum, role);
        dotNetFlexGrid.FieldFormatorHandle proc2 = delegate(DataRow dr)
        {

            int a = Convert.ToInt32(dr["Sex"].ToString());
            if (a == 1)
            {
                return "男";
            }
            else
            {
                return "女";
            }

        };
        result.FieldFormator.Register("Sex", proc2);



        dotNetFlexGrid.FieldFormatorHandle proc3 = delegate(DataRow dr)
        {

            int a = Convert.ToInt32(dr["Role"].ToString());
            if (a == 0)
            {
                return "管理员";
            }
            else if (a == 1)
            {
                return "调剂人员";
            }
            else if (a == 2)
            {
                return "复核人员";
            }
            else if (a == 3)
            {
                return "泡药人员";
            }

            else if (a == 4)
            {
                return "煎药人员";
            }
            else if (a == 5)
            {
                return "包装人员";
            }

            else if (a == 6)
            {
                return "发货人员";
            }
            else if (a == 7)
            {
                return "接方人员";
            }
            else if (a == 8)
            {
                return "配方人员";
            }
            else if (a == 9)
            {
                return "医院登录人员";
            }
            else if (a == 10)
            {
                return "医院人员";
            }
            else 
            {
                return "无";
            }



        };
        result.FieldFormator.Register("Role", proc3);


       /* EmployeeHandler ehandler = new EmployeeHandler();
        result.table = ehandler.SearchEmployee();*/
        return result;
        
      
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        // this.TextBox1.Text = "voodooer";
    }
    [WebMethod]
    public static string getNumByEName(String EName)
    {
        EmployeeModel hm = new EmployeeModel();
        DataTable dt = hm.findNumByEName(EName);

        string data = "";
        data = dt.Rows[0][0].ToString();
       


        return data ;

    }
    [WebMethod]
    public static bool deleteEmployeeById(string strRowIds)
    {
        string[] strRows1Id = strRowIds.Split(',');
        for (int i = 0; i < strRows1Id.Length; i++)
        {
            EmployeeModel rm = new EmployeeModel();
            rm.deleteEmployeeInfo(Convert.ToInt16(strRows1Id[i]));
        }

        return true;

    }
 
}