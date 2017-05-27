using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;
using System.Data;
using System.Data.SqlClient;
using SQLDAL;

public partial class view_reconciliation_Selected : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            ClearingpartyModel hm = new ClearingpartyModel();
            SqlDataReader sdr = hm.findClearingpartyAll();

            if (sdr != null)
            {
                while (sdr.Read())
                {
                    this.Clearing1.Items.Add(new ListItem(sdr["ClearPName"].ToString()));

                }
            }
           
            if (Request.QueryString["id"] != null)
            {

                string id = Request.QueryString["id"];

                this.strRowIds.Value = Request.QueryString["id"].ToString();

            }
        }
        /*
        if (!Page.IsPostBack)
        {
            //给button1添加客户端事件
            Button1.Attributes.Add("OnClick", "return  btnok_onclick()");
            //jsFunction()是js函数
        }*/

    }
        

        //导出数据
         protected void Button1_Click(object sender, EventArgs e)
          {
              string strRowIds = "";
              if (Request.QueryString["id"] != null)
              {

                  string id = Request.QueryString["id"];

                  strRowIds = Request.QueryString["id"].ToString();

              }
             
              int sdr = 0;
             string Clearing=Clearing1.Value;
             string ReconciliaT=ReconciliaT1.Value;
             string ReconciliaPer=ReconciliaPer1.Value;
             string Remarks=RemarksA.Value;
              string[] strRows1Id = strRowIds.Split(',');
             DataBaseLayer db = new DataBaseLayer();
              // now：生成对账单时间
            System.DateTime now = new System.DateTime();
            now = System.DateTime.Now;
            string n = now.ToString();
            // ReconciliaT:对账时间 
            string current = now.ToString("yyyyMMddhhmmss");
            string str = "select id from Clearingparty where   ClearPName = '" + Clearing + "'";
            SqlDataReader sr = db.get_Reader(str);
            if (sr.Read())
            {

                string Retime = sr["id"].ToString() + current;
                ClearingpartyHandler ch = new ClearingpartyHandler();
                for (int i = 0; i < strRows1Id.Length; i++)
                {
                    sdr = ch.AddReconciliation(Clearing, ReconciliaT, ReconciliaPer, Remarks, strRows1Id[i],n,Retime);

                }
            }

           
 
              /*   DataTable dt = null;
            
                ClearingpartyHandler ch2 = new ClearingpartyHandler();

                dt = ch2.SearchInfo(strRowIds);

                CreateExcel(dt, "application/ms-excel", "excel");*/

              //Response.Write("<script language='javascript'>closeDiv();</script>"); 
          }
          public void CreateExcel(DataTable dt, string FileType, string FileName)
          {
              Response.Clear();
              Response.Charset = "UTF-8";
              Response.Buffer = true;
              Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
              Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls\"");
              Response.ContentType = FileType;
              string colHeaders = string.Empty;
              //string ls_item = string.Empty;

              string ls_item = "序号\t 结算方 \t对账单号\t对账人\t对账时间 \t生成对账单时间\t对账单状态\t备注\t下单时间\t医院名称\t处方号\t煎药方式\t患者姓名\t药品数量\t剂量\t次数\t包装量   \n  ";

              DataRow[] myRow = dt.Select();
              int i = 0;
              int cl = dt.Columns.Count;
              foreach (DataRow row in myRow)
              {
                  for (i = 0; i < cl; i++)
                  {
                      if (i == (cl - 1))
                      {
                          ls_item += row[i].ToString() + "\n";
                      }
                      else
                      {
                          ls_item += row[i].ToString() + "\t";
                      }
                  }
                  Response.Output.Write(ls_item);
                  ls_item = string.Empty;
              }
              Response.Output.Flush();
              Response.End();
          }


          [WebMethod]
          public static String AddReconciliation(string strRowIds, string Clearing, string ReconciliaT, string ReconciliaPer, string Remarks)
          {

              int sdr = 0;
              string[] strRows1Id = strRowIds.Split(',');
              DataBaseLayer db = new DataBaseLayer();
              // now：生成对账单时间
              System.DateTime now = new System.DateTime();
              now = System.DateTime.Now;
              string n = now.ToString();
              // ReconciliaT:对账时间 
              string current = now.ToString("yyyyMMddhhmmss");
              string str = "select id from Clearingparty where   ClearPName = '" + Clearing + "'";
              SqlDataReader sr = db.get_Reader(str);
              if (sr.Read())
              {

                  string Retime = sr["id"].ToString() + current;
                  ClearingpartyHandler ch = new ClearingpartyHandler();
                  for (int i = 0; i < strRows1Id.Length; i++)
                  {
                      sdr = ch.AddReconciliation(Clearing, ReconciliaT, ReconciliaPer, Remarks, strRows1Id[i], n, Retime);

                  }
              }

              return "";
          }

    }

