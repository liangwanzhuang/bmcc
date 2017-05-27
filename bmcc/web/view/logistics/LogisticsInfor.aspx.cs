using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using SQLDAL;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;

public partial class view_logistics_LogisticsInfor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            HospitalModel hm = new HospitalModel();
            SqlDataReader sd = hm.findHospitalAll();
            int hid = 0;
            hospitalname.Items.Add(new ListItem("  全部  ", "0"));
            if (sd != null)
            {
                while (sd.Read())
                {
                    if (hid == 0)
                    {
                        hid = Convert.ToInt32(sd["ID"].ToString());
                    }
                    this.hospitalname.Items.Add(new ListItem(sd["Hname"].ToString(), sd["ID"].ToString()));

                }
            }
           
           
        }
        this.FlexGridRecipe.InitConfig(
            new string[]{
                "title=物流信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=850"//宽度，可为auto或具体px值
            },
          

            new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("ID","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Pspnum","处方号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("name","患者姓名",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("phone","患者电话",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbtype"," 快递类型",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                //new dotNetFlexGrid.FieldConfig("OutpatientDepartment"," 医院",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("SendTime","发货时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                //new dotNetFlexGrid.FieldConfig("a1","发货方名称",80,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("a2","收件方",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
               new dotNetFlexGrid.FieldConfig("a3","收货方联系电话",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbaddress","收件地址",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("a4","物流单号",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
            //    new dotNetFlexGrid.FieldConfig("curstate","物流状态",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
             //   new dotNetFlexGrid.FieldConfig("e","当前状态",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
                
            //   new dotNetFlexGrid.FieldConfig("qname","签收人",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
             //  new dotNetFlexGrid.FieldConfig("qtime","签收时间",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
              // new dotNetFlexGrid.FieldConfig("DrugDescription","药品详情",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
          
             
            

        
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


        string Pspnum = "";
        if (p.extParam.ContainsKey("Pspnum"))
        {
            Pspnum = p.extParam["Pspnum"];
        }
        string dtbtype = "";
        if (p.extParam.ContainsKey("dtbtype"))
        {
            dtbtype = p.extParam["dtbtype"];
        }
        string hospitalname = "";
        if (p.extParam.ContainsKey("hospitalname"))
        {
            hospitalname = p.extParam["hospitalname"];
        }
        string patient = "";
        if (p.extParam.ContainsKey("patient"))
        {
            patient = p.extParam["patient"];
        }


        string phone = "";
        if (p.extParam.ContainsKey("phone"))
        {
            phone = p.extParam["phone"];
        }

        string curstate = "";
        if (p.extParam.ContainsKey("curstate"))
        {
           curstate = p.extParam["curstate"];
        }
        string time = "0";
        if (p.extParam.ContainsKey("time"))
        {
            time = p.extParam["time"];
        }
        string ftime = "0";
        if (p.extParam.ContainsKey("ftime"))
        {
            ftime = p.extParam["ftime"];
        }
                 
        result.table = rm.LogisticsInfor(Pspnum, dtbtype, hospitalname, patient, phone,curstate,time,ftime);
        dotNetFlexGrid.FieldFormatorHandle proc5 = delegate(DataRow dr)
        {

            int a = Convert.ToInt32(dr["dtbtype"].ToString());
            if (a == 0)
            {
                return "产内配送";
            }
            else if (a == 1)
            {
                return "顺丰";
            }
            else if (a == 2)
            {
                return "圆通";
            }
            else if (a == 3)
            {
                return "中通";
            }
            else if (a == 4)
            {
                return "EMS";
            }
            else
            {
                return "无";
            }

        };
        result.FieldFormator.Register("dtbtype", proc5);
        return result;
       
    }

    protected void ExportMedicineStorage_Click(object sender, EventArgs e)
    {
        string hospitalname1 = hospitalname.Value;
            string Pspnum1 = Pspnum.Value;
            string dtbtype1 = dtbtype.Value;
            string patient1 = patient.Value;
            string phone1 = phone.Value;
            string curstate1 = curstate.Value;
            string time1 = time.Value;
            string ftime1 = ftime.Value;
        RecipeModel rm = new RecipeModel();

        DataTable dt = rm.LogisticsInfor(Pspnum1, dtbtype1, hospitalname1, patient1, phone1,curstate1,time1,ftime1);

        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now;
        string now = currentTime.ToString("yyyyMMdd");
        CreateExcel(dt, "application/ms-excel", "物流信息" + now);
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

        string ls_item = "序号\t处方号\t患者姓名\t患者电话\t快递类型\t发货时间\t收件地址\t当前状态\t收件方\t收货方联系电话\t物流单号\t签收人\t签收时间\t物流状态\n";

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