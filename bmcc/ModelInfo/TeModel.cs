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
    public class TeModel
    {
        public int updateTisaneinfo(int id, int status, string endDate, string tisaneNum, string starttime)
        {
            DateTime d1 = Convert.ToDateTime(endDate);//当前时间
            DateTime d2 = Convert.ToDateTime(starttime);//开始时间

            TimeSpan d3 = d1.Subtract(d2);//泡药时间

            int doingtime = Convert.ToInt32(d3.Days.ToString()) * 24 * 60 + Convert.ToInt32(d3.Hours.ToString()) * 60 + Convert.ToInt32(d3.Minutes.ToString());//转化为分钟数

            DataBaseLayer db = new DataBaseLayer();
            string sql = "update tisaneinfo set tisanestatus='" + status + "',endDate='" + endDate + "',tisanetime='" + doingtime + "' where id=" + id;

            string sql2 = "update prescription set curstate = '煎药完成'  where id = '" + tisaneNum + "'";
            db.cmd_Execute(sql2);
            int count = db.cmd_Execute(sql);
            return count;

        }
        #region 通过权限查询人员
        public SqlDataReader findNameAll()
        {
            DataBaseLayer db = new DataBaseLayer();
            string sql = "select * from  Employee where Role ='4' or  Role ='0'";

            return db.get_Reader(sql);
        }

        #endregion
        public int addTisaneinfo(int userid, string wordDate, string barcode, string wordcontent, string tisaneNum, string imgname, string waterYield, string userName)
        {
            DataBaseLayer db = new DataBaseLayer();
            string sql = "insert into tisaneinfo(employeeId,starttime,barcode,wordcontent,pid,imgname,waterYield,tisaneman,tisanestatus) values('" + userid + "','" + wordDate + "','" + barcode + "','" + wordcontent + "','" + tisaneNum + "','" + imgname + "','" + waterYield + "','" + userName + "','0')";
            string str2 = "update prescription set doperson ='" + userName + "',curstate = '开始煎药'  where id = '" + tisaneNum + "'";
            db.cmd_Execute(str2);
            int count = db.cmd_Execute(sql);
            if (count > 0)
            {
                //下发煎药指令
                BaseInfo.Insert_TisaneCmd(Convert.ToDateTime(wordDate), db, tisaneNum);
                string sqlStr = "update machine set status='忙碌',pid='" + tisaneNum + "' where id=(select machineid from tisaneunit where pid='" + tisaneNum + "')";

                db.cmd_Execute(sqlStr);

            }
            return count;
        }
        public DataTable findTisaneinfoBybarcode(string barcode)
        {
            DataBaseLayer db = new DataBaseLayer();
            string sql = "select * from tisaneinfo where pid='" + barcode + "'";

            DataTable dt = db.get_DataTable(sql);
            return dt;

        }
        public SqlDataReader findTisaneAll()
        {
            string sql = "select * from machine where mark = 0";
            DataBaseLayer db = new DataBaseLayer();

            return db.get_Reader(sql);
        }

        public SqlDataReader findmachinenamebyid(int id)
        {
            string sql = "select machinename from machine where id = '" + id + "'";
            DataBaseLayer db = new DataBaseLayer();

            return db.get_Reader(sql);
        }




        public SqlDataReader findTisaneAllbyId(int id)
        {
            string sql = "select * from machine where id = '" + id + "'";
            DataBaseLayer db = new DataBaseLayer();

            return db.get_Reader(sql);
        }
        public int addunit(int id, string tisaneid, string tisaneman, string ps)
        {
            DataBaseLayer db = new DataBaseLayer();
            string str = "select * from tisaneinfo where pid = '" + id + "'";
            //db.get_Reader(str);
            int result = 0;
            if (db.get_Reader(str).Read())
            {
                result = 0;
            }
            else
            {
                string str2 = "select * from prescription where id = '" + id + "'";
                SqlDataReader sr = db.get_Reader(str2);
                string tisanemethod = "";
                string tisanescheme = "";

                if (sr.Read())
                {
                    tisanemethod = sr["decmothed"].ToString();
                    tisanescheme = sr["decscheme"].ToString();
                }


                string sql = "INSERT INTO [tisaneinfo](pid,machineid,tisaneman,tisanemethod,tisanescheme,remark) VALUES('" + id + "','" + tisaneid + "','" + tisaneman + "','" + tisanemethod + "','" + tisanescheme + "','" + ps + "')";
                result = db.cmd_Execute(sql);
                if (result != 0)
                {

                    string sql2 = "update bubble set distributionstatus = 1 where pid = '" + id + "'";
                    db.cmd_Execute(sql2);
                }
            }

            return result;
        }


        public DataTable searchTisaneClass(string pspnum)
        {
            DataBaseLayer db = new DataBaseLayer();
            string strSQL;
            if (pspnum == "")
            {
                strSQL = "select (select pid from tisaneunit where id=t.id) as id,(select machinename from machine where id = t.machineid) as machinename,(select pspnum from prescription where id = t.pid) as ps,(select bubblestatus from bubble where pid = t.pid) as bs from tisaneunit as t  order by t.pid desc";
            }
            else
            {
                strSQL = "select (select pid from tisaneunit where id=t.id) as id,(select machinename from machine where id = (select machineid from tisaneunit where pid = (select id from prescription where pspnum = '" + pspnum + "') )) as machinename,(select distinct pspnum from prescription where  pspnum = '" + pspnum + "')as ps,(select bubblestatus from bubble where pid in (select id from prescription where pspnum = '" + pspnum + "')) as bs from tisaneunit as t where pid in (select id from prescription where pspnum = '" + pspnum + "') order by t.pid desc";
            }

            DataTable dt = db.get_DataTable(strSQL);

            return dt;
        }

        public DataTable getTisaneMachinInfobyid(int TisaneMachine)
        {
            string str = "";
            DataBaseLayer db = new DataBaseLayer();


            if (TisaneMachine == 0)
            {

                str = "select distinct * from machine where mark =0";
            }
            else
            {

                str = "select  distinct * from machine where id = '" + TisaneMachine + "'";
            }

            DataTable dt = db.get_DataTable(str);
            return dt;
        }


        public SqlDataReader getTisaneMachinInfo()
        {
            string str = "";
            DataBaseLayer db = new DataBaseLayer();

            str = "select * from machine where mark = 0";

            return db.get_Reader(str);
        }




        public DataTable getPackingMachineInfobyid(int packid)
        {
            DataBaseLayer db = new DataBaseLayer();

            string str = "";
            if (packid == 0)
            {

                str = "select  distinct  * from machine where mark = 1";
            }
            else
            {

                str = "select distinct * from machine where id = '" + packid + "'";
            }



            DataTable dt = db.get_DataTable(str);
            return dt;
        }


        public SqlDataReader getPackingMachineInfo()
        {
            DataBaseLayer db = new DataBaseLayer();
            string str = "";
            str = "select * from machine where mark =1";





            return db.get_Reader(str);
        }
        public DataTable getPreBytisaneid(int userid, string date)
        {
            DataBaseLayer db = new DataBaseLayer();

            string str = "";
            str = "select p.ID,p.Pspnum,p.customid,p.delnum,p.Hospitalid,p.name,p.sex,p.age,p.phone,p.address,p.department,p.inpatientarea,p.ward,p.sickbed,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,"
             + "p.diagresult,p.dose,p.takenum,p.getdrugtime,p.getdrugnum,p.takemethod,p.decscheme,p.oncetime,p.twicetime,p.packagenum,p.dotime,p.doperson,p.dtbcompany,p.dtbaddress,p.dtbphone,p.dtbtype,p.soakwater,p.soaktime,p.labelnum,p.remark,p.doctor,p.footnote,p.ordertime,p.curstate"
             + ",t.tisanestatus tstatus,t.starttime tstarttime,t.endDate tendDate,t.tisanetime tisanetime,t.waterYield waterYield,(SELECT machinename FROM machine WHERE (id = (SELECT   machineid FROM tisaneunit AS tisaneunit_1 WHERE (pid = p.id)))) as machinename from prescription as p inner join tisaneinfo t on p.id=t.pid and p.id not in (select pid from InvalidPrescription) where t.employeeId=" + userid + " and CONVERT(varchar, t.starttime, 120) like '%" + date + "%' order by p.ID desc";



            DataTable dt = db.get_DataTable(str);
            return dt;
        }

        public DataTable getPreBytisaneid(int tisaneid)
        {
            DataBaseLayer db = new DataBaseLayer();

            string str = "";
            if (tisaneid == 0)
            {


                str = "select ID,Pspnum,(select tisaneman from tisaneinfo where pid = p.id ) as tisaneman,(select waterYield from  tisaneinfo where pid = p.id) as waterYield,(select tisanestatus from tisaneinfo where pid = p.id ) as tisanestatus,(select starttime from tisaneinfo where pid = p.id ) as  starttime,(select endDate from tisaneinfo where pid = p.id ) as  endDate,(select waterYield from tisaneinfo where pid = p.id ) as waterYield,(select machinename from machine where id = (select machineid from tisaneunit where pid = p.id )) as  machineid,customid,delnum,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,";
                str += "diagresult,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate,RemarksA,RemarksB from prescription as p where id in (select pid from tisaneinfo) order by p.id desc";


            }
            else
            {

                // str = "select Pspnum,(select id from tisaneinfo where id = '" + tisaneid + "') as id,customid,delnum,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,";
                //str += "diagresult,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate from prescription as p where id = (select pid from tisaneinfo where id = '" + tisaneid + "')";

                str = "select ID,Pspnum,(select tisaneman from tisaneinfo where pid = p.id ) as tisaneman,(select tisanestatus from tisaneinfo where  pid = p.id ) as tisanestatus,(select starttime from tisaneinfo where  pid = p.id) as  starttime,(select endDate from tisaneinfo where pid = p.id ) as  endDate,(select waterYield from tisaneinfo where pid = p.id ) as waterYield,(select machinename from machine where id = (select machineid from tisaneunit where  pid = p.id )) as  machineid,customid,delnum,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,";
                str += "diagresult,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate,RemarksA,RemarksB from prescription as p  where id in (select pid from tisaneinfo where pid ='" + tisaneid + "') and p.id not in (select pid from InvalidPrescription) order by p.id desc";



            }



            DataTable dt = db.get_DataTable(str);
            return dt;
        }

        public DataTable getTisaneInfoByTisanenum(string tisanenum)
        {
            DataBaseLayer db = new DataBaseLayer();

            string str = "";
            if (tisanenum == "0")
            {
                str = "SELECT distinct id,(select machinename from machine where id = t.machineid) as machineid,pid,remark,tisanemethod,tisanestatus, tisaneman, starttime, timesetting,(select pspnum from prescription as p where p.id= t.pid  and p.id not in (select pid from InvalidPrescription)) as ps from tisaneinfo as t order by t.pid desc ";
            }
            else
            {


                str = "SELECT distinct id,(select machinename from machine where id = t.machineid) as machineid, pid, remark,tisanemethod ,tisanestatus, tisaneman, starttime, timesetting,(select pspnum from prescription where id = t.pid) as ps from tisaneinfo as t where machineid ='" + tisanenum + "' order by t.pid desc  ";

            }

            DataTable dt = db.get_DataTable(str);
            return dt;
        }



        public DataTable queryTisaneInfo(int tisaneid, string tisaneman, int tisanestatus, int tisanemethod, string STime, string ETime)
        {
            DataBaseLayer db = new DataBaseLayer();
            string sql = "";





            /* //预警
             ArrayList list = new ArrayList();
             ArrayList list1 = new ArrayList();
             ArrayList list2 = new ArrayList();
             ArrayList list3 = new ArrayList();


             db = new DataBaseLayer();
             System.DateTime currentTime = new System.DateTime();
             currentTime = System.DateTime.Now;
             string sql3 = "";

             sql3 = "select ID,Pspnum,customid,delnum,(select tisanewarning from warning where hospitalid = p.Hospitalid) as tisanewarning,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
             sql3 += "diagresult,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate";
             sql3 += " from prescription as p where  id not in (select pid from InvalidPrescription)";

             SqlDataReader sr3 = db.get_Reader(sql3);



             while (sr3.Read())
             {

                 // sr3["bubblewarning"].ToString();
                 // sr3["getdrugtime"].ToString();
                 // string d1 = sr3["bubblewarning"].ToString();

                 // list1.Add(d1);

                 string drugtime = sr3["getdrugtime"].ToString();
                 //  DateTime d2 = Convert.ToDateTime(sr3["getdrugtime"].ToString());
                 list2.Add(drugtime);//取药时间

                 string tisanewarning = sr3["tisanewarning"].ToString();
                 list1.Add(tisanewarning);//煎药预警时间

                 //获取处方号
                 string id = sr3["ID"].ToString();
                 list3.Add(id);
             }

             for (int i = 0; i < list2.Count; i++)
             {


                 string d1 = list1[i].ToString();//预警时间


                 DateTime d2 = Convert.ToDateTime(list2[i].ToString());//取药时间


                 string strY = currentTime.ToString("yyyy-MM-dd HH:mm:ss");

                 DateTime d3 = Convert.ToDateTime(strY);//当前时间



                 TimeSpan d4 = d2.Subtract(d3);//取药时间-当前时间

                 int time = Convert.ToInt32(d4.Days.ToString()) * 24 * 60 + Convert.ToInt32(d4.Hours.ToString()) * 60 + Convert.ToInt32(d4.Minutes.ToString());
                 int time2 = Convert.ToInt32(d1);
                 if (time < time2)
                 {
                     string strsql1 = "update tisaneinfo set warningstatus = 1 where pid = '" + list3[i] + "'";

                     db.cmd_Execute(strsql1);
                 }
             }
             */
            // if (tisaneid == 0 && tisaneman == "0" && tisanestatus == 0 && tisanemethod == 0 && tisanetime == "0")endDate
            /// {
            sql = "select  ID,Pspnum,(select warningstatus from tisaneinfo where pid = p.id) as warningstatus,(select remark from tisaneinfo where pid = p.id) as mark,delnum,(select tisaneman from tisaneinfo where pid = p.id ) as tisaneman,(select tisanestatus from tisaneinfo where pid = p.id ) as tisanestatus,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
            sql += "diagresult,(select starttime from tisaneinfo where pid = p.id ) as starttime,(select tisanetime from tisaneinfo where pid = p.id ) as tisanetime,(select endDate from tisaneinfo where pid = p.id ) as endDate,(select waterYield from tisaneinfo where pid = p.id ) as waterYield,(select machinename from machine where id = (select machineid from tisaneunit where pid = p.id )) as machineid,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,RemarksA,RemarksB,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate";
            sql += " from prescription as p where  id not in (select pid from InvalidPrescription)  and id in (select pid from tisaneinfo where 1=1";

            if (tisaneid != 0)
            {
                sql += "and pid ='" + tisaneid + "'";
            }

            if (tisaneman != "0")
            {
                sql += "and tisaneman ='" + tisaneman + "'";
            }
            if (tisanestatus != 2)
            {
                sql += "and tisanestatus ='" + tisanestatus + "'";
            }
            //if (tisanemethod !=0)
            //{
            //     sql += "and tisanemethod ='" + tisanemethod + "'";
            // }

            if (tisanemethod != 0)
            {
                sql += "and pid in (select id from prescription where decmothed ='" + tisanemethod + "')";
            }
            /*if (tisanetime != "0")
            {
                sql += "and tisanetime ='" + tisanetime + "'";
            }*/
            if (STime != null && STime.Length > 0)
            {
                DateTime d = Convert.ToDateTime(STime);
                string strS = d.ToString("yyyy/MM/dd 00:00:00");
                sql += "and starttime >='" + strS + "'";

            }


            if (ETime != null && ETime.Length > 0)
            {
                DateTime d4 = Convert.ToDateTime(ETime);
                string strE = d4.ToString("yyyy/MM/dd 23:59:59");
                sql += "and starttime  <='" + strE + "'";

            }


            sql += ")";
            sql += " order by ID desc";

            DataTable dt = db.get_DataTable(sql);
            return dt;
        }
        public DataTable queryTisaneInfoDao(int tisaneid, string tisaneman, int tisanestatus, int tisanemethod, string STime, string ETime)
        {
            DataBaseLayer db = new DataBaseLayer();
            string sql = "";


            sql = "select  ID,Pspnum,delnum,(select tisaneman from tisaneinfo where pid = p.id ) as tisaneman, (select case convert(nvarchar(50), tisanestatus)  when 0 then '开始煎药' when 1 then '煎药完成' else convert(nvarchar(50), tisanestatus) end from  tisaneinfo where pid = p.id ) as tisanestatus ,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,name,case convert(nvarchar(50), sex)  when 1 then '男' when 2 then '女' else convert(nvarchar(50), sex) end,age,phone,address,department,inpatientarea,ward,sickbed,";
            sql += "diagresult,(select starttime from tisaneinfo where pid = p.id ) as starttime,(select tisanetime from tisaneinfo where pid = p.id ) as tisanetime,(select endDate from tisaneinfo where pid = p.id ) as endDate,(select waterYield from tisaneinfo where pid = p.id ) as waterYield,(select machinename from machine where id = (select machineid from tisaneunit where pid = p.id )) as machineid,dose,takenum,getdrugtime,getdrugnum,takemethod,case decscheme when 1 then '微压（密闭）解表（15min)' when 2 then '微压（密闭）汤药（15min）' when 3 then '微压（密闭）补药（15min）' when 4 then '常压解表（10min，10min）' when 5 then '常压汤药（20min，15min）' when 6 then '常压补药（25min，20min）'when 20 then '先煎解表（10min，10min，10min）'when 21 then '先煎汤药（10min，20min，15min）'when 22 then '先煎补药（10min，25min，20min）' when 36 then '后下解表（10min（3：7），10min）' when 37 then '后下汤药（20min（13：7），15min）' when 38 then '后下补药（25min（18：7），20min）' when 81 then '微压自定义' when 82 then '常压自定义'when 83 then '先煎自定义' when 84 then '后下自定义' else decscheme end,oncetime,RemarksA,RemarksB,twicetime,packagenum,dotime,dtbcompany,dtbaddress,dtbphone,case dtbtype when 1 then '顺丰' when 2 then '圆通' when 3 then '中通' else dtbtype end ,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime";
            sql += " from prescription as p where  id not in (select pid from InvalidPrescription)  and id in (select pid from tisaneinfo where 1=1";

            if (tisaneid != 0)
            {
                sql += "and pid ='" + tisaneid + "'";
            }

            if (tisaneman != "0")
            {
                sql += "and tisaneman ='" + tisaneman + "'";
            }
            if (tisanestatus != 2)
            {
                sql += "and tisanestatus ='" + tisanestatus + "'";
            }
            if (tisanemethod != 0)
            {
                sql += "and tisanemethod ='" + tisanemethod + "'";
            }
            if (STime != null && STime.Length > 0)
            {
                DateTime d = Convert.ToDateTime(STime);
                string strS = d.ToString("yyyy/MM/dd 00:00:00");
                sql += "and starttime >='" + strS + "'";

            }


            if (ETime != null && ETime.Length > 0)
            {
                DateTime d4 = Convert.ToDateTime(ETime);
                string strE = d4.ToString("yyyy/MM/dd 23:59:59");
                sql += "and starttime  <='" + strE + "'";

            }
            sql += ")";
            sql += " order by ID desc";

            DataTable dt = db.get_DataTable(sql);
            return dt;
        }
        #region 煎药大屏显示信息
        public DataTable DecoctingDisplayInfo()
        {

            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;//当前时间


            string strS = currentTime.ToString("yyyy/MM/dd 00:00:00");

            string strS2 = currentTime.ToString("yyyy/MM/dd 23:59:59");


            DataBaseLayer db = new DataBaseLayer();
            string sql = "";
            sql = "select ID,Pspnum,(select warningstatus from tisaneinfo where pid = p.id) as warningstatus,(select remark from tisaneinfo where pid = p.id) as mark,customid,delnum,(select tisaneman from tisaneinfo where pid = p.id ) as tisaneman,(select tisanestatus from tisaneinfo where pid = p.id ) as tisanestatus,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
            sql += "diagresult,(select starttime from tisaneinfo where pid = p.id ) as starttime,(select tisanetime from tisaneinfo where pid = p.id ) as tisanetime,(select machinename from machine where id = (select machineid from tisaneinfo where pid = p.id )) as machineid,(select tisanetime from tisaneinfo where pid = p.id ) as tisanetime,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,RemarksA,RemarksB,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate";
            sql += " from prescription as p where  id not in (select pid from InvalidPrescription) and id in (select pid from tisaneinfo ) and id not  in (select DecoctingNum from Packing )  and p.Hospitalid  in (select id from hospital where ChineseDisplayState='0') and p.dotime between '" + strS + "' and '" + strS2 + "' order by ID desc";

            DataTable dt = db.get_DataTable(sql);
            return dt;
        }
        #endregion
        public int addtisaneman(int id, string tisaneman)
        {



            return 0;
        }
        public SqlDataReader findTisaneinfoByid(int id)
        {

            DataBaseLayer db = new DataBaseLayer();
            string sql = "";
            sql = "select ID,Pspnum,customid,delnum,(select tisaneman from tisaneinfo where pid = p.id ) as tisaneman,(select tisanestatus from tisaneinfo where pid = p.id ) as tisanestatus,(select id from tisaneinfo where pid = p.id ) as tisaneid,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
            sql += "diagresult,(select starttime from tisaneinfo where pid = p.id ) as starttime,(select tisanetime from tisaneinfo where pid = p.id ) as tisanetime,(select machineid from tisaneinfo where pid = p.id ) as machineid,(select tisanetime from tisaneinfo where pid = p.id ) as tisanetime,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate";
            sql += " from prescription as p where id in (select pid from tisaneinfo where id ='" + id + "')and id not in (select pid from InvalidPrescription)";

            SqlDataReader sr = db.get_Reader(sql);


            return sr;
        }

        public int updateTisaneinfo(int id, string tisaneman, int machineid, int tisanestatus)
        {

            DataBaseLayer db = new DataBaseLayer();
            string sql = "";
            sql = "update tisaneinfo set tisaneman = '" + tisaneman + "',machineid='" + machineid + "',tisanestatus='" + tisanestatus + "' where id = '" + id + "' ";


            int end = 0;
            end = db.cmd_Execute(sql);

            //string result = sr["id"].ToString();
            // a = Convert.ToInt32(result);
            //sql = "update bubble set bubbleperson = '" + bubbleman + "',pid='" + a + "' where pid = '" + id + "' ";
            //  end = db.cmd_Execute(sql);

            return end;

        }


        public int deleteTisaneinfoById(int id)
        {
            DataBaseLayer db = new DataBaseLayer();
            string strSql = "delete from tisaneinfo where pid = '" + id + "'";
            int n = db.cmd_Execute(strSql);


            return n;
        }

        public DataTable getBubbleInfo(string name, int status)
        {
            ArrayList list = new ArrayList();
            ArrayList list1 = new ArrayList();
            ArrayList list2 = new ArrayList();
            ArrayList list3 = new ArrayList();


            DataBaseLayer db = new DataBaseLayer();
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            string sql3 = "";

            sql3 = "select ID,Pspnum,customid,delnum,(select tisanewarning from warning where hospitalid = p.Hospitalid) as tisanewarning,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
            sql3 += "diagresult,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate";
            sql3 += " from prescription as p where id in (select pid from tisaneinfo where tisanestatus = 0)and id not in (select pid from InvalidPrescription)";

            SqlDataReader sr3 = db.get_Reader(sql3);



            while (sr3.Read())
            {

                // sr3["bubblewarning"].ToString();
                // sr3["getdrugtime"].ToString();
                // string d1 = sr3["bubblewarning"].ToString();

                // list1.Add(d1);

                string drugtime = sr3["getdrugtime"].ToString();
                //  DateTime d2 = Convert.ToDateTime(sr3["getdrugtime"].ToString());
                list2.Add(drugtime);//取药时间

                string tisanewarning = sr3["tisanewarning"].ToString();
                list1.Add(tisanewarning);//煎药预警时间

                //获取处方号
                string id = sr3["ID"].ToString();
                list3.Add(id);
            }

            for (int i = 0; i < list2.Count; i++)
            {


                string d1 = list1[i].ToString();//预警时间


                DateTime d2 = Convert.ToDateTime(list2[i].ToString());//取药时间


                string strY = currentTime.ToString("yyyy-MM-dd HH:mm:ss");

                DateTime d3 = Convert.ToDateTime(strY);//当前时间



                TimeSpan d4 = d2.Subtract(d3);//取药时间-当前时间

                int time = Convert.ToInt32(d4.Days.ToString()) * 24 * 60 + Convert.ToInt32(d4.Hours.ToString()) * 60 + Convert.ToInt32(d4.Minutes.ToString());
                int time2 = Convert.ToInt32(d1);
                if (time < time2)
                {
                    string strsql1 = "update tisaneinfo set warningstatus = 1 where pid = '" + list3[i] + "'";

                    db.cmd_Execute(strsql1);
                }


            }

            if (status == 1)
            {
                string strY = currentTime.ToString("yyyy-MM-dd HH:mm:ss");




                DateTime d2 = Convert.ToDateTime(strY);


                string strsql = "select starttime from bubble where bubblestatus = 1";
                SqlDataReader sr = db.get_Reader(strsql);
                while (sr.Read())
                {
                    string a = sr["starttime"].ToString();

                    list.Add(a);

                }

                for (int i = 0; i < list.Count; i++)
                {

                    string a = list[i].ToString();

                    DateTime d1 = Convert.ToDateTime(a);

                    TimeSpan d3 = d2.Subtract(d1);
                    string doingtime = d3.Days.ToString() + ":" + d3.Hours.ToString() + ":" + d3.Minutes.ToString();


                    string strsql1 = "update bubble set doingtime= '" + doingtime + "' where bubblestatus = 1";

                    db.cmd_Execute(strsql1);

                }




            }








            string sql = "";
            if (status == 3)
            {
                sql = "select ID,Pspnum,customid,delnum,(select Distinct bubblestatus from bubble where bubblestatus = 0) as bubblestatus,(select bubblewarning from warning where hospitalid = p.Hospitalid) as bubblewarning,(select warningstatus from bubble where pid = p.id) as warningstatus,(select doingtime from bubble where pid = p.id) as doingtime,(SELECT bubbleperson FROM bubble WHERE pid = p.id) as bp,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
                sql += "diagresult,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate";
                sql += " from prescription as p where id in (select prescriptionId from AgainPrescriptionCheckState where checkStatus = 1 and addbubblestatus = 0)and id not in (select pid from InvalidPrescription)";

            }
            else if (status == 4)
            {
                sql = "select ID,Pspnum,customid,delnum,(select Distinct bubblestatus from bubble where bubblestatus = 2) as bubblestatus,(select bubblewarning from warning where hospitalid = p.Hospitalid) as bubblewarning,(select doingtime from bubble where pid = p.id) as doingtime,(select warningstatus from bubble where pid = p.id) as warningstatus,(SELECT bubbleperson FROM bubble WHERE pid = p.id) as bp,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
                sql += "diagresult,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate";
                sql += " from prescription as p where id in (select pid from bubble where distributionstatus = 0 and bubblestatus = 2)and id not in (select pid from InvalidPrescription)";
            }
            else
            {

                if (name == "0")
                {
                    sql = "select ID,Pspnum,customid,delnum,(select Distinct bubblestatus from bubble where bubblestatus = '" + status + "') as bubblestatus,(select bubblewarning from warning where hospitalid = p.Hospitalid) as bubblewarning,(select doingtime from bubble where pid = p.id) as doingtime,(select warningstatus from bubble where pid = p.id) as warningstatus,(SELECT bubbleperson FROM bubble WHERE pid = p.id) as bp,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
                    sql += "diagresult,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate";
                    sql += " from prescription as p where id in (select pid from bubble where bubblestatus = '" + status + "')and id not in (select pid from InvalidPrescription)";
                }
                else
                {
                    sql = "select ID,Pspnum,customid,delnum,(select Distinct bubblestatus from bubble where bubblestatus = '" + status + "') as bubblestatus,(select bubblewarning from warning where hospitalid = p.Hospitalid) as bubblewarning,(select warningstatus from bubble where pid = p.id) as warningstatus,(select doingtime from bubble where pid = p.id) as doingtime,(SELECT DISTINCT bubbleperson FROM bubble WHERE (bubbleperson = '" + name + "')) as bp,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
                    sql += "diagresult,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate";
                    sql += " from prescription as p where id in (select pid from bubble where bubbleperson = '" + name + "' and bubblestatus = '" + status + "')and id not in (select pid from InvalidPrescription)";
                }


            }


            DataTable dt = db.get_DataTable(sql);

            return dt;
        }



        public int addtisaneinfo(string tisanebarcode, string tisaneman, string mark)
        {
            DataBaseLayer db = new DataBaseLayer();
            string tisaneid = tisanebarcode.Substring(4, 10);

            string originaltisaneid = tisaneid.TrimStart('0');

            String sql = "";

            string per = tisaneman.Substring(6);



            string employeeid = "";
            string str6 = "select id from employee where EmNumAName ='" + tisaneman + "'";
            SqlDataReader sr6 = db.get_Reader(str6);

            if (sr6.Read())
            {

                employeeid = sr6["id"].ToString();

            }




            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            string strtime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");//

            int end = 0;//添加失败
            string str2 = "select * from prescription where id not in (select pid from InvalidPrescription) and id = '" + originaltisaneid + "'";
            SqlDataReader sr2 = db.get_Reader(str2);

            if (sr2.Read())
            {

                string str3 = "select * from bubble where pid = '" + originaltisaneid + "' and bubblestatus = 1";
                SqlDataReader sr3 = db.get_Reader(str3);
                if (sr3.Read())
                {

                    string str = "select * from tisaneinfo where pid = '" + originaltisaneid + "'";
                    SqlDataReader sr = db.get_Reader(str);
                    if (sr.Read())
                    {

                        if (sr["tisanestatus"].ToString() == "1")
                        {

                            end = 4;//煎药已完成


                        }
                        else
                        {
                            //  DateTime d1 = Convert.ToDateTime(strtime);//当前时间
                            // DateTime d2 = Convert.ToDateTime(sr["starttime"].ToString());//开始时间

                            // TimeSpan d3 = d1.Subtract(d2);//泡药时间

                            // int doingtime = Convert.ToInt32(d3.Days.ToString()) * 24 * 60 + Convert.ToInt32(d3.Hours.ToString()) * 60 + Convert.ToInt32(d3.Minutes.ToString());//转化为分钟数
                            DateTime d1 = Convert.ToDateTime(strtime);//当前时间
                            DateTime d2 = Convert.ToDateTime(sr["starttime"].ToString());//开始时间

                            TimeSpan d3 = d1.Subtract(d2);//煎药时间

                            int doingtime = Convert.ToInt32(d3.Days.ToString()) * 24 * 60 + Convert.ToInt32(d3.Hours.ToString()) * 60 + Convert.ToInt32(d3.Minutes.ToString());//转化为分钟数


                            string str1 = "update tisaneinfo set tisanestatus =1,tisanetime = '" + doingtime + "',enddate='" + strtime + "' where pid = '" + originaltisaneid + "'";

                            if (db.cmd_Execute(str1) == 1)
                            {
                                end = 2;//煎药成功



                                // string machineid = distributionmachine();
                                // string str3 = "insert into tisaneunit(pid,machineid) values('" + originaltisaneid + "','" + machineid + "')";
                                //if (db.cmd_Execute(str3) == 1)
                                // {
                                //     end = 6;//泡药成功，且成功分配机组



                                //}
                                string sql7 = "update prescription set curstate = '煎药完成'  where id = '" + originaltisaneid + "'";

                                db.cmd_Execute(sql7);//更新处方表里的当前状态


                            }
                            else
                            {
                                end = 5;//煎药未成功
                            }
                        }

                    }
                    else
                    {
                        string scheme = "";
                        string machineid = "";
                        string str4 = "select decscheme from prescription where id = '" + originaltisaneid + "'";
                        string str5 = "select machineid from tisaneunit where pid = '" + originaltisaneid + "'";
                        SqlDataReader sr4 = db.get_Reader(str4);
                        SqlDataReader sr5 = db.get_Reader(str5);
                        if (sr4.Read())
                        {
                            //   scheme = db.get_Reader(str4)["decscheme"].ToString();


                            scheme = sr4["decscheme"].ToString();


                        }
                        if (sr5.Read())
                        {

                            machineid = sr5["machineid"].ToString();

                        }


                        sql = "INSERT INTO [tisaneinfo](pid,starttime,tisanescheme,machineid,tisaneman,remark,employeeId) VALUES('" + originaltisaneid + "','" + strtime + "','" + scheme + "','" + machineid + "','" + per + "','" + mark + "','" + employeeid + "')";


                        if (db.cmd_Execute(sql) == 1)
                        {

                            //下发煎药指令
                            BaseInfo.Insert_TisaneCmd(Convert.ToDateTime(strtime), db, tisaneid);

                            //更改煎药机的状态
                            string sql8 = "update machine set status ='忙碌' where id = '" + machineid + "'";
                            db.cmd_Execute(sql8);


                            end = 1;//正在煎=1
                            string sql7 = "update prescription set doperson ='" + per + "',curstate = '开始煎药'  where id = '" + originaltisaneid + "'";

                            if (db.cmd_Execute(sql7) == 1) //更新处方表里
                            {
                                //删除泡药表里的泡药的数据
                                //string sql8 = "delete from bubble where pid = '"+originaltisaneid+"'";
                                //db.cmd_Execute(sql8);
                            }

                        }


                    }

                }
                else
                {
                    end = 6;//泡药未完成，不能开始煎药
                }
            }
            else
            {
                end = 3;//煎药单号不存在
            }


            return end;

        }

        //煎药警告
        public string tisanewarning()
        {
            DataBaseLayer db = new DataBaseLayer();
            string sql3 = "";
            sql3 = "select ID,Pspnum,customid,delnum,(select tisanewarning from warning where hospitalid = p.Hospitalid and type=0) as tisanewarning,(select doingtime from bubble where pid = p.id) as doingtime,(SELECT bubbleperson FROM bubble WHERE pid = p.id) as bp,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
            sql3 += "diagresult,(select warningtime from bubble where pid = p.id) as warningtime,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,RemarksA,RemarksB footnote,ordertime,curstate";
            sql3 += " from prescription as p where id in (select pid from bubble where bubblestatus =1)and id not in (select pid from InvalidPrescription)";

            SqlDataReader sr3 = db.get_Reader(sql3);//泡药完成的所有信息

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
                string d1 = sr3["tisanewarning"].ToString();//煎药警告时间

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



                string sql8 = "select status from warning where hospitalid = '" + list4[i] + "'";

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
                    string strsql1 = "update bubble set warningstatus = 1 ,warningtype='煎药预警' where pid = '" + list3[i] + "'";

                    db.cmd_Execute(strsql1);

                    // if (list5[i].ToString() == "1970-1-1 0:00:00")
                    if (list5[i].ToString() == "" || Convert.ToDateTime(list5[i].ToString()).ToString("yyyy-MM-dd HH:mm:ss") == "1970-01-01 00:00:00")
                    {
                        string strsql2 = "update bubble set warningtime ='" + warningtime + "' where pid = '" + list3[i] + "'";

                        db.cmd_Execute(strsql2);
                    }

                }
                else
                {
                    string strsql2 = "update bubble set warningstatus = 0,warningtype='暂无预警',warningtime ='1970-1-1 00:00:00' where pid = '" + list3[i] + "'";

                    db.cmd_Execute(strsql2);
                }


            }
            string strS = currentTime.ToString("yyyy/MM/dd 00:00:00");

            string strS2 = currentTime.ToString("yyyy/MM/dd 23:59:59");

            string str2 = "";
            string str = "select pid from bubble where bubblestatus =1 and warningstatus =1 and pid not in (select pid from tisaneinfo) and pid in (select id from prescription as p where  p.dotime between '" + strS + "' and  '" + strS2 + "')";
            SqlDataReader sr = db.get_Reader(str);





            while (sr.Read())
            {

                str2 += sr["pid"].ToString() + ",";

            }
            return str2;
        }

        //发货预警时间

        public string deliverywarning()
        {
            DataBaseLayer db = new DataBaseLayer();
            string sql3 = "";
            sql3 = "select ID,Pspnum,customid,delnum,(select deliverwarning from warning where hospitalid = p.Hospitalid and type=0) as deliverwarning,(select doingtime from bubble where pid = p.id) as doingtime,(SELECT bubbleperson FROM bubble WHERE pid = p.id) as bp,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
            sql3 += "diagresult,(select warningtime from packing where decoctingnum=p.id) as warningtime,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,RemarksA,RemarksB footnote,ordertime,curstate";
            sql3 += " from prescription as p where id in (select decoctingnum from packing  where fpactate =1)and id not in (select pid from InvalidPrescription)";

            SqlDataReader sr3 = db.get_Reader(sql3);//包装完成的所有信息

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
                string d1 = sr3["deliverwarning"].ToString();//发货警告时间

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



                string sql8 = "select status from warning where hospitalid = '" + list4[i] + "'";

                SqlDataReader sr8 = db.get_Reader(sql8);
                string status = "";//医院预警开关状态

                if (sr8.Read())
                {
                    status = sr8["status"].ToString();

                }



                string d1 = list1[i].ToString();//发货警告时间

                DateTime d2 = Convert.ToDateTime(list2[i].ToString());//取药时间


                string strY = currentTime.ToString("yyyy-MM-dd HH:mm:ss");

                DateTime d3 = Convert.ToDateTime(strY);//当前时间



                TimeSpan d4 = d2.Subtract(d3);//取药时间- 当前时间



                //取药时间- 当前时间
                int time = Convert.ToInt32(d4.Days.ToString()) * 24 * 60 + Convert.ToInt32(d4.Hours.ToString()) * 60 + Convert.ToInt32(d4.Minutes.ToString());
                //发货警告时间
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
                    string strsql1 = "update packing set warningstatus = 1,warningtype='发货预警' where decoctingnum = '" + list3[i] + "'";

                    db.cmd_Execute(strsql1);
                    string a = list5[i].ToString();
                    //  if (list5[i].ToString() == "1970-1-1 0:00:00")
                    if (list5[i].ToString() == "" || Convert.ToDateTime(list5[i].ToString()).ToString("yyyy-MM-dd HH:mm:ss") == "1970-01-01 00:00:00")
                    {

                        string strsql2 = "update packing set warningtime ='" + warningtime + "' where decoctingnum = '" + list3[i] + "'";

                        db.cmd_Execute(strsql2);
                    }

                }
                else
                {
                    string strsql2 = "update packing set warningstatus = 0,warningtype='暂无预警',warningtime ='1970-1-1 00:00:00' where decoctingnum = '" + list3[i] + "'";

                    db.cmd_Execute(strsql2);
                }
            }

            string strS = currentTime.ToString("yyyy/MM/dd 00:00:00");

            string strS2 = currentTime.ToString("yyyy/MM/dd 23:59:59");


            string str2 = "";
            string str = "select decoctingnum from packing where fpactate =1 and warningstatus =1 and decoctingnum not in (select decoctingnum from delivery where sendstate =1) and decoctingnum in (select id from prescription as p where  p.dotime between '" + strS + "' and  '" + strS2 + "') ";
            SqlDataReader sr = db.get_Reader(str);

            while (sr.Read())
            {

                str2 += sr["decoctingnum"].ToString() + ",";

            }
            return str2;
        }

        //调剂预警时间

        public string adjustwarning()
        {
            DataBaseLayer db = new DataBaseLayer();
            string sql3 = "";
            sql3 = "select ID,Pspnum,customid,delnum,(select adjustwarning from warning where hospitalid = p.Hospitalid and type=0) as  adjustwarning,(select doingtime from bubble where pid = p.id) as doingtime,(SELECT bubbleperson FROM bubble WHERE pid = p.id) as bp,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
            sql3 += "diagresult,(select warningtime from prescriptioncheckstate where prescriptionid = p.id) as warningtime,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,RemarksA,RemarksB footnote,ordertime,curstate";
            sql3 += " from prescription as p where id in (select prescriptionid from prescriptioncheckstate  where checkstatus =1)and id not in (select pid from InvalidPrescription)";

            SqlDataReader sr3 = db.get_Reader(sql3);//审核完成的所有信息

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
                string d1 = sr3["adjustwarning"].ToString();//调剂警告时间

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
                string sql8 = "select status from warning where hospitalid = '" + list4[i] + "'";

                SqlDataReader sr8 = db.get_Reader(sql8);
                string status = "";//医院预警开关状态

                if (sr8.Read())
                {
                    status = sr8["status"].ToString();

                }
                string d1 = list1[i].ToString();//发货警告时间

                DateTime d2 = Convert.ToDateTime(list2[i].ToString());//取药时间


                string strY = currentTime.ToString("yyyy-MM-dd HH:mm:ss");

                DateTime d3 = Convert.ToDateTime(strY);//当前时间



                TimeSpan d4 = d2.Subtract(d3);//取药时间- 当前时间



                //取药时间- 当前时间
                int time = Convert.ToInt32(d4.Days.ToString()) * 24 * 60 + Convert.ToInt32(d4.Hours.ToString()) * 60 + Convert.ToInt32(d4.Minutes.ToString());
                //发货警告时间
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
                    string strsql1 = "update prescriptioncheckstate  set warningstatus = 1,warningtype='调剂预警' where prescriptionid = '" + list3[i] + "'";

                    db.cmd_Execute(strsql1);

                    if (list5[i].ToString() == "" || Convert.ToDateTime(list5[i].ToString()).ToString("yyyy-MM-dd HH:mm:ss") == "1970-01-01 00:00:00")
                    {
                        string strsql2 = "update prescriptioncheckstate  set warningtime ='" + warningtime + "' where prescriptionid = '" + list3[i] + "'";

                        db.cmd_Execute(strsql2);
                    }

                }
                else
                {
                    string strsql2 = "update  prescriptioncheckstate set warningstatus = 0,warningtype='暂无预警',warningtime='1970-1-1 0:00:00' where prescriptionid = '" + list3[i] + "'";

                    db.cmd_Execute(strsql2);
                }


            }

            string strS = currentTime.ToString("yyyy/MM/dd 00:00:00");

            string strS2 = currentTime.ToString("yyyy/MM/dd 23:59:59");




            string str2 = "";
            string str = "select prescriptionid from  prescriptioncheckstate where checkstatus =1 and warningstatus =1 and prescriptionid not in (select pid from InvalidPrescription) and prescriptionid not in (select prescriptionid from adjust)  and prescriptionid in (select id from prescription as p where  p.dotime between '" + strS + "' and  '" + strS2 + "')";
            SqlDataReader sr = db.get_Reader(str);

            while (sr.Read())
            {

                str2 += sr["prescriptionid"].ToString() + ",";

            }
            return str2;
        }


        //审核报警
        public string checkwarning()
        {
            DataBaseLayer db = new DataBaseLayer();
            string sql3 = "";
            sql3 = "select ID,Pspnum,customid,delnum,(select checkwarning from warning where hospitalid = p.Hospitalid and type=0) as  checkwarning,(select doingtime from bubble where pid = p.id) as doingtime,(SELECT bubbleperson FROM bubble WHERE pid = p.id) as bp,(select hnum from hospital as h where h.id = p.hospitalid) as hnum,(select hname from hospital as h where h.id = p.hospitalid) as hname,Hospitalid,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
            sql3 += "diagresult,(select warningtime from jfinfo where pid = p.id) as warningtime,dose,takenum,getdrugtime,getdrugnum,takemethod,decscheme,oncetime,twicetime,packagenum,dotime,doperson,dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,RemarksA,RemarksB footnote,ordertime,curstate";
            sql3 += " from prescription as p where curstate='未审核'";

            SqlDataReader sr3 = db.get_Reader(sql3);//审核完成的所有信息

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
                string d1 = sr3["checkwarning"].ToString();//审核警告时间

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



                string sql8 = "select status from warning where hospitalid = '" + list4[i] + "'";

                SqlDataReader sr8 = db.get_Reader(sql8);
                string status = "";//医院预警开关状态

                if (sr8.Read())
                {
                    status = sr8["status"].ToString();

                }



                string d1 = list1[i].ToString();//发货警告时间

                DateTime d2 = Convert.ToDateTime(list2[i].ToString());//取药时间


                string strY = currentTime.ToString("yyyy-MM-dd HH:mm:ss");

                DateTime d3 = Convert.ToDateTime(strY);//当前时间



                TimeSpan d4 = d2.Subtract(d3);//取药时间- 当前时间



                //取药时间- 当前时间
                int time = Convert.ToInt32(d4.Days.ToString()) * 24 * 60 + Convert.ToInt32(d4.Hours.ToString()) * 60 + Convert.ToInt32(d4.Minutes.ToString());
                //发货警告时间
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
                    /*  string strsql1 = "update Audit set bubblewarningstatus = 1,warningtype='泡药预警' where pId = '" + list3[i] + "'";

                    db.cmd_Execute(strsql1);
                    if (list5[i].ToString() == "1970-1-1 0:00:00")
                    {
                        string strsql2 = "update Audit set warningtime ='" + warningtime + "' where pId = '" + list3[i] + "'";

                        db.cmd_Execute(strsql2);
                    }*/



                    string strsql1 = "update jfinfo  set warningstatus = 1,warningtype='审核预警' where pid = '" + list3[i] + "'";

                    db.cmd_Execute(strsql1);


                    if (list5[i].ToString() == "" || Convert.ToDateTime(list5[i].ToString()).ToString("yyyy-MM-dd HH:mm:ss") == "1970-01-01 00:00:00")
                    {
                        string strsql2 = "update jfinfo set warningtime ='" + warningtime + "' where pId = '" + list3[i] + "'";

                        db.cmd_Execute(strsql2);
                    }


                }
                else
                {
                    string strsql2 = "update  jfinfo set warningstatus = 0,warningtype='暂无预警',warningtime='1970-1-1 00:00:00' where pid = '" + list3[i] + "'";

                    db.cmd_Execute(strsql2);
                }


            }


            string strS = currentTime.ToString("yyyy/MM/dd 00:00:00");

            string strS2 = currentTime.ToString("yyyy/MM/dd 23:59:59");




            string str2 = "";
            string str = "select pid from jfinfo where warningstatus =1 and pid not in (select prescriptionid from prescriptioncheckstate) and pid in (select id from prescription as p where  p.dotime between '" + strS + "' and  '" + strS2 + "')";
            SqlDataReader sr = db.get_Reader(str);

            while (sr.Read())
            {

                str2 += sr["pid"].ToString() + ",";

            }
            return str2;
        }


        //煎药机工作量统计
        public DataTable findtisanemachineInfo(int tisanenum, string starttime, string endtime)
        {

            DataBaseLayer db = new DataBaseLayer();
            string sql = "select  max(id) as id,(select machinename from machine where id = machineid) as hao,convert(varchar, starttime, 111) as workdate,'煎药' as workcontent,count(starttime)  as workload from tisaneinfo where 1=1";

            if (tisanenum != 0)
            {
                sql += "and machineid = '" + tisanenum + "'";

            }

            if (starttime != "0" && starttime != "")
            {
                DateTime d = Convert.ToDateTime(starttime);

                string strS = d.ToString("yyyy/MM/dd  00:00:00");

                sql += "and starttime  >= '" + strS + "'";
            }
            if (endtime != "0" && endtime != "")
            {
                DateTime d = Convert.ToDateTime(endtime);

                string strS = d.ToString("yyyy/MM/dd 23:59:59");

                sql += "and starttime  <= ' " + strS + "'";
                //                    sql += "and enddate  <= ' " + strS + "'";
            }


            sql += "GROUP BY machineid,CONVERT(varchar, starttime, 111)";



            DataTable dt = db.get_DataTable(sql);
            return dt;


        }
        //煎药机工作量图表数据

        public DataTable findtisanemachineInfo()
        {
            DataBaseLayer db = new DataBaseLayer();
            string sql = "select  max(id) as id,convert(varchar, starttime, 111) as workdate,'煎药' as workcontent,count(starttime)  as workload from tisaneinfo where 1=1";

            sql += "GROUP BY CONVERT(varchar, starttime, 111)";
            return db.get_DataTable(sql);
        }




        //员工工作量统计
        public DataTable EmployeeInfo(string employname, string employcode, string starttime, string endtime, string workcontent)
        {

            DataBaseLayer db = new DataBaseLayer();
            //string sql = "select  max(id) as id,convert(varchar, starttime, 111) as workdate,'煎药' as workcontent,count(starttime)  as workload from tisaneinfo ";

            // string sql = "select max(id) as id,'泡药' as workcontent,convert(varchar, starttime, 111) as workdate,count(starttime)  as workload from bubble  ";

            // sql += "group by convert(varchar, starttime, 111)";
            // sql += "union all  select max(id) as id,'煎药' as workcontent,convert(varchar, starttime, 111) as workdate,count(starttime)  as workload from tisaneinfo";
            //  sql += "GROUP BY CONVERT(varchar, starttime, 111)";
            string employeeid = "";
            string str2 = "select id from employee where ename ='" + employname + "'";
            SqlDataReader sr = db.get_Reader(str2);
            if (sr.Read())
            {
                employeeid = sr["id"].ToString();

            }
            string sql = "";


            //(1000000*MAX(prescriptionid)) AS id
            sql = "SELECT (1000000*MAX(prescriptionid)) AS id, '审核' AS workcontent,(select Ename from employee where id =p.employeeid) as workman,(select jobnum from employee where id = p.employeeid) as workmannum,CONVERT(varchar, partytime, 111) AS workdate, COUNT(partytime) AS workload FROM prescriptionCheckState as p where (partytime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and partyPer ='" + employname + "'";
            }
            if (employcode != "0")
            {
                // sql += "and partyPer =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and partytime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and partytime <='" + strE + "'";
            }
            if (workcontent == "2" || workcontent == "3" || workcontent == "4" || workcontent == "5" || workcontent == "6" || workcontent == "7")
            {
                sql += "and prescriptionid =-1";

            }



            sql += " GROUP BY CONVERT(varchar, partytime, 111),(employeeid)";
            sql += " UNION ALL";
            sql += " SELECT (100000*MAX(prescriptionid)) AS id,'调剂' AS workcontent,(select Ename from employee where id =a.employeeid) as workman,(select jobnum from employee where id =a.employeeid) as workmannum, CONVERT(varchar, worddate, 111) AS workdate, COUNT(worddate) AS workload FROM adjust as a where (worddate is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and swapper ='" + employname + "'";
            }

            if (employcode != "0")
            {
                // sql += "and swapper =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and worddate >='" + strS + "'";
            }

            if (endtime != "0")
            {

                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and worddate <='" + strE + "'";
            }

            if (workcontent == "1" || workcontent == "3" || workcontent == "4" || workcontent == "5" || workcontent == "6" || workcontent == "7")
            {
                sql += "and prescriptionid =-1";

            }


            sql += " GROUP BY CONVERT(varchar, worddate, 111),(employeeid)";
            sql += "UNION ALL SELECT (10000*MAX(pid)) AS id, '复核' AS workcontent,(select Ename from employee where id =a.employeeid) as workman,(select jobnum from employee where id =a.employeeid) as workmannum,CONVERT(varchar, audittime, 111) AS workdate, COUNT(audittime) AS workload FROM audit as a where (audittime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and reviewper ='" + employname + "'";
            }
            if (employcode != "0")
            {
                //sql += "and reviewper =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and audittime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and audittime <='" + strE + "'";
            }

            if (workcontent == "2" || workcontent == "1" || workcontent == "4" || workcontent == "5" || workcontent == "6" || workcontent == "7")
            {
                sql += "and pid =-1";
            }

            sql += " GROUP BY CONVERT(varchar, audittime, 111),(employeeid)";
            sql += " UNION ALL SELECT   MAX(pid) AS id, '泡药' AS workcontent,(select Ename from employee where id =b.employeeid) as workman,(select jobnum from employee where id =b.employeeid) as workmannum ,CONVERT(varchar, starttime, 111) AS workdate, COUNT(starttime) AS workload FROM bubble  as b where (starttime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and bubbleperson ='" + employname + "'";
            }
            if (employcode != "0")
            {
                //  sql += "and bubbleperson =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and starttime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and starttime <='" + strE + "'";
            }


            if (workcontent == "2" || workcontent == "3" || workcontent == "1" || workcontent == "5" || workcontent == "6" || workcontent == "7")
            {
                sql += "and pid =-1";
            }


            sql += " GROUP BY CONVERT(varchar, starttime, 111),(employeeid)";
            sql += " UNION ALL SELECT  (10*MAX(pid)) AS id, '煎药' AS workcontent,(select Ename from employee where id =t.employeeid) as workman,(select jobnum from employee where id =t.employeeid) as workmannum, CONVERT(varchar, starttime, 111) AS workdate, COUNT(starttime)  AS workload FROM  tisaneinfo as t where (starttime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and tisaneman ='" + employname + "'";
            }
            if (employcode != "0")
            {
                //sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and starttime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and starttime <='" + strE + "'";
            }


            if (workcontent == "2" || workcontent == "3" || workcontent == "4" || workcontent == "1" || workcontent == "6" || workcontent == "7")
            {
                sql += "and pid =-1";
            }

            sql += " GROUP BY CONVERT(varchar, starttime, 111),(employeeid)";


            sql += " UNION ALL SELECT  (100*MAX(DecoctingNum)) AS id, '包装' AS workcontent,(select Ename from employee where id =p.employeeid) as workman, (select jobnum from employee where id =p.employeeid) as workmannum,CONVERT(varchar, starttime, 111) AS workdate, COUNT(starttime)  AS workload FROM  Packing as p where (starttime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and pacpersonnel ='" + employname + "'";
            }
            if (employcode != "0")
            {
                // sql += "and pacpersonnel =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and starttime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and starttime <='" + strE + "'";
            }

            if (workcontent == "2" || workcontent == "3" || workcontent == "4" || workcontent == "5" || workcontent == "1" || workcontent == "7")
            {
                sql += "and DecoctingNum =-1";
            }


            sql += " GROUP BY CONVERT(varchar, starttime, 111),(employeeid)";
            sql += " UNION ALL SELECT  (1000*MAX(DecoctingNum)) AS id, '发货' AS workcontent,(select Ename from employee where id =d.employeeid) as workman, (select jobnum from employee where id =d.employeeid) as workmannum,CONVERT(varchar, sendTime, 111) AS workdate, COUNT(sendtime)  AS workload FROM  delivery as d where (sendtime is not null) and (employeeid is not null)";

            if (employname != "0")
            {
                sql += "and sendpersonnel ='" + employname + "'";
            }
            if (employcode != "0")
            {
                //  sql += "and sendpersonnel =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }

            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and sendTime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and sendTime <='" + strE + "'";
            }

            if (workcontent == "2" || workcontent == "3" || workcontent == "4" || workcontent == "5" || workcontent == "6" || workcontent == "1")
            {
                sql += "and DecoctingNum =-1";
            }
            sql += " GROUP BY CONVERT(varchar, sendtime, 111),(employeeid)";

            DataTable dt = db.get_DataTable(sql);
            return dt;
        }
        //员工工作量统计
        public DataTable EmployeeInfoCount(string employname, string employcode, string starttime, string endtime, string workcontent)
        {

            DataBaseLayer db = new DataBaseLayer();
            //string sql = "select  max(id) as id,convert(varchar, starttime, 111) as workdate,'煎药' as workcontent,count(starttime)  as workload from tisaneinfo ";

            // string sql = "select max(id) as id,'泡药' as workcontent,convert(varchar, starttime, 111) as workdate,count(starttime)  as workload from bubble  ";

            // sql += "group by convert(varchar, starttime, 111)";
            // sql += "union all  select max(id) as id,'煎药' as workcontent,convert(varchar, starttime, 111) as workdate,count(starttime)  as workload from tisaneinfo";
            //  sql += "GROUP BY CONVERT(varchar, starttime, 111)";
            string employeeid = "";
            string str2 = "select id from employee where ename ='" + employname + "'";
            SqlDataReader sr = db.get_Reader(str2);
            if (sr.Read())
            {
                employeeid = sr["id"].ToString();

            }
            string sql = "";


            //(1000000*MAX(prescriptionid)) AS id
            sql = "SELECT '审核' AS workcontent,CONVERT(varchar, partytime, 111) AS data, COUNT(partytime) AS count FROM prescriptionCheckState as p where (partytime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and partyPer ='" + employname + "'";
            }
            if (employcode != "0")
            {
                // sql += "and partyPer =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and partytime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and partytime <='" + strE + "'";
            }
            if (workcontent == "2" || workcontent == "3" || workcontent == "4" || workcontent == "5" || workcontent == "6" || workcontent == "7")
            {
                sql += "and prescriptionid =-1";

            }



            sql += " GROUP BY CONVERT(varchar, partytime, 111)";
            sql += " UNION ALL";
            sql += " SELECT '调剂' AS workcontent, CONVERT(varchar, worddate, 111) AS data, COUNT(worddate) AS count FROM adjust as a where (worddate is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and swapper ='" + employname + "'";
            }

            if (employcode != "0")
            {
                // sql += "and swapper =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and worddate >='" + strS + "'";
            }

            if (endtime != "0")
            {

                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and worddate <='" + strE + "'";
            }

            if (workcontent == "1" || workcontent == "3" || workcontent == "4" || workcontent == "5" || workcontent == "6" || workcontent == "7")
            {
                sql += "and prescriptionid =-1";

            }


            sql += " GROUP BY CONVERT(varchar, worddate, 111)";
            sql += " UNION ALL SELECT '复核' AS workcontent,CONVERT(varchar, audittime, 111) AS data, COUNT(audittime) AS count FROM audit as a where (audittime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and reviewper ='" + employname + "'";
            }
            if (employcode != "0")
            {
                //sql += "and reviewper =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and audittime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and audittime <='" + strE + "'";
            }

            if (workcontent == "2" || workcontent == "1" || workcontent == "4" || workcontent == "5" || workcontent == "6" || workcontent == "7")
            {
                sql += "and pid =-1";
            }

            sql += " GROUP BY CONVERT(varchar, audittime, 111)";
            sql += " UNION ALL SELECT   '泡药' AS workcontent,CONVERT(varchar, starttime, 111) AS data, COUNT(starttime) AS count FROM bubble  as b where (starttime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and bubbleperson ='" + employname + "'";
            }
            if (employcode != "0")
            {
                //  sql += "and bubbleperson =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and starttime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and starttime <='" + strE + "'";
            }


            if (workcontent == "2" || workcontent == "3" || workcontent == "1" || workcontent == "5" || workcontent == "6" || workcontent == "7")
            {
                sql += "and pid =-1";
            }


            sql += " GROUP BY CONVERT(varchar, starttime, 111)";
            sql += " UNION ALL SELECT '煎药' AS workcontent, CONVERT(varchar, starttime, 111) AS data, COUNT(starttime)  AS count FROM  tisaneinfo as t where (starttime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and tisaneman ='" + employname + "'";
            }
            if (employcode != "0")
            {
                //sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and starttime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and starttime <='" + strE + "'";
            }


            if (workcontent == "2" || workcontent == "3" || workcontent == "4" || workcontent == "1" || workcontent == "6" || workcontent == "7")
            {
                sql += "and pid =-1";
            }

            sql += " GROUP BY CONVERT(varchar, starttime, 111)";


            sql += " UNION ALL SELECT '包装' AS workcontent,CONVERT(varchar, starttime, 111) AS data, COUNT(starttime)  AS count FROM  Packing as p where (starttime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and pacpersonnel ='" + employname + "'";
            }
            if (employcode != "0")
            {
                // sql += "and pacpersonnel =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and starttime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and starttime <='" + strE + "'";
            }

            if (workcontent == "2" || workcontent == "3" || workcontent == "4" || workcontent == "5" || workcontent == "1" || workcontent == "7")
            {
                sql += "and DecoctingNum =-1";
            }


            sql += " GROUP BY CONVERT(varchar, starttime, 111)";
            sql += " UNION ALL SELECT  '发货' AS workcontent,CONVERT(varchar, sendTime, 111) AS data, COUNT(sendtime)  AS count FROM  delivery as d where (sendtime is not null) and (employeeid is not null)";

            if (employname != "0")
            {
                sql += "and sendpersonnel ='" + employname + "'";
            }
            if (employcode != "0")
            {
                //  sql += "and sendpersonnel =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }

            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and sendTime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and sendTime <='" + strE + "'";
            }

            if (workcontent == "2" || workcontent == "3" || workcontent == "4" || workcontent == "5" || workcontent == "6" || workcontent == "1")
            {
                sql += "and DecoctingNum =-1";
            }
            sql += " GROUP BY CONVERT(varchar, sendtime, 111)";
            sql += " ORDER BY data";

            DataTable dt = db.get_DataTable(sql);
            return dt;
        }
        public DataTable EmployeeInfoCountAll(string employname, string employcode, string starttime, string endtime, string workcontent)
        {

            DataBaseLayer db = new DataBaseLayer();
            //string sql = "select  max(id) as id,convert(varchar, starttime, 111) as workdate,'煎药' as workcontent,count(starttime)  as workload from tisaneinfo ";

            // string sql = "select max(id) as id,'泡药' as workcontent,convert(varchar, starttime, 111) as workdate,count(starttime)  as workload from bubble  ";

            // sql += "group by convert(varchar, starttime, 111)";
            // sql += "union all  select max(id) as id,'煎药' as workcontent,convert(varchar, starttime, 111) as workdate,count(starttime)  as workload from tisaneinfo";
            //  sql += "GROUP BY CONVERT(varchar, starttime, 111)";
            string employeeid = "";
            string str2 = "select id from employee where ename ='" + employname + "'";
            SqlDataReader sr = db.get_Reader(str2);
            if (sr.Read())
            {
                employeeid = sr["id"].ToString();

            }
            string sql = "";


            //(1000000*MAX(prescriptionid)) AS id
            sql = "SELECT CONVERT(varchar, partytime, 111) AS data, COUNT(partytime) AS count FROM prescriptionCheckState as p where (partytime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and partyPer ='" + employname + "'";
            }
            if (employcode != "0")
            {
                // sql += "and partyPer =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and partytime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and partytime <='" + strE + "'";
            }
            if (workcontent == "2" || workcontent == "3" || workcontent == "4" || workcontent == "5" || workcontent == "6" || workcontent == "7")
            {
                sql += "and prescriptionid =-1";

            }



            sql += " GROUP BY CONVERT(varchar, partytime, 111)";
            sql += " UNION ALL";
            sql += " SELECT  CONVERT(varchar, worddate, 111) AS data, COUNT(worddate) AS count FROM adjust as a where (worddate is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and swapper ='" + employname + "'";
            }

            if (employcode != "0")
            {
                // sql += "and swapper =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and worddate >='" + strS + "'";
            }

            if (endtime != "0")
            {

                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and worddate <='" + strE + "'";
            }

            if (workcontent == "1" || workcontent == "3" || workcontent == "4" || workcontent == "5" || workcontent == "6" || workcontent == "7")
            {
                sql += "and prescriptionid =-1";

            }


            sql += " GROUP BY CONVERT(varchar, worddate, 111)";
            sql += " UNION ALL SELECT CONVERT(varchar, audittime, 111) AS data, COUNT(audittime) AS count FROM audit as a where (audittime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and reviewper ='" + employname + "'";
            }
            if (employcode != "0")
            {
                //sql += "and reviewper =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and audittime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and audittime <='" + strE + "'";
            }

            if (workcontent == "2" || workcontent == "1" || workcontent == "4" || workcontent == "5" || workcontent == "6" || workcontent == "7")
            {
                sql += "and pid =-1";
            }

            sql += " GROUP BY CONVERT(varchar, audittime, 111)";
            sql += " UNION ALL SELECT   CONVERT(varchar, starttime, 111) AS data, COUNT(starttime) AS count FROM bubble  as b where (starttime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and bubbleperson ='" + employname + "'";
            }
            if (employcode != "0")
            {
                //  sql += "and bubbleperson =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and starttime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and starttime <='" + strE + "'";
            }


            if (workcontent == "2" || workcontent == "3" || workcontent == "1" || workcontent == "5" || workcontent == "6" || workcontent == "7")
            {
                sql += "and pid =-1";
            }


            sql += " GROUP BY CONVERT(varchar, starttime, 111)";
            sql += " UNION ALL SELECT  CONVERT(varchar, starttime, 111) AS data, COUNT(starttime)  AS count FROM  tisaneinfo as t where (starttime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and tisaneman ='" + employname + "'";
            }
            if (employcode != "0")
            {
                //sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and starttime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and starttime <='" + strE + "'";
            }


            if (workcontent == "2" || workcontent == "3" || workcontent == "4" || workcontent == "1" || workcontent == "6" || workcontent == "7")
            {
                sql += "and pid =-1";
            }

            sql += " GROUP BY CONVERT(varchar, starttime, 111)";


            sql += " UNION ALL SELECT CONVERT(varchar, starttime, 111) AS data, COUNT(starttime)  AS count FROM  Packing as p where (starttime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and pacpersonnel ='" + employname + "'";
            }
            if (employcode != "0")
            {
                // sql += "and pacpersonnel =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and starttime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and starttime <='" + strE + "'";
            }

            if (workcontent == "2" || workcontent == "3" || workcontent == "4" || workcontent == "5" || workcontent == "1" || workcontent == "7")
            {
                sql += "and DecoctingNum =-1";
            }


            sql += " GROUP BY CONVERT(varchar, starttime, 111)";
            sql += " UNION ALL SELECT  CONVERT(varchar, sendTime, 111) AS data, COUNT(sendtime)  AS count FROM  delivery as d where (sendtime is not null) and (employeeid is not null)";

            if (employname != "0")
            {
                sql += "and sendpersonnel ='" + employname + "'";
            }
            if (employcode != "0")
            {
                //  sql += "and sendpersonnel =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }

            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and sendTime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and sendTime <='" + strE + "'";
            }

            if (workcontent == "2" || workcontent == "3" || workcontent == "4" || workcontent == "5" || workcontent == "6" || workcontent == "1")
            {
                sql += "and DecoctingNum =-1";
            }
            sql += " GROUP BY CONVERT(varchar, sendtime, 111)";


            sql = "SELECT   data, SUM(count) AS count FROM (" + sql + ") AS derivedtbl_1 GROUP BY data ORDER BY data";


            DataTable dt = db.get_DataTable(sql);
            return dt;
        }
        //员工工作量统计
        public DataTable EmployeeInfoSingleCount(string employname, string employcode, string starttime, string endtime, string workcontent)
        {

            DataBaseLayer db = new DataBaseLayer();
            //string sql = "select  max(id) as id,convert(varchar, starttime, 111) as workdate,'煎药' as workcontent,count(starttime)  as workload from tisaneinfo ";

            // string sql = "select max(id) as id,'泡药' as workcontent,convert(varchar, starttime, 111) as workdate,count(starttime)  as workload from bubble  ";

            // sql += "group by convert(varchar, starttime, 111)";
            // sql += "union all  select max(id) as id,'煎药' as workcontent,convert(varchar, starttime, 111) as workdate,count(starttime)  as workload from tisaneinfo";
            //  sql += "GROUP BY CONVERT(varchar, starttime, 111)";
            string employeeid = "";
            string str2 = "select id from employee where ename ='" + employname + "'";
            SqlDataReader sr = db.get_Reader(str2);
            if (sr.Read())
            {
                employeeid = sr["id"].ToString();

            }
            string sql = "";


            //(1000000*MAX(prescriptionid)) AS id
            sql = "SELECT '审核' AS workcontent, (SELECT EName FROM Employee WHERE (ID = p.employeeid)) AS data, COUNT(employeeid) AS count FROM prescriptionCheckState as p where (partytime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and partyPer ='" + employname + "'";
            }
            if (employcode != "0")
            {
                // sql += "and partyPer =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and partytime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and partytime <='" + strE + "'";
            }
            if (workcontent == "2" || workcontent == "3" || workcontent == "4" || workcontent == "5" || workcontent == "6" || workcontent == "7")
            {
                sql += "and prescriptionid =-1";

            }



            sql += " GROUP BY employeeid ";
            sql += " UNION ALL";
            sql += " SELECT '调剂' AS workcontent, (SELECT EName FROM Employee AS Employee_6 WHERE (ID = a.employeeId)) AS data, COUNT(employeeId) AS count FROM adjust as a where (worddate is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and swapper ='" + employname + "'";
            }

            if (employcode != "0")
            {
                // sql += "and swapper =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and worddate >='" + strS + "'";
            }

            if (endtime != "0")
            {

                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and worddate <='" + strE + "'";
            }

            if (workcontent == "1" || workcontent == "3" || workcontent == "4" || workcontent == "5" || workcontent == "6" || workcontent == "7")
            {
                sql += "and prescriptionid =-1";

            }


            sql += " GROUP BY employeeId ";
            sql += " UNION ALL SELECT '复核' AS workcontent,(SELECT EName FROM Employee AS Employee_5 WHERE (ID = a.employeeId)) AS data, COUNT(employeeId) AS count FROM audit as a where (audittime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and reviewper ='" + employname + "'";
            }
            if (employcode != "0")
            {
                //sql += "and reviewper =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and audittime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and audittime <='" + strE + "'";
            }

            if (workcontent == "2" || workcontent == "1" || workcontent == "4" || workcontent == "5" || workcontent == "6" || workcontent == "7")
            {
                sql += "and pid =-1";
            }

            sql += " GROUP BY employeeId ";
            sql += " UNION ALL SELECT '泡药' AS workcontent,(SELECT EName FROM Employee AS Employee_4 WHERE (ID = b.employeeId)) AS data, COUNT(employeeId) AS count FROM bubble  as b where (starttime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and bubbleperson ='" + employname + "'";
            }
            if (employcode != "0")
            {
                //  sql += "and bubbleperson =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and starttime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and starttime <='" + strE + "'";
            }


            if (workcontent == "2" || workcontent == "3" || workcontent == "1" || workcontent == "5" || workcontent == "6" || workcontent == "7")
            {
                sql += "and pid =-1";
            }


            sql += " GROUP BY employeeId ";
            sql += " UNION ALL SELECT '煎药' AS workcontent, (SELECT EName FROM Employee AS Employee_3 WHERE (ID = t.employeeId)) AS data, COUNT(employeeId)  AS count FROM  tisaneinfo as t where (starttime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and tisaneman ='" + employname + "'";
            }
            if (employcode != "0")
            {
                //sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and starttime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and starttime <='" + strE + "'";
            }


            if (workcontent == "2" || workcontent == "3" || workcontent == "4" || workcontent == "1" || workcontent == "6" || workcontent == "7")
            {
                sql += "and pid =-1";
            }

            sql += " GROUP BY employeeId ";


            sql += " UNION ALL SELECT '包装' AS workcontent,(SELECT EName FROM Employee AS Employee_2 WHERE (ID = p.employeeId)) AS data, COUNT(employeeId)  AS count FROM  Packing as p where (starttime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and pacpersonnel ='" + employname + "'";
            }
            if (employcode != "0")
            {
                // sql += "and pacpersonnel =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and starttime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and starttime <='" + strE + "'";
            }

            if (workcontent == "2" || workcontent == "3" || workcontent == "4" || workcontent == "5" || workcontent == "1" || workcontent == "7")
            {
                sql += "and DecoctingNum =-1";
            }


            sql += " GROUP BY employeeId ";
            sql += " UNION ALL SELECT  '发货' AS workcontent, (SELECT EName FROM Employee AS Employee_1 WHERE (ID = d.employeeId)) AS data, COUNT(employeeId)  AS count FROM  delivery as d where (sendtime is not null) and (employeeid is not null)";

            if (employname != "0")
            {
                sql += "and sendpersonnel ='" + employname + "'";
            }
            if (employcode != "0")
            {
                //  sql += "and sendpersonnel =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }

            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and sendTime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and sendTime <='" + strE + "'";
            }

            if (workcontent == "2" || workcontent == "3" || workcontent == "4" || workcontent == "5" || workcontent == "6" || workcontent == "1")
            {
                sql += "and DecoctingNum =-1";
            }
            sql += " GROUP BY employeeId ";


            DataTable dt = db.get_DataTable(sql);
            return dt;
        }

        //员工工作量统计
        public DataTable EmployeeAllCount(string employname, string employcode, string starttime, string endtime, string workcontent)
        {

            DataBaseLayer db = new DataBaseLayer();
            //string sql = "select  max(id) as id,convert(varchar, starttime, 111) as workdate,'煎药' as workcontent,count(starttime)  as workload from tisaneinfo ";

            // string sql = "select max(id) as id,'泡药' as workcontent,convert(varchar, starttime, 111) as workdate,count(starttime)  as workload from bubble  ";

            // sql += "group by convert(varchar, starttime, 111)";
            // sql += "union all  select max(id) as id,'煎药' as workcontent,convert(varchar, starttime, 111) as workdate,count(starttime)  as workload from tisaneinfo";
            //  sql += "GROUP BY CONVERT(varchar, starttime, 111)";
            string employeeid = "";
            string str2 = "select id from employee where ename ='" + employname + "'";
            SqlDataReader sr = db.get_Reader(str2);
            if (sr.Read())
            {
                employeeid = sr["id"].ToString();

            }
            string sql = "";


            //(1000000*MAX(prescriptionid)) AS id
            sql = "SELECT (SELECT EName FROM Employee WHERE (ID = p.employeeid)) AS data,p.employeeid as employeeId, COUNT(employeeid) AS count FROM prescriptionCheckState as p where (partytime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and partyPer ='" + employname + "'";
            }
            if (employcode != "0")
            {
                // sql += "and partyPer =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and partytime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and partytime <='" + strE + "'";
            }
            if (workcontent == "2" || workcontent == "3" || workcontent == "4" || workcontent == "5" || workcontent == "6" || workcontent == "7")
            {
                sql += "and prescriptionid =-1";

            }



            sql += " GROUP BY employeeid ";
            sql += " UNION ALL";
            sql += " SELECT (SELECT EName FROM Employee AS Employee_6 WHERE (ID = a.employeeId)) AS data,a.employeeId as employeeId, COUNT(employeeId) AS count FROM adjust as a where (worddate is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and swapper ='" + employname + "'";
            }

            if (employcode != "0")
            {
                // sql += "and swapper =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and worddate >='" + strS + "'";
            }

            if (endtime != "0")
            {

                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and worddate <='" + strE + "'";
            }

            if (workcontent == "1" || workcontent == "3" || workcontent == "4" || workcontent == "5" || workcontent == "6" || workcontent == "7")
            {
                sql += "and prescriptionid =-1";

            }


            sql += " GROUP BY employeeId ";
            sql += " UNION ALL SELECT (SELECT EName FROM Employee AS Employee_5 WHERE (ID = a.employeeId)) AS data,a.employeeId as employeeId, COUNT(employeeId) AS count FROM audit as a where (audittime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and reviewper ='" + employname + "'";
            }
            if (employcode != "0")
            {
                //sql += "and reviewper =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and audittime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and audittime <='" + strE + "'";
            }

            if (workcontent == "2" || workcontent == "1" || workcontent == "4" || workcontent == "5" || workcontent == "6" || workcontent == "7")
            {
                sql += "and pid =-1";
            }

            sql += " GROUP BY employeeId ";
            sql += " UNION ALL SELECT (SELECT EName FROM Employee AS Employee_4 WHERE (ID = b.employeeId)) AS data,b.employeeId as employeeId, COUNT(employeeId) AS count FROM bubble  as b where (starttime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and bubbleperson ='" + employname + "'";
            }
            if (employcode != "0")
            {
                //  sql += "and bubbleperson =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and starttime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and starttime <='" + strE + "'";
            }


            if (workcontent == "2" || workcontent == "3" || workcontent == "1" || workcontent == "5" || workcontent == "6" || workcontent == "7")
            {
                sql += "and pid =-1";
            }


            sql += " GROUP BY employeeId ";
            sql += " UNION ALL SELECT (SELECT EName FROM Employee AS Employee_3 WHERE (ID = t.employeeId)) AS data,t.employeeId as employeeId, COUNT(employeeId)  AS count FROM  tisaneinfo as t where (starttime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and tisaneman ='" + employname + "'";
            }
            if (employcode != "0")
            {
                //sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and starttime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and starttime <='" + strE + "'";
            }


            if (workcontent == "2" || workcontent == "3" || workcontent == "4" || workcontent == "1" || workcontent == "6" || workcontent == "7")
            {
                sql += "and pid =-1";
            }

            sql += " GROUP BY employeeId ";


            sql += " UNION ALL SELECT (SELECT EName FROM Employee AS Employee_2 WHERE (ID = p.employeeId)) AS data,p.employeeId as employeeId, COUNT(employeeId)  AS count FROM  Packing as p where (starttime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and pacpersonnel ='" + employname + "'";
            }
            if (employcode != "0")
            {
                // sql += "and pacpersonnel =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and starttime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and starttime <='" + strE + "'";
            }

            if (workcontent == "2" || workcontent == "3" || workcontent == "4" || workcontent == "5" || workcontent == "1" || workcontent == "7")
            {
                sql += "and DecoctingNum =-1";
            }


            sql += " GROUP BY employeeId ";
            sql += " UNION ALL SELECT  (SELECT EName FROM Employee AS Employee_1 WHERE (ID = d.employeeId)) AS data,d.employeeId as employeeId, COUNT(employeeId)  AS count FROM  delivery as d where (sendtime is not null) and (employeeid is not null)";

            if (employname != "0")
            {
                sql += "and sendpersonnel ='" + employname + "'";
            }
            if (employcode != "0")
            {
                //  sql += "and sendpersonnel =(select ename from employee where jobnum ='" + employcode + "')";
                sql += "and employeeid =(select id from employee where jobnum ='" + employcode + "')";
            }

            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and sendTime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and sendTime <='" + strE + "'";
            }

            if (workcontent == "2" || workcontent == "3" || workcontent == "4" || workcontent == "5" || workcontent == "6" || workcontent == "1")
            {
                sql += "and DecoctingNum =-1";
            }
            sql += " GROUP BY employeeId ";
            sql = "SELECT   data, SUM(count) AS count FROM (" + sql + ") AS derivedtbl_1 GROUP BY data,employeeId ";



            DataTable dt = db.get_DataTable(sql);
            return dt;
        }
        //导出员工工作量统计
        public DataTable EmployeeInfoout(string employname, string employcode, string starttime, string endtime)
        {

            DataBaseLayer db = new DataBaseLayer();
            //string sql = "select  max(id) as id,convert(varchar, starttime, 111) as workdate,'煎药' as workcontent,count(starttime)  as workload from tisaneinfo ";

            // string sql = "select max(id) as id,'泡药' as workcontent,convert(varchar, starttime, 111) as workdate,count(starttime)  as workload from bubble  ";

            // sql += "group by convert(varchar, starttime, 111)";
            // sql += "union all  select max(id) as id,'煎药' as workcontent,convert(varchar, starttime, 111) as workdate,count(starttime)  as workload from tisaneinfo";
            //  sql += "GROUP BY CONVERT(varchar, starttime, 111)";
            string employeeid = "";
            string str2 = "select id from employee where ename ='" + employname + "'";
            SqlDataReader sr = db.get_Reader(str2);
            if (sr.Read())
            {
                employeeid = sr["id"].ToString();

            }
            string sql = "";


            //(1000000*MAX(prescriptionid)) AS id
            sql = "SELECT  '审核' AS workcontent, CONVERT(varchar, partytime, 111) AS workdate, COUNT(partytime) AS workload FROM prescriptionCheckState where (partytime is not null) and (employeeid is not null)";
            if (employname != "0")
            {
                sql += "and partyPer ='" + employname + "'";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and partytime >='" + strS + "'";
            }
            if (endtime != "0")
            {

                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and partytime <='" + strE + "'";
            }

            sql += "GROUP BY CONVERT(varchar, partytime, 111)";


            sql += "UNION ALL SELECT  '调剂' AS workcontent, CONVERT(varchar, worddate, 111) AS workdate, COUNT(worddate) AS workload FROM adjust where (worddate is not null)";
            if (employname != "0")
            {
                sql += "and swapper ='" + employname + "'";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and worddate >='" + strS + "'";
            }
            if (endtime != "0")
            {

                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and worddate <='" + strE + "'";
            }

            sql += "GROUP BY CONVERT(varchar, worddate, 111)";
            sql += "UNION ALL SELECT  '复核' AS workcontent, CONVERT(varchar, audittime, 111) AS workdate, COUNT(audittime) AS workload FROM audit where (audittime is not null)";
            if (employname != "0")
            {
                sql += "and reviewper ='" + employname + "'";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and audittime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and audittime <='" + strE + "'";
            }

            sql += "GROUP BY CONVERT(varchar, audittime, 111)";
            sql += "UNION ALL SELECT '泡药' AS workcontent, CONVERT(varchar, starttime, 111) AS workdate, COUNT(starttime) AS workload FROM bubble where (starttime is not null)";
            if (employname != "0")
            {
                sql += "and bubbleperson ='" + employname + "'";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and starttime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and starttime <='" + strE + "'";
            }

            sql += "GROUP BY CONVERT(varchar, starttime, 111)";
            sql += "UNION ALL SELECT   '煎药' AS workcontent, CONVERT(varchar, starttime, 111) AS workdate, COUNT(starttime)  AS workload FROM  tisaneinfo where (starttime is not null)";
            if (employname != "0")
            {
                sql += "and tisaneman ='" + employname + "'";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and starttime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and starttime <='" + strE + "'";
            }

            sql += "GROUP BY CONVERT(varchar, starttime, 111)";


            sql += "UNION ALL SELECT '包装' AS workcontent, CONVERT(varchar, starttime, 111) AS workdate, COUNT(starttime)  AS workload FROM  Packing where (starttime is not null)";
            if (employname != "0")
            {
                sql += "and pacpersonnel ='" + employname + "'";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and starttime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and starttime <='" + strE + "'";
            }


            sql += "GROUP BY CONVERT(varchar, starttime, 111)";
            sql += "UNION ALL SELECT  '发货' AS workcontent, CONVERT(varchar, sendTime, 111) AS workdate, COUNT(sendtime)  AS workload FROM  delivery where (sendtime is not null)";

            if (employname != "0")
            {
                sql += "and sendpersonnel ='" + employname + "'";
            }
            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);
                string strS = d.ToString("yyyy/MM/dd  00:00:00");
                sql += "and sendTime >='" + strS + "'";
            }
            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);
                string strE = d.ToString("yyyy/MM/dd  23:59:59");
                sql += "and sendTime <='" + strE + "'";
            }






            sql += "GROUP BY CONVERT(varchar, sendtime, 111)";





            DataTable dt = db.get_DataTable(sql);
            return dt;


        }


        //员工工作量统计表格数据
        public DataTable EmployeeInfo()
        {
            DataBaseLayer db = new DataBaseLayer();
            string sql = "select  max(id) as id,convert(varchar, starttime, 111) as workdate,count(starttime)  as workload from tisaneinfo where 1=1";
            sql += "GROUP BY CONVERT(varchar, starttime, 111)";
            return db.get_DataTable(sql);

        }

        public SqlDataReader findpackmachine()
        {
            string sql = "select * from machine where mark = 1";
            DataBaseLayer db = new DataBaseLayer();
            return db.get_Reader(sql);
        }


        //包装机工作量统计
        public DataTable findpackmachineInfo(int packnum, string starttime, string endtime)
        {

            DataBaseLayer db = new DataBaseLayer();
            string sql = "SELECT   MAX(id) AS id, CONVERT(varchar, endDate, 111) AS workdate,(select machinename from machine where unitnum =t.unitnum and mark=1) as bao, '包装' AS workcontent, COUNT(endDate) AS workload FROM tisaneunit  as t WHERE   (packstatus = 1) AND (endDate IS NOT NULL)";

            if (packnum != 0)
            {
                //sql += "and machineid in (select id from machine where roomnum=(select roomnum from machine where id ='" + packnum + "') and unitnum=(select unitnum from machine where id ='" + packnum + "'))";
                sql += "and unitnum=(select unitnum from machine where id ='" + packnum + "')";
            }

            if (starttime != "0")
            {
                DateTime d = Convert.ToDateTime(starttime);

                string strS = d.ToString("yyyy/MM/dd  00:00:00");

                sql += "and endDate  >= '" + strS + "'";
            }

            if (endtime != "0")
            {
                DateTime d = Convert.ToDateTime(endtime);

                string strS = d.ToString("yyyy/MM/dd 23:59:59");

                sql += "and endDate  <= ' " + strS + "'";
            }


            sql += "GROUP BY CONVERT(varchar, endDate, 111),unitnum";



            DataTable dt = db.get_DataTable(sql);
            return dt;


        }


        //包装机图表统计

        public DataTable packmachineInfo()
        {
            DataBaseLayer db = new DataBaseLayer();
            string sql = "select  max(id) as id,convert(varchar, endDate, 111) as workdate,'包装' as workcontent,count(endDate) as workload from tisaneunit where (packstatus =1) and (enddate is not null)";
            sql += "GROUP BY CONVERT(varchar, endDate, 111)";
            return db.get_DataTable(sql);

        }

        //综合图表数据

        public DataTable gettemperture(string pid)
        {
            DataBaseLayer db = new DataBaseLayer();
            string sql = "select macaddress from machine where id = (select machineid from tisaneunit where pid ='" + pid + "')";
            SqlDataReader sr = db.get_Reader(sql);
            string mac = "";
            string sql2 = "";
            if (sr.Read())
            {
                mac = sr["macaddress"].ToString();

                string sql3 = "select starttime ,enddate from tisaneinfo where pid ='" + pid + "'";

                SqlDataReader sr3 = db.get_Reader(sql3);
                string stime = "";
                string etime = "";
                if (sr3.Read())
                {
                    stime = sr3["starttime"].ToString();
                    etime = sr3["enddate"].ToString();
                }
                sql2 = "select temperature,time from temperturetable where bmip ='" + mac + "'   and time between '" + stime + "' and '" + etime + "'";
            }




            return db.get_DataTable(sql2);

        }
    }
}
