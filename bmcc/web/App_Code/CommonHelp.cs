using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataBaseAccessLib;
using System.Text.RegularExpressions;

/// <summary>
///CommonHelp 的摘要说明
/// </summary>
public class CommonHelp
{
    public CommonHelp()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public string GetShortStr(string str)
    {
        #region 换行

        if (str.Length > 10)
        {
            string a = "";
            int b = 0;
            for (int i = 0; i < OConfig.StrLength(str); i++)
            {
                if ((str.Length - str.Length % 9) / 9 - b > 1)
                {
                    a += str.Substring(9 * b, 9) + "</br>";
                    i += 8;
                }
                else
                {
                    a += str.Substring(9 * b, str.Length - 9 * b);
                    break;
                }
                b += 1;
            }
            str = a;
        }

        #endregion

        return str;
    }
    /// <summary>
    /// 截取10个字符带
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string GetMinShortStr(string str, string chars)
    {
        if (str.Length > 10)
        {
            str = str.Substring(0, 9) + chars;
        }
        return str;
    }

    /// <summary>
    /// 项目或合同排序字段
    /// </summary>
    /// <param name="Str"></param>
    /// <returns></returns>
    public string GetOrderNumber(string Str)
    {
        string temp = "";
        if (!Str.Equals(""))
        {
            try
            {
                temp = Str.Replace("-","").Substring(2, 2);
                if (IsNumeric(temp))
                {
                    if (temp == "20")
                    {
                        temp = Str.Substring(2, 4);//SF20140201
                    }
                    else
                    {
                        temp = "20" + temp;//SF140201
                    }
                }
                else
                {
                    temp = Str.Substring(4, 2);
                    if (IsNumeric(temp))
                    {
                        if (temp == "20")
                        {
                            temp = Str.Substring(4, 4);//HTST20140201
                        }
                        else
                        {
                            temp = "20" + temp;//HTST140201
                        }
                    }
                    else
                    {
                        temp = "0";//SF
                    }
                }
            }
            catch (Exception)
            {
                temp = "0";
            }
        }
        return temp;
    }
    /// <summary>
    /// 判断是不是数字
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsNumeric(string value)
    {
        return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
    }
    public static bool IsInt(string value)
    {
        return Regex.IsMatch(value, @"^[+-]?\d*$");
    }
    public static bool IsUnsign(string value)
    {
        return Regex.IsMatch(value, @"^\d*[.]?\d*$");
    }

}