using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class quit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            this.Session["currentUserID"] = null;
            this.Session["currentUserPageSize"] = null;
            this.Session["currentRoleID"] = null;
            this.Session["currentUserName"] = null;
            this.Session["currentUserRealName"] = null;
            this.Session["currentOfficeGuid"] = null;
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("login.aspx");

        }
        catch (Exception)
        {
            Response.Redirect("login.aspx");
        }
    }
}