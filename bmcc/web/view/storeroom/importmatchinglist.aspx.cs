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
public partial class view_storeroom_importmatchinglist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int zage = 0;
        int zsex = 0;
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
            Response.Write("<script>alert('请您选择Excel文件');location='DrugMatchingList.aspx'</script> ");


            return;//当无文件时,返回  
        }
        string IsXls = System.IO.Path.GetExtension(FileUpload1.FileName).ToString().ToLower();//System.IO.Path.GetExtension获得文件的扩展名  
        if (IsXls != ".xls")
        {
            Response.Write("<script>alert('只可以选择Excel文件');location='DrugMatchingList.aspx'</script>");
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

        if (columns != 7)
        {
            Response.Write("<script>alert('Excel表导入格式不对,请选择正确的模板!');location='DrugMatchingList.aspx'</script>");
        }
        else
        {
            if (rowsnum == 0)
            {
                Response.Write("<script>alert('Excel表为空表,无数据!');location='DrugMatchingList.aspx'</script>");   //当Excel表为空时,对用户进行提示  
            }
            else
            {
                for (int i = 0; i < dr.Length; i++)
                {

                    string seq = dr[i]["序号"].ToString();
                    string hospitalname = dr[i]["医院名称"].ToString();
                    string hospitalnum = dr[i]["医院编号"].ToString();
                    // rinfo.nSex = Convert.ToInt16(dr[i]["性别"].ToString());
                    string hdrugname = dr[i]["医院药品名称"].ToString();//
                    string hdrugnum = dr[i]["医院药品编号"].ToString();

                    string ydrugname = dr[i]["饮片厂药品名称"].ToString();
                    string ydrugnum = dr[i]["饮片厂药品编号"].ToString();


                    DataBaseLayer db = new DataBaseLayer();
                    string str = "select id from hospital where hname ='" + hospitalname + "' and hnum ='" + hospitalnum + "'";
                    SqlDataReader sdr = db.get_Reader(str);
                    string hospitalid = "";
                    string strSql = "";


                    if (sdr.Read())
                    {
                        string str1 = "select * from drugadmin where drugname ='" + ydrugname + "' and drugcode ='" + ydrugnum + "'";
                        SqlDataReader sdr1 = db.get_Reader(str1);

                        if (sdr1.Read())
                        {
                            hospitalid = sdr["id"].ToString();


                            string str2 = "select * from ypcdrug where drugname ='" + hdrugname + "' and drugnum ='" + hdrugnum + "' and hospitalid ='" + hospitalid + "'";
                            SqlDataReader sdr2 = db.get_Reader(str2);

                            if (sdr2.Read())
                            {
                                Response.Write("<script>alert('序号为" + seq + "的信息出错,该药品在该医院已经匹配过了');location='DrugMatchingList.aspx'</script>");
                            }
                            else
                            {
                                strSql = "insert into ypcdrug(drugName, drugNum, drugDetailedName, drugAlias,hospitalid) ";
                                strSql += "values ('" + hdrugname + "','" + hdrugnum + "','" + ydrugname + "','" + ydrugnum + "','" + hospitalid + "')";

                                // string insertstr = "insert into prescription (hospitalid,pspsnum) values('" +hospitalid+ "','" + pspnum+"')";
                                SqlCommand cmd = new SqlCommand(strSql, cn);
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)       //捕捉异常  
                                {
                                    Response.Write("<script>alert('序号为" + seq + "的信息出错，导入内容:" + ex.Message + "');location='DrugMatchingList.aspx'</script>");
                                }
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('序号为" + seq + "的信息出错,饮片厂没有该药品');location='DrugMatchingList.aspx'</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('序号为" + seq + "的信息出错，不存在改医院');location='DrugMatchingList.aspx'</script>");
                    }
                }




            }
            Response.Write("<script>alert('Excle表导入完成!');location='DrugMatchingList.aspx'</script>");
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