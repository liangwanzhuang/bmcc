using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data.SqlClient;
using System.Web.Services;
using System.Data;
using System.IO;

using System.Data.OleDb;
using System.Web.Security;

public partial class view_recipe_DrugDecoctingMachineManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {





        if (!IsPostBack)
        {
            typeofmachine.Items.Add(new ListItem("煎药机", "0"));
            typeofmachine.Items.Add(new ListItem("包装机", "1"));
        }
        this.FlexGridDrugGlobal.InitConfig(
            new string[]{
                "title=煎药机管理",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                  "singleselected=false",//是否单选
                "height=300",//高度，可为auto或具体px值
                "width=500"//宽度，可为auto或具体px值
            },
            new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("id","编号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("mark","类型",60,true,dotNetFlexGrid.FieldConfigAlign.Center),

                new dotNetFlexGrid.FieldConfig("roomnum","煎药室",100,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("unitnum","机组编号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("equipmenttype","设备类型",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("machinename","煎药机编号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("macaddress","mac地址",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("status","状态",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("usingstatus","启用状态",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("healthstatus","卫生状态",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("disinfectionstatus","消毒状态",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("checkman","巡检人员",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("checktime","巡检时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                //new dotNetFlexGrid.FieldConfig("pid","煎药单号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                
            },
         null
         ,
            null
        );
        this.FlexGridDrugGlobal.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);
    }
    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际
        //result.table = dotNetFlexGrid.DemoMemoryTable(p.page * 100, p.rp);//调用演示的数据生成函数产生模拟数据




        string typeofmachine = "3";
        if (p.extParam.ContainsKey("typeofmachine"))
        {
            typeofmachine = p.extParam["typeofmachine"];
        }

        if (typeofmachine == "")
        {
            typeofmachine = "3";
        }





        meRoomModel mrm =new meRoomModel();
        result.table = mrm.findallmachineinfo(typeofmachine);



        dotNetFlexGrid.FieldFormatorHandle proc1 = delegate(DataRow dr)
        {

            int bstatus = Convert.ToInt32(dr["mark"].ToString());
            if (bstatus == 0)
            {
                return "煎药机";
            }
            else
            {
                return "包装机";
            }



        };

        result.FieldFormator.Register("mark", proc1);


        dotNetFlexGrid.FieldFormatorHandle proc = delegate(DataRow dr)
        {
            if (dr["usingstatus"].ToString() == "启用")
            {
                return "<span style='color:red'>启用</span>";
            }
            else
            {
                return "<span style='color:black'>停用</span>";
            }



        };
        result.FieldFormator.Register("usingstatus", proc);









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



    [WebMethod]
    public static bool deletemachineById(string strRowIds)
    {
        int a = 0;
        bool result;
        string[] strRows1Id = strRowIds.Split(',');

        for (int i = 0; i < strRows1Id.Length; i++)
        {

            meRoomModel rm = new meRoomModel();

            a = rm.deletemachineinfo(strRows1Id[i]);

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
    [WebMethod]
    public static bool updatewarninginfoById(string strRowIds)
    {

        int a = 0;
        bool result;

        string[] strRowsId = strRowIds.Split(',');
        for (int i = 0; i < strRowsId.Length; i++)
        {
            //RecipeModel rm = new RecipeModel();
            //Bubbleinfo bi = new Bubbleinfo();
            //bi.deleteRecipeInfo(Convert.ToInt16(strRowsId[i]));
            meRoomModel rm = new meRoomModel();

            a = rm.updatewarningstatus(strRowsId[i]);
            // a = hm.deletewarninginfo(strRowsId[i]);
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