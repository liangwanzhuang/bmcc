using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLDAL;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace ModelInfo
{
    public class PackingModel
    {
        public DataBaseLayer db = new DataBaseLayer();

        #region 查询所有包装信息
        ///// <summary>
        ///// 查询所有包装信息
        ///// </summary>
        ///// <param name="">id</param>
        ///// <returns>SqlDataReader对象</returns>
        public SqlDataReader findPackingAll()
        {
            string sql = "select * from Packing ";

            return db.get_Reader(sql);
        }
        public DataTable findNumById(int id)
        {
            string sql = "select DecoctingNum from Packing where ID =" + id;

            return db.get_DataTable(sql);
        }
        #endregion
        #region
        public DataTable findPackingInfo(int userid, string date)
        {

            string sql = "select p.ID,p.Pspnum,p.customid,p.delnum,p.Hospitalid,p.name,p.sex,p.age,p.phone,p.address,p.department,p.inpatientarea,p.ward,p.sickbed,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,"
             + "p.diagresult,p.dose,p.takenum,p.getdrugtime,p.getdrugnum,p.takemethod,p.decscheme,p.oncetime,p.twicetime,p.packagenum,p.dotime,p.doperson,p.dtbcompany,p.dtbaddress,p.dtbphone,p.dtbtype,p.soakwater,p.soaktime,p.labelnum,p.remark,p.doctor,p.footnote,p.ordertime,p.curstate"
             + ",pk.Fpactate pstatus,pk.Starttime Starttime,pk.PacTime PacTime,( select machinename  from machine   where  mark =1 and unitnum in (select unitnum from machine where id in (select machineid from tisaneunit as t where t.pid =p.id))) as packmachine  from prescription as p inner join Packing pk on p.id=pk.DecoctingNum where pk.employeeId=" + userid + " and CONVERT(varchar, pk.Starttime, 120) like '%" + date + "%' order by p.ID desc";
            DataTable dt = db.get_DataTable(sql);

            return dt;
        }


        /// <summary>
        /// 查询包装信息
        /// </summary>
        /// <param > Fpactate,  PacTime, Pacpersonnel</param>
        /// <returns>dt</returns>

        public DataTable findPackingInfo(String Fpactate, String Pacpersonnel, String PacTime, String StartTime)
        {
            //string strSQL = "SELECT  distinct c.ID, c.DecoctingNum, c.warningstatus, c.Pacpersonnel, c.PacTime, c.Fpactate, c.Starttime,  p.customid,p.delnum,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,p.Hospitalid,p.name,p.sex,p.age,p.phone,p.address,p.department,p.inpatientarea,p.ward,p.sickbed,";
            //strSQL += "p.diagresult,p.Pspnum,(select machinename from machine where id = (select machineid from tisaneinfo where pid = p.id )) as machineid,p.dose,p.takenum,p.getdrugtime,p.getdrugnum,p.takemethod,p.decscheme,p.oncetime,p.RemarksA,p.RemarksB,p.twicetime,p.packagenum,p.dotime,p.doperson,p.dtbcompany,p.dtbaddress,p.dtbphone,p.dtbtype,p.soakwater,p.soaktime,p.labelnum,p.remark,p.doctor,p.footnote,p.ordertime,p.curstate,( select machinename  from machine   where  mark =1 and unitnum in (select unitnum from machine where id in (select machineid from tisaneunit as t where t.pid =c.DecoctingNum))) as packmachine";
            //strSQL += " from prescription as p join     Packing as c on p.id=c.DecoctingNum where DecoctingNum not in (select pid from InvalidPrescription)";
            string strSQL = "SELECT  distinct c.ID, c.DecoctingNum,  c.Pacpersonnel, c.PacTime, c.Fpactate, c.Starttime,  (select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,p.Pspnum,p.name,";
            strSQL += "(select machinename from machine where id = (select machineid from tisaneinfo where pid = p.id )) as machineid,p.dose,p.takenum,p.takemethod,p.packagenum,( select m.machinename  from machine as m , tisaneunit as t  where  m.mark =1 and  m.id = t.machineid and t.pid =c.DecoctingNum)as packmachine";
            strSQL += " from prescription as p join     Packing as c on p.id=c.DecoctingNum where DecoctingNum not in (select pid from InvalidPrescription)";
            if (Fpactate != "")
            {
                strSQL += "and  c.Fpactate ='" + Fpactate + "'";
            }

            if (Pacpersonnel != "0" && Pacpersonnel != "")
            {
                strSQL += "and c.Pacpersonnel='" + Pacpersonnel + "'";
            }

            if (StartTime != "0")
            {
                //strSQL += "and Convert(varchar,PacTime ,120)   like '" + PacTime + "%' ";

                DateTime d = Convert.ToDateTime(StartTime);
                string strS = d.ToString("yyyy/MM/dd 00:00:00");
                strSQL += "and PacTime >='" + strS + "'";

            }


            if (PacTime != "0")
            {
                //strSQL += "and Convert(varchar,PacTime ,120)   like '" + PacTime + "%' ";

                DateTime d4 = Convert.ToDateTime(PacTime);
                string strE = d4.ToString("yyyy/MM/dd 23:59:59");
                strSQL += "and PacTime  <='" + strE + "'";

            }



            DataTable dt = db.get_DataTable(strSQL);

            return dt;



        }
        public DataTable findPackingInfoDao(String Fpactate, String Pacpersonnel, String PacTime)
        {



            //string strSQL = "SELECT  distinct c.ID, c.DecoctingNum, c.warningstatus, c.Pacpersonnel, c.PacTime, c.Fpactate, c.Starttime,  p.customid,p.delnum,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,p.Hospitalid,p.name,p.sex,p.age,p.phone,p.address,p.department,p.inpatientarea,p.ward,p.sickbed,";
            //strSQL += "p.diagresult,p.Pspnum,(select machinename from machine where id = (select machineid from tisaneinfo where pid = p.id )) as machineid,p.dose,p.takenum,p.getdrugtime,p.getdrugnum,p.takemethod,p.decscheme,p.oncetime,p.RemarksA,p.RemarksB,p.twicetime,p.packagenum,p.dotime,p.doperson,p.dtbcompany,p.dtbaddress,p.dtbphone,p.dtbtype,p.soakwater,p.soaktime,p.labelnum,p.remark,p.doctor,p.footnote,p.ordertime,p.curstate,( select machinename  from machine   where  mark =1 and unitnum in (select unitnum from machine where id in (select machineid from tisaneunit as t where t.pid =c.DecoctingNum))) as packmachine";
            //strSQL += " from prescription as p join     Packing as c on p.id=c.DecoctingNum where DecoctingNum not in (select pid from InvalidPrescription)";
            string strSQL = "SELECT  distinct c.ID, c.DecoctingNum,  c.Pacpersonnel, c.PacTime,case c.Fpactate when '0' then '开始包装' when '1' then '包装完成' else c.Fpactate end , c.Starttime,  (select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,p.Pspnum,p.name,";
            strSQL += "(select machinename from machine where id = (select machineid from tisaneinfo where pid = p.id )) as machineid,p.dose,p.takenum,p.takemethod,p.packagenum,( select machinename  from machine   where  mark =1 and unitnum in (select unitnum from machine where id in (select machineid from tisaneunit as t where t.pid =c.DecoctingNum))) as packmachine";
            strSQL += " from prescription as p join     Packing as c on p.id=c.DecoctingNum where DecoctingNum not in (select pid from InvalidPrescription)";
            if (Fpactate != "")
            {
                strSQL += "and  c.Fpactate ='" + Fpactate + "'";
            }

            if (Pacpersonnel != "0" && Pacpersonnel != "")
            {
                strSQL += "and c.Pacpersonnel='" + Pacpersonnel + "'";
            }
            if (PacTime != "0")
            {
                strSQL += "and Convert(varchar,PacTime ,120)   like '" + PacTime + "%' ";
            }



            DataTable dt = db.get_DataTable(strSQL);

            return dt;



        }
        #endregion
        #region 删除包装信息
        public int deletePackingInfo(int nPId)
        {
            string strSql = "delete from Packing where id =" + nPId;
            int n = db.cmd_Execute(strSql);
            return n;
        }
        #endregion

        public DataTable findPackingInfo(int id)
        {
            string strSql = "select id ,DecoctingNum,Pacpersonnel,PacTime,Fpactate,Starttime,Timeset from Packing where id = " + id;

            DataTable dt = db.get_DataTable(strSql);

            return dt;
        }
        #region
        public bool UpdatePackingInfo(PackingInfo ri)
        {
            string strSql = "Update Packing set DecoctingNum='" + ri.strDecoctingNum + "',  Pacpersonnel ='" + ri.strPacpersonnel + "',  PacTime=" + ri.strPacTime + ",  Fpactate=" + ri.strFpactate;
            strSql += ", Starttime='" + ri.strStarttime + " , Timeset='" + ri.strTimeset + "'";

            return true;
        }
        #endregion
        #region 根据条形码查询
        public DataTable findPackingBybarcode(string barcode)
        {
            DataBaseLayer db = new DataBaseLayer();
            string sql = "select * from packing where DecoctingNum='" + barcode + "'";

            DataTable dt = db.get_DataTable(sql);
            return dt;

        }
        #endregion

        public int updatePackinginfo(int id, int status, string endDate, String tisaneNum)
        {
            DataBaseLayer db = new DataBaseLayer();
            string sql = "update packing set Fpactate='" + status + "',PacTime='" + endDate + "' where id=" + id;


            int count = db.cmd_Execute(sql);
            if (count > 0)
            {
                string sql2 = "update prescription set curstate = '包装完成'  where id = '" + tisaneNum + "'";
                db.cmd_Execute(sql2);
                string sql3 = "INSERT INTO [Delivery](DecoctingNum,Sendstate) VALUES('" + tisaneNum + "','0')";
                db.cmd_Execute(sql3);
                string sqlStr = "update machine set status='空闲',pid='' where id=(SELECT   c.id FROM machine AS c INNER JOIN (SELECT   a.id, a.roomnum, a.mark, a.unitnum FROM      machine AS a INNER JOIN (SELECT machineid FROM tisaneunit WHERE   (pid = '" + tisaneNum + "')) AS b ON a.id = b.machineid) AS d ON d.roomnum = c.roomnum AND d.unitnum = c.unitnum AND c.mark = 1)";
                db.cmd_Execute(sqlStr);
            }




            return count;

        }
        #region 添加
        public int addPacking(int userid, string wordDate, string barcode, string tisaneNum, string imgname, string userName)
        {
            string sql = "insert into packing(employeeId,Starttime,barcode,DecoctingNum,imgname,Fpactate,Pacpersonnel) values('" + userid + "','" + wordDate + "','" + barcode + "','" + tisaneNum + "','" + imgname + "','0" + "','" + userName + "')";
            string sql2 = "update prescription set doperson ='" + userName + "',curstate = '开始包装'  where id = '" + tisaneNum + "'";
            db.cmd_Execute(sql2);
            int count = db.cmd_Execute(sql);
            if (count > 0)
            {
                BaseInfo.Insert_PackCmd(Convert.ToDateTime(wordDate), db, tisaneNum);//开始包装
                string sqlStr = "update machine set status='空闲',pid='' where id=(select machineid from tisaneunit where pid='" + tisaneNum + "')";
                db.cmd_Execute(sqlStr);
                sqlStr = "update machine set status='忙碌',pid='" + tisaneNum + "' where id=(SELECT   c.id FROM machine AS c INNER JOIN (SELECT   a.id, a.roomnum, a.mark, a.unitnum FROM      machine AS a INNER JOIN (SELECT machineid FROM tisaneunit WHERE   (pid = '" + tisaneNum + "')) AS b ON a.id = b.machineid) AS d ON d.roomnum = c.roomnum AND d.unitnum = c.unitnum AND c.mark = 1)";
                db.cmd_Execute(sqlStr);
            }
            return count;

        }
        #endregion

    }
}
