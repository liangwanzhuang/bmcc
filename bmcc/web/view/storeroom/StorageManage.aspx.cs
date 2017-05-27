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

public partial class view_storeroom_StorageManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
           if (!IsPostBack)
           {
            WarehousepharmacyModel hm = new WarehousepharmacyModel();
            SqlDataReader sdr = hm.findWarehouseInfo();
               if (sdr != null)
            {
                while (sdr.Read())
                {
                    this.Warehouse1.Items.Add(new ListItem(sdr["WName"].ToString()));

                }
            }


        }
        this.FlexGridStorage.InitConfig(
                 new string[]{
                "title=入库单信息",//标题
                "striped=true",//是否显示行交替色
                 "singleselected=false",//是否单选
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=1000"//宽度，可为auto或具体px值

            },
            

                 new dotNetFlexGrid.FieldConfig[]{
               
                new dotNetFlexGrid.FieldConfig("id","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ProductBatch","药品批次",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("DrugCode","药品编号",90,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("DrugName","药品名称",90,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Univalent","单价",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("PurUnits","单位",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Amount","数量",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("money","金额",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ProDate","生产日期",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ExpiryDate","有效日期",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Quality","质量情况",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Producer","生产商",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ProducingArea","产地",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("LicenseNum","批准文号",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Remarkes","备注",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                
               // new dotNetFlexGrid.FieldConfig("DrugSpecificat","药品规格",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                //new dotNetFlexGrid.FieldConfig("BatchNum","批号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                //new dotNetFlexGrid.FieldConfig("OSingle","开单人",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                //new dotNetFlexGrid.FieldConfig("OSTime","开单时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),

           },
              null
              ,
                 null
             );
        this.FlexGridStorage.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);  //提供数据的方法



    }

    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        StorageManageModel rm = new StorageManageModel();



        result.table = rm.searchStorageInfo3();

        
        return result;
    }


    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid2DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        StorageManageModel rm = new StorageManageModel();
      
        string LSTime = "";
        if (p.extParam.ContainsKey("LSTime"))
        {
            LSTime = p.extParam["LSTime"];
        }
        string LETime = "";
        if (p.extParam.ContainsKey("LETime"))
        {
            LETime = p.extParam["LETime"];
        }
        string Warehousing = "";
        if (p.extParam.ContainsKey("Warehousing"))
        {
            Warehousing = p.extParam["Warehousing"];
        }
        string  DrugName = "";
        if (p.extParam.ContainsKey("DrugName"))
        {
            DrugName = p.extParam["DrugName"];
        }

        result.table = rm.findStorageListInfo(LSTime, LETime, Warehousing, DrugName);
     
        return result;
    }




    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid3DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        StorageManageModel rm = new StorageManageModel();


        string operatenum = "";
        if (p.extParam.ContainsKey("operatenum"))
        {
            operatenum = p.extParam["operatenum"];
        }




        result.table = rm.findstoragedruginfobyopertatenum(operatenum);

        return result;
    }


   
    //作废
    [WebMethod]
    public static string deleteStorageById(string strRowIds)
    {
        string result = "";
        int sdr = 0;
        string[] strRowsId = strRowIds.Split(',');
        for (int i = 0; i < strRowsId.Length; i++)
        {
            //StorageManageModel rm = new StorageManageModel();
           // sdr = rm.deleteStorageInfor(Convert.ToInt16(strRowsId[i]));
        }
        if (sdr == 0)
        {
            result = "0";
        }
        else
        {
            result = "1";
        }

        return result;

    }
    //取消作废

    [WebMethod]
    public static string CloseRecipeById(string strRowIds)
    {
        string result = "";
        int sdr = 0;
        string[] strRowsId = strRowIds.Split(',');
        for (int i = 0; i < strRowsId.Length; i++)
        {
            RecipeModel rm = new RecipeModel();
            sdr = rm.CloseRecipeInfo(Convert.ToInt16(strRowsId[i]));
        }
        if (sdr == 0)
        {
            result = "0";
        }
        else
        {
            result = "1";
        }

        return result;

    }



    [WebMethod]
    public static bool deletedrugtoroominfoById(string strRowIds)
    {
        int a = 0;
        bool result;
        string[] strRowsId = strRowIds.Split(',');
        for (int i = 0; i < strRowsId.Length; i++)
        {
            //RecipeModel rm = new RecipeModel();
            //Bubbleinfo bi = new Bubbleinfo();
            WarehousepharmacyModel whm = new WarehousepharmacyModel();

            //bi.deleteRecipeInfo(Convert.ToInt16(strRowsId[i]));
            a = whm.deletedtempruginfo(strRowsId[i].ToString()); ;
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
    public static int enterStorage(string strRowIds, string Warehouse1, string intoman, string OSingle1, string OSTime1)
    {
        int result = 0;

          System.DateTime currentTime = new System.DateTime();
         currentTime = System.DateTime.Now;//获取当前时间

       //  string currentTime1 = currentTime.ToString();
        //单号
          string now =  currentTime.ToString("yyyyMMddhhmmss");
         string Num = "RK" + now;//单号
      



        string[] strRowsId = strRowIds.Split(',');
       
        for (int i = 0; i < strRowsId.Length; i++)
        {

            StorageManageModel smm = new StorageManageModel();
            result = smm.AddStorage(strRowsId[i].ToString(), Warehouse1, intoman, OSingle1, OSTime1, currentTime, Num);  
           
        }


        return result;

    }
}