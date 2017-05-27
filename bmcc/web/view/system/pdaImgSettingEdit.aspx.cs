using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using ModelInfo;
using System.Data.SqlClient;

using System.Web.UI.HtmlControls;
using System.Web.Script.Services;
using System.Web.Services;


using System.Data;

public partial class view_system_pdaImgSettingEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        
        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            HospitalModel hm = new HospitalModel();

            DataTable dt = hm.findPdaImgSwitchById(id);
            if (dt.Rows.Count > 0)
            {
                this.idnum.Value = id + "";
                this.tiaoji.Value = dt.Rows[0]["tiaoji"].ToString();
                this.fuhe.Value = dt.Rows[0]["fuhe"].ToString();
                this.paoyao.Value = dt.Rows[0]["paoyao"].ToString();
                this.jianyao.Value = dt.Rows[0]["jianyao"].ToString();
                this.baozhuang.Value = dt.Rows[0]["baozhuang"].ToString();
                this.fahuo.Value = dt.Rows[0]["fahuo"].ToString();

            }

        }
    }


    [WebMethod]
    public static string editPdaImgSwitch(string id, string tiaoji, string fuhe, string paoyao, string jianyao, string baozhuang, string fahuo)
    {

        HospitalModel hm = new HospitalModel();
        int count = hm.editPdaImgSwitch(id, tiaoji, fuhe, paoyao, jianyao, baozhuang, fahuo);
        if (count > 0)
        {
            return "操作成功";
        }

        return "操作失败";
    }

}