using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;
using System.Data.SqlClient;

public partial class view_storeroom_WarehouseInvenGet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            WarehousepharmacyModel hm = new WarehousepharmacyModel();
            SqlDataReader sdr = hm.findpart2Warehouse();
            if (sdr != null)
            {
                while (sdr.Read())
                {
                    this.fromid.Items.Add(new ListItem(sdr["WName"].ToString(), sdr["WName"].ToString()));

                }
            }

        }
    }
    [WebMethod]
    public static string addWarehouseInvenInfo(string fromid, string drugnum, string InventoryPer, string ActualCapacity, string InventoryStatus, string StorageCondition, string Rmarkes)
    {
        string result = "";

        WarehouseInvenModel wr = new WarehouseInvenModel();

        int sdr = wr.AddWarehouseInven(fromid,drugnum, InventoryPer, ActualCapacity, InventoryStatus, StorageCondition, Rmarkes);
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
