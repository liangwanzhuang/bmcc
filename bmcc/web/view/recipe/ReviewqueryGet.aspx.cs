using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;
using SQLDAL;
public partial class view_recipe_ReviewqueryGet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReviewAddInfo rinfo = new ReviewAddInfo();
            SqlDataReader sdr = rinfo.findNameAll();


            if (sdr != null)
            {
                while (sdr.Read())
                {
                    this.ReviewPer.Items.Add(new ListItem(sdr["EmNumAName"].ToString()));
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
                    ReviewPer.Value = sr["EmNumAName"].ToString();
                }
            }
            else
            {

                Response.Write("<script>alert('用户名已失效');window.parent.loginview();</script>");

            }
           
        }
    }

    [WebMethod]
    public static string addReviewinfo(String DecoctingNum, string ReviewPer)
    {
        string result = "";

        ReviewAddInfo rinfo = new ReviewAddInfo();

        string str1 = DecoctingNum.Substring(4,10);

        string str2 = str1.TrimStart('0');
        int sdr = rinfo.AddAudit(Convert.ToInt32(str2), ReviewPer);
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