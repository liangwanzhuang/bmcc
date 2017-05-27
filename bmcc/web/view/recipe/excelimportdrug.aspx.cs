using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using ModelInfo;
using System.Data.SqlClient;
using System.Web.Services;
using System.Data;
using System.IO;

using System.Data.OleDb;
using System.Web.Security;

using SQLDAL;

public partial class view_recipe_excelimportdrug : System.Web.UI.Page
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

        if (FileUpload2.HasFile == false)//HasFile用来检查FileUpload是否有指定文件  
        {
            Response.Write("<script>alert('请您选择Excel文件');location='RecipeGet.aspx'</script> ");
            return;//当无文件时,返回  
        }


        string IsXls = System.IO.Path.GetExtension(FileUpload2.FileName).ToString().ToLower();//System.IO.Path.GetExtension获得文件的扩展名  
        if (IsXls != ".xls")
        {
            Response.Write("<script>alert('只可以选择Excel文件');location='RecipeGet.aspx'</script>");
            return;//当选择的不是Excel文件时,返回  
        }
       // string strConn = "Data Source=118.244.237.123;Initial Catalog=rinfo;user id=sa;password=dalianvideo;MultipleActiveResultSets=true";

        string strConn = ConfigurationManager.ConnectionStrings["SKConnection"].ConnectionString;

        SqlConnection cn = new SqlConnection(strConn);
        cn.Open();
        string filename = DateTime.Now.ToString("yyyymmddhhMMss") + FileUpload2.FileName;              //获取Execle文件名  DateTime日期函数  
        //  string savePath = Server.MapPath(("~\\upfiles\\") + filename);//Server.MapPath 获得虚拟服务器相对路径
        string savePath = Server.MapPath("~\\upfiles\\");


        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }
        string savePath2 = savePath + filename;
        FileUpload2.SaveAs(savePath2);                        //SaveAs 将上传的文件内容保存在服务器上  
        DataSet ds = ExecleDs(savePath2, filename);           //调用自定义方法  
        DataRow[] dr = ds.Tables[0].Select();            //定义一个DataRow数组  
        int rowsnum = ds.Tables[0].Rows.Count;
        int a = ds.Tables[0].Columns.Count;


        if (a != 12)
        {
            Response.Write("<script>alert('Excel导入格式不正确，请选择正确的模板');location='RecipeGet.aspx'</script>");   //当Excel表为空时,对用户进行提示 
           
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

                DrugInfo dinfo = new DrugInfo();
                //dinfo.strDelNum = dr[i]["委托单号"].ToString();
                //dinfo.nHospitalNum = Convert.ToInt16(dr[i]["医院编号"].ToString());
                string seq = dr[i]["序号"].ToString();

                //  dinfo.strHospitalName = dr[i]["医院名称"].ToString();
                
                dinfo.strPspnum = dr[i]["处方号"].ToString();
                if (dinfo.strPspnum=="")
                {
                    Response.Write("<script>alert('序号为" + seq + "的信息出错，处方号不能为空');location='RecipeGet.aspx'</script>");
                    return;
                }


                dinfo.strDrugNum = dr[i]["药品编号"].ToString();//re23

                if (dinfo.strDrugNum=="")
                {

                    Response.Write("<script>alert('序号为" + seq + "的信息出错，药品编号不能为空');location='RecipeGet.aspx'</script>");
                    return;
                }

                dinfo.strDrugName = dr[i]["药品名称"].ToString();//234
                if (dinfo.strDrugName == "")
                {

                    Response.Write("<script>alert('序号为" + seq + "的信息出错，药品名称不能为空');location='RecipeGet.aspx'</script>");
                    return;
                }

                dinfo.strDrugDsp = dr[i]["脚注"].ToString();
                dinfo.strDrugPosition = dr[i]["药品规格"].ToString();//2423
                if (dinfo.strDrugPosition == "")
                {

                    Response.Write("<script>alert('序号为" + seq + "的信息出错，药品规格不能为空');location='RecipeGet.aspx'</script>");
                    return;
                }



               
                if (dr[i]["单剂量"].ToString() == "")
                {

                    Response.Write("<script>alert('序号为" + seq + "的信息出错，单剂量不能为空');location='RecipeGet.aspx'</script>");
                    return;
                }
                else
                {
                    dinfo.nAllNum = Convert.ToInt32(dr[i]["单剂量"].ToString());//234
                  
                }


                if (dr[i]["总剂量"].ToString() == "")
                {

                    Response.Write("<script>alert('序号为" + seq + "的信息出错，总剂量不能为空');location='RecipeGet.aspx'</script>");
                    return;
                }
                else
                {
                    dinfo.dWeight = Convert.ToDouble(dr[i]["总剂量"].ToString());//234
                }
                if (dr[i]["贴数"].ToString() == "")
                {

                    Response.Write("<script>alert('序号为" + seq + "的信息出错，贴数不能为空');location='RecipeGet.aspx'</script>");
                    return;
                }
                else
                {
                    dinfo.nTieNum = Convert.ToInt32(dr[i]["贴数"].ToString());//2343
                }

                dinfo.strDsp = dr[i]["说明"].ToString();
                dinfo.dWholeSalePrice = Convert.ToDouble(dr[i]["批发价格"].ToString());
                dinfo.dRetailPrice = Convert.ToDouble(dr[i]["零售价格"].ToString());
                //dinfo.dWholeSaleCost = Convert.ToDouble(dr[i]["批发费用"].ToString());
                //dinfo.dRetailCost = Convert.ToDouble(dr[i]["零售费用"].ToString());
                //dinfo.dMoneyWithTax = Convert.ToDouble(dr[i]["含税金额"].ToString());
                //dinfo.dFee = Convert.ToDouble(dr[i]["扣率"].ToString());

                // EnterDrug ed = new EnterDrug();
                // bool rn = ed.AddDrug(dinfo);


                int hid = Convert.ToInt32(hospitalname.Value);



                EntrustNumberModel enm = new EntrustNumberModel();
                dinfo.strDelNum = enm.getEntrustNumber(hid) + "";


               

                    string sqlcheck = "select count(*) from prescription where hospitalid='" + hid + "' And pspnum='" + dinfo.strPspnum + "'";  //检查用户是否存在  
                    SqlCommand sqlcmd = new SqlCommand(sqlcheck, cn);
                    int count = Convert.ToInt32(sqlcmd.ExecuteScalar());
                    if (count > 1 || count == 1)
                    {

                        DataBaseLayer db = new DataBaseLayer();

                        string stateSql1 = "select  id,confirmdrug  from prescription as p where p.Pspnum = '" + dinfo.strPspnum + "' and p.hospitalid = '" + hid + "'";
                        SqlDataReader srd1 = db.get_Reader(stateSql1);
                        string pid = "";
                        string confirmdrug = "";
                        if (srd1.Read())
                        {
                            pid = srd1["id"].ToString();
                            confirmdrug = srd1["confirmdrug"].ToString();

                        }
                        if (confirmdrug == "1")
                        {

                            Response.Write("<script>alert('序号为" + seq + "的信息出错，该处方号不能再导入药品');location='RecipeGet.aspx'</script></script> ");
                            return;

                        }
                        else
                        {


                            string str = "select * from drug where pid='" + pid + "' and drugnum ='" + dinfo.strDrugNum + "' and drugname ='" + dinfo.strDrugName + "'";
                            SqlDataReader srd4 = db.get_Reader(str);

                            if (srd4.Read())
                            {
                                Response.Write("<script>alert('序号为" + seq + "的信息出错，同一处方号不能导入相同的药品');location='RecipeGet.aspx'</script></script> ");
                                return;
                            }
                            else
                            {

                                string strSql = "insert into drug(customid,delnum,Hospitalid,Pspnum,drugnum,drugname,drugdescription,";
                                strSql += "drugposition,drugallnum,drugweight,tienum,description,wholesaleprice,retailprice,wholesalecost,retailpricecost,money,fee,pid) ";
                                strSql += "values(" + dinfo.nCustomId + ",'" + dinfo.strDelNum + "'," + hid + ",'" + dinfo.strPspnum + "',";
                                strSql += "'" + dinfo.strDrugNum + "','" + dinfo.strDrugName + "','" + dinfo.strDrugDsp + "','" + dinfo.strDrugPosition + "',";
                                strSql += "" + dinfo.nAllNum + "," + dinfo.dWeight + "," + dinfo.nTieNum + ",'" + dinfo.strDsp + "'," + dinfo.dWholeSalePrice + ",";
                                strSql += "" + dinfo.dRetailPrice + "," + dinfo.dWholeSaleCost + "," + dinfo.dRetailCost + "," + dinfo.dMoneyWithTax + "," + dinfo.dFee + "," + pid + ")";

                                // string insertstr = "insert into prescription (hospitalid,pspsnum) values('" +hospitalid+ "','" + pspnum+"')";
                                SqlCommand cmd = new SqlCommand(strSql, cn);
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)       //捕捉异常  
                                {
                                    Response.Write("<script>alert('序号为" + seq + "的信息出错，导入内容:" + ex.Message + "');location='RecipeGet.aspx'</script>");
                                    return;
                                }
                            }
                        }
                    
                }
                else
                {

                    Response.Write("<script>alert('序号为" + seq + "的信息出错，不存在医院和对应的处方号');location='RecipeGet.aspx'</script></script> ");
                    return;
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
