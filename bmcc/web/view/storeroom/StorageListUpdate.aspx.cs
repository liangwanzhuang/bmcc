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

public partial class view_storeroom_StorageListUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum1.Value = Request.QueryString["id"].ToString();
            StorageManageModel wr = new StorageManageModel();
            DataTable dt = wr.ftempdrugtoroomInfo(id);

            Amount1.Value = dt.Rows[0]["num"].ToString();
            Rmarkes1.Value = dt.Rows[0]["remark"].ToString();
            ProDate1.Value = dt.Rows[0]["productdate"].ToString();
            ExpiryDate1.Value = dt.Rows[0]["validedate"].ToString();
            Quality1.Value = dt.Rows[0]["quality"].ToString();
            LicenseNum1.Value = dt.Rows[0]["permitNo"].ToString();
           
        }

    }
    [WebMethod]
    public static string StorageListInfo(int id,   string Amount,  string Rmarkes,string ProDate,string  ExpiryDate, string Quality,  string LicenseNum  )
    {



        StorageManageModel wr = new StorageManageModel();
        int result = wr.StorageDrugInfo(id, Amount, Rmarkes, ProDate, ExpiryDate, Quality, LicenseNum);

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