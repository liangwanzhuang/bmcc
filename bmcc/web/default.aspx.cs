using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    /// <summary>
    /// 当前用户ID
    /// </summary>
    public string currentUserID = "";

    /// <summary>
    /// 页面加载
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        ////防脚本SQL注入
        //AvertInjection.OnLoadCheck();
        //if (Session["currentUserID"] != null)
        //{
        //    currentUserID = Session["currentUserID"].ToString();
        //}
        //else
        //{
        //    Response.Redirect("noRight.aspx");
        //}
        string usernamebar = "";
       /* try
        {
            usernamebar = Session["userNamebar"].ToString();
        }
        catch (NullReferenceException ex)       //捕捉异常  
        {
            // Response.Write("<script language=javascript>window.location.href='../login.aspx' </script>");
            // Response.Redirect("web/login.aspx", true);
            Response.Redirect("login.aspx");
        }*/
        if (Session["userNamebar"] != null)
        {
        }
        else
        {
            Response.Redirect("login.aspx");
        }

        //{
        //    currentUserID = Session["currentUserID"].ToString();
        //}
        //else
        //{
        //    Response.Redirect("noRight.aspx");
        //}
    }
}