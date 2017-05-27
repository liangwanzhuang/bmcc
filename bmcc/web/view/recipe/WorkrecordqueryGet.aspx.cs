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

public partial class view_recipe_WorkrecordqueryGet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }



  
    [WebMethod]
    public static string addWorkrecordqueryinfo(string DecoctingNum)
    {
        string result = "";
      

        //string str2 = str1.TrimStart('0');
        WorkrecordQuInfo wr = new WorkrecordQuInfo();
        string str1 = DecoctingNum.Substring(4,10);
        int sdr = wr.AddWorkrecordQuInfo(Convert.ToInt64(str1));
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
