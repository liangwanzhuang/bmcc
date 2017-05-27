using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;

public partial class view_recipe_ReviewqueryUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HospitalModel hm = new HospitalModel();
            SqlDataReader sdr = hm.findHospitalAll();
            if (sdr != null)
            {
                while (sdr.Read())
                {
                    this.hospitalSelect.Items.Add(new ListItem(sdr["Hname"].ToString(), sdr["ID"].ToString()));
                }
            }
        }
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt16(Request.QueryString["id"]);
                idnum.Value = Request.QueryString["id"].ToString();
                ReviewAddInfo rm = new ReviewAddInfo();
                DataTable dt = rm.getAuditInfo(id);
                AuditTime.Value = dt.Rows[0]["AuT"].ToString();
                hospitalSelect.Value = dt.Rows[0]["hospitalid"].ToString();
                pspnum.Value = dt.Rows[0]["pspnum"].ToString();
               
            }
        }


    [WebMethod]
    public static string updateRecipeInfo(int id, string AuditTime, string hospitalSelect, string pspnum)
    {

        ReviewAddInfo binfo = new ReviewAddInfo();
        int result = binfo.updateAuditInfo(id, AuditTime, Convert.ToInt32(hospitalSelect), pspnum);

        string str = null;
        if (result == 0)
        {
            str = "0";
        }else{
            str = "1";
        }

        return str;

    }
}