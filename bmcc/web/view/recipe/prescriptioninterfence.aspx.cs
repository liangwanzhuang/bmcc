using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;

public partial class view_recipe_prescriptioninterfence : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        string strTip = "";
        // const string regPattern = @"^(130|131|132|133|134|135|136|137|138|139)\d{8}$"; 
        const string regPattern = @"^\d{11}$";
        const string regnumber = @"^([0-9]*)$";
        if (Request.QueryString["pspnum"].ToString() == "")
        {
            strTip += "电子处方号不能为空；";
        }

        if (Request.QueryString["phone"].ToString() != "")
        {

            if (!System.Text.RegularExpressions.Regex.IsMatch(Request.QueryString["phone"].ToString(), regPattern))
            {
                strTip += "手机号格式不对；";
            }
        }
        if (Request.QueryString["age"].ToString() != "")
        {

            if (!System.Text.RegularExpressions.Regex.IsMatch(Request.QueryString["age"].ToString(), regnumber))
            {
                strTip += "年龄格式不对；";
            }
        }

        if (Request.QueryString["soakwater"].ToString() != "")
        {

            if (!System.Text.RegularExpressions.Regex.IsMatch(Request.QueryString["soakwater"].ToString(), regnumber))
            {
                strTip += "浸泡加水量格式不对；";
            }
        }
        if (Request.QueryString["labelnum"].ToString()!= "")
        {

            if (!System.Text.RegularExpressions.Regex.IsMatch(Request.QueryString["labelnum"].ToString(), regnumber))
            {
                strTip += "标签数量格式不对；";
            }
        }
        if (Request.QueryString["druggetnum"].ToString() != "")
        {

            if (!System.Text.RegularExpressions.Regex.IsMatch(Request.QueryString["druggetnum"].ToString(), regnumber))
            {
                strTip += "取药号格式不对；";
            }
        }
        if (Request.QueryString["dose"].ToString() == "")
        {
            strTip += "贴数不能为空；";
        }
        else
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(Request.QueryString["dose"].ToString(), regnumber))
            {
                strTip += "贴数格式不对；";
            }
        }

        if (Request.QueryString["num"].ToString() == "")
        {
            strTip += "次数不能为空；";
        }
        else
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(Request.QueryString["num"].ToString(), regnumber))
            {
                strTip += "次数格式不对；";
            }
        }


        if (Request.QueryString["packquantity"].ToString() == "")
        {
            strTip += "包装量不能为空；";
        }
        else
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(Request.QueryString["packquantity"].ToString(), regnumber))
            {
                strTip += "包装量格式不对；";
            }
        }
        if (Request.QueryString["scheme"].ToString() == "13")
        {
            if (Request.QueryString["timeone"].ToString() == "")
            {
                strTip += "时间段一不能为空；";
            }
            else
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(Request.QueryString["timeone"].ToString(), regnumber))
                {
                    strTip += "时间段一格式不对；";
                }
            }
        }


        if (Request.QueryString["scheme"].ToString() == "14" || Request.QueryString["scheme"].ToString() == "15" || Request.QueryString["scheme"].ToString() == "16")
        {

            if (Request.QueryString["timeone"].ToString() == "")
            {
                strTip += "时间段一不能为空；";
            }
            else
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(Request.QueryString["timeone"].ToString(), regnumber))
                {
                    strTip += "时间段一格式不对；";
                }
            }

            if (Request.QueryString["timetwo"].ToString() == "")
            {
                strTip += "时间段二不能为空；";
            }
            else
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(Request.QueryString["timetwo"].ToString(), regnumber))
                {
                    strTip += "时间段二格式不对；";
                }
            }
        }


        if (Request.QueryString["soaktime"].ToString() == "")
        {
            strTip += "浸泡时间不能为空；";
        }
        else
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(Request.QueryString["soaktime"].ToString(), regnumber))
            {
                strTip += "浸泡时间格式不对；";
            }
        }

        if (Request.QueryString["druggettime"].ToString() == "")
        {
            strTip += "取药时间不能为空；";
        }


        /* if (dtbphone.Value == "")
         {
             strTip += "联系电话；";
         }
         else
         {
             if (!System.Text.RegularExpressions.Regex.IsMatch(dtbphone.Value, regPattern))
             {
                 strTip += "联系电话；";
             }
         }
          */
        if (strTip != "")
        {
            //content.InnerHtml 
            strTip = "提示: " + strTip;

            //ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>window.onload=function(){ok_onclick();}</script>");         

            //return;

            Page.ClientScript.RegisterStartupScript(
            this.GetType(), "myscript",
            "<script type=\"text/javascript\">function ShowAlert(){alert('" + strTip + "');}window.onload=ShowAlert;</script>");
            return;
        }


       // EmployeeModel em = new EmployeeModel();

       // string JobNum = Request.QueryString["JobNum"].ToString();
        //string strTip = "";
        RecipeInfo rinfo = new RecipeInfo();
        rinfo.strDelnum = Request.QueryString["delnum"].ToString(); 
        rinfo.nHospitalID = Convert.ToInt16(Request.QueryString["hospitalname"].ToString());
        // rinfo.strHospitalNum = hospitalnum.Value;
        rinfo.strPspnum = Request.QueryString["pspnum"].ToString();
        rinfo.strName = Request.QueryString["name"].ToString();
        rinfo.nSex = Request.QueryString["sex"].ToString();
        rinfo.nAge = Request.QueryString["age"].ToString();
        rinfo.strPhone = Request.QueryString["phone"].ToString();
        rinfo.strAddress = Request.QueryString["address"].ToString();
        rinfo.strDepartment = Request.QueryString["department"].ToString();
        rinfo.strInpatientAreaNum = Request.QueryString["inpatientnum"].ToString(); 
       
       
        rinfo.strWard = Request.QueryString["wardnum"].ToString();
       
        rinfo.strSickBed = Request.QueryString["sickbed"].ToString();
        rinfo.strDiagResult = Request.QueryString["diagresult"].ToString();
        rinfo.strDose = Request.QueryString["dose"].ToString();
        rinfo.nNum = Request.QueryString["num"].ToString();


        rinfo.strDrugGetTime = Request.QueryString["druggettime"].ToString();
        rinfo.strDrugGetNum = Request.QueryString["druggetnum"].ToString();
        rinfo.strScheme = Request.QueryString["scheme"].ToString();
        rinfo.strTimeOne = Request.QueryString["timeone"].ToString();
        rinfo.strTimeTwo = Request.QueryString["timetwo"].ToString();
        rinfo.nPackageNum = Request.QueryString["packquantity"].ToString();

        rinfo.strDoPerson = Request.QueryString["doperson"].ToString();
        rinfo.strDtbCompany = Request.QueryString["dtbcompany"].ToString();
        rinfo.strDtbAddress = Request.QueryString["dtbaddress"].ToString();
        rinfo.strDtbPhone = Request.QueryString["dtbphone"].ToString();
        rinfo.strDtbStyle = Request.QueryString["dtbtype"].ToString();
        rinfo.nSoakWater = Request.QueryString["soakwater"].ToString();
        rinfo.nSoakTime = Request.QueryString["soaktime"].ToString();
        rinfo.nLabelNum = Request.QueryString["labelnum"].ToString();
        rinfo.strRemark = Request.QueryString["remark"].ToString();
        rinfo.strDoctor = Request.QueryString["doctor"].ToString();
        rinfo.strFootNote = Request.QueryString["footnote"].ToString();
        rinfo.strOrderTime = Request.QueryString["ordertime"].ToString();
        //rinfo.strCurState = curstate.Value;

        if (rinfo.strOrderTime == "")
        {
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;//当前时间  
            string ordertime1 = currentTime.ToString("yyyy-MM-dd 00:00:00");//
            rinfo.strOrderTime = ordertime1;

        }

        rinfo.strDecMothed = Request.QueryString["decmothed"].ToString();
        rinfo.strTakeWay = Request.QueryString["takeway"].ToString();
        rinfo.strTakeMethod = Request.QueryString["takemethod"].ToString();
        rinfo.strRemarksA = Request.QueryString["RemarksA"].ToString();
        rinfo.strRemarksB = Request.QueryString["RemarksB"].ToString(); 



      //  DataTable dataTable = em.findEmployeeByJobNum(JobNum);
      //  if (dataTable.Rows.Count > 0)
      //  {
      //      Response.Write("{\"code\":\"0\",\"msg\":\"操作成功\",\"data\":" + DataTableToJson.ToJson(dataTable) + "}");
      //  }
      //  else
     //   {
      //      Response.Write("{\"code\":\"1\",\"msg\":\"操作失败\"}");
       // }


        EnterRecipe er = new EnterRecipe();
        bool rn = er.AddRecipe(rinfo);
        if (rn)
        {
            Page.ClientScript.RegisterStartupScript(
             this.GetType(), "myscript",
             "<script type=\"text/javascript\">function ShowAlert(){alert('处方录入成功');}window.onload=ShowAlert;</script>");

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(
            this.GetType(), "myscript",
            "<script type=\"text/javascript\">function ShowAlert(){alert('处方录入失败,可能该医院已存在此处方号！');}window.onload=ShowAlert;</script>");

        }
    }
}