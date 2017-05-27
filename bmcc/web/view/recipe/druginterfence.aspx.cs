using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using SQLDAL;

using System.Data.SqlClient;
using System.Web.Services;
using System.Data;
using System.IO;

using System.Data.OleDb;
using System.Web.Security;


public partial class view_recipe_druginterfence : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strTip = "";
       // Request.QueryString["decmothed"].ToString();

        if (Request.QueryString["drughospitalname"].ToString() == "")
        {
            strTip += "医院名；";
        }

        if (Request.QueryString["drugpspnum"].ToString() == "")
        {
            strTip += "处方号；";
        }
        if (Request.QueryString["drugnum"].ToString() == "")
        {
            strTip += "药品编号；";
        }
        if (Request.QueryString["drugname"].ToString() == "")
        {
            strTip += "药品名称；";
        }
        if (Request.QueryString["drugposition"].ToString()== "")
        {
            strTip += "药品规格；";
        }
        if (Request.QueryString["drugallnum"].ToString() == "")
        {
            strTip += "单剂量；";
        }
        if (Request.QueryString["drugweight"].ToString() == "")
        {
            strTip += "总剂量；";

        }
        if (Request.QueryString["tienum"].ToString() == "")
        {
            strTip += "贴数；";
        }

        if (strTip != "")
        {
            strTip = "以下信息不能空，请填写: " + strTip;

            Page.ClientScript.RegisterStartupScript(
            this.GetType(), "myscript",
            "<script type=\"text/javascript\">function ShowAlert(){alert('" + strTip + "');}window.onload=ShowAlert;</script>");
            return;
        }





        DrugInfo dinfo = new DrugInfo();
        //dinfo.strDelNum = drugdelnum.Value;
        // dinfo.nHospitalNum = Convert.ToInt16(drughospitalnum.Value);

        HospitalModel hm = new HospitalModel();
        SqlDataReader sr = hm.findhospitalidbyhname(Request.QueryString["drughospitalname"].ToString());
        string hospitalid = "";
        if (sr.Read())
        {
            hospitalid = sr["id"].ToString();
        }



        dinfo.nHospitalNum = Convert.ToInt16(hospitalid);







        dinfo.strPspnum = Request.QueryString["drugpspnum"].ToString();
        dinfo.strDrugNum = Request.QueryString["drugnum"].ToString();
        dinfo.strDrugName = Request.QueryString["drugname"].ToString();
        if (Request.QueryString["drugdescription"].ToString() == "")
        {
            dinfo.strDrugDsp = "无";
        }
        else
        {
            dinfo.strDrugDsp =Request.QueryString["drugdescription"].ToString();
        }
        dinfo.strDrugPosition =Request.QueryString["drugposition"].ToString();
        dinfo.nAllNum = Convert.ToInt32(Request.QueryString["drugallnum"].ToString());
        dinfo.dWeight = Convert.ToDouble(Request.QueryString["drugweight"].ToString());
        dinfo.nTieNum = Convert.ToInt32(Request.QueryString["tienum"].ToString());
        if (Request.QueryString["description"].ToString() == "")
        {
            dinfo.strDsp = "无";
        }
        else
        {
            dinfo.strDsp =Request.QueryString["description"].ToString();
        }
        if (Request.QueryString["wholesaleprice"].ToString() != "")
        {
            dinfo.dWholeSalePrice = Convert.ToDouble(Request.QueryString["wholesaleprice"].ToString());
        }
        else
        {

        }
        if (Request.QueryString["retailprice"].ToString() != "")
        {
            dinfo.dRetailPrice = Convert.ToDouble(Request.QueryString["retailprice"].ToString());
        }
        else
        {

        }
        //dinfo.dWholeSaleCost = Convert.ToDouble(wholesalecost.Value);
        // dinfo.dRetailCost = Convert.ToDouble(retailcost.Value);
        // dinfo.dMoneyWithTax = Convert.ToDouble(moneywithtax.Value);
        // dinfo.dFee = Convert.ToDouble(fee.Value);

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
            "<script type=\"text/javascript\">function ShowAlert(){alert('录入失败，此处方已在审核之后阶段不能再添加药品！');}window.onload=ShowAlert;</script>");

        }

    }
}