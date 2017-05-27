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

public partial class view_system_Backgdset : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

      if (!IsPostBack)
        {

      
        RecipeModel rm = new RecipeModel();
        SqlDataReader sdr = rm.findisneedcheckstatus();

        if (sdr.Read())
        {
            string status = sdr["isneedcheck"].ToString();
            if (status == "0")
            {
               
               
                this.checkbox1.Checked = true;
                this.checkbox2.Checked = false;
            }
            else
            {
                this.checkbox2.Checked = true;
                this.checkbox1.Checked = false;
            }
        }

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
                "width=700"//宽度，可为auto或具体px值
            },
                new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("id","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hospitalname","医院名称",87,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("checkwarning","审核预警时间（单位min）",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("adjustwarning","调剂预警时间（单位min）",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("recheckwarning","复核预警时间（单位min）",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("bubblewarning","泡药预警时间（单位min）",60,false,dotNetFlexGrid.FieldConfigAlign.Center),  
                new dotNetFlexGrid.FieldConfig("tisanewarning","煎药预警时间（单位min）",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("packwarning","包装预警时间（单位min）",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("deliverwarning","发货预警时间（单位min）",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("status","开启状态",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
           },
                null
                ,
                   null
               );
        this.FlexGrid1.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(FlexGrid1DataHandler);  //提供数据的方法

        this.DotNetFlexGrid1.InitConfig(
                   new string[]{
                "title=医院预警设置",//标题
                 "singleselected=false",//是否单选
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=700"//宽度，可为auto或具体px值
            },
                new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("id","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hospitalname","医院名称",87,true,dotNetFlexGrid.FieldConfigAlign.Center),
                
                new dotNetFlexGrid.FieldConfig("adjustwarning","调剂预警时间（单位min）",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("recheckwarning","复核预警时间（单位min）",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("bubblewarning","泡药预警时间（单位min）",60,false,dotNetFlexGrid.FieldConfigAlign.Center),  
                new dotNetFlexGrid.FieldConfig("tisanewarning","煎药预警时间（单位min）",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("packwarning","包装预警时间（单位min）",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("deliverwarning","发货预警时间（单位min）",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("status","开启状态",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
           },
                null
                ,
                   null
               );
        this.DotNetFlexGrid1.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(FlexGrid1DataHandler2);  //提供数据的方法

        this.DotNetFlexGrid2.InitConfig(
                  new string[]{
                "title=医院屏显设置",//标题
                 "singleselected=false",//是否单选
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=700"//宽度，可为auto或具体px值
            },
               new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("ID","序号",121,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hname","医院名称",170,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("DrugDisplayState","泡药屏显状态",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ChineseDisplayState","煎药屏显状态",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("DrugSendDisplayState","发药屏显状态",120,true,dotNetFlexGrid.FieldConfigAlign.Center),
               
           },
               null
               ,
                  null
              );
        this.DotNetFlexGrid2.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(FlexGrid2DataHandler);  //提供数据的方法
    }

    public dotNetFlexGrid.DataHandlerResult FlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际
       // result.table = dotNetFlexGrid.DemoMemoryTable(p.page * 100, p.rp);
        HospitalModel hm = new HospitalModel();
        result.table = hm.findwarningtime("0");



        dotNetFlexGrid.FieldFormatorHandle proc = delegate(DataRow dr)
        {
            if (dr["status"].ToString() == "1")
            {
                return "<span style='color:red'>开启</span>";
            }
            else
            {
                return "<span style='color:black'>关闭</span>";
            }



        };
        result.FieldFormator.Register("status", proc);

        return result;


    }
    public dotNetFlexGrid.DataHandlerResult FlexGrid1DataHandler2(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际
        // result.table = dotNetFlexGrid.DemoMemoryTable(p.page * 100, p.rp);
        HospitalModel hm = new HospitalModel();
        result.table = hm.findwarningtime("1");



        dotNetFlexGrid.FieldFormatorHandle proc = delegate(DataRow dr)
        {
            if (dr["status"].ToString() == "1")
            {
                return "<span style='color:red'>开启</span>";
            }
            else
            {
                return "<span style='color:black'>关闭</span>";
            }



        };
        result.FieldFormator.Register("status", proc);

        return result;


    }
    /// <summary>
    /// 大屏显示
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public dotNetFlexGrid.DataHandlerResult FlexGrid2DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际
        // result.table = dotNetFlexGrid.DemoMemoryTable(p.page * 100, p.rp);
        HospitalModel hm = new HospitalModel();
        result.table = hm.findInfo();
        dotNetFlexGrid.FieldFormatorHandle proc = delegate(DataRow dr)
        {
            if (dr["DrugDisplayState"].ToString() == "0")
            {
                return "<span style='color:red'>开启</span>";
            }
            else
            {
                return "关闭";
            }

        };
        result.FieldFormator.Register("DrugDisplayState", proc);
         dotNetFlexGrid.FieldFormatorHandle proc1 = delegate(DataRow dr)
        {
            if (dr["ChineseDisplayState"].ToString() == "0")
            {
                return "<span style='color:red'>开启</span>";
            }
            else
            {
                return "关闭";
            }

        };
         result.FieldFormator.Register("ChineseDisplayState", proc1);
         dotNetFlexGrid.FieldFormatorHandle proc2= delegate(DataRow dr)
        {
            if (dr["DrugSendDisplayState"].ToString() == "0")
            {
                return "<span style='color:red'>开启</span>";
            }
            else
            {
                return "关闭";
            }

        };
         result.FieldFormator.Register("DrugSendDisplayState", proc2);
        return result;


    }


    [WebMethod]
    public static bool deletewarninginfoById(string strRowIds)
    {

        int a = 0;
        bool result;
        string[] strRowsId = strRowIds.Split(',');
        for (int i = 0; i < strRowsId.Length; i++)
        {
            //RecipeModel rm = new RecipeModel();
            //Bubbleinfo bi = new Bubbleinfo();
            //bi.deleteRecipeInfo(Convert.ToInt16(strRowsId[i]));
            HospitalModel hm = new HospitalModel();


            a = hm.deletewarninginfo(strRowsId[i]);
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
            HospitalModel hm = new HospitalModel();

            a = hm.updatewarningstatus(strRowsId[i]);
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
    //泡药
     [WebMethod]
     public static bool updateDrugDisplayStateById(string strRowIds)
     {

         int a = 0;
         bool result;

         string[] strRowsId = strRowIds.Split(',');
         for (int i = 0; i < strRowsId.Length; i++)
         {
             
             HospitalModel hm = new HospitalModel();
             a = hm.updateDrugDisplayState(strRowsId[i]);
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
    //煎药
     [WebMethod]
     public static bool updateChineseDisplayStateById(string strRowIds)
     {

         int a = 0;
         bool result;

         string[] strRowsId = strRowIds.Split(',');
         for (int i = 0; i < strRowsId.Length; i++)
         {
             HospitalModel hm = new HospitalModel();
             a = hm.updateChineseDisplayState(strRowsId[i]);
           
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
    //发药
     [WebMethod]
     public static bool updateDrugSendDisplayStateById(string strRowIds)
     {

         int a = 0;
         bool result;

         string[] strRowsId = strRowIds.Split(',');
         for (int i = 0; i < strRowsId.Length; i++)
         {
             
             HospitalModel hm = new HospitalModel();
             a = hm.updateDrugSendDisplayState(strRowsId[i]);
            
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
     public static int isneedcheck(string id)
     {

         
        
         RecipeModel rm = new RecipeModel();
         int result = rm.isneedcheck(id);


        return result;
         
     }

}
