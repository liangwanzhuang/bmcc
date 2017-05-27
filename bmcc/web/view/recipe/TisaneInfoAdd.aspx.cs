using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;
using System.Data.SqlClient;
using SQLDAL;
public partial class view_recipe_TisaneInfoAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum.Value = Request.QueryString["id"].ToString();
        }

        if (!IsPostBack)
        {
            TeModel tm = new TeModel();
            SqlDataReader sdr = tm.findNameAll();


            if (sdr != null)
            {
                while (sdr.Read())
                {
                    this.tisaneperson.Items.Add(new ListItem(sdr["EmNumAName"].ToString()));
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
                    tisaneperson.Value = sr["EmNumAName"].ToString();
                }
            }
            else
            {
                Response.Write("<script>alert('用户名已失效');window.parent.loginview();</script>");

            }



        }
    }


    [WebMethod]
    public static int addtisaneinfo(string tisanebarcode, string tisaneperson, string mark)
    {


       // Bubbleinfo bi = new Bubbleinfo();
        TeModel tm = new TeModel();
        //int sdr = bi.addbubble(tisanebarcode);
        int sdr = tm.addtisaneinfo(tisanebarcode, tisaneperson, mark);

        return sdr;

    }





}