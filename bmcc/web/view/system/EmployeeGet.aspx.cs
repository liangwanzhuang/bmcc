using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Web.Services;

public partial class view_system_EmployeeGet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Sex11.Items.Add(new ListItem("男", "1"));
            Sex11.Items.Add(new ListItem("女", "2"));
           




        }
    
    }

    [WebMethod]
    public static string addEmployeeinfo(string  JobNum,string EName,string Role,string  Age,string  Sex,string  Nation,string  Phone,string  Address,string  Origin,string password)
    {
        string result = "";


        //string str2 = str1.TrimStart('0');
        EmployeeHandler wr = new EmployeeHandler();

        int sdr = wr.AddEmployee(JobNum, EName, Role, Age, Sex, Nation, Phone, Address, Origin,password);
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



}
