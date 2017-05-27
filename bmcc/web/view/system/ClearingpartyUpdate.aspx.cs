using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;

public partial class view_system_ClearingpartyUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum1.Value = Request.QueryString["id"].ToString();
            ClearingpartyModel rm = new ClearingpartyModel();
            DataTable dt = rm.findClearingpartyInfo(id);

            ClearPName11.Value = dt.Rows[0]["ClearPName"].ToString();
            ConPerson11.Value = dt.Rows[0]["ConPerson"].ToString();
            ConPhone11.Value = dt.Rows[0]["ConPhone"].ToString();
            //PerSetInformation11.Value = dt.Rows[0]["PerSetInformation"].ToString();
            Address11.Value = dt.Rows[0]["Address"].ToString();
            Remarks11.Value = dt.Rows[0]["Remarks"].ToString();
            GenDecoct11.Value = dt.Rows[0]["GenDecoct"].ToString();
           
        }
    }

    [WebMethod]
    public static string Clearingpartyinfo(int id, string ClearPName, string ConPerson, string ConPhone, string Address, string Remarks, string GenDecoct)
    {



        ClearingpartyModel winfo = new ClearingpartyModel();
        int result = winfo.updateClearingpartyInfo(id, ClearPName, ConPerson, ConPhone, Address,  Remarks, GenDecoct);

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