using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ModelInfo;

public partial class view_reconciliation_CheckList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

     this.FlexGridCheckList.InitConfig(
            new string[]{
                "title=对账信息",//标题
                "singleselected=true",//是否单选
                "striped=true",//是否显示行交替色
                "selectedonclick=false",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=940"//宽度，可为auto或具体px值
            },
         //结算方、账单生成时间、对账单号、对账时间、对账人、金额（账单中所包含的处方信息下的药品信息计算得出）、代煎费（系统中可设置，代煎费用*处方数量）、备注

            new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("ID","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Clearing","结算方",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("now","账单生成时间",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("CheckNum","对账单号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ReconciliaT","对账时间",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ReconciliaPer","对账人",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
               new dotNetFlexGrid.FieldConfig("money","金额",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("GeneraDecoc","代煎费",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("State","账单状态",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Remarks","备注",80,false,dotNetFlexGrid.FieldConfigAlign.Center),
              
           },
         null
         ,
            null
        );
        this.FlexGridCheckList.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);
    }  //提供数据的方法
    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        RecipeModel rm = new RecipeModel();

        string Clearing = "";
        if (p.extParam.ContainsKey("Clearing"))
        {
            Clearing = p.extParam["Clearing"];
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
        string ClearingS = "";
        if (p.extParam.ContainsKey("ClearingS"))
        {
            ClearingS = p.extParam["ClearingS"];
        }
        result.table = rm.CheckListInfo(Clearing, ClearingS, STime, ETime);

        
  
      
        dotNetFlexGrid.FieldFormatorHandle proc61 = delegate(DataRow dr)
        {

            int a = Convert.ToInt32(dr["State"].ToString());
            if (a == 1)
            {
                return "已结算";
            }
            else
            {
                return "未结算";
            }
        };

        result.FieldFormator.Register("State", proc61);
        return result;
    }

}