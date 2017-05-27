using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using SQLDAL;
using System.Data.SqlClient;

public partial class register : System.Web.UI.Page
{
    public DataBaseLayer db = new DataBaseLayer();
    public UserInfo uf = new UserInfo();
    String userPwd;
    String userName;
    String jobnum;
    String userPwd2;
    String phone;
    String email;

    protected void Page_Load(object sender, EventArgs e)
    {
        userPwd = Request.Form["txtUserPwd"];
        userName = Request.Form["txtUserName"];
        jobnum = Request.Form["txtJobNum"];
        userPwd2 = Request.Form["txtUserPwd2"];
        phone = Request.Form["txtTel"];
        email = Request.Form["txtEmail"];
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        SqlDataReader sr = uf.login(userName);
        if (sr.Read())
        {
            Page.ClientScript.RegisterStartupScript(
                this.GetType(), "myscript123",
                "<script type=\"text/javascript\">function ShowAlert(){alert('用户名已被注册');}window.onload=ShowAlert;</script>");
        }
        else
        {
            int count = uf.register(userName, db.GetMD5(userPwd), email, phone);
   
           if (count != 0)
            {
               // Page.ClientScript.RegisterStartupScript( this.GetType(), "myscript12345", "<script>alert('恭喜你注册成功！');window.location.href='new.aspx'</script>"); 
               // Page.ClientScript.RegisterStartupScript("false", "<script>alert('提示消息');window.location.href='new.aspx'</script>");


              // Response.Redirect("login.aspx", false);
                Response.Write("<script>alert('恭喜你注册成功');window.location.href='login.aspx'</script>");

            }
            else
            {
                Response.Redirect("register.aspx", false);
            }
       }


    }

    
}