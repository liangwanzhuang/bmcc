using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using ModelInfo;
using System.Data.SqlClient;

public partial class view_storeroom_updatedrugmatching : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {


            HospitalModel hm = new HospitalModel();
            SqlDataReader sdr = hm.findHospitalAll();
            int hid = 0;
            if (sdr != null)
            {
                while (sdr.Read())
                {
                    if (hid == 0)
                    {
                        hid = Convert.ToInt32(sdr["ID"].ToString());
                    }
                    this.hospitalname123.Items.Add(new ListItem(sdr["Hname"].ToString(), sdr["ID"].ToString()));

                }
            }
        }




        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum1.Value = Request.QueryString["id"].ToString();
            DrugAdminModel wr = new DrugAdminModel();
            DataTable dt = wr.findDrugmatchingInfo(id);


            DrugName12.Value = dt.Rows[0]["drugName"].ToString();
            DrugCode1.Value = dt.Rows[0]["drugNum"].ToString();
            ypcdrugname.Value = dt.Rows[0]["drugDetailedName"].ToString();
            ypcdrugcode.Value = dt.Rows[0]["drugAlias"].ToString();
         //   positionnum.Value = dt.Rows[0]["positionNum"].ToString();
            hospitalname123.Value = dt.Rows[0]["hospitalid"].ToString();
        }
    }


    [WebMethod]
    public static string updatematchingInfo(string hospitalname, string DrugName12, string DrugCode1, string ypcdrugname, string ypcdrugcode, string positionnum,string id)
    {
        string result = "";


        //string str2 = str1.TrimStart('0');
        DrugAdminModel wr = new DrugAdminModel();

        int sdr = wr.updatedrugmatchinginfo(hospitalname, DrugName12, DrugCode1, ypcdrugname, ypcdrugcode, positionnum,id);
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