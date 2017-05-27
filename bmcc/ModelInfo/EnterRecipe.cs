using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLDAL;
using System.Data.SqlClient;

namespace ModelInfo
{
    public class EnterRecipe
    {
        /// <summary>
        /// 添加处方信息
        /// </summary>
        /// <param name="rinfo"></param>
        /// <returns></returns>
        
       public DataBaseLayer db = new DataBaseLayer();
        public bool AddRecipe(RecipeInfo rinfo)
        {
              
             
              int n = 0;
              string stateSql = "select Pspnum  from prescription where Hospitalid =" + rinfo.nHospitalID + "and Pspnum ='" + rinfo.strPspnum + "'";
            SqlDataReader srd = db.get_Reader(stateSql);
            //string q = srd["Pspnum"].ToString();
          
            if (srd.Read())
            {
                n = 0;
            }
            else
            {
                System.DateTime currentTime = new System.DateTime();
                currentTime = System.DateTime.Now;//当前时间  
              


                string strSql = "insert into prescription(delnum,Hospitalid,Pspnum,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
                strSql += "diagresult,dose,takenum,getdrugtime,getdrugnum,decscheme,oncetime,twicetime,packagenum,dotime,doperson,";
                strSql += "dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate,decmothed,takeway,takemethod,RemarksA,RemarksB)";
                strSql += " values('" + rinfo.strDelnum + "','" + rinfo.nHospitalID + "','" + rinfo.strPspnum + "',";
                strSql += "'" + rinfo.strName + "','" + rinfo.nSex + "','" + rinfo.nAge + "','" + rinfo.strPhone + "','" + rinfo.strAddress + "',";
                strSql += "'" + rinfo.strDepartment + "','" + rinfo.strInpatientAreaNum + "','" + rinfo.strWard + "','" + rinfo.strSickBed + "',";
                strSql += "'" + rinfo.strDiagResult + "','" + rinfo.strDose + "','" + rinfo.nNum + "','" + rinfo.strDrugGetTime + "','" + rinfo.strDrugGetNum + "',";
                strSql += "'" + rinfo.strScheme + "','" + rinfo.strTimeOne + "','" + rinfo.strTimeTwo + "','" + rinfo.nPackageNum + "','" + currentTime + "',";
                strSql += "'" + rinfo.strDoPerson + "','" + rinfo.strDtbCompany + "','" + rinfo.strDtbAddress + "','" + rinfo.strDtbPhone + "','" + rinfo.strDtbStyle + "',";
                strSql += "'" + rinfo.nSoakWater + "','" + rinfo.nSoakTime + "','" + rinfo.nLabelNum + "','" + rinfo.strRemark + "','" + rinfo.strDoctor + "','" + rinfo.strFootNote + "','" + rinfo.strOrderTime + "','未匹配','" + rinfo.strDecMothed + "','" + rinfo.strTakeWay + "','" + rinfo.strTakeMethod + "','" + rinfo.strRemarksA + "','" + rinfo.strRemarksB + "')";
              
                 n = db.cmd_Execute(strSql);
                 if (n == 1)
                 {
                     string str2 = "select id from prescription where hospitalid ='" + rinfo.nHospitalID + "' and Pspnum='" + rinfo.strPspnum + "'";
                    SqlDataReader srd2 = db.get_Reader(str2);
                    if (srd2.Read())
                    {
                        string pid = srd2["id"].ToString();
                        string str3 = "insert into jfInfo(pid,jiefangman,jiefangtime)values('" + pid + "','" + rinfo.strDoPerson + "','" + rinfo.strDoTime + "')";
                        db.cmd_Execute(str3);
                    }
                 }

            }

        
            if ( n>0 )
            {
                return true;
            } 
            else
            {
                return false;
            }


          




        }
    }
}
