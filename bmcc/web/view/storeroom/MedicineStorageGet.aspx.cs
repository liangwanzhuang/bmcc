using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Web.Services;
using System.Data.SqlClient;

public partial class view_storeroom_MedicineStorageGet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            WarehousepharmacyModel whm = new WarehousepharmacyModel();
            SqlDataReader sdr = whm.findgrudnum();

            if (sdr != null)
            {
                while (sdr.Read())
                {

                    this.drugnum.Items.Add(new ListItem(sdr["ProductBatch"].ToString(), sdr["ProductBatch"].ToString()));

                }



            }






        }
    }
    [WebMethod]
    public static int addtempDrugInfo(string drugnum, string num, string quality, string productdate, string validdate, string permitno, string remark)
    {



        //string str2 = str1.TrimStart('0');
        WarehousepharmacyModel whm = new WarehousepharmacyModel();
        int result = whm.adddtemMedicinepruginfo(drugnum, num, quality, productdate, validdate, permitno, remark);

        /*  int sdr = wr.AddStorage(Warehouse, DrugType, DrugCode, PurUnits, DrugName, DrugSpecificat, PositionNum, Amount, Money, Univalent, Mnemonic, Rmarkes, ProDate, ExpiryDate, Quality, Producer, ProducingArea, LicenseNum, OSingle, OSTime, Warehousing, UpperLimit, LowerLimit, Rmarkes2, Rmarkes3);
          if (sdr == 0)
          {
              result = "0";
          }
          else
          {
              result = "1";
          }
         */




        return result;

    }

    [WebMethod]
    public static string getdruginfobydrugnum(string drugnum)
    {
        string result = "";


        //string str2 = str1.TrimStart('0');
        WarehousepharmacyModel whm = new WarehousepharmacyModel();
        SqlDataReader sdr = whm.findgrudinfobyproductbatch(drugnum);
        if (sdr.Read())
        {

            result = sdr["DrugType"].ToString() + "," + sdr["DrugCode"] + "," + sdr["PurUnits"] + "," + sdr["DrugName"] + "," + sdr["DrugSpecificat"]
               + "," + sdr["PositionNum"] + "," + sdr["Univalent"] + "," + sdr["Mnemonic"] + "," + sdr["Rmarkes"]
               + "," + sdr["Producer"] + "," + sdr["ProducingArea"] + "," + sdr["StorageTime"] + "," + sdr["LowerLimit"]
               + "," + sdr["UpperLimit"] + "," + sdr["Rmarkes2"] + "," + sdr["Rmarkes3"];

        }
        return result;

    }


    [WebMethod]
    public static string serchDrugInfo(string text)
    {
        StorageManageModel smm = new StorageManageModel();
        string sdr = smm.getdrugname(text);

        return sdr;

    }


    [WebMethod]
    public static string getproductbatch(string dataname)
    {

        StorageManageModel smm = new StorageManageModel();
        string sdr = smm.getproductbatchbydrugname(dataname);

        return sdr;
    }



}

