using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLDAL;
using System.Data;
using System.Data.SqlClient;

namespace ModelInfo
{

    public class HospitalHandler
    {
        public DataBaseLayer db = new DataBaseLayer();
        public int AddHospital(string hname, string hshortname, string hnum, string contacter, string phone, string address, string pricetype)
        {

            int end = 0;
            DataBaseLayer db = new DataBaseLayer();
            string tate = "select  hnum   from hospital where hnum = '" + hnum + "' ";
            SqlDataReader tate1 = db.get_Reader(tate);
            if (tate1.Read())
            {
                end = 0;
            }
            else
            {
                /*string tate2 = "select  settler   from hospital where settler = '" + settler + "' ";
                SqlDataReader tatea = db.get_Reader(tate2);
                if (tatea.Read())
                {
                    end = 0;
                }
                else
                {*/
                    //泡药显示   DrugDisplayState 煎药显示   ChineseDisplayState 发药显示  DrugSendDisplayState
                string strSql = "insert into hospital(hnum,hname,hshortname,contacter,phone,address,pricetype, DrugDisplayState,ChineseDisplayState,DrugSendDisplayState) ";
                    strSql += "values ('" + hnum + "','" + hname + "','" + hshortname + "','" + contacter + "',";
                    strSql += "'" + phone + "','" + address + "','" + pricetype + "','0','0','0')";



                    end = db.cmd_Execute(strSql);
               // }
            }

            return end;


        }

        public DataTable SearchHospital(string hname, string hnum)
        {
            string strSql = "select id,hnum,hname,Hshortname,contacter,phone,address,pricetype,settler from hospital where 1=1 ";
            if (hnum != "0" && hnum != "")
            {
                strSql += "and  hnum ='" + hnum + "'";
            }
            if (hname != "0" && hname != "")
            {
                strSql += "and  id ='" + hname + "'";
            }

            DataBaseLayer db = new DataBaseLayer();

            DataTable dt = db.get_DataTable(strSql);

            return dt;
        }



        public DataTable PrintRecipeInfo()
        {
            string strSql = "SELECT ID, customid, delnum, barcodescan, Hospitalid, Pspnum, decmothed, name,sex,age,phone,address, department," +
              "inpatientarea, ward, sickbed, diagresult, dose, takemethod, takenum, packagenum, decscheme, oncetime, twicetime," +
                "soakwater, soaktime, labelnum, remark, doctor, footnote, getdrugtime, getdrugnum, ordertime, curstate, dotime," +
                "doperson, dtbcompany, dtbaddress, dtbphone, dtbtype, takeway ,(select hname from hospital as h where h.id = p.hospitalid) as hspname FROM prescription as p";

            DataBaseLayer db = new DataBaseLayer();




            DataTable dt = db.get_DataTable(strSql);


            return dt;

        }

        #region 查询医院信息通过ID
        public DataTable findHospitalInfo(int id)
        {
            string strSql = "select * from  hospital where id = " + id;

            DataTable dt = db.get_DataTable(strSql);

            return dt;
        }
        #endregion
        #region 修改医院信息
        public int updateHospitalInfo(int id, string hname, string hshortname, string hnum, string contacter, string phone, string address, string pricetype)
        {
            //string strSql = "select id,JobNum,EName,Role,Sex,Age,Phone,Address,Nation,Origin from  Employee where id = " + id;

            int end = 0;
            DataBaseLayer db = new DataBaseLayer();
            string tate = "select  hnum   from hospital where hnum = '" + hnum + "' and id != '"+id+"'";
            SqlDataReader tate1 = db.get_Reader(tate);
            if (tate1.Read())
            {
                end = 0;
            }
            else
            {
               /* string tate2 = "select  settler   from hospital where settler = '" + settler + "' and id != '" + id + "'";
                SqlDataReader tatea = db.get_Reader(tate2);
                if (tatea.Read())
                {
                    end = 0;
                }
                else
                {*/


                    string sql = "update hospital set hname='" + hname + "',hshortname='" + hshortname + "',hnum='" + hnum + "',contacter='" + contacter + "',phone='" + phone + "',address='" + address + "',pricetype='" + pricetype + "' where id = " + id + "";
                    end = db.cmd_Execute(sql);
               // }
            }

                return end;
            }
        #endregion
        }
    }
