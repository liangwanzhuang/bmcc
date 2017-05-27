using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Web.Services;
public partial class view_storeroom_DrugAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.dotNetFlexGrid1.InitConfig(
                           new string[]{
                "title=药品信息列表查询",//标题
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
            
               new dotNetFlexGrid.FieldConfig("id","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ProductBatch","药品批次",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("DrugCode","药品编号",90,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("DrugName","药品名称",90,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("DrugSpecificat","药品规格",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
               new dotNetFlexGrid.FieldConfig("DrugType","药品种类",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Univalent","单价",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("PurUnits","单位",90,false,dotNetFlexGrid.FieldConfigAlign.Center), 
                new dotNetFlexGrid.FieldConfig("Producer","生产商",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ProducingArea","产地",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("PositionNum","货位号",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
               new dotNetFlexGrid.FieldConfig("Mnemonic","助记符",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
              new dotNetFlexGrid.FieldConfig("UpperLimit","上限",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
              new dotNetFlexGrid.FieldConfig("LowerLimit","下限",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
              new dotNetFlexGrid.FieldConfig("Rmarkes","备注1",90,false,dotNetFlexGrid.FieldConfigAlign.Center),     
              new dotNetFlexGrid.FieldConfig("Rmarkes2","备注2",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
              new dotNetFlexGrid.FieldConfig("Rmarkes3","备注3",120,false,dotNetFlexGrid.FieldConfigAlign.Center),

              
            
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



        string medicaltype = "0";
        if (p.extParam.ContainsKey("medicaltype"))
        {
            medicaltype = p.extParam["medicaltype"];
        }


        if (medicaltype == "" || medicaltype == "0")
        {
            medicaltype = "0";
        }



        string medicalname = "0";
        if (p.extParam.ContainsKey("medicalname"))
        {
            medicalname = p.extParam["medicalname"];
        }


        if (medicalname == "" || medicalname == "0")
        {
            medicalname = "0";
        }



        StorageManageModel smm = new StorageManageModel();
        result.table = smm.findStorage(medicaltype, medicalname);

        return result;

    }
    [WebMethod]
    public static bool deleteDrugAdminById(string strRowIds)
    {
        string[] strRows1Id = strRowIds.Split(',');
        for (int i = 0; i < strRows1Id.Length; i++)
        {
            DrugAdminModel rm = new DrugAdminModel();
            rm.deleteDrugAdminInfo(Convert.ToInt16(strRows1Id[i]));
        }

        return true;

    }

}