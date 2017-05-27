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

public partial class view_recipe_Deliveryinformation : System.Web.UI.Page
{
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
      
        this.dotNetFlexGrid7.InitConfig(
                      new string[]{
                "title=发货信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=auto"//宽度，可为auto或具体px值
            },
                      new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("ID","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("DecoctingNum","煎药单号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Sendpersonnel","操作人员",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("SendTime","发货时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Sendstate","当前状态",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
               new dotNetFlexGrid.FieldConfig("Remarks","备注",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hname","医院名称",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Pspnum","处方号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("name","患者姓名",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("takenum","次数",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dose","剂量",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("packagenum","包装量",60,true,dotNetFlexGrid.FieldConfigAlign.Center),          
                new dotNetFlexGrid.FieldConfig("getdrugtime","取药时间",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("getdrugnum","取药号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbaddress","配送地址",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
           },
                   null
                   ,
                      null
                  );
        this.dotNetFlexGrid7.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);  //提供数据的方法
    }

    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际
        DeliveryModel rm = new DeliveryModel();
        string Sendstate = "0";
        if (p.extParam.ContainsKey("Sendstate"))
        {
            Sendstate = p.extParam["Sendstate"];
        }
        string SendTime = "0";
        if (p.extParam.ContainsKey("SendTime"))
        {
            SendTime = p.extParam["SendTime"];
        }
        string Sendpersonnel = "0";
        if (p.extParam.ContainsKey("Sendpersonnel"))
        {
            Sendpersonnel = p.extParam["Sendpersonnel"];
        }

        string hospitalId = "0";
        if (p.extParam.ContainsKey("hospitalId"))
        {
            hospitalId = p.extParam["hospitalId"];
        }

        string GetDrugTime = "0";
        if (p.extParam.ContainsKey("GetDrugTime"))
        {
            GetDrugTime = p.extParam["GetDrugTime"];
        }


        if (SendTime == "")
        {
            SendTime = "0";
        }

        if (Sendpersonnel == "")
        {
            Sendpersonnel = "0";
        }

        if (hospitalId == "")
        {
            hospitalId = "0";
        }

        if (GetDrugTime == "")
        {
            GetDrugTime = "0";
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
       result.table = rm.findDeliveryInfo(Sendstate, SendTime, Sendpersonnel, hospitalId, GetDrugTime);
       dotNetFlexGrid.FieldFormatorHandle proc2 = delegate(DataRow dr)
       {

           int bstatus = Convert.ToInt32(dr["Sendstate"].ToString());
           if (bstatus == 1)
           {
               return "已发货";
           }
           else
           {
               return "待发货";
           }

       };
       result.FieldFormator.Register("Sendstate", proc2);
   
        return result;
    }
   
    //导出数据
    protected void Button1_Click(object sender, EventArgs e)
    {
        string Sendpersonnel1 = Sendpersonnel.Value;

        string SendTime1 = SendTime.Value;
        string Sendstate1 = Sendstate.Value;
        if (SendTime1 == "")
        {
            SendTime1 = "0";
        }

        if (Sendpersonnel1 == "")
        {
            Sendpersonnel1 = "0";
        }
        DeliveryModel rm = new DeliveryModel();

        // DataBaseLayer db = new DataBaseLayer();
        //    string str = "select * from lossiInfor where type ='" + type + "'";
        DataTable dt = rm.findDeliveryInfoDao(Sendstate1, SendTime1, Sendpersonnel1);
        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now;
        string now = currentTime.ToString("yyyyMMdd");
        CreateExcel(dt, "application/ms-excel", "发货管理" + now);
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

        string ls_item = "煎药单号\t序号\t  发货人员\t发货时间\t 当前状态\t备注\t医院编号 \t医院名称 \t 处方号\t患者姓名\t煎药机  \t 贴数\t 次数\t  包装量  \t 配送地址 \t取药时间 \t 取药号\n";

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
    public static bool deleteDeliveryById(string strRowIds)
    {
        int a = 0;
        bool result;
        string[] strRows1Id = strRowIds.Split(',');
        for (int i = 0; i < strRows1Id.Length; i++)
        {
            DeliveryModel rm = new DeliveryModel();
            a= rm.deleteDeliveryInfo(Convert.ToInt16(strRows1Id[i]));
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
        TeModel bi = new TeModel();
        string warningid = bi.deliverywarning();

        return warningid;

    }

    
}