using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ModelInfo;
using System.IO.Ports;
using System.Drawing;

using System.Text;
using System.IO;

    public partial class view_recipe_EmployeeBarCode : System.Web.UI.Page
    {
        SerialPort serialPort1;
        
        private void Page_Load(object sender, System.EventArgs e)
        {

            string jn = "";
            string jm = "";
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt16(Request.QueryString["id"]);
                idnum.Value = Request.QueryString["id"].ToString();
                EmployeeModel rm = new EmployeeModel();
                DataTable dt = rm.findEmployeeInfo(id);
              
                jn = dt.Rows[0]["JobNum"].ToString();
                jm = dt.Rows[0]["EName"].ToString();
                
            }

            string ng = jn ;
            string  bg = jm;
          //  Response.Write(PrintBmWorkerData(ng, bg));
           // PrintBmWorkerData(ng, bg);

            this.employeename.Text = bg;
            this.employeenum.Text = jn;
            this.Image1.ImageUrl = printemployeecode(ng, bg);

           // string spath = Server.MapPath("");


        }



        private string printemployeecode(string a, string b)
        {



            string id = a;
            string name = b;//dataGridViewX1.SelectedRows[0].Cells[2].Value.ToString();
            string data = id;
            try
            {
                for (int i = 0; i < name.Length; i++)
                {
                    data += this.getAscStr(name.Substring(i, 1));
                }
            }
            catch { }




          /*  Code128 _Code = new Code128();
            _Code.ValueFont = new Font("宋体", 20);
            //System.Drawing.Bitmap imgTemp = _Code.GetCodeImage("T26200-1900-123-1-0900", Code128.Encode.Code128A);
            System.Drawing.Bitmap imgTemp = _Code.GetCodeImage(data, Code128.Encode.Code128B);


         

            String path = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "barcode\\";
           string  imgname = a+b + ".gif";

           imgTemp.Save(path + imgname, System.Drawing.Imaging.ImageFormat.Gif);

            //FileBinaryConvertHelper.Bytes2File(bimg, path + imgname);
           string picpath = "http://123.56.104.61/barcode/" + imgname;
           String path21213 = Request.Url.Host;
           String path123 = Request.ApplicationPath;*/




            System.Drawing.Image image;
            int width = 240, height = 64;
            string fileSavePath = AppDomain.CurrentDomain.BaseDirectory + "BarcodePattern.jpg";
            if (File.Exists(fileSavePath))
                File.Delete(fileSavePath);
            GetBarcode(height, width, BarcodeLib.TYPE.CODE128, data, out image, fileSavePath);

            //pictureBox1.Image = Image.FromFile("BarcodePattern.jpg");  



            //FileBinaryConvertHelper.Bytes2File(bimg, path + imgname);
            //  string picpath = "http://123.56.104.61/barcode/" + imgname;


            string picpath = "http://123.56.104.61/BarcodePattern.jpg";

          
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
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        /// <summary>
        /// 打印煎药工数据
        /// </summary>
        /*  private void PrintBmWorkerData( string a,string b)
          {
              string id =a;
              string name = b;//dataGridViewX1.SelectedRows[0].Cells[2].Value.ToString();
              string data = id;
              try
              {
                  for (int i = 0; i < name.Length; i++)
                  {
                      data +=this.getAscStr(name.Substring(i, 1));
                  }
              }
              catch { }

              //组合打印需要的字符串
              string printStr = "";
              printStr += "SIZE 66.10 mm, 37 mm\r\n";
              printStr += "GAP 3 mm, 0 mm\r\n";
              printStr += "SPEED 5\r\n";
              printStr += "DENSITY 7\r\n";
              printStr += "DIRECTION 0,0\r\n";
              printStr += "REFERENCE 0,0\r\n";
              printStr += "OFFSET 0 mm\r\n";
              printStr += "SHIFT 0\r\n";
              printStr += "SET PEEL OFF\r\n";
              printStr += "SET CUTTER OFF\r\n";
              printStr += "SET PARTIAL_CUTTER OFF\r\n";
              printStr += "SET TEAR ON\r\n";
              printStr += "CLS\r\n";
              printStr += "CODEPAGE 850\r\n";
              printStr += "TEXT 450,320,\"TSS24.BF2\",180,2,2,\"员工条码工牌\"\r\n";//TEXT 340,280,"TSS24.BF2",180,1,1,"煎药工条码工牌"
              printStr += "TEXT 510,265,\"TSS24.BF2\",180,2,1,\"姓名：" + id + " " + name + "\"\r\n";//TEXT 430,100,"TSS24.BF2",180,1,1,"工号：1001    姓名：康建荣"
              printStr +=  "BARCODE 460,230,\"128\",60,0,180,2,6,\"" + data + "\"\r\n";//BARCODE 515,223,"128",60,0,180,2,6,"1001KangJianRongKJR1";
              printStr += "TEXT 480,160,\"3\",180,1,1,\"" + data + "\"\r\n";//TEXT 430,140,"3",180,1,1,"1001KangJianRongKJR1"
              printStr += "BARCODE 480,120,\"128\",60,0,180,2,6,\"" + "9"+data + "\"\r\n";//BARCODE 515,223,"128",60,0,180,2,6,"1001KangJianRongKJR1"
              printStr += "TEXT 420,50,\"TSS24.BF2\",180,1,1,\"(包装工注册条码)\"\r\n";
              printStr += "PRINT 1,1\r\n";
            //  System.IO.Ports serialPort1 = new Ports();
              serialPort1 = new SerialPort();
              serialPort1.PortName = "COM1";
              serialPort1.BaudRate = 9600;
              try
                 {
                  
                     //如果串口关闭的话先打开串口
                     if (!serialPort1.IsOpen)
                     {
                         serialPort1.Open();
                     }
                     //发送给打印机打印
                     serialPort1.Encoding =Encoding.Default;
                     serialPort1.Write(printStr);

                 
                     //打印完毕关掉串口
                     serialPort1.Close();
                 
                    // MessageBoxEx.Show("打印数据成功！", "提示信息", MessageBoxButtons.OK,MessageBoxIcon.Information);
                     Page.ClientScript.RegisterStartupScript(
                   this.GetType(), "myscript",
                   "<script type=\"text/javascript\">function ShowAlert(){alert('打印数据成功！, 提示信息');}window.onload=ShowAlert;</script>");

                 }
                 catch (Exception e)
                 {
                    // MessageBoxEx.Show("串口使用出错，请等待一会再试！\r\n具体错误信息为：" + e.Message);
                     Page.ClientScript.RegisterStartupScript(
                  this.GetType(), "myscript",
                  "<script type=\"text/javascript\">function ShowAlert(){alert('串口使用出错'+'" + e.Message + "');}window.onload=ShowAlert;</script>");
                 }
          
          }*/

        /// <summary>
        /// 根据字符串获取ASC字符串
        /// </summary>
        private string getAscStr(String OrgChar)
        {
            string result = "";
            try
            {
                byte[] aryByte =System.Text.Encoding.Default.GetBytes(OrgChar);
                for (int i = 0; i < aryByte.Length; i++)
                    result +=Convert.ToString(Convert.ToInt32(aryByte[i]));
            }
            catch (Exception eee)
            {
                result = "";
            }

            return result;
        }

}
        
   
