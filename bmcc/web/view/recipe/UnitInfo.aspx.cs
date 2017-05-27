using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Web.Services;
using System.Data.SqlClient;

public partial class view_recipe_UnitInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        TeModel tm = new TeModel();
        SqlDataReader sdr1 = tm.getTisaneMachinInfo();
        SqlDataReader sdr2 = tm.getPackingMachineInfo();


        if (sdr1 != null)
        {
            while (sdr1.Read())
            {
                this.TisaneMachine.Items.Add(new ListItem(sdr1["machinename"].ToString(), sdr1["id"].ToString()));
            }
        }


        if (sdr2 != null)
        {
            while (sdr2.Read())
            {
                this.PackMachine.Items.Add(new ListItem(sdr2["machinename"].ToString(), sdr2["id"].ToString()));
            }
        }



        this.FlexGridRecipe.InitConfig(
                                new string[]{
                "title=煎药机信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=585"//宽度，可为auto或具体px值
            },
                                new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("machinename","煎药名称",90,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("roomnum","机房号",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("usingstatus","启用状态",90,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("status","状态",90,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("healthstatus","卫生状态",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("disinfectionstatus","消毒状态",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
             
           },
                             null
                             ,
                                null
                            );
        this.FlexGridRecipe.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(FlexGridRecipeDataHandler);  //提供数据的方法


        this.FlexGridDrug.InitConfig(
             new string[]{
                "title=包装机信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=1000"//宽度，可为auto或具体px值
            },
                new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("machinename","包装机名称",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("roomnum","机房号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("usingstatus","启用状态",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("status","状态",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("healthstatus","卫生状态",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("disinfectionstatus","消毒状态",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
               
           },
          null
          ,
             null
         );
        this.FlexGridDrug.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(FlexGridDrugDataHandler);  //提供数据的方法

    }

    public dotNetFlexGrid.DataHandlerResult FlexGridRecipeDataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际
        // result.table = dotNetFlexGrid.DemoMemoryTable(p.page * 100, p.rp);//调用演示的数据生成函数产生模拟数据


        string TisaneMachine = "0";
        if (p.extParam.ContainsKey("TisaneMachine"))
        {
            TisaneMachine = p.extParam["TisaneMachine"];
        }


       



        TeModel tm = new TeModel();
        result.table = tm.getTisaneMachinInfobyid(Convert.ToInt32(TisaneMachine));


        //如果传递的参数包含排序设置的话，通过DataView.Sort功能模拟进行当页排序
        //if (p.sortname.Length > 0 && p.sortorder.Length > 0)
        //{
        //    System.Data.DataView dv = result.table.DefaultView;
        //    dv.Sort = (p.sortname + " " + p.sortorder);
        //    result.table = dv.ToTable();
        //}
        ////处理默认查询，即Button1_Click中指定的DefaultSearch查询参数
        //if (p.defaultSearch.ContainsKey("String1"))
        //{
        //    System.Data.DataView dv = result.table.DefaultView;
        //    dv.RowFilter = "String1 Like '%" + p.defaultSearch["String1"] + "%'";
        //    result.table = dv.ToTable();
        //}

        ////如果传递的参数包含附加参数的话，再来模拟查询，原谅我真的很懒。
        //if (p.extParam.ContainsKey("String1"))
        //{
        //    System.Data.DataView dv = result.table.DefaultView;
        //    dv.RowFilter = "String1 Like '%" + p.extParam["String1"] + "%'";
        //    result.table = dv.ToTable();
        //}
        ////如果传递的参数包含快速查询参数，则进行快速查询
        //if (p.qop != dotNetFlexGrid.SerchParamConfigOperater.None && p.qtype.Length > 0 && p.query.Length > 0)
        //{
        //    System.Data.DataView dv = result.table.DefaultView;
        //    if (p.qop == dotNetFlexGrid.SerchParamConfigOperater.Like)
        //        dv.RowFilter = p.qtype + " Like '%" + p.query + "%'";
        //    else
        //        dv.RowFilter = p.qtype + " = '" + p.query + "'";
        //    result.table = dv.ToTable();
        //}

        return result;
    }

    public dotNetFlexGrid.DataHandlerResult FlexGridDrugDataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际
        //  result.table = dotNetFlexGrid.DemoMemoryTable(p.page * 100, p.rp);//调用演示的数据生成函数产生模拟数据



        TeModel tm = new TeModel();
       
        string PackMachine = "0";
        if (p.extParam.ContainsKey("PackMachine"))
        {
            PackMachine = p.extParam["PackMachine"];
        }



        result.table = tm.getPackingMachineInfobyid(Convert.ToInt32(PackMachine));


        //如果传递的参数包含排序设置的话，通过DataView.Sort功能模拟进行当页排序
        //if (p.sortname.Length > 0 && p.sortorder.Length > 0)
        //{
        //    System.Data.DataView dv = result.table.DefaultView;
        //    dv.Sort = (p.sortname + " " + p.sortorder);
        //    result.table = dv.ToTable();
        //}
        ////处理默认查询，即Button1_Click中指定的DefaultSearch查询参数
        //if (p.defaultSearch.ContainsKey("String1"))
        //{
        //    System.Data.DataView dv = result.table.DefaultView;
        //    dv.RowFilter = "String1 Like '%" + p.defaultSearch["String1"] + "%'";
        //    result.table = dv.ToTable();
        //}

        ////如果传递的参数包含附加参数的话，再来模拟查询，原谅我真的很懒。
        //if (p.extParam.ContainsKey("String1"))
        //{
        //    System.Data.DataView dv = result.table.DefaultView;
        //    dv.RowFilter = "String1 Like '%" + p.extParam["String1"] + "%'";
        //    result.table = dv.ToTable();
        //}
        ////如果传递的参数包含快速查询参数，则进行快速查询
        //if (p.qop != dotNetFlexGrid.SerchParamConfigOperater.None && p.qtype.Length > 0 && p.query.Length > 0)
        //{
        //    System.Data.DataView dv = result.table.DefaultView;
        //    if (p.qop == dotNetFlexGrid.SerchParamConfigOperater.Like)
        //        dv.RowFilter = p.qtype + " Like '%" + p.query + "%'";
        //    else
        //        dv.RowFilter = p.qtype + " = '" + p.query + "'";
        //    result.table = dv.ToTable();
        //}

        return result;
    }


}

