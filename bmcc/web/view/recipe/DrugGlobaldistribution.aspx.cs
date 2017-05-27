using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data.SqlClient;

using System.Web.Services;
public partial class view_recipe_DrugGlobaldistribution : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        TeModel tm = new TeModel();
        SqlDataReader sdr = tm.findTisaneAll();



        if (sdr != null)
        {
            while (sdr.Read())
            {
                this.tisanenum.Items.Add(new ListItem(sdr["machinename"].ToString(), sdr["id"].ToString()));
            }
        }


        
        //teid.Text = "nihao";
        // testatus1.Text = "空闲";
        // teroomid.Text = "1号机房";
        // testatus2.Text ="良好";
        int a = Convert.ToInt32(tisanenum.Value);

        SqlDataReader sdr1 = tm.findTisaneAllbyId(a);

        if (sdr1.Read())
        {
            // teid.Text = sdr1["tisaneunitid"].ToString();


        }
        else
        {
            tehealthstatus.Text = "无";
            teroomid.Text = "无";
            texiaodustatus.Text = "无";
            status.Text = "无";
            usingstatus.Text = "无";
        }



        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum.Value = Request.QueryString["id"].ToString();
        }


        Bubbleinfo bi = new Bubbleinfo();
       string machineid = bi.distributionmachine();
       SqlDataReader sdr2 = tm.findmachinenamebyid(Convert.ToInt32(machineid));
       if (sdr2.Read())
       {
           recommend.Text = sdr2["machinename"].ToString();
       }
    }


    [WebMethod]
    public static string updateGlobalInfo(int id)
    {
        string result = "1";
        TeModel tm = new TeModel();
        int a = Convert.ToInt32(id);
        SqlDataReader sdr1 = tm.findTisaneAllbyId(a);


       // if (sdr1.Read())
       // {
            // teid.Text = sdr1["tisaneunitid"].ToString();


         //   testatus1.Text = sdr1["tisaneunitname"].ToString();
           /// teroomid.Text = sdr1["machineroomid"].ToString();
           // testatus2.Text = sdr1["healthstatus"].ToString();
       // }
       // else
        //{
        //    testatus1.Text = "无";
        //    teroomid.Text = "无";
       //     testatus2.Text = "无";
       // }
        if (sdr1.Read())
        {
            result = sdr1["disinfectionstatus"].ToString() + "," + sdr1["roomnum"] + "," + sdr1["healthstatus"]+","+sdr1["status"]+","+sdr1["usingstatus"];

        }


        return result;



    }

    [WebMethod]
    public static string addunit(int id, string tisaneid, string tisaneman,string ps)
    {
        string result = "";

        TeModel tm = new TeModel();
        int sdr = tm.addunit(id, tisaneid, tisaneman, ps);
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