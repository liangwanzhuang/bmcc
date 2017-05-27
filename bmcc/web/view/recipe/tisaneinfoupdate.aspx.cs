using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services;
using ModelInfo;
using System.Data;
using System.Data.SqlClient;
public partial class view_recipe_tisaneinfoupdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


      
        this.tisanestatus.Items.Add(new ListItem("已完成", "1"));
        this.tisanestatus.Items.Add(new ListItem("待煎药", "2"));
        this.tisanestatus.Items.Add(new ListItem("正在煎药", "3"));

        TeModel tm = new TeModel();
        SqlDataReader sdr1 = tm.getTisaneMachinInfo();


        if (sdr1 != null)
        {
            while (sdr1.Read())
            {
                this.machinename.Items.Add(new ListItem(sdr1["machinename"].ToString(), sdr1["id"].ToString()));
            }
        }



        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum.Value = Request.QueryString["id"].ToString();


             SqlDataReader sr = tm.findTisaneinfoByid(id);
            if(sr.Read()){
             tisaneperson.Value = sr["tisaneman"].ToString();
             machinename.Value = sr["machineid"].ToString();
         
             tisanestatus.Value = sr["tisanestatus"].ToString();

            }
        }
      //  TeModel tm = new TeModel();
        //tm.findTisaneinfoByid();
       
        




    }



    [WebMethod]
    public static string tisaneinfoupdate(int id, string tisaneman, string machinename, string tisanestatus)
    {
        TeModel tm = new TeModel();
        int result = tm.updateTisaneinfo(id, tisaneman, Convert.ToInt32(machinename), Convert.ToInt32(tisanestatus));

        string end = "";
        if (result == 0)
        {
            end = "0";
        }
        else
        {
            end = "1";
        }

     return end;

    }
}