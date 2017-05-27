using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;

public partial class view_system_RecipientGet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { 
    }
   [WebMethod]
    public static string addRecipientinfo(string ClearPName,string Telephone,string Address,string Remarks)
    {
        string result = "";


        //string str2 = str1.TrimStart('0');
        RecipientModel wr = new RecipientModel();

        int sdr = wr.AddRecipient(ClearPName, Telephone, Address, Remarks);
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