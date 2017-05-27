using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;



using ModelInfo;
using System.Web.Services;
using System.Data.SqlClient;


public partial class view_storeroom_MedicineLossiInforGet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            WarehousepharmacyModel hm = new WarehousepharmacyModel();
            SqlDataReader sdr = hm.findpartWarehouse();
            if (sdr != null)
            {
                while (sdr.Read())
                {
                    this.fromid.Items.Add(new ListItem(sdr["WName"].ToString()));

                }
            }

        }
         
            /* if (Request.QueryString["id"] != null)
             {
                 int id = Convert.ToInt16(Request.QueryString["id"]);
                 idnum1.Value = Request.QueryString["id"].ToString();
                 StorageManageModel wr = new StorageManageModel();
                 DataTable dt = wr.findStorageListInfo(id);

                 Warehouse1.Value = dt.Rows[0]["Warehouse"].ToString();

                 WarehouseNum.Value = dt.Rows[0]["WarehouseNum"].ToString();

                 Type1.Value = dt.Rows[0]["Type"].ToString();
                 DrugCode.Value = dt.Rows[0]["DrugCode"].ToString();
                 Rmarkes.Value = dt.Rows[0]["remark"].ToString();
                 Per.Value = dt.Rows[0]["Per"].ToString();
                 DeugName.Value = dt.Rows[0]["DrugName"].ToString();
                 Reason.Value = dt.Rows[0]["Reason"].ToString();
                


             }*/

       
    }
    [WebMethod]
    public static string MedicineLossiInforGet(string fromid, string drugnum, string losstype, string Per, string Reason, string Rmarkes, string lossnum)
    {


        LossiModel wr = new LossiModel();
        int result = wr.GetMedicineLossiInfo(fromid, drugnum, losstype, Per, Reason, Rmarkes, lossnum);

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
