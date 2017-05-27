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



public partial class login : System.Web.UI.Page
{
    public DataBaseLayer db = new DataBaseLayer();


    /// <summary>
    /// 员工工号
    /// </summary>
    public string userNamebar = "";

    /// <summary>
    /// 密码
    /// </summary>
    public string userPwd = "";
    /// <summary>
    /// <summary>
    /// 页面加载
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// 
    public bool flag;

    public string userError = "";
    public UserInfo uf = new UserInfo();


    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        // userName = Request.Form["uname"];
        userPwd = Request.Form["txtUserPwd"];
        userNamebar = Request.Form["txtUserName"];
        //userError = Request.Form["txtError"];


        SqlDataReader sr = uf.login(userNamebar);

        if (sr.Read())
        {

            if (sr["JobNum"].ToString() == userNamebar && sr["pwd"].ToString() == userPwd)
            {
                Session["flag"] = "yes";
                Session["userNamebar"] = userNamebar;
                Session["userPwd"] = userPwd;
                Session["id"] = sr["id"];
                
                Response.Redirect("default.aspx", false);

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(
                this.GetType(), "myscript",
                "<script type=\"text/javascript\">function ShowAlert(){alert('用户工号和密码不匹配');}window.onload=ShowAlert;</script>");
            }

        }
        else
        {
            ClientScript.RegisterStartupScript(
            this.GetType(), "myscript1",
            "<script type=\"text/javascript\">function ShowAlert(){alert('不存在该用户工号');}window.onload=ShowAlert;</script>");
        }
    }



}