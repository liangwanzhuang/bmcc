#region ***************Copyright Description************
/**********************************************************
(C) Copyright 奇科计算机信息有限公司. 2009
FileName         : AvertInjection.cs
Function         : 防SQL注入类
Author           : 王涛
Last modified by : 王涛
Last modified    : 2009-8-21
************************************************************/
#endregion
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

    /// <summary>
    /// 防SQL注入类
    /// </summary>
public class AvertInjection
{
    /// <summary>
    /// 防SQL注入
    /// </summary>
    /// <param name="e"></param>
    public static void OnLoadCheck()
    {
        try
        {
            HttpCookie cookSearch;
            if (System.Web.HttpContext.Current.Request.Cookies["cookSearch"] != null)
            {
                cookSearch = System.Web.HttpContext.Current.Request.Cookies["cookSearch"];
                cookSearch.Expires = DateTime.Now.AddDays(-1);
                System.Web.HttpContext.Current.Response.Cookies.Add(cookSearch);
            }

            string getkeys = "";
            string sqlErrorPage = "noRight.aspx";
            //get方式验证
            if (System.Web.HttpContext.Current.Request.QueryString != null)
            {
                for (int i = 0; i < System.Web.HttpContext.Current.Request.QueryString.Count; i++)
                {
                    getkeys = System.Web.HttpContext.Current.Request.QueryString.Keys[i];
                    if (!ProcessSqlStr(System.Web.HttpContext.Current.Request.QueryString[getkeys], 0))
                    {
                        System.Web.HttpContext.Current.Response.Redirect(sqlErrorPage);
                        System.Web.HttpContext.Current.Response.End();
                    }
                }
            }
            //post方式验证
            if (System.Web.HttpContext.Current.Request.Form != null)
            {
                for (int i = 0; i < System.Web.HttpContext.Current.Request.Form.Count; i++)
                {
                    getkeys = System.Web.HttpContext.Current.Request.Form.Keys[i];
                    if (!ProcessSqlStr(System.Web.HttpContext.Current.Request.Form[getkeys], 1))
                    {
                        System.Web.HttpContext.Current.Response.Redirect(sqlErrorPage);
                        System.Web.HttpContext.Current.Response.End();
                    }
                }
            }
        }
        catch
        {

        }

    }

    /// <summary>
    /// 分析用户请求是否正常
    /// </summary>
    /// <param name="Str">传入用户提交数据</param>
    /// <returns>返回是否含有SQL注入式攻击代码</returns>
    private static bool ProcessSqlStr(string Str, int type)
    {
        string SqlStr;

        if (type == 1)
            SqlStr = "exec |insert |delete |update |count |chr |mid |master |truncate |char |declare ";
        else
            SqlStr = "'|and|exec|insert|delete|update|count|*|chr|mid|master|truncate|char|declare|%5c|`|%|^|(|)|+|?|[|]|{";

        bool ReturnValue = true;
        try
        {
            if (Str != "")
            {
                string[] anySqlStr = SqlStr.Split('|');
                foreach (string ss in anySqlStr)
                {
                    if (Str.IndexOf(ss) >= 0)
                    {
                        ReturnValue = false;
                    }
                }
            }
        }
        catch
        {
            ReturnValue = false;
        }
        return ReturnValue;
    }

}