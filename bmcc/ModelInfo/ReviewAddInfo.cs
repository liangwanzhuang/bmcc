using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLDAL;
using System.Data.SqlClient;
using System.Data;

namespace ModelInfo
{
    public class ReviewAddInfo
    {
        public DataBaseLayer db = new DataBaseLayer();
        #region 添加复核信息
        public int AddAudit(int DecoctingNum, string ReviewPer)
        {
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;//获取当前时间
            String sql = "";
            int end = 0;
            string per = ReviewPer.Substring(6);

            string employeeid = "";
            string str3 = "select id from employee where EmNumAName ='" + ReviewPer + "'";
            SqlDataReader sr3 = db.get_Reader(str3);

            if (sr3.Read())
            {

                employeeid = sr3["id"].ToString();

            }





            string str = "select id  from prescription where  id in (select prescriptionId from adjust where status = 1 ) and id not in (select pid from InvalidPrescription) and  id = '" + DecoctingNum + "'";
            SqlDataReader sr = db.get_Reader(str);

            if (sr.Read())
            {
                string result = sr["id"].ToString();
                int a = Convert.ToInt32(result);

                string str1 = "select * from Audit where pid = '" + a + "'";
                SqlDataReader sr1 = db.get_Reader(str1);

                if (sr1.Read())
                {
                    sql = "";
                }
                else
                {

                    sql = "INSERT INTO [Audit](AuditTime,pid,ReviewPer,AuditStatus,employeeId) VALUES('" + currentTime + "','" + a + "','" + per + "',1,'" + employeeid + "')";
                    if (db.cmd_Execute(sql) == 1)
                    {

                        sql = "update prescription set doperson ='" + per + "', curstate = '复核'  where id = '" + a + "'";
                    
                    }
                }
            }
            else
            {
                sql = "";

            }

            if (sql == "")
            {
                end = 0;
            }
            else
            {
                end = db.cmd_Execute(sql);
            }
            return end; ;
        }
        #endregion
        #region 更新时获取复核信息
        public DataTable getAuditInfo(int id)
        {

            string sql = "select   hospitalid,pspnum  ,(select AuditTime from Audit where pid = '" + id + "') as AuT from prescription   where id = '" + id + "'";
            DataBaseLayer db = new DataBaseLayer();

            DataTable dt = db.get_DataTable(sql);


            return dt;
        }
        #endregion
        #region 更新复核信息
        public int updateAuditInfo(int id, string AuditTime, int hospitalSelect, string pspnum)
        {
            
            int end = 0;
            int a = 0;
            string sql = "";
            string str = "select id from prescription where hospitalid = '" + hospitalSelect + "' and pspnum = '" + pspnum + "'";
            SqlDataReader sr = db.get_Reader(str);
            if (sr.Read())
            {
                string result = sr["id"].ToString();
                a = Convert.ToInt32(result);
                sql = "update Audit set AuditTime = '" + AuditTime + "',pid='" + a + "' where pid = '" + id + "' ";
                end = db.cmd_Execute(sql);
            }
            else
            {
                end = 0;
            }


            return end;
        }
        #endregion
        #region 删除复核信息
        public int deleteRRecipeInfo(int id)
        {
            string strSql = "delete from Audit where pid = '" + id + "'";
            int n = db.cmd_Execute(strSql);


            return n;
        }
        #endregion
        #region 通过权限查询人员
        public SqlDataReader findNameAll()
        {
            string sql = "select * from  Employee where Role ='2' or  Role ='0' ";

            return db.get_Reader(sql);
        }

        #endregion

    }
}
