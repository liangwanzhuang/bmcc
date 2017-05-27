using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Data.SqlClient;
using System.Web.Services;
using System.Data;
using System.IO;
using System.Configuration;
using System.Data.OleDb;
using System.Web.Security;

using SQLDAL;

public partial class view_recipe_excelimport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        HospitalModel hm = new HospitalModel();
        SqlDataReader sdr = hm.findHospitalAll();
        int hid = 0;
        if (sdr != null)
        {
            while (sdr.Read())
            {
                if (hid == 0)
                {
                    hid = Convert.ToInt32(sdr["ID"].ToString());
                }
                this.hospitalname.Items.Add(new ListItem(sdr["Hname"].ToString(), sdr["ID"].ToString()));

            }
        }


        DataTable dt = hm.findNumById(Convert.ToInt16(hospitalname.Value));

      

        EntrustNumberModel enm = new EntrustNumberModel();
        del.Value = enm.getEntrustNumber(hid) + "";

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int zage=0;
        int zsex=0;
        int zdose = 0;
        int ztakenum = 0;
        int zpackagenum = 0;
        int zoncetime = 0;
        int ztwicetime = 0;
        int zsoakwater = 0;
        int zsoaktime = 0;
        int zlabelnum = 0;
        int zgetdrugnum = 0;




        if (FileUpload1.HasFile == false)//HasFile用来检查FileUpload是否有指定文件  
        {
            Response.Write("<script>alert('请您选择Excel文件');location='RecipeGet.aspx'</script> ");


            return;//当无文件时,返回  
        }
        string IsXls = System.IO.Path.GetExtension(FileUpload1.FileName).ToString().ToLower();//System.IO.Path.GetExtension获得文件的扩展名  
        if (IsXls != ".xls")
        {
            Response.Write("<script>alert('只可以选择Excel文件');location='RecipeGet.aspx'</script>");
            return;//当选择的不是Excel文件时,返回  
        }   
       // string strConn = "Data Source=118.244.237.123;Initial Catalog=rinfo;user id=sa;password=dalianvideo;MultipleActiveResultSets=true";
        string strConn = ConfigurationManager.ConnectionStrings["SKConnection"].ConnectionString;

        SqlConnection cn = new SqlConnection(strConn);
        cn.Open();
        string filename = DateTime.Now.ToString("yyyymmddhhMMss") + FileUpload1.FileName;              //获取Execle文件名  DateTime日期函数  
        //  string savePath = Server.MapPath(("~\\upfiles\\") + filename);//Server.MapPath 获得虚拟服务器相对路径
        string savePath = Server.MapPath("~\\upfiles\\");


        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }
        string savePath2 = savePath + filename;
        FileUpload1.SaveAs(savePath2);                        //SaveAs 将上传的文件内容保存在服务器上  
        DataSet ds = ExecleDs(savePath2, filename);           //调用自定义方法  
        DataRow[] dr = ds.Tables[0].Select();            //定义一个DataRow数组  
        int rowsnum = ds.Tables[0].Rows.Count;
        int columns = ds.Tables[0].Columns.Count;

        if (columns != 37)
        {
            Response.Write("<script>alert('Excel表导入格式不对,请选择正确的模板!');location='RecipeGet.aspx'</script>");
        }else{
        if (rowsnum == 0)
        {
            Response.Write("<script>alert('Excel表为空表,无数据!');location='RecipeGet.aspx'</script>");   //当Excel表为空时,对用户进行提示  
        }
        else
        {
            for (int i = 0; i < dr.Length; i++)
            {
                // string id = dr[i]["编号"].ToString();//编号 列名 以下类似  
                // string hospitalid = dr[i]["医院ID"].ToString();
                // string pspnum = dr[i]["处方号"].ToString();//密码 excel列名【名称不能变,否则就会出错】  
                string doperson = "";//操作人员

                if (Session["userNamebar"] != null)
                {
                    string usernamechange = "";
                    string usernamebar = Session["userNamebar"].ToString();
                    EmployeeModel em = new EmployeeModel();
                    SqlDataReader sdr3 = em.findusernamebyjobnum(usernamebar);
                    if (sdr3.Read())
                    {
                        usernamechange = sdr3["EName"].ToString();
                    }
                    doperson = usernamechange;
                }
                else
                {
                    Response.Write("<script>alert('用户名已失效');window.parent.loginview();</script>");
                    return;
                }


             
                string strdotime = DateTime.Now.ToString();//操作时间

                RecipeInfo rinfo = new RecipeInfo();

                string seq = dr[i]["序号"].ToString();

                if (dr[i]["性别"].ToString() == "女")
                {
                    zsex = 2;
                }
                else
                {
                    zsex = 1;
                }

                //  rinfo.strDelnum = dr[i]["委托单号"].ToString();
                //  rinfo.nHospitalID = Convert.ToInt16(dr[i]["医院编号"].ToString());
                // rinfo.strHospitalNum = dr[i]["医院编号"].ToString();
                rinfo.strPspnum = dr[i]["处方号"].ToString();
                rinfo.strName = dr[i]["姓名"].ToString();
                // rinfo.nSex = Convert.ToInt16(dr[i]["性别"].ToString());
                rinfo.nAge = dr[i]["年龄"].ToString();//
                if (rinfo.nAge == "")
                {
                }
                else
                {
                    zage = Convert.ToInt16(rinfo.nAge);
                }
                rinfo.strPhone = dr[i]["电话"].ToString();

                rinfo.strAddress = dr[i]["地址"].ToString();
                rinfo.strDepartment = dr[i]["科室"].ToString();
                rinfo.strInpatientAreaNum = dr[i]["病区号"].ToString();
                rinfo.strWard = dr[i]["病房号"].ToString();
                rinfo.strSickBed = dr[i]["病床号"].ToString();
                rinfo.strDiagResult = dr[i]["诊断结果"].ToString();
                rinfo.strDose = dr[i]["贴数"].ToString();//贴数只能输入整数；；；；

                if (rinfo.strDose == "")
                {
                    Response.Write("<script>alert('序号为"+seq+"的行的数据有错，贴数不能为空!');location='RecipeGet.aspx'</script>");   //当Excel表为空时,对用户进行提示 
                    return;
                }
                else
                {
                    zdose = Convert.ToInt16(rinfo.strDose);
                }


                rinfo.nNum = dr[i]["次数"].ToString();//贴数只能输入整数；；；；
                if (rinfo.nNum == "")
                {
                    Response.Write("<script>alert('序号为" + seq + "的行的数据有错，次数不能为空!');location='RecipeGet.aspx'</script>");   //当Excel表为空时,对用户进行提示  
                    return;
                }
                else
                {
                    ztakenum = Convert.ToInt16(rinfo.nNum);
                }
               

                rinfo.strDrugGetTime = dr[i]["取药时间"].ToString();//时间

                if (rinfo.strDrugGetTime == "")
                {
                    System.DateTime seconddayTime = new System.DateTime();
                    seconddayTime = System.DateTime.Now.AddDays(1);//当前时间  


                    string getdrugtime = seconddayTime.ToString("yyyy-MM-dd 08:00:00");//
                    rinfo.strDrugGetTime = getdrugtime;

                }
                else
                {

                }


                rinfo.strDrugGetNum = dr[i]["取药序号"].ToString();
                if (rinfo.strDrugGetNum == "")
                {
                }
                else
                {
                    zgetdrugnum = Convert.ToInt16(rinfo.strDrugGetNum);
                }
               



                rinfo.strScheme = dr[i]["煎药方案"].ToString();
                rinfo.strTimeOne = dr[i]["一煎时间"].ToString();
                if (rinfo.strTimeOne == "")
                {
                }
                else
                {
                    zoncetime = Convert.ToInt16(rinfo.strTimeOne);
                }
                rinfo.strTimeTwo = dr[i]["二煎时间"].ToString();
                if (rinfo.strTimeTwo == "")
                {
                }
                else
                {
                    ztwicetime = Convert.ToInt16(rinfo.strTimeTwo);
                }
                rinfo.nPackageNum = dr[i]["包装量"].ToString();//
                if (rinfo.nPackageNum == "")
                {
                    Response.Write("<script>alert('序号为" + seq + "的行的数据有错，包装量不能为空!');location='RecipeGet.aspx'</script>");   //当Excel表为空时,对用户进行提示  
                    return;
                }
                else
                {
                    zpackagenum = Convert.ToInt16(rinfo.nPackageNum);
                }
               

              

                rinfo.strDoTime = strdotime;//操作时间
                rinfo.strDoPerson = doperson;
                rinfo.strDtbCompany = dr[i]["配送公司"].ToString();
                rinfo.strDtbAddress = dr[i]["配送地址"].ToString();
                rinfo.strDtbPhone = dr[i]["联系电话"].ToString();
                rinfo.strDtbStyle = dr[i]["快件类型"].ToString();
                rinfo.nSoakWater = dr[i]["浸泡加水量"].ToString();//
                if (rinfo.nSoakWater == "")
                {
                }
                else
                {
                    zsoakwater = Convert.ToInt16(rinfo.nSoakWater);
                }



                rinfo.nSoakTime = dr[i]["浸泡时间"].ToString();//只能数整数；；；
                if (rinfo.nSoakTime == "")
                {
                    zsoaktime = 30;
                }
                else
                {
                    zsoaktime = Convert.ToInt16(rinfo.nSoakTime);
                }


                rinfo.nLabelNum = dr[i]["标签数量"].ToString();//
                if (rinfo.nLabelNum == "")
                {
                }
                else
                {
                    zlabelnum = Convert.ToInt16(rinfo.nLabelNum);
                }



                rinfo.strRemark = dr[i]["备注信息"].ToString();
                rinfo.strDoctor = dr[i]["医生"].ToString();
                rinfo.strFootNote = dr[i]["医生脚注"].ToString();
                rinfo.strOrderTime = dr[i]["下单时间"].ToString();//下单时间
                // rinfo.strCurState = dr[i]["当前状态"].ToString();
                rinfo.strDecMothed = dr[i]["煎药方式"].ToString();
                rinfo.strTakeWay = dr[i]["服用方法"].ToString();
                rinfo.strTakeMethod = dr[i]["服用方式"].ToString();
                rinfo.strRemarksA = dr[i]["备注A"].ToString();
                rinfo.strRemarksB = dr[i]["备注B"].ToString();


                int hid = Convert.ToInt32(hospitalname.Value);

                EntrustNumberModel enm = new EntrustNumberModel();
                rinfo.strDelnum = enm.getEntrustNumber(hid) + "";
                rinfo.strCurState = "未匹配";

                string sqlcheck = "select count(*) from prescription where hospitalid='" + hid + "' And pspnum='" + rinfo.strPspnum + "'";  //检查用户是否存在  
                SqlCommand sqlcmd = new SqlCommand(sqlcheck, cn);
                int count = Convert.ToInt32(sqlcmd.ExecuteScalar());
                if (count < 1)
                {
                    string strSql = "insert into prescription(delnum,Hospitalid,Pspnum,name,sex,age,phone,address,department,inpatientarea,ward,sickbed,";
                    strSql += "diagresult,dose,takenum,getdrugtime,getdrugnum,decscheme,oncetime,twicetime,packagenum,dotime,doperson,";
                    strSql += "dtbcompany,dtbaddress,dtbphone,dtbtype,soakwater,soaktime,labelnum,remark,doctor,footnote,ordertime,curstate,decmothed,takeway,takemethod,RemarksA,RemarksB)";
                    strSql += " values('" + rinfo.strDelnum + "','" + hid + "','" + rinfo.strPspnum + "',";
                    strSql += "'" + rinfo.strName + "','" + zsex + "','" + zage + "','" + rinfo.strPhone + "','" + rinfo.strAddress + "',";
                    strSql += "'" + rinfo.strDepartment + "','" + rinfo.strInpatientAreaNum + "','" + rinfo.strWard + "','" + rinfo.strSickBed + "',";
                    strSql += "'" + rinfo.strDiagResult + "','" + rinfo.strDose + "','" + ztakenum + "','" + rinfo.strDrugGetTime + "','" + zgetdrugnum + "',";
                    strSql += "'" + rinfo.strScheme + "','" + zoncetime + "','" + ztwicetime + "','" + zpackagenum + "','" + rinfo.strDoTime + "',";
                    strSql += "'" + rinfo.strDoPerson + "','" + rinfo.strDtbCompany + "','" + rinfo.strDtbAddress + "','" + rinfo.strDtbPhone + "','" + rinfo.strDtbStyle + "',";
                    strSql += "'" + zsoakwater + "','" + zsoaktime + "','" + zlabelnum + "','" + rinfo.strRemark + "','" + rinfo.strDoctor + "','" + rinfo.strFootNote + "','" + rinfo.strOrderTime + "','" + rinfo.strCurState + "','" + rinfo.strDecMothed + "','" + rinfo.strTakeWay + "','" + rinfo.strTakeMethod + "','" + rinfo.strRemarksA + "','" + rinfo.strRemarksB + "')";

                    // string insertstr = "insert into prescription (hospitalid,pspsnum) values('" +hospitalid+ "','" + pspnum+"')";
                    SqlCommand cmd = new SqlCommand(strSql, cn);
                    try
                    {
                        cmd.ExecuteNonQuery();

                             DataBaseLayer db = new DataBaseLayer();

                             string str2 = "select id from prescription where hospitalid ='" + hid + "' and Pspnum='" + rinfo.strPspnum + "'";
                            SqlDataReader srd2 = db.get_Reader(str2);
                            if (srd2.Read())
                            {
                                string pid = srd2["id"].ToString();
                                string str3 = "insert into jfInfo(pid,jiefangman,jiefangtime)values('" + pid + "','" + rinfo.strDoPerson + "','" + rinfo.strDoTime + "')";
                                db.cmd_Execute(str3);
                            }

                    }
                    catch (Exception ex)       //捕捉异常  
                    {
                        Response.Write("<script>alert('序号为" + seq + "的信息出错，导入内容:" + ex.Message + "');location='RecipeGet.aspx'</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('序号为" + seq + "的信息出错，内容重复！禁止导入');location='RecipeGet.aspx'</script></script> ");
                    continue;
                }
            }
               
            }
            Response.Write("<script>alert('Excle表导入结束!');location='RecipeGet.aspx'</script>");
        }
        cn.Close();
    }
  

    // 查询EXCEL电子表格添加到DATASET  
    public DataSet ExecleDs(string filenameurl, string table)
    {
        string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + filenameurl + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";
        OleDbConnection conn = new OleDbConnection(strConn);
        conn.Open();
        DataSet ds = new DataSet();
        OleDbDataAdapter odda = new OleDbDataAdapter("select * from [Sheet1$]", conn);
        odda.Fill(ds, table);
        return ds;
    }

   

}