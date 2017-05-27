﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;
using System.Data;
using System.Data.SqlClient;

public partial class view_storeroom_WarehouseInvenUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            WarehousepharmacyModel hm = new WarehousepharmacyModel();
            SqlDataReader sdr = hm.findWarehouseInfo();
            if (sdr != null)
            {
                while (sdr.Read())
                {
                    this.Warehouse1.Items.Add(new ListItem(sdr["WName"].ToString()));

                }
            }

        }

        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum1.Value = Request.QueryString["id"].ToString();
            WarehouseInvenModel rm = new WarehouseInvenModel();
            DataTable dt = rm.findWarehouseInvenInfo(id);

            Warehouse1.Value = dt.Rows[0]["Warehouse"].ToString();
            InventoryPer.Value = dt.Rows[0]["InventoryPer"].ToString();
            ActualCapacity.Value = dt.Rows[0]["ActualCapacity"].ToString();
            InventoryStatus.Value = dt.Rows[0]["InventoryStatus"].ToString();
            StorageCondition.Value = dt.Rows[0]["StorageCondition"].ToString();
            Rmarkes.Value = dt.Rows[0]["remark"].ToString();


        }
    }
    [WebMethod]
    public static string WarehouseInvenUpdateInfo(int id, string Warehouse, string InventoryPer, string ActualCapacity, string InventoryStatus, string StorageCondition, string remark)
    {
        WarehouseInvenModel winfo = new WarehouseInvenModel();
        int result = winfo.updateWarehouseInvenInfo(id, Warehouse, InventoryPer, ActualCapacity, InventoryStatus, StorageCondition, remark);

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