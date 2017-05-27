using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Text;
using System.Data;
public partial class view_scan_Delivery : System.Web.UI.Page
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
                DeliveryHandler dh = new DeliveryHandler();
                RecipeModel rm = new RecipeModel();
                DataTable dtable = rm.findPackingFinish(Convert.ToInt32(tisaneNum));
                int result = 0;
                if (dtable.Rows.Count > 0)
                {
                    
                    DataTable dtables = rm.findDeliveryFinish(Convert.ToInt32(tisaneNum));
                    if (dtables.Rows.Count > 0)
                    {
                      //  result = dh.AddDelivery(Convert.ToInt32(userNum), nowDate, barcode, tisaneNum, imgname, userName);
                        result = dh.AddDelivery(Convert.ToInt32(userNum), nowDate, barcode, tisaneNum, imgname, userName);
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
            RecipeModel rm2 = new RecipeModel();

            string warningid = rm2.getRetentionWarning(6);
            DeliveryModel rm = new DeliveryModel();

            DataTable dataTable = rm.findDeliveryInfo(Convert.ToInt32(id), DateTime.Now.ToString("yyyy-MM-dd"));
            Response.Write("{\"code\":\"0\",\"msg\":\"操作成功\",\"data\":" + DataTableToJson.ToJson(dataTable) + ",\"warning\":\"" + warningid + "\"}");
        }
    }
}