using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_recipe_SwapStatisticsGet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnDrugGlobalInfoGetClick(object sender, EventArgs e)
    {
        string strTip = "";

        if (Date.Value == "")
        {
            strTip += "日期；";
        }
        if (WorkContent.Value == "")
        {
            strTip += "工作内容；";
        }
        if (Workload.Value == "")
        {
            strTip += "工作量；";
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

        /* SwapSearchInfo sinfo = new SwapSearchInfo();
         sinfo.strDate = Date.Value;
         sinfo.strWorkContent = WorkContent.Value;
         sinfo.strWorkload = Workload.Value;
        SwapSearchHandler shandler = new SwapSearchHandler();

         bool rn = shandler.AddDelivery(sinfo);
         if (rn)
         {
             Page.ClientScript.RegisterStartupScript(
              this.GetType(), "myscript",
              "<script type=\"text/javascript\">function ShowAlert(){alert('发货信息添加成功');}window.onload=ShowAlert;</script>");

         }
         else
         {
             Page.ClientScript.RegisterStartupScript(
             this.GetType(), "myscript",
             "<script type=\"text/javascript\">function ShowAlert(){alert('发货信息添加失败');}window.onload=ShowAlert;</script>");

         }*/

    }   
}

