using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;
using System.Data;

public partial class view_system_WarehousepharmacyUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum1.Value = Request.QueryString["id"].ToString();
            WarehousepharmacyModel rm = new WarehousepharmacyModel();
            DataTable dt = rm.findWarehousepharmacy(id);

            WName1.Value = dt.Rows[0]["WName"].ToString();
            WareNum1.Value = dt.Rows[0]["WareNum"].ToString();
            Type1.Value = dt.Rows[0]["Type"].ToString();
           
        }

    }
    [WebMethod]
    public static string WarehousepharmacyInfo(int id, string WName, string WareNum, string Type) 
    {
        WarehousepharmacyModel winfo = new WarehousepharmacyModel();
        int result = winfo.UpdateWarehousepharmacyInfo(id, WName, WareNum, Type);

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
