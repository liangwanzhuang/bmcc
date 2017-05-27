using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;

public partial class view_system_MeRoomAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static string addMeRoom(string meRoomName, string meRoomNum, string Remarks)
    {
        string result = "";

        meRoomModel rm = new meRoomModel();

        int sdr = rm.AddmeRoom(meRoomNum, meRoomName,Remarks);
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