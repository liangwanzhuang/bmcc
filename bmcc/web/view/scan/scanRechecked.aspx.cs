using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Text;
using System.Data;
public partial class view_scan_scanRechecked : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        String type = Request.QueryString["type"].ToString();
        if ("save".Equals(type))
        {
            try
            {
                string imgbase64 = Request.Form["imgbase64"];//图片
                string tisaneNum = Request.Form["tisaneNum"];//煎药单号
                string userNum = Request.Form["userNum"];//员工号
                string barcode = Request.Form["barcode"];//条形码
                string userName = Request.Form["userName"];//员工姓名
                string imgname = null;
                string nowDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if (imgbase64 != null && imgbase64.Trim().Length > 0)
                {
                    imgbase64 = imgbase64.Replace(' ', '+');
                    Byte[] bimg = Convert.FromBase64String(imgbase64);
                    //D:\\项目\\煎药厂\\src\\web\\upload\\

                    String path = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "upload\\";
                    imgname = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".png";
                    FileBinaryConvertHelper.Bytes2File(bimg, path + imgname);
                }
                RecheckedModel rm = new RecheckedModel();

                DataTable dt = rm.findRecheckedInfoByBarcode(tisaneNum);
                int result = 0;
                if (dt.Rows.Count > 0)
                {
                   /* 
                    if ("1".Equals(dt.Rows[0]["status"].ToString()))
                    {
                        result = 1;
                    }
                    else
                    {

                        result = rm.updateRechecked(Convert.ToInt32(dt.Rows[0]["id"].ToString()), 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }*/
                    result = 0;
                }
                else
                {
                    RecipeModel rem = new RecipeModel();
                    DataTable dtable = rem.findAdjustFinish(Convert.ToInt32(tisaneNum));
                    if (dtable.Rows.Count > 0)
                    {

                        result = rm.addRechecked(Convert.ToInt32(userNum), nowDate, barcode, "复核", tisaneNum, imgname, userName);
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
            catch (Exception e1) {
                Response.Write("{\"code\":\"1\",\"msg\":\"操作失败\"}");
            }
            
            
        }
        else if ("get".Equals(type))
        {
            String id = Request.QueryString["id"].ToString();

            RecipeModel rm = new RecipeModel();
            string warningid = rm.getRetentionWarning(2);
           

            RecheckedModel rdm = new RecheckedModel();
            DataTable dataTable = rdm.findRecheckedInfo(Convert.ToInt32(id), DateTime.Now.ToString("yyyy-MM-dd"));
            Response.Write("{\"code\":\"0\",\"msg\":\"操作成功\",\"data\":" + DataTableToJson.ToJson(dataTable) + ",\"warning\":\"" + warningid + "\"}");
        }
    

    }
}