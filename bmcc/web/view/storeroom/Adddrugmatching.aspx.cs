using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;



using System.Data.SqlClient;
using System.Web.Services;
using System.Data;
using System.IO;

using System.Data.OleDb;
using System.Web.Security;


public partial class view_storeroom_Adddrugmatching : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            HospitalModel hm = new HospitalModel();
            SqlDataReader sdr = hm.findHospitalAll();
            int hid = 0;
            int count = 0;
            if (sdr != null)
            {
                while (sdr.Read())
                {
                    if (hid == 0)
                    {
                        hid = Convert.ToInt32(sdr["ID"].ToString());
                    }
                    if (count == 0)
                    {
                        string Hnum = sdr["Hnum"].ToString();
                        hospitalnum.Value = Hnum;

                    }
                    count++;
                    this.hospitalname12.Items.Add(new ListItem(sdr["Hname"].ToString(), sdr["ID"].ToString()));

                }
            }

        }
    }




    [WebMethod]
    public static string addmatchingInfo(string hospitalname, string DrugName12, string DrugCode1, string ypcdrugname, string ypcdrugcode)
    {
        string result = "";


        //string str2 = str1.TrimStart('0');
        DrugAdminModel wr = new DrugAdminModel();

        int sdr = wr.Adddrugmatchinginfo(hospitalname, DrugName12, DrugCode1, ypcdrugname, ypcdrugcode);
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
    public static string getdruginfobydrugnum(string drugnum)
    {
        string result = "";






        //string str2 = str1.TrimStart('0');
        WarehousepharmacyModel whm = new WarehousepharmacyModel();
        SqlDataReader sdr = whm.findgrudinfobydrugnumthrid(drugnum);



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
    public static string getNumByHospitalId(int hospitalId)
    {
        HospitalModel hm = new HospitalModel();
        DataTable dt = hm.findNumById(hospitalId);

        string data = "";
        data = dt.Rows[0][0].ToString();
        EntrustNumberModel enm = new EntrustNumberModel();


        return data + ";" + enm.getEntrustNumber(hospitalId);


    }
}