using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data.SqlClient;
using System.Web.Services;
using System.Data;
using System.IO;

using System.Data.OleDb;
using System.Web.Security;


using SQLDAL;

public partial class view_recipe_RecipeGet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sex.Items.Add(new ListItem("男", "1"));
            sex.Items.Add(new ListItem("女", "2"));
            if (Session["userNamebar"] != null)
            {
                string usernamechange = "";
                string usernamebar = Session["userNamebar"].ToString();
                EmployeeModel em = new EmployeeModel();
                SqlDataReader sdr3 = em.findusernamebyjobnum(usernamebar);
                if (sdr3.Read())
                {
                    usernamechange = sdr3["EName"].ToString();
                }
                this.doperson.Value = usernamechange;
            }
           
             else
             {
                    Response.Write("<script>alert('用户名已失效');window.parent.loginview();</script>");
                    
              }

           
            
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
            int hid = 0;
            if (sdr != null)
            {
                while (sdr.Read())
                {
                    if (hid == 0)
                    {
                       hid = Convert.ToInt32(sdr["ID"].ToString());
                    }
                    this.hospitalname.Items.Add(new ListItem(sdr["Hname"].ToString(), sdr["ID"].ToString()));

                }
            }

                   
            DataTable dt = hm.findNumById( Convert.ToInt16(hospitalname.Value));

            hospitalnum.Value = dt.Rows[0][0].ToString();

            EntrustNumberModel enm = new EntrustNumberModel();
            delnum.Value = enm.getEntrustNumber(hid)+"";

            System.DateTime seconddayTime = new System.DateTime();
            seconddayTime = System.DateTime.Now.AddDays(1);//当前时间  


            string getdrugtime = seconddayTime.ToString("yyyy-MM-dd 08:00:00");//

            this.soaktime.Value = "30";

            this.druggettime.Value = getdrugtime;


        }
            string strDelNum = DateTime.Now.ToString("MMddhhmmss");
           // delnum.Value = strDelNum;
           
            string strdotime = DateTime.Now.ToString();

            
            string a = "";     
            this.FlexGridRecipe.InitConfig(
                new string[]{
                "title=处方信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=1000",//宽度，可为auto或具体px值
                "selectedonclick = true"
            },
            new dotNetFlexGrid.FieldConfig[]{
                        new dotNetFlexGrid.FieldConfig("ID","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("hnum","医院编号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("hname","医院名称",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("delnum","委托单号",120,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("Hospitalid","医院ID",60,true,dotNetFlexGrid.FieldConfigAlign.Center,false,true,false),
                        new dotNetFlexGrid.FieldConfig("Pspnum","处方号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("decmothed","煎药方法",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("name","患者姓名",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("sex","性别",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("age","年龄",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("phone","手机号码",150,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("address","地址",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("department","科室",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("inpatientarea","病区号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("ward","病房号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("sickbed","病床号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("diagresult","诊断结果",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                       
                        new dotNetFlexGrid.FieldConfig("takemethod","服用方式",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("takenum","次数",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("decscheme","煎药方案",180,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("packagenum","包装量",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                       new dotNetFlexGrid.FieldConfig("dose","贴数",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("oncetime","煎药时间一",80,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("twicetime","煎药时间二",80,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("soakwater","浸泡加水量",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("soaktime","浸泡时间",60,true,dotNetFlexGrid.FieldConfigAlign.Center),

                        new dotNetFlexGrid.FieldConfig("labelnum","标签数量",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("remark","说明",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("doctor","医生",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("footnote","医生脚注",120,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("getdrugtime","取药时间",120,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("getdrugnum","取药号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("ordertime","下单时间",120,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("curstate","当前状态",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("dotime","接方时间",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("dtbcompany","配送公司",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("dtbaddress","配送地址",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("dtbphone","快递电话",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("dtbtype","配送类型",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("takeway","服用方法",80,true,dotNetFlexGrid.FieldConfigAlign.Center),
                 
                         new dotNetFlexGrid.FieldConfig("RemarksA","备注A",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                        new dotNetFlexGrid.FieldConfig("RemarksB","备注B",60,true,dotNetFlexGrid.FieldConfigAlign.Center),

                   },
         null
         ,
            null
        );

        
        this.FlexGridRecipe.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(FlexGridRecipeDataHandler);  //提供数据的方法
     

   
                this.FlexGridDrug.InitConfig(
                  new string[]{
                "title=药物信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=false",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=false",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=980"//宽度，可为auto或具体px值
            },
            //序号、委托单号、医院编号、医院名称、处方号、药品编号、药品名称、药品描述、药品位置、药品总数量、药品重量、贴数、说明、批发价格、零售价格
             new dotNetFlexGrid.FieldConfig[]{

                new dotNetFlexGrid.FieldConfig("ID","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("delnum","委托单号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hnum","医院编号",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hname","医院名称",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Hospitalid","医院ID",60,true,dotNetFlexGrid.FieldConfigAlign.Center,false,true,false),
                new dotNetFlexGrid.FieldConfig("Pspnum","处方号",65,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Drugnum","药品编号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Drugname","药品名称",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("DrugDescription","脚注",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("DrugPosition","药品规格",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("DrugAllNum","单剂量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("DrugWeight","总剂量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("TieNum","贴数",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Description","说明",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("WholeSalePrice","批发价格",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("RetailPrice","零售价格",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("WholeSaleCost","批发费用",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                //new dotNetFlexGrid.FieldConfig("retailpricecost","零售费用",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                //new dotNetFlexGrid.FieldConfig("money","含税金额",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                //new dotNetFlexGrid.FieldConfig("Fee","扣率",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
           },
          null
          ,
             null
         );

        this.FlexGridDrug.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(FlexGridFlexGridDrugDataHandler);  //提供数据的方法
        
    }
//表1方法
    public dotNetFlexGrid.DataHandlerResult FlexGridRecipeDataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际
      

       //如果传递的参数包含排序设置的话，通过DataView.Sort功能模拟进行当页排序
        RecipeModel rm = new RecipeModel();
        result.table = rm.findRecipeInfo();
      dotNetFlexGrid.FieldFormatorHandle proc2 = delegate(DataRow dr)
            {

                int a = Convert.ToInt32(dr["sex"].ToString());
                if (a == 1)
                {
                    return "男";
                }
                else
                {
                    return "女";
                }


                

            };
            result.FieldFormator.Register("sex", proc2);
            dotNetFlexGrid.FieldFormatorHandle proc3 = delegate(DataRow dr)
            {

                int b = Convert.ToInt32(dr["decscheme"].ToString());
                if (b == 1)
                {
                    return "微压（密闭）解表（15min）";
                }
                else if (b == 2)
                {
                    return "微压（密闭）汤药（15min）";
                }
                else if (b == 3) { return "微压（密闭）补药（15min）"; }
                else if (b == 4) { return "常压解表（10min，10min）"; }
                else if (b == 5) { return "常压汤药（20min，15min）"; }
                else if (b == 6) { return "常压补药（25min，20min）"; }
                else if (b == 20) { return "先煎解表（10min，10min，10min）"; }
                else if (b == 21) { return "先煎汤药（10min，20min，15min）"; }
                else if (b == 22) { return "先煎补药（10min，25min，20min）"; }
                else if (b == 36) { return "后下解表（10min（3：7），10min）"; }
                else if (b == 37) { return "后下汤药（20min（13：7），15min）"; }
                else if (b == 38) { return "后下补药（25min（18：7），20min）"; }
                else if (b == 81) { return "微压自定义"; }
                else if (b == 82) { return "常压自定义"; }
                else if (b == 83) { return "先煎自定义"; }
                else { return "后下自定义"; }
            };
            result.FieldFormator.Register("decscheme", proc3);

            dotNetFlexGrid.FieldFormatorHandle proc4 = delegate(DataRow dr)
            {

                int a = Convert.ToInt32(dr["decmothed"].ToString());
                if (a == 1)
                {
                    return "先煎";
                }
                else if (a == 2)
                {
                    return "后下";
                }
                else
                {
                    return "加糖加蜜";
                }




            };
            result.FieldFormator.Register("decmothed", proc4);
            dotNetFlexGrid.FieldFormatorHandle proc6 = delegate(DataRow dr)
            {

                int a = Convert.ToInt32(dr["takeway"].ToString());
                if (a == 1)
                {
                    return "水煎餐后";
                }
                else
                {
                    return "";
                }




            };
            result.FieldFormator.Register("takeway", proc6);
            dotNetFlexGrid.FieldFormatorHandle proc5 = delegate(DataRow dr)
            {

                int a = Convert.ToInt32(dr["dtbtype"].ToString());
                if (a == 1)
                {
                    return "顺丰";
                }
                else if (a == 2)
                {
                    return "圆通";
                }
                else
                {
                    return "中通";
                }




            };
            result.FieldFormator.Register("dtbtype", proc5);

            return result;
        }
    
//表2方法
   public dotNetFlexGrid.DataHandlerResult FlexGridFlexGridDrugDataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际
        DrugModel dm = new DrugModel();
        string pspnum = "0";
        string hospitalId = "";
      /*  if (p.extParam.ContainsKey("drugpspnum"))
        {
            pspnum = p.extParam["drugpspnum"];
        }
        if (p.extParam.ContainsKey("Hospitalid"))
        {
            hospitalId = p.extParam["Hospitalid"];
        }*/

        string pid = "";
        if (p.extParam.ContainsKey("pid"))
        {
            pid = p.extParam["pid"];
        }



        //result.table = dm.findDrugByPspnum(pspnum, hospitalId);

        result.table = dm.findDrugByPspnum(pid);
       // result.table = dotNetFlexGrid.DemoMemoryTable(p.page * 100, p.rp);//调用演示的数据生成函数产生模拟数据
        //如果传递的参数包含排序设置的话，通过DataView.Sort功能模拟进行当页排序
        //if (p.sortname.Length > 0 && p.sortorder.Length > 0)
        //{
        //    System.Data.DataView dv = result.table.DefaultView;
        //    dv.Sort = (p.sortname + " " + p.sortorder);
        //    result.table = dv.ToTable();
        //}
        ////处理默认查询，即Button1_Click中指定的DefaultSearch查询参数
        //if (p.defaultSearch.ContainsKey("String1"))
        //{
        //    System.Data.DataView dv = result.table.DefaultView;
        //    dv.RowFilter = "String1 Like '%" + p.defaultSearch["String1"] + "%'";
        //    result.table = dv.ToTable();
        //}

        ////如果传递的参数包含附加参数的话，再来模拟查询，原谅我真的很懒。
        //if (p.extParam.ContainsKey("String1"))
        //{
        //    System.Data.DataView dv = result.table.DefaultView;
        //    dv.RowFilter = "String1 Like '%" + p.extParam["String1"] + "%'";
        //    result.table = dv.ToTable();
        //}
        ////如果传递的参数包含快速查询参数，则进行快速查询
        //if (p.qop != dotNetFlexGrid.SerchParamConfigOperater.None && p.qtype.Length > 0 && p.query.Length > 0)
        //{
        //    System.Data.DataView dv = result.table.DefaultView;
        //    if (p.qop == dotNetFlexGrid.SerchParamConfigOperater.Like)
        //        dv.RowFilter = p.qtype + " Like '%" + p.query + "%'";
        //    else
        //        dv.RowFilter = p.qtype + " = '" + p.query + "'";
        //    result.table = dv.ToTable();
        //}
        
        return result;
    }
 
    protected void btnRecipeOkClick(object sender, EventArgs e)
    {
       // string  regtel = "/^((13[0-9]{9})|(159[0-9]{8}))$/";
        //System.Text.RegularExpressions.Regex objPattern = new System.Text.RegularExpressions.Regex("/^((13[0-9]{9})|(159[0-9]{8}))$/");
       string strTip = "";
      // const string regPattern = @"^(130|131|132|133|134|135|136|137|138|139)\d{8}$"; 
       const string regPattern = @"^\d{11}$";
       const string regnumber = @"^([0-9]*)$";
       if (pspnum.Value == "")
       {
            strTip += "电子处方号不能为空；";
       }
      
      if (phone.Value != "")
       {
      
           if (!System.Text.RegularExpressions.Regex.IsMatch(phone.Value, regPattern))
           {
               strTip += "手机号格式不对；";
           }
      }
      if (age.Value != "")
      {

          if (!System.Text.RegularExpressions.Regex.IsMatch(age.Value, regnumber))
          {
              strTip += "年龄格式不对；";
          }
      }

      if (soakwater.Value != "")
      {

          if (!System.Text.RegularExpressions.Regex.IsMatch(soakwater.Value, regnumber))
          {
              strTip += "浸泡加水量格式不对；";
          }
      }
      if (labelnum.Value != "")
      {

          if (!System.Text.RegularExpressions.Regex.IsMatch(labelnum.Value, regnumber))
          {
              strTip += "标签数量格式不对；";
          }
      }
      if (druggetnum.Value != "")
      {

          if (!System.Text.RegularExpressions.Regex.IsMatch(druggetnum.Value, regnumber))
          {
              strTip += "取药号格式不对；";
          }
      }
      if (dose.Value == "")
      {
          strTip += "贴数不能为空；";
      }
      else
      {
          if (!System.Text.RegularExpressions.Regex.IsMatch(dose.Value, regnumber))
          {
              strTip += "贴数格式不对；";
          }
      }

      if (num.Value == "")
      {
          strTip += "次数不能为空；";
      }
      else
      {
          if (!System.Text.RegularExpressions.Regex.IsMatch(num.Value, regnumber))
          {
              strTip += "次数格式不对；";
          }
      }


       if (packquantity.Value == "")
       {
           strTip += "包装量不能为空；";
       }
       else
       {
           if (!System.Text.RegularExpressions.Regex.IsMatch(packquantity.Value, regnumber))
           {
               strTip += "包装量格式不对；";
           }
       }
        if(scheme.Value =="13"){
       if (timeone.Value == "")
       {
           strTip += "时间段一不能为空；";
       }
       else
       {
           if (!System.Text.RegularExpressions.Regex.IsMatch(timeone.Value, regnumber))
           {
               strTip += "时间段一格式不对；";
           }
       }
        }


        if (scheme.Value == "14" || scheme.Value == "15" || scheme.Value == "16")
        {

            if (timeone.Value == "")
            {
                strTip += "时间段一不能为空；";
            }
            else
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(timeone.Value, regnumber))
                {
                    strTip += "时间段一格式不对；";
                }
            }

            if (timetwo.Value == "")
            {
                strTip += "时间段二不能为空；";
            }
            else
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(timetwo.Value, regnumber))
                {
                    strTip += "时间段二格式不对；";
                }
            }
        }
      

       if (soaktime.Value == "")
       {
           strTip += "浸泡时间不能为空；";
       }
       else
       {
           if (!System.Text.RegularExpressions.Regex.IsMatch(soaktime.Value, regnumber))
           {
               strTip += "浸泡时间格式不对；";
           }
       }

       if (this.druggettime.Value == "")
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

        RecipeInfo rinfo = new RecipeInfo();
        rinfo.strDelnum = delnum.Value;
        rinfo.nHospitalID = Convert.ToInt16(hospitalname.Value);
       // rinfo.strHospitalNum = hospitalnum.Value;
        rinfo.strPspnum = pspnum.Value;
        rinfo.strName = name.Value;
        rinfo.nSex = sex.Value;
        rinfo.nAge = age.Value;
        rinfo.strPhone = phone.Value;
        rinfo.strAddress = address.Value;
        rinfo.strDepartment = department.Value;
        rinfo.strInpatientAreaNum = inpatientnum.Value;
        if (wardnum.Value.Length > 10)
        {
            strTip += "病房号超出50位！；";
        }
        else
        {
            rinfo.strWard = wardnum.Value;
        }
        rinfo.strSickBed = sickbed.Value;
        rinfo.strDiagResult = diagresult.Value;
        rinfo.strDose = dose.Value;
        rinfo.nNum = num.Value;
        

        rinfo.strDrugGetTime = druggettime.Value;
        rinfo.strDrugGetNum = druggetnum.Value;
        rinfo.strScheme = scheme.Value;
        rinfo.strTimeOne = timeone.Value;
        rinfo.strTimeTwo = timetwo.Value;
        rinfo.nPackageNum = packquantity.Value;
       
        rinfo.strDoPerson = doperson.Value;
        rinfo.strDtbCompany = dtbcompany.Value;
        rinfo.strDtbAddress = dtbaddress.Value;
        rinfo.strDtbPhone = dtbphone.Value;
        rinfo.strDtbStyle = dtbtype.Value;
        rinfo.nSoakWater =soakwater.Value;
        rinfo.nSoakTime = soaktime.Value;
        rinfo.nLabelNum = labelnum.Value;
        rinfo.strRemark = remark.Value;
        rinfo.strDoctor = doctor.Value;
        rinfo.strFootNote = footnote.Value;
        rinfo.strOrderTime = ordertime.Value;
        //rinfo.strCurState = curstate.Value;

        if (rinfo.strOrderTime=="")
        {
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;//当前时间  
            string ordertime1 = currentTime.ToString("yyyy-MM-dd 00:00:00");//
            rinfo.strOrderTime = ordertime1;

        }

        rinfo.strDecMothed = decmothed.Value;
        rinfo.strTakeWay = takeway.Value;
        rinfo.strTakeMethod = takemethod.Value;
        rinfo.strRemarksA = RemarksA.Value;
        rinfo.strRemarksB = RemarksB.Value;
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
    [WebMethod]
    public static string getNumByHospitalId(int hospitalId)
    {
        HospitalModel hm = new HospitalModel();
        DataTable dt = hm.findNumById(hospitalId);

        string data = "";
        data = dt.Rows[0][0].ToString();
        EntrustNumberModel enm = new EntrustNumberModel();


        return data + ";" + enm.getEntrustNumber(hospitalId);
       

    }
    
    
    [WebMethod]
    public static DataTable getRecipeInfoById(int rowId)
    {
        HospitalModel hm = new HospitalModel();
        DataTable dt = hm.findNumById(rowId);

        //string data = "";
        //data = dt.Rows[0][0].ToString();
        return dt;

    }

    protected void btnDrugOkClick(object sender, EventArgs e)
    {
        string strTip = "";

        
        if (drugpspnum.Value == "")
        {
            strTip += "处方号；";
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
            strTip += "药品规格；";
        }
        if (drugallnum.Value == "")
        {
            strTip += "单剂量；";
        }
        if (drugweight.Value == "")
        {
            strTip += "总剂量；";

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
            return;
        }


        DrugInfo dinfo = new DrugInfo();
        //dinfo.strDelNum = drugdelnum.Value;
       // dinfo.nHospitalNum = Convert.ToInt16(drughospitalnum.Value);

        HospitalModel hm = new HospitalModel();
       SqlDataReader sr = hm.findhospitalidbyhname(drughospitalname.Value);
       string hospitalid = "";
       if (sr.Read())
       {
           hospitalid = sr["id"].ToString();
       }



       dinfo.nHospitalNum = Convert.ToInt16(hospitalid);







        dinfo.strPspnum = drugpspnum.Value;
        dinfo.strDrugNum = drugnum.Value;
        dinfo.strDrugName = drugname.Value;
        if (drugdescription.Value =="") {
            dinfo.strDrugDsp = "无";
        }
        else {
        dinfo.strDrugDsp = drugdescription.Value;}
        dinfo.strDrugPosition = drugposition.Value;
        dinfo.nAllNum = Convert.ToInt32(drugallnum.Value);
        dinfo.dWeight = Convert.ToDouble(drugweight.Value);
        dinfo.nTieNum = Convert.ToInt32(tienum.Value);
        if (description.Value == "") {
            dinfo.strDsp = "无";
        }
        else
        {
            dinfo.strDsp = description.Value;
        }
        if (wholesaleprice.Value != "")
        {
            dinfo.dWholeSalePrice = Convert.ToDouble(wholesaleprice.Value);
        }
        else { 
        
        }
        if (retailprice.Value != "")
        {
            dinfo.dRetailPrice = Convert.ToDouble(retailprice.Value);
        }
        else { 
              
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
            "<script type=\"text/javascript\">function ShowAlert(){alert('药品录入失败，相同的药品不能被添加，或该处方已确认添加完成！');}window.onload=ShowAlert;</script>");

        }
    }

    [WebMethod]
    public static string confirmDrug(int pid,string pspnum, string Hospitalid)
    {
        DrugModel dm = new DrugModel();

        DataTable dt = dm.findDrugByPid(pid+"");
        if (dt.Rows.Count > 0)
        {
            RecipeModel rm = new RecipeModel();
            int count = rm.confirmDrug(pid);
            if (count > 0)
            {
                DrugMatchingModel dmm = new DrugMatchingModel();

                dmm.findNotCheckAndMatchRecipeDrugInfoToMatch();
                return "操作成功";
            }
            else
            {
                return "操作失败";
            }

        }
        else
        {
            return "操作失败:该处方还没有录入药品";

        }
        
        

    }

    [WebMethod]
    public static string submitDrugInfo(string hospitalid, string drugpspnum, string drugnum, string drugname
        , string drugdescription, string drugposition, string drugallnum, string drugweight, string tienum
        , string description, string wholesaleprice, string retailprice, string pid)
    {
        DrugInfo dinfo = new DrugInfo();
        HospitalModel hm = new HospitalModel();
        dinfo.nHospitalNum = Convert.ToInt16(hospitalid);

        dinfo.strPspnum = drugpspnum;
        dinfo.strDrugNum = drugnum;
        dinfo.strDrugName = drugname;
        if (drugdescription == "")
        {
            dinfo.strDrugDsp = "无";
        }
        else
        {
            dinfo.strDrugDsp = drugdescription;
        }
        dinfo.strDrugPosition = drugposition;
        dinfo.nAllNum = Convert.ToInt32(drugallnum);
        dinfo.dWeight = Convert.ToDouble(drugweight);
        dinfo.nTieNum = Convert.ToInt32(tienum);
        if (description == "")
        {
            dinfo.strDsp = "无";
        }
        else
        {
            dinfo.strDsp = description;
        }
        if (wholesaleprice != "")
        {
            dinfo.dWholeSalePrice = Convert.ToDouble(wholesaleprice);
        }
        else
        {

        }
        if (retailprice != "")
        {
            dinfo.dRetailPrice = Convert.ToDouble(retailprice);
        }
        else
        {

        }
        RecipeModel m = new RecipeModel();
        DataTable table = m.findPrescriptionById(pid);
        if (table.Rows.Count > 0)
        {
            if ("1".Equals(table.Rows[0]["confirmDrug"].ToString()))
            {
                return "该处方药品已录入完成,不可以在录入药品";
            }
            else {
                EnterDrug ed = new EnterDrug();
                /**/
                bool rn = ed.AddDrug(dinfo);

                if (rn)
                {
                    return "录入成功";

                }
                else
                {
                    return "录入失败";

                }
            }

        }
        else
        {
            return "处方不存在";
        }
    }
}
