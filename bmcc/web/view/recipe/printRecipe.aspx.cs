﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Script.Services;
using System.Web.Services;
using System.Collections.Generic;
using System.Data;
public partial class view_recipe_printRecipe : System.Web.UI.Page
{

    private string hospitalId = "0";
    private string pspnum = "0";

    protected void Page_Load(object sender, EventArgs e)
    {

        HospitalModel hm = new HospitalModel();
        SqlDataReader sdr = hm.findHospitalAll();

        if (sdr != null)
        {
            while (sdr.Read())
            {
                this.hospitalSelect.Items.Add(new ListItem(sdr["Hname"].ToString(), sdr["ID"].ToString()));

            }

        }

        this.FlexGridRecipe.InitConfig(
                   new string[]{
                "title=未打印处方信息",//标题
                
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=1000"//宽度，可为auto或具体px值
            },
                new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("ID","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("delnum","委托单号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hnum","医院编号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hname","医院名称",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Pspnum","处方号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("name","患者姓名",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("sex","性别",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("age","年龄",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("phone","电话",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("address","地址",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("department","科室",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("inpatientarea","病区号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ward","病房号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("sickbed","病床号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("diagresult","诊断结果",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("takemethod","服用方式",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("takenum","次数",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("packagenum","包装量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("decscheme","煎药方案",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("oncetime","一煎时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("twicetime","二煎时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("soakwater","浸泡加水量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("soaktime","浸泡时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("labelnum","标签数量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("remark","备注信息",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("doctor","医生",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("footnote","医生脚注",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("getdrugtime","取药时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("getdrugnum","取药序号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ordertime","下单时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("curstate","当前状态",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dotime","操作时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("doperson","操作人员",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbcompany","配送公司",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbaddress","配送地址",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbphone","联系电话",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbtype","快件类型",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Hospitalid","医院ID",60,true,dotNetFlexGrid.FieldConfigAlign.Center,false,true,false),
               
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
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=1000"//宽度，可为auto或具体px值
            },
            //序号、委托单号、医院编号、医院名称、处方号、药品编号、药品名称、药品描述、药品位置、药品总数量、药品重量、贴数、说明、批发价格、零售价格
             new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("ID","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                //new dotNetFlexGrid.FieldConfig("delnum","委托单号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hnum","医院编号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hname","医院名称",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Pspnum","处方号",95,false,dotNetFlexGrid.FieldConfigAlign.Center),
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

           },
          null
          ,
             null
         );

        this.FlexGridDrug.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(FlexGridFlexGridDrugDataHandler);  //提供数据的方法
    }

    public dotNetFlexGrid.DataHandlerResult FlexGridRecipeDataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        RecipeModel rm = new RecipeModel();

        string hospitalId = "0";
        if (p.extParam.ContainsKey("hospitalId"))
        {
            hospitalId = p.extParam["hospitalId"];
        }
        string pspnum = "";
        if (p.extParam.ContainsKey("pspnum"))
        {
            pspnum = p.extParam["pspnum"];
        }
        string Status ="0";
        if (p.extParam.ContainsKey("printStatus"))
        {
            Status = p.extParam["printStatus"];
        }
       
        result.table = rm.findRecipeInfo(Convert.ToInt32(hospitalId), pspnum, Convert.ToInt32(Status));
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



    public dotNetFlexGrid.DataHandlerResult FlexGridFlexGridDrugDataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际
        DrugModel dm = new DrugModel();

        string pid = "";
        if (p.extParam.ContainsKey("pid"))
        {
            pid = p.extParam["pid"];
        }

        result.table = dm.findDrugByPspnum(pid);

        return result;
    }
 
    [WebMethod]
    public static string printRecipeBycurentid(string currentid)
    {

        string id = currentid;

        return id;
    }

}