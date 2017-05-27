using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using ModelInfo;
using System.Web.Services;
using System.Data.SqlClient;

public partial class view_storeroom_medicalOutbounddata : System.Web.UI.Page
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
                    this.fromid.Items.Add(new ListItem(sdr["WName"].ToString(), sdr["WName"].ToString()));

                }
            }
        }

    }
    [WebMethod]
    public static int addtempDrugInfo(string drugnum, string num, string quality, string productdate, string validdate, string permitno, string remark,string fromid)
    {



        //string str2 = str1.TrimStart('0');
        WarehousepharmacyModel whm = new WarehousepharmacyModel();
        int result = whm.adddtemMedicinepruginfochange(drugnum, num, quality, productdate, validdate, permitno, remark, fromid);

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
    public static string getdruginfobydrugnum(string drugnum,string fromid)
    {
        string result = "";


        //string str2 = str1.TrimStart('0');
        WarehousepharmacyModel whm = new WarehousepharmacyModel();
        SqlDataReader sdr = whm.findgrudinfobydrugnumsecond(drugnum);
        SqlDataReader sdr2 = whm.findgrudinfobydrugnumfromstoragedrug(drugnum);


        StorageManageModel smm = new StorageManageModel();

        int remainingnum = smm.remainingnummedical(fromid, drugnum);


        if (sdr.Read())
        {
            if (sdr2.Read())
            {
                result = sdr["DrugType"].ToString() + "," + sdr["DrugCode"] + "," + sdr["PurUnits"] + "," + sdr["DrugName"] + "," + sdr["DrugSpecificat"]
                   + "," + sdr["PositionNum"] + "," + sdr["Univalent"] + "," + sdr["Mnemonic"] + "," + sdr["Rmarkes"]
                   + "," + sdr["Producer"] + "," + sdr["ProducingArea"] + "," + sdr["StorageTime"] + "," + sdr["LowerLimit"]
                   + "," + sdr["UpperLimit"] + "," + sdr["Rmarkes2"] + "," + sdr["Rmarkes3"] + "," + remainingnum + "," + sdr2["ProDate"] + "," + sdr2["ExpiryDate"] + "," + sdr2["Quality"] + "," + sdr2["LicenseNum"] + "," + sdr2["Rmarkes"];
            }
        }


        return result;

    }
    [WebMethod]
    public static string getproductbatchbyid(string fromid)
    {
        /* int result = 0;
         string[] strRowsId = strRowIds.Split(',');

         for (int i = 0; i < strRowsId.Length; i++)
         {

             StorageManageModel smm = new StorageManageModel();
             result = smm.AddStorage(strRowsId[i].ToString(), Warehouse1, intoman, OSingle1, OSTime1);

         }
         */

        StorageManageModel smm = new StorageManageModel();
        string sr = smm.findproductbatchbyfromiddrug(fromid);




        return sr;

    }



    [WebMethod]
    public static string serchDrugInfo(string text, string fromid)
    {
        StorageManageModel smm = new StorageManageModel();
        string sdr = smm.getdrugnamemedical(text, fromid);

        return sdr;

    }

    [WebMethod]
    public static string getproductbatch(string dataname,string fromid)
    {

        StorageManageModel smm = new StorageManageModel();
        string sdr = smm.getproductbatchbydrugnamemedical(dataname,fromid);

        return sdr;
    }



    [WebMethod]
    public static int ischeckoutnum(string num, string fromid, string drugnum)
    {

        StorageManageModel smm = new StorageManageModel();
        int result = smm.ischeckoutnummedical(num, fromid, drugnum);



        return result;
    }

}

