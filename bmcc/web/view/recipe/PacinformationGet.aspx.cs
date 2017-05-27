using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Web.Services;
using System.Data.SqlClient;
using SQLDAL;
public partial class view_recipe_PacinformationGet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PackingHandler phandler = new PackingHandler();
            SqlDataReader sdr = phandler.findNameAll();


            if (sdr != null)
            {
                while (sdr.Read())
                {
                    this.PackPer.Items.Add(new ListItem(sdr["EmNumAName"].ToString()));
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
                    PackPer.Value = sr["EmNumAName"].ToString();
                }
            }
            else
            {
                Response.Write("<script>alert('用户名已失效');window.parent.loginview();</script>");

            }

        }
    }
  
    
    [WebMethod]
    public static string addPackingGetinfo(string DecoctingBar, string PackPer)
    {
        string result = "";
          PackingHandler phandler = new PackingHandler();
          string DecoctingNum = DecoctingBar.Substring(4,10);
          int sdr = phandler.AddPacking(Convert.ToInt32(DecoctingNum), PackPer);
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


