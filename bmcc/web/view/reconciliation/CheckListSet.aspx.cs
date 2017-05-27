using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;
using System.Data;
using System.Data.SqlClient;

public partial class view_reconciliation_CheckListSet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       if (Request.QueryString["id"] != null)
        {
            string id = Request.QueryString["id"];
            idnum.Value = Request.QueryString["id"];
            
            ClearingpartyHandler ch = new ClearingpartyHandler();
            DataTable dt = ch.findInfo(id);
            dPer.Value = dt.Rows[0]["ReconciliaPer"].ToString();
        }
        ClearingpartyHandler ch1 = new ClearingpartyHandler();
        SqlDataReader sdr = ch1.findInfo();
    
       /* if (sdr != null)
        {
            while (sdr.Read())
            {

                this.dPer.Items.Add(new ListItem(sdr["ReconciliaPer"].ToString()));

            }
        }*/
    }

    [WebMethod]
    public static string updateInfo(string id, string dPer)
    {
        ClearingpartyHandler dm = new ClearingpartyHandler();

        int result = dm.update(id, dPer);

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
