using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;

public partial class view_query_tisanestatics : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TeModel tm = new TeModel();
        SqlDataReader sdr = tm.findTisaneAll();



        if (sdr != null)
        {
            while (sdr.Read())
            {
                this.tisanenum.Items.Add(new ListItem(sdr["machinename"].ToString(), sdr["id"].ToString()));
            }

        }


     

        this.FlexGrid2.InitConfig(
                new string[]{
                "title=煎药机工作量统计",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=814"//宽度，可为auto或具体px值
            },
          

             new dotNetFlexGrid.FieldConfig[]{
              new dotNetFlexGrid.FieldConfig("hao","煎药机号",183,true,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("workdate","日期",190,true,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("workcontent","工作内容",190,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("workload","工作量",190,false,dotNetFlexGrid.FieldConfigAlign.Center),
          
           },
             null
             ,
                null
            );
        this.FlexGrid2.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid2DataHandler);


       TeModel tml = new TeModel();

       DataTable dt = tml.findtisanemachineInfo(0, "0", "0");
        this.chartData.Value = DataTableToJson.ToJson(dt);

    }


 


    //提供数据的方法
    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid2DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        //result.table = dotNetFlexGrid.DemoMemoryTable(p.page * 100, p.rp);

        string tisanenum = "0";
        if (p.extParam.ContainsKey("tisanenum"))
        {
            tisanenum = p.extParam["tisanenum"];
        }


        if (tisanenum == "")
        {
            tisanenum = "0";
        }



        string StartTime = "0";
        if (p.extParam.ContainsKey("StartTime"))
        {
            StartTime = p.extParam["StartTime"];
        }


        if (StartTime == "")
        {
            StartTime = "0";
        }




        string EndTime = "0";
        if (p.extParam.ContainsKey("EndTime"))
        {
            EndTime = p.extParam["EndTime"];
        }


        if (EndTime == "")
        {
            EndTime = "0";
        }




        TeModel tm = new TeModel();
        result.table = tm.findtisanemachineInfo(Convert.ToInt32(tisanenum), StartTime, EndTime);
        //  RecipeModel rm = new RecipeModel();
        //result.table = rm.findAdjustRecipeInfo();

        return result;

    }




    //导出数据
    protected void Button1_Click(object sender, EventArgs e)
    {
        string tisanenum1 = tisanenum.Value;

        string EndTime1 = EndTime.Value;
        string StartTime1 = StartTime.Value;
        if (tisanenum1 == "")
        {
            tisanenum1 = "0";
        }

        if (StartTime1 == "")
        {
            StartTime1 = "0";
        }
        if (EndTime1 == "")
        {
            EndTime1 = "0";
        }
        TeModel tm = new TeModel();
        DataTable dt= tm.findtisanemachineInfo(Convert.ToInt32(tisanenum1), StartTime1, EndTime1);
         
        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now;
        string now = currentTime.ToString("yyyyMMdd");
        CreateExcel(dt, "application/ms-excel", "煎药机工作量统计"+now);
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

        string ls_item = "序号\t 煎药机号\t 日期\t 工作内容 \t工作量 \n  ";

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
    public static string findtisanemachineInfo(string tisanenum, string StartTime, string EndTime)
    {

        TeModel tm = new TeModel();
        DataTable table = tm.findtisanemachineInfo(Convert.ToInt32(tisanenum), StartTime, EndTime);

        return DataTableToJson.ToJson(table);
    }

  






}