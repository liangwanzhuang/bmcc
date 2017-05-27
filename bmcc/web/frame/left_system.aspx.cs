using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using SQLDAL;
using System.Data;


public partial class left_search : System.Web.UI.Page
{
    /// <summary>
    /// 
    /// </summary>
    public string cid = "";

    /// <summary>
    /// 用户id 
    /// </summary>  
    public string currentUserID = "";

    /// <summary>
    /// 用户角色的操作类
    /// </summary>
 
    /// <summary>
    /// 页面加载
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        ////防脚本SQL注入
        //AvertInjection.OnLoadCheck();
        //if (Request.QueryString["cid"] != null)
        //{
        //    cid = Request.QueryString["cid"].ToString();
        //}
        //if (Session["currentUserID"] != null)
        //{
        //    currentUserID = Session["currentUserID"].ToString();
        //}
        //else 
        //{
        //    Response.Redirect("noRight.aspx");
        //}
        //if (!IsPostBack)
        //{
          
        //}
    }
    /// <summary>
    /// 数据绑定
    /// </summary>
   
}