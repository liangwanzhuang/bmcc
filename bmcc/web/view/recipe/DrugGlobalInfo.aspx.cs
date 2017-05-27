using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;
using System.Data;
using System.Collections;
public partial class view_recipe_GlobalDrugInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //  person1.Items.Add(new ListItem("", "1"));
            // person1.Items.Add(new ListItem("", "2"));
            //this.bubblestatus.Items.Add(new ListItem("已完成","1"));
            // this.bubblestatus.Items.Add(new ListItem("未完成", "0"));

        }


        //Statistics sc = new Statistics();
      //  string str = sc.countall();


      //  String[] strArr = str.Split(',');

        //count.Text = "统计: 已录入: " + strArr[9] + "  已审核: " + strArr[8] + "   已打印: " + strArr[7] + "   未打印: " + strArr[10] + "   已匹配: " + strArr[6] + "   未匹配: " + strArr[11] + "   已调剂: " + strArr[5] + "  已复核: " + strArr[4] + "  已泡药: " + strArr[0] + "  已煎药: " + strArr[1] + "  已包装：" + strArr[2] + "  已发货：" + strArr[3] + " ";

      //  count.Text = "统计：已接方: " + strArr[9] + "    已审核: " + strArr[8] + "     未匹配: " + strArr[11] + "     调剂: " + strArr[5] + "    复核: " + strArr[4] + "    泡药: " + strArr[0] + "    煎药: " + strArr[1] + "     包装：" + strArr[2] + "    发货：" + strArr[3] + " ";
        //报警
     //   Bubbleinfo bi = new Bubbleinfo();
     //   string warningid = bi.bubblewarning();

      //  warning.Value = warningid;



        this.FlexGridDrugGlobal1.InitConfig(
            new string[]{
                "title=泡药信息显示",//标题
                "striped=true",//是否显示行交替色
                 "singleselected=true",//是否单选
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=true",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=1000"//宽度，可为auto或具体px值
            },
            new dotNetFlexGrid.FieldConfig[]{
  
                new dotNetFlexGrid.FieldConfig("ID","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("doingtime","已泡药时间(min)",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("mark","泡药备注",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("wateryield","实际加水量",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("delnum","委托单号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hnum","医院编号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hname","医院名称",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Pspnum","处方号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Hospitalid","医院ID",60,true,dotNetFlexGrid.FieldConfigAlign.Center,false,true,false),
                new dotNetFlexGrid.FieldConfig("name","患者姓名",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("sex","性别",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("age","年龄",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("phone","电话",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("address","地址",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("department","科室",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("inpatientarea","病区号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ward","病房号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("sickbed","病床号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("diagresult","诊断结果",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("takemethod","服用方式",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("takenum","次数",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("packagenum","包装量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("decscheme","煎药方案",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("oncetime","一煎时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("twicetime","二煎时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("soakwater","浸泡加水量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("soaktime","浸泡时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("labelnum","标签数量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("remark","备注信息",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("doctor","医生",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("footnote","医生脚注",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("getdrugtime","取药时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("getdrugnum","取药序号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ordertime","下单时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("bubblestatus","当前状态",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
              //  new dotNetFlexGrid.FieldConfig("dotime","操作时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("starttime","开始时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("endDate","完成时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("bp","操作人员",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbcompany","配送公司",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbaddress","配送地址",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbphone","联系电话",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbtype","快件类型",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("RemarksA","备注A",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("RemarksB","备注B",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               
            },
         null
         ,
            null        
        );

        this.FlexGridDrugGlobal1.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);



       // this.FlexGridDrugGlobal1.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);


        //第二个·
        /* this.FlexGridDrugGlobal2.InitConfig(
            new string[]{
                 "title=已完成的泡药处方信息",//标题
                  "singleselected=false",//是否单选
                 "striped=true",//是否显示行交替色
                 "selectedonclick=true",//是否点击行自动选中checkbox
                 "usepager=false",//使用分页器
                 "showcheckbox=true",//显示复选框
                 "height=300",//高度，可为auto或具体px值
                 "width=1000"//宽度，可为auto或具体px值
             },
            new dotNetFlexGrid.FieldConfig[]{
                 new dotNetFlexGrid.FieldConfig("ID","序号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                  new dotNetFlexGrid.FieldConfig("bubbleman","泡药人员",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("hnum","医院编号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("hname","医院名称",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("Pspnum","处方号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("name","病人姓名",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("sex","性别",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("age","年龄",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("phone","手机号码",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("address","地址",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("department","科室",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("inpatientarea","病房区",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("dose","剂量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("takenum","次数",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("getdrugtime","取药时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("getdrugnum","取药号",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("decscheme","煎药方案",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("soaktime","煎药时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("packagenum","包装量",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("dotime","处理日期",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
             },
         null
         ,
            null
        );*/
        //   this.FlexGridDrugGlobal2.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid2DataHandler);


    }
    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际
        // result.table = dotNetFlexGrid.DemoMemoryTable(p.page * 100, p.rp);//调用演示的数据生成函数产生模拟数据
        //如果传递的参数包含排序设置的话，通过DataView.Sort功能模拟进行当页排序


        string bubbleman = "0";
        if (p.extParam.ContainsKey("bubbleman"))
        {
            bubbleman = p.extParam["bubbleman"];
        }
        string bubblestatus = "0";
        if (p.extParam.ContainsKey("bubblestatus"))
        {
            bubblestatus = p.extParam["bubblestatus"];
        }

        if (bubbleman == "")
        {
            bubbleman = "0";
        }
      

        Bubbleinfo bi = new Bubbleinfo();
        result.table = bi.getBubbleInfo(bubbleman, Convert.ToInt32(bubblestatus));


        dotNetFlexGrid.FieldFormatorHandle proc1 = delegate(DataRow dr)
        {

            int bstatus = Convert.ToInt32(dr["bubblestatus"].ToString());
            if (bstatus ==1)
            {
                return "泡药完成";
            }
            else
            {
                return "开始泡药";
            }



        };
        dotNetFlexGrid.FieldFormatorHandle proc1a = delegate(DataRow dr)
        {

            string z = "";
            int bstatus = Convert.ToInt32(dr["bubblestatus"].ToString());
            string  start =dr["starttime"].ToString();
       
           
            int soaktime = Convert.ToInt32(dr["soaktime"].ToString());
            if (bstatus == 0)
            {
                System.DateTime currentTime = new System.DateTime();
                currentTime = System.DateTime.Now;
                string strtime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");//
                DateTime d1 = Convert.ToDateTime(strtime);//当前时间

                DateTime d2 = Convert.ToDateTime(start);//开始时间

                TimeSpan d3 = d1.Subtract(d2);//泡药时间

                int dT = Convert.ToInt32(d3.Days.ToString()) * 24 * 60 + Convert.ToInt32(d3.Hours.ToString()) * 60 + Convert.ToInt32(d3.Minutes.ToString());//转化为分钟数

                string dt = dT.ToString(); 
                if (dT> soaktime)
                {
                    z = "<span style='color:red'>" + dt + "</span>";

                }
                else
                {

                    z = "<span style='color:black'>" + dt + "</span>";
                }
            }
            else
            {
               
                int d = Convert.ToInt32(dr["doingtime"].ToString());
                if (d > soaktime)
                {
                    z = "<span style='color:red'>" + dr["doingtime"].ToString() + "</span>";

                }
                else
                {
                   z = "<span style='color:black'>" + dr["doingtime"].ToString() + "</span>";
                }
            }

            return z;


        };

      /*  dotNetFlexGrid.FieldFormatorHandle proc = delegate(DataRow dr)
        {
            string a = "";
           int doingtime = Convert.ToInt32(dr["doingtime"].ToString());
           int soaktime =  Convert.ToInt32(dr["soaktime"].ToString());
          
           if (doingtime > soaktime)
           {
               a = "<span style='color:red'>" + dr["doingtime"].ToString() + "</span>";

           }
           else {

               a = "<span style='color:black'>" + dr["doingtime"].ToString() + "</span>";
           }


            return a;

        };
        */
        result.FieldFormator.Register("bubblestatus", proc1);
        result.FieldFormator.Register("doingtime", proc1a);
       // result.FieldFormator.Register("doingtime", proc);

      //  result.FieldFormator.Register("warningstatus", proc1);

        dotNetFlexGrid.FieldFormatorHandle proc2 = delegate(DataRow dr)
        {

            int a = Convert.ToInt32(dr["sex"].ToString());
            if (a == 1)
            {
                return "男";
            }
            else
            {
                return "女";
            }




        };
        result.FieldFormator.Register("sex", proc2);
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




    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid2DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际
        // result.table = dotNetFlexGrid.DemoMemoryTable(p.page * 100, p.rp);//调用演示的数据生成函数产生模拟数据
        //如果传递的参数包含排序设置的话，通过DataView.Sort功能模拟进行当页排序


        string bubbleman = "0";
        if (p.extParam.ContainsKey("bubbleman"))
        {
            bubbleman = p.extParam["bubbleman"];
        }
        string bubblestatus = "0";
        if (p.extParam.ContainsKey("bubblestatus"))
        {
            bubblestatus = p.extParam["bubblestatus"];
        }


        // EmployeeHandler eh = new EmployeeHandler();
        //  result.table = eh.getBubbleInfo( Convert.ToInt32("1"));

        Bubbleinfo bi = new Bubbleinfo();
        result.table = bi.getBubbleInfo(bubbleman, Convert.ToInt32(bubblestatus));
        // result.table = rm.findRecipeInfo(1, "1", 0);
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

    //导出数据
    protected void Button1_Click(object sender, EventArgs e)
    {
        string bubblestatus1 = bubblestatus.Value;

        string bubbleman1 = bubbleman.Value;
        if (bubbleman1 == "")
        {
            bubbleman1 = "0";
        }
        Bubbleinfo bi = new Bubbleinfo();

        // DataBaseLayer db = new DataBaseLayer();
        //    string str = "select * from lossiInfor where type ='" + type + "'";
        DataTable dt = bi.getBubbleInfoDao(bubbleman1, Convert.ToInt32(bubblestatus1));
        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now;
        string now = currentTime.ToString("yyyyMMdd");
        CreateExcel(dt, "application/ms-excel", "泡药信息" + now);
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

        string ls_item = "序号 \t处方号\t委托单号\t当前状态\t已泡药时间(min)\t开始时间\t完成时间\t泡药人员\t泡药备注\t医院编号\t医院名称\t姓名\t性别\t年龄\t电话\t地址\t科室\t病区号\t"
            + "病房号\t病床号\t诊断结果\t实际加水量\t贴数\t次数\t取药时间\t取药序号\t服用方式\t煎药方案\t一煎时间\t二煎时间\t包装量\t操作时间 \t配送公司\t配送地址\t联系电话\t快件类型\t浸泡加水量\t浸泡时间\t标签数量\t备注信息\t医生\t医生脚注\t下单时间\t"
           // + ""
            + "备注A \t备注B\n";
        //煎药方式\t服用方法
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

    [WebMethod]
    public static bool deleteRecipeById(string strRowIds)
    {
        int a = 0;
        bool result;
        string[] strRowsId = strRowIds.Split(',');
        for (int i = 0; i < strRowsId.Length; i++)
        {
            //RecipeModel rm = new RecipeModel();
            Bubbleinfo bi = new Bubbleinfo();
            //bi.deleteRecipeInfo(Convert.ToInt16(strRowsId[i]));
            a = bi.deleteBubbleInfo(Convert.ToInt32(strRowsId[i]));
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
    public static bool distributionById(string strRowIds)
    {
        int a = 0;
        bool result;
        string[] strRowsId = strRowIds.Split(',');
        for (int i = 0; i < strRowsId.Length; i++)
        {
            //RecipeModel rm = new RecipeModel();
            Bubbleinfo bi = new Bubbleinfo();
            //bi.deleteRecipeInfo(Convert.ToInt16(strRowsId[i]));
            a = bi.deleteBubbleInfo(Convert.ToInt32(strRowsId[i]));
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
    public static bool checkisdone(string id)
    {

        Bubbleinfo bi = new Bubbleinfo();


        bool result = bi.checkisdone(id);

        return result;

    }
    [WebMethod]
    public static string  countstatistics()
    {
        Statistics sc = new Statistics();
        string str = sc.countall();


        String[] strArr = str.Split(',');

        //count.Text = "统计: 已录入: " + strArr[9] + "  已审核: " + strArr[8] + "   已打印: " + strArr[7] + "   未打印: " + strArr[10] + "   已匹配: " + strArr[6] + "   未匹配: " + strArr[11] + "   已调剂: " + strArr[5] + "  已复核: " + strArr[4] + "  已泡药: " + strArr[0] + "  已煎药: " + strArr[1] + "  已包装：" + strArr[2] + "  已发货：" + strArr[3] + " ";

        string result = "统计：已接方: " + strArr[9] + "    已审核: " + strArr[8] + "     未匹配: " + strArr[11] + "     调剂: " + strArr[5] + "    复核: " + strArr[4] + "    泡药: " + strArr[0] + "    煎药: " + strArr[1] + "     包装：" + strArr[2] + "    发货：" + strArr[3] + " ";
        return result;
    }

    [WebMethod]
    public static string getWarning()
    {
        //报警
        Bubbleinfo bi = new Bubbleinfo();
        string warningid = bi.bubblewarning();

        return warningid;

    }

}