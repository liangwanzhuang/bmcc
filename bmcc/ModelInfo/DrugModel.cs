using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SQLDAL;
using System.Data;
namespace ModelInfo
{
    public class DrugModel
    {
        public DataBaseLayer db = new DataBaseLayer();

        #region 根据处方号查询药品信息
        ///// <summary>
        ///// 根据处方号查询药品信息
        ///// </summary>
        ///// <param name="pspnum">处方号</param>
        ///// <returns>DataTable对象</returns>
        public DataTable findDrugByPid(string pid)
        {



            string sql = "select ID,delnum,(select hnum from hospital as h where h.id = d.hospitalid) as hnum,(select hname from hospital as h where h.id = d.hospitalid) as hname,"
                + "Pspnum,Drugnum,Drugname,DrugDescription,DrugPosition,DrugAllNum,DrugWeight,TieNum,Description,WholeSalePrice,RetailPrice,WholeSaleCost,retailpricecost,"
                + "money,Fee from drug as d where pid='" + pid + "'";

            DataTable dt = db.get_DataTable(sql);

            return dt;
        }
        ///// <returns>DataTable对象</returns>
        public DataTable findDrugByPspnum(string pid)
        {



            string sql = "select  ROW_NUMBER() OVER(ORDER BY delnum desc) as ID,delnum,(select hnum from hospital as h where h.id = (select hospitalid from prescription where id = '" + pid + "')) as hnum,(select hname from hospital as h where h.id = (select hospitalid from prescription where id = '" + pid + "')) as hname,"
                + "(select pspnum from prescription where id = d.pid) as Pspnum,Drugnum,Drugname,DrugDescription,DrugPosition,DrugAllNum,DrugWeight,TieNum,Description,WholeSalePrice,RetailPrice,WholeSaleCost,retailpricecost,"
                + "money,Fee from drug as d where pid ='" + pid + "'";

            DataTable dt = db.get_DataTable(sql);

            return dt;
        }
        public DataTable findDrugByPspnum1232(string pid)
        {



            string sql = "select  id,  ROW_NUMBER() OVER(ORDER BY delnum desc) as yy,delnum,(select hnum from hospital as h where h.id = (select hospitalid from prescription where id = '" + pid + "')) as hnum,(select hname from hospital as h where h.id = (select hospitalid from prescription where id = '" + pid + "')) as hname,"
                + "(select pspnum from prescription where id = d.pid) as Pspnum,Drugnum,Drugname,DrugDescription,DrugPosition,DrugAllNum,DrugWeight,TieNum,Description,WholeSalePrice,RetailPrice,WholeSaleCost,retailpricecost,"
                + "money,Fee from drug as d where pid ='" + pid + "'";

            DataTable dt = db.get_DataTable(sql);

            return dt;
        }

        ///// <summary>
        ///// 根据处方号查询未匹配药品信息
        ///// </summary>
        ///// <param name="pspnum">处方号</param>
        ///// <returns>DataTable对象</returns>
        public DataTable findNotMatchDrugByPspnum(string pid)
        {
            string sql = "select d.ID,d.delnum,(select hnum from hospital as h where h.id = (select hospitalid from prescription where id = '" + pid + "')) as hnum,(select hname from hospital as h where h.id = (select hospitalid from prescription where id = '" + pid + "')) as hname,"
                + "(select pspnum from prescription where id = d.pid) as Pspnum,d.Drugnum,d.Drugname,d.DrugDescription,d.DrugPosition,d.DrugAllNum,d.DrugWeight,d.TieNum,d.Description,d.WholeSalePrice,d.RetailPrice,d.WholeSaleCost,d.retailpricecost,"
                + "d.money,d.Fee from drug as d left join DrugMatching dm on d.id=dm.drugId where dm.drugId IS NULL and d.pid ='" + pid + "'";

            DataTable dt = db.get_DataTable(sql);

            return dt;
        }
        #endregion
        #region 删除处方信息
        public bool deleteDrugInfo(int ndId)
        {
            string strSql = "delete from drug where id =" + ndId;
            int n = db.cmd_Execute(strSql);
            return true;
        }
        #endregion
        #region 根据复核处方号查询药品信息
        ///// <summary>
        ///// 根据处方号查询药品信息
        ///// </summary>
        ///// <param name="pspnum">处方号</param>
        ///// <returns>DataTable对象</returns>
        public DataTable findDrugInfo(string pspnum, string Hospitalid)
        {


            string str = "select id from hospital where hnum ='" + Hospitalid+ "'";


            SqlDataReader sdr2 = db.get_Reader(str);
            string hid = "";
            if (sdr2.Read())
            {
                hid = sdr2["id"].ToString();

            }





            string sql = "select  ROW_NUMBER() OVER(ORDER BY id desc) as ID,delnum,(select hnum from hospital as h where h.id = d.hospitalid) as hnum,(select hname from hospital as h where h.id = d.hospitalid) as hname,"
                + "Pspnum,Drugnum,Drugname,DrugDescription,DrugPosition,DrugAllNum,DrugWeight,TieNum,Description,WholeSalePrice,RetailPrice,WholeSaleCost,retailpricecost,"
                + "money,Fee from drug as d where d.Pspnum='" + pspnum + "' and Hospitalid='" + hid + "'";

            DataTable dt = db.get_DataTable(sql);

            return dt;
        }

        #endregion
    }
    
}

