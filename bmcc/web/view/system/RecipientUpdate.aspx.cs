using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;
using System.Data;

public partial class view_system_RecipientUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"]!= null){
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum1.Value = Request.QueryString["id"].ToString();
            RecipientModel rm = new RecipientModel();
            DataTable dt = rm.finRecipienallinfoByid(id);
            ClearPName1.Value = dt.Rows[0]["ClearPName"].ToString();
            Telephone.Value = dt.Rows[0]["Telephone"].ToString();
            Remarks.Value = dt.Rows[0]["Remarks"].ToString();
            Address.Value = dt.Rows[0]["Address"].ToString();
        }

    }
    [WebMethod]
    public static int RecipientUpdateInfo(int id,string ClearPName, string Telephone, string Address, string Remarks)
    {
        RecipientModel rm = new RecipientModel();
        int a = rm.UpdateRecipientInfo(id, ClearPName, Telephone, Address, Remarks);

        return a;
    
    }
}