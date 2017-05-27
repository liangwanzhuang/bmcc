using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;

public partial class view_system_HospitalGet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static string addHospitalinfo(string hname, string hshortname, string hnum, string contacter, string phone, string address, string pricetype)
    {  string result = "";


        //string str2 = str1.TrimStart('0');
        HospitalHandler wr = new HospitalHandler();

        int sdr = wr.AddHospital(hname, hshortname, hnum, contacter, phone, address, pricetype);
        if (sdr == 0)
        {
            result = "0";
        }
        else
        {
            result = "1";
        }

        return result;

    }

}
