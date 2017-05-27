using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data.SqlClient;
using SQLDAL;
using System.Data;
using System.Web.Services;
using System.Collections;




public partial class view_recipe_QueryFunction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
      
        this.tisanestatus.Items.Add(new ListItem("开始煎药", "0"));
        this.tisanestatus.Items.Add(new ListItem("煎药完成", "1"));



        this.tisanemethod.Items.Add(new ListItem("先煎", "1"));
        this.tisanemethod.Items.Add(new ListItem("后下", "2"));
        this.tisanemethod.Items.Add(new ListItem("加糖加蜜", "3"));


        /*this.tisanetime.Items.Add(new ListItem("15min", "1"));
        this.tisanetime.Items.Add(new ListItem("20min", "2"));
        this.tisanetime.Items.Add(new ListItem("35min", "3"));
        this.tisanetime.Items.Add(new ListItem("45min", "4"));
        this.tisanetime.Items.Add(new ListItem("55min", "5"));
        */



        //Bubbleinfo bi = new Bubbleinfo();
       // string machineid = bi.distributionmachine();
       // SqlDataReader sdr2 = tm.findmachinenamebyid(Convert.ToInt32(machineid));
        //if (sdr2.Read())
        //{
       //     recommend.Text = sdr2["machinename"].ToString();
       // }

       // Statistics sc = new Statistics();
       // string str = sc.countall();
    

      //  String[] strArr = str.Split(',');

       // count.Text = "统计: 已录入: " + strArr[9] + "  已审核: " + strArr[8] + "   已打印: " + strArr[7] + "   未打印: " + strArr[10] + "   已匹配: " + strArr[6] + "   未匹配: " + strArr[11] + "   已调剂: " + strArr[5] + "  已复核: " + strArr[4] + "  已泡药: " + strArr[0] + "  已煎药: " + strArr[1] + "  已包装：" + strArr[2] + "  已发货：" + strArr[3] + " ";

      //  count.Text = "统计：已接方: " + strArr[9] + "    已审核: " + strArr[8] + "     未匹配: " + strArr[11] + "     调剂: " + strArr[5] + "    复核: " + strArr[4] + "    泡药: " + strArr[0] + "    煎药: " + strArr[1] + "     包装：" + strArr[2] + "    发货：" + strArr[3] + " ";
        //报警
       // DeliveryModel dm = new DeliveryModel();
        //string warningid = dm.deliverywarning();
     //   TeModel tm = new TeModel();

    //    string warningid = tm.tisanewarning();
     //   warning.Value = warningid;



        this.dotNetFlexGrid1.InitConfig(
                            new string[]{
                "title=查询信息",//标题
                 "singleselected=true",//是否单选
                "striped=true",//是否显示行交替色
                "selectedonclick=true",//是否点击行自动选中checkbox
                "usepager=false",//使用分页器
                "showcheckbox=false",//显示复选框
                "height=300",//高度，可为auto或具体px值
                "width=1000"//宽度，可为auto或具体px值
            },
                new dotNetFlexGrid.FieldConfig[]{
                new dotNetFlexGrid.FieldConfig("ID","煎药单号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("tisanetime","煎药时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("starttime","开始时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("endDate","完成时间",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("machineid","煎药机组",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
              //new dotNetFlexGrid.FieldConfig("mark","煎药备注",60,false,dotNetFlexGrid.FieldConfigAlign.Center),

                new dotNetFlexGrid.FieldConfig("hnum","医院编号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("hname","医院名称",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("delnum","委托单号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("Pspnum","处方号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("name","患者姓名",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("sex","性别",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("age","年龄",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("phone","手机号码",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("address","地址",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("department","科室",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("inpatientarea","病区号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ward","病房号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("sickbed","病床号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("diagresult","诊断结果",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                       
                new dotNetFlexGrid.FieldConfig("takemethod","服用方式",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("takenum","次数",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("decscheme","煎药方案",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               
                new dotNetFlexGrid.FieldConfig("packagenum","包装量",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                       
                new dotNetFlexGrid.FieldConfig("oncetime","煎药时间一",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("twicetime","煎药时间二",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("soakwater","加水量",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("waterYield","实际加水量",60,true,dotNetFlexGrid.FieldConfigAlign.Center),

                new dotNetFlexGrid.FieldConfig("labelnum","标签数量",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("remark","说明",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("doctor","医生",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("footnote","煎医生脚",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("getdrugtime","取药时间",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("getdrugnum","取药号",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("ordertime","订单时间",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("tisanestatus","当前状态",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
               // new dotNetFlexGrid.FieldConfig("dotime","处理时间",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("tisaneman","操作人员",60,false,dotNetFlexGrid.FieldConfigAlign.Center),
    
                new dotNetFlexGrid.FieldConfig("dtbcompany","配送公司",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbaddress","配送地址",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbphone","快递电话",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                new dotNetFlexGrid.FieldConfig("dtbtype","配送类型",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("RemarksA","备注A",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
                 new dotNetFlexGrid.FieldConfig("RemarksB","备注B",60,true,dotNetFlexGrid.FieldConfigAlign.Center),
           },
                         null
                         ,
                            null
                        );
        this.dotNetFlexGrid1.DataHandler = new dotNetFlexGrid.DataHandlerDelegate(DotNetFlexGrid1DataHandler);  //提供数据的方法
    }

    public dotNetFlexGrid.DataHandlerResult DotNetFlexGrid1DataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        result.page = p.page;//设定当前返回的页号
        result.total = 100;//总计的数据条数，此处用100进行模拟，查询和筛选时需要根据实际
       // result.table = dotNetFlexGrid.DemoMemoryTable(p.page * 100, p.rp);//调用演示的数据生成函数产生模拟数据
        //如果传递的参数包含排序设置的话，通过DataView.Sort功能模拟进行当页排序


        string tisaneid = "0";
        if (p.extParam.ContainsKey("tisaneid"))
        {
            tisaneid = p.extParam["tisaneid"];
        }
        string tisaneman = "0";
        if (p.extParam.ContainsKey("tisaneman"))
        {
            tisaneman = p.extParam["tisaneman"];
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

        string tisanestatus = "0";
        if (p.extParam.ContainsKey("tisanestatus"))
        {
            tisanestatus = p.extParam["tisanestatus"];
        }
        string tisanemethod = "0";
        if (p.extParam.ContainsKey("tisanemethod"))
        {
            tisanemethod = p.extParam["tisanemethod"];
        }


        if (tisaneid == "")
        {
            tisaneid = "0";
        }

        if (tisaneman == "")
        {
            tisaneman = "0";
        }

     

        TeModel tm = new TeModel();




      





      //  result.table = tm.queryTisaneInfo(Convert.ToInt32(tisaneid), tisaneman, tisanestatus, tisanemethod, tisanetime);
        result.table = tm.queryTisaneInfo(Convert.ToInt32(tisaneid), tisaneman, Convert.ToInt32(tisanestatus), Convert.ToInt32(tisanemethod), STime, ETime);

        dotNetFlexGrid.FieldFormatorHandle proc = delegate(DataRow dr)
        {
            string a = "";

            int tstatus = Convert.ToInt32(dr["tisanestatus"].ToString());

            if (tstatus==0)
            {
                a = "开始煎药";

            }
            else if (tstatus == 1)
            {

                a = "煎药完成";
            }
          
            return a;

        };

        result.FieldFormator.Register("tisanestatus", proc);
        dotNetFlexGrid.FieldFormatorHandle proc1 = delegate(DataRow dr)
        {

            int bstatus = Convert.ToInt32(dr["bubblestatus"].ToString());
            if (bstatus == 1)
            {
                return "泡药完成";
            }
            else
            {
                return "开始泡药";
            }



        };
        //
        dotNetFlexGrid.FieldFormatorHandle proc1a = delegate(DataRow dr)
        {

            string z = "";
            int bstatus = Convert.ToInt32(dr["tisanestatus"].ToString());
            string start = dr["starttime"].ToString();


           
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
               
                z = dt;

            }
            else
            {

                z = dr["tisanetime"].ToString();
                
            }

            return z;


        };

        result.FieldFormator.Register("tisanetime", proc1a);
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

    [WebMethod]
    public static bool deleteTisaneById(string strRowIds)
    {
        int a = 0;
        bool result;
        string[] strRowsId = strRowIds.Split(',');
        for (int i = 0; i < strRowsId.Length; i++)
        {
            //RecipeModel rm = new RecipeModel();
            //Bubbleinfo bi = new Bubbleinfo();

             TeModel tm = new TeModel();

            a = tm.deleteTisaneinfoById(Convert.ToInt32(strRowsId[i]));
            //bi.deleteRecipeInfo(Convert.ToInt16(strRowsId[i]));
           // a = bi.deleteBubbleInfo(Convert.ToInt32(strRowsId[i]));
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

    //导出数据
    protected void Button1_Click(object sender, EventArgs e)
    {
        string tisanetime1 = "";


        string STime1 = "";
        string ETime1 = "";

         string tisanestatus1="";
         STime1 = STime.Value;
         ETime1 = ETime.Value;
        


         if (tisanestatus.Value=="")
         {
        
         tisanestatus1 = "2";
        }else{
         tisanestatus1 = tisanestatus.Value;
        }
       
        string tisanemethod1 = tisanemethod.Value;
        string tisaneman1 = tisaneman.Value;
        string tisaneid1 = "";
        if (tisaneid.Value == "") {
             tisaneid1 = "0";
        }
        else
        {
             tisaneid1 = tisaneid.Value;
        }

        if (tisaneid1 == "")
        {
            tisaneid1 = "0";
        }

        if (tisaneman1 == "")
        {
            tisaneman1 = "0";
        }


        TeModel tm = new TeModel();

        // DataBaseLayer db = new DataBaseLayer();
        //    string str = "select * from lossiInfor where type ='" + type + "'";
        DataTable dt = tm.queryTisaneInfoDao(Convert.ToInt32(tisaneid1), tisaneman1, Convert.ToInt32(tisanestatus1), Convert.ToInt32(tisanemethod1), STime1, ETime1);
        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now;
        string now = currentTime.ToString("yyyyMMdd");
        CreateExcel(dt, "application/ms-excel", "煎药查询功能" + now);
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

        string ls_item = "序号\t处方号\t委托单号 \t煎药人员\t当前状态\t医院编号\t医院名称\t姓名\t性别\t年龄\t电话\t地址\t科室\t病区号\t 病房号\t病床号\t诊断结果"
            + " \t  开始时间\t煎药时间 \t 完成时间 \t浸泡加水量\t煎药机\t贴数\t次数\t取药时间\t取药序号\t服用方式\t煎药方案\t一煎时间\t备注A\t备注B\t二煎时间\t包装量\t操作时间\t配送公司\t配送地址\t配送电话"
            +"\t配送类型\t加水量\t加水时间\t标签数量\t备注信息\t医生\t医生脚注\t下单时间\n";

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
    public static string getWarning()
    {
        //报警
        TeModel tm = new TeModel();

        string warningid = tm.tisanewarning();

        return warningid;

    }

}