using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using SQLDAL;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;
public partial class view_system_autoPrintOnOff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RecipeModel rm = new RecipeModel();
            DataTable dt = rm.findPrintOnOffById(1);
            if (dt.Rows.Count > 0)
            {
                this.printOnOff.Value = dt.Rows[0]["onOff"].ToString();
            }

        }
    }

    [WebMethod]
    public static int updatePrintOnOff(string onOff)
    {
        RecipeModel rm = new RecipeModel();
        return rm.updatePrintOnOff(1, onOff);
    }
}