using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data.SqlClient;
using System.Web.Services;

public partial class view_system_upload_ClearingpartyGet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

    }

    [WebMethod]
    public static string addClearingpartyinfo(string ClearPName, string ConPerson, string ConPhone, string Address, string Remarks, string GenDecoct)
    {
        string result = "";


        //string str2 = str1.TrimStart('0');
        ClearingpartyHandler wr = new ClearingpartyHandler();

        int sdr = wr.AddClearingparty(ClearPName, ConPerson, Address, ConPhone, Remarks, GenDecoct);
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
