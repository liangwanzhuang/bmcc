using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;


public partial class view_recipe_PackingUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum.Value = Request.QueryString["id"].ToString();
            PackingHandler rm = new PackingHandler();
            DataTable dt = rm.getpackingInfo(id);

            DecNum.Value = dt.Rows[0]["DecoctingNum"].ToString();
            Pacper.Value = dt.Rows[0]["Pacpersonnel"].ToString();
            PacTi.Value = dt.Rows[0]["PacTime"].ToString();
            Ftate.Value = dt.Rows[0]["Fpactate"].ToString();
            Sttime.Value = dt.Rows[0]["Starttime"].ToString();
            Tset.Value = dt.Rows[0]["Timeset"].ToString();

        }
    }


    

    [WebMethod]
    public static string updatepackingInfo(int DecoctingNum, string Pacpersonnel, string PacTime, string Fpactate, string Starttime, string Timeset)
    {

        PackingHandler ph = new PackingHandler();
        int result = ph.updatePackingInfo(DecoctingNum, Pacpersonnel, PacTime, Fpactate, Starttime, Timeset);

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



