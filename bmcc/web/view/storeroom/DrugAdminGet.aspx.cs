using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;
using System.Data;
public partial class view_storeroom_DrugAdminGet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static string addDrugAdminInfo(string DrugType, string DrugCode, string PurUnits, string DrugName, string DrugSpecificat, string PositionNum, string Univalent, string Mnemonic, string Rmarkes, string Producer, string ProducingArea, string UpperLimit, string LowerLimit, string Rmarkes2, string Rmarkes3)
    {
        string result = "";


        //string str2 = str1.TrimStart('0');
        DrugAdminModel wr = new DrugAdminModel();
        DataTable dataTable = wr.findDrugAdinByDrugCode(DrugCode);
        if (dataTable.Rows.Count > 0)
        {
            return "2";
        }
        int sdr = wr.AddDrug( DrugType, DrugCode, PurUnits, DrugName, DrugSpecificat, PositionNum,  Univalent, Mnemonic, Rmarkes, Producer, ProducingArea,  UpperLimit, LowerLimit, Rmarkes2, Rmarkes3);
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


