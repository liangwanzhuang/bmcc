using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data.SqlClient;
using System.Web.Services;

public partial class view_system_Recipient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack){
            RecipientModel rm = new RecipientModel();
            SqlDataReader sd = rm.finRecipienallinfo();
            ClearPName.Items.Add(new ListItem ("全部","0"));
            if( sd != null){
            while(sd.Read()){
                this.ClearPName.Items.Add(new ListItem(sd["ClearPName"].ToString()));
            }
            
            }
        
        }


        this.FlexGridRecipient.InitConfig(
            new string[]{
                "title=收件人信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=505"//宽度，可为auto或具体px值
            },
            new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("ClearPName","收件人名称",80,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Telephone","联系电话",80,true,dotNetFlexGrid.FieldConfigAlign.Center),
               
                new dotNetFlexGrid.FieldConfig("Address","地址",170,true,dotNetFlexGrid.FieldConfigAlign.Center),
            
                new dotNetFlexGrid.FieldConfig("Remarks","备注",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
               
           },
         null
         ,
            null
        );
 this.FlexGridRecipient.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(FlexGridClearingpartyDataHandler);  //提供数据的方法
    }

    public dotNetFlexGrid.DataHandlerResult FlexGridClearingpartyDataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际
        RecipientModel rm= new RecipientModel();
        string ClearPName = "0";
        if (p.extParam.ContainsKey("ClearPName"))
        {
            ClearPName = p.extParam["ClearPName"];
        }
        result.table = rm.finRecipientInfo(ClearPName);
       

        return result;

    }

    [WebMethod]
    public static bool deleteRecipientById(string strRowIds)
    {
        
        string[] strRows1Id = strRowIds.Split(',');
        for (int i = 0; i < strRows1Id.Length; i++)
        {
            RecipientModel rm = new RecipientModel();
            rm.deleteRPInfoByid(Convert.ToInt16( strRowIds));
        }

        return true;

       
    
    }
    
   
}


