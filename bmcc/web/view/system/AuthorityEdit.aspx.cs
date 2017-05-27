using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data;
using System.Web.Services;
public partial class view_system_AuthorityEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            EmployeeHandler eh = new EmployeeHandler();

            DataTable table = eh.findLimitsauthorityById(id);
            if(table.Rows.Count > 0){
                this.authorityText.Value = table.Rows[0]["limits"].ToString();

            }
            string role = getRoleText(table.Rows[0]["role"].ToString());

            this.authorityName.InnerText = "角色名称："+role;
            this.aid.Value = id + "";
        }
    }


    [WebMethod]
    public static string updateLimits(int id, string limits)
    {

        EmployeeHandler eh = new EmployeeHandler();
        int count = eh.updateLimits(id, limits);
        if (count > 0)
        {
            return "操作成功";

        }


        return "操作失败";
    }

    public string getRoleText(string role)
    {
        int a = Convert.ToInt32(role);
        if (a == 0)
        {
            return "管理员";
        }
        else if (a == 1)
        {
            return "调剂人员";
        }
        else if (a == 2)
        {
            return "复核人员";
        }
        else if (a == 3)
        {
            return "泡药人员";
        }

        else if (a == 4)
        {
            return "煎药人员";
        }
        else if (a == 5)
        {
            return "包装人员";
        }

        else if (a == 6)
        {
            return "发货人员";
        }
        else if (a == 7)
        {
            return "接方人员";
        }
        else if (a == 8)
        {
            return "配方人员";
        }
        else if (a == 9)
        {
            return "医院人员";
        }
        else if (a == 10)
        {
            return "医院登录人员";
        }
        else
        {
            return "无";
        }
    }
}