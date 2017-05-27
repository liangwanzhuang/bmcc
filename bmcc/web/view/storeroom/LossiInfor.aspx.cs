using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Web.Services;
using System.Data.SqlClient;

using SQLDAL;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient;
using SQLDAL;
using System.Collections;
using System.Data;

public partial class view_storeroom_LossiInfor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {



        this.FlexGridLossiInfor.InitConfig(
            new string[]{
                "title=库房报损信息",//标题
                "singleselected=false",//是否单选
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=850"//宽度，可为auto或具体px值
            },
           
            new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("id","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                  new dotNetFlexGrid.FieldConfig("Warehouse","库房名称",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("productbatch","药品批次",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dname","药品名称",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dcode","药品编号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
              
               // new dotNetFlexGrid.FieldConfig("WarehouseNum","库房编号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Type","类型",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                  new dotNetFlexGrid.FieldConfig("lossnum","报损数量",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Per","人员",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("time","时间",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Reason","信息",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("remark","备注",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
               
           },
         null
         ,
            null
        );
        this.FlexGridLossiInfor.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);
    }  //提供数据的方法
    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际
        LossiModel hm1 = new LossiModel();
        var Type = "";

        if (p.extParam.ContainsKey("Type"))
        {
            Type = p.extParam["Type"];
        }

        int pageSize = p.rp;
        result.table = hm1.finLossiInfor(Type);
        

        return result;
    }
    [WebMethod]
    public static bool deleteLossiInforById(string strRowIds)
    {
        int a = 0;
        bool result;
        string[] strRowsId = strRowIds.Split(',');
        for (int i = 0; i < strRowsId.Length; i++)
        {
            //RecipeModel rm = new RecipeModel();
            //Bubbleinfo bi = new Bubbleinfo();
            WarehousepharmacyModel whm = new WarehousepharmacyModel();

            //bi.deleteRecipeInfo(Convert.ToInt16(strRowsId[i]));
            a = whm.deletedlossiInforinfo(strRowsId[i].ToString()); ;
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




    protected void  Button1_Click(object sender, EventArgs e)
{
    string type = Type.Value;
    LossiModel hm1 = new LossiModel();

     // DataBaseLayer db = new DataBaseLayer();
    //    string str = "select * from lossiInfor where type ='" + type + "'";
    DataTable dt = hm1.finLossiInfor(type);
    System.DateTime currentTime = new System.DateTime();
    currentTime = System.DateTime.Now;
    string now = currentTime.ToString("yyyyMMdd");
    CreateExcel(dt, "application/ms-excel", "库房报损信息"+now);
}



    public void CreateExcel(DataTable dt, string FileType, string FileName)
    {
        Response.Clear();
        Response.Charset = "UTF-8";
        Response.Buffer = true;
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls\"");
        Response.ContentType = FileType;
        string colHeaders = string.Empty;
        //string ls_item = string.Empty;

        string ls_item = "序号\t库房名称\t药品批次\t药品名称\t药品编号\t类型\t报损数量\t人员\t时间\t信息\t备注\n";

        DataRow[] myRow = dt.Select();
        int i = 0;
        int cl = dt.Columns.Count;
        foreach (DataRow row in myRow)
        {
            for (i = 0; i < cl; i++)
            {
                if (i == (cl - 1))
                {
                    ls_item += row[i].ToString() + "\n";
                }
                else
                {
                    ls_item += row[i].ToString() + "\t";
                }
            }
            Response.Output.Write(ls_item);
            ls_item = string.Empty;
        }
        Response.Output.Flush();
        Response.End();
    }
}

