using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;
using System.Data;

public partial class view_storeroom_DrugAdminUpdate : System.Web.UI.Page
{
    private static string sDrugCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum1.Value = Request.QueryString["id"].ToString();
            DrugAdminModel wr = new DrugAdminModel();
            DataTable dt = wr.findDrugAdminInfo(id);

            sDrugCode = dt.Rows[0]["DrugCode"].ToString();

            DrugType1.Value = dt.Rows[0]["DrugType"].ToString();
            DrugName12.Value = dt.Rows[0]["DrugName"].ToString();
            PurUnits1.Value = dt.Rows[0]["PurUnits"].ToString();
            DrugCode1.Value = dt.Rows[0]["DrugCode"].ToString();
            DrugSpecificat1.Value = dt.Rows[0]["DrugSpecificat"].ToString();
            PositionNum1.Value = dt.Rows[0]["PositionNum"].ToString();
            Mnemonic1.Value = dt.Rows[0]["Mnemonic"].ToString();
            Univalent1.Value = dt.Rows[0]["Univalent"].ToString();
            Univalent1.Value = dt.Rows[0]["Univalent"].ToString();
            Rmarkes1.Value = dt.Rows[0]["Rmarkes"].ToString();
            Producer1.Value = dt.Rows[0]["Producer"].ToString();
            ProducingArea1.Value = dt.Rows[0]["ProducingArea"].ToString();
            UpperLimit1.Value = dt.Rows[0]["UpperLimit"].ToString();
            LowerLimit1.Value = dt.Rows[0]["LowerLimit"].ToString();
            Rmarkes21.Value = dt.Rows[0]["Rmarkes2"].ToString();
            Rmarkes31.Value = dt.Rows[0]["Rmarkes3"].ToString();

        }

    }
    [WebMethod]
    public static string DrugAdminUpdateInfo(int id, string DrugType, string DrugCode, string PurUnits, string DrugName, string DrugSpecificat, string PositionNum, string Univalent, string Mnemonic, string Rmarkes, string Producer, string ProducingArea, string UpperLimit, string LowerLimit, string Rmarkes2, string Rmarkes3)
    {


        DrugAdminModel wr = new DrugAdminModel();
        if (!DrugCode.Equals(sDrugCode))
        {
            DataTable dataTable = wr.findDrugAdinByDrugCode(DrugCode);
            if (dataTable.Rows.Count > 0)
            {
                return "2";
            }
        }

        
        int result = wr.UpdateDrugAdminInfo(id, DrugType, DrugCode, PurUnits, DrugName, DrugSpecificat, PositionNum, Univalent, Mnemonic, Rmarkes, Producer, ProducingArea, UpperLimit, LowerLimit, Rmarkes2, Rmarkes3);

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