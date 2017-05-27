using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

public partial class view_system_Hospital : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        HospitalModel hm = new HospitalModel();
        SqlDataReader sdr = hm.findHospitalAll();

        int hid = 0;
        hname.Items.Add(new ListItem("全部", "0"));
        if (sdr != null)
        {
            while (sdr.Read())
            {
                if (hid == 0)
                {
                    hid = Convert.ToInt32(sdr["ID"].ToString());
                }
                this.hname.Items.Add(new ListItem(sdr["Hname"].ToString(), sdr["ID"].ToString()));

            }
        }

        this.FlexGridHospital.InitConfig(
            new string[]{
                "title=医院信息",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=500"//宽度，可为auto或具体px值
            },
            new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("id","ID",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hnum","医院编码",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hname","医院名称",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Hshortname","医院简称",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("contacter","联系人",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("phone","联系电话",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("address","地址",80,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("pricetype","价格类型",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                //new dotNetFlexGrid.FieldConfig("settler","结算方",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
           },
         null
         ,
            null
        );
        this.FlexGridHospital.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(FlexGridHospitalDataHandler);  //提供数据的方法
    }


    public dotNetFlexGrid.DataHandlerResult FlexGridHospitalDataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        HospitalHandler hhandler = new HospitalHandler();
        string hname = "0";
        if (p.extParam.ContainsKey("hname"))
        {
            hname = p.extParam["hname"];
        }
        string hnum = "0";
        if (p.extParam.ContainsKey("hnum"))
        {
            hnum = p.extParam["hnum"];
        }


        result.table = hhandler.SearchHospital(hname, hnum);

        return result;
    }
    [WebMethod]
    public static string getNumByHospitalId(string hname)
    {
        HospitalModel hm = new HospitalModel();
        DataTable dt = hm.findNumById(hname);

        string data = "";
        data = dt.Rows[0][0].ToString();



        return data;

    }
    [WebMethod]
    public static bool deleteHospitalById(string strRowIds)
    {
        string[] strRows1Id = strRowIds.Split(',');
        for (int i = 0; i < strRows1Id.Length; i++)
        {
            HospitalModel rm = new HospitalModel();
            rm.deleteHospitalById(Convert.ToInt16(strRows1Id[i]));
        }

        return true;

    }
}