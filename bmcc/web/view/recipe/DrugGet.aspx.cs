using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;

public partial class view_recipe_DrugGet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    protected void btnOkClick(object sender, EventArgs e)
    {
        string strTip = "";

        if (delnum.Value == "")
        {
            strTip += "委托单号；";
        }
        if(pspnum.Value =="")
        {
            strTip += "电子处方号；";
        }
        if (drugnum.Value == "")
        {
            strTip += "药品编号；";
        }
        if (drugname.Value == "")
        {
            strTip += "药品名称；";
        }
        if (drugposition.Value == "")
        {
            strTip += "药品位置；";
        }
        if (drugallnum.Value == "")
        {
            strTip += "药品总数量；";
        }
        if (drugweight.Value == "")
        {
            strTip += "药品重量；";

        }
        if (tienum.Value == "")
        {
            strTip += "贴数；";
        }

        if (strTip != "")
        {
            strTip = "以下信息不能空，请填写: " + strTip;

            Page.ClientScript.RegisterStartupScript(
            this.GetType(), "myscript",
            "<script type=\"text/javascript\">function ShowAlert(){alert('" + strTip + "');}window.onload=ShowAlert;</script>");
  
        }

        
        DrugInfo dinfo = new DrugInfo();
        dinfo.nHospitalNum = Convert.ToInt16(hospitalid.Value);
        dinfo.strHospitalName = hospitalname.Value;
        dinfo.strPspnum = pspnum.Value;
        dinfo.strDrugNum = drugnum.Value;
        dinfo.strDrugName = drugname.Value;
        dinfo.strDrugDsp = drugdescription.Value;
        dinfo.strDrugPosition = drugposition.Value;
        dinfo.nAllNum = Convert.ToInt16(drugallnum.Value);
        dinfo.dWeight = Convert.ToDouble(drugweight.Value);
        dinfo.nTieNum = Convert.ToInt16(tienum.Value);
        dinfo.strDsp = description.Value;
        dinfo.dWholeSalePrice = Convert.ToDouble(wholesaleprice.Value);
        dinfo.dRetailPrice = Convert.ToDouble(retailprice.Value);
        dinfo.dWholeSaleCost = Convert.ToDouble(wholesalecost.Value);
        dinfo.dRetailCost = Convert.ToDouble(retailcost.Value);
        dinfo.dMoneyWithTax = Convert.ToDouble(moneywithtax.Value);
        dinfo.dFee = Convert.ToDouble(fee.Value);

        EnterDrug ed = new EnterDrug();
        bool rn = ed.AddDrug(dinfo);

        if (rn)
        {
            Page.ClientScript.RegisterStartupScript(
             this.GetType(), "myscript",
             "<script type=\"text/javascript\">function ShowAlert(){alert('药品录入成功');}window.onload=ShowAlert;</script>");

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(
            this.GetType(), "myscript",
            "<script type=\"text/javascript\">function ShowAlert(){alert('药品录入成功');}window.onload=ShowAlert;</script>");

        }
    }
}