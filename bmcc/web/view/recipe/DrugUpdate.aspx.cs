using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



using ModelInfo;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

public partial class view_recipe_DrugUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum.Value = Request.QueryString["id"].ToString();
            RecipeModel rm = new RecipeModel();
            DataTable dt = rm.findDrugInfo(id);

            drugnum.Value = dt.Rows[0]["drugnum"].ToString();
            drugdescription.Value = dt.Rows[0]["drugdescription"].ToString();
            drugposition.Value = dt.Rows[0]["drugposition"].ToString();
            drugweight.Value = dt.Rows[0]["drugweight"].ToString();
            description.Value = dt.Rows[0]["Description"].ToString();
            wholesaleprice.Value = dt.Rows[0]["wholesaleprice"].ToString();
            wholesalecost.Value = dt.Rows[0]["wholesalecost"].ToString();
            moneywithtax.Value = dt.Rows[0]["money"].ToString();

            drugname.Value = dt.Rows[0]["Drugname"].ToString();
            drugallnum.Value = dt.Rows[0]["drugallnum"].ToString();
            tienum.Value = dt.Rows[0]["tienum"].ToString();
            retailprice.Value = dt.Rows[0]["retailprice"].ToString();
            retailcost.Value = dt.Rows[0]["retailpricecost"].ToString();
            fee.Value = dt.Rows[0]["fee"].ToString();        
        }
    }

   

    [WebMethod]
    //public static int updateDrugInfo(string id, string drugnum, string drugdescription, string drugposition, string drugweight, string description, string wholesaleprice, string wholesalecost, string moneywithtax, string drugname, string drugallnum, string tienum, string retailprice, string retailcost, string fee)
    public static int updateDrugInfo(string id, string drugnum, string drugdescription, string drugposition, string drugweight, string description, string wholesaleprice, string wholesalecost, string moneywithtax, string drugname, string drugallnum, string tienum, string retailprice, string retailcost, string fee)
   {

    
      // RecipeInfo ri = new RecipeInfo();
       RecipeModel rm = new RecipeModel();
      // bool result = rm.UpdateRecipeInfo(ri,id);
      int result = rm.updatedruginfo(id, drugnum, drugdescription, drugposition, drugweight, description, wholesaleprice, wholesalecost, moneywithtax, drugname, drugallnum, tienum, retailprice, retailcost, fee);

     


       return result;

   }
  



   
}