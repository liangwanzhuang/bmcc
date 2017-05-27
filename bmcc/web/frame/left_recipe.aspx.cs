using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using SQLDAL;
using System.Data;
using ModelInfo;
using SQLDAL;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient;
using SQLDAL;
using System.Collections;
using System.Data;

public partial class left_recipe : System.Web.UI.Page
{
    /// <summary>
    /// 
    /// </summary>
    public string cid = "";

    /// <summary>
    /// 用户id 
    /// </summary>  
    public string currentUserID = "";

    /// <summary>
    /// 用户角色的操作类
    /// </summary>
 
    /// <summary>
    /// 页面加载
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        ////防脚本SQL注入
        //AvertInjection.OnLoadCheck();
        //if (Request.QueryString["cid"] != null)
        //{
        //    cid = Request.QueryString["cid"].ToString();
        //}
        //if (Session["currentUserID"] != null)
        //{
        //    currentUserID = Session["currentUserID"].ToString();
        //}
        //else 
        //{
        //    Response.Redirect("noRight.aspx");
        //}
        //if (!IsPostBack)
        //{
          
        //}

        string usernamebar = Session["userNamebar"].ToString();


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
            this.Div1.Style["display"] = "block";
            this.Div2.Style["display"] = "block";
            this.tip8.Style["display"] = "block";
            this.tip9.Style["display"] = "block";
            this.tip10.Style["display"] = "block";
            this.tip11.Style["display"] = "block";
            this.tip12.Style["display"] = "block";
            this.tip13.Style["display"] = "block";
            this.tip14.Style["display"] = "block";
            this.tip15.Style["display"] = "block";
            this.tip16.Style["display"] = "block";
            this.tip17.Style["display"] = "block";
            this.tip18.Style["display"] = "block";
            this.tip19.Style["display"] = "block";
            this.tip20.Style["display"] = "block";
            //this.tip21.Style["display"] = "block";
            this.tip22.Style["display"] = "block";
            this.tip23.Style["display"] = "block";
            this.tip24.Style["display"] = "block";
            this.recipemanage.Style["display"] = "block";


            
            this.QueryStatistics.Style["display"] = "block";
            this.CentralMonitoring.Style["display"] = "block";
            this.systemmanage.Style["display"] = "block";
            this.StoreroomManagement.Style["display"] = "block";
            //this.tip21.Style["display"] = "block";
            this.ReconciliationManagement.Style["display"] = "block";
            this.LogisticsManagement.Style["display"] = "block";
            this.isShow.Value = "1";
        }
        else
        {
            this.isShow.Value = "0";
            checkAuthority(role);

        }
        /*
        if (role == "7")//7
        {
            this.recipemanage.Style["display"] = "block";
            this.tip1.Style["display"] = "block";
        }

        if (role == "8")//8
        {
            this.recipemanage.Style["display"] = "block";
            this.tip2.Style["display"] = "block";
        }
        if (role == "1")//1
        {
            this.recipemanage.Style["display"] = "block";
            this.tip3.Style["display"] = "block";
        }
        if (role == "2")//2
        {
            this.recipemanage.Style["display"] = "block";
            this.tip4.Style["display"] = "block";
        }
        if (role == "3")//3
        {
            this.recipemanage.Style["display"] = "block";
            this.tip5.Style["display"] = "block";
        }
        if (role == "4")//4
        {
            this.recipemanage.Style["display"] = "block";
            this.tip6.Style["display"] = "block";
        }
        if (role == "5")//5
        {
            this.recipemanage.Style["display"] = "block";
            this.tip7.Style["display"] = "block";
            this.Div1.Style["display"] = "block";
        }
        if (role == "6")//6
        {
            this.recipemanage.Style["display"] = "block";
            this.tip7.Style["display"] = "block";
            this.Div2.Style["display"] = "block";
        }
        if (role == "9")//10
        {
            this.QueryStatistics.Style["display"] = "block";
            this.CentralMonitoring.Style["display"] = "block";
            this.tip9.Style["display"] = "block";
            this.tip14.Style["display"] = "block";
        }
        if (role == "10")//9
        {
            this.LogisticsManagement.Style["display"] = "block";
            this.tip23.Style["display"] = "block";
            
        }
         */
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
            for (int i = 0; i < arrLimits.Length ; i++)
            {
                string limitsName = arrLimits[i];
                if ("处方录入".Equals(limitsName))
                {
                    if ("none".Equals(this.tip1.Style["display"]))
                    {
                        this.tip1.Style["display"] = "block";
                        
                    }
                    if ("none".Equals(this.recipemanage.Style["display"]))
                    {
                        this.recipemanage.Style["display"] = "block";

                    }
                    this.chufangluru.Style["display"] = "block";
                    
                }
                else if ("接方查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip1.Style["display"]))
                    {
                        this.tip1.Style["display"] = "block";

                    }
                    if ("none".Equals(this.recipemanage.Style["display"]))
                    {
                        this.recipemanage.Style["display"] = "block";

                    }
                    this.jiefangchaxun.Style["display"] = "block";
                    
                }
                else if ("药品匹配".Equals(limitsName))
                {
                    if ("none".Equals(this.tip2.Style["display"]))
                    {
                        this.tip2.Style["display"] = "block";

                    }
                    if ("none".Equals(this.recipemanage.Style["display"]))
                    {
                        this.recipemanage.Style["display"] = "block";

                    }
                    this.yaopinpipei.Style["display"] = "block";

                }
                else if ("处方审核".Equals(limitsName))
                {
                    if ("none".Equals(this.tip2.Style["display"]))
                    {
                        this.tip2.Style["display"] = "block";

                    }
                    if ("none".Equals(this.recipemanage.Style["display"]))
                    {
                        this.recipemanage.Style["display"] = "block";

                    }
                    this.chufangshenhe.Style["display"] = "block";

                }
                else if ("处方打印".Equals(limitsName))
                {
                    if ("none".Equals(this.tip2.Style["display"]))
                    {
                        this.tip2.Style["display"] = "block";

                    }
                    if ("none".Equals(this.recipemanage.Style["display"]))
                    {
                        this.recipemanage.Style["display"] = "block";

                    }
                    this.chufangdayin.Style["display"] = "block";

                }
                else if ("配方查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip2.Style["display"]))
                    {
                        this.tip2.Style["display"] = "block";

                    }
                    if ("none".Equals(this.recipemanage.Style["display"]))
                    {
                        this.recipemanage.Style["display"] = "block";

                    }
                    this.peifangchaxun.Style["display"] = "block";

                }
                else if ("调剂查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip3.Style["display"]))
                    {
                        this.tip3.Style["display"] = "block";

                    }
                    if ("none".Equals(this.recipemanage.Style["display"]))
                    {
                        this.recipemanage.Style["display"] = "block";

                    }
                    this.tiaojichaxun.Style["display"] = "block";

                }
                else if ("调剂统计".Equals(limitsName))
                {
                    if ("none".Equals(this.tip3.Style["display"]))
                    {
                        this.tip3.Style["display"] = "block";

                    }
                    if ("none".Equals(this.recipemanage.Style["display"]))
                    {
                        this.recipemanage.Style["display"] = "block";

                    }
                    this.tiaojitongji.Style["display"] = "block";

                }
                else if ("复核查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip4.Style["display"]))
                    {
                        this.tip4.Style["display"] = "block";

                    }
                    if ("none".Equals(this.recipemanage.Style["display"]))
                    {
                        this.recipemanage.Style["display"] = "block";

                    }
                    this.fuhechaxun.Style["display"] = "block";

                }
                else if ("工作记录查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip4.Style["display"]))
                    {
                        this.tip4.Style["display"] = "block";

                    }
                    if ("none".Equals(this.recipemanage.Style["display"]))
                    {
                        this.recipemanage.Style["display"] = "block";

                    }
                    this.gongzuojilu.Style["display"] = "block";


                }
                else if ("泡药信息".Equals(limitsName))
                {
                    if ("none".Equals(this.tip5.Style["display"]))
                    {
                        this.tip5.Style["display"] = "block";

                    }
                    if ("none".Equals(this.recipemanage.Style["display"]))
                    {
                        this.recipemanage.Style["display"] = "block";

                    }
                    this.paoyaoxinxi.Style["display"] = "block";


                }
                else if ("简要机组分配".Equals(limitsName))
                {
                    if ("none".Equals(this.tip5.Style["display"]))
                    {
                        this.tip5.Style["display"] = "block";

                    }
                    if ("none".Equals(this.recipemanage.Style["display"]))
                    {
                        this.recipemanage.Style["display"] = "block";

                    }
                    this.jianyaojizu.Style["display"] = "block";


                }
                else if ("煎药信息".Equals(limitsName))
                {
                    if ("none".Equals(this.tip6.Style["display"]))
                    {
                        this.tip6.Style["display"] = "block";

                    }
                    if ("none".Equals(this.recipemanage.Style["display"]))
                    {
                        this.recipemanage.Style["display"] = "block";

                    }
                    this.jianyaoxinxi.Style["display"] = "block";


                }
                else if ("机组信息".Equals(limitsName))
                {
                    if ("none".Equals(this.tip6.Style["display"]))
                    {
                        this.tip6.Style["display"] = "block";

                    }
                    if ("none".Equals(this.recipemanage.Style["display"]))
                    {
                        this.recipemanage.Style["display"] = "block";

                    }
                    this.jizuxinxi.Style["display"] = "block";


                }
                else if ("查询功能".Equals(limitsName))
                {
                    if ("none".Equals(this.tip6.Style["display"]))
                    {
                        this.tip6.Style["display"] = "block";

                    }
                    if ("none".Equals(this.recipemanage.Style["display"]))
                    {
                        this.recipemanage.Style["display"] = "block";

                    }
                    this.chaxungongneng.Style["display"] = "block";


                }
                else if ("包装管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip7.Style["display"]))
                    {
                        this.tip7.Style["display"] = "block";

                    }
                    if ("none".Equals(this.recipemanage.Style["display"]))
                    {
                        this.recipemanage.Style["display"] = "block";

                    }
                    this.Div1.Style["display"] = "block";


                }
                else if ("发货管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip7.Style["display"]))
                    {
                        this.tip7.Style["display"] = "block";

                    }
                    if ("none".Equals(this.recipemanage.Style["display"]))
                    {
                        this.recipemanage.Style["display"] = "block";

                    }
                    this.Div2.Style["display"] = "block";


                }
                else if ("综合查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip8.Style["display"]))
                    {
                        this.tip8.Style["display"] = "block";

                    }
                    if ("none".Equals(this.QueryStatistics.Style["display"]))
                    {
                        this.QueryStatistics.Style["display"] = "block";

                    }
                    this.zonghechaxun.Style["display"] = "block";

                }
                else if ("员工工作量统计".Equals(limitsName))
                {
                    if ("none".Equals(this.tip9.Style["display"]))
                    {
                        this.tip9.Style["display"] = "block";

                    }
                    if ("none".Equals(this.QueryStatistics.Style["display"]))
                    {
                        this.QueryStatistics.Style["display"] = "block";

                    }
                    this.gongzuoliangtongji.Style["display"] = "block";

                }
                else if ("煎药机工作量统计".Equals(limitsName))
                {
                    if ("none".Equals(this.tip9.Style["display"]))
                    {
                        this.tip9.Style["display"] = "block";

                    }
                    if ("none".Equals(this.QueryStatistics.Style["display"]))
                    {
                        this.QueryStatistics.Style["display"] = "block";

                    }
                    this.jianyaogongzuoliangtongji.Style["display"] = "block";

                }
                else if ("包装机工作量统计".Equals(limitsName))
                {
                    if ("none".Equals(this.tip9.Style["display"]))
                    {
                        this.tip9.Style["display"] = "block";

                    }
                    if ("none".Equals(this.QueryStatistics.Style["display"]))
                    {
                        this.QueryStatistics.Style["display"] = "block";

                    }
                    this.baozhuanggongzuoliangtongji.Style["display"] = "block";

                }
                else if ("配送统计".Equals(limitsName))
                {
                    if ("none".Equals(this.tip10.Style["display"]))
                    {
                        this.tip10.Style["display"] = "block";

                    }
                    if ("none".Equals(this.QueryStatistics.Style["display"]))
                    {
                        this.QueryStatistics.Style["display"] = "block";

                    }
                    this.peisongtongji.Style["display"] = "block";

                }
                else if ("业务员业绩统计".Equals(limitsName))
                {
                    if ("none".Equals(this.tip11.Style["display"]))
                    {
                        this.tip11.Style["display"] = "block";

                    }
                    if ("none".Equals(this.QueryStatistics.Style["display"]))
                    {
                        this.QueryStatistics.Style["display"] = "block";

                    }
                    this.yejitongji.Style["display"] = "block";

                }
                else if ("综合预警".Equals(limitsName))
                {
                    if ("none".Equals(this.tip12.Style["display"]))
                    {
                        this.tip12.Style["display"] = "block";

                    }
                    if ("none".Equals(this.CentralMonitoring.Style["display"]))
                    {
                        this.CentralMonitoring.Style["display"] = "block";

                    }
                    this.zongheyujing.Style["display"] = "block";

                }
                else if ("煎药机监控".Equals(limitsName))
                {
                    if ("none".Equals(this.tip13.Style["display"]))
                    {
                        this.tip13.Style["display"] = "block";

                    }
                    if ("none".Equals(this.CentralMonitoring.Style["display"]))
                    {
                        this.CentralMonitoring.Style["display"] = "block";

                    }
                    this.yanyaojijiankong.Style["display"] = "block";

                }
                else if ("包装机监控".Equals(limitsName))
                {
                    if ("none".Equals(this.tip13.Style["display"]))
                    {
                        this.tip13.Style["display"] = "block";

                    }
                    if ("none".Equals(this.CentralMonitoring.Style["display"]))
                    {
                        this.CentralMonitoring.Style["display"] = "block";

                    }
                    this.baozhuangjijiankong.Style["display"] = "block";

                }
                else if ("泡药显示".Equals(limitsName))
                {
                    if ("none".Equals(this.tip14.Style["display"]))
                    {
                        this.tip14.Style["display"] = "block";

                    }
                    if ("none".Equals(this.CentralMonitoring.Style["display"]))
                    {
                        this.CentralMonitoring.Style["display"] = "block";

                    }
                    this.paoyaoxianshi.Style["display"] = "block";

                }
                else if ("煎药显示".Equals(limitsName))
                {
                    if ("none".Equals(this.tip14.Style["display"]))
                    {
                        this.tip14.Style["display"] = "block";

                    }
                    if ("none".Equals(this.CentralMonitoring.Style["display"]))
                    {
                        this.CentralMonitoring.Style["display"] = "block";

                    }
                    this.jianyaoxianshi.Style["display"] = "block";

                }
                else if ("发药显示".Equals(limitsName))
                {
                    if ("none".Equals(this.tip14.Style["display"]))
                    {
                        this.tip14.Style["display"] = "block";

                    }
                    if ("none".Equals(this.CentralMonitoring.Style["display"]))
                    {
                        this.CentralMonitoring.Style["display"] = "block";

                    }
                    this.fayaoxianshi.Style["display"] = "block";

                }
                else if ("抽检录入".Equals(limitsName))
                {
                    if ("none".Equals(this.tip15.Style["display"]))
                    {
                        this.tip15.Style["display"] = "block";

                    }
                    if ("none".Equals(this.CentralMonitoring.Style["display"]))
                    {
                        this.CentralMonitoring.Style["display"] = "block";

                    }
                    this.choujianluru.Style["display"] = "block";

                }
                else if ("抽检列表查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip15.Style["display"]))
                    {
                        this.tip15.Style["display"] = "block";

                    }
                    if ("none".Equals(this.CentralMonitoring.Style["display"]))
                    {
                        this.CentralMonitoring.Style["display"] = "block";

                    }
                    this.choujianchaxun.Style["display"] = "block";

                }
                else if ("员工信息".Equals(limitsName))
                {
                    if ("none".Equals(this.tip16.Style["display"]))
                    {
                        this.tip16.Style["display"] = "block";

                    }
                    if ("none".Equals(this.systemmanage.Style["display"]))
                    {
                        this.systemmanage.Style["display"] = "block";

                    }
                    this.yuangongxinxi.Style["display"] = "block";

                }
                else if ("权限管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip16.Style["display"]))
                    {
                        this.tip16.Style["display"] = "block";

                    }
                    if ("none".Equals(this.systemmanage.Style["display"]))
                    {
                        this.systemmanage.Style["display"] = "block";

                    }
                    this.quanxianguanli.Style["display"] = "block";

                }
                else if ("后台设置".Equals(limitsName))
                {
                    if ("none".Equals(this.tip16.Style["display"]))
                    {
                        this.tip16.Style["display"] = "block";

                    }
                    if ("none".Equals(this.systemmanage.Style["display"]))
                    {
                        this.systemmanage.Style["display"] = "block";

                    }
                    this.houtaishezhi.Style["display"] = "block";

                }
                else if ("界面管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip16.Style["display"]))
                    {
                        this.tip16.Style["display"] = "block";

                    }
                    if ("none".Equals(this.systemmanage.Style["display"]))
                    {
                        this.systemmanage.Style["display"] = "block";

                    }
                    this.jiemianguanli.Style["display"] = "block";

                }
                else if ("打印模块设置".Equals(limitsName))
                {
                    if ("none".Equals(this.tip16.Style["display"]))
                    {
                        this.tip16.Style["display"] = "block";

                    }
                    if ("none".Equals(this.systemmanage.Style["display"]))
                    {
                        this.systemmanage.Style["display"] = "block";

                    }
                    this.dayinmokuaishezhi.Style["display"] = "block";

                }
                else if ("医院管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip16.Style["display"]))
                    {
                        this.tip16.Style["display"] = "block";

                    }
                    if ("none".Equals(this.systemmanage.Style["display"]))
                    {
                        this.systemmanage.Style["display"] = "block";

                    }
                    this.yiyuanguanli.Style["display"] = "block";

                }
                else if ("结算方管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip16.Style["display"]))
                    {
                        this.tip16.Style["display"] = "block";

                    }
                    if ("none".Equals(this.systemmanage.Style["display"]))
                    {
                        this.systemmanage.Style["display"] = "block";

                    }
                    this.jiesuanfangguanli.Style["display"] = "block";

                }
                else if ("收件人管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip16.Style["display"]))
                    {
                        this.tip16.Style["display"] = "block";

                    }
                    if ("none".Equals(this.systemmanage.Style["display"]))
                    {
                        this.systemmanage.Style["display"] = "block";

                    }
                    this.shoujianrenguanli.Style["display"] = "block";

                }
                else if ("库房药房管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip16.Style["display"]))
                    {
                        this.tip16.Style["display"] = "block";

                    }
                    if ("none".Equals(this.systemmanage.Style["display"]))
                    {
                        this.systemmanage.Style["display"] = "block";

                    }
                    this.kufangyaofangguanli.Style["display"] = "block";

                }
                else if ("设备管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip16.Style["display"]))
                    {
                        this.tip16.Style["display"] = "block";

                    }
                    if ("none".Equals(this.systemmanage.Style["display"]))
                    {
                        this.systemmanage.Style["display"] = "block";

                    }
                    this.shebeiguanli.Style["display"] = "block";

                }
                else if ("煎药室管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip16.Style["display"]))
                    {
                        this.tip16.Style["display"] = "block";

                    }
                    if ("none".Equals(this.systemmanage.Style["display"]))
                    {
                        this.systemmanage.Style["display"] = "block";

                    }
                    this.jianyaoshiguanli.Style["display"] = "block";

                }
                else if ("物流key设置".Equals(limitsName))
                {
                    if ("none".Equals(this.tip16.Style["display"]))
                    {
                        this.tip16.Style["display"] = "block";

                    }
                    if ("none".Equals(this.systemmanage.Style["display"]))
                    {
                        this.systemmanage.Style["display"] = "block";

                    }
                    this.wuliukeyshezhi.Style["display"] = "block";

                }
                else if ("自动打印开关".Equals(limitsName))
                {
                    if ("none".Equals(this.tip16.Style["display"]))
                    {
                        this.tip16.Style["display"] = "block";

                    }
                    if ("none".Equals(this.systemmanage.Style["display"]))
                    {
                        this.systemmanage.Style["display"] = "block";

                    }
                    this.zidongdayinkaiguan.Style["display"] = "block";

                }
                    
                else if ("入库管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip17.Style["display"]))
                    {
                        this.tip17.Style["display"] = "block";

                    }
                    if ("none".Equals(this.StoreroomManagement.Style["display"]))
                    {
                        this.StoreroomManagement.Style["display"] = "block";

                    }
                    this.rukuguanli.Style["display"] = "block";

                }
                else if ("入库列表查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip17.Style["display"]))
                    {
                        this.tip17.Style["display"] = "block";

                    }
                    if ("none".Equals(this.StoreroomManagement.Style["display"]))
                    {
                        this.StoreroomManagement.Style["display"] = "block";

                    }
                    this.rukuliebiaochaxun.Style["display"] = "block";

                }
                else if ("调拨管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip17.Style["display"]))
                    {
                        this.tip17.Style["display"] = "block";

                    }
                    if ("none".Equals(this.StoreroomManagement.Style["display"]))
                    {
                        this.StoreroomManagement.Style["display"] = "block";

                    }
                    this.tiaoboguanli.Style["display"] = "block";

                }
                else if ("调拨列表查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip17.Style["display"]))
                    {
                        this.tip17.Style["display"] = "block";

                    }
                    if ("none".Equals(this.StoreroomManagement.Style["display"]))
                    {
                        this.StoreroomManagement.Style["display"] = "block";

                    }
                    this.tiaoboxinxiliebiao.Style["display"] = "block";

                }
                else if ("库存信息".Equals(limitsName))
                {
                    if ("none".Equals(this.tip17.Style["display"]))
                    {
                        this.tip17.Style["display"] = "block";

                    }
                    if ("none".Equals(this.StoreroomManagement.Style["display"]))
                    {
                        this.StoreroomManagement.Style["display"] = "block";

                    }
                    this.kucunxinxi.Style["display"] = "block";

                }
                else if ("库房盘点".Equals(limitsName))
                {
                    if ("none".Equals(this.tip17.Style["display"]))
                    {
                        this.tip17.Style["display"] = "block";

                    }
                    if ("none".Equals(this.StoreroomManagement.Style["display"]))
                    {
                        this.StoreroomManagement.Style["display"] = "block";

                    }
                    this.kufangpandian.Style["display"] = "block";

                }
                else if ("报损信息".Equals(limitsName))
                {
                    if ("none".Equals(this.tip17.Style["display"]))
                    {
                        this.tip17.Style["display"] = "block";

                    }
                    if ("none".Equals(this.StoreroomManagement.Style["display"]))
                    {
                        this.StoreroomManagement.Style["display"] = "block";

                    }
                    this.baosunxinxi.Style["display"] = "block";

                }
                else if ("报单查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip17.Style["display"]))
                    {
                        this.tip17.Style["display"] = "block";

                    }
                    if ("none".Equals(this.StoreroomManagement.Style["display"]))
                    {
                        this.StoreroomManagement.Style["display"] = "block";

                    }
                    this.baodanchaxun.Style["display"] = "block";
                }
                else if ("药房入库管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip18.Style["display"]))
                    {
                        this.tip18.Style["display"] = "block";

                    }
                    if ("none".Equals(this.StoreroomManagement.Style["display"]))
                    {
                        this.StoreroomManagement.Style["display"] = "block";

                    }
                    this.yaofangrukuguanli.Style["display"] = "block";

                }
                else if ("药房调拨管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip18.Style["display"]))
                    {
                        this.tip18.Style["display"] = "block";

                    }
                    if ("none".Equals(this.StoreroomManagement.Style["display"]))
                    {
                        this.StoreroomManagement.Style["display"] = "block";

                    }
                    this.yaofangtiaoboguanli.Style["display"] = "block";

                }
                else if ("药房调拨单列表查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip18.Style["display"]))
                    {
                        this.tip18.Style["display"] = "block";

                    }
                    if ("none".Equals(this.StoreroomManagement.Style["display"]))
                    {
                        this.StoreroomManagement.Style["display"] = "block";

                    }
                    this.yaofangtiaobodanchaxun.Style["display"] = "block";

                }
                else if ("药房库存信息".Equals(limitsName))
                {
                    if ("none".Equals(this.tip18.Style["display"]))
                    {
                        this.tip18.Style["display"] = "block";

                    }
                    if ("none".Equals(this.StoreroomManagement.Style["display"]))
                    {
                        this.StoreroomManagement.Style["display"] = "block";

                    }
                    this.yaofangkufangxinxi.Style["display"] = "block";

                }
                else if ("药房库房盘点".Equals(limitsName))
                {
                    if ("none".Equals(this.tip18.Style["display"]))
                    {
                        this.tip18.Style["display"] = "block";

                    }
                    if ("none".Equals(this.StoreroomManagement.Style["display"]))
                    {
                        this.StoreroomManagement.Style["display"] = "block";

                    }
                    this.yaofangkufangxinxi.Style["display"] = "block";

                }
                else if ("药房报损信息".Equals(limitsName))
                {
                    if ("none".Equals(this.tip18.Style["display"]))
                    {
                        this.tip18.Style["display"] = "block";

                    }
                    if ("none".Equals(this.StoreroomManagement.Style["display"]))
                    {
                        this.StoreroomManagement.Style["display"] = "block";

                    }
                    this.yaofangbaosunxinxi.Style["display"] = "block";

                }
                else if ("药房报单查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip18.Style["display"]))
                    {
                        this.tip18.Style["display"] = "block";

                    }
                    if ("none".Equals(this.StoreroomManagement.Style["display"]))
                    {
                        this.StoreroomManagement.Style["display"] = "block";

                    }
                    this.yaofangbaodanchaxun.Style["display"] = "block";

                }
                else if ("药品管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip19.Style["display"]))
                    {
                        this.tip19.Style["display"] = "block";

                    }
                    if ("none".Equals(this.StoreroomManagement.Style["display"]))
                    {
                        this.StoreroomManagement.Style["display"] = "block";

                    }
                    this.yaopinguanli.Style["display"] = "block";

                }
                else if ("药品匹配列表".Equals(limitsName))
                {
                    if ("none".Equals(this.tip20.Style["display"]))
                    {
                        this.tip20.Style["display"] = "block";

                    }
                    if ("none".Equals(this.StoreroomManagement.Style["display"]))
                    {
                        this.StoreroomManagement.Style["display"] = "block";

                    }
                    this.yaopinpipeiliebiao.Style["display"] = "block";

                }
                else if ("对账单".Equals(limitsName))
                {
                    if ("none".Equals(this.tip22.Style["display"]))
                    {
                        this.tip22.Style["display"] = "block";

                    }
                    if ("none".Equals(this.ReconciliationManagement.Style["display"]))
                    {
                        this.ReconciliationManagement.Style["display"] = "block";

                    }
                    this.duizhangdan.Style["display"] = "block";

                }
                else if ("对账列表".Equals(limitsName))
                {
                    if ("none".Equals(this.tip22.Style["display"]))
                    {
                        this.tip22.Style["display"] = "block";

                    }
                    if ("none".Equals(this.ReconciliationManagement.Style["display"]))
                    {
                        this.ReconciliationManagement.Style["display"] = "block";

                    }
                    this.duizhangliebiao.Style["display"] = "block";

                }
                else if ("订单列表".Equals(limitsName))
                {
                    if ("none".Equals(this.tip22.Style["display"]))
                    {
                        this.tip22.Style["display"] = "block";

                    }
                    if ("none".Equals(this.ReconciliationManagement.Style["display"]))
                    {
                        this.ReconciliationManagement.Style["display"] = "block";

                    }
                    this.dingdanliebiao.Style["display"] = "block";

                }
                else if ("物流信息".Equals(limitsName))
                {
                    if ("none".Equals(this.tip23.Style["display"]))
                    {
                        this.tip23.Style["display"] = "block";

                    }
                    if ("none".Equals(this.LogisticsManagement.Style["display"]))
                    {
                        this.LogisticsManagement.Style["display"] = "block";

                    }
                    this.wuliuxinxi.Style["display"] = "block";

                }
                else if ("物流信息".Equals(limitsName))
                {
                    if ("none".Equals(this.tip23.Style["display"]))
                    {
                        this.tip23.Style["display"] = "block";

                    }
                    if ("none".Equals(this.LogisticsManagement.Style["display"]))
                    {
                        this.LogisticsManagement.Style["display"] = "block";

                    }
                    this.wuliuxinxi.Style["display"] = "block";

                }
                else if ("拍照设置".Equals(limitsName))
                {
                    if ("none".Equals(this.tip24.Style["display"]))
                    {
                        this.tip24.Style["display"] = "block";

                    }
                    if ("none".Equals(this.systemmanage.Style["display"]))
                    {
                        this.systemmanage.Style["display"] = "block";

                    }
                    this.paizhaoguanli.Style["display"] = "block";

                }

            }

        }

    }
    
    /// <summary>
    /// 数据绑定
    /// </summary>
   
}