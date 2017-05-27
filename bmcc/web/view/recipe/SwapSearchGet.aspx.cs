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
using SQLDAL;
public partial class view_recipe_SwapSearchGet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       

        
        if (!IsPostBack)
        {
            AdjustModel am = new AdjustModel();
            SqlDataReader sdr = am.findNameAll();

           
            if (sdr != null)
            {
                while (sdr.Read())
                {
                    this.SwapPer.Items.Add(new ListItem(sdr["EmNumAName"].ToString()));
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
                    SwapPer.Value = sr["EmNumAName"].ToString();
                }
            }
            else
            {
                Response.Write("<script>alert('用户名已失效');window.parent.loginview();</script>");
            }
           
          
        }


    }
    [WebMethod]
    public static int addAdjust( string barcode, string SwapPer)
    {

       // string result = "";
        AdjustModel am = new AdjustModel();


        return am.addAdjust( barcode,SwapPer);
        /*if (sdr == 0)
        {
            result = "0";
        }
        else
        {
            result = "1";
        }

        return result;*/

        // if (dt.Rows.Count > 0)
        // {
        // return am.updateAdjust(Convert.ToInt32(dt.Rows[0]["id"].ToString()), 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        // }
        // else
        // {
        // return  am.addAdjust(userid, barcode1, wordcontent);
        //}
         
    }
    [WebMethod]
    public static string getNumByNAMEId(string SwapPer)
    {
        AdjustModel am = new AdjustModel();
        DataTable dt = am.findNumById(SwapPer);


        string data = "";
        data = dt.Rows[0][0].ToString();

        //string a = data;
        return data; ;


    }


    }
