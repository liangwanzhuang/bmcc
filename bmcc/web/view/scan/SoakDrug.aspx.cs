using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelInfo;
using System.Text;
using System.Data;
public partial class view_scan_SoakDrug : System.Web.UI.Page
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
                Bubbleinfo bl = new Bubbleinfo();
                DataTable dt = bl.findBubbleBybarcode(tisaneNum);
                int result = 0;
                string machine = "[]";
                string tisaneunit = "[]";
                int flag = 0;
                if (dt.Rows.Count > 0)
                {
                    if ("1".Equals(dt.Rows[0]["bubblestatus"].ToString()))
                    {
                        result = 0;
                    }else
                    {

                        
                        DataTable table = bl.findMachineByStartAndFree();
                        if (table.Rows.Count > 0)
                        {
                            machine = DataTableToJson.ToJson(table);
                            result = bl.updateBubble(Convert.ToInt32(dt.Rows[0]["id"].ToString()), 1, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), dt.Rows[0]["starttime"].ToString());
                        }
                        else
                        {
                            result = 0;
                            flag = 1;
                        }

                        DataTable tisaneunits = bl.findTisaneunitByPid(Convert.ToInt32(tisaneNum));
                        if (tisaneunits.Rows.Count > 0)
                        {
                            tisaneunit = DataTableToJson.ToJson(tisaneunits);

                        }
                    }
                    

                }
                else
                {
                    RecipeModel rem = new RecipeModel();
                    DataTable dtable = rem.findRecheckedFinish(Convert.ToInt32(tisaneNum));
                    if (dtable.Rows.Count > 0)
                    {
                        result = bl.addbubble(Convert.ToInt32(userNum), nowDate, barcode, "泡药", tisaneNum, imgname, waterYield,userName);
                    }
                    else
                    {
                        result = 0;
                    }
                    
                }

                if (result > 0)
                {
                    Response.Write("{\"code\":\"0\",\"msg\":\"操作成功\",\"machine\":" + machine + ",\"tisaneunit\":" + tisaneunit + ",\"flag\":\"" + flag + "\"}");

                }
                else
                {
                    Response.Write("{\"code\":\"1\",\"msg\":\"操作失败\",\"flag\":\"" + flag + "\"}");
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
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            Bubbleinfo bi = new Bubbleinfo();
            RecipeModel rm = new RecipeModel();
            string warningid = rm.getRetentionWarning(3);
            string timeout = bi.getTimeoutNumber(date);
            DataTable dataTable = bi.getBubbleInfo(Convert.ToInt32(id), date);

            Response.Write("{\"code\":\"0\",\"msg\":\"操作成功\",\"data\":" + DataTableToJson.ToJson(dataTable) + ",\"warning\":\"" + warningid + "\",\"timeout\":\"" + timeout + "\"}");
        }
        else if ("updateMachine".Equals(type))
        {
            Bubbleinfo bi = new Bubbleinfo();
            string tid = Request.Form["tid"];//分配机组记录id
            string machineid = Request.Form["machineid"];//煎药机id
            bi.updateTisaneunitByMachineid(Convert.ToInt32(tid), Convert.ToInt32(machineid));
            Response.Write("{\"code\":\"0\",\"msg\":\"操作成功\"}");
        }


    }
}