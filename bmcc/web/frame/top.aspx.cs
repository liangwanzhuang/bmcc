using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQLDAL;
using System.Text;
using ModelInfo;
using SQLDAL;
using System.Data.SqlClient;
using System.Data;


public partial class frame_top : System.Web.UI.Page
{

    /// <summary>
    /// 当前用户ID
    /// </summary>
    public string currentUserID = "";


    /// <summary>
    /// 当前用户真实姓名
    /// </summary>
    public string currentUserRealName = "";

    /// <summary>
    /// 权限表
    /// </summary>
   

    /// <summary>
    /// 头部菜单
    /// </summary>
    public StringBuilder menuInfo = new StringBuilder();

    /// <summary>
    /// 页面加载事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        string usernamebar = "";
        //AvertInjection.OnLoadCheck();
        if (Session["userNamebar"] != null)
        {
            string usernamechange = "";
             usernamebar = Session["userNamebar"].ToString();
            EmployeeModel em = new EmployeeModel();
            SqlDataReader sdr = em.findusernamebyjobnum(usernamebar);
            if (sdr.Read())
            {
                usernamechange =sdr["EName"].ToString();
            }


            username.InnerText = usernamechange;
        }
          EmployeeHandler eh = new EmployeeHandler();
           SqlDataReader sdr3 = eh.findrolebyname(usernamebar);
        string role = "";
        if(sdr3.Read()){
             role = sdr3["Role"].ToString();
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

        }
        else
        {
            checkAuthority(role);

        }
        /*
        if (role == "7")//7
        {
            this.tip1.Style["display"] = "block";

        }

        if (role == "8")//2
        {
            this.tip1.Style["display"] = "block";
           
        }
        if (role == "1")//3
        {
            this.tip1.Style["display"] = "block";
           
        }
        if (role == "2")//4
        {
            this.tip1.Style["display"] = "block";
           
        }
        if (role == "3")//5
        {
            this.tip1.Style["display"] = "block";
           
        }
        if (role == "4")//6
        {
            this.tip1.Style["display"] = "block";
           
        }
        if (role == "5")//7
        {
            //this.tip23.Style["display"] = "block";
            this.tip1.Style["display"] = "block";
        }
        if (role == "6")//7
        {

            this.tip1.Style["display"] = "block";
           // this.tip22.Style["display"] = "block";
        }
        if (role == "9")//9 14
        {
            this.tip2.Style["display"] = "block";
            this.tip3.Style["display"] = "block";
           
            
        }
        if (role == "10")//23
        {
            this.tip7.Style["display"] = "block";
            
        }
    */
        //else 
        //{
        //    Response.Redirect("../noRight.aspx");
        //}
        //if (Session["currentUserRealName"] != null)
        //{
        //    currentUserRealName = Session["currentUserRealName"].ToString();
        //}
        //if (!IsPostBack)
        //{
           
        //}
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
                    if ("none".Equals(this.tip1.Style["display"]))
                    {
                        this.tip1.Style["display"] = "block";

                    }


                }
                else if ("接方查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip1.Style["display"]))
                    {
                        this.tip1.Style["display"] = "block";

                    }
                    

                }
                else if ("药品匹配".Equals(limitsName))
                {
                    if ("none".Equals(this.tip1.Style["display"]))
                    {
                        this.tip1.Style["display"] = "block";

                    }

                }
                else if ("处方审核".Equals(limitsName))
                {
                    if ("none".Equals(this.tip1.Style["display"]))
                    {
                        this.tip1.Style["display"] = "block";

                    }

                }
                else if ("处方打印".Equals(limitsName))
                {
                    if ("none".Equals(this.tip1.Style["display"]))
                    {
                        this.tip1.Style["display"] = "block";

                    }
                }
                else if ("配方查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip1.Style["display"]))
                    {
                        this.tip1.Style["display"] = "block";

                    }

                }
                else if ("调剂查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip1.Style["display"]))
                    {
                        this.tip1.Style["display"] = "block";

                    }

                }
                else if ("调剂统计".Equals(limitsName))
                {
                    if ("none".Equals(this.tip1.Style["display"]))
                    {
                        this.tip1.Style["display"] = "block";

                    }

                }
                else if ("复核查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip1.Style["display"]))
                    {
                        this.tip1.Style["display"] = "block";

                    }

                }
                else if ("工作记录查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip1.Style["display"]))
                    {
                        this.tip1.Style["display"] = "block";

                    }


                }
                else if ("泡药信息".Equals(limitsName))
                {
                    if ("none".Equals(this.tip1.Style["display"]))
                    {
                        this.tip1.Style["display"] = "block";

                    }


                }
                else if ("简要机组分配".Equals(limitsName))
                {
                    if ("none".Equals(this.tip1.Style["display"]))
                    {
                        this.tip1.Style["display"] = "block";

                    }


                }
                else if ("煎药信息".Equals(limitsName))
                {
                    if ("none".Equals(this.tip1.Style["display"]))
                    {
                        this.tip1.Style["display"] = "block";

                    }


                }
                else if ("机组信息".Equals(limitsName))
                {
                    if ("none".Equals(this.tip1.Style["display"]))
                    {
                        this.tip1.Style["display"] = "block";

                    }


                }
                else if ("查询功能".Equals(limitsName))
                {
                    if ("none".Equals(this.tip1.Style["display"]))
                    {
                        this.tip1.Style["display"] = "block";

                    }


                }
                else if ("包装管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip1.Style["display"]))
                    {
                        this.tip1.Style["display"] = "block";

                    }


                }
                else if ("发货管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip1.Style["display"]))
                    {
                        this.tip1.Style["display"] = "block";

                    }


                }
                else if ("综合查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip2.Style["display"]))
                    {
                        this.tip2.Style["display"] = "block";

                    }

                }
                else if ("员工工作量统计".Equals(limitsName))
                {
                    if ("none".Equals(this.tip2.Style["display"]))
                    {
                        this.tip2.Style["display"] = "block";

                    }

                }
                else if ("煎药机工作量统计".Equals(limitsName))
                {
                    if ("none".Equals(this.tip2.Style["display"]))
                    {
                        this.tip2.Style["display"] = "block";

                    }

                }
                else if ("包装机工作量统计".Equals(limitsName))
                {
                    if ("none".Equals(this.tip2.Style["display"]))
                    {
                        this.tip2.Style["display"] = "block";

                    }

                }
                else if ("配送统计".Equals(limitsName))
                {
                    if ("none".Equals(this.tip2.Style["display"]))
                    {
                        this.tip2.Style["display"] = "block";

                    }

                }
                else if ("业务员业绩统计".Equals(limitsName))
                {
                    if ("none".Equals(this.tip2.Style["display"]))
                    {
                        this.tip2.Style["display"] = "block";

                    }

                }
                else if ("综合预警".Equals(limitsName))
                {
                    if ("none".Equals(this.tip3.Style["display"]))
                    {
                        this.tip3.Style["display"] = "block";

                    }

                }
                else if ("煎药机监控".Equals(limitsName))
                {
                    if ("none".Equals(this.tip3.Style["display"]))
                    {
                        this.tip3.Style["display"] = "block";

                    }

                }
                else if ("包装机监控".Equals(limitsName))
                {
                    if ("none".Equals(this.tip3.Style["display"]))
                    {
                        this.tip3.Style["display"] = "block";

                    }
                }
                else if ("泡药显示".Equals(limitsName))
                {
                    if ("none".Equals(this.tip3.Style["display"]))
                    {
                        this.tip3.Style["display"] = "block";

                    }

                }
                else if ("煎药显示".Equals(limitsName))
                {
                    if ("none".Equals(this.tip3.Style["display"]))
                    {
                        this.tip3.Style["display"] = "block";

                    }

                }
                else if ("发药显示".Equals(limitsName))
                {
                    if ("none".Equals(this.tip3.Style["display"]))
                    {
                        this.tip3.Style["display"] = "block";

                    }

                }
                else if ("抽检录入".Equals(limitsName))
                {
                    if ("none".Equals(this.tip3.Style["display"]))
                    {
                        this.tip3.Style["display"] = "block";

                    }

                }
                else if ("抽检列表查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip3.Style["display"]))
                    {
                        this.tip3.Style["display"] = "block";

                    }

                }
                else if ("员工信息".Equals(limitsName))
                {
                    if ("none".Equals(this.tip4.Style["display"]))
                    {
                        this.tip4.Style["display"] = "block";

                    }

                }
                else if ("权限管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip4.Style["display"]))
                    {
                        this.tip4.Style["display"] = "block";

                    }

                }
                else if ("后台设置".Equals(limitsName))
                {
                    if ("none".Equals(this.tip4.Style["display"]))
                    {
                        this.tip4.Style["display"] = "block";

                    }
                }
                else if ("界面管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip4.Style["display"]))
                    {
                        this.tip4.Style["display"] = "block";

                    }

                }
                else if ("打印模块设置".Equals(limitsName))
                {
                    if ("none".Equals(this.tip4.Style["display"]))
                    {
                        this.tip4.Style["display"] = "block";

                    }

                }
                else if ("医院管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip4.Style["display"]))
                    {
                        this.tip4.Style["display"] = "block";

                    }

                }
                else if ("结算方管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip4.Style["display"]))
                    {
                        this.tip4.Style["display"] = "block";

                    }

                }
                else if ("收件人管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip4.Style["display"]))
                    {
                        this.tip4.Style["display"] = "block";

                    }

                }
                else if ("库房药房管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip4.Style["display"]))
                    {
                        this.tip4.Style["display"] = "block";

                    }

                }
                else if ("设备管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip4.Style["display"]))
                    {
                        this.tip4.Style["display"] = "block";

                    }

                }
                else if ("煎药室管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip4.Style["display"]))
                    {
                        this.tip4.Style["display"] = "block";

                    }

                }
                else if ("物流key设置".Equals(limitsName))
                {
                    if ("none".Equals(this.tip4.Style["display"]))
                    {
                        this.tip4.Style["display"] = "block";

                    }

                }
                else if ("自动打印开关".Equals(limitsName))
                {
                    if ("none".Equals(this.tip4.Style["display"]))
                    {
                        this.tip4.Style["display"] = "block";

                    }

                }
                else if ("拍照设置".Equals(limitsName))
                {
                    if ("none".Equals(this.tip4.Style["display"]))
                    {
                        this.tip4.Style["display"] = "block";

                    }

                }
                else if ("入库管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip5.Style["display"]))
                    {
                        this.tip5.Style["display"] = "block";

                    }

                }
                else if ("入库列表查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip5.Style["display"]))
                    {
                        this.tip5.Style["display"] = "block";

                    }

                }
                else if ("调拨管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip5.Style["display"]))
                    {
                        this.tip5.Style["display"] = "block";

                    }

                }
                else if ("调拨列表查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip5.Style["display"]))
                    {
                        this.tip5.Style["display"] = "block";

                    }

                }
                else if ("库存信息".Equals(limitsName))
                {
                    if ("none".Equals(this.tip5.Style["display"]))
                    {
                        this.tip5.Style["display"] = "block";

                    }

                }
                else if ("库房盘点".Equals(limitsName))
                {
                    if ("none".Equals(this.tip5.Style["display"]))
                    {
                        this.tip5.Style["display"] = "block";

                    }

                }
                else if ("报损信息".Equals(limitsName))
                {
                    if ("none".Equals(this.tip5.Style["display"]))
                    {
                        this.tip5.Style["display"] = "block";

                    }

                }
                else if ("报单查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip5.Style["display"]))
                    {
                        this.tip5.Style["display"] = "block";

                    }
                }
                else if ("药房入库管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip5.Style["display"]))
                    {
                        this.tip5.Style["display"] = "block";

                    }

                }
                else if ("药房调拨管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip5.Style["display"]))
                    {
                        this.tip5.Style["display"] = "block";

                    }

                }
                else if ("药房调拨单列表查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip5.Style["display"]))
                    {
                        this.tip5.Style["display"] = "block";

                    }

                }
                else if ("药房库存信息".Equals(limitsName))
                {
                    if ("none".Equals(this.tip5.Style["display"]))
                    {
                        this.tip5.Style["display"] = "block";

                    }

                }
                else if ("药房库房盘点".Equals(limitsName))
                {
                    if ("none".Equals(this.tip5.Style["display"]))
                    {
                        this.tip5.Style["display"] = "block";

                    }

                }
                else if ("药房报损信息".Equals(limitsName))
                {
                    if ("none".Equals(this.tip5.Style["display"]))
                    {
                        this.tip5.Style["display"] = "block";

                    }

                }
                else if ("药房报单查询".Equals(limitsName))
                {
                    if ("none".Equals(this.tip5.Style["display"]))
                    {
                        this.tip5.Style["display"] = "block";

                    }

                }
                else if ("药品管理".Equals(limitsName))
                {
                    if ("none".Equals(this.tip5.Style["display"]))
                    {
                        this.tip5.Style["display"] = "block";

                    }

                }
                else if ("药品匹配列表".Equals(limitsName))
                {
                    if ("none".Equals(this.tip5.Style["display"]))
                    {
                        this.tip5.Style["display"] = "block";

                    }

                }
                else if ("对账单".Equals(limitsName))
                {
                    if ("none".Equals(this.tip6.Style["display"]))
                    {
                        this.tip6.Style["display"] = "block";

                    }

                }
                else if ("对账列表".Equals(limitsName))
                {
                    if ("none".Equals(this.tip6.Style["display"]))
                    {
                        this.tip6.Style["display"] = "block";

                    }

                }
                else if ("订单列表".Equals(limitsName))
                {
                    if ("none".Equals(this.tip6.Style["display"]))
                    {
                        this.tip6.Style["display"] = "block";

                    }

                }
                else if ("物流信息".Equals(limitsName))
                {
                    if ("none".Equals(this.tip7.Style["display"]))
                    {
                        this.tip7.Style["display"] = "block";

                    }

                }
                else if ("物流信息".Equals(limitsName))
                {
                    if ("none".Equals(this.tip7.Style["display"]))
                    {
                        this.tip7.Style["display"] = "block";

                    }

                }

            }

        }

    }


}