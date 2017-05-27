using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data.SqlClient;
using System.Web.Services;
using System.Data;
using System.IO;

using System.Data.OleDb;
using System.Web.Security;

public partial class view_system_Addmachine : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        meRoomModel mrm = new meRoomModel();
        SqlDataReader sdr = mrm.findmachineroom();
        
        if (sdr != null)
        {
            while (sdr.Read())
            {

                this.meRoomName.Items.Add(new ListItem(sdr["meRoomName"].ToString(), sdr["id"].ToString()));

            }
        }



        if (!IsPostBack)
        {
            this.typemachine.Items.Add(new ListItem("煎药机", "0"));
            this.typemachine.Items.Add(new ListItem("包装机", "1"));
            
        }


    }


    [WebMethod]
    public static string addMachineinfo(string meRoomName, string unitnum, string machinenum, string macaddresss, string typeofmachine, string status, string openstatus, string healthystatus, string disinfectionstatus, string checkman, string checktime, string equipmenttype)
    {
        string result = "0";

        meRoomModel rm = new meRoomModel();

        int sdr = rm.addmachineinfo(meRoomName, unitnum, typeofmachine, machinenum, macaddresss, status, openstatus, healthystatus, disinfectionstatus, checkman, checktime, equipmenttype);
        if (sdr == 1)
        {
            result = "1";
       }
       else
       {
            result = "2";
        }

        return result;

    }


}