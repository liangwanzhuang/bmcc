using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using ModelInfo;
using System.Data.SqlClient;

public partial class view_storeroom_MedicineInventoryInfor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            WarehousepharmacyModel hm = new WarehousepharmacyModel();
            SqlDataReader sdr = hm.findWarehouseInfodrug();
            Warehouse.Items.Add(new ListItem("全部", "0"));
            if (sdr != null)
            {
                while (sdr.Read())
                {
                    this.Warehouse.Items.Add(new ListItem(sdr["WName"].ToString()));

                }
            }


        }
        this.FlexGridInventoryInfor.InitConfig(
            new string[]{
                "title=库房库存信息",//标题
                "singleselected=false",//是否单选
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=850"//宽度，可为auto或具体px值
            },
            // 序号、委托单号、医院编号、医院名称、处方号、煎药方式、姓名、性别、年龄、电话、地址、科室、病区号、
            //病房号、病床号、诊断结果、剂数、服用方式、次数、包装量、服用方法、煎药方案、一煎时间、二煎时间、
            //浸泡加水量、浸泡时间、标签数量、备注信息、医生、医生脚注、取药时间、取药序号、下单时间、当前状态、
            //操作时间、操作人员、配送公司、配送地址、联系电话、快件类型

            new dotNetFlexGrid.FieldConfig[]{
                 new dotNetFlexGrid.FieldConfig("id","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("productbatch","药品批次",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
               new dotNetFlexGrid.FieldConfig("warehouse","仓库",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("drugname","药品名称",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("drugcode","药品编号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("iamount","进库量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("famount","出库量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("lossnum","报损量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("consume","消耗量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("kucun","库存容量",80,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ActualCapacity","实际数量",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("chazhi","差值",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("positionnum","货架号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
               
                
            

        
           },
         null
         ,
            null
        );
        this.FlexGridInventoryInfor.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);
    }  //提供数据的方法
    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        StorageManageModel rm = new StorageManageModel();


        var DrugName = "";

        if (p.extParam.ContainsKey("DrugName"))
        {
            DrugName = p.extParam["DrugName"];
        }

        string Warehouse = "";
        if (p.extParam.ContainsKey("Warehouse"))
        {
            Warehouse = p.extParam["Warehouse"];
        }

        //int pageSize = p.rp;
        // result.table = rm.finInventoryInfor(DrugName, Warehouse);
        //result.table = dotNetFlexGrid.DemoMemoryTable(p.page * 100, p.rp);//调用演示的数据生成函数产生模拟数据 
        if (DrugName == "" || DrugName == "0")
        {
            DrugName = "0";
        }

        if (Warehouse == "" || Warehouse == "0")
        {
            Warehouse = "0";
        }



        result.table = rm.druginventory(DrugName, Warehouse);


        dotNetFlexGrid.FieldFormatorHandle proc3 = delegate(DataRow dr)
        {
            string ActualCapacity = "";

            if (dr["ActualCapacity"].ToString() == "0")
            {
                return ActualCapacity = dr["kucun"].ToString();
            }
            else
            {
                return dr["ActualCapacity"].ToString();
            }

        };





        dotNetFlexGrid.FieldFormatorHandle proc4 = delegate(DataRow dr)
        {


            if (dr["ActualCapacity"].ToString() == "0")
            {



                return "0";
            }
            else
            {



                int a = Convert.ToInt32(dr["kucun"].ToString()) - Convert.ToInt32(dr["ActualCapacity"].ToString());
                if (a < 0)
                {

                    a = -a;

                }
                return a.ToString();
            }

        };



        //result.FieldFormator.Register("famount", proc6);
        //result.FieldFormator.Register("iamount", proc5);
        result.FieldFormator.Register("ActualCapacity", proc3);
        result.FieldFormator.Register("chazhi", proc4);




        return result;
    }
    protected void ExportMedicineInventoryInfor_Click(object sender, EventArgs e)
    {
        string DrugName1 = DrugName.Value;

        string Warehouse1 = Warehouse.Value;

        if (DrugName1 == "" || DrugName1 == "0")
        {
            DrugName1 = "0";
        }

        if (Warehouse1 == "" || Warehouse1 == "0")
        {
            Warehouse1 = "0";
        }
        StorageManageModel rm = new StorageManageModel();

        // DataBaseLayer db = new DataBaseLayer();
        //    string str = "select * from lossiInfor where type ='" + type + "'";
        DataTable dt = rm.druginventory(DrugName1, Warehouse1);
        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now;
        string now = currentTime.ToString("yyyyMMdd");
        CreateExcel(dt, "application/ms-excel", "药房库存信息" + now);
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

        string ls_item = "序号\t 仓库\t 药品批次\t货架号\t 药品名称 \t药品编号\t实际数量 \t 进库量\t 出库量\t报损量 \t 库存容量 \t消耗量\t 差值  \n  ";

        DataRow[] myRow = dt.Select();
        int i = 0;
        int cl = dt.Columns.Count;
        foreach (DataRow row in myRow)
        {
            for (i = 0; i <= cl; i++)
            {
                if ((i == 6)&&(row[i].ToString() == "0"))
                {
                    row[6] = row[10];
                }
                if (i == cl)
                {
                    if (row[6] == "0")
                    {
                        ls_item += "0" + "\n";
                    }
                    else
                    {
                        int a = Convert.ToInt32(row[10].ToString()) - Convert.ToInt32(row[6].ToString());
                        if (a < 0)
                        {
                            a = -a;
                        }

                        ls_item += a.ToString() + "\n";
                    }
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