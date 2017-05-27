using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ModelInfo;
using System.Data.SqlClient;
using System.Data;
using SQLDAL;

public partial class view_reconciliation_Query : System.Web.UI.Page
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
            this.Pspnum.Value = Request.QueryString["Pspnum"];
            this.STime.Value = Request.QueryString["STime"];
            this.ETime.Value = Request.QueryString["ETime"];
            this.hospitalSelect1.Value = Request.QueryString["hospitalSelect"].ToString();
        }
       /* if (!Page.IsPostBack)
        {
            //给button1添加客户端事件
            Button1.Attributes.Add("OnClick", "return  btnok_onclick()");
            //jsFunction()是js函数
        }*/
      
        

    }
    //导出数据
    protected void Button1_Click(object sender, EventArgs e)
    {
        string[] arr = null;
        string strRowIDs = "";
        if (Request.QueryString["Pspnum"] != null || Request.QueryString["hospitalSelect"] != null || Request.QueryString["STime"] != null || Request.QueryString["ETime"] != null)
        {

            RecipeModel rm = new RecipeModel();
            string Pspnum = Request.QueryString["Pspnum"];
            string hospitalSelect = Request.QueryString["id"];
            string STime = Request.QueryString["STime"];
            string ETime = Request.QueryString["ETime"];
            string Pspnum1 = Request.QueryString["Pspnum"].ToString();
            string hospitalSelect1 = Request.QueryString["hospitalSelect"].ToString();
            string STime1 = Request.QueryString["STime"].ToString();
            string ETime1 = Request.QueryString["ETime"].ToString();

            DataTable sdr1 = rm.AccountStatementInfo(Pspnum, STime, ETime, Convert.ToInt32(hospitalSelect1));

            arr = new string[sdr1.Rows.Count];
            int a = sdr1.Rows.Count;
            for (var i = 0; i < sdr1.Rows.Count; i++)
            {

                arr[i] = sdr1.Rows[i]["id"].ToString();

                strRowIDs = arr[i].ToString();

            }

            int sdr = 0;
            string Clearing = Clearing1.Value;
            string ReconciliaT = ReconciliaT1.Value;
            string ReconciliaPer = ReconciliaPer1.Value;
            string Remarks = RemarksA.Value;
            //  string[] strRows1Id = strRowIDs.Split(',');
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
                for (int i = 0; i < arr.Length; i++)
                {
                    string Retime = sr["id"].ToString() + current;

                    ClearingpartyHandler ch = new ClearingpartyHandler();

                    sdr = ch.AddReconciliation1(Clearing, ReconciliaT, ReconciliaPer, Remarks, arr[i], n, Retime);

                }
            }



        //    Response.Write("<script type='text/javascript'>refurbishFlexGridRecipe();</script>");

            /*     DataTable dt = null;

                 ClearingpartyHandler ch2 = new ClearingpartyHandler();

                 dt = ch2.SearchInfoabc(arr);

                 CreateExcel(dt, "application/ms-excel", "excel");*/
        }
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
    public static String AddReconciliation(string Clearing, string ReconciliaT, string ReconciliaPer, string Remarks
        , string Pspnum, string hospitalSelect1, string STime, string ETime)
    {

       string[] arr = null;

        RecipeModel rm = new RecipeModel();
        DataTable sdr1 = rm.AccountStatementInfo(Pspnum, STime, ETime, Convert.ToInt32(hospitalSelect1));

        arr = new string[sdr1.Rows.Count];

        for (var i = 0; i < sdr1.Rows.Count; i++)
        {

            arr[i] = sdr1.Rows[i]["id"].ToString();

       

        }

        int sdr = 0;

        //  string[] strRows1Id = strRowIDs.Split(',');
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
            for (int i = 0; i < arr.Length; i++)
            {
                string Retime = sr["id"].ToString() + current;

                ClearingpartyHandler ch = new ClearingpartyHandler();

                sdr = ch.AddReconciliation1(Clearing, ReconciliaT, ReconciliaPer, Remarks, arr[i], n, Retime);

            }
        }

        return "";
    }
}
