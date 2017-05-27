using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using ModelInfo;
using SQLDAL;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;
public partial class view_logistics_kuaidi100 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        RecipeModel rm = new RecipeModel();
        DataTable dt = rm.findLogisticsKeyById(1);
        if (dt.Rows.Count > 0)
        {
            string key = dt.Rows[0]["logisticsKey"].ToString();
            string id = Request.QueryString["id"];
            string dtbtype = Request.QueryString["dtbtype"];
            string num = Request.QueryString["num"];
            if ("顺丰".Equals(dtbtype))
            {
                dtbtype = "shunfeng";
            }
            else if ("EMS".Equals(dtbtype))
            {
                dtbtype = "ems";
            }
            else if ("圆通".Equals(dtbtype))
            {
                dtbtype = "yuantong";
            }
            else if ("中通".Equals(dtbtype))
            {
                dtbtype = "zhongtong";
            }
            //471982204437
            string apiurl = "http://www.kuaidi100.com/applyurl?key=" + key + "&com=" + dtbtype + "&nu=" + num;
            //Response.Write (apiurl);
            WebRequest request = WebRequest.Create(@apiurl);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            Encoding encode = Encoding.UTF8;
            StreamReader reader = new StreamReader(stream, encode);
            string detail = reader.ReadToEnd();
            string kuaidi100 = "<iframe name=\"kuaidi100\" src=\"" + detail + "\" width=\"580\" height=\"470\" marginwidth=\"0\" marginheight=\"0\" hspace=\"0\" vspace=\"0\" frameborder=\"0\" scrolling=\"no\"></iframe>";
            this.kuaidi100Div.InnerHtml = kuaidi100;
        }
        else
        {
            this.kuaidi100Div.InnerHtml = "<span style=\"color:red;\">获取key失败</span>";
        }


        
    }
}