using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;
using ModelInfo;
using System.Web.UI.HtmlControls;
using System.Web.Script.Services;
using System.Web.Services;

using System.Drawing;
using System.Configuration;
using SQLDAL;
using System.IO;
public partial class view_recipe_tisanebarcode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RecipeModel rm = new RecipeModel();
        DataTable dt = rm.getprintstatus();

       // string adjust = dt.Rows[0][18].ToString();
       // string adjustbarcode = dt.Rows[1][18].ToString();
       // string packbarcode = dt.Rows[2][18].ToString();
         string tisanebarcode = dt.Rows[3][18].ToString();

      
        if (tisanebarcode == "1")
        {
           
            this.print2.Style["display"] = "block";
            SqlDataReader sdr = rm.getprintstatusbytype("4");
            if (sdr.Read())
            {
                if (sdr["strName"].ToString() == "1")
                {
                    this.div16.Style["display"] = "block";
                }
                if (sdr["nSex"].ToString() == "1")
                {
                    this.div17.Style["display"] = "block";
                }
                if (sdr["nAge"].ToString() == "1")
                {
                    this.div18.Style["display"] = "block";
                }
                if (sdr["strSickBed"].ToString() == "1")
                {
                    this.div19.Style["display"] = "block";
                }
                if (sdr["strHospitalName"].ToString() == "1")
                {
                    this.div1.Style["display"] = "block";
                }
                if (sdr["strPspnum"].ToString() == "1")
                {
                    this.div2.Style["display"] = "block";
                }
                if (sdr["strScheme"].ToString() == "1")
                {
                    this.div3.Style["display"] = "block";
                }
                if (sdr["strInpatientAreaNum"].ToString() == "1")
                {
                    this.div4.Style["display"] = "block";
                }
                if (sdr["strWard"].ToString() == "1")
                {
                    this.div5.Style["display"] = "block";
                }
                if (sdr["strDepartment"].ToString() == "1")
                {
                    this.div6.Style["display"] = "block";
                }
                if (sdr["strDose"].ToString() == "1")
                {
                    this.div7.Style["display"] = "block";
                }
                if (sdr["nNum"].ToString() == "1")
                {
                    this.div8.Style["display"] = "block";

                }
                if (sdr["nPackageNum"].ToString() == "1")
                {
                    this.div9.Style["display"] = "block";
                }
                if (sdr["strDrugGetTime"].ToString() == "1")
                {
                    this.div10.Style["display"] = "block";
                }
                if (sdr["strOrderTime"].ToString() == "1")
                {
                    this.div11.Style["display"] = "block";
                }
                if (sdr["strTakeMethod"].ToString() == "1")
                {
                    this.div14.Style["display"] = "block";
                }
                if (sdr["strTakeWay"].ToString() == "1")
                {
                    this.div15.Style["display"] = "block";
                }

            }

        }



             BindDataToRepeater();
            this.Image1.ImageUrl = printbarcode();

    }

       
  private void BindDataToRepeater()
    {



      //  string strSql = "Data Source=118.244.237.123;Initial Catalog=rinfo;user id=sa;password=dalianvideo;MultipleActiveResultSets=true";
        string strSql = ConfigurationManager.ConnectionStrings["SKConnection"].ConnectionString;
        SqlConnection myConn = new SqlConnection(strSql);


        int id = 0;
        if (Request.QueryString["id"] != null)
        {
            id = Convert.ToInt16(Request.QueryString["id"]);
            idnum123.Value = Request.QueryString["id"].ToString();
           // string a = idnum123.Value;

          
        }
        string psp = "";
        string hospitalid = "";
        string drugtime = "";
        string drugnum = "";
        string name = ""; 
        string sex="";
        string age = "";
        string department = "";
        string dot="";
        string  getdrug1="";
        string  getdrug2="";
        string getdrugweight = "";
      
     
        RecipeModel rm = new RecipeModel();
        SqlDataReader sdr = rm.print(id);
        SqlDataReader sdr1 = rm.findrug(id);
        SqlDataReader sdr2 = rm.findrug2(id);
       
      
        if (sdr.Read() && sdr1.Read() && sdr2.Read())
        {
          
           psp = sdr["Pspnum"].ToString();
           hospitalid = sdr["Hospitalid"].ToString();
           drugtime = sdr["getdrugtime"].ToString();
           drugnum = sdr["getdrugnum"].ToString();
           name = sdr["name"].ToString();
           sex = sdr["sex"].ToString();
           age = sdr["age"].ToString();
           department = sdr["department"].ToString();
           dot=sdr["doctor"].ToString();
           getdrug2 = sdr["dose"].ToString();
           getdrug1 = sdr1["p"].ToString();
           getdrugweight = sdr2["pp"].ToString();


       }
      // getdrugnum.Text =  drugnum;
     //  getdrugtime.Text = drugtime;
      // patientname.Text = name;
      //
       if (sex == "1")
       {
           sex = "男";
          // patientsex.Text = sex;
       }
       else {
           sex = "女";
        //   patientsex.Text = sex;
           }
      // patientage.Text = age;
      // patientdepartment.Text = department;
      // pspnum.Text = psp;
       string strDelNum = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
      // printtime.Text = strDelNum;
      // doctor.Text = dot;
       //drug2.Text = getdrug2;
       //drug1.Text = getdrug1;
     //  drugweight.Text = getdrugweight;


        //adjustbarcodeinfo


       this.namebar.Text = name;
       if (sex == "1")
       {
           sex = "男";
           this.sexbar.Text = sex;
       }
       else
       {
           sex = "女";
           this.sexbar.Text = sex;
       }


       this.agebar.Text = age;
       this.roomnumbar.Text = sdr["sickbed"].ToString();

       HospitalModel hm = new HospitalModel();
       SqlDataReader sdr10 = hm.findHospitalnamebyid(sdr["Hospitalid"].ToString());
       string hname = "";
       if (sdr10.Read())
       {
           hname = sdr10["hname"].ToString();
       }


       this.hospitalnamebar.Text = hname;//sdr["Hospitalid"].ToString();//

       this.pspnumbar.Text = sdr["pspnum"].ToString();
       this.strSchemebar.Text = sdr["decscheme"].ToString();
       this.strInpatientAreaNumbar.Text = sdr["inpatientarea"].ToString();

       this.strWardbar.Text = sdr["ward"].ToString();


       this.strDepartmentbar.Text = sdr["department"].ToString();

       this.dosebar.Text = sdr["dose"].ToString();

       this.nNumbar.Text = sdr["takenum"].ToString();


       this.nPackageNumbar.Text = sdr["packagenum"].ToString();

       this.strDrugGetTimebar.Text = sdr["getdrugtime"].ToString();

       this.strDrugGetNumbar.Text = sdr["getdrugnum"].ToString();

       this.decmothedbar.Text = sdr["decmothed"].ToString();


       this.takemethodbar.Text = sdr["takemethod"].ToString();

       this.takewaybar.Text = sdr["takeway"].ToString();


       this.ordertimebar.Text = sdr["ordertime"].ToString();


        //packagebarcodeinfo

      // this.namebar1.Text = name;
       if (sex == "1")
       {
           sex = "男";
         //  this.sexbar1.Text = sex;
       }
       else
       {
           sex = "女";
         //  this.sexbar1.Text = sex;
       }



       string sql2 = "select ROW_NUMBER() OVER(ORDER BY d.id desc) as id,d.drugdescription,d.description,d.DrugAllNum,d.DrugWeight,d.DrugPosition,d.drugname,(select ypcdrugPositionNum  from  DrugMatching as m where  m.pspId=d.pid and m.drugId = d.id) as ypcdrugPositionNum from drug as d   where  d.pid='" + id + "'";
              // sql2 = "select   ypcdrugPositionNum   from DrugMatching where pspId ='" + id + "'";
       
        SqlCommand cmd = new SqlCommand(sql2);
        cmd.Connection = myConn;
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = cmd;
        DataSet ds = new DataSet();
        sda.Fill(ds, "drug");
      //  rpTest.DataSource = ds.Tables["drug"];
      //  rpTest.DataBind();   

        myConn.Close();
       
    }





     public string printbarcode()
    {
        int id = 0;
        string barcode="";
        if (Request.QueryString["id"] != null)
        {
            id = Convert.ToInt16(Request.QueryString["id"]);
            //idnum.Value = Request.QueryString["id"].ToString();

            RecipeModel rm = new RecipeModel();
           barcode = rm.gettisanebarcode(id);
           this.barcode.Text = barcode;
          // this.barcode2.Text = barcode;
        }

        System.Drawing.Image image;
        int width = 270, height = 36;
        string fileSavePath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "BarcodePattern.jpg";
        if (File.Exists(fileSavePath))
            File.Delete(fileSavePath);
        GetBarcode(height, width, BarcodeLib.TYPE.CODE128, barcode, out image, fileSavePath);

        //pictureBox1.Image = Image.FromFile("BarcodePattern.jpg");  



        //FileBinaryConvertHelper.Bytes2File(bimg, path + imgname);
        //  string picpath = "http://123.56.104.61/barcode/" + imgname;


        string picpath = "http://123.56.104.61/BarcodePattern.jpg";

       /* Code128 _Code = new Code128();
        _Code.ValueFont = new Font("宋体", 20);
        //System.Drawing.Bitmap imgTemp = _Code.GetCodeImage("T26200-1900-123-1-0900", Code128.Encode.Code128A);
        System.Drawing.Bitmap imgTemp = _Code.GetCodeImage(barcode, Code128.Encode.Code128B);

        String path = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "barcode\\";
        string imgname = barcode + ".gif";

        imgTemp.Save(path + imgname, System.Drawing.Imaging.ImageFormat.Gif);

        //FileBinaryConvertHelper.Bytes2File(bimg, path + imgname);
        string picpath = "http://123.56.104.61/barcode/" + imgname;
        String path21213 = Request.Url.Host;
        String path123 = Request.ApplicationPath;*/

        return picpath;

    }



     public static void GetBarcode(int height, int width, BarcodeLib.TYPE type, string code, out System.Drawing.Image image, string fileSaveUrl)
     {
         try
         {
             image = null;
             BarcodeLib.Barcode b = new BarcodeLib.Barcode();
             b.BackColor = System.Drawing.Color.White;//图片背景颜色  
             b.ForeColor = System.Drawing.Color.Black;//条码颜色  
             b.IncludeLabel = false;
             b.Alignment = BarcodeLib.AlignmentPositions.LEFT;
             //b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;
             b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMLEFT;
             b.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;//图片格式  
             // b.ImageFormat = System.Drawing.Imaging.ImageFormat.Gif;//图片格式  
             System.Drawing.Font font = new System.Drawing.Font("verdana", 10f);//字体设置  
             b.LabelFont = font;
             b.Height = height;//图片高度设置(px单位)  
             b.Width = width;//图片宽度设置(px单位)  

             image = b.Encode(type, code);//生成图片  


             image.Save(fileSaveUrl, System.Drawing.Imaging.ImageFormat.Jpeg);

         }
         catch (Exception ex)
         {

             image = null;
         }
     }  


    }

 

   