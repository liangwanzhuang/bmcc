using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;

using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
public partial class view_system_Authority : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.FlexGridAuthority.InitConfig(
            new string[]{
                "title=权限信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=500"//宽度，可为auto或具体px值
            },
            new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("id","ID",60,true,dotNetFlexGrid.FieldConfigAlign.Center,false,true,false),
                new dotNetFlexGrid.FieldConfig("role","角色",109,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("limits","权限",377 ,true,dotNetFlexGrid.FieldConfigAlign.Center),   
           },
         null
         ,
            null
        );
        this.FlexGridAuthority.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(FlexGridClearingpartyDataHandler);  //提供数据的方法
    }

    public dotNetFlexGrid.DataHandlerResult FlexGridClearingpartyDataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际
        string EName = "0";
        if (p.extParam.ContainsKey("EName"))
        {
            EName = p.extParam["EName"];
        }



        if (EName == "0" || EName == "")
        {
            EName = "0";
        }





        EmployeeHandler eh = new EmployeeHandler();
        result.table = eh.employeelimits(EName);

        dotNetFlexGrid.FieldFormatorHandle proc3 = delegate(DataRow dr)
        {

            int a = Convert.ToInt32(dr["role"].ToString());
            if (a == 0)
            {
                return "管理员";
            }
            else if (a == 1)
            {
                return "调剂人员";
            }
            else if (a == 2)
            {
                return "复核人员";
            }
            else if (a == 3)
            {
                return "泡药人员";
            }

            else if (a == 4)
            {
                return "煎药人员";
            }
            else if (a == 5)
            {
                return "包装人员";
            }

            else if (a == 6)
            {
                return "发货人员";
            }
            else if (a == 7)
            {
                return "接方人员";
            }
            else if (a == 8)
            {
                return "配方人员";
            }
            else if (a == 9)
            {
                return "医院人员";
            }
            else if (a == 10)
            {
                return "医院登录人员";
            }
            else
            {
                return "无";
            }



        };
        result.FieldFormator.Register("role", proc3);




        //result.table = dotNetFlexGrid.DemoMemoryTable(p.page * 100, p.rp);//调用演示的数据生成函数产生模拟数据

        return result;

    }

    }
