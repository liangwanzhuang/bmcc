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

public partial class view_storeroom_MedicineStorageUpdate : System.Web.UI.Page
{
        protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            WarehousepharmacyModel hm = new WarehousepharmacyModel();
            SqlDataReader sdr = hm.findWarehouseALLInfo();
            if (sdr != null)
            {
                while (sdr.Read())
                {
                    this.storageroom.Items.Add(new ListItem(sdr["WName"].ToString()));

                }
            }
        }
        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum1.Value = Request.QueryString["id"].ToString();
            StorageManageModel wr = new StorageManageModel();
            DataTable dt = wr.fmedicinequreydrugtoroomInfo(id);

            storageroom.Value = dt.Rows[0]["storageroom"].ToString();

            Amount1.Value = dt.Rows[0]["Amount"].ToString();
            
            Rmarkes1.Value = dt.Rows[0]["Rmarkes"].ToString();
            ProDate1.Value = dt.Rows[0]["ProDate"].ToString();
            ExpiryDate1.Value = dt.Rows[0]["ExpiryDate"].ToString();
            Quality1.Value = dt.Rows[0]["Quality"].ToString();
           
            LicenseNum1.Value = dt.Rows[0]["LicenseNum"].ToString();
            OSingle12.Value = dt.Rows[0]["OSingle"].ToString();
            OSTime1.Value = dt.Rows[0]["OSTime"].ToString();
            Warehousing12.Value = dt.Rows[0]["Warehousing"].ToString();
            

        }

    }
    [WebMethod]
        public static string StorageInfo(int id, string storageroom, string Amount, string Rmarkes, string ProDate, string ExpiryDate, string Quality, string LicenseNum, string OSingle, string OSTime, string Warehousing)
    {


        StorageManageModel wr = new StorageManageModel();
        int result = wr.medicineoutboundqueryInfo(id, storageroom, Amount, Rmarkes, ProDate, ExpiryDate, Quality, LicenseNum, OSingle, OSTime, Warehousing);

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