using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SQLDAL;
using System.Data;
namespace ModelInfo
{
   public class DrugMatchingModel
    {
       public DataBaseLayer db = new DataBaseLayer();

        #region 添加药品匹配信息
        ///// <summary>
        ///// 添加药品匹配信息
        ///// </summary>
        ///// <param name="drugMatchingInfo)">药品匹配信息/param>
        ///// <returns>int对象</returns>
       public int insertDrugMatching(DrugMatchingInfo drugMatchingInfo)
        {
            String sql = "insert into DrugMatching(hospitalId,hospitalName,hdrugNum,ypcdrugNum,hdrugName,ypcdrugName,"
                +"hdrugOriginAddress,ypcdrugOriginAddress,hdrugSpecs,ypcdrugSpecs,hdrugTotal,ypcdrugTotal,pspNum,"
                + "ypcdrugPositionNum,pspId,drugId) values('" + drugMatchingInfo.hospitalId + "','" + drugMatchingInfo.hospitalName + "','" + drugMatchingInfo.hdrugNum
                + "','" + drugMatchingInfo.ypcdrugNum + "','" + drugMatchingInfo.hdrugName + "','" + drugMatchingInfo.ypcdrugName
                + "','" + drugMatchingInfo.hdrugOriginAddress + "','" + drugMatchingInfo.ypcdrugOriginAddress + "','" + drugMatchingInfo.hdrugSpecs
                + "','" + drugMatchingInfo.ypcdrugSpecs + "','" + drugMatchingInfo.hdrugTotal + "','" + drugMatchingInfo.ypcdrugTotal
                + "','" + drugMatchingInfo.pspNum + "','" + drugMatchingInfo.ypcdrugPositionNum + "','" + drugMatchingInfo.pspId + "','" + drugMatchingInfo.drugId
                + "')";

            return db.cmd_Execute(sql); ;

        }
        #endregion


        ///// <summary>
        ///// 查询未审核和未匹配处方药品信息
        ///// </summary>
        ///// <param name="hospitalId">医院id</param>
        ///// <param name="Pspnum">处方号</param>
        ///// <returns>SqlDataReader对象</returns>
       public DataTable findNotCheckAndMatchRecipeDrugInfo(string drugnum)
        {
            string sql = "SELECT DISTINCT p.ID AS pspId, p.Pspnum AS pspNum,(SELECT   Hname FROM Hospital AS h WHERE   (ID = p.Hospitalid)) AS hospitalName, p.Hospitalid AS hospitalId, d.ID AS drugId, d.drugnum AS hdrugNum, "
               + " d.drugname AS hdrugName, d.drugallnum AS hdrugTotal FROM      prescription AS p LEFT OUTER JOIN PrescriptionCheckState AS pcs ON p.ID = pcs.prescriptionId RIGHT OUTER JOIN "
               + " (SELECT   ID,pid, customid, delnum, Hospitalid, Pspnum, drugnum, drugname, drugdescription, drugposition, drugallnum, drugweight, tienum, description, wholesaleprice, retailprice, wholesalecost, retailpricecost, money, "
               + " fee FROM drug WHERE   (drugnum = '" + drugnum + "')) AS d ON d.pid = p.id LEFT OUTER JOIN DrugMatching AS dm ON d.ID = dm.drugId AND dm.pspId = p.ID "
               + " WHERE   (pcs.prescriptionId IS NULL) AND (dm.drugId IS NULL) AND (d.ID IS NOT NULL) AND (p.ID IS NOT NULL) AND (p.Hospitalid IS NOT NULL)";

             DataTable dt = db.get_DataTable(sql);

            return dt;
        }

       ///// <summary>
       ///// 根据药品编号,医院id查询已匹配的信息
       ///// </summary>

       public DataTable findNotMatchDrugInfo(string drugnum, string hospitalId)
       {
           //根据药品编号查询已匹配的信息
           string sql = "SELECT TOP (1) id, hospitalId, hospitalName, hdrugNum, ypcdrugNum, hdrugName, ypcdrugName, hdrugOriginAddress, "
                +"ypcdrugOriginAddress, hdrugSpecs, ypcdrugSpecs, hdrugTotal, ypcdrugTotal, status, pspNum, ypcdrugPositionNum, pspId, drugId, printstatus, warningstatus "
                + " FROM DrugMatching WHERE (hdrugNum = '" + drugnum + "') AND (hospitalId = '" + hospitalId + "')";

           DataTable dt = db.get_DataTable(sql);

           return dt;
       }
       ///// <summary>
       ///// 查询未审核和未匹配处方药品信息进行匹配
       ///// </summary>
       ///// <param name="hospitalId">医院id</param>
       ///// <param name="Pspnum">处方号</param>
       ///// <returns>SqlDataReader对象</returns>
       public int findNotCheckAndMatchRecipeDrugInfoToMatch()
       {
           RecipeModel rm = new RecipeModel();
           int count = 0;
           //未审核,未匹配的药品和处方
           string sql = "SELECT DISTINCT p.ID AS pspId, p.Pspnum AS pspNum, (SELECT Hname FROM Hospital AS h "
                    +" WHERE (ID = p.Hospitalid)) AS hospitalName, p.Hospitalid AS hospitalId, d.ID AS drugId, d.drugnum AS hdrugNum,"
                +"d.drugname AS hdrugName, d.drugallnum AS hdrugTotal FROM prescription AS p LEFT OUTER JOIN "
                +"PrescriptionCheckState AS pcs ON p.ID = pcs.prescriptionId RIGHT OUTER JOIN "
                +"drug AS d ON d.pid = p.id LEFT OUTER JOIN "
                +"DrugMatching AS dm ON d.ID = dm.drugId AND d.drugnum = dm.hdrugNum AND dm.hospitalId = d.Hospitalid "
                +"WHERE (pcs.prescriptionId IS NULL) AND (p.ID IS NOT NULL) AND (p.Hospitalid IS NOT NULL) AND (dm.drugId IS NULL)";
           /*string sql = "SELECT DISTINCT p.ID AS pspId, p.Pspnum AS pspNum, (SELECT Hname FROM Hospital AS h "
                    +" WHERE (ID = p.Hospitalid)) AS hospitalName, p.Hospitalid AS hospitalId, d.ID AS drugId, d.drugnum AS hdrugNum,"
                +"d.drugname AS hdrugName, d.drugallnum AS hdrugTotal FROM prescription AS p LEFT OUTER JOIN "
                +"PrescriptionCheckState AS pcs ON p.ID = pcs.prescriptionId RIGHT OUTER JOIN "
                +"drug AS d ON d.Pspnum = p.Pspnum AND p.Hospitalid = d.Hospitalid LEFT OUTER JOIN "
                +"DrugMatching AS dm ON d.ID = dm.drugId AND d.drugnum = dm.hdrugNum AND dm.hospitalId = d.Hospitalid "
                +"WHERE (pcs.prescriptionId IS NULL) AND (p.ID IS NOT NULL) AND (p.Hospitalid IS NOT NULL) AND (dm.drugId IS NULL)";*/
           DataTable dt = db.get_DataTable(sql);
 
           if (dt.Rows.Count > 0)
           {
               for (int i = 0; i < dt.Rows.Count; i++)
               {

                   DrugMatchingInfo drugMatchingInfo = new DrugMatchingInfo();
                   DataTable dtable = findNotMatchDrugInfo(dt.Rows[i]["hdrugNum"].ToString(), dt.Rows[i]["hospitalId"].ToString());
                   string ypcdrugNum = "";
                   string ypcdrugName = "";
                   string hdrugOriginAddress = "";
                   string ypcdrugOriginAddress = "";
                   string hdrugSpecs = "";
                   string ypcdrugSpecs = "";
                   string ypcdrugTotal = "";
                   string ypcdrugPositionNum = "";
                   DrugAdminModel wr = new DrugAdminModel();
                   if (dtable.Rows.Count > 0)
                   {
                       ypcdrugNum = dtable.Rows[0]["ypcdrugNum"].ToString();
                       ypcdrugName = dtable.Rows[0]["ypcdrugName"].ToString();
                       hdrugOriginAddress = dtable.Rows[0]["hdrugOriginAddress"].ToString();
                       ypcdrugOriginAddress = dtable.Rows[0]["ypcdrugOriginAddress"].ToString();
                       hdrugSpecs = dtable.Rows[0]["hdrugSpecs"].ToString();
                       ypcdrugSpecs = dtable.Rows[0]["ypcdrugSpecs"].ToString();
                       ypcdrugTotal = dtable.Rows[0]["ypcdrugTotal"].ToString();
                       ypcdrugPositionNum = dtable.Rows[0]["ypcdrugPositionNum"].ToString();

                       drugMatchingInfo.hospitalId = Convert.ToInt32(dt.Rows[i]["hospitalId"].ToString());
                       drugMatchingInfo.hospitalName = dt.Rows[i]["hospitalName"].ToString();
                       drugMatchingInfo.hdrugNum = dt.Rows[i]["hdrugNum"].ToString();
                       drugMatchingInfo.ypcdrugNum = ypcdrugNum;
                       drugMatchingInfo.hdrugName = dt.Rows[i]["hdrugName"].ToString();
                       drugMatchingInfo.ypcdrugName = ypcdrugName;
                       drugMatchingInfo.hdrugOriginAddress = hdrugOriginAddress;
                       drugMatchingInfo.ypcdrugOriginAddress = ypcdrugOriginAddress;
                       drugMatchingInfo.hdrugSpecs = hdrugSpecs;
                       drugMatchingInfo.ypcdrugSpecs = ypcdrugSpecs;
                       drugMatchingInfo.hdrugTotal = dt.Rows[i]["hdrugTotal"].ToString();
                       drugMatchingInfo.ypcdrugTotal = ypcdrugTotal;
                       drugMatchingInfo.pspNum = dt.Rows[i]["pspNum"].ToString();
                       drugMatchingInfo.ypcdrugPositionNum = ypcdrugPositionNum;
                       drugMatchingInfo.pspId = dt.Rows[i]["pspId"].ToString();
                       drugMatchingInfo.drugId = dt.Rows[i]["drugId"].ToString();
                       count += insertDrugMatching(drugMatchingInfo);
                       // rm.updatePrescriptionStatus(Convert.ToInt32(drugMatchingInfo.pspId), "未审核");


                       wr.Adddrugmatchinginfo(dt.Rows[i]["hospitalId"].ToString(), dt.Rows[i]["hdrugName"].ToString(), dt.Rows[i]["hdrugNum"].ToString(), ypcdrugName, ypcdrugNum);

                       bool boo = rm.checkPrescriptionIsMath(Convert.ToInt32(drugMatchingInfo.pspId));
                       if (boo)
                       {


                           SqlDataReader sdr2 = rm.findisneedcheckstatus();
                           string isneedcheck = "";
                           if (sdr2.Read())
                           {
                               isneedcheck = sdr2["isneedcheck"].ToString();

                           }

                           if (isneedcheck == "0")
                           {
                               rm.updatePrescriptionStatus(Convert.ToInt32(drugMatchingInfo.pspId), "未审核");
                           }
                           if (isneedcheck == "1")
                           {
                               string reasonText = "";
                               string name = "";
                               string employid = "";

                               int num = rm.checkPrescription(Convert.ToInt32(drugMatchingInfo.pspId), 1, reasonText, name, employid);
                               rm.updatePrescriptionStatus(Convert.ToInt32(drugMatchingInfo.pspId), "已审核");
                           }


                       }/**/

                   }
               }
           }
           return count;
       }
       
    }
}
