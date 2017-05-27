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

public partial class view_system_Updatemachine : System.Web.UI.Page
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

        if (Request.QueryString["id"] != null)
        {

            string roomid = "0";
            int id = Convert.ToInt16(Request.QueryString["id"]);
            idnum.Value = Request.QueryString["id"].ToString();

            meRoomModel mrm1 = new meRoomModel();
            DataTable dt = mrm1.findmachienInfobyid(id);
            
            SqlDataReader sdr2 = mrm1.findmachineroomidbymachineroom(dt.Rows[0]["roomnum"].ToString());
            if (sdr2.Read())
            {
                roomid = sdr2["id"].ToString();
            }


            //hospitalname.Value = dt.Rows[0]["hname"].ToString();
            meRoomName.Value = roomid;
            unitnum.Value = dt.Rows[0]["unitnum"].ToString();
            typemachine.Value = dt.Rows[0]["mark"].ToString();
            machinenum.Value = dt.Rows[0]["machinename"].ToString();
            macaddresss.Value = dt.Rows[0]["macaddress"].ToString();
            status.Value = dt.Rows[0]["status"].ToString();
            openstatus.Value = dt.Rows[0]["usingstatus"].ToString();
            healthystatus.Value = dt.Rows[0]["healthstatus"].ToString();
            disinfectionstatus.Value = dt.Rows[0]["disinfectionstatus"].ToString();
            checkman.Value = dt.Rows[0]["checkman"].ToString();
            checktime.Value = dt.Rows[0]["checktime"].ToString();
            equipmenttype.Value = dt.Rows[0]["equipmenttype"].ToString();
           
        }     

    }


    [WebMethod]
    public static string updateMachineinfo(string meRoomName, string unitnum, string machinenum, string macaddresss, string typeofmachine, string idnum, string status, string openstatus, string disinfectionstatus, string healthystatus, string checkman, string checktime, string equipmenttype)
    {
        string result = "0";

        meRoomModel rm = new meRoomModel();
        DataTable machienInfo = rm.findmachienInfobyid(Convert.ToInt32(idnum));
        if (machienInfo.Rows.Count > 0)
        {
            if (machienInfo.Rows[0]["unitnum"].ToString() != unitnum && typeofmachine == "1")
            {
                DataTable machienInfos = rm.findMachineByMarkAndUnitnum("1", unitnum);
                if (machienInfos.Rows.Count > 0)
                {
                    return "4";
                }
                else
                {
                    int sdr = rm.updatemachineinfo(meRoomName, unitnum, typeofmachine, machinenum, macaddresss, idnum, status, openstatus, disinfectionstatus, healthystatus, checkman, checktime, equipmenttype);
                    if (sdr == 2)
                    {
                        result = "2";
                    }
                    else
                    {
                        result = "1";
                    }

                }
            }
            else
            {
                int sdr = rm.updatemachineinfo(meRoomName, unitnum, typeofmachine, machinenum, macaddresss, idnum, status, openstatus, disinfectionstatus, healthystatus, checkman, checktime, equipmenttype);
                if (sdr == 2)
                {
                    result = "2";
                }
                else
                {
                    result = "1";
                }
            }
            

        }
        else
        {
            result = "3";
        }


        

        return result;

    }

}