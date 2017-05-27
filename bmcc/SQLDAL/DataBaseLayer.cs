using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Data.OleDb;
using System.Security.Cryptography;


namespace SQLDAL
{
    public class DataBaseLayer
    {
        //private static dbControl m_objDBcontrol = null;

        public static string strSql = ConfigurationManager.ConnectionStrings["SKConnection"].ConnectionString;//数据库连接字符串
        //public static string strSql = "Data Source=118.244.237.123;Initial Catalog=rinfo;user id=sa;password=dalianvideo;MultipleActiveResultSets=true";

        private SqlConnection myConn = null;

        #region 构造函数
        public DataBaseLayer()
        {
            myConn = new SqlConnection(strSql);
        }
        #endregion

        #region 实例化数据库操作对象
        ///// <summary>
        ///// 实例化数据库操作对象
        ///// </summary>
        ///// <param name="connectionString">连接数据库的字符串</param>
        ///// <returns>数据库控制对象</returns>
        //public static dbControl GetDBOpterator(string connectionString)
        //{
        //    try
        //    {
        //        if (m_objDBcontrol == null)
        //        {
        //            strSql = connectionString;
        //            m_objDBcontrol = new dbControl();
        //        }
        //        return m_objDBcontrol;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        #endregion

        #region  执行存储过程要返回值的（Enum)
        /// <summary>
        /// 要执行的SQL语句类型
        /// </summary>
        public enum sp_ReturnType
        {
            /// <summary>
            /// 返回值为单个DataTable
            /// </summary>
            DataTable,

            /// <summary>
            /// 受影响行数
            /// </summary>
            AffectedRowsCount

        }
        #endregion

        #region 通过带有参数的Sql语句获取DataReader[推荐使用此方法]， SqlLDataReader类型
        /// <summary>
        /// 通过带有参数的SQL语句获取SqlDataReader对象
        /// </summary>
        /// <param name="strSql">带有参数的SQL语句,如："select * from Sample where id=@id"</param>
        /// <param name="paramsArr">可以是一个参数数组</param>
        /// <returns>SqlDataReader对象</returns>
        public SqlDataReader get_Reader(string strSql, params  SqlParameter[] paramArray)
        {
            SqlCommand myCmd = new SqlCommand();
            //添加SqlCommand对象的参数
            foreach (SqlParameter temp in paramArray)
            {
                myCmd.Parameters.Add(temp);
            }

            //利用SqlCommand对象的ExecuteReader()方法获取SqlDataReader;
            try
            {
                myCmd.Connection = myConn;
                myCmd.CommandText = strSql;
                ConnectionManage(true);
                return myCmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                myCmd.Dispose();
            }
        }
        #endregion

        #region 通过不带有参数的Sql语句获取DataReader[不推荐使用此方法]， SQLDataReader类型
        /// <summary>
        /// 通过不带有参数的Sql语句获取DataReader[不推荐使用此方法]
        /// </summary>
        /// <param name="strSql">要获取DataReader执行的Sql语句</param>
        /// <returns>SqlDataReader对象</returns>
        public SqlDataReader get_Reader(string strSql)
        {
            SqlCommand myCmd = new SqlCommand();
            myCmd.CommandText = strSql;
            myCmd.Connection = myConn;
            try
            {
                ConnectionManage(true);
                return myCmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                myCmd.Dispose();
            }
        }
        #endregion

        #region 通过带有参数的Sql语句获取DataTable[推荐使用此方法]，返回值：DataTable类型
        /// <summary>
        /// 通过带有参数的Sql语句获取DataTable[推荐使用此方法]
        /// </summary>
        /// <param name="strSql">含参数的带有查询功能的Sql语句
        /// </param>
        /// <param name="paramArray"></param>
        /// <returns>DataTable对象</returns>
        public DataTable get_DataTable(string strSql, params SqlParameter[] paramArray)
        {
            DataTable dtTemp = new DataTable();
            SqlCommand myCmd = new SqlCommand();
            SqlDataAdapter myDataAdapter = null;
            try
            {
                myCmd.Connection = myConn;
                myCmd.CommandText = strSql;

                //添加SqlCommand对象的参数
                foreach (SqlParameter temp in paramArray)
                {
                    myCmd.Parameters.Add(temp);
                }

                myDataAdapter = new SqlDataAdapter(myCmd);
                ConnectionManage(true);
                myDataAdapter.Fill(dtTemp);
                return dtTemp;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                ConnectionManage(false);
                myDataAdapter.Dispose();
                dtTemp.Dispose();
                myCmd.Dispose();
            }
        }
        #endregion

        #region 通过Sql语句获取DataTable[不推荐使用此方法],返回值：DataTable类型
        /// <summary>
        ///  通过Sql语句获取DataTable[不推荐使用此方法]
        /// </summary>
        /// <param name="strSql">要获取DataTable执行的Sql语句</param>
        /// <returns>DataTable对象</returns>
        public DataTable get_DataTable(string strSql)
        {
            DataTable dtTemp = new DataTable();
            SqlCommand myCmd = new SqlCommand();
            SqlDataAdapter myDataAdapter = null;
            try
            {
                myCmd.Connection = myConn;
                myCmd.CommandText = strSql;
                myDataAdapter = new SqlDataAdapter(strSql, myConn);
                ConnectionManage(true);

                myDataAdapter.Fill(dtTemp);
                return dtTemp;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                //myDataAdapter.Dispose();
                ConnectionManage(false);
                myCmd.Dispose();
                //dtTemp.Dispose();
            }
        }
        #endregion

        #region 用带参数的Sql语句执行具有添加、修改、删除功能的Sql语句[推荐使用此方法],返回值类型：int类型
        /// <summary>
        /// 用带参数的Sql语句执行具有添加、修改、删除功能的Sql语句[推荐使用此方法]
        /// </summary>
        /// <param name="strSql">带有参数的SQL语句,如："update Sample set Column1=@column1 where id=@id"</param>
        /// <param name="paramArray">可以是一个参数数组</param>
        /// <returns>Sql语句影响的行数</returns>
        public int cmd_Execute(string strSql, params SqlParameter[] paramArray)
        {
            SqlCommand myCmd = new SqlCommand();
            try
            {
                myCmd.Connection = myConn;
                myCmd.CommandText = strSql;

                myCmd.Parameters.Clear();

                //添加SqlCommand对象的参数
                foreach (SqlParameter temp in paramArray)
                {
                    myCmd.Parameters.Add(temp);
                }

                ConnectionManage(true);
                return myCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                myCmd.Dispose();
                ConnectionManage(false);
            }
        }


        #endregion

        #region 执行具有添加、修改、删除功能的Sql语句[不推荐使用此方法] int类型
        /// <summary>
        /// 执行具有添加、修改、删除功能的Sql语句[不推荐使用此方法]
        /// 如:"update Sample set column1='value' where column2='value'"
        /// 此种方法无法防止SQL注入，除非你手动过滤其非法字符
        /// </summary>
        /// <param name="strSql">要执行的Sql语句</param>
        /// <returns>SQL语句影响的行数</returns>
        public int cmd_Execute(string strSql)
        {
            SqlCommand myCmd = new SqlCommand();
            try
            {
                myCmd.CommandType = CommandType.Text;
                myCmd.Connection = myConn;
                myCmd.CommandText = strSql;
                ConnectionManage(true);
                return myCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                myCmd.Dispose();
                ConnectionManage(false);
            }
        }
        #endregion

        #region 获取单行单列的值
        /// <summary>
        /// 获取单行单列的值,这种查询适合于用聚合函数查询时的情况
        /// </summary>
        /// <param name="strSql">SQL语句,如select count(*) from TableName</param>
        /// <returns>第一行第一列的值</returns>
        public string cmd_ExecuteScalar(string strSql)
        {
            SqlCommand myCmd = new SqlCommand();
            try
            {
                myCmd.CommandType = CommandType.Text;
                myCmd.Connection = myConn;
                myCmd.CommandText = strSql;
                ConnectionManage(true);
                return myCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                myCmd.Dispose();
                ConnectionManage(false);
            }
        }
        #endregion

        #region  执行返回值不是表的的存储过程
        /// <summary>
        /// 执行 返回值不是表的且无参数的存储过程
        /// </summary>
        /// <param name="str_ProcudureName">存储过程名</param>
        /// <returns>返回该存储过程影响的行数</returns>
        public int sp_Execute(string str_ProcudureName)
        {
            SqlCommand myCmd = new SqlCommand();
            try
            {
                myCmd.CommandText = str_ProcudureName;
                myCmd.CommandType = CommandType.StoredProcedure;
                myCmd.Connection = myConn;
                ConnectionManage(true);
                return myCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                myCmd.Dispose();
                ConnectionManage(false);
            }
        }
        #endregion

        #region 执行返回值为单个数据表的存储过程
        /// <summary>
        /// 执行带有参数的存储过程
        /// 如果该存储过程返回数据表，则返回值为数据表
        /// 否则，返回该存储过程影响的行数
        /// </summary>
        /// <param name="str_ProcudureName">存储过程名称</param>
        /// <param name="paramArray">参数数组</param>
        /// <returns>DataTable对象</returns>
        public Object sp_Execute(string str_ProcudureName, sp_ReturnType returnType, params SqlParameter[] paramArray)
        {
            SqlParameter s = new SqlParameter();
            SqlCommand myCmd = new SqlCommand();
            SqlDataAdapter myDataAdapter;
            try
            {
                myCmd.CommandText = str_ProcudureName;
                myCmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter temp in paramArray)
                {
                    myCmd.Parameters.Add(temp);
                }

                ConnectionManage(true);

                myCmd.Connection = myConn;
                //返回值为DataTable
                if (returnType == sp_ReturnType.DataTable)
                {
                    myDataAdapter = new SqlDataAdapter(myCmd);

                    DataTable dtTemp = new DataTable();
                    myDataAdapter.Fill(dtTemp);
                    if (dtTemp != null)
                        return dtTemp;
                    else
                        return null;
                }
                else
                {
                    //返回值为受影响的行数
                    return myCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myCmd.Dispose();
                ConnectionManage(false);
            }
        }
        #endregion

        #region 执行具有输出参数的存储过程
        /// <summary>
        /// 执行带有输出参数的存储过程
        /// </summary>
        /// <param name="str_ProcudureName">存储过程名称</param>
        /// <param name="outParam">输出参数的名称</param>
        /// <param name="paramArray">参数数组</param>
        /// <returns>Object类型</returns>
        public object sp_Execute(string str_ProcudureName, string outParam, params SqlParameter[] paramArray)
        {
            SqlCommand myCmd = new SqlCommand();
            try
            {
                myCmd.CommandText = str_ProcudureName;
                myCmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter temp in paramArray)
                {
                    myCmd.Parameters.Add(temp);
                }

                ConnectionManage(true);
                myCmd.Connection = myConn;
                myCmd.ExecuteNonQuery();
                return myCmd.Parameters[outParam].Value;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                myCmd.Dispose();
                ConnectionManage(false);
            }
        }
        #endregion

        #region Connection对象处理

        /// <summary>
        /// 关于对Connection对象的处理
        /// </summary>
        /// <param name="IsOpen">True：打开，False:关闭</param>
        private void ConnectionManage(bool IsOpen)
        {
            if (IsOpen == true)
            {
                if (myConn.State != ConnectionState.Open)
                {
                    myConn.Open();
                }
            }
            else if (IsOpen == false)
            {
                if (myConn.State != ConnectionState.Closed)
                {
                    myConn.Close();
                }
            }
        }

        #endregion




        public string GetMD5(string strPwd)
        {
            string pwd = "";
            //实例化一个md5对象
            MD5 md5 = MD5.Create();
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(strPwd));
            //翻转生成的MD5码  


            // s.Reverse();
            //通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            //只取MD5码的一部分，这样恶意访问者无法知道取的是哪几位
            for (int i = 3; i < s.Length - 1; i++)
            {
                //将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符
                //进一步对生成的MD5码做一些改造
                pwd = pwd + (s[i] < 198 ? s[i] + 28 : s[i]).ToString("X");
            }
            return pwd;
        }


    }



}
