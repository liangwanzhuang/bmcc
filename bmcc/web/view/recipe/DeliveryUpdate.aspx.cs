using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;
using System.Data;

public partial class view_recipe_DeliveryUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum.Value = Request.QueryString["id"].ToString();
            DeliveryModel rm = new DeliveryModel();
            DataTable dt = rm.findDeliveryInfo(id);

            DecNum.Value = dt.Rows[0]["DecoctingNum"].ToString();
            Sendper.Value = dt.Rows[0]["Sendpersonnel"].ToString();
            SendT.Value = dt.Rows[0]["SendTime"].ToString();
            SendS.Value = dt.Rows[0]["Sendstate"].ToString();
            StartT.Value = dt.Rows[0]["Starttime"].ToString();
            Rems.Value = dt.Rows[0]["Remarks"].ToString();

        }
    }

    [WebMethod]
    public static string updateDeliveryInfo(int DecoctingNum, string Sendpersonnel, string SendTime, string Sendstate, string Starttime, string Remarks)
    {
        DeliveryModel dm = new DeliveryModel();

        int result = dm.updateDelivery(DecoctingNum, Sendpersonnel, SendTime, Sendstate, Starttime, Remarks);

        string str = null;
        if (result == 0)
        {
            str = "0";
        }
        else
        {
            str = "1";
        }

        return str;

    }

}
