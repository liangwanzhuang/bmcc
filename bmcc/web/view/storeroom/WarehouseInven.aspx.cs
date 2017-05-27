using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data.SqlClient;
using System.Data;

public partial class view_storeroom_WarehouseInven : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            WarehousepharmacyModel hm = new WarehousepharmacyModel();
            SqlDataReader sdr = hm.findWarehouseInfo();
            Warehouse.Items.Add(new ListItem("全部", "0"));
            if (sdr != null)
            {
                while (sdr.Read())
                {
                    this.Warehouse.Items.Add(new ListItem(sdr["WName"].ToString()));

                }
            }


        }
        this.FlexGridWarehouseInven.InitConfig(
            new string[]{
                "title=库房盘点信息",//标题
                "singleselected=false",//是否单选
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=850"//宽度，可为auto或具体px值
            },

            //盘点时间、盘点日期、盘点人、入库量、出库量、库存容量、实际容量、差值、药品保质期情况、库存安全状况、保管条件是否合格等

            new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("id","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Warehouse","仓库",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("productbatch","批次",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("drugname","药品名称",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                  new dotNetFlexGrid.FieldConfig("drugcode","药品编号",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                
                new dotNetFlexGrid.FieldConfig("time","盘点时间",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("date","盘点日期",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("InventoryPer","盘点人",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("famount","出库量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("iamount","入库量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                  new dotNetFlexGrid.FieldConfig("lossnum","报损量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("kucun","库存容量",80,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ActualCapacity","实际容量",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("chazhi","差值",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
            
                new dotNetFlexGrid.FieldConfig("InventoryStatus","库存状况",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("StorageCondition","保管条件",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("remark","备注",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
               
               
        
           },
         null
         ,
            null
        );
        this.FlexGridWarehouseInven.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);
    }  //提供数据的方法
    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        WarehouseInvenModel rm = new WarehouseInvenModel();


       

        string Warehouse = "";
        if (p.extParam.ContainsKey("Warehouse"))
        {
            Warehouse = p.extParam["Warehouse"];
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

        string drugname = "";
        if (p.extParam.ContainsKey("drugname"))
        {
            drugname = p.extParam["drugname"];
        }

        int pageSize = p.rp;
        result.table = rm.finWarehouseInvenInfor(Warehouse, STime, ETime, drugname);
       dotNetFlexGrid.FieldFormatorHandle proc = delegate(DataRow dr)
        {

            int a = Convert.ToInt32(dr["InventoryStatus"].ToString());
            if (a == 0)
            {
                return "安全";
            }
            else
            {
                return "不安全";
            }

        };
        result.FieldFormator.Register("InventoryStatus", proc);
        dotNetFlexGrid.FieldFormatorHandle proc2 = delegate(DataRow dr)
        {

            int a = Convert.ToInt32(dr["StorageCondition"].ToString());
            if (a == 0)
            {
                return "合格";
            }
            else
            {
                return "不合格";
            }

        };
        result.FieldFormator.Register("StorageCondition", proc2);
        result.FieldFormator.Register("InventoryStatus", proc);



   /*  dotNetFlexGrid.FieldFormatorHandle proc4 = delegate(DataRow dr)
        {
           int iamount=0;
             int famount = 0;
             if (dr["iamount"].ToString() == "")
             {
                 iamount = 0;
             }
             else
             {
                 iamount = Convert.ToInt32(dr["iamount"].ToString());
             }

             if (dr["famount"].ToString() == "")
             {
                 famount=0;
             }
             else
             {
                
                famount = Convert.ToInt32(dr["famount"].ToString());
             }

            int c = iamount - famount;
            if (c < 0)
            {
                c = -c;
            }
           
            string cstr = c.ToString();
           
            return cstr;

        };
        result.FieldFormator.Register("kucun", proc4);


        */


      /*  dotNetFlexGrid.FieldFormatorHandle proc5 = delegate(DataRow dr)
        {
          
            if (dr["iamount"].ToString() == "")
            {
                return "0";
            }
            else
            {
                return  dr["iamount"].ToString();
            }

        };
        result.FieldFormator.Register("iamount", proc5);


        dotNetFlexGrid.FieldFormatorHandle proc6 = delegate(DataRow dr)
        {

            if (dr["famount"].ToString() == "")
            {
                return "0";
            }
            else
            {
                return dr["famount"].ToString();
            }

        };
        result.FieldFormator.Register("famount", proc6);
*/

dotNetFlexGrid.FieldFormatorHandle proc3 = delegate(DataRow dr)
        {


            int a = Convert.ToInt32(dr["kucun"].ToString()) - Convert.ToInt32(dr["ActualCapacity"].ToString());
            if(a<0){
                a=-a;
            }
            return a.ToString();

        };
        result.FieldFormator.Register("chazhi", proc3);
 

            return result;
      
    }
    protected void ExportHouse_Click(object sender, EventArgs e)
    {
        string sTime = STime.Value;
        string eTime = ETime.Value;
        string Warehousing = Warehouse.Value;
        string DrugName = drugname123.Value;


        WarehouseInvenModel rm = new WarehouseInvenModel();

        DataTable dt = rm.finWarehouseInvenInfor(Warehousing, sTime, eTime, DrugName);

        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now;
        string now = currentTime.ToString("yyyyMMdd");
        CreateExcel(dt, "application/ms-excel", "库房库存盘点" + now);
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

        string ls_item = "序号\t仓库\t批次\t药品名称\t药品编号\t盘点人\t实际容量\t库存状况\t保管条件\t盘点时间\t盘点日期\t备注\t入库量\t出库量\t报损量\t库存容量\t差值\n";

        DataRow[] myRow = dt.Select();
        int i = 0;
        int cl = dt.Columns.Count;
        foreach (DataRow row in myRow)
        {
            for (i = 0; i <= cl; i++)
            {
                
                if (i == cl)
                {
                    if (row[6] == "0")
                    {
                        ls_item += "0" + "\n";
                    }
                    else
                    {
                        int a = Convert.ToInt32(row[15].ToString()) - Convert.ToInt32(row[6].ToString());
                        if (a < 0)
                        {
                            a = -a;
                        }

                        ls_item += a.ToString() + "\n";
                    }
                }

                else
                {
                    if (i == 7 || i == 8)
                    {
                        ls_item += "安全" + "\t";
                    }
                    else
                    {
                        ls_item += row[i].ToString() + "\t";
                    }
                }
            }
            Response.Output.Write(ls_item);
            ls_item = string.Empty;
        }
        Response.Output.Flush();
        Response.End();
    }
  
}