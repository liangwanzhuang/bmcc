using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using SQLDAL;
using System.Data;

public partial class view_recipe_DrugDecoctingMachineDistribution : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.FlexGridTisaneClass.InitConfig(
            new string[]{
                "title=煎药机组分配信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=520"//宽度，可为auto或具体px值
            },
            new dotNetFlexGrid.FieldConfig[]{
  

                new dotNetFlexGrid.FieldConfig("id","煎药单号",80,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ps","处方号",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("machinename","煎药机组号",160,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("bs","处方状态",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
             


           },
         null
         ,
            null
        );
        this.FlexGridTisaneClass.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);
        
    }
    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际




      
        string pspnum = "";
        if (p.extParam.ContainsKey("PspNum"))
        {
            pspnum = p.extParam["PspNum"];
        }




     TeModel tm = new TeModel() ;

        result.table = tm.searchTisaneClass(pspnum);//调用演示的数据生成函数产生模拟数据
        dotNetFlexGrid.FieldFormatorHandle proca = delegate(DataRow dr)
        {
            string z = "";
            if (dr["bs"].ToString() == "")
            {
                String az = dr["bs"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                int az = Convert.ToInt32(dr["bs"].ToString());

                if (az == 1)
                {
                    z = "泡药完成";
                }
                
            }
            return z;

        };
        result.FieldFormator.Register("bs", proca);
        return result;
    }







    protected void btnSearchClick(object sender, EventArgs e)
    {
      

    }
    
}