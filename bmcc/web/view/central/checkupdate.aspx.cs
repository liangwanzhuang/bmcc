using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;
using System.Data;
using System.Collections;

public partial class view_central_checkupdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ischeck1.Items.Add(new ListItem("合格", "1"));
            ischeck1.Items.Add(new ListItem("不合格", "2"));
        }

        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum.Value = Request.QueryString["id"].ToString();
            RecipeModel rm = new RecipeModel();
            DataTable dt = rm.findqualitycheckinfobyid(id);

           // bubbleperson.Value = dt.Rows[0]["bp"].ToString();
            qualitycheckTime1.Value = dt.Rows[0]["qualitytime"].ToString();
            tisaneid1.Value = dt.Rows[0]["tisaneid"].ToString();
            qualitycheckperson1.Value = dt.Rows[0]["qualityman"].ToString();
            pspnumweight1.Value = dt.Rows[0]["pspweight"].ToString();
            actualweight1.Value = dt.Rows[0]["actualweight"].ToString();
            //deviation1.Value = dt.Rows[0]["deviation"].ToString();
           // deviationpercent1.Value = dt.Rows[0]["deviationpercent"].ToString();
            casetodo1.Value = dt.Rows[0]["docase"].ToString();
            taste1.Value = dt.Rows[0]["taste"].ToString();
            actualtaste1.Value = dt.Rows[0]["actualtaste"].ToString();
            matchperson1.Value = dt.Rows[0]["matchman"].ToString();
            checkperson1.Value = dt.Rows[0]["checkman"].ToString();
            remark1.Value = dt.Rows[0]["remark"].ToString();
            tienum1.Value = dt.Rows[0]["tie"].ToString();
            ischeck1.Value = dt.Rows[0]["ischeck"].ToString();
           



            // hospitalname.Value = dt.Rows[0][""].ToString();

            // bubbleman.Value = dt.Rows[0]["bp"].ToString();
        }     



    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string strTip = "";
        if (Request.Form["qualitycheckTime1"] == "")
        {
            strTip += "质检时间；";
        }
        if (Request.Form["qualitycheckperson1"] == "")
        {
            strTip += "质检人员；";
        }
        if (Request.Form["tisaneid1"] == "")
        {
            strTip += "煎药单号；";
        }
        if (Request.Form["pspnumweight1"] == "")
        {
            strTip += "处方重量；";
        }
        if (Request.Form["actualweight1"] == "")
        {
            strTip += "实际重量；";
        }
       /* if (Request.Form["deviation1"] == "")
        {
            strTip += "误差；";
        }
        if (Request.Form["deviationpercent1"] == "")
        {
            strTip += "误差百分百；";

        }*/
        if (Request.Form["casetodo1"] == "")
        {
            strTip += "处理情况；";
        }

        if (Request.Form["taste1"] == "")
        {
            strTip += "药味；";

        }
        if (Request.Form["actualtaste1"] == "")
        {
            strTip += "实际药味；";
        }


        if (Request.Form["matchperson1"] == "")
        {
            strTip += "配方员；";
        }

        if (Request.Form["checkperson1"] == "")
        {
            strTip += "验方员；";

        }
        if (Request.Form["remark1"] == "")
        {
            strTip += "备注；";
        }
        if (Request.Form["tienum1"] == "")
        {
            strTip += "贴数；";
        }
        if (Request.Form["ischeck1"] == "")
        {
            strTip += "是否合格；";
        }

        if (strTip != "")
        {
            strTip = "以下信息不能空，请填写: " + strTip;

            Page.ClientScript.RegisterStartupScript(
            this.GetType(), "myscript",
            "<script type=\"text/javascript\">function ShowAlert(){alert('" + strTip + "');}window.onload=ShowAlert;</script>");
            return;
        }
        string id = Request.Form["idnum"];
        string aqualitycheckTime = Request.Form["qualitycheckTime1"];
        string aqualitycheckperson = Request.Form["qualitycheckperson1"];
        string apspnum = Request.Form["tisaneid1"];
        string apspnumweight = Request.Form["pspnumweight1"];
        string aactualweight = Request.Form["actualweight1"];
       // string adeviation = Request.Form["deviation1"];
        //string adeviationpercent = Request.Form["deviationpercent1"];
        string acasetodo = Request.Form["casetodo1"];
        string ataste = Request.Form["taste1"];

        string aactualtaste = Request.Form["actualtaste1"];

        string amatchperson = Request.Form["matchperson1"];

        string acheckperson = Request.Form["checkperson1"];

        string aremark = Request.Form["remark1"];

        string aischeck = Request.Form["ischeck1"];
        string atienum = Request.Form["tienum1"];

        RecipeModel rm = new RecipeModel();
        int result = rm.UpdateQualitycheck(id,aqualitycheckTime, aqualitycheckperson, apspnum, apspnumweight, aactualweight, 
         acasetodo, ataste, aactualtaste, amatchperson, acheckperson, aremark, aischeck, atienum);

        if (result == 1)
        {
            Response.Write("<script>alert('修改成功');window.location.href='querycheck.aspx'</script>");
        }
        else
        {
            Response.Write("<script>alert('修改失败,可能的原因是煎药单号不存在');window.location.href='querycheck.aspx'</script>");
        }
    }
}