using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;

public partial class view_system_AuthorityGet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
     protected void btnAddClick(object sender, EventArgs e)
    {
         string strTip = "";

         if (Personnel.Value == "")
       {
           strTip += "人员；";
       }
       
        
      
        if (strTip != "")
        {
            //content.InnerHtml 
            strTip = "以下信息不能空，请填写: " + strTip;

            //ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>window.onload=function(){ok_onclick();}</script>");         
            
            //return;

            Page.ClientScript.RegisterStartupScript(
            this.GetType(), "myscript",
            "<script type=\"text/javascript\">function ShowAlert(){alert('" + strTip + "');}window.onload=ShowAlert;</script>");
            return;
        }

         /* AuthorityInfo ainfo = new AuthorityInfo();
        ainfo.strPersonnel = Personnel.Value;
        ainfo.strJurisdiction = Jurisdiction.Value;
       
        

        AuthorityHandler ahandler = new AuthorityHandler();
        bool rn = ahandler.AddPersonnelinfo(ainfo);

        if (rn)
        {
            Page.ClientScript.RegisterStartupScript(
             this.GetType(), "myscript",
             "<script type=\"text/javascript\">function ShowAlert(){alert('权限设置成功');}window.onload=ShowAlert;</script>");

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(
            this.GetType(), "myscript",
            "<script type=\"text/javascript\">function ShowAlert(){alert('权限设置失败');}window.onload=ShowAlert;</script>");

        }
        */
    }}

