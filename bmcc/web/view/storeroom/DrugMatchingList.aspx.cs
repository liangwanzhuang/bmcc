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

public partial class view_storeroom_DrugMatchingList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {


            HospitalModel hm = new HospitalModel();
            SqlDataReader sdr = hm.findHospitalAll();
            int hid = 0;
            if (sdr != null)
            {
                this.hospitalname.Items.Add(new ListItem("全部", "0"));
                while (sdr.Read())
                {
                    if (hid == 0)
                    {
                        hid = Convert.ToInt32(sdr["ID"].ToString());
                    }
                    this.hospitalname.Items.Add(new ListItem(sdr["Hname"].ToString(), sdr["ID"].ToString()));

                }
            }

        }



        this.dotNetFlexGrid1.InitConfig(
                                        new string[]{
                "title=药品匹配列表查询",//标题
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                 "showcheckbox=true",//显示复选框
              "singleselected=false",//是否单选
                "height=300",//高度，可为auto或具体px值
                "width=600"//宽度，可为auto或具体px值
            },
            // 序号、委托单号、医院编号、医院名称、处方号、煎药方式、姓名、性别、年龄、电话、地址、科室、病区号、
            //病房号、病床号、诊断结果、剂数、服用方式、次数、包装量、服用方法、煎药方案、一煎时间、二煎时间、
            //浸泡加水量、浸泡时间、标签数量、备注信息、医生、医生脚注、取药时间、取药序号、下单时间、当前状态、
            //操作时间、操作人员、配送公司、配送地址、联系电话、快件类型

             new dotNetFlexGrid.FieldConfig[]{
             new dotNetFlexGrid.FieldConfig("id","序号",90,true,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("hospitalname","医院",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("hospitalnum","医院编号",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("drugNum","医院药品编号",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("drugName","医院药品名",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("drugAlias","饮片厂药品编号",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("drugDetailedName","饮片厂药品名",120,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("positionNum","货位号",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("producingarea","产地",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
             new dotNetFlexGrid.FieldConfig("drugspecificat","规格",170,false,dotNetFlexGrid.FieldConfigAlign.Center),
  
           },
                                     null
                                     ,
                                        null
                                    );
        this.dotNetFlexGrid1.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);
    }


    //提供数据的方法
    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际



        string medicalname = "0";
        if (p.extParam.ContainsKey("medicalname"))
        {
            medicalname = p.extParam["medicalname"];
        }


        if (medicalname == "" || medicalname == "0")
        {
            medicalname = "0";
        }



        string hospitalname = "0";
        if (p.extParam.ContainsKey("hospitalname"))
        {
            hospitalname = p.extParam["hospitalname"];
        }


        if (hospitalname == "" || hospitalname == "0")
        {
            hospitalname = "0";
        }



        string hospitaldrugname = "";
        if (p.extParam.ContainsKey("hospitaldrugname"))
        {
            hospitaldrugname = p.extParam["hospitaldrugname"];
        }


        if (hospitaldrugname == "" || hospitaldrugname == "0")
        {
            hospitaldrugname = "0";
        }


        StorageManageModel smm = new StorageManageModel();
        result.table = smm.finddrugmatchdone(medicalname, hospitalname, hospitaldrugname);

        return result;

    }



    [WebMethod]
    public static int deletedrugmatchinginfo(string strRowIds)
    {

        int end = 0;
        string[] strRows1Id = strRowIds.Split(',');
        for (int i = 0; i < strRows1Id.Length; i++)
        {
            DrugAdminModel rm = new DrugAdminModel();
            end = rm.deleteDrugmatchingInfo(Convert.ToInt16(strRows1Id[i]));
        }

        return end;

    }


}