using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;

public partial class view_system_MedicineRoomMachine : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.FlexGridClearingparty.InitConfig(
            new string[]{
                "title=煎药室信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=400",//高度，可为auto或具体px值
                "width=414"//宽度，可为auto或具体px值
            },
                 new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("id","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),

                new dotNetFlexGrid.FieldConfig("meRoomName","煎药室名称",100,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("meRoomNum","煎药室编号",90 ,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Remarks","备注",120 ,true,dotNetFlexGrid.FieldConfigAlign.Center),
               
               
           },
         null
         ,
            null
        );
        this.FlexGridClearingparty.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(FlexGridClearingpartyDataHandler);  //提供数据的方法
    }

    public dotNetFlexGrid.DataHandlerResult FlexGridClearingpartyDataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际
        meRoomModel rm = new meRoomModel();
        result.table = rm.findmeRoomInfo();
        return result;

    }
    [WebMethod]
    public static bool deleteMeRoomById(string strRowIds)
    {
        int a = 0;
        bool result;
        string[] strRows1Id = strRowIds.Split(',');

        for (int i = 0; i < strRows1Id.Length; i++)
        {

            meRoomModel winfo = new meRoomModel();

            a = winfo.deleteMeRoomInfo(Convert.ToInt32(strRows1Id[i]));

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
}
