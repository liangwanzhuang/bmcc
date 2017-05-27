using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Web.Services;

public partial class view_system_Warehousepharmacy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
        this.dotNetFlexGrid3.InitConfig(
              new string[]{
                "title=库房药房信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=450",//高度，可为auto或具体px值
                "width=495"//宽度，可为auto或具体px值
            },

             new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("id","编号",90,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("WName","名称",120,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("WareNum","仓库编号",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Type","类型",120,true,dotNetFlexGrid.FieldConfigAlign.Center),
                
               
              
           },
           null
           ,
              null
          );
        this.dotNetFlexGrid3.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);  //提供数据的方法

        
    }

    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际



        WarehousepharmacyModel rm = new WarehousepharmacyModel();
         string Type = "0";
         if (p.extParam.ContainsKey("Type"))
         {
             Type = p.extParam["Type"];
         }

         result.table = rm.findWarehousepharmacyModelInfo(Type); 

        return result;
    }

    [WebMethod]
    public static bool deleteWarehousepharmacyById(string strRowIds)
    {
        string[] strRows1Id = strRowIds.Split(',');
        for (int i = 0; i < strRows1Id.Length; i++)
        {
            WarehousepharmacyModel rm = new WarehousepharmacyModel();
            rm.deleteWarehousepharmacyInfo(Convert.ToInt16(strRows1Id[i]));
        }

        return true;

    }
}