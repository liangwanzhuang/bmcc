﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data.SqlClient;
using System.Data;

public partial class view_central_DecoctingMonitoring : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            meRoomModel hm = new meRoomModel();
            SqlDataReader sdr = hm.findunitnumbymachine();
            
            unitnum.Items.Add(new ListItem("  全部  ", "0"));
          
            if (sdr != null)
            {
                while (sdr.Read())
                {
                    this.unitnum.Items.Add(new ListItem(sdr["unitnum"].ToString()));

                }
            }
            meRoomModel hm1 = new meRoomModel();

            SqlDataReader sdr1 = hm1.findroomnumbymachine();
            roomnum.Items.Add(new ListItem("  全部  ", "0"));
            if (sdr1 != null)
            {
                while (sdr1.Read())
                {
                    this.roomnum.Items.Add(new ListItem(sdr1["meRoomName"].ToString()));

                }
            }
        }
        this.FlexGridDecoctingMonitoring.InitConfig(
              new string[]{
                "title=煎药机监控信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=false",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=600"//宽度，可为auto或具体px值
            },
         

              new dotNetFlexGrid.FieldConfig[]{
                 new dotNetFlexGrid.FieldConfig("id","序号",90,true,dotNetFlexGrid.FieldConfigAlign.Center),

                 new dotNetFlexGrid.FieldConfig("unitnum","煎药机组编号",90,true,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("machinename","煎药机编号",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                
                 new dotNetFlexGrid.FieldConfig("roomnum","煎药室",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("usingstatus","启用状态",90,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("status","工作状态",90,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("healthstatus","卫生状态",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("disinfectionstatus","消毒状态",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("CurrentTemp","当前温度",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
             
           },
           null
           ,
              null
          );
        this.FlexGridDecoctingMonitoring.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);//提供数据的方法

    }  
    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        meRoomModel rm = new meRoomModel();


        string unitnum = "";
        if (p.extParam.ContainsKey("unitnum"))
        {
            unitnum = p.extParam["unitnum"];
        }

        string roomnum = "";
        if (p.extParam.ContainsKey("roomnum"))
        {
            roomnum = p.extParam["roomnum"];
        }

        result.table = rm.DecoctingMonitoring(unitnum, roomnum);



        return result;
    }
    //导出数据
    protected void Button1_Click(object sender, EventArgs e)
    {
        string unitnum1 = unitnum.Value;
        string roomnum1 = roomnum.Value;
        meRoomModel rm = new meRoomModel();
        DataTable dt = rm.DecoctingMonitoring(unitnum1, roomnum1);

        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now;
        string now = currentTime.ToString("yyyyMMdd");
        CreateExcel(dt, "application/ms-excel", "煎药机监控" + now);
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

        string ls_item = "序号\t 煎药机组编号 \t煎药机编号\t煎药室 \t 启用状态\t工作状态  \t 卫生状态\t消毒状态\t当前温度 \n  ";

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