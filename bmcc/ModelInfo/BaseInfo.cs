using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SQLDAL;

namespace ModelInfo
{
    public class BaseInfo
    {
        /// <summary>
        /// 开始包装 插入命令表
        /// </summary>
        /// <param name="now">时间</param>
        /// <param name="db">DB层</param>
        /// <param name="bmNum">煎药单号</param>
        public static void Insert_PackCmd(DateTime now, DataBaseLayer db, string bmNum)
        {
            //开始包装指令
            string strtime = now.ToString("yyyy-MM-dd HH:mm:ss");//
            string sql12 = "select macaddress from machine where id = (select machineid from tisaneunit where pid ='" + bmNum + "')";
            SqlDataReader sr12 = db.get_Reader(sql12);
            string mac = "";

            if (sr12.Read())
            {
                mac = sr12["macaddress"].ToString();
            }

            string sql10 = "select *, RIGHT(CAST('000000000' + RTRIM(id) AS varchar(20)), 10)  as bNum from prescription where id = '" + bmNum + "'";
            SqlDataReader sr10 = db.get_Reader(sql10);
            // var strzero = "0000000000";
            // string tid = strzero.substring(0, 10 - Convert.ToInt32(DecoctingNum).length) + DecoctingNum;
            //  String str = String.format("%04d", youNumber);      
            string content = "";
            if (sr10.Read())
            {

                content = (Convert.ToInt32(sr10["dose"].ToString()) * Convert.ToInt32(sr10["takenum"].ToString())).ToString().PadLeft(2, '0') + bmNum.PadLeft(10, '0') + sr10["packagenum"].ToString().PadLeft(4, '0');

            }
            string sql11 = "insert into cmdtable(cmd,bmip,time) values('" + content + "','" + mac + "','" + strtime + "');";
            db.cmd_Execute(sql11);
        }

        /// <summary>
        /// 开始煎药 插入命令表
        /// </summary>
        /// <param name="now">开始煎药时间</param>
        /// <param name="db">db层</param>
        /// <param name="bmNum">煎药单号</param>
        public static void Insert_TisaneCmd(DateTime now, DataBaseLayer db, string bmNum)
        {
            //开始煎药指令

            string sql12 = "select macaddress from machine where id = (select machineid from tisaneunit where pid ='" + bmNum + "')";
            SqlDataReader sr12 = db.get_Reader(sql12);
            string mac = "";

            if (sr12.Read())
            {
                mac = sr12["macaddress"].ToString();
            }

            string sql10 = "select * from prescription where id = '" + bmNum + "'";
            SqlDataReader sr10 = db.get_Reader(sql10);
            string content = "";
            if (sr10.Read())
            {
                content = (Convert.ToInt32(sr10["dose"].ToString()) * Convert.ToInt32(sr10["takenum"].ToString())).ToString().PadLeft(2, '0') + sr10["decscheme"].ToString().PadLeft(2, '0') + bmNum.PadLeft(10, '0') + sr10["oncetime"].ToString().PadLeft(2, '0') + sr10["twicetime"].ToString().PadLeft(2, '0');

            }
            string sql11 = "insert into cmdtable(cmd,bmip,time) values('" + content + "','" + mac + "','" + now + "');";
            db.cmd_Execute(sql11);
        }

    }
}
