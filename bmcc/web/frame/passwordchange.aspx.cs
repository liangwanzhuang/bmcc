using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using SQLDAL;
using DataBaseAccessLib;
using ModelInfo;
using System.Data.SqlClient;

public partial class frame_passwordchange : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
string oldpwd = "";
        string newpwd = "";
        string dosure = "";


        string strTip = "";

        if (Password1.Value == "")
        {
            strTip += "旧密码；";
        }
        if (txtUserPwd.Value == "")
        {
            strTip += "新密码；";
        }
        if (txtUserPwd2.Value == "")
        {
            strTip += "确认密码；";
        }
      

        if (strTip != "")
        {
            strTip = "以下信息不能空，请填写: " + strTip;

            Page.ClientScript.RegisterStartupScript(
            this.GetType(), "myscript",
            "<script type=\"text/javascript\">function ShowAlert(){alert('" + strTip + "');}window.onload=ShowAlert;</script>");
            return;
        }

        UserInfo uf = new UserInfo();
        string usernamebar = "";
        if (Session["userNamebar"] != null)
        {
            usernamebar = Session["userNamebar"].ToString();
        }

        oldpwd = Request.Form["Password1"];//老密码
        newpwd = Request.Form["txtUserPwd"];//新密码
        dosure = Request.Form["txtUserPwd2"];//确定密码
        DataBaseLayer db = new DataBaseLayer();

        SqlDataReader sr = uf.login(usernamebar);

        if (sr.Read())
        {
            if (sr["pwd"].ToString() == oldpwd)
            {
                if (newpwd == dosure)
                {
                    string str = "update employee set pwd ='" + newpwd + "'where JobNum='" + usernamebar+ "'";
                   int result = db.cmd_Execute(str);
                   if (result == 1)
                   {
                       Page.ClientScript.RegisterStartupScript(
              this.GetType(), "myscript",
              "<script type=\"text/javascript\">function ShowAlert(){alert('修改密码成功');}window.onload=ShowAlert;</script>");
                   }
                   else
                   {
                       Page.ClientScript.RegisterStartupScript(
                                   this.GetType(), "myscript",
                                   "<script type=\"text/javascript\">function ShowAlert(){alert('修改密码不成功');}window.onload=ShowAlert;</script>");
                   }

                }

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(
              this.GetType(), "myscript",
              "<script type=\"text/javascript\">function ShowAlert(){alert('旧密码输入的不正确');}window.onload=ShowAlert;</script>");
            }


        }
    }
}
