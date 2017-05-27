using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;
using System.Data;
using System.Data.SqlClient;

public partial class view_query_DistributionStat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HospitalModel hm = new HospitalModel();
            SqlDataReader sdr = hm.findHospitalAll();
            RecipeModel rm = new RecipeModel();
            SqlDataReader sdr1 = rm.findRecipAlla();
            hospitalname.Items.Add(new ListItem("  全部  ", "0"));
            DCompany.Items.Add(new ListItem("  全部  ", "0"));
            if (sdr != null)
            {
                while (sdr.Read())
                {
                    this.hospitalname.Items.Add(new ListItem(sdr["Hname"].ToString(), sdr["ID"].ToString()));
                    
                }
            }
            if (sdr1 != null)
            {
                while (sdr1.Read())
                {
                    
                    this.DCompany.Items.Add(new ListItem(sdr1["b"].ToString()));
                }
            }

            DataTable table = rm.finDistributInfoCount("","","","0");

            this.chartDatas.Value=DataTableToJson.ToJson(table);
            
        }
            this.FlexGridRecipe.InitConfig(
                 new string[]{
                "title=配送统计信息",//标题
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
                new dotNetFlexGrid.FieldConfig("ID","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Pspnum","处方号",80,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hname","医院名称",80,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Hospitalid","医院ID",60,true,dotNetFlexGrid.FieldConfigAlign.Center,false,true,false),
                new dotNetFlexGrid.FieldConfig("name","患者姓名",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("phone","联系电话",140,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Sendpersonnel","发货人员",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbcompany","配送公司",210,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbaddress","配送地址",210,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("SendTime","发货时间",210,false,dotNetFlexGrid.FieldConfigAlign.Center,false,true,false),
              

           },
              null
              ,
                 null
             );
            this.FlexGridRecipe.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);
        }
    //提供数据的方法
 public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        RecipeModel rm = new RecipeModel();


        string hospitalID = "";
        if (p.extParam.ContainsKey("hospitalID"))
        {
            hospitalID = p.extParam["hospitalID"];
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
        string dtbcompany = "0";
        if (p.extParam.ContainsKey("dtbcompany"))
        {
            dtbcompany = p.extParam["dtbcompany"];
        }
        if (dtbcompany == "无")
        {
            dtbcompany = "";

        }
        dotNetFlexGrid.FieldFormatorHandle proc91 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["dtbcompany"].ToString() == "")
            {
                String az = dr["dtbcompany"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                String az = dr["dtbcompany"].ToString();
                z = az;
            }

            return z;

        };
        result.FieldFormator.Register("dtbcompany", proc91);
        //int pageSize = p.rp;
        result.table = rm.finDistributInfo(hospitalID, STime, ETime, dtbcompany);

        
        return result;
    }

 //导出数据
 protected void Button1_Click(object sender, EventArgs e)
 {
     string hospitalID1 = hospitalname.Value;

     string STime1 = STime.Value;
     string ETime1 = ETime.Value;
     string dtbcompany1 = DCompany.Value;

    
     if (dtbcompany1 == "")
     {
         dtbcompany1 = "0";
     }
     RecipeModel rm = new RecipeModel();
     DataTable dt = rm.finDistributInfo(hospitalID1, STime1, ETime1, dtbcompany1);

     System.DateTime currentTime = new System.DateTime();
     currentTime = System.DateTime.Now;
     string now = currentTime.ToString("yyyyMMdd");
     CreateExcel(dt, "application/ms-excel", "配送统计" + now);
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

     string ls_item = "序号\t 处方号\t 患者姓名 \t联系电话\t发货人员 \t 医院编号\t医院名称 \t配送公司 \t 配送地址\t发货时间  \n  ";

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
 public static string finDistributInfoCount(string hospitalID, string STime, string ETime, string dtbcompany)
 {
     RecipeModel rm = new RecipeModel();

     DataTable table = rm.finDistributInfoCount(hospitalID, STime, ETime, dtbcompany);

     string data = DataTableToJson.ToJson(table);

     return data;
 }


   
}