using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data;
using System.Web.Services;

public partial class view_system_HospitalUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        
        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum1.Value = Request.QueryString["id"].ToString();
            HospitalHandler rm = new HospitalHandler();
            DataTable dt = rm.findHospitalInfo(id);

            hnum11.Value = dt.Rows[0]["hnum"].ToString();
            hname11.Value = dt.Rows[0]["hname"].ToString();
            hshortname11.Value = dt.Rows[0]["hshortname"].ToString();
            contacter11.Value = dt.Rows[0]["contacter"].ToString();
            phone11.Value = dt.Rows[0]["phone"].ToString();
            address11.Value = dt.Rows[0]["address"].ToString();
            pricetype11.Value = dt.Rows[0]["pricetype"].ToString();
            //settler11.Value = dt.Rows[0]["settler"].ToString();
           // HPerSetInfor11.Value = dt.Rows[0]["HPerSetInfor"].ToString();
        }

    }
    [WebMethod]
    public static string HospitalInfo(int id, string hname, string hshortname, string hnum, string contacter, string phone, string address, string pricetype)
    {



        HospitalHandler winfo = new HospitalHandler();
        int result = winfo.updateHospitalInfo(id, hname, hshortname, hnum, contacter, phone, address, pricetype);

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