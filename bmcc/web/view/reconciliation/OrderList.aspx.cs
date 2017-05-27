using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data;
using System.Data.SqlClient;

public partial class view_reconciliation_OrderList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        HospitalModel hm = new HospitalModel();
        SqlDataReader sdr = hm.findHospitalAll();
        if (sdr != null)
        {
            while (sdr.Read())
            {
                this.hospitalSelect.Items.Add(new ListItem(sdr["Hname"].ToString(), sdr["ID"].ToString()));

            }

        }

        this.FlexGridOrderList.InitConfig(
               new string[]{
                "title=订单信息",//标题
                "singleselected=false",//是否单选
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=false",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=860"//宽度，可为auto或具体px值
            },


               new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("ID","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ordertime","下单时间",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dotime","接收时间",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
               
                new dotNetFlexGrid.FieldConfig("Pspnum","处方号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hnum","医院编号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                  new dotNetFlexGrid.FieldConfig("hname","医院名称",110,false,dotNetFlexGrid.FieldConfigAlign.Center),
                  new dotNetFlexGrid.FieldConfig("name","患者姓名",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dose","贴数",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("st","状态",80,false,dotNetFlexGrid.FieldConfigAlign.Center),
               new dotNetFlexGrid.FieldConfig("printstatus","打印状态",90,false,dotNetFlexGrid.FieldConfigAlign.Center),
                
                
            

        
           },
            null
            ,
               null
           );
        this.FlexGridOrderList.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);
    }  //提供数据的方法
    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        RecipeModel rm = new RecipeModel();
        string per = "";
        if (p.extParam.ContainsKey("per"))
        {
            per = p.extParam["per"];
        }
        string STime = "";
        if (p.extParam.ContainsKey("STime"))
        {
            STime = p.extParam["STime"];
        }
        string ETime = "";
        if (p.extParam.ContainsKey("ETime"))
        {
            ETime = p.extParam["ETime"];
        }
        string hospitalId = "0";
        if (p.extParam.ContainsKey("hospitalId"))
        {
            hospitalId = p.extParam["hospitalId"];
        }


        result.table = rm.OrderListInfo(per, STime, ETime, Convert.ToInt32(hospitalId));
        dotNetFlexGrid.FieldFormatorHandle proc6 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["st"].ToString() == "")
             {
                 String az = dr["st"].ToString();
                 az = "3";
                 if (az == "3")
                 {
                     z = "无";

                 }
             }
             else
             {
                 int a = Convert.ToInt32(dr["st"].ToString());
                 if (a == 1)
                 {
                     z = "已结算";
                 }
                 else
                 {
                     z = "未结算";
                 }
             }
            return z;
        };

        result.FieldFormator.Register("st", proc6);
        dotNetFlexGrid.FieldFormatorHandle proca2 = delegate(DataRow dr)
        {
            string z = "";
            if (dr["printstatus"].ToString() == "")
            {
                String az = dr["printstatus"].ToString();
                az = "3";
                if (az == "3")
                {
                    z = "无";

                }
            }
            else
            {
                int az = Convert.ToInt32(dr["printstatus"].ToString());

                if (az == 1)
                {
                    z = "已打印";
                }
                if (az == 0)
                {
                    z = "未打印";
                }
            }
            return z;

        };
        result.FieldFormator.Register("printstatus", proca2);
        dotNetFlexGrid.FieldFormatorHandle proc3 = delegate(DataRow dr)
        {

            int b = Convert.ToInt32(dr["decscheme"].ToString());
            if (b == 1)
            {
                return "微压（密闭）解表（15min）";
            }
            else if (b == 2)
            {
                return "微压（密闭）汤药（15min）";
            }
            else if (b == 3) { return "微压（密闭）补药（15min）"; }
            else if (b == 4) { return "常压解表（10min，10min）"; }
            else if (b == 5) { return "常压汤药（20min，15min）"; }
            else if (b == 6) { return "常压补药（25min，20min）"; }
            else if (b == 20) { return "先煎解表（10min，10min，10min）"; }
            else if (b == 21) { return "先煎汤药（10min，20min，15min）"; }
            else if (b == 22) { return "先煎补药（10min，25min，20min）"; }
            else if (b == 36) { return "后下解表（10min（3：7），10min）"; }
            else if (b == 37) { return "后下汤药（20min（13：7），15min）"; }
            else if (b == 38) { return "后下补药（25min（18：7），20min）"; }
            else if (b == 81) { return "微压自定义"; }
            else if (b == 82) { return "常压自定义"; }
            else if (b == 83) { return "先煎自定义"; }
            else { return "后下自定义"; }
        };
        result.FieldFormator.Register("decscheme", proc3);

        dotNetFlexGrid.FieldFormatorHandle proc4 = delegate(DataRow dr)
        {

            int a = Convert.ToInt32(dr["decmothed"].ToString());
            if (a == 1)
            {
                return "先煎";
            }
            else if (a == 2)
            {
                return "后下";
            }
            else
            {
                return "加糖加蜜";
            }




        };
        result.FieldFormator.Register("decmothed", proc4);
        dotNetFlexGrid.FieldFormatorHandle proc61 = delegate(DataRow dr)
        {

            int a = Convert.ToInt32(dr["takeway"].ToString());
            if (a == 1)
            {
                return "水煎餐后";
            }
            else
            {
                return "";
            }




        };
        result.FieldFormator.Register("takeway", proc61);
        dotNetFlexGrid.FieldFormatorHandle proc5 = delegate(DataRow dr)
        {

            int a = Convert.ToInt32(dr["dtbtype"].ToString());
            if (a == 1)
            {
                return "顺丰";
            }
            else if (a == 2)
            {
                return "圆通";
            }
            else
            {
                return "中通";
            }




        };
        result.FieldFormator.Register("dtbtype", proc5);
        return result;
    }

}