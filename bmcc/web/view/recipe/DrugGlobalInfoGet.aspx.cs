using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ModelInfo;
using System.Data.SqlClient;
using SQLDAL;
using System.Web.Services;
public partial class view_recipe_DrugGlobalInfoGet : System.Web.UI.Page
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
            Bubbleinfo bi = new Bubbleinfo();
            SqlDataReader sdr = bi.findNameAll();


            if (sdr != null)
            {
                while (sdr.Read())
                {
                    this.bubbleperson.Items.Add(new ListItem(sdr["EmNumAName"].ToString()));
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
                    bubbleperson.Value = sr["EmNumAName"].ToString();
                }
            }
            else
            {
                Response.Write("<script>alert('用户名已失效');window.parent.loginview();</script>");

            }
        }
    }
    /*   Bubbleinfo bi = new Bubbleinfo();
       int count = bi.addbubble(bubbleperson.Value,Convert.ToInt32(idnum.Value));
       if (count != 0)
       {
           // Response.Write("<script>alert('添加成功');window.location.href=''</script>");


           Page.ClientScript.RegisterStartupScript(
         this.GetType(), "myscript2",
         "<script type=\"text/javascript\">function ShowAlert(){alert('添加成功');}window.onload=ShowAlert;</script>");
           return;

       }
       else
       {
           Page.ClientScript.RegisterStartupScript(
         this.GetType(), "myscript2",
         "<script type=\"text/javascript\">function ShowAlert(){alert('添加失败，可能是由于不存在这处方号，或者该处方号分配到给别人了');}window.onload=ShowAlert;</script>");
       }
   }   */


    [WebMethod]
    public static int addbubbleinfo(string tisanebarcode, string bubbleperson, string mark,string wateryield)
    {
       

        Bubbleinfo bi = new Bubbleinfo();
        int sdr = bi.addbubble(tisanebarcode, bubbleperson, mark,wateryield);
       

        return sdr;

    }



}