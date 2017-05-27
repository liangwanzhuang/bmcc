using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using SQLDAL;
using ModelInfo;

public partial class welcome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string usernamebar = "";
        if (Session["userNamebar"] != null)
        {
           
             usernamebar = Session["userNamebar"].ToString();
        }
        DataBaseLayer db = new DataBaseLayer();
        string str = "select EName from Employee where   JobNum = '" + usernamebar + "'";
            SqlDataReader sr = db.get_Reader(str);
            if (sr.Read())
            {

                string hh = "";
                System.DateTime cc = new System.DateTime();
                cc = System.DateTime.Now;
                string SendTime = cc.ToString("HHmmss");
                name.Text = sr["EName"].ToString();

                //string a = DateTime.Now.ToString("yyyy/MM/dd hhmmss");
                // string m = SendTime.Substring(11);

                int now = Convert.ToInt32(SendTime);
                int strS = 240000;
                int strS6 = 245959;
                int strS5 = 010000;
                int strS1 = 080000;
                int strS2 = 110000;
                int strS3 = 130000;
                int strS4 = 170000;

                if (strS1 >= now && now >= strS5)
                {
                    hh = "早上";
                }
                else if (strS2 >= now && now > strS1)
                {
                    hh = "上午";
                }
                else if (strS3 >= now && now > strS2)
                {
                    hh = "中午";

                }
                else if (strS4 >= now && now > strS3)
                {
                    hh = "下午";

                }
                else if (strS >= now && now > strS1)
                {
                    hh = "晚上";
                }
                else if (strS6 >= now && now > strS)
                {
                    hh = "早上";
                }
                else
                {
                    hh = "您";
                }
                hello.Text = hh + "好，欢迎使用煎药管理系统";

            }
            else { 
            
            name.Text="您好，欢迎使用煎药管理系统";
            hello.Text = "";
            }
            string strDelNum = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

            string dt24 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


            time.Text = "您当前登录的时间：" + dt24;
            string str1 = "select Phone from Employee where   JobNum = '" + usernamebar + "'";
            SqlDataReader sr1 = db.get_Reader(str1);
            if (sr1.Read())
            {
                tell.Text = "(Telephone:" + sr1["Phone"].ToString() + ")";
            }
            else {

                tell.Text = "";
            }


        EmployeeHandler eh = new EmployeeHandler();
       SqlDataReader sdr = eh.findrolebyname(usernamebar);
       string role = "";
        if(sdr.Read()){
             role = sdr["Role"].ToString();
        }

        if (role == "0")//0
        {
            this.tip1.Style["display"] = "block";
            this.tip2.Style["display"] = "block";

            this.tip3.Style["display"] = "block";
            this.tip4.Style["display"] = "block";
            this.tip5.Style["display"] = "block";
            this.tip6.Style["display"] = "block";
            this.tip7.Style["display"] = "block";
            this.tip8.Style["display"] = "block";
            this.tip9.Style["display"] = "block";
            this.tip10.Style["display"] = "block";
            this.tip11.Style["display"] = "block";
            this.tip12.Style["display"] = "block";
            this.tip19.Style["display"] = "block";
            this.tip20.Style["display"] = "block";
            this.tip21.Style["display"] = "block";
            this.tip22.Style["display"] = "block";
            this.tip23.Style["display"] = "block";
            this.tip24.Style["display"] = "block";
            this.tip25.Style["display"] = "block";
            this.tip26.Style["display"] = "block";
            this.tip27.Style["display"] = "block";

            this.tip28.Style["display"] = "block";
            this.tip29.Style["display"] = "block";
            this.tip30.Style["display"] = "block";
            this.tip31.Style["display"] = "block";
            this.tip32.Style["display"] = "block";
            this.tip33.Style["display"] = "block";
            this.tip34.Style["display"] = "block";
            this.tip35.Style["display"] = "block";
            this.tip36.Style["display"] = "block";
            this.tip37.Style["display"] = "block";
            this.tip38.Style["display"] = "block";
            this.tip39.Style["display"] = "block";
            this.tip40.Style["display"] = "block";
            this.tip41.Style["display"] = "block";
            this.tip42.Style["display"] = "block";
            this.tip43.Style["display"] = "block";
            this.tip44.Style["display"] = "block";
            this.tip45.Style["display"] = "block";
            this.tip46.Style["display"] = "block";
            this.tip47.Style["display"] = "block";
            this.tip48.Style["display"] = "block";
            this.tip49.Style["display"] = "block";
            this.tip50.Style["display"] = "block";

            this.tip51.Style["display"] = "block";
            this.tip52.Style["display"] = "block";
            this.tip53.Style["display"] = "block";
            this.tip54.Style["display"] = "block";
            this.tip55.Style["display"] = "block";
            this.tip56.Style["display"] = "block";
            this.tip57.Style["display"] = "block";
            this.tip58.Style["display"] = "block";
            this.tip59.Style["display"] = "block";
            this.tip60.Style["display"] = "block";
            this.tip61.Style["display"] = "block";
            this.tip62.Style["display"] = "block";
            this.tip63.Style["display"] = "block";
            this.tip64.Style["display"] = "block";
            this.tip65.Style["display"] = "block";
            this.tip66.Style["display"] = "block";
            this.tip70.Style["display"] = "block";
            this.tip71.Style["display"] = "block";
            this.tip72.Style["display"] = "block";
            this.tip73.Style["display"] = "block";
            this.tip74.Style["display"] = "block";
            this.tip75.Style["display"] = "block";
        }
        else
        {
            checkAuthority(role);
        }
        /*
        if (role == "7")//7
        {
            this.tip1.Style["display"] = "block";
            this.tip2.Style["display"] = "block";
        }

        if (role == "8")//2
        {
            this.tip3.Style["display"] = "block";
            this.tip4.Style["display"] = "block";
            this.tip5.Style["display"] = "block";
            this.tip6.Style["display"] = "block";
        }
        if (role == "1")//3
        {
            this.tip7.Style["display"] = "block";
            this.tip8.Style["display"] = "block";
        }
        if (role == "2")//4
        {
            this.tip9.Style["display"] = "block";
            this.tip10.Style["display"] = "block";
        }
        if (role == "3")//5
        {
            this.tip11.Style["display"] = "block";
            this.tip12.Style["display"] = "block";
        }
        if (role == "4")//6
        {
            this.tip19.Style["display"] = "block";
            this.tip20.Style["display"] = "block";
            this.tip21.Style["display"] = "block";
        }
        if (role == "5")//7
        {
            //this.tip23.Style["display"] = "block";
            this.tip22.Style["display"] = "block";
        }
        if (role == "6")//7
        {

            this.tip23.Style["display"] = "block";
           // this.tip22.Style["display"] = "block";
        }
        if (role == "9")//9 14
        {
            this.tip25.Style["display"] = "block";
            this.tip26.Style["display"] = "block";
            this.tip27.Style["display"] = "block";
            this.tip31.Style["display"] = "block";
            this.tip32.Style["display"] = "block";
            this.tip66.Style["display"] = "block";
        }
        if (role == "10")//23
        {
            this.tip63.Style["display"] = "block";
            
        }*/
    }
    public void checkAuthority(string role)
    {
        EmployeeHandler eh = new EmployeeHandler();
        SqlDataReader sdr = eh.findEmployeelimits(role);
        string limits = "";
        if (sdr.Read())
        {
            limits = sdr["limits"].ToString();
        }
        if (limits.Length > 0)
        {
            string[] arrLimits = limits.Split('、');
            for (int i = 0; i < arrLimits.Length; i++)
            {
                string limitsName = arrLimits[i];
                if ("处方录入".Equals(limitsName))
                {
                    this.tip1.Style["display"] = "block";

                }
                else if ("接方查询".Equals(limitsName))
                {
                    this.tip2.Style["display"] = "block";

                }
                else if ("药品匹配".Equals(limitsName))
                {
                    this.tip3.Style["display"] = "block";

                }
                else if ("处方审核".Equals(limitsName))
                {
                    this.tip4.Style["display"] = "block";

                }
                else if ("处方打印".Equals(limitsName))
                {
                    this.tip5.Style["display"] = "block";

                }
                else if ("配方查询".Equals(limitsName))
                {
                    this.tip6.Style["display"] = "block";

                }
                else if ("调剂查询".Equals(limitsName))
                {
                    this.tip7.Style["display"] = "block";

                }
                else if ("调剂统计".Equals(limitsName))
                {
                    this.tip8.Style["display"] = "block";

                }
                else if ("复核查询".Equals(limitsName))
                {
                    this.tip9.Style["display"] = "block";

                }
                else if ("工作记录查询".Equals(limitsName))
                {
                    this.tip10.Style["display"] = "block";


                }
                else if ("泡药信息".Equals(limitsName))
                {
                    this.tip11.Style["display"] = "block";


                }
                else if ("简要机组分配".Equals(limitsName))
                {
                    this.tip12.Style["display"] = "block";

                }
                else if ("煎药信息".Equals(limitsName))
                {
                    this.tip19.Style["display"] = "block";


                }
                else if ("机组信息".Equals(limitsName))
                {
                    this.tip20.Style["display"] = "block";


                }
                else if ("查询功能".Equals(limitsName))
                {
                    this.tip21.Style["display"] = "block";


                }
                else if ("包装管理".Equals(limitsName))
                {
                    this.tip22.Style["display"] = "block";


                }
                else if ("发货管理".Equals(limitsName))
                {
                    this.tip23.Style["display"] = "block";


                }
                else if ("综合查询".Equals(limitsName))
                {
                    this.tip24.Style["display"] = "block";
                }
                else if ("员工工作量统计".Equals(limitsName))
                {
                    this.tip25.Style["display"] = "block";

                }
                else if ("煎药机工作量统计".Equals(limitsName))
                {
                    this.tip26.Style["display"] = "block";

                }
                else if ("包装机工作量统计".Equals(limitsName))
                {
                    this.tip27.Style["display"] = "block";

                }
                else if ("配送统计".Equals(limitsName))
                {
                    this.tip28.Style["display"] = "block";

                }
                else if ("业务员业绩统计".Equals(limitsName))
                {
                    this.tip29.Style["display"] = "block";

                }
                else if ("综合预警".Equals(limitsName))
                {
                    this.tip30.Style["display"] = "block";

                }
                else if ("煎药机监控".Equals(limitsName))
                {
                    this.tip64.Style["display"] = "block";

                }
                else if ("包装机监控".Equals(limitsName))
                {
                    this.tip65.Style["display"] = "block";

                }
                else if ("泡药显示".Equals(limitsName))
                {
                    this.tip66.Style["display"] = "block";

                }
                else if ("煎药显示".Equals(limitsName))
                {
                    this.tip31.Style["display"] = "block";

                }
                else if ("发药显示".Equals(limitsName))
                {
                    this.tip32.Style["display"] = "block";

                }
                else if ("抽检录入".Equals(limitsName))
                {
                    this.tip33.Style["display"] = "block";

                }
                else if ("抽检列表查询".Equals(limitsName))
                {
                    this.tip34.Style["display"] = "block";

                }
                else if ("员工信息".Equals(limitsName))
                {
                    this.tip35.Style["display"] = "block";

                }
                else if ("权限管理".Equals(limitsName))
                {
                    this.tip36.Style["display"] = "block";

                }
                else if ("后台设置".Equals(limitsName))
                {
                    this.tip37.Style["display"] = "block";

                }
                else if ("界面管理".Equals(limitsName))
                {
                    this.tip38.Style["display"] = "block";

                }
                else if ("打印模块设置".Equals(limitsName))
                {
                    this.tip39.Style["display"] = "block";

                }
                else if ("医院管理".Equals(limitsName))
                {
                    this.tip40.Style["display"] = "block";

                }
                else if ("结算方管理".Equals(limitsName))
                {
                    this.tip41.Style["display"] = "block";

                }
                else if ("收件人管理".Equals(limitsName))
                {
                    this.tip42.Style["display"] = "block";

                }
                else if ("库房药房管理".Equals(limitsName))
                {
                    this.tip43.Style["display"] = "block";

                }
                else if ("设备管理".Equals(limitsName))
                {
                    this.tip44.Style["display"] = "block";

                }
                else if ("煎药室管理".Equals(limitsName))
                {
                    this.tip45.Style["display"] = "block";

                }
                else if ("入库管理".Equals(limitsName))
                {
                    this.tip46.Style["display"] = "block";

                }
                else if ("入库列表查询".Equals(limitsName))
                {
                    this.tip70.Style["display"] = "block";

                }
                else if ("调拨管理".Equals(limitsName))
                {
                    this.tip47.Style["display"] = "block";

                }
                else if ("调拨列表查询".Equals(limitsName))
                {
                    this.tip71.Style["display"] = "block";

                }
                else if ("库存信息".Equals(limitsName))
                {
                    this.tip48.Style["display"] = "block";

                }
                else if ("库房盘点".Equals(limitsName))
                {
                    this.tip49.Style["display"] = "block";

                }
                else if ("报损信息".Equals(limitsName))
                {
                    this.tip50.Style["display"] = "block";

                }
                else if ("报单查询".Equals(limitsName))
                {
                    this.tip51.Style["display"] = "block";
                }
                else if ("药房入库管理".Equals(limitsName))
                {
                    this.tip52.Style["display"] = "block";

                }
                else if ("药房调拨管理".Equals(limitsName))
                {
                    this.tip53.Style["display"] = "block";

                }
                else if ("药房调拨单列表查询".Equals(limitsName))
                {
                    this.tip72.Style["display"] = "block";

                }
                else if ("药房库存信息".Equals(limitsName))
                {
                    this.tip54.Style["display"] = "block";
                }
                else if ("药房库房盘点".Equals(limitsName))
                {
                    this.tip55.Style["display"] = "block";

                }
                else if ("药房报损信息".Equals(limitsName))
                {
                    this.tip56.Style["display"] = "block";

                }
                else if ("药房报单查询".Equals(limitsName))
                {
                    this.tip57.Style["display"] = "block";

                }
                else if ("药品管理".Equals(limitsName))
                {
                    this.tip58.Style["display"] = "block";

                }
                else if ("药品匹配列表".Equals(limitsName))
                {
                    this.tip59.Style["display"] = "block";

                }
                else if ("对账单".Equals(limitsName))
                {
                    this.tip60.Style["display"] = "block";

                }
                else if ("对账列表".Equals(limitsName))
                {
                    this.tip61.Style["display"] = "block";

                }
                else if ("订单列表".Equals(limitsName))
                {
                    this.tip62.Style["display"] = "block";

                }
                else if ("物流信息".Equals(limitsName))
                {
                    this.tip63.Style["display"] = "block";

                }
                else if ("物流信息".Equals(limitsName))
                {
                    this.tip36.Style["display"] = "block";

                }
                else if ("拍照设置".Equals(limitsName))
                {
                    this.tip73.Style["display"] = "block";

                }
                else if ("物流key设置".Equals(limitsName))
                {
                    this.tip74.Style["display"] = "block";

                }
                else if ("自动打印开关".Equals(limitsName))
                {
                    this.tip75.Style["display"] = "block";

                }

            }

        }

    }
    }

     
   
