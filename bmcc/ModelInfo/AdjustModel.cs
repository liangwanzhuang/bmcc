using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SQLDAL;
using System.Data;
namespace ModelInfo
{
    public class AdjustModel
    {
        public DataBaseLayer db = new DataBaseLayer();


        #region 删除调剂信息
        ///// <summary>
        ///// 查询所有调剂信息
        ///// </summary>
        ///// <param name="id">id</param>
        ///// <returns>int对象</returns>
        public int delAdjust(int id)
        {
            string sql = "delete from adjust where id="+id;

            return db.cmd_Execute(sql);

        }
        #endregion

        #region 更新调剂信息
        ///// <summary>
        ///// 更新调剂信息
        ///// </summary>
        ///// <param name="id">id</param>
        ///// <returns>int对象</returns>
        public int updateAdjust(int id,string wordcontent, string wordDate, string workload)
        {
            string sql = "update adjust set wordcontent='" + wordcontent + "',wordDate='" + wordDate + "',workload='" + workload + "' where id=" + id;

            return db.cmd_Execute(sql);

        }
        ///// <summary>
        ///// 更新调剂状态
        ///// </summary>
        ///// <param name="id">id</param>
        ///// <returns>int对象</returns>
        public int updateAdjust(int id,int status,string endDate,string userName,string tisaneNum)
        {
            string sql = "update adjust set status='" + status + "',endDate='"+endDate+"' where id=" + id;
            string sql2 = "update prescription set curstate = '调剂完成'  where id = '" + tisaneNum + "'";;
            db.cmd_Execute(sql2);
            return db.cmd_Execute(sql);

        }
        #endregion
         #region 添加调剂信息
        ///// <summary>
        ///// 更新调剂信息
        ///// </summary>
        ///// <param name="id">id</param>
        ///// <returns>int对象</returns>
        public int addAdjust( string barcode, string SwapPer)
        {
           // string sql = "insert into adjust(employeeId,wordDate,barcode,wordcontent) values('" + userid + "','" + wordDate + "','" + barcode + "','" + wordcontent + "')";

           // return db.cmd_Execute(sql);
          
             int  barcode1 =Convert.ToInt32( barcode.Substring(4,10));
            String sql = "";
            int end = 0;
            string per = SwapPer.Substring(6);
            string employeeid = "";
            string str3 = "select id from employee where EmNumAName ='" + SwapPer + "'";
            SqlDataReader sr3 = db.get_Reader(str3);

            if (sr3.Read())
            {

                employeeid = sr3["id"].ToString();

            }

            string str1 = " select  prescriptionId  from PrescriptionCheckState  where  prescriptionId not in (select pid from InvalidPrescription) and  checkStatus =1 and  prescriptionId =" + barcode1;
           SqlDataReader sr1 = db.get_Reader(str1);

            if (sr1.Read())
           {
               string str = "select prescriptionId from adjust as a  where prescriptionId =" + barcode1;
                SqlDataReader sr = db.get_Reader(str);
                System.DateTime now = new System.DateTime();
                now = System.DateTime.Now;
                if (sr.Read())
                {
                    string str2 = "select status from adjust  where  prescriptionId=" + barcode1;
                    SqlDataReader sr2 = db.get_Reader(str2);
                    if (sr2.Read())
                    {
                        if (sr2["status"].ToString() == "0")
                        {
                            AdjustModel am = new AdjustModel();
                            DataTable dt = am.findAdjustBybarcode(barcode1.ToString());

                            sql = "update adjust set status= 1 ,endDate='" + now + "' where prescriptionId=" + barcode1;
                            if (db.cmd_Execute(sql) == 1)
                            {
                                sql = "update prescription set curstate = '调剂完成'  where id = '" + barcode1 + "'";

                            }
                        }
                        else {

                            sql = "";
                        }
                    }
                }else
                {
                    sql = "insert into adjust(wordDate,barcode,wordcontent,prescriptionId,SwapPer,employeeId) values('" + now + "','" + barcode + "',' 调剂 ','" + barcode1 + "','" + per + "','" + employeeid + "')";
                    if (db.cmd_Execute(sql) == 1)
                    {
                        sql = "update prescription set doperson ='" + per + "',curstate = '开始调剂'  where id = '" + barcode1 + "'";
                     //db.cmd_Execute(sql2);
                    }
                }
            }
           else {
                sql = "";
           }

            if (sql== "")
            {

                end = 0;   
            }
            else
            {
                end = db.cmd_Execute(sql);
               
            }
            return end; ;

        }
        public int addAdjust(int userid, string wordDate, string barcode, string wordcontent, string tisaneNum, string imgname, string userName)
        {
            string sql = "insert into adjust(employeeId,wordDate,barcode,wordcontent,prescriptionId,imgname,SwapPer) values('" + userid + "','" + wordDate + "','" + barcode + "','" + wordcontent + "','" + tisaneNum + "','" + imgname + "','" + userName + "')";
            string sql2 = "update prescription set doperson ='" + userName + "',curstate = '开始调剂'  where id = '" + tisaneNum + "'";
            db.cmd_Execute(sql2);
            return db.cmd_Execute(sql);

        }

        
        #endregion
        
        #region 查询调剂信息
        ///// <summary>
        ///// 查询所有调剂信息
        ///// </summary>
        ///// <param name="status">0未完成,1已完成,2全部</param>
        ///// <param name="begindate">开始日期</param>
        ///// <param name="enddate">结束日期</param>
        ///// <param name="eName">员工姓名</param>
        ///// <returns>DataTable对象</returns>
        public DataTable findRecipeInfo(int status,string begindate,string enddate,string eName)
        {
            string sql = "select  max(id) as id,SwapPer,convert(varchar, wordDate, 111) as wordDate,'调剂' AS wordcontent, count(wordDate)  as workload from adjust as a  where 1=1";

            if (status != 2 )
            {

                sql += " and a.status=" + status;

            }
            if (begindate != null && begindate.Length > 0)
            {
                DateTime d = Convert.ToDateTime(begindate);
                string strB = d.ToString("yyyy/MM/dd  00:00:00");
                sql += " and a.wordDate>='" + strB + "'";

            }
            if (enddate != null && enddate.Length > 0)
            {
                DateTime d4 = Convert.ToDateTime(enddate);
                string strE = d4.ToString("yyyy/MM/dd 23:59:59");
                sql += " and a.wordDate<='" + strE + "'";

            }


            if (eName != null && eName.Length > 0)
            {
                sql += " and a.SwapPer='" + eName + "'";

            }
            sql += "GROUP BY  SwapPer,CONVERT(varchar, wordDate, 111)";

            DataTable dt = db.get_DataTable(sql);
            return dt;

        }
        public DataTable findRecipeInfo()
        {
            string sql = "select  '调剂' AS wordcontent,convert(varchar, wordDate, 111) as wordDate,count(wordDate) AS workload from adjust as a left join employee as e on a.employeeId=e.id where 1=1 GROUP BY CONVERT(varchar, a.wordDate, 111)";

            


            DataTable dt = db.get_DataTable(sql);
            return dt;

        }
        ///// <summary>
        ///// 查询所有调剂信息
        ///// </summary>
        ///// <param name="status">0未完成,1已完成,2全部</param>
        ///// <param name="begindate">开始日期</param>
        ///// <param name="enddate">结束日期</param>
        ///// <param name="eName">员工姓名</param>
        ///// <returns>DataTable对象</returns>
        public DataTable findAdjustById(int id)
        {
            string sql = "select a.id,wordcontent,convert(varchar, wordDate, 111) as wordDate,workload,employeeId,prescriptionId,status from adjust as a left join employee as e on a.employeeId=e.id where a.id="+id;

            DataTable dt = db.get_DataTable(sql);
            return dt;

        }

        ///// <summary>
        ///// 根据条码查询调剂信息
        ///// </summary>
        ///// <param name="status">0未完成,1已完成,2全部</param>
        ///// <param name="begindate">开始日期</param>
        ///// <param name="enddate">结束日期</param>
        ///// <param name="eName">员工姓名</param>
        ///// <returns>DataTable对象</returns>
        public DataTable findAdjustBybarcode(string barcode)
        {
            string sql = "select a.id,wordcontent,convert(varchar, wordDate, 111) as wordDate,workload,employeeId,prescriptionId,status,barcode from adjust as a  where a.prescriptionId='" + barcode + "'";

            DataTable dt = db.get_DataTable(sql);
            return dt;

        }
        #endregion
        #region 通过权限查询调剂人员
        public SqlDataReader findNameAll()
        {
            string sql = "select * from  Employee where Role ='1' or  Role ='0' ";

            return db.get_Reader(sql);
        }
        public DataTable findNumById(string SwapPer)
        {
            string sql = "select EName from Employee where JobNum ='"+SwapPer+"'";

            return db.get_DataTable(sql);
        }
        #endregion
    }
}
