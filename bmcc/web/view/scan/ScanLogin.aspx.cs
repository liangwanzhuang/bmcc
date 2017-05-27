using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Text;
using System.Data;
public partial class view_scan_ScanLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        EmployeeModel em = new EmployeeModel();

        string JobNum = Request.QueryString["JobNum"].ToString();
        DataTable dataTable = em.findEmployeeByJobNum(JobNum);
        HospitalModel hm = new HospitalModel();

        DataTable dt = hm.findPdaImgSwitchById(1);

        if (dataTable.Rows.Count > 0)
        {
            Response.Write("{\"code\":\"0\",\"msg\":\"操作成功\",\"data\":" + DataTableToJson.ToJson(dataTable) + ",\"imgswitch\":" + DataTableToJson.ToJson(dt) + "}");
        }
        else
        {
            Response.Write("{\"code\":\"1\",\"msg\":\"操作失败\"}");
        }
        

    }
}