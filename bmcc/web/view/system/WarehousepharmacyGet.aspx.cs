using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;

public partial class view_system_WarehousepharmacyGet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static string addWarehousepharmacyGetinfo(string WName, string WareNum, string Type)
    {
        string result = "";


        //string str2 = str1.TrimStart('0');
        WarehousepharmacyModel wr = new WarehousepharmacyModel();

        int sdr = wr.AddWarehousepharmacy(WName, WareNum, Type);
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
