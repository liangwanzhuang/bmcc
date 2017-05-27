using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLDAL;
using System.Data.SqlClient;
using System.Data;
using ModelInfo;


public partial class view_storeroom_MedicineStorageManageAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            WarehousepharmacyModel whm = new WarehousepharmacyModel();
            SqlDataReader sdr = whm.findallWarehouse();


            while (sdr.Read())
            {
                from.Items.Add(new ListItem(sdr["WName"].ToString(), sdr["id"].ToString()));
            }

            SqlDataReader sdr2 = whm.findpartWarehouse();

            while (sdr2.Read())
            {
                into.Items.Add(new ListItem(sdr2["WName"].ToString(), sdr2["id"].ToString()));
            }
        }






        this.dotNetFlexGrid1.InitConfig(
                                 new string[]{
                "title=药品信息添加",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=1000"//宽度，可为auto或具体px值
            },
            // 序号、委托单号、医院编号、医院名称、处方号、煎药方式、姓名、性别、年龄、电话、地址、科室、病区号、
            //病房号、病床号、诊断结果、剂数、服用方式、次数、包装量、服用方法、煎药方案、一煎时间、二煎时间、
            //浸泡加水量、浸泡时间、标签数量、备注信息、医生、医生脚注、取药时间、取药序号、下单时间、当前状态、
            //操作时间、操作人员、配送公司、配送地址、联系电话、快件类型

                                 new dotNetFlexGrid.FieldConfig[]{
             new dotNetFlexGrid.FieldConfig("id","序号",90,true,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("qualitytime","产品批次",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("DrugCode","药品编号",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("DrugName","药品名称",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("pspweight","药品规格",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("DrugType","药品种类",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("deviation","产地",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("deviationpercent","厂商",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("docase","单价",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("taste","基本单位",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("actualtaste","货位号",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("matchman","助记符",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("checkman","上限",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("remark","下限",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("tie1","备注1",120,false,dotNetFlexGrid.FieldConfigAlign.Center),        
             new dotNetFlexGrid.FieldConfig("tie2","备注2",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("tie3","备注3",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
          
            
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






        string fromid = "0";
        if (p.extParam.ContainsKey("fromid"))
        {
            fromid = p.extParam["fromid"];
        }


        if (fromid == "" || fromid == "0")
        {
            fromid = "0";
        }



        StorageManageModel smm = new StorageManageModel();
        result.table = smm.findStoragebyfromid(fromid);

        return result;

    }

}