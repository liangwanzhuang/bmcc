using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLDAL;
using System.Data.SqlClient;
using System.Data;

namespace ModelInfo
{
    public class ClearingpartyModel
    {
        public DataBaseLayer db = new DataBaseLayer();

        #region 查询所有结算方信息
        ///// <summary>
        ///// 查询所有结算方信息
        ///// </summary>
        ///// <param name=""></param>
        ///// <returns>SqlDataReader对象</returns>
        public SqlDataReader findClearingpartyAll()
        {
            string sql = "select * from Clearingparty";

            return db.get_Reader(sql);
        }

        public DataTable findNumById(int id)
        {
            string sql = "select ClearPName from Clearingparty where ID =" + id;

            return db.get_DataTable(sql);
        }
        #endregion
        #region
        /// <summary>
        /// 查询结算方信息
        /// </summary>
        /// <param > ClearPName</param>
        /// <returns>dt</returns>

        public DataTable findClearingpartyInfo(int ClearPName)
        {
            string sql = "select id ,ClearPName,ConPerson,ConPhone,Address,PerSetInformation,Remarks ,GenDecoct from  Clearingparty where 1=1";

            if (ClearPName!=0)
            {
           sql+="and id = " + ClearPName+"";
          
          }

            DataTable dt = db.get_DataTable(sql);

            return dt;

        }
        #endregion
       #region 删除包装信息
        public bool deleteClearingpartyInfo(int nCId)
        {
            string strSql = "delete from Clearingparty where id =" + nCId;
            int n = db.cmd_Execute(strSql);
            return true;
        }
        #endregion
        #region 修改结算方信息
        public int updateClearingpartyInfo(int id, string ClearPName, string ConPerson, string ConPhone, string Address,  string Remarks, string GenDecoct)
        {
            //string strSql = "select id,JobNum,EName,Role,Sex,Age,Phone,Address,Nation,Origin from  Employee where id = " + id;

            int end = 0;

            string sql = "";
            string str = "select ConPerson from Clearingparty where id != " + id + " and ConPerson = '" + ConPerson + "'";
            SqlDataReader sr = db.get_Reader(str);
            if (sr.Read())
            {
                end = 0;
            }
            else
            {
                string str1 = "select ClearPName from Clearingparty where id != " + id + " and ClearPName = '" + ClearPName + "'";
                SqlDataReader sr1 = db.get_Reader(str1);
                if (sr1.Read()) {

                    end = 0;
                }
                else
                {
                    sql = "update Clearingparty set ClearPName='" + ClearPName + "',ConPerson='" + ConPerson + "',ConPhone='" + ConPhone + "',Address='" + Address + "',Remarks='" + Remarks + "',GenDecoct='" + GenDecoct + "' where id = " + id + "";
                    end = db.cmd_Execute(sql);
                }
            }


            return end;
        }
        #endregion 
    }
    }
