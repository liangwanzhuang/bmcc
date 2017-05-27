using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Text;
using System.Data;
public partial class view_scan_tisane : System.Web.UI.Page
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
                string waterYield = Request.Form["waterYield"];//水量
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
                TeModel tm = new TeModel();
                Bubbleinfo bl = new Bubbleinfo();
                DataTable dt = tm.findTisaneinfoBybarcode(tisaneNum);
                int result = 0;
                string machine = "[]";
                string tisaneunit = "[]";
                string flag = "0";
                if (dt.Rows.Count > 0)
                {

                    if ("1".Equals(dt.Rows[0]["tisanestatus"].ToString()))
                    {
                        result = 0;
                    }
                    else
                    {
                        flag = "1";
                        result = tm.updateTisaneinfo(Convert.ToInt32(dt.Rows[0]["id"].ToString()), 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), tisaneNum, dt.Rows[0]["starttime"].ToString());
                    }


                }
                else
                {
                    RecipeModel rem = new RecipeModel();
                    DataTable dtable = rem.findBubbleFinish(Convert.ToInt32(tisaneNum));
                    if (dtable.Rows.Count > 0)
                    {
                        
                        DataTable table = bl.findMachineByStartAndFree();
                        if (table.Rows.Count > 0)
                        {
                            machine = DataTableToJson.ToJson(table);

                        }

                        DataTable tisaneunits = bl.findTisaneunitByPid(Convert.ToInt32(tisaneNum));
                        if (tisaneunits.Rows.Count > 0)
                        {
                            tisaneunit = DataTableToJson.ToJson(tisaneunits);

                        }
                        result = 1;
                       
                    }
                    else
                    {
                        result = 0;
                    }
                    
                }
                if (result > 0)
                {
                    Response.Write("{\"code\":\"0\",\"msg\":\"操作成功\",\"machine\":" + machine + ",\"tisaneunit\":" + tisaneunit + ",\"flag\":" + flag + "}");

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

            TeModel tm = new TeModel();

            RecipeModel rm = new RecipeModel();
            string warningid = rm.getRetentionWarning(4);

            DataTable dataTable = tm.getPreBytisaneid(Convert.ToInt32(id), DateTime.Now.ToString("yyyy-MM-dd"));
            Response.Write("{\"code\":\"0\",\"msg\":\"操作成功\",\"data\":" + DataTableToJson.ToJson(dataTable) + ",\"warning\":\"" + warningid + "\"}");
        }
        else if ("updateMachine".Equals(type))
        {
            string imgbase64 = Request.Form["imgbase64"];//图片
            string tisaneNum = Request.Form["tisaneNum"];//煎药单号
            string userNum = Request.Form["userNum"];//员工号
            string barcode = Request.Form["barcode"];//条形码
            string waterYield = Request.Form["waterYield"];//水量
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

            Bubbleinfo bi = new Bubbleinfo();
            string tid = Request.Form["tid"];//分配机组记录id
            string machineid = Request.Form["machineid"];//煎药机id
            bi.updateTisaneunitByMachineid(Convert.ToInt32(tid), Convert.ToInt32(machineid));
            TeModel tm = new TeModel();
            tm.addTisaneinfo(Convert.ToInt32(userNum), nowDate, barcode, "煎药", tisaneNum, imgname, waterYield, userName);
            Response.Write("{\"code\":\"0\",\"msg\":\"操作成功\"}");
        }
    }
}