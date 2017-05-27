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
public partial class view_logistics_setKey : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RecipeModel rm = new RecipeModel();
            DataTable dt = rm.findLogisticsKeyById(1);
            if (dt.Rows.Count > 0)
            {
                this.key.Value = dt.Rows[0]["logisticsKey"].ToString();
            }

        }


        
    }
    [WebMethod]
    public static int updateLogisticsKey(string key)
    {
        RecipeModel rm = new RecipeModel();
        return rm.updateLogisticsKey(1, key);
    }
}