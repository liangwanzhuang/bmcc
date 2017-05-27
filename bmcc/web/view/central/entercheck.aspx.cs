using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;

public partial class view_central_entercheck : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
       //     ischeck.Items.Add(new ListItem("合格", "1"));
        //    ischeck.Items.Add(new ListItem("不合格", "2"));
       // }
    }
 
    protected void Button1_Click(object sender, EventArgs e)
    {
        string strTip = "";
                if (qualitycheckTime.Value == "")
                {
                    strTip += "请填写质检时间；";
                }
                if (qualitycheckperson.Value == "")
                {
                    strTip += "请填写质检人员；";
                }
                if (pspnum.Value == "")
                {
                    strTip += "请填写煎药单号；";
                }
                if (pspnum.Value.Length >10)
                {
                    strTip += "煎药单号不存在；";
                 }
                if (pspnumweight.Value == "")
                {
                    strTip += "请填写处方重量；";
                }
                if (actualweight.Value == "")
                {
                    strTip += "请填写实际重量；";
                }
                
                if (casetodo.Value == "")
                {
                    strTip += "请填写处理情况；";
                }
      
                if (taste.Value == "")
                {
                    strTip += "请填写药味；";

                }
                if (actualtaste.Value == "")
                {
                    strTip += "请填写实际药味；";
                }


                if (matchperson.Value == "")
                {
                    strTip += "请填写配方员；";
                }

                if (checkperson.Value == "")
                {
                    strTip += "请填写验方员；";

                }
                if (remark.Value == "")
                {
                    strTip += "请填写备注；";
                }
                if (tienum.Value == "")
                {
                    strTip += "请填写贴数；";
                }

                if (qualitycheckperson.Value.Length > 150)
                {
                    strTip += "质检人员已超出150位；";
                }
                if (casetodo.Value.Length > 150)
                {
                    strTip += "处理情况超出150位；";
                }
                if (matchperson.Value.Length > 150)
                {
                    strTip += "配方员超出150位；";
                }
                if (checkperson.Value.Length > 150)
                {
                    strTip += "验方员超出150位；";
                }
                if (remark.Value.Length > 150)
                {
                    strTip += "备注超出150位；";
                }
        
        if (strTip != "")
        {
         strTip = "提示: " + strTip;

        Page.ClientScript.RegisterStartupScript(
        this.GetType(), "myscript",
        "<script type=\"text/javascript\">function ShowAlert(){alert('" + strTip + "');}window.onload=ShowAlert;</script>");
        return;
         }

        string aqualitycheckTime = qualitycheckTime.Value;
        string aqualitycheckperson = qualitycheckperson.Value;
        
        string apspnum = pspnum.Value;
        string apspnumweight = pspnumweight.Value;
        string aactualweight = actualweight.Value;
        double a = Convert.ToDouble(actualweight.Value) - Convert.ToDouble(pspnumweight.Value);
      
        string adeviation = a.ToString();
       
        string acasetodo = casetodo.Value;
        string ataste = taste.Value;

        string aactualtaste = actualtaste.Value;

        string amatchperson = matchperson.Value;

        string acheckperson = checkperson.Value;

        string aremark = remark.Value;

        string aischeck = ischeck.Value;
        string atienum = tienum.Value;

        RecipeModel rm = new RecipeModel();
        int result = rm.AddQualitycheck(aqualitycheckTime, aqualitycheckperson, apspnum, apspnumweight, aactualweight, adeviation, 
         acasetodo, ataste, aactualtaste, amatchperson, acheckperson, aremark, aischeck,atienum);

        if (result ==1)
        {
            Page.ClientScript.RegisterStartupScript(
       this.GetType(), "myscript",
       "<script type=\"text/javascript\">function ShowAlert(){alert('录入成功');}window.onload=ShowAlert;</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(
      this.GetType(), "myscript",
      "<script type=\"text/javascript\">function ShowAlert(){alert('录入失败,可能原因是该煎药单号不存在');}window.onload=ShowAlert;</script>");
        }

    }
}