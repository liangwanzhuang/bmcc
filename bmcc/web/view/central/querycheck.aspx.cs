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
public partial class view_central_querycheck : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            pspstatus.Items.Add(new ListItem("合格", "1"));
            pspstatus.Items.Add(new ListItem("不合格", "2"));
        }



        this.dotNetFlexGrid1.InitConfig(
                    new string[]{
                "title=抽检列表查询",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=600"//宽度，可为auto或具体px值
            },
            // 序号、委托单号、医院编号、医院名称、处方号、煎药方式、姓名、性别、年龄、电话、地址、科室、病区号、
            //病房号、病床号、诊断结果、剂数、服用方式、次数、包装量、服用方法、煎药方案、一煎时间、二煎时间、
            //浸泡加水量、浸泡时间、标签数量、备注信息、医生、医生脚注、取药时间、取药序号、下单时间、当前状态、
            //操作时间、操作人员、配送公司、配送地址、联系电话、快件类型

                    new dotNetFlexGrid.FieldConfig[]{
             new dotNetFlexGrid.FieldConfig("id","序号",90,true,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("qualitytime","质检时间",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("qualityman","质检人员",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("tisaneid","煎药单号",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("pspweight","处方重量",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("actualweight","实际重量",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("deviation","误差",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("deviationpercent","误差百分百",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("docase","处理情况",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("taste","药味",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("actualtaste","实际药味",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("matchman","配方人员",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("checkman","验方人员",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("remark","备注",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("tie","贴数",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("ischeck","是否合格",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
            
           },
                 null
                 ,
                    null
                );
        this.dotNetFlexGrid1.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);
    }


    //提供数据的方法
    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际



        string pspstatus = "0";
        if (p.extParam.ContainsKey("pspstatus"))
        {
            pspstatus = p.extParam["pspstatus"];
        }


        if (pspstatus == "")
        {
            pspstatus = "0";
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
        string employcode = "0";
        if (p.extParam.ContainsKey("employcode"))
        {
            employcode = p.extParam["employcode"];
        }


        if (employcode == "")
        {
            employcode = "0";
        }

        string qualityman = "0";
        if (p.extParam.ContainsKey("qualityman"))
        {
            qualityman = p.extParam["qualityman"];
        }


        if (qualityman == "")
        {
            qualityman = "0";
        }



       RecipeModel rm = new  RecipeModel();
       result.table = rm.findqualitycheckinfo(pspstatus, StartTime, EndTime,qualityman);




       dotNetFlexGrid.FieldFormatorHandle proc1 = delegate(DataRow dr)
       {

           int ischeck = Convert.ToInt32(dr["ischeck"].ToString());
           
           if (ischeck == 1)
           {
               return "合格";
           }
           else
           {
               return "不合格";
           }

       };

       result.FieldFormator.Register("ischeck", proc1);


        return result;

    }
    //导出数据
    protected void Button1_Click(object sender, EventArgs e)
    {
        string pspstatus1 = pspstatus.Value;
        string StartTime1 = StartTime.Value;
        string EndTime1 = EndTime.Value;
        string qualityman1 = qualityman.Value;
       

        if (pspstatus1 == "")
        {
            pspstatus1 = "0";
        }
        if (StartTime1 == "")
        {
            StartTime1 = "0";
        }

        if (EndTime1 == "")
        {
            EndTime1 = "0";
        }
        
        if (qualityman1 == "")
        {
            qualityman1 = "0";
        }

        RecipeModel rm = new RecipeModel();
        DataTable dt = rm.findqualitycheckinfo(pspstatus1, StartTime1, EndTime1, qualityman1);

        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now;
        string now = currentTime.ToString("yyyyMMdd");
        CreateExcel(dt, "application/ms-excel", "质检列表查询" + now);
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

        string ls_item = "序号\t 质检时间\t 质检人员 \t煎药单号\t处方重量 \t 实际重量\t误差 \t误差百分比 \t 处理情况\t药味\t实际药味\t是否合格\t配方人员\t 验方人员\t贴数\t备注 \n  ";

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