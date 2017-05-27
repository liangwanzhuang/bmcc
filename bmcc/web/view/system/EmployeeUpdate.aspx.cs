using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data;
using System.Web.Services;

public partial class view_system_EmployeeUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            Sex1.Items.Add(new ListItem("男", "1"));
            Sex1.Items.Add(new ListItem("女", "2"));
           }
        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum1.Value = Request.QueryString["id"].ToString();
            EmployeeModel rm = new EmployeeModel();
            DataTable dt = rm.findEmployeeInfo(id);

            JobNum1.Value = dt.Rows[0]["JobNum"].ToString();
            EName1.Value = dt.Rows[0]["EName"].ToString();
            Role1.Value = dt.Rows[0]["Role"].ToString();
            Age1.Value = dt.Rows[0]["Age"].ToString();
            Sex1.Value = dt.Rows[0]["Sex"].ToString();
            Nation1.Value = dt.Rows[0]["Nation"].ToString();
            Address1.Value = dt.Rows[0]["Address"].ToString();
            Phone1.Value = dt.Rows[0]["Phone"].ToString();
            Origin1.Value = dt.Rows[0]["Origin"].ToString();
            password1.Value = dt.Rows[0]["pwd"].ToString();
        }

    }
     [WebMethod]
    public static string EmployeeInfo(int id, string JobNum, string EName, string Role, string Age, string Sex, string Nation, string Phone, string Address, string Origin, string password)
     
    {
        EmployeeModel winfo = new EmployeeModel();
        int result = winfo.updateEmployeeInfo1(id, JobNum, EName, Role, Age, Sex, Nation, Phone, Address, Origin,password);

        string str = null;
        if (result == 0)
        {
           str = "0";
       }
        else
        {
            str = "1";
        }
        return str;
    }
}