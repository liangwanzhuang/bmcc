using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;
using System.Data;

public partial class view_system_MeRoomUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum.Value = Request.QueryString["id"].ToString();
            meRoomModel rm = new meRoomModel();
            DataTable dt = rm.findmachineroombyid1(id);

            meRoomName.Value = dt.Rows[0]["meRoomName"].ToString();
            meRoomNum.Value = dt.Rows[0]["meRoomNum"].ToString();
            Remarks.Value = dt.Rows[0]["Remarks"].ToString();
           
        }
    }

    [WebMethod]
    public static string updateDeliveryInfo(int id, string meRoomName, string meRoomNum, string Remarks)
    {
        meRoomModel dm = new meRoomModel();

        int result = dm.updatemeRoom(id, meRoomName, meRoomNum,Remarks);

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
