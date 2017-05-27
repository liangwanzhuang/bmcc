using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;
using System.Data;

public partial class view_query_BusiPerforStat : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        this.FlexGridRecipe.InitConfig(
             new string[]{
                "title=业务员业绩统计信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=false",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=600"//宽度，可为auto或具体px值
            },
            // 序号、委托单号、医院编号、医院名称、处方号、煎药方式、姓名、性别、年龄、电话、地址、科室、病区号、
            //病房号、病床号、诊断结果、剂数、服用方式、次数、包装量、服用方法、煎药方案、一煎时间、二煎时间、
            //浸泡加水量、浸泡时间、标签数量、备注信息、医生、医生脚注、取药时间、取药序号、下单时间、当前状态、
            //操作时间、操作人员、配送公司、配送地址、联系电话、快件类型

             new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("ID","序号",80,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Date","日期",90,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("WorkContent","工作内容",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Sales","销售额",90,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Workload","工作量",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
                


           },
          null
          ,
             null
         );
        this.FlexGridRecipe.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);
    }  //提供数据的方法
 public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        RecipeModel rm = new RecipeModel();
       

        string Salesman = "";
        if (p.extParam.ContainsKey("Salesman"))
        {
            Salesman = p.extParam["Salesman"];
        }
        string STime = "";
        if (p.extParam.ContainsKey("STime"))
        {
            STime = p.extParam["STime"];
        }
        string ETime = "";
        if (p.extParam.ContainsKey("ETime"))
        {
            ETime = p.extParam["ETime"];
        }
        string StaffId = "";
        if (p.extParam.ContainsKey("StaffId"))
        {
            StaffId = p.extParam["StaffId"];
        }

        int pageSize = p.rp;
        result.table = rm.finBusiPerinfo(Salesman, STime, ETime, StaffId);

        
        return result;
    }
 //导出数据
 protected void Button1_Click(object sender, EventArgs e)
 {
     string StaffId1 = StaffId.Value;
     string ETime1 = ETime.Value;
     string STime1 = STime.Value;
     string Salesman1 = Salesman.Value;

     RecipeModel rm = new RecipeModel();

     // DataBaseLayer db = new DataBaseLayer();
     //    string str = "select * from lossiInfor where type ='" + type + "'";
     DataTable dt = rm.finBusiPerinfo(Salesman1, STime1, ETime1, StaffId1);

     CreateExcel(dt, "application/ms-excel", "excel");
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

     string ls_item = "序号\t 日期\t  工作内容\t  销售额 \t 工作量  \n  ";

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
 
}