using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ModelInfo;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Script.Services;
using System.Web.Services;
using System.Data;
public partial class view_recipe_SwapSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // Statistics sc = new Statistics();
       // string str = sc.countall();

        
       // String[] strArr = str.Split(',');

        //count.Text = "统计: 已录入: " + strArr[9] + "  已审核: " + strArr[8] + "   已打印: " + strArr[7] + "   未打印: " + strArr[10] + "   已匹配: " + strArr[6] + "   未匹配: " + strArr[11] + "   已调剂: " + strArr[5] + "  已复核: " + strArr[4] + "  已泡药: " + strArr[0] + "  已煎药: " + strArr[1] + "  已包装：" + strArr[2] + "  已发货：" + strArr[3] + " ";
      //  count.Text = "统计：已接方: " + strArr[9] + "    已审核: " + strArr[8] + "     未匹配: " + strArr[11] + "     调剂: " + strArr[5] + "    复核: " + strArr[4] + "    泡药: " + strArr[0] + "    煎药: " + strArr[1] + "     包装：" + strArr[2] + "    发货：" + strArr[3] + " ";

        //报警
        // DeliveryModel dm = new DeliveryModel();
        //string warningid = dm.deliverywarning();
     //   TeModel tm = new TeModel();

       // string warningid = tm.adjustwarning();
      //  warning.Value = warningid;



        this.FlexGridRecipe.InitConfig(
            new string[]{
                "title=处方信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=false",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=1000"//宽度，可为auto或具体px值
            },
            // 序号、委托单号、医院编号、医院名称、处方号、煎药方式、姓名、性别、年龄、电话、地址、科室、病区号、
            //病房号、病床号、诊断结果、剂数、服用方式、次数、包装量、服用方法、煎药方案、一煎时间、二煎时间、
            //浸泡加水量、浸泡时间、标签数量、备注信息、医生、医生脚注、取药时间、取药序号、下单时间、当前状态、
            //操作时间、操作人员、配送公司、配送地址、联系电话、快件类型 开始时间 调剂ID 完成时间  备注A 备注B

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
                new dotNetFlexGrid.FieldConfig("status","当前状态",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
             //   new dotNetFlexGrid.FieldConfig("dotime","操作时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("SwapPer","操作人员",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbcompany","配送公司",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbaddress","配送地址",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbphone","联系电话",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbtype","快件类型",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("wordDate","开始时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("aid","调剂ID",60,true,dotNetFlexGrid.FieldConfigAlign.Center,false,true,false),
                new dotNetFlexGrid.FieldConfig("endDate","完成时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("RemarksA","备注A",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("RemarksB","备注B",60,true,dotNetFlexGrid.FieldConfigAlign.Center),


           },
         null
         ,
            null
        );


        this.FlexGridRecipe.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(FlexGridRecipeDataHandler);  //提供数据的方法
    }

    public dotNetFlexGrid.DataHandlerResult FlexGridRecipeDataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际
       
        RecipeModel rm = new RecipeModel();
        //0,未完成,1已完成,2全部
        string status = "0";
        if (p.extParam.ContainsKey("status"))
        {
            status = p.extParam["status"];
        }
        string date = "";
        if (p.extParam.ContainsKey("date"))
        {
            date = p.extParam["date"];
        }
        string eName = "";
        if (p.extParam.ContainsKey("eName"))
        {
            eName = p.extParam["eName"];
        }
        int pageSize = p.rp;
        //result.table = rm.findRecipeInfo(11, "111");
        result.table = rm.findAdjustRecipeInfo(Convert.ToInt32(status), date, eName);
        dotNetFlexGrid.FieldFormatorHandle proc1 = delegate(DataRow dr)
        {

            int bstatus = Convert.ToInt32(dr["status"].ToString());
            if (bstatus == 1)
            {
                return "调剂完成";
            }
            else
            {
                return "开始调剂";
            }

        };
        result.FieldFormator.Register("status", proc1);
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
    //导出数据
    protected void Button1_Click(object sender,  EventArgs e)
    {
        string status1 = status.Value;

        string date1 = date.Value;
        string eName1 = eName.Value;
        RecipeModel rm = new RecipeModel();

        // DataBaseLayer db = new DataBaseLayer();
        //    string str = "select * from lossiInfor where type ='" + type + "'";
        DataTable dt = rm.findAdjustRecipeInfoDao(Convert.ToInt32(status1), date1, eName1);
        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now;
        string now = currentTime.ToString("yyyyMMdd");
        CreateExcel(dt, "application/ms-excel", "调剂查询" + now);
    }
    public void CreateExcel(DataTable dt, string FileType, string FileName)
    {
        Response.Clear();
        Response.Charset = "UTF-8";
        Response.Buffer = true;
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls\"");
        Response.ContentType = FileType;
        string colHeaders = string.Empty;
        //string ls_item = string.Empty;
        //(select status from adjust as a where a.prescriptionId =p.id )as status,p.Hospitalid,p.name,p.sex,p.age,p.phone,p.address,p.department,p.inpatientarea,p.ward,p.sickbed,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,"
            // + "diagresult,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime, doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,  RemarksA,RemarksB"
           //  + ",(select wordDate from adjust as a where  a.prescriptionId =p.id) as wordDate,(select endDate from adjust as a where  a.prescriptionId =p.id) as endDate  from prescription as p where   p.id not in (select pid from InvalidPrescription) and  p.id in (select prescriptionId from  adjust as a where 1=1


        string ls_item = "序号\t处方号\t委托单号\t调剂人员\t当前状态\t医院ID\t姓名\t性别\t年龄\t电话\t地址\t科室\t病区号\t"
            + "病房号\t病床号\t医院编号\t医院名称\t诊断结果\t贴数\t次数\t取药时间\t取药序号\t服用方式\t煎药方案\t一煎时间\t二煎时间\t包装量\t操作时间\t操作人员"
            + "\t配送公司\t配送地址\t联系电话\t快件类型 \t浸泡加水量\t浸泡时间\t标签数量\t备注信息\t医生\t医生脚注\t下单时间\t"
            + " 备注A \t备注B\t开始时间 \t完成时间\n";

        DataRow[] myRow = dt.Select();
        int i = 0;
        int cl = dt.Columns.Count;
        foreach (DataRow row in myRow)
        {
            for (i = 0; i < cl; i++)
            {
                if (i == (cl - 1))
                {
                    ls_item += row[i].ToString() + "\n";
                }
                else
                {
                    ls_item += row[i].ToString() + "\t";
                }
            }
            Response.Output.Write(ls_item);
            ls_item = string.Empty;
        }
        Response.Output.Flush();
        Response.End();
    }
    [WebMethod]
    public static int delAdjust(int id)
    {
        AdjustModel rm = new AdjustModel();
        int num = rm.delAdjust(id);

        return num;
    }



    [WebMethod]
    public static string getpcwarning()
    {

        TeModel tm = new TeModel();

        string warningid = tm.adjustwarning();
        return warningid;
    }
    
}