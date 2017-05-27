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





public partial class view_system_Backgdsetwarningupdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum.Value = Request.QueryString["id"].ToString();
          //  Bubbleinfo bl = new Bubbleinfo();
            HospitalModel hm = new HospitalModel();

            DataTable dt = hm.findwarningtimebyid(id);

           // bubbleperson.Value = dt.Rows[0]["bp"].ToString();

            // hospitalname.Value = dt.Rows[0][""].ToString();

            // bubbleman.Value = dt.Rows[0]["bp"].ToString();

            checkwarning.Value = dt.Rows[0]["checkwarning"].ToString();
            adjustwarning.Value = dt.Rows[0]["adjustwarning"].ToString();
            recheckwarning.Value = dt.Rows[0]["recheckwarning"].ToString();
            bubblewarning.Value = dt.Rows[0]["bubblewarning"].ToString();
            tisanewarning.Value = dt.Rows[0]["tisanewarning"].ToString();
            packwarning.Value = dt.Rows[0]["packwarning"].ToString();
            deliverwarning.Value = dt.Rows[0]["deliverwarning"].ToString();

            if ("1".Equals(dt.Rows[0]["type"].ToString()))
            {

                checkwarning_li.Style["display"] = "none";
            }
        }     

    }



    [WebMethod]
    public static int updatewarninginfoByid(string id, string checkwarning, string adjustwarning, string recheckwarning, string bubblewarning, string tisanewarning, string packwarning, string deliverwarning)
    {

        HospitalModel hm = new HospitalModel();
        int end = hm.updatewarningtimeinfo(id, checkwarning, adjustwarning, recheckwarning, bubblewarning, tisanewarning, packwarning, deliverwarning);
        //int result = hm.addwarningtime(hospitalId, checkwarning, adjustwarning, recheckwarning, bubblewarning, tisanewarning, packwarning, deliverwarning);



        return end;
    }











}