using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SQLDAL;
using System.Collections;
using System.Data;

namespace ModelInfo
{
    public class Bubbleinfo
    {
        public DataBaseLayer db = new DataBaseLayer();

        public int addbubble(string tisanebarcode,string bubbleperson,string mark,string wateryield)
        {
            string tisaneid = tisanebarcode.Substring(4,10);

            string originaltisaneid = tisaneid.TrimStart('0');

            String sql = "";

            string per = bubbleperson.Substring(6);


            string employeeid = "";
            string str4 = "select id from employee where EmNumAName ='" + bubbleperson + "'";
            SqlDataReader sr4 = db.get_Reader(str4);

            if (sr4.Read())
            {

                employeeid = sr4["id"].ToString();

            }

            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            string strtime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");//

            int end=0;//正在泡
            string str2 = "select * from prescription where id not in (select pid from InvalidPrescription) and id = '" + originaltisaneid + "'";
            SqlDataReader sr2 = db.get_Reader(str2);

            if (sr2.Read())
            {

                string str5 = "select * from Audit where  pid='" + originaltisaneid + "'";

                SqlDataReader sr5 = db.get_Reader(str5);

                if (sr5.Read())
                {

                    string str = "select * from bubble where pid = '" + originaltisaneid + "'";
                    SqlDataReader sr = db.get_Reader(str);
                    if (sr.Read())
                    {
                        if (sr["bubblestatus"].ToString() == "1")
                        {
                            end = 4;//泡药已完成
                        }
                        else
                        {
                            DateTime d1 = Convert.ToDateTime(strtime);//当前时间
                            DateTime d2 = Convert.ToDateTime(sr["starttime"].ToString());//开始时间

                            TimeSpan d3 = d1.Subtract(d2);//泡药时间

                            int doingtime = Convert.ToInt32(d3.Days.ToString()) * 24 * 60 + Convert.ToInt32(d3.Hours.ToString()) * 60 + Convert.ToInt32(d3.Minutes.ToString());//转化为分钟数


                            string str1 = "update bubble set bubblestatus =1,endDate='" + strtime+ "',doingtime='" + doingtime + "' where pid = '" + originaltisaneid + "'";

                            if (db.cmd_Execute(str1) == 1)
                            {
                                end = 2;//泡药成功，但分配机组不成功

                                string machineid = distributionmachine();
                                string unitnum = "select unitnum from machine where id = '" + machineid + "'";
                                SqlDataReader sdr10 = db.get_Reader(unitnum);
                                string ut = "";
                                if (sdr10.Read())
                                {
                                    ut =sdr10["unitnum"].ToString();
                                }

                                string str3 = "insert into tisaneunit(pid,machineid,unitnum) values('" + originaltisaneid + "','" + machineid + "','" + ut+ "')";

                                if (db.cmd_Execute(str3) == 1)
                                {
                                    end = 6;//泡药成功，且成功分配机组

                                    string sql7 = "update prescription set curstate = '泡药完成'  where id = '" + originaltisaneid + "'";

                                  db.cmd_Execute(sql7);//更新处方表里的当前状态
                                }

                            }
                            else
                            {
                                end = 5;//泡药未成功
                            }
                        }

                    }
                    else
                    {
                        sql = "INSERT INTO [Bubble](pid,starttime,bubbleperson,mark,waterYield,employeeId) VALUES('" + originaltisaneid + "','" + strtime + "','" + per + "','" + mark + "','" + wateryield + "','" + employeeid + "')";
                      
                        if (db.cmd_Execute(sql) == 1)
                        {
                            end = 1;//正在泡
                            string sql7 = "update prescription set doperson ='" + per + "',curstate = '开始泡药'  where id = '" + originaltisaneid + "'";

                            if (db.cmd_Execute(sql7) == 1) //更新处方表里
                            {
                                //删除复合表里的复合的数据

                               // string sql8 = "delete from AgainPrescriptionCheckState where prescriptionId = '" + originaltisaneid + "'";
                             //   db.cmd_Execute(sql8);
                            }

                        }

                    }

                }
                else
                {
                    end = 7;//该煎药单号还没完成复核
                }
            }
            else
            {
                end = 3;//煎药单号不存在
            }


            return end;

        }
        #region 泡药大屏显示信息

        public DataTable DrugDisplayInfo()
        {

            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;//当前时间


            string strS = currentTime.ToString("yyyy/MM/dd 00:00:00");

            string strS2 = currentTime.ToString("yyyy/MM/dd 23:59:59");
            DataBaseLayer db = new DataBaseLayer();
           // string sql = "select id ,  (select Pspnum from prescription as p p.id = b.pid )as Pspnum, (select getdrugnum from prescription as p p.id = b.pid )as getdrugnum, (select getdrugtime from prescription as p p.id = b.pid )as getdrugtime,bubbleperson as bp,starttime,doingtime,bubblestatus from bubble as b";
            string sql = "select (select pid from bubble where pid= p.id) as ID,Pspnum,customid,delnum,(select bubblestatus from bubble where pid= p.id) as bubblestatus,(select doingtime from bubble where pid = p.id) as doingtime,(select starttime from bubble where pid = p.id) as starttime,(select warningstatus from bubble where pid = p.id) as warningstatus,(SELECT bubbleperson FROM bubble WHERE pid = p.id) as bp,(SELECT mark FROM bubble WHERE pid = p.id) as mark,(select hnum from hospital as h where h.id = p.hospitalid ) as hnum,(select hname from hospital as h where h.id = p.hospitalid  ) as hname,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
            sql += "diagresult,(select wateryield from bubble where pid= p.id) as wateryield,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate,RemarksA,RemarksB";
            sql += " from prescription as p where  id not in (select pid from InvalidPrescription) and  id in (select pid from bubble ) and id not in (select pid from tisaneinfo ) and p.Hospitalid  in (select id from hospital where DrugDisplayState='0') and p.dotime between '" + strS + "' and '" + strS2 + "'";

            DataTable dt = db.get_DataTable(sql);
            return dt;
        }
        #endregion

        #region 根据处方id查询分配的煎药机

        public DataTable findTisaneunitByPid(int pid)
        {
            DataBaseLayer db = new DataBaseLayer();
            // string sql = "select id ,  (select Pspnum from prescription as p p.id = b.pid )as Pspnum, (select getdrugnum from prescription as p p.id = b.pid )as getdrugnum, (select getdrugtime from prescription as p p.id = b.pid )as getdrugtime,bubbleperson as bp,starttime,doingtime,bubblestatus from bubble as b";
            string sql = "SELECT   id, pid, machineid, packstatus, roomnum, unitnum, machinename, endDate, (SELECT machinename FROM machine WHERE (id = t.machineid)) AS mname FROM tisaneunit AS t WHERE pid="+pid;



            DataTable dt = db.get_DataTable(sql);
            return dt;
        }
        #endregion
        #region 修改煎药机

        public int updateTisaneunitByMachineid(int id, int machineid)
        {
            DataBaseLayer db = new DataBaseLayer();
            // string sql = "select id ,  (select Pspnum from prescription as p p.id = b.pid )as Pspnum, (select getdrugnum from prescription as p p.id = b.pid )as getdrugnum, (select getdrugtime from prescription as p p.id = b.pid )as getdrugtime,bubbleperson as bp,starttime,doingtime,bubblestatus from bubble as b";
            string sql = "update tisaneunit set machineid=" + machineid +" where id="+id;



            return db.cmd_Execute(sql);
        }
        #endregion

        public int updateBubble(int id, int status, string endDate, string starttime)
        {

            DateTime d1 = Convert.ToDateTime(endDate);//当前时间
            DateTime d2 = Convert.ToDateTime(starttime);//开始时间

            TimeSpan d3 = d1.Subtract(d2);//泡药时间

            int doingtime = Convert.ToInt32(d3.Days.ToString()) * 24 * 60 + Convert.ToInt32(d3.Hours.ToString()) * 60 + Convert.ToInt32(d3.Minutes.ToString());//转化为分钟数


            string sql = "update bubble set bubblestatus='" + status + "',endDate='" + endDate + "',doingtime='" + doingtime + "' where id=" + id;
            int count = db.cmd_Execute(sql);
            if (count > 0)
            {

                string sql4 = "select pid from bubble where id=" + id;
                DataTable dt4 = db.get_DataTable(sql4);
                if (dt4.Rows.Count > 0)
                {
                    string machineid = distributionmachine();
                    string str3 = "insert into tisaneunit(pid,machineid) values('" + dt4.Rows[0]["pid"].ToString() + "','" + machineid + "')";


                    if (db.cmd_Execute(str3) == 1)
                    {

                        string sql7 = "update prescription set curstate = '泡药完成'  where id = '" + dt4.Rows[0]["pid"].ToString() + "'";

                        db.cmd_Execute(sql7);//更新处方表里的当前状态
                      

                    }
                }


                

            }
            

            return count;

        }

        public int addbubble(int userid, string wordDate, string barcode, string wordcontent, string tisaneNum, string imgname, string waterYield, string userName)
        {
            string sql = "insert into bubble(employeeId,starttime,barcode,wordcontent,pid,imgname,waterYield,bubblestatus,doingtime,bubbleperson) values('" + userid + "','" + wordDate + "','" + barcode + "','" + wordcontent + "','" + tisaneNum + "','" + imgname + "','" + waterYield + "','0','0" + "','" + userName + "')";
            string sql2 = "update prescription set doperson ='" + userName + "',curstate = '开始泡药'  where id = '" + tisaneNum + "'";
            db.cmd_Execute(sql2);
            return db.cmd_Execute(sql);

        }
        public DataTable findBubbleBybarcode(string barcode)
        {
            string sql = "select * from bubble  where pid='" + barcode + "'";

            DataTable dt = db.get_DataTable(sql);
            return dt;

        }
        public DataTable getBubbleInfo(int userid, string date)
        {
            string sql = "select p.ID,p.Pspnum,p.customid,p.delnum,p.Hospitalid,p.name,p.sex,p.age,p.phone,p.address,p.department,p.inpatientarea,p.ward,p.sickbed,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,"
             + "p.diagresult,p.dose,p.takenum,p.getdrugtime,p.getdrugnum,p.takemethod,p.decscheme,p.oncetime,p.twicetime,p.packagenum,p.dotime,p.doperson,p.dtbcompany,p.dtbaddress,p.dtbphone,p.dtbtype,p.soakwater,p.soaktime,p.labelnum,p.remark,p.doctor,p.footnote,p.ordertime,p.curstate"
             + ",b.bubblestatus bstatus,b.waterYield bwaterYield,b.starttime bstarttime,b.endDate bendDate,b.doingtime bdoingtime,(SELECT machinename FROM machine WHERE (id = (SELECT   machineid FROM tisaneunit AS tisaneunit_1 WHERE (pid = p.id)))) as machinename  from prescription as p inner join bubble b on p.id=b.pid where b.employeeId=" + userid + " and CONVERT(varchar, b.starttime, 120) like '%" + date + "%' order by p.ID desc";

            DataTable dt = db.get_DataTable(sql);

            return dt;
        }

        #region 获取泡药超时煎药单号

        public string getTimeoutNumber(string date)
        {
            DataBaseLayer db = new DataBaseLayer();
            // string sql = "select id ,  (select Pspnum from prescription as p p.id = b.pid )as Pspnum, (select getdrugnum from prescription as p p.id = b.pid )as getdrugnum, (select getdrugtime from prescription as p p.id = b.pid )as getdrugtime,bubbleperson as bp,starttime,doingtime,bubblestatus from bubble as b";
            string sql = "SELECT p.ID FROM prescription AS p INNER JOIN bubble AS b ON p.ID = b.pid AND DATEDIFF(minute, b.starttime, GETDATE()) > p.soaktime WHERE   (b.bubblestatus = 0) AND (b.bubblestatus = 0) AND (CONVERT(varchar, p.dotime, 120) LIKE '%" + date + "%') ORDER BY DATEDIFF(minute, b.starttime, GETDATE()) DESC";


            SqlDataReader sr = db.get_Reader(sql);
            string str = "";
            int index = 0;
            while (sr.Read())
            {

                str += sr["ID"].ToString() + ",";
                index++;
                if (index == 3)
                {
                    break;
                }
            }

            return str;
        }
        #endregion
        public DataTable getBubbleInfo(string name, int status)
        {

          ArrayList list = new ArrayList();
            ArrayList list1 = new ArrayList();
            ArrayList list2 = new ArrayList();
            ArrayList list3 = new ArrayList();


            DataBaseLayer db = new DataBaseLayer();
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
           /* string sql3 = "";

            sql3 = "select ID,Pspnum,customid,delnum,(select bubblewarning from warning where hospitalid = p.Hospitalid) as bubblewarning,(select doingtime from bubble where pid = p.id) as doingtime,(SELECT bubbleperson FROM bubble WHERE pid = p.id) as bp,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
            sql3 += "diagresult,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate";
            sql3 += " from prescription as p where id in (select pid from bubble where bubblestatus = 0)";

            SqlDataReader sr3 = db.get_Reader(sql3);//泡药表里 的所有正在泡药的处方



            while (sr3.Read())
            {

                // sr3["bubblewarning"].ToString();
                // sr3["getdrugtime"].ToString();
                // string d1 = sr3["bubblewarning"].ToString();

                // list1.Add(d1);

                string drugtime = sr3["getdrugtime"].ToString();//得到该处方号的取药时间
                //  DateTime d2 = Convert.ToDateTime(sr3["getdrugtime"].ToString());
                list2.Add(drugtime);

                string bubblewarning = sr3["bubblewarning"].ToString();
                list1.Add(bubblewarning);

                string id = sr3["ID"].ToString();
                list3.Add(id);

            }

            for (int i = 0; i < list2.Count; i++)
            {


                string d1 = list1[i].ToString();


                DateTime d2 = Convert.ToDateTime(list2[i].ToString());


                string strY = currentTime.ToString("yyyy-MM-dd HH:mm:ss");

                DateTime d3 = Convert.ToDateTime(strY);



                TimeSpan d4 = d2.Subtract(d3);

                int time = Convert.ToInt32(d4.Days.ToString()) * 24 * 60 + Convert.ToInt32(d4.Hours.ToString()) * 60 + Convert.ToInt32(d4.Minutes.ToString());
                int time2 = Convert.ToInt32(d1);
                if (time < time2)
                {
                    string strsql1 = "update bubble set warningstatus = 1 where pid = '"+list3[i]+"'";

                    db.cmd_Execute(strsql1);
                }


            }*/

              if (status == 0)//正在泡
                {
                    string strY = currentTime.ToString("yyyy-MM-dd HH:mm:ss");




                    DateTime d2 = Convert.ToDateTime(strY);//当前时间


                    string strsql = "select starttime from bubble where bubblestatus = 0";
                    SqlDataReader sr = db.get_Reader(strsql);//正在泡药的处方号的开始时间
                   // if (sr.Read())
                  //  {
                        while(sr.Read())
                        {
                            string a = sr["starttime"].ToString();

                            list.Add(a);


                        }

                        for (int i = 0; i < list.Count; i++)
                        {

                            string a = list[i].ToString();

                            DateTime d1 = Convert.ToDateTime(a);//正在泡药的处方号的开始时间

                            TimeSpan d3 = d2.Subtract(d1);//当前时间-开始时间=已泡药时间
                            int doingtime = Convert.ToInt32(d3.Days.ToString()) * 24 * 60 + Convert.ToInt32(d3.Hours.ToString()) * 60 + Convert.ToInt32(d3.Minutes.ToString());

                            // int doingtime = Convert.ToInt32(d3.Days.ToString()) + ":" + d3.Hours.ToString() + ":" + d3.Minutes.ToString();


                            string strsql1 = "update bubble set doingtime= '" + doingtime + "' where starttime = '" + a + "'";

                            db.cmd_Execute(strsql1);

                        }


               //     }

                }







     /* 
                string sql = "";
                if (status == 3)
                {
                    sql = "select ID,Pspnum,customid,delnum,(select Distinct bubblestatus from bubble where bubblestatus = 0) as bubblestatus,(select bubblewarning from warning where hospitalid = p.Hospitalid) as bubblewarning,(select warningstatus from bubble where pid = p.id) as warningstatus,(select doingtime from bubble where pid = p.id) as doingtime,(SELECT bubbleperson FROM bubble WHERE pid = p.id) as bp,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
                    sql += "diagresult,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate";
                    sql += " from prescription as p where id in (select prescriptionId from AgainPrescriptionCheckState where checkStatus = 1 and addbubblestatus = 0)";

                }
                else if (status == 4)
                {
                    sql = "select ID,Pspnum,customid,delnum,(select Distinct bubblestatus from bubble where bubblestatus = 2) as bubblestatus,(select bubblewarning from warning where hospitalid = p.Hospitalid) as bubblewarning,(select doingtime from bubble where pid = p.id) as doingtime,(select warningstatus from bubble where pid = p.id) as warningstatus,(SELECT bubbleperson FROM bubble WHERE pid = p.id) as bp,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
                    sql += "diagresult,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate";
                    sql += " from prescription as p where id in (select pid from bubble where distributionstatus = 0 and bubblestatus = 2)";
                }
                else
                {



                */
          string sql = "";


          sql = "select  ID,Pspnum,delnum,(select bubblestatus from bubble where pid= p.id) as bubblestatus,(select bubblewarning from warning where hospitalid = p.Hospitalid and type=0) as bubblewarning,(select doingtime from bubble where pid = p.id) as doingtime,(select warningstatus from bubble where pid = p.id) as warningstatus,(SELECT bubbleperson FROM bubble WHERE pid = p.id) as bp,(SELECT mark FROM bubble WHERE pid = p.id) as mark,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
          sql += "diagresult,(select wateryield from bubble where pid= p.id) as wateryield,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate,RemarksA,RemarksB";
          sql += ",(select starttime from bubble where pid= p.id) as starttime ,(select endDate from bubble where pid= p.id) as endDate from prescription as p where    id not in (select pid from InvalidPrescription) and  id in (select pid from bubble where 1=1";



          if (name != "0")
          {

              sql += "and bubbleperson ='" + name + "'";
          }
         if(status !=2)
          {
              sql += "and bubblestatus ='"+status+"'";

          }


         sql += ")";
         sql += " order by ID desc";






           /* string sql ="";

                if (name == "0")
                {
                    sql = "select ID,Pspnum,customid,delnum,(select Distinct bubblestatus from bubble where bubblestatus = '" + status + "') as bubblestatus,(select bubblewarning from warning where hospitalid = p.Hospitalid) as bubblewarning,(select doingtime from bubble where pid = p.id) as doingtime,(select warningstatus from bubble where pid = p.id) as warningstatus,(SELECT bubbleperson FROM bubble WHERE pid = p.id) as bp,(SELECT mark FROM bubble WHERE pid = p.id) as mark,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
                    sql += "diagresult,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate,RemarksA,RemarksB";
                    sql += " from prescription as p where  id not in (select pid from InvalidPrescription) and  id in (select pid from bubble where bubblestatus = '" + status + "')";
                }
                else 
                {
                    sql = "select ID,Pspnum,customid,delnum,(select Distinct bubblestatus from bubble where bubblestatus = '" + status + "') as bubblestatus,(select bubblewarning from warning where hospitalid = p.Hospitalid) as bubblewarning,(SELECT mark FROM bubble WHERE pid = p.id) as mark,(select warningstatus from bubble where pid = p.id) as warningstatus,(select doingtime from bubble where pid = p.id) as doingtime,(SELECT DISTINCT bubbleperson FROM bubble WHERE (bubbleperson = '" + name + "')) as bp,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
                    sql += "diagresult,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate,RemarksA,RemarksB";
                    sql += " from prescription as p where  id not in (select pid from InvalidPrescription) and id in (select pid from bubble where bubbleperson = '" + name + "' and bubblestatus = '" + status + "')";
                }

            */
          

            DataTable dt = db.get_DataTable(sql);

            return dt;
        }

        #region 导出泡药信息
        public DataTable getBubbleInfoDao(string name, int status)
        {
            string sql = "";
            sql = "select  ID,Pspnum,delnum,(select case  convert(nvarchar(50),bubblestatus) when 1 then '泡药完成' when 0 then '开始泡药' else convert(nvarchar(50),bubblestatus) end from bubble where pid= p.id) as bubblestatus,(select doingtime from bubble where pid = p.id) as doingtime,(select starttime from bubble where pid= p.id) as starttime,(select endDate from bubble where pid= p.id) as endDate,(SELECT bubbleperson FROM bubble WHERE pid = p.id) as bp,(SELECT mark FROM bubble WHERE pid = p.id) as mark,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,name,case convert(nvarchar(50), sex)  when 1 then '男' when 2 then '女' else convert(nvarchar(50), sex) end,age,phone,address,department,inpatientarea,ward,sickbed,";
            sql += "diagresult,(select wateryield from bubble where pid= p.id) as wateryield,dose,takenum,getdrugtime,getdrugnum,takemethod,case decscheme when 1 then '微压（密闭）解表（15min)' when 2 then '微压（密闭）汤药（15min）' when 3 then '微压（密闭）补药（15min）' when 4 then '常压解表（10min，10min）' when 5 then '常压汤药（20min，15min）' when 6 then '常压补药（25min，20min）'when 20 then '先煎解表（10min，10min，10min）'when 21 then '先煎汤药（10min，20min，15min）'when 22 then '先煎补药（10min，25min，20min）' when 36 then '后下解表（10min（3：7），10min）' when 37 then '后下汤药（20min（13：7），15min）' when 38 then '后下补药（25min（18：7），20min）' when 81 then '微压自定义' when 82 then '常压自定义'when 83 then '先煎自定义' when 84 then '后下自定义' else decscheme end ,oncetime,twicetime,packagenum,dotime,dtbcompany,dtbaddress,dtbphone,case dtbtype when 1 then '顺丰' when 2 then '圆通' when 3 then '中通' else dtbtype end,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,RemarksA,";
            sql += "RemarksB from prescription as p where id not in (select pid from InvalidPrescription) and  id in (select pid from bubble where 1=1";

            if (name != "0")
            {
                sql += "and bubbleperson ='" + name + "'";
            }
            if (status != 2)
            {
                sql += "and bubblestatus ='" + status + "'";

            }

            sql += ")";
            sql += " order by ID desc";

            DataTable dt = db.get_DataTable(sql);

            return dt;
        }

        #endregion
        public DataTable getBubbleInfo(int id)
        {

            string sql = "select hospitalid,pspnum ,(select bubbleperson from bubble where pid = '" + id + "') as bp from prescription where id = '" + id + "'";
            DataBaseLayer db = new DataBaseLayer();

            DataTable dt = db.get_DataTable(sql);


            return dt;
        }



        public int updateBubbleInfo(int id, string bubbleman)
        {
            //update tb set UserName="XXXXX" where UserID="aasdd"
            int end = 0;
           
            string sql = "";
            string str = "select * from bubble where pid= '"+id+"'";
            SqlDataReader sr = db.get_Reader(str);
            if (sr.Read())
            {
                //string result = sr["id"].ToString();
                //a = Convert.ToInt32(result);
                sql = "update bubble set bubbleperson = '" + bubbleman + "' where pid = '" + id + "' ";
                end = db.cmd_Execute(sql);
            }
            else
            {
                end = 0;
            }


            return end;
        }


        public int deleteBubbleInfo(int id)
        {
            string strSql = "delete from bubble where pid = '" + id + "'";
            int n = db.cmd_Execute(strSql);


            return n;
        }
        #region 查询开启并空闲的煎药机
        public DataTable findMachineByStartAndFree()
        {
            string str = "SELECT   id, status, roomnum, usingstatus, healthstatus, disinfectionstatus, machinename, mark, unitnum, machineroom, "
                + "macaddress, checkman, checktime, equipmenttype, pid FROM machine WHERE (mark = 0) AND (usingstatus = '启用') AND (status = '空闲') and mark = 0";
            return db.get_DataTable(str);
        }
        #endregion
        //分配机组的算法
        public string distributionmachine()
        {
            ArrayList list = new ArrayList();
            ArrayList list1 = new ArrayList();
            ArrayList list2 = new ArrayList();
            //找出机组
            string str = "select id from machine where mark = 0 and usingstatus = '启用' and status='空闲'";

            SqlDataReader sr = db.get_Reader(str);
            //煎药机
            while (sr.Read())
            {
                string id = sr["id"].ToString();
                int machineid = Convert.ToInt32(id);
                list.Add(machineid);
            }
            string str1 = "";
            string str2 = "";
            string num = "";
            string num1 = "";
            int count = 0;
            int count1 = 0;
            int count2 = 0;
            for (int i = 0; i < list.Count; i++)
            {
                str1 = "select count(machineid) as num  from tisaneunit where machineid ='" + list[i] + "'";
                SqlDataReader sr1 = db.get_Reader(str1);//从煎药表里找到每个煎药机被分配的处方的数量

                str2 = "select count(*) as num1 from  tisaneunit  where packstatus = 1 and machineid ='" + list[i] + "'";
                SqlDataReader sr2 = db.get_Reader(str2);//每个煎药机被分配且已包装好的处方的数量



                if (sr1.Read())
                {
                    num = sr1["num"].ToString();
                }
                else
                {
                    num = "0";
                }
                count1 = Convert.ToInt32(num);
                if (sr2.Read())
                {
                    num1 = sr2["num1"].ToString();
                }
                else
                {
                    num1 = "0";
                }
                count2 = Convert.ToInt32(num1);



                count = count1 - count2;//每个煎药机被分配处方的数量-这些处方已包装的数量

                list1.Add(count);

            }


            int min = 10000;
            int pos = 0;
            for (int i = 0; i < list1.Count; i++)
            {
                if (Convert.ToInt32(list1[i]) < min)
                {
                    min = Convert.ToInt32(list1[i]);
                    pos = i;
                }
            }
            return list[pos].ToString();//最先分配的煎药机的id
        }


        //泡药警告
        public string bubblewarning()
        {
            string sql3 = "";
            sql3 = "select ID,Pspnum,customid,delnum,(select bubblewarning from warning where hospitalid = p.Hospitalid and type=0) as bubblewarning,(select doingtime from bubble where pid = p.id) as doingtime,(SELECT bubbleperson FROM bubble WHERE pid = p.id) as bp,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
            sql3 += "diagresult,(select warningtime from Audit where pid = p.id) as warningtime,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate";
            sql3 += " from prescription as p where id in (select pid from Audit)";

            SqlDataReader sr3 = db.get_Reader(sql3);//复核通过的所有信息

           System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;//当前时间
            string warningtime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
             ArrayList list2 = new ArrayList();
             ArrayList list1 = new ArrayList();
             ArrayList list3 = new ArrayList();
             ArrayList list4 = new ArrayList();
             ArrayList list5 = new ArrayList();



            while (sr3.Read())
            {

                // sr3["bubblewarning"].ToString();
                // sr3["getdrugtime"].ToString();
                 string d1 = sr3["bubblewarning"].ToString();//泡药警告时间

                 list1.Add(d1);
             
                string drugtime = sr3["getdrugtime"].ToString();//得到该处方号的取药时间
                //  DateTime d2 = Convert.ToDateTime(sr3["getdrugtime"].ToString());
                list2.Add(drugtime);  
 

                  string id = sr3["ID"].ToString();//当前id煎药单号
                  list3.Add(id);



              string hospitalid = sr3["hospitalid"].ToString();

               list4.Add(hospitalid);
               
                 string awarningtime = sr3["warningtime"].ToString();

               list5.Add(awarningtime);

            }
            for (int i = 0; i < list2.Count; i++)
            {



                string sql8 = "select status from warning where hospitalid = '"+list4[i]+"'";

                SqlDataReader sr8 = db.get_Reader(sql8);
                string status = "";//医院预警开关状态

                if (sr8.Read())
                {
                    status = sr8["status"].ToString();

                }




                string d1 = list1[i].ToString();//泡药警告时间

                DateTime d2 = Convert.ToDateTime(list2[i].ToString());//取药时间


                string strY = currentTime.ToString("yyyy-MM-dd HH:mm:ss");

                DateTime d3 = Convert.ToDateTime(strY);//当前时间



                TimeSpan d4 = d2.Subtract(d3);//取药时间- 当前时间



                //取药时间- 当前时间
                int time = Convert.ToInt32(d4.Days.ToString()) * 24 * 60 + Convert.ToInt32(d4.Hours.ToString()) * 60 + Convert.ToInt32(d4.Minutes.ToString());
                //泡药警告时间
                if (d1 == "")
                {
                    d1 = "-10000000";
                }
                int time2 = Convert.ToInt32(d1);
                if (status == "0")
                {
                    time2 = -10000000;
                }


                if (time < time2)
                {
                    string strsql1 = "update Audit set bubblewarningstatus = 1,warningtype='泡药预警' where pId = '" + list3[i] + "'";

                    db.cmd_Execute(strsql1);

                   // if (list5[i].ToString() == "1970-1-1 0:00:00")
                    if (list5[i].ToString() == "" || Convert.ToDateTime(list5[i].ToString()).ToString("yyyy-MM-dd HH:mm:ss") == "1970-01-01 00:00:00")
                    {
                        string strsql2 = "update Audit set warningtime ='" + warningtime + "' where pId = '" + list3[i] + "'";

                        db.cmd_Execute(strsql2);
                    }
                }
                else
                {
                    string strsql2 = "update Audit set bubblewarningstatus = 0,warningtype='暂无预警',warningtime='1970-1-1 00:00:00' where pId = '" + list3[i] + "'";

                    db.cmd_Execute(strsql2);
                }


            }
            string strS = currentTime.ToString("yyyy/MM/dd 00:00:00");

            string strS2 = currentTime.ToString("yyyy/MM/dd 23:59:59");

            string str2 = "";
            string str = "select pId from  Audit where bubblewarningstatus = 1 and pid not in (select pid from bubble) and pid in (select id from prescription as p where  p.dotime between '" + strS + "' and  '" + strS2 + "')";
            SqlDataReader sr =db.get_Reader(str);

            while (sr.Read())
            {

                str2 += sr["pId"].ToString() +",";

            }
            return str2;
        }
        #region 通过权限查询人员
        public SqlDataReader findNameAll()
        {
            string sql = "select * from  Employee where Role ='3' or  Role ='0'";

            return db.get_Reader(sql);
        }

        #endregion



        public bool checkisdone(string id)
        {

            bool result = false;
            string str = "select bubblestatus from bubble where pid ='" + id + "' ";

            SqlDataReader sdr = db.get_Reader(str);

            if (sdr.Read())
            {
                if (sdr["bubblestatus"].ToString() == "1")
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

            }




            return result;

        }

    }
}
