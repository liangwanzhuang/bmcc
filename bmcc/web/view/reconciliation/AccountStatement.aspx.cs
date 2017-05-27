using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data;
using System.Data.SqlClient;

public partial class view_reconciliation_AccountStatement : System.Web.UI.Page
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

        this.FlexGridRecipe.InitConfig(
            new string[]{
                "title=处方信息",//标题
                "singleselected=false",//是否单选
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=1000"//宽度，可为auto或具体px值
            },
            // 序号、委托单号、医院编号、医院名称、处方号、煎药方式、姓名、性别、年龄、电话、地址、科室、病区号、
            //病房号、病床号、诊断结果、剂数、服用方式、次数、包装量、服用方法、煎药方案、一煎时间、二煎时间、
            //浸泡加水量、浸泡时间、标签数量、备注信息、医生、医生脚注、取药时间、取药序号、下单时间、当前状态、
            //操作时间、操作人员、配送公司、配送地址、联系电话、快件类型
            //下单时间、医院名称、处方号、煎药方式、患者姓名、药品数量、剂量、次数、包装量 
            new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("ID","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("h","受理日",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dotime","下单时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
               new dotNetFlexGrid.FieldConfig("hname","医院名称",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("a","内部处方号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Pspnum","处方号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("decscheme","煎药方式",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("name","患者姓名",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
               new dotNetFlexGrid.FieldConfig("DrugAcount","药品数量",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
               new dotNetFlexGrid.FieldConfig("dose","剂量",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
               new dotNetFlexGrid.FieldConfig("takenum","次数",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
               new dotNetFlexGrid.FieldConfig("packagenum","包装量",130,false,dotNetFlexGrid.FieldConfigAlign.Center),

             //   new dotNetFlexGrid.FieldConfig("b","结算方",80,false,dotNetFlexGrid.FieldConfigAlign.Center),
       
               // new dotNetFlexGrid.FieldConfig("d","金额",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("e","状态",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("f","对账人",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
              //  new dotNetFlexGrid.FieldConfig("j","对账时间",130,false,dotNetFlexGrid.FieldConfigAlign.Center),
                
             
            

        
           },
         null
         ,
            null
        );
        this.FlexGridRecipe.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);
    }  //提供数据的方法
    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际

        RecipeModel rm = new RecipeModel();


        string Pspnum = "";
        if (p.extParam.ContainsKey("Pspnum"))
        {
            Pspnum = p.extParam["Pspnum"];
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


        result.table = rm.AccountStatementInfo(Pspnum, STime, ETime, Convert.ToInt32(hospitalId));

        
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
        dotNetFlexGrid.FieldFormatorHandle proc6 = delegate(DataRow dr)
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
        result.FieldFormator.Register("takeway", proc6);
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