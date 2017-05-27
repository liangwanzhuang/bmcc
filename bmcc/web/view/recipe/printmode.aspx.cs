using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;
using ModelInfo;
using System.Data.SqlClient;

using System.Web.UI.HtmlControls;
using System.Web.Script.Services;
using System.Web.Services;
using ModelInfo;
using System.Drawing;
using System.Configuration;
using System.IO;


public partial class view_recipe_printmode : System.Web.UI.Page
{



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RecipeModel rm = new RecipeModel();
            DataTable dt = rm.getprintstatus();

            string adjust = dt.Rows[0][18].ToString();
            string adjustbarcode = dt.Rows[1][18].ToString();
            string packbarcode = dt.Rows[2][18].ToString();

            Select1.Items.Add(new ListItem("--全部--", "0"));

            if (adjust == "1")
            {
                Select1.Items.Add(new ListItem("调配单", "1"));
                this.print1.Style["display"] = "block";

                SqlDataReader sdr = rm.getprintstatusbytype("1");
                if (sdr.Read())
                {
                    if (sdr["strName"].ToString() == "1")
                    {
                        this.div41.Style["display"] = "block";
                    }
                    if (sdr["nSex"].ToString() == "1")
                    {
                        this.div42.Style["display"] = "block";
                    }
                    if (sdr["nAge"].ToString() == "1")
                    {
                        this.div43.Style["display"] = "block";
                    }
                    if (sdr["strSickBed"].ToString() == "1")
                    {
                        this.div44.Style["display"] = "block";
                    }
                    if (sdr["strHospitalName"].ToString() == "1")
                    {
                        this.div45.Style["display"] = "block";
                    }
                    if (sdr["strPspnum"].ToString() == "1")
                    {
                        this.div46.Style["display"] = "block";
                    }
                    if (sdr["strScheme"].ToString() == "1")
                    {
                        this.div47.Style["display"] = "block";
                    }
                    if (sdr["strInpatientAreaNum"].ToString() == "1")
                    {
                        this.div48.Style["display"] = "block";
                    }
                    if (sdr["strWard"].ToString() == "1")
                    {
                        this.div49.Style["display"] = "block";
                    }
                    if (sdr["strDepartment"].ToString() == "1")
                    {
                        this.div51.Style["display"] = "block";
                    }
                    if (sdr["strDose"].ToString() == "1")
                    {
                        this.div52.Style["display"] = "block";
                    }
                    if (sdr["nNum"].ToString() == "1")
                    {
                        this.div53.Style["display"] = "block";

                    }
                    if (sdr["nPackageNum"].ToString() == "1")
                    {
                        this.div54.Style["display"] = "block";
                    }
                    if (sdr["strDrugGetTime"].ToString() == "1")
                    {
                        this.div55.Style["display"] = "block";
                    }
                    if (sdr["strOrderTime"].ToString() == "1")
                    {
                        this.div56.Style["display"] = "block";
                    }
                    if (sdr["strTakeMethod"].ToString() == "1")
                    {
                        this.div59.Style["display"] = "block";
                    }
                    if (sdr["strTakeWay"].ToString() == "1")
                    {
                        this.div60.Style["display"] = "block";
                    }

                }
            }

            if (adjustbarcode == "1")
            {
                Select1.Items.Add(new ListItem("调配条码", "2"));
                this.print2.Style["display"] = "block";
                SqlDataReader sdr = rm.getprintstatusbytype("2");
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
            if (packbarcode == "1")
            {
                Select1.Items.Add(new ListItem("包装条码", "3"));
                this.print3.Style["display"] = "block";

                SqlDataReader sdr = rm.getprintstatusbytype("3");
                if (sdr.Read())
                {
                    if (sdr["strName"].ToString() == "1")
                    {
                        this.div22.Style["display"] = "block";
                    }
                    if (sdr["nSex"].ToString() == "1")
                    {
                        this.div23.Style["display"] = "block";
                    }
                    if (sdr["nAge"].ToString() == "1")
                    {
                        this.div24.Style["display"] = "block";
                    }
                    if (sdr["strSickBed"].ToString() == "1")
                    {
                        this.div25.Style["display"] = "block";
                    }
                    if (sdr["strHospitalName"].ToString() == "1")
                    {
                        this.div26.Style["display"] = "block";
                    }
                    if (sdr["strPspnum"].ToString() == "1")
                    {
                        this.div27.Style["display"] = "block";
                    }
                    if (sdr["strScheme"].ToString() == "1")
                    {
                        this.div28.Style["display"] = "block";
                    }
                    if (sdr["strInpatientAreaNum"].ToString() == "1")
                    {
                        this.div29.Style["display"] = "block";
                    }
                    if (sdr["strWard"].ToString() == "1")
                    {
                        this.div30.Style["display"] = "block";
                    }
                    if (sdr["strDepartment"].ToString() == "1")
                    {
                        this.div31.Style["display"] = "block";
                    }
                    if (sdr["strDose"].ToString() == "1")
                    {
                        this.div32.Style["display"] = "block";
                    }
                    if (sdr["nNum"].ToString() == "1")
                    {
                        this.div33.Style["display"] = "block";

                    }
                    if (sdr["nPackageNum"].ToString() == "1")
                    {
                        this.div34.Style["display"] = "block";
                    }
                    if (sdr["strDrugGetTime"].ToString() == "1")
                    {
                        this.div35.Style["display"] = "block";
                    }
                    if (sdr["strOrderTime"].ToString() == "1")
                    {
                        this.div36.Style["display"] = "block";
                    }
                    if (sdr["strTakeMethod"].ToString() == "1")
                    {
                        this.div39.Style["display"] = "block";
                    }
                    if (sdr["strTakeWay"].ToString() == "1")
                    {
                        this.div40.Style["display"] = "block";
                    }
                }
            }

            BindDataToRepeater();
            this.Image1.ImageUrl = printbarcode();
            this.Image2.ImageUrl = printbarcode();


        }

    }


    private void BindDataToRepeater()
    {

        // string strSql = "Data Source=118.244.237.123;Initial Catalog=rinfo;user id=sa;password=dalianvideo;MultipleActiveResultSets=true";
        string strSql = ConfigurationManager.ConnectionStrings["SKConnection"].ConnectionString;
        SqlConnection myConn = new SqlConnection(strSql);

        int id = 0;
        if (Request.QueryString["id"] != null)
        {
            id = Convert.ToInt16(Request.QueryString["id"]);
            idnum.Value = Request.QueryString["id"].ToString();
        }
        string psp = "";
        string hospitalid = "";
        string drugtime = "";
        string drugnum = "";
        string name = "";
        string sex = "";
        string age = "";
        string department = "";
        string dot = "";
        string getdrug1 = "";
        string getdrug2 = "";
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
            dot = sdr["doctor"].ToString();
            getdrug2 = sdr["dose"].ToString();
            getdrug1 = sdr1["p"].ToString();
            getdrugweight = sdr2["pp"].ToString();

        }
        getdrugnum.Text = drugnum;
        getdrugtime.Text = drugtime;

        if (sex == "1")
        {
            sex = "男";
        }
        else
        {
            sex = "女";
        }

        string strDelNum = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
        printtime.Text = strDelNum;

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

        this.hospitalnamebar.Text = hname;  //sdr["Hospitalid"].ToString();//

        this.pspnumbar.Text = sdr["pspnum"].ToString();
        this.strSchemebar.Text = getDecscheme(sdr["decscheme"].ToString());
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

        this.namebar1.Text = name;
        if (sex == "1")
        {
            sex = "男";
            this.sexbar1.Text = sex;
        }
        else
        {
            sex = "女";
            this.sexbar1.Text = sex;
        }


        this.agebar1.Text = age;
        this.roomnumbar1.Text = sdr["sickbed"].ToString();
        this.hospitalnamebar1.Text = hname;//sdr["Hospitalid"].ToString();//

        this.pspnumbar1.Text = sdr["pspnum"].ToString();
        this.strSchemebar1.Text = getDecscheme(sdr["decscheme"].ToString());
        this.strInpatientAreaNumbar1.Text = sdr["inpatientarea"].ToString();

        this.strWardbar1.Text = sdr["ward"].ToString();


        this.strDepartmentbar1.Text = sdr["department"].ToString();

        this.dosebar1.Text = sdr["dose"].ToString();

        this.nNumbar1.Text = sdr["takenum"].ToString();


        this.nPackageNumbar1.Text = sdr["packagenum"].ToString();

        this.strDrugGetTimebar1.Text = sdr["getdrugtime"].ToString();

        this.strDrugGetNumbar1.Text = sdr["getdrugnum"].ToString();

        this.decmothedbar1.Text = sdr["decmothed"].ToString();


        this.takemethodbar1.Text = sdr["takemethod"].ToString();

        this.takewaybar1.Text = sdr["takeway"].ToString();


        this.ordertimebar1.Text = sdr["ordertime"].ToString();

        //调剂内容

        this.namebar3.Text = name;
        if (sex == "1")
        {
            sex = "男";
            this.sexbar3.Text = sex;
        }
        else
        {
            sex = "女";
            this.sexbar3.Text = sex;
        }


        this.agebar3.Text = age;
        this.roomnumbar3.Text = sdr["sickbed"].ToString();
        this.hospitalnamebar3.Text = hname;//sdr["Hospitalid"].ToString();//

        this.pspnumbar3.Text = sdr["pspnum"].ToString();
        this.strSchemebar3.Text = getDecscheme(sdr["decscheme"].ToString());
        this.strInpatientAreaNumbar3.Text = sdr["inpatientarea"].ToString();

        this.strWardbar3.Text = sdr["ward"].ToString();


        this.strDepartmentbar3.Text = sdr["department"].ToString();

        this.dosebar3.Text = sdr["dose"].ToString();

        this.nNumbar3.Text = sdr["takenum"].ToString();


        this.nPackageNumbar3.Text = sdr["packagenum"].ToString();

        this.strDrugGetTimebar3.Text = sdr["getdrugtime"].ToString();

        this.strDrugGetNumbar3.Text = sdr["getdrugnum"].ToString();

        this.decmothedbar3.Text = sdr["decmothed"].ToString();


        this.takemethodbar3.Text = sdr["takemethod"].ToString();

        this.takewaybar3.Text = sdr["takeway"].ToString();

        this.ordertimebar3.Text = sdr["ordertime"].ToString();

        string sql2 = "select ROW_NUMBER() OVER(ORDER BY d.id desc) as id,d.drugdescription,d.description,d.DrugAllNum,d.DrugWeight,d.DrugPosition,d.drugname,(select ypcdrugPositionNum  from  DrugMatching as m where  m.pspId=d.pid and m.drugId = d.id) as ypcdrugPositionNum from drug as d   where  d.pid='" + id + "'";
        // sql2 = "select   ypcdrugPositionNum   from DrugMatching where pspId ='" + id + "'";

        SqlCommand cmd = new SqlCommand(sql2);
        cmd.Connection = myConn;
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = cmd;
        DataSet ds = new DataSet();
        sda.Fill(ds, "drug");
        rpTest.DataSource = ds.Tables["drug"];
        rpTest.DataBind();
        myConn.Close();




    }



    public string printbarcode()
    {
        int id = 0;
        string barcode = "";
        if (Request.QueryString["id"] != null)
        {
            id = Convert.ToInt16(Request.QueryString["id"]);
            //idnum.Value = Request.QueryString["id"].ToString();

            RecipeModel rm = new RecipeModel();
            barcode = rm.getadjustbarcode(id);
            this.barcode.Text = barcode;
            //this.barcode2.Text = barcode;
            this.packbarcode.Text = barcode;

        }


        /* Code128 _Code = new Code128();
          _Code.ValueFont = new Font("宋体", 20);
          //System.Drawing.Bitmap imgTemp = _Code.GetCodeImage("T26200-1900-123-1-0900", Code128.Encode.Code128A);
          System.Drawing.Bitmap imgTemp = _Code.GetCodeImage(barcode, Code128.Encode.Code128B);

          String path = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "barcode\\";
          string imgname = barcode + ".gif";

          imgTemp.Save(path + imgname, System.Drawing.Imaging.ImageFormat.Gif);*/



        System.Drawing.Image image;
        int width = 270, height = 36;
        string fileSavePath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "BarcodePattern.jpg";
        if (File.Exists(fileSavePath))
            File.Delete(fileSavePath);
        GetBarcode(height, width, BarcodeLib.TYPE.CODE128, barcode, out image, fileSavePath);
        string picpath = "~/BarcodePattern.jpg";

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



    [WebMethod]
    public static int printokbyid(string id)
    {

        //int count = 0;
        // HtmlSelect select = (HtmlSelect)FindControl("recipeSelect");
        // RecipeModel rm = new RecipeModel();
        //SqlDataReader sdr = rm.findRecipeByHospitalId(hospitalId);
        // Response.Write("<script>alert('恭喜你注册成功');window.location.href='login.aspx'</script>");

        RecipeModel rm = new RecipeModel();
        int result = rm.printstatus(id);

        return result;
    }

    public String getDecscheme(string decscheme)
    {
        string code = "0";
        if ("1".Equals(decscheme))
        {

            code = "1";
        }
        else if ("2".Equals(decscheme))
        {

            code = "2";
        }
        else if ("3".Equals(decscheme))
        {

            code = "3";
        }
        else if ("4".Equals(decscheme))
        {
            code = "4";

        }
        else if ("5".Equals(decscheme))
        {

            code = "5";
        }
        else if ("6".Equals(decscheme))
        {
            code = "6";

        }
        else if ("7".Equals(decscheme))
        {
            code = "20";

        }
        else if ("8".Equals(decscheme))
        {
            code = "21";

        }
        else if ("9".Equals(decscheme))
        {

            code = "22";
        }
        else if ("10".Equals(decscheme))
        {
            code = "36";

        }
        else if ("11".Equals(decscheme))
        {
            code = "37";

        }
        else if ("12".Equals(decscheme))
        {
            code = "38";

        }
        else if ("13".Equals(decscheme))
        {
            code = "81";

        }
        else if ("14".Equals(decscheme))
        {
            code = "82";

        }
        else if ("15".Equals(decscheme))
        {
            code = "83";

        }
        else if ("16".Equals(decscheme))
        {
            code = "83";

        }

        return code;
    }

    /* protected void CheckBox17_CheckedChanged(object sender, EventArgs e)
     {
         if (this.CheckBox17.Checked == true)
         {
             this.div15.Style["display"] = "block";
         }
         else
         {
             this.div15.Style["display"] = "none";
         }
     }*/
}