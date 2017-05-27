using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ModelInfo;
using System.Data.SqlClient;
using System.Web.Services;

public partial class view_recipe_DrugGlobalInfoUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            HospitalModel hm = new HospitalModel();
            SqlDataReader sdr = hm.findHospitalAll();

            if (sdr != null)
            {
                while (sdr.Read())
                {
                  //  this.hospitalSelect.Items.Add(new ListItem(sdr["Hname"].ToString(), sdr["ID"].ToString()));

                }

            }

        }


        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum.Value = Request.QueryString["id"].ToString();
            Bubbleinfo bl = new Bubbleinfo();
            DataTable dt = bl.getBubbleInfo(id);

            bubbleperson.Value = dt.Rows[0]["bp"].ToString();
        
           // hospitalname.Value = dt.Rows[0][""].ToString();
         
           // bubbleman.Value = dt.Rows[0]["bp"].ToString();
        }     

    }

    [WebMethod]
    public static string updateGlobalInfo(int id, string bubbleperson)
    {

        Bubbleinfo bi = new Bubbleinfo();
        int result = bi.updateBubbleInfo(id, bubbleperson);

        string str = null;
        if (result == 0)
        {
            str = "0";
        }else{
            str = "1";
        }

        return str;

    }



}