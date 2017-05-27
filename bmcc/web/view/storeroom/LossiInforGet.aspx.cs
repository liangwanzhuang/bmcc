using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;
using System.Data.SqlClient;

public partial class view_storeroom_LossiInforGet : System.Web.UI.Page
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
                    this.fromid.Items.Add(new ListItem(sdr["WName"].ToString()));

                }
            }
          
        }
    }
    [WebMethod]
    public static string addLossiInfor(string fromid, string drugnum, string losstype, string Per, string Reason, string Rmarkes, string lossnum)
    {
        string result = "";

        LossiModel hm1 = new LossiModel();

        int sdr = hm1.LossiInforAdd(fromid, drugnum, losstype, Per, Reason, Rmarkes, lossnum);
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
    [WebMethod]
    public static string getNumByWarehouse(string Warehouse)
    {
        string result = "";

        LossiModel whm = new LossiModel();
        SqlDataReader sdr = whm.findWarehouseNum(Warehouse);
        //SqlDataReader sdr1 = whm.findDeugName(Warehouse);
        if (sdr.Read())
        {

            result = sdr["WareNum"].ToString();

        }


        return result;

    }
    [WebMethod]
    public static string getNumByDeugName(string DeugName)
    {
        string result = "";

        LossiModel whm = new LossiModel();
        SqlDataReader sdr = whm.findDeugNameNum(DeugName);

        if (sdr.Read())
        {

            result = sdr["DrugCode"].ToString();

        }
        


        return result;

    }

}
