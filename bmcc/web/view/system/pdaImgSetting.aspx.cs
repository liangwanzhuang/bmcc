using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ModelInfo;
using SQLDAL;



using System.Data.SqlClient;

using System.Web.UI.HtmlControls;
using System.Web.Script.Services;
using System.Web.Services;





using System.Data;
using System.Collections;

public partial class view_system_pdaImgSetting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


           

        }


        this.FlexGrid1.InitConfig(
                   new string[]{
                "title=医院预警设置",//标题
                 "singleselected=false",//是否单选
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=505"//宽度，可为auto或具体px值
            },
                new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("id","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("tiaoji","调剂",87,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("fuhe","复核",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("paoyao","泡药",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("jianyao","煎药",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("baozhuang","包装",60,false,dotNetFlexGrid.FieldConfigAlign.Center),  
                new dotNetFlexGrid.FieldConfig("fahuo","发货",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                
           },
                null
                ,
                   null
               );
        this.FlexGrid1.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(FlexGrid1DataHandler);  //提供数据的方法

        

    }

    public dotNetFlexGrid.DataHandlerResult FlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际
        // result.table = dotNetFlexGrid.DemoMemoryTable(p.page * 100, p.rp);
        HospitalModel hm = new HospitalModel();
        result.table = hm.findPdaImgSwitchInfo();



        dotNetFlexGrid.FieldFormatorHandle tiaoji = delegate(DataRow dr)
        {
            if (dr["tiaoji"].ToString() == "1")
            {
                return "<span style='color:red'>开启</span>";
            }
            else
            {
                return "<span style='color:black'>关闭</span>";
            }



        };
        dotNetFlexGrid.FieldFormatorHandle fuhe = delegate(DataRow dr)
        {
            if (dr["fuhe"].ToString() == "1")
            {
                return "<span style='color:red'>开启</span>";
            }
            else
            {
                return "<span style='color:black'>关闭</span>";
            }



        };
        dotNetFlexGrid.FieldFormatorHandle paoyao = delegate(DataRow dr)
        {
            if (dr["paoyao"].ToString() == "1")
            {
                return "<span style='color:red'>开启</span>";
            }
            else
            {
                return "<span style='color:black'>关闭</span>";
            }



        };
        dotNetFlexGrid.FieldFormatorHandle jianyao = delegate(DataRow dr)
        {
            if (dr["jianyao"].ToString() == "1")
            {
                return "<span style='color:red'>开启</span>";
            }
            else
            {
                return "<span style='color:black'>关闭</span>";
            }



        };
        dotNetFlexGrid.FieldFormatorHandle baozhuang = delegate(DataRow dr)
        {
            if (dr["baozhuang"].ToString() == "1")
            {
                return "<span style='color:red'>开启</span>";
            }
            else
            {
                return "<span style='color:black'>关闭</span>";
            }



        };
        dotNetFlexGrid.FieldFormatorHandle fahuo = delegate(DataRow dr)
        {
            if (dr["fahuo"].ToString() == "1")
            {
                return "<span style='color:red'>开启</span>";
            }
            else
            {
                return "<span style='color:black'>关闭</span>";
            }



        };
        result.FieldFormator.Register("tiaoji", tiaoji);
        result.FieldFormator.Register("fuhe", fuhe);
        result.FieldFormator.Register("paoyao", paoyao);
        result.FieldFormator.Register("jianyao", jianyao);
        result.FieldFormator.Register("baozhuang", baozhuang);
        result.FieldFormator.Register("fahuo", fahuo);
        return result;


    }

}