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

public partial class view_recipe_RecipeUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sex.Items.Add(new ListItem("男", "1"));
            sex.Items.Add(new ListItem("女", "2"));

            scheme.Items.Add(new ListItem("微压（密闭）解表（15min）", "1"));
            scheme.Items.Add(new ListItem("微压（密闭）汤药（15min）", "2"));
            scheme.Items.Add(new ListItem("微压（密闭）补药（15min）", "3"));
            scheme.Items.Add(new ListItem("常压解表（10min，10min）", "4"));
            scheme.Items.Add(new ListItem("常压汤药（20min，15min）", "5"));
            scheme.Items.Add(new ListItem("常压补药（25min，20min）", "6"));
            scheme.Items.Add(new ListItem("先煎解表（10min，10min，10min）", "20"));
            scheme.Items.Add(new ListItem("先煎汤药（10min，20min，15min）", "21"));
            scheme.Items.Add(new ListItem("先煎补药（10min，25min，20min）", "22"));
            scheme.Items.Add(new ListItem("后下解表（10min（3：7），10min）", "36"));
            scheme.Items.Add(new ListItem("后下汤药（20min（13：7），15min）", "37"));
            scheme.Items.Add(new ListItem("后下补药（25min（18：7），20min）", "38"));
            scheme.Items.Add(new ListItem("微压自定义", "81"));
            scheme.Items.Add(new ListItem("常压自定义", "82"));
            scheme.Items.Add(new ListItem("先煎自定义", "83"));
            scheme.Items.Add(new ListItem("后下自定义", "84"));

            decmothed.Items.Add(new ListItem("先煎", "1"));
            decmothed.Items.Add(new ListItem("后下", "2"));
            decmothed.Items.Add(new ListItem("加糖加蜜", "3"));

            takeway.Items.Add(new ListItem("水煎餐后", "1"));

            dtbtype.Items.Add(new ListItem("顺丰", "1"));
            dtbtype.Items.Add(new ListItem("圆通", "2"));
            dtbtype.Items.Add(new ListItem("中通", "3"));

            HospitalModel hm = new HospitalModel();
            SqlDataReader sdr = hm.findHospitalAll();

            if (sdr != null)
            {
                while (sdr.Read())
                {
                    this.hospitalname.Items.Add(new ListItem(sdr["Hname"].ToString(), sdr["ID"].ToString()));

                }
            }


            if (Request.QueryString["id"] != null && Request.QueryString["randomnumber"] != null)
            {

             //   string str = Request.QueryString[""];


                string str = Request.QueryString["randomnumber"];
                int id = Convert.ToInt16(Request.QueryString["id"]);
                
                idnum.Value = Request.QueryString["id"].ToString();
                RecipeModel rm = new RecipeModel();
                DataTable dt = rm.findRecipeInfo(id);

                delnum.Value = dt.Rows[0]["delnum"].ToString();
                hospitalnum.Value = dt.Rows[0]["hnum"].ToString();

                //hospitalname.Value = dt.Rows[0]["hname"].ToString();
                hospitalname.Value = dt.Rows[0]["hospitalid"].ToString();

                pspnum.Value = dt.Rows[0]["pspnum"].ToString();
                decmothed.Value = dt.Rows[0]["decmothed"].ToString();
                name.Value = dt.Rows[0]["name"].ToString();
                sex.Value = dt.Rows[0]["sex"].ToString();
                age.Value = dt.Rows[0]["age"].ToString();
                phone.Value = dt.Rows[0]["phone"].ToString();
                address.Value = dt.Rows[0]["address"].ToString();
                department.Value = dt.Rows[0]["department"].ToString();
                inpatientnum.Value = dt.Rows[0]["inpatientarea"].ToString();
                wardnum.Value = dt.Rows[0]["ward"].ToString();
                sickbed.Value = dt.Rows[0]["sickbed"].ToString();
                diagresult.Value = dt.Rows[0]["diagresult"].ToString();
                dose.Value = dt.Rows[0]["dose"].ToString();
                num.Value = dt.Rows[0]["takenum"].ToString();
                takemethod.Value = dt.Rows[0]["takemethod"].ToString();
                packquantity.Value = dt.Rows[0]["packagenum"].ToString();
                takeway.Value = dt.Rows[0]["takeway"].ToString();
                scheme.Value = dt.Rows[0]["decscheme"].ToString();
                timeone.Value = dt.Rows[0]["oncetime"].ToString();
                timetwo.Value = dt.Rows[0]["twicetime"].ToString();
                soakwater.Value = dt.Rows[0]["soakwater"].ToString();
                soaktime.Value = dt.Rows[0]["soaktime"].ToString();
                labelnum.Value = dt.Rows[0]["labelnum"].ToString();
                remark.Value = dt.Rows[0]["remark"].ToString();
                doctor.Value = dt.Rows[0]["doctor"].ToString();
                footnote.Value = dt.Rows[0]["footnote"].ToString();
                druggettime.Value = dt.Rows[0]["getdrugtime"].ToString();
                druggetnum.Value = dt.Rows[0]["getdrugnum"].ToString();
                ordertime.Value = dt.Rows[0]["ordertime"].ToString();
               // curstate.Value = dt.Rows[0]["curstate"].ToString();
                //dotime.Value = dt.Rows[0]["dotime"].ToString();
               // doperson.Value = dt.Rows[0]["doperson"].ToString();
                dtbcompany.Value = dt.Rows[0]["dtbcompany"].ToString();
                dtbaddress.Value = dt.Rows[0]["dtbaddress"].ToString();
                dtbphone.Value = dt.Rows[0]["dtbphone"].ToString();
                dtbtype.Value = dt.Rows[0]["dtbtype"].ToString();
                RemarksA.Value = dt.Rows[0]["RemarksA"].ToString();
                RemarksB.Value = dt.Rows[0]["RemarksB"].ToString();
            }
        }
        
    }

    public void btnUpdate_Click(object sender, EventArgs e)
    {
       /* string strTip = "";
        // const string regPattern = @"^(130|131|132|133|134|135|136|137|138|139)\d{8}$"; 
        const string regPattern = @"^((13[0-9]{9})|(159[0-9]{8}))$";
        if (pspnum.Value == "")
        {
            strTip += "电子处方号；";
        }
        if (name.Value == "")
        {
            strTip += "姓名；";
        }
        if (sex.Value == "")
        {
            strTip += "性别；";
        }
        if (age.Value == "")
        {
            strTip += "年龄；";
        }
        if (phone.Value == "")
        {
            strTip += "手机号；";
        }
        else
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(phone.Value, regPattern))
            {
                strTip += "手机号；";
            }
        }

        if (address.Value == "")
        {
            strTip += "地址；";
        }
        if (department.Value == "")
        {
            strTip += "科室；";
        }

        if (diagresult.Value == "")
        {
            strTip += "诊断结果；";
        }
        if (dose.Value == "")
        {
            strTip += "剂量；";
        }

        if (num.Value == "")
        {
            strTip += "次数；";
        }


        if (packquantity.Value == "")
        {
            strTip += "包装量；";
        }
        if (scheme.Value == "13")
        {
            if (timeone.Value == "")
            {
                strTip += "时间段一；";
            }
        }


        if (scheme.Value == "14" || scheme.Value == "15" || scheme.Value == "16")
        {

            if (timeone.Value == "")
            {
                strTip += "时间段一；";
            }

            if (timetwo.Value == "")
            {
                strTip += "时间段二；";
            }
        }
        if (soakwater.Value == "")
        {
            strTip += "浸泡加水量；";
        }

        if (soaktime.Value == "")
        {
            strTip += "浸泡时间；";
        }

        if (labelnum.Value == "")
        {
            strTip += "标签数量；";
        }

        if (remark.Value == "")
        {
            strTip += "备注信息；";
        }

        if (doctor.Value == "")
        {
            strTip += "医生；";
        }

        if (footnote.Value == "")
        {
            strTip += "医生脚注；";
        }

        if (ordertime.Value == "")
        {
            strTip += "下单时间；";
        }



       

        if (dtbcompany.Value == "")
        {
            strTip += "配送公司；";
        }

        if (dtbaddress.Value == "")
        {
            strTip += "配送地址；";
        }

        if (dtbphone.Value == "")
        {
            strTip += "联系电话；";
        }

        if (strTip != "")
        {
            //content.InnerHtml 
            strTip = "修改失败，'"+strTip+"' ，以上信息输入异常，可能没填，可能格式不对，请认真输入后在确认修改" ;

            //ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>window.onload=function(){ok_onclick();}</script>");         

            //return;

          //  Page.ClientScript.RegisterStartupScript(
            //this.GetType(), "myscript",
            //"<script type=\"text/javascript\">function ShowAlert(){alert('" + strTip + "');}window.onload=ShowAlert;</script>");
            Response.Write("<script>alert('" + strTip + "');window.location.href='RecipeSearch.aspx'</script>");
            return;
        }
        */















        RecipeInfo ri = new RecipeInfo();
        int id = Convert.ToInt16(idnum.Value);
        ri.strDelnum = delnum.Value;
        ri.nHospitalID = Convert.ToInt16(hospitalname.Value);


        ri.strPspnum = pspnum.Value;
        ri.strDecMothed = decmothed.Value;
        ri.strName = name.Value;
        ri.nSex = sex.Value;
        ri.nAge =age.Value;
        ri.strPhone = phone.Value;
        ri.strAddress = address.Value;
        ri.strDepartment = department.Value;
        ri.strInpatientAreaNum = inpatientnum.Value;
        ri.strWard = wardnum.Value;
        ri.strSickBed = sickbed.Value;
        ri.strDiagResult = diagresult.Value;
        ri.strDose = dose.Value;
        ri.nNum = num.Value;
        ri.strTakeMethod = takemethod.Value;
        ri.nPackageNum =packquantity.Value;
        ri.strTakeWay = takeway.Value;
        ri.strScheme = scheme.Value;
        ri.strTimeOne = timeone.Value;
        ri.strTimeTwo = timetwo.Value;
        ri.nSoakWater = soakwater.Value;
        ri.nSoakTime = soaktime.Value;
        ri.nLabelNum = labelnum.Value;
        ri.strRemark = remark.Value;
        ri.strDoctor = doctor.Value;
        ri.strFootNote = footnote.Value;
        ri.strDrugGetTime = druggettime.Value;
        ri.strDrugGetNum = druggetnum.Value;
        ri.strOrderTime = ordertime.Value;
       // ri.strCurState = curstate.Value;
       // ri.strDoTime = dotime.Value;
        //ri.strDoPerson = doperson.Value;
        ri.strDtbCompany = dtbphone.Value;
        ri.strDtbAddress = dtbaddress.Value;
        ri.strDtbPhone = dtbphone.Value;
        ri.strDtbStyle = dtbtype.Value;
        ri.strRemarksA =RemarksA.Value;
        ri.strRemarksB = RemarksB.Value;

        RecipeModel rm = new RecipeModel();
        //DataTable dt = rm.findRecipeInfo(id);
       int result = rm.UpdateRecipeInfo(ri, id);

       if (result ==1)
       {
           Response.Write("<script>alert('修改成功');window.location.href='RecipeSearch.aspx'</script>");
       }
       else if (result == 2)
       {
           Response.Write("<script>alert('修改失败，已审核过的处方信息和药品信息，不能被修改');window.location.href='RecipeSearch.aspx'</script>");
       }
       else
       {
            Response.Write("<script>alert('修改失败，该处方号已存在');window.location.href='RecipeSearch.aspx'</script>");
       }
       }
    }



    /*[WebMethod]
    public static string updateRecipeInfo(int id)
    {
        RecipeInfo ri = new RecipeInfo();
        RecipeModel rm = new RecipeModel();
        bool result = rm.UpdateRecipeInfo(ri,id);
   
        string str = null;


        return str;

    }
    */
