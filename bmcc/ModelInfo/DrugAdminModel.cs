using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLDAL;
using System.Data.SqlClient;
using System.Data;

namespace ModelInfo
{
   public class DrugAdminModel
    {
       public DataBaseLayer db = new DataBaseLayer();
       #region 根据编号查询
       public DataTable findDrugAdinByDrugCode(string drugCode)
       {
           string sql = "select * from DrugAdmin where DrugCode='" + drugCode + "'";
           DataTable dt = db.get_DataTable(sql);

           return dt;
       }
           

       #endregion
       #region 添加药品信息
       public int AddDrug(string DrugType, string DrugCode, string PurUnits, string DrugName, string DrugSpecificat, string PositionNum, string Univalent, string Mnemonic, string Rmarkes, string Producer, string ProducingArea,  string UpperLimit, string LowerLimit, string Rmarkes2, string Rmarkes3)
       {
           DataBaseLayer db = new DataBaseLayer();
           String strSql = "";
           int end = 0;
           System.DateTime currentTime = new System.DateTime();
           currentTime = System.DateTime.Now;//获取当前时间
          
           //产品批次
           string ProductBatch = "";
           string now1 = currentTime.ToString("yyyyMMdd");//1当前日期

           string str = "select StorageTime from DrugAdmin where StorageTime='" + now1 + "'";//2查询到数据库存储的当前时间
           SqlDataReader sr = db.get_Reader(str);
           if (sr.Read())
           {
               string result = sr["StorageTime"].ToString();
              
               int m = 0;

               if (now1 == result)
               {
                   string str1 = "select   max(CAST(ProductBatch AS int)) as kk  from DrugAdmin  WHERE  StorageTime= '" + now1 + "'";//2查询到数据库存储的当前时间
                   SqlDataReader s1r = db.get_Reader(str1);
                   string result1 = "";
                   if (s1r.Read())
                   {
                       result1 = s1r["kk"].ToString();
                   }
                   string DeNum = result1.Substring(8);
                   int hh = Convert.ToInt16(DeNum);
                   int sum1 = ++hh;

                   ProductBatch = now1 + sum1;

               }
               else
               {
                   int sum = ++m;
                   ProductBatch = now1 + sum.ToString();

               }

           }
           else
           {
               int ss = 0;
               int sum2 = ++ss;
               ProductBatch = now1 + sum2.ToString();

           }

           /* string tate = "";
            SqlDataReader tate1 = db.get_Reader(tate);
            if (tate1.Read())
            {
                strSql = "";
            }
            else
            {*/
           strSql = "insert into DrugAdmin(ProductBatch, DrugType, DrugCode, PurUnits, DrugName,DrugSpecificat, PositionNum,  Univalent, Mnemonic, Rmarkes,  Producer, ProducingArea,  StorageTime,UpperLimit,LowerLimit,Rmarkes2,Rmarkes3) ";
           strSql += "values ('" + ProductBatch + "','" + DrugType + "','" + DrugCode + "','" + PurUnits + "',";
           strSql += "'" + DrugName + "','" + DrugSpecificat + "','" + PositionNum + "','" + Univalent + "','" + Mnemonic + "','" + Rmarkes + "','" + Producer + "','" + ProducingArea + "','" + now1 + "','" + UpperLimit + "','" + LowerLimit + "','" + Rmarkes2 + "','" + Rmarkes3 + "')";
           // }


           if (strSql == "")
           {
               end = 0;
           }
           else
           {
               end = db.cmd_Execute(strSql);
           }
           return end;

       }
        #endregion
       //添加匹配列表信息
       public int Adddrugmatchinginfo(string hospitalname, string DrugName12, string DrugCode1, string ypcdrugname, string ypcdrugcode)
       {
           int end = 0;
           string strSql = "";
           string str1 = "select * from drugadmin where drugname ='" + ypcdrugname + "' and drugcode ='" + ypcdrugcode + "'";
           SqlDataReader sdr1 = db.get_Reader(str1);

           if (sdr1.Read())
           {
               string str2 = "select * from ypcdrug where drugNum ='" + DrugCode1 + "' and hospitalid ='" + hospitalname + "'";
               SqlDataReader sdr2 = db.get_Reader(str2);

               if (sdr2.Read())
               {

               }else{
                   strSql = "insert into ypcdrug(drugName, drugNum, drugDetailedName, drugAlias,hospitalid) ";
                   strSql += "values ('" + DrugName12 + "','" + DrugCode1 + "','" + ypcdrugname + "','" + ypcdrugcode + "','" + hospitalname + "')";
                   end = db.cmd_Execute(strSql);
               }

           }
           else
           {
              
           }

           return end;
       }

       //修改匹配列表信息
       public int updatedrugmatchinginfo(string hospitalname, string DrugName12, string DrugCode1, string ypcdrugname, string ypcdrugcode, string positionnum ,string id )
       {
           int end = 0;
           string strSql = "";

           string str = "";

           str = "select * from ypcdrug where hospitalid ='" + hospitalname + "' and drugNum='" + DrugCode1 + "' and id != '" + id + "'";
           SqlDataReader sdr2  = db.get_Reader(str);
           if (sdr2.Read())
           {

           }
           else
           {
               strSql = "update ypcdrug set drugName='" + DrugName12 + "',drugNum='" + DrugCode1 + "',drugDetailedName ='" + ypcdrugname + "', positionNum ='" + positionnum + "',drugAlias='" + ypcdrugcode + "',hospitalid='" + hospitalname + "' where id = '" + id + "' ";
               end = db.cmd_Execute(strSql);
           }



           return end;
       }

  
        #region 查询所有信息通过id
       public DataTable findDrugAdminInfo(int id)
       {
           string strSql = "select * from  DrugAdmin where id = " + id;

           DataTable dt = db.get_DataTable(strSql);

           return dt;
       }

        #endregion

       #region 查询所有匹配表信息通过id
       public DataTable findDrugmatchingInfo(int id)
       {
           string strSql = "select * from  ypcdrug where id = " + id;

           DataTable dt = db.get_DataTable(strSql);

           return dt;
       }

        #endregion
        #region 修改药品信息

       public int UpdateDrugAdminInfo(int id, string DrugType, string DrugCode, string PurUnits, string DrugName, string DrugSpecificat, string PositionNum, string Univalent, string Mnemonic, string Rmarkes, string Producer, string ProducingArea, string UpperLimit, string LowerLimit, string Rmarkes2, string Rmarkes3)
       {
           //string strSql = "select id,JobNum,EName,Role,Sex,Age,Phone,Address,Nation,Origin from  Employee where id = " + id;

           int end = 0;

           string sql = "";
           string str = " ";
           SqlDataReader sr = db.get_Reader(str);
           if (sr.Read())
           {
               end = 0;
           }
           else
           {


               sql = "update DrugAdmin set DrugType='" + DrugType + "',DrugCode='" + DrugCode + "',Mnemonic='" + Mnemonic + "',PurUnits='" + PurUnits + "',DrugName='" + DrugName + "',DrugSpecificat='" + DrugSpecificat + "',PositionNum='" + PositionNum + "' ,Univalent='" + Univalent + "',UpperLimit='" + UpperLimit + "',Rmarkes='" + Rmarkes + "',Producer='" + Producer + "',ProducingArea='" + ProducingArea + "',LowerLimit='" + LowerLimit + "',Rmarkes2='" + Rmarkes2 + "',Rmarkes3='" + Rmarkes3 + "'where id = " + id + "";
               end = db.cmd_Execute(sql);
           }


           return end;
       }
        #endregion 
       #region 删除药品信息
       public bool deleteDrugAdminInfo(int nPId)
       {
           string strSql = "delete from DrugAdmin where id =" + nPId;
           int n = db.cmd_Execute(strSql);
           return true;
       }
       #endregion


       #region 删除匹配列表药品信息
       public int deleteDrugmatchingInfo(int nPId)
       {
             string str = "select hospitalid ,drugnum from ypcDrug where id = '" + nPId + "'";
             SqlDataReader sdr2 = db.get_Reader(str);

             string hid = "";
             string hdrugnum = "";
             if (sdr2.Read())
             {

                 hid = sdr2["hospitalid"].ToString();
                 hdrugnum = sdr2["drugnum"].ToString();
             }

            string str2 = "delete from drugmatching where hospitalid ='" + hid + "' and hdrugnum ='" + hdrugnum + "'";

            db.cmd_Execute(str2);

           string strSql = "delete from ypcdrug where id =" + nPId;
           int n = db.cmd_Execute(strSql);


         



           return n;
       }
       #endregion

    }
}
