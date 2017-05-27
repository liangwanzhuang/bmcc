using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

public partial class view_recipe_Packaginginformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      //  Statistics sc = new Statistics();
       // string str = sc.countall();


      //  String[] strArr = str.Split(',');

        //count.Text = "统计: 已录入: " + strArr[9] + "  已审核: " + strArr[8] + "   已打印: " + strArr[7] + "   未打印: " + strArr[10] + "   已匹配: " + strArr[6] + "   未匹配: " + strArr[11] + "   已调剂: " + strArr[5] + "  已复核: " + strArr[4] + "  已泡药: " + strArr[0] + "  已煎药: " + strArr[1] + "  已包装：" + strArr[2] + "  已发货：" + strArr[3] + " ";
       // count.Text = "统计：已接方: " + strArr[9] + "    已审核: " + strArr[8] + "     未匹配: " + strArr[11] + "     调剂: " + strArr[5] + "    复核: " + strArr[4] + "    泡药: " + strArr[0] + "    煎药: " + strArr[1] + "     包装：" + strArr[2] + "    发货：" + strArr[3] + " ";
        //报警
     //   PackingHandler ph = new PackingHandler();
     //   string warningid = ph.packwarning() ;

     //   warning.Value = warningid;




        this.dotNetFlexGrid6.InitConfig(
                      new string[]{
                "title=包装信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=false",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=900"//宽度，可为auto或具体px值
            },
                      new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("ID","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("DecoctingNum","煎药单号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Pacpersonnel","操作人员",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("PacTime","包装时间",160,false,dotNetFlexGrid.FieldConfigAlign.Center),
               new dotNetFlexGrid.FieldConfig("PacTime","包装完成时间",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Fpactate","当前状态",80,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Starttime","开始包装时间",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
                //new dotNetFlexGrid.FieldConfig("Timeset","时间设置",160,false,dotNetFlexGrid.FieldConfigAlign.Center),
                // new dotNetFlexGrid.FieldConfig("machineid","煎药机号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
        
                //new dotNetFlexGrid.FieldConfig("hnum","医院编号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hname","医院名称",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                //new dotNetFlexGrid.FieldConfig("delnum","委托单号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Pspnum","处方号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("name","患者姓名",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("sex","性别",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("age","年龄",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("phone","手机号码",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("address","地址",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("department","科室",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("inpatientarea","病区号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                //new dotNetFlexGrid.FieldConfig("ward","病房号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("sickbed","病床号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("diagresult","诊断结果",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                       
                new dotNetFlexGrid.FieldConfig("takemethod","服用方式",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("takenum","次数",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("dose","剂量",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                //new dotNetFlexGrid.FieldConfig("decscheme","煎药方案",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("packagenum","包装量",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("packmachine","包装机",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                //new dotNetFlexGrid.FieldConfig("oncetime","煎药时间一",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                //new dotNetFlexGrid.FieldConfig("twicetime","煎药时间二",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("soakwater","加水量",60,true,dotNetFlexGrid.FieldConfigAlign.Center),

               // new dotNetFlexGrid.FieldConfig("labelnum","标签数量",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("remark","说明",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("doctor","医生",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("footnote","煎医生脚",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("getdrugtime","取药时间",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("getdrugnum","取药号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("ordertime","订单时间",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                //new dotNetFlexGrid.FieldConfig("tisanestatus","当前状态",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("dotime","处理时间",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // //new dotNetFlexGrid.FieldConfig("tisaneman","操作人员",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
    
                //new dotNetFlexGrid.FieldConfig("dtbcompany","配送公司",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("dtbaddress","配送地址",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("dtbphone","快递电话",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("dtbtype","配送类型",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                
                 //new dotNetFlexGrid.FieldConfig("RemarksA","备注A",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                // new dotNetFlexGrid.FieldConfig("RemarksB","备注B",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("warningstatus","预警状态",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
           },
                   null
                   ,
                      null
                  );
        this.dotNetFlexGrid6.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);  //提供数据的方法
    }

    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        PackingModel rm = new PackingModel();
        string Fpactate = "0";
        if (p.extParam.ContainsKey("Fpactate"))
        {
            Fpactate = p.extParam["Fpactate"];
        }
        string Pacpersonnel = "0";
        if (p.extParam.ContainsKey("Pacpersonnel"))
        {
            Pacpersonnel = p.extParam["Pacpersonnel"];
        }
        string PacTime = "0";
        if (p.extParam.ContainsKey("PacTime"))
        {
            PacTime = p.extParam["PacTime"];
        }


        string StartTime = "0";
        if (p.extParam.ContainsKey("StartTime"))
        {
            StartTime = p.extParam["StartTime"];
        }


        if (PacTime == "")
        {
            PacTime = "0";
        }

        if (Pacpersonnel == "")
        {
            Pacpersonnel = "0";
        }


        if (StartTime == "")
        {
            StartTime = "0";
        }


       dotNetFlexGrid.FieldFormatorHandle proc1 = delegate(DataRow dr)
        {
            if (dr["warningstatus"].ToString() == "1")
            {
                return "<span style='color:red'>黄色预警</span>";
            }
            else
            {
                return "<span style='color:black'>暂无预警</span>";
            }


        };



        result.FieldFormator.Register("warningstatus", proc1);


        result.table = rm.findPackingInfo(Fpactate, Pacpersonnel, PacTime, StartTime);
        dotNetFlexGrid.FieldFormatorHandle proc2 = delegate(DataRow dr)
        {

            int bstatus = Convert.ToInt32(dr["Fpactate"].ToString());
            if (bstatus == 1)
            {
                return "包装完成";
            }
            else
            {
                return "开始包装";
            }

        };
        result.FieldFormator.Register("Fpactate", proc2);
      
        return result;

     
     
        


    }
    //导出数据
    protected void Button1_Click(object sender, EventArgs e)
    {
        string PacTime1 = PacTime.Value;

        string Fpactate1 = Fpactate.Value;
        string Pacpersonnel1 = Pacpersonnel.Value;
        if (PacTime1 == "")
        {
            PacTime1 = "0";
        }

        if (Pacpersonnel1 == "")
        {
            Pacpersonnel1 = "0";
        }
        PackingModel rm = new PackingModel();

        // DataBaseLayer db = new DataBaseLayer();
        //    string str = "select * from lossiInfor where type ='" + type + "'";
        DataTable dt = rm.findPackingInfoDao(Fpactate1, Pacpersonnel1, PacTime1);
        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now;
        string now = currentTime.ToString("yyyyMMdd");
        CreateExcel(dt, "application/ms-excel", "包装管理" + now);
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

        string ls_item = "序号\t 煎药单号\t 操作人员 \t包装完成时间\t 当前状态 \t开始包装时间\t医院编号\t医院名称 \t 处方号\t 患者姓名\t煎药机 \t 次数 \t 剂量\t服用方式\t  包装量 \t包装机 \n  ";

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
    public static bool  deletePackingById(string strRowIds)
    {
         int a = 0;
        bool result;
        string[] strRows1Id = strRowIds.Split(',');

        for (int i = 0; i < strRows1Id.Length; i++)
        {

            PackingModel rm = new PackingModel();
           a = rm.deletePackingInfo(Convert.ToInt16(strRows1Id[i]));

        }
        if (a == 0)
        {
            result = false;
        }
        else
        {
            result = true;
        }

        return result;

    }

    [WebMethod]
    public static string getWarning()
    {
        //报警
        PackingHandler ph = new PackingHandler();
        string warningid = ph.packwarning();

        return warningid;

    }
}
