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

public partial class view_storeroom_StorageListUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum1.Value = Request.QueryString["id"].ToString();
            StorageManageModel wr = new StorageManageModel();
            DataTable dt = wr.LossiInforInfo(id);

            Type1.Value = dt.Rows[0]["Type"].ToString();
            Per1.Value = dt.Rows[0]["Per"].ToString();
            Reason1.Value = dt.Rows[0]["Reason"].ToString();
            lossnum1.Value = dt.Rows[0]["lossnum"].ToString();
            Rmarkes1.Value = dt.Rows[0]["remark"].ToString();
            
           
        }

    }
    [WebMethod]
    public static string lossiInforInfo(int id,   string Type,  string Per,string Reason,string  lossnum, string Rmarkes )
    {



        StorageManageModel wr = new StorageManageModel();
        int result = wr.LossiInforInfo(id, Type, Per, Reason, lossnum, Rmarkes);

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