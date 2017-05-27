using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Text;
using System.Data;
public partial class view_scan_scanAdjust : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        String type = Request.QueryString["type"].ToString();
        if ("save".Equals(type))
        {
            try
            {
                //   string strName = System.Web.HttpUtility.UrlDecode(Request["txtData"]);

                //  byte[] bt = Convert.FromBase64String(base64string);
                string imgbase64 = Request.Form["imgbase64"];
                // string imgbase64 = Request.QueryString["imgbase64"].ToString();

                // string tisaneNum = Request.QueryString["tisaneNum"].ToString();
                string tisaneNum = Request.Form["tisaneNum"];

                //  string userNum = Request.QueryString["userNum"].ToString();
                string userNum = Request.Form["userNum"];
                string barcode = Request.Form["barcode"];
                string userName = Request.Form["userName"];//员工姓名
                // string userName = Request.QueryString["userName"].ToString();
                //   string userName = Request.Form["userName"];
                // imgbase64 = imgbase64.Replace("+", "%2B");
                string imgname = null;
                if (imgbase64 != null && imgbase64.Trim().Length > 0)
                {
                    imgbase64 = imgbase64.Replace(' ', '+');
                    Byte[] bimg = Convert.FromBase64String(imgbase64);
                    //D:\\项目\\煎药厂\\src\\web\\upload\\

                    String path = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "upload\\";
                    imgname = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".png";
                    FileBinaryConvertHelper.Bytes2File(bimg, path + imgname);
                }



                AdjustModel am = new AdjustModel();
                DataTable dt = am.findAdjustBybarcode(tisaneNum);
                int result = 0;
                if (dt.Rows.Count > 0)
                {

                    if ("1".Equals(dt.Rows[0]["status"].ToString()))
                    {
                        result = 0;
                    }
                    else
                    {

                        result = am.updateAdjust(Convert.ToInt32(dt.Rows[0]["id"].ToString()), 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), userName, tisaneNum);
                    }
                    

                }
                else
                {

                    RecipeModel rm = new RecipeModel();
                    DataTable dtable = rm.findRecipeInfoByCheckId(Convert.ToInt32(tisaneNum));
                    if (dtable.Rows.Count > 0)
                    {
                        result = am.addAdjust(Convert.ToInt32(userNum), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), barcode, "调剂", tisaneNum, imgname,userName);
                    }
                    else
                    {
                        result = 0;
                    }
                    
                }
                if (result > 0)
                {
                    Response.Write("{\"code\":\"0\",\"msg\":\"操作成功\"}");
                }
                else
                {
                    Response.Write("{\"code\":\"1\",\"msg\":\"操作失败\"}");
                }
            }
            catch (Exception e1)
            {
                Response.Write("{\"code\":\"1\",\"msg\":\"操作失败\"}");
            }
            
        }
        else if ("get".Equals(type))
        {
            String id = Request.QueryString["id"].ToString();

            RecipeModel rm = new RecipeModel();
            DataTable dataTable = rm.findAdjustRecipeInfo(Convert.ToInt32(id), DateTime.Now.ToString("yyyy-MM-dd"));

            string adjustwarning = rm.getRetentionWarning(1);
            Response.Write("{\"code\":\"0\",\"msg\":\"操作成功\",\"data\":" + DataTableToJson.ToJson(dataTable) + ",\"warning\":\"" + adjustwarning + "\"}");
        }
        
    
        

      //  Response.Write(imgbase64 + "," + tisaneNum + "," + userNum + "," + userName);
    }


   


}