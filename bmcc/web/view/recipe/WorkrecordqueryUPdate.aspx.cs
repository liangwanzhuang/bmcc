using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data.SqlClient;
using System.Web.Services;
using System.Data;

public partial class view_recipe_WorkrecordqueryUPdate : System.Web.UI.Page
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
            WorkrecordQuInfo wm = new WorkrecordQuInfo();
            DataTable dt = wm.getWorkrecordqueryInfo(id);
            hospitalSelect.Value = dt.Rows[0]["hospitalid"].ToString();
            pspnum.Value = dt.Rows[0]["pspnum"].ToString();

        }
    }
    [WebMethod]
    public static string updateWorkrecordqueryInfo(int id, string hospitalSelect, string pspnum)
    {
        WorkrecordQuInfo winfo = new WorkrecordQuInfo();
        int result = winfo.updateWorkrecordqueryInfo( id, Convert.ToInt32(hospitalSelect), pspnum);

        string str = null;
        if (result == 0)
        {
            str = "0";
        }
        else
        {
            str = "1";
        }

        return str;
    }
}