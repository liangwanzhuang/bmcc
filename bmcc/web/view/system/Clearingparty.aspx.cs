using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Web.Services;
using System.Data.SqlClient;

public partial class view_system_Clearingparty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            ClearingpartyModel hm = new ClearingpartyModel();
            SqlDataReader sdr = hm.findClearingpartyAll();

            ClearPName.Items.Add(new ListItem("全部", "0"));
            if (sdr != null)
            {
                while (sdr.Read())
                {
                    this.ClearPName.Items.Add(new ListItem(sdr["ClearPName"].ToString(), sdr["ID"].ToString()));

                }
            }

        }
        this.FlexGridClearingparty.InitConfig(
            new string[]{
                "title=结算方信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=500"//宽度，可为auto或具体px值
            },
            new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("id","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),

                new dotNetFlexGrid.FieldConfig("ClearPName","结算方名称",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("GenDecoct","代煎费",60,true,dotNetFlexGrid.FieldConfigAlign.Center),

                new dotNetFlexGrid.FieldConfig("ConPerson","联系人",80,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ConPhone","联系电话",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Address","地址",120,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("PerSetInformation","查看权限",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Remarks","备注",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
               
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
        ClearingpartyModel rm = new ClearingpartyModel();
        string ClearPName = "0";
        if (p.extParam.ContainsKey("ClearPName"))
        {
            ClearPName = p.extParam["ClearPName"];
        }
       

        //result.table = rm.findRecipeInfo(11, "111");
        // result.table = rm.findPackingInfo(Fpactate, Pacpersonnel, PacTime);

        result.table = rm.findClearingpartyInfo(Convert.ToInt32(ClearPName));
      /*  ClearingpartyHandler chandler = new ClearingpartyHandler();
        result.table = chandler.SearchClearingparty();*/

        return result;

    }

    protected void Search_onclick(object sender, EventArgs e)
    {


    }

     protected void btn_Click(object sender, EventArgs e)
    {
        // this.TextBox1.Text = "voodooer";
    }
    [WebMethod]
    public static bool deleteClearingpartyById(string strRowIds)
    {
        string[] strRows1Id = strRowIds.Split(',');
        for (int i = 0; i < strRows1Id.Length; i++)
        {
            ClearingpartyModel rm = new ClearingpartyModel();
            rm.deleteClearingpartyInfo(Convert.ToInt16(strRows1Id[i]));
        }

        return true;

    }

   
}


