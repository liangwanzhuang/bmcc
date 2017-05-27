using System;
using System.Data.SqlClient;
using SQLDAL;
using System.Data;

namespace ModelInfo
{
    public class HospitalModel
    {
        public DataBaseLayer db = new DataBaseLayer();

        #region 查询所有医院名称
        ///// <summary>
        ///// 查询所有医院名称
        ///// </summary>
        ///// <param name=""></param>
        ///// <returns>SqlDataReader对象</returns>
        public SqlDataReader findHospitalAll()
        {
            string sql = "select * from Hospital";

            return db.get_Reader(sql);
        }

        public DataTable findNumById(string  id)
        {
            string sql = "select hnum from Hospital where ID =" + id;

            return db.get_DataTable(sql);
        }
        public DataTable findNumById(int id)
        {
            string sql = "select hnum from Hospital where ID =" + id;

            return db.get_DataTable(sql);
        }

        public SqlDataReader findHospitalnamebyid(string id)
        {
            string sql = "select hname from Hospital where ID =" + id;
            return db.get_Reader(sql);
        }
        #endregion




        //添加医院报警时间

        public int addwarningtime(string hospitalid, string checkwarning, string adjustwarning, string recheckwarning, string bubblewarning, string tisanewarning, string packwarning, string deliverwarning, string type)
        {





            int end=0;
            string hospitalname = "";

            string sql3 = "select * from warning where hospitalid = '" + hospitalid + "' and type='"+type+"'";
            SqlDataReader sr2 = db.get_Reader(sql3);
            if (sr2.Read())
            {
                end = 0;
            }else{
            



            string sql2 = "select hname from hospital where id ='" + hospitalid + "'";

            SqlDataReader sr = db.get_Reader(sql2);
            if (sr.Read())
            {
              hospitalname =  sr["hname"].ToString();
            }



            string sql = "INSERT INTO [warning](hospitalid,hospitalname,checkwarning,adjustwarning,recheckwarning,bubblewarning,tisanewarning,packwarning,deliverwarning,type) VALUES('" + hospitalid + "','" + hospitalname + "','" + checkwarning + "','" + adjustwarning + "','" + recheckwarning + "','" + bubblewarning + "','" + tisanewarning + "','" + packwarning + "','" + deliverwarning + "','" + type + "')";

            end = db.cmd_Execute(sql);

            }
            return end;

    }

        //查找医院报警时间信息
        public DataTable findwarningtime(string type)
        {

            string sql = "select id,(select hname from hospital where id = w.hospitalid) as hospitalname,checkwarning,adjustwarning,recheckwarning,bubblewarning,tisanewarning,packwarning,deliverwarning,status from warning as w where type='"+type+"'";
            return db.get_DataTable(sql);

        }

        //查找医院屏显信息
        public DataTable findInfo()
        {

            string sql = "select distinct ID,hname,DrugDisplayState, ChineseDisplayState, DrugSendDisplayState from  hospital ";
            return db.get_DataTable(sql);

        }

        //删除报警信息


        public int deletewarninginfo(string id){


            string sql = "delete from warning where id = '"+id+"'";
            return db.cmd_Execute(sql);
        }
  //找到医院报警时间根据id

        public DataTable findwarningtimebyid(int id)
        {
            string str = "select * from warning where id = '" + id + "'";
            return db.get_DataTable(str);
        }
        //更改报警时间

        public int updatewarningtimeinfo(string id, string checkwarning, string adjustwarning, string recheckwarning, string bubblewarning, string tisanewarning, string packwarning, string deliverwarning)
        {
            //sql = "update bubble set bubbleperson = '" + bubbleman + "' where pid = '" + id + "' ";
           // end = db.cmd_Execute(sql);

            string str = "update warning set checkwarning='" + checkwarning + "',adjustwarning='" + adjustwarning + "',recheckwarning='" + recheckwarning + "',bubblewarning='" + bubblewarning + "',tisanewarning='" + tisanewarning + "',packwarning='" + packwarning + "',deliverwarning='" + deliverwarning + "' where  id ='" + id + "'";
            int end = db.cmd_Execute(str);

            return end;
        }
        //更改开启状态byid
        public int updatewarningstatus(string id)
        {


            string str = "select status from warning where id = '"+id+"'";
            int end = 0;
            SqlDataReader sr = db.get_Reader(str);
            string result = "";
            if (sr.Read())
            {
                result = sr["status"].ToString();

            }

            if (result == "0")
            {
                string str2 = "update warning set status = 1 where id = '" + id + "'";
               end = db.cmd_Execute(str2);
            }
            else
            {
                string str3 = "update warning set status = 0 where id = '" + id + "'";
               end = db.cmd_Execute(str3);
            }

            return end;
        }
        #region 更改泡药开启状态byid
        public int updateDrugDisplayState(string id)
        {


            string str = "select DrugDisplayState from hospital where id = '" + id + "'";
            int end = 0;
            SqlDataReader sr = db.get_Reader(str);
            string result = "";
            if (sr.Read())
            {
                result = sr["DrugDisplayState"].ToString();

            }

            if (result == "0")
            {
                string str2 = "update hospital set DrugDisplayState = '1' where id = '" + id + "'";
                end = db.cmd_Execute(str2);
            }
            else
            {
                string str3 = "update hospital set DrugDisplayState = '0' where id = '" + id + "'";
                end = db.cmd_Execute(str3);
            }

            return end;
        }
       #endregion
        #region 更改煎药开启状态byid
        public int updateChineseDisplayState(string id)
        {


            string str = "select ChineseDisplayState from hospital where id = '" + id + "'";
            int end = 0;
            SqlDataReader sr = db.get_Reader(str);
            string result = "";
            if (sr.Read())
            {
                result = sr["ChineseDisplayState"].ToString();

            }

            if (result == "0")
            {
                string str2 = "update hospital set ChineseDisplayState = '1' where id = '" + id + "'";
                end = db.cmd_Execute(str2);
            }
            else
            {
                string str3 = "update hospital set ChineseDisplayState = '0' where id = '" + id + "'";
                end = db.cmd_Execute(str3);
            }

            return end;
        }
        #endregion
        #region 更改发药开启状态byid
        public int updateDrugSendDisplayState(string id)
        {


            string str = "select DrugSendDisplayState from hospital where id = '" + id + "'";
            int end = 0;
            SqlDataReader sr = db.get_Reader(str);
            string result = "";
            if (sr.Read())
            {
                result = sr["DrugSendDisplayState"].ToString();

            }

            if (result == "0")
            {
                string str2 = "update hospital set DrugSendDisplayState = '1' where id = '" + id + "'";
                end = db.cmd_Execute(str2);
            }
            else
            {
                string str3 = "update hospital set DrugSendDisplayState = '0' where id = '" + id + "'";
                end = db.cmd_Execute(str3);
            }

            return end;
        }
        #endregion
        public SqlDataReader findhospitalidbyhname(string hospitalname)
        {
            string str = "select id from hospital where hname='"+hospitalname+"'";
             SqlDataReader sr2 = db.get_Reader(str);
             return sr2;
        }
        #region 删除员工信息
        public bool deleteHospitalById(int nPId)
        {
            string strSql = "delete from hospital where id =" + nPId;
            int n = db.cmd_Execute(strSql);
            return true;
        }
        #endregion
        //查找pda图片开关
        public DataTable findPdaImgSwitchInfo()
        {

            string sql = "select * from  pdaImgSwitch ";
            return db.get_DataTable(sql);

        }
        //根据id查找pda图片开关
        public DataTable findPdaImgSwitchById(int id)
        {

            string sql = "select * from  pdaImgSwitch where id="+id;
            return db.get_DataTable(sql);

        }
        //修改pda图片开关
        public int editPdaImgSwitch(string id ,string tiaoji,string fuhe,string paoyao,string jianyao,string baozhuang,string fahuo)
        {

            string sql = "update pdaImgSwitch set tiaoji="+tiaoji+",fuhe="+fuhe+",paoyao="+paoyao+",jianyao="+jianyao+",baozhuang="+baozhuang+",fahuo="+fahuo+" where id=" + id;


            return db.cmd_Execute(sql);

        }
    }
}