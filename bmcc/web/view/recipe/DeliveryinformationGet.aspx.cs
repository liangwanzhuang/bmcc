using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using SQLDAL;
public partial class view_recipe_DeliveryinformationGet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["id"] != null )
            {
                int id = Convert.ToInt16(Request.QueryString["id"]);
                idnum.Value = Request.QueryString["id"].ToString();
                DeliveryHandler dhandler = new DeliveryHandler();
                string dt = dhandler.finDecotingBarbyId(id);


                DecoctingBar.Value = dt;
                
           

            }
        if (!IsPostBack )
            {
                DeliveryHandler dhandler = new DeliveryHandler();
                SqlDataReader sdr = dhandler.findNameAll();


                if (sdr != null)
                {
                    while (sdr.Read())
                    {
                        this.Sendper.Items.Add(new ListItem(sdr["EmNumAName"].ToString()));
                        // this.SwapPer.Items.Add(new ListItem(sdr["JobNum"].ToString()));

                    }
                }
                DataBaseLayer db = new DataBaseLayer();
                if (Session["userNamebar"] != null)
                {
                    string name = Session["userNamebar"].ToString();

                    string sq1 = "select EmNumAName from Employee where jobnum ='" + name + "' ";
                    SqlDataReader sr = db.get_Reader(sq1);
                    if (sr.Read())
                    {
                        Sendper.Value = sr["EmNumAName"].ToString();
                    }
                }
                else
                {
                    Response.Write("<script>alert('用户名已失效');window.parent.loginview();</script>");
                }
            }
        

    }

   
    [WebMethod]
    public static string addDeliveryinfo(string id, string DecoctingBar, string Sendpersonnel,  string Remarks,string dtbtype,string logisticsnum)
    {
        string result = "";
        
        System.DateTime now = new System.DateTime();
        now = System.DateTime.Now;
        string SendTime = now.ToString();
        DeliveryHandler dhandler = new DeliveryHandler();
        string DeNum = DecoctingBar.Substring(4,10);
        int sdr = dhandler.AddDelivery(id, Convert.ToInt32(DeNum), Sendpersonnel, SendTime, Remarks,dtbtype,logisticsnum);
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


