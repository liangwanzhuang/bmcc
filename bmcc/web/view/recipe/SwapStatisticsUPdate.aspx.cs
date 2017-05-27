using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using ModelInfo;
public partial class view_recipe_SwapStatisticsUPdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt16(Request.QueryString["id"]);
                idnum.Value = Request.QueryString["id"].ToString();
                AdjustModel am = new AdjustModel();
                DataTable dt = am.findAdjustById(id);

                Date.Value = Convert.ToDateTime(dt.Rows[0]["wordDate"].ToString()).ToString("yyyy-MM-dd");

                WorkContent.Value = dt.Rows[0]["wordcontent"].ToString();
                Workload.Value = dt.Rows[0]["workload"].ToString(); 
               
            }
   }

    
    
    [WebMethod]
    public static int updateAdjust(int id, string wordcontent, string wordDate, string workload)
    {


        AdjustModel am = new AdjustModel();

        return am.updateAdjust(id, wordcontent, wordDate, workload);

    }
}