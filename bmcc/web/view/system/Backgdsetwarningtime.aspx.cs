using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using SQLDAL;



using System.Data.SqlClient;

using System.Web.UI.HtmlControls;
using System.Web.Script.Services;
using System.Web.Services;


public partial class view_system_Backgdsetwarningtime : System.Web.UI.Page
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

    }


     [WebMethod]
    public static int addwarningtime(string hospitalId, string checkwarning, string adjustwarning, string recheckwarning, string bubblewarning, string tisanewarning, string packwarning, string deliverwarning, string type)
    {


         


        HospitalModel hm = new HospitalModel();
        int result = hm.addwarningtime(hospitalId, checkwarning, adjustwarning, recheckwarning, bubblewarning, tisanewarning, packwarning, deliverwarning, type);




        return result;

    }








}