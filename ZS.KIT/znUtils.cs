using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web;

namespace ZS.KIT
{
    public class znUtils
    {
        /// <summary>
        /// 系统提示[Alert]
        /// </summary>
        public static void Alert(string msg, string url)
        {
            string _msg = msg.Trim();
            string _url = url.Trim();
            if (_url == "" && _url == null)
            {
                HttpContext.Current.Response.Write("<script language=javascript>alert('" + _msg + "');history.go(-1)</script>");
            }
            else
            {
                HttpContext.Current.Response.Write("<script language=javascript>alert('" + _msg + "');location='" + _url + "';</script>");
            }
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 系统提示[Tips]
        /// </summary>
        public static void Tips(System.Web.UI.Page page, string msgtitle, string url)
        {
            string msbox = "parent.zsTips(\"" + msgtitle + "\", \"" + url + "\")";
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "zsTips", msbox, true);
        }
        
        /// <summary>
        /// 系统提示[Tips]
        /// </summary>
        public static void Tips(System.Web.UI.Page page, string msgtitle, string url, string callback)
        {
            string msbox = "parent.zsTips(\"" + msgtitle + "\", \"" + url + "\", " + callback + ")";
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "zsTips", msbox, true);
        }

        /// <summary>
        /// 系统转跳
        /// </summary>
        public static void Redirect(string msg)
        {
            HttpContext.Current.Response.Redirect("../error.aspx?msg=" + msg);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 检测数值类型
        /// </summary>
        public static bool IsNumeric(object expression)
        {
            if (expression != null)
                return IsNumeric(expression.ToString());
            return false;
        }

        /// <summary>
        /// 检测数值类型
        /// </summary>
        public static bool IsNumeric(string expression)
        {
            if (expression != null)
            {
                string str = expression;
                if (str.Length > 0 && str.Length <= 11 && Regex.IsMatch(str, @"^[-]?[0-9]*[.]?[0-9]*$"))
                {
                    if ((str.Length < 10) || (str.Length == 10 && str[0] == '1') || (str.Length == 11 && str[0] == '-' && str[1] == '1'))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 检测IP类型
        /// </summary>
        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// 检测Url
        /// </summary>
        public static bool IsUrl(string strUrl)
        {
            return Regex.IsMatch(strUrl, @"^(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*$");
        }

        /// <summary>
        /// 生成指定长度的字符串,即生成n个str字符串
        /// </summary>
        public static string StringOfChar(string str, int n)
        {
            string returnStr = "";
            for (int i = 0; i < n; i++)
            {
                returnStr += str;
            }
            return returnStr;
        }

        /// <summary>
        /// 生成随机数字
        /// </summary>
        public static string GetRamNum(int Length)
        {
            return GetRamNum(Length, true);
        }

        /// <summary>
        /// 生成随机数字
        /// </summary>
        public static string GetRamNum(int Length, bool Sleep)
        {
            if (Sleep)
                System.Threading.Thread.Sleep(3);
            string result = "";
            System.Random random = new Random();
            for (int i = 0; i < Length; i++)
            {
                result += random.Next(10).ToString();
            }
            return result;
        }

        /// <summary>
        /// 生成随机字母字符串(数字字母混和)
        /// </summary>
        public static string GetRamStr(int codeCount)
        {
            string str = string.Empty;
            int rep = 0;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < codeCount; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }

        /// <summary>
        /// 清除HTML标记
        /// </summary>
        public static string FilterHtml(string Htmlstring)
        {
            if (string.IsNullOrEmpty(Htmlstring)) return "";
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }

        /// <summary>
        /// 清除HTML标记且返回相应的长度
        /// </summary>
        public static string FilterHtml(string Htmlstring, int length)
        {
            return GetSubStr(FilterHtml(Htmlstring), length);
        }

        /// <summary>
        /// 截取字符长度
        /// </summary>
        public static string GetSubStr(string str, int length)
        {
            if (string.IsNullOrEmpty(str))
                return "";
            string istr = str.Trim();
            int i = 0, n = 0;
            foreach (char chr in istr)
            {
                if ((int)chr > 127)
                {
                    i += 2;
                }
                else
                {
                    i++;
                }
                if (i > length)
                {
                    istr = istr.Substring(0, n) + "...";
                    break;
                }
                n++;
            }
            return istr;
        }

        /// <summary>
        /// TXT代码转换成HTML格式
        /// </summary>
        public static String ToHtml(string txt)
        {
            StringBuilder sb = new StringBuilder(txt);
            sb.Replace("&", "&amp;");
            sb.Replace("<", "&lt;");
            sb.Replace(">", "&gt;");
            sb.Replace("\r\n", "<br />");
            sb.Replace("\n", "<br />");
            sb.Replace("\t", " ");
            return sb.ToString();
        }

        /// <summary>
        /// HTML代码转换成TXT格式
        /// </summary>
        public static String ToTxt(String html)
        {
            StringBuilder sb = new StringBuilder(html);
            sb.Replace("&nbsp;", " ");
            sb.Replace("<br>", "\r\n");
            sb.Replace("<br>", "\n");
            sb.Replace("<br />", "\n");
            sb.Replace("<br />", "\r\n");
            sb.Replace("&lt;", "<");
            sb.Replace("&gt;", ">");
            sb.Replace("&amp;", "&");
            return sb.ToString();
        }

        /// <summary>
        /// 过滤特殊字符
        /// </summary>
        public static string FilterStr(string str)
        {
            if (str != string.Empty && str != null)
            {
                string outStr = str.ToLower();
                outStr = outStr.Replace("<script", "&lt;script");
                outStr = outStr.Replace("script>", "script&gt;");
                outStr = outStr.Replace("<%", "&lt;%");
                outStr = outStr.Replace("%>", "%&gt;");
                outStr = outStr.Replace("<$", "&lt;$");
                outStr = outStr.Replace("$>", "$&gt;");
                return outStr;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 替换指定的字符串
        /// </summary>
        public static string ReplaceStr(string originalStr, string oldStr, string newStr)
        {
            if (string.IsNullOrEmpty(oldStr))
            {
                return "";
            }
            return originalStr.Replace(oldStr, newStr);
        }

        /// <summary>
        /// 删除最后结尾的指定字符后的字符
        /// </summary>
        public static string DelLastChar(string str, string strchar)
        {
            if (string.IsNullOrEmpty(str))
                return "";
            if (str.LastIndexOf(strchar) >= 0 && str.LastIndexOf(strchar) == str.Length - 1)
            {
                return str.Substring(0, str.LastIndexOf(strchar));
            }
            return str;
        }

        /// <summary>
        /// 组合URL参数
        /// </summary>
        public static string CombUrl(string url, string keys, params string[] values)
        {
            StringBuilder urlParams = new StringBuilder();
            try
            {
                string[] keyArr = keys.Split(new char[] { '&' });
                for (int i = 0; i < keyArr.Length; i++)
                {
                    if (!string.IsNullOrEmpty(values[i]) && values[i] != "0")
                    {
                        values[i] = UrlEncode(values[i]);
                        urlParams.Append(string.Format(keyArr[i], values) + "&");
                    }
                }
                if (!string.IsNullOrEmpty(urlParams.ToString()) && url.IndexOf("?") == -1)
                    urlParams.Insert(0, "?");
            }
            catch
            {
                return url;
            }
            return url + DelLastChar(urlParams.ToString(), "&");
        }

        /// <summary>
        /// 组合URL参数
        /// </summary>
        /// <param name="url">页面地址</param>
        /// <param name="keys">参数名称</param>
        /// <param name="values">参数值</param>
        /// <returns>String</returns>
        public static string CombUrls(string url, string keys, params string[] values)
        {
            StringBuilder urlParams = new StringBuilder();
            try
            {
                string[] keyArr = keys.Split(new char[] { '&' });
                for (int i = 0; i < keyArr.Length; i++)
                {
                    if (!string.IsNullOrEmpty(values[i]) && values[i] != "0")
                    {
                        values[i] = UrlEncode(values[i]);
                        urlParams.Append(string.Format(keyArr[i], values) + "/");
                    }
                }
            }
            catch
            {
                return url;
            }
            return url + DelLastChar(urlParams.ToString(), "/");
        }

        /// <summary>
        /// URL字符编码
        /// </summary>
        public static string UrlEncode(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            str = str.Replace("'", "");
            return HttpContext.Current.Server.UrlEncode(str);
        }

        /// <summary>
        /// URL字符解码
        /// </summary>
        public static string UrlDecode(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            return HttpContext.Current.Server.UrlDecode(str);
        }

        /// <summary>
        /// 格式化输出分页列表
        /// </summary>
        public static string PageList(int pageSize, int pageIndex, int totalCount, string linkUrl, int centerSize)
        {
            if (totalCount < 1 || pageSize < 1)
            {
                return "";
            }
            int pageCount = totalCount / pageSize;
            if (pageCount < 1)
            {
                return "";
            }
            if (totalCount % pageSize > 0)
            {
                pageCount += 1;
            }
            if (pageCount <= 1)
            {
                return "";
            }
            StringBuilder pageListStr = new StringBuilder();
            string pageTag = "znPage";
            string totalNum = "<span>共 " + totalCount + " 条记录</span>";
            string firstBtn = "<a href=\"" + znUtils.ReplaceStr(linkUrl, pageTag, (pageIndex - 1).ToString()) + "\">上一页</a>";
            string lastBtn = "<a href=\"" + znUtils.ReplaceStr(linkUrl, pageTag, (pageIndex + 1).ToString()) + "\">下一页</a>";
            string firstStr = "<a href=\"" + znUtils.ReplaceStr(linkUrl, pageTag, "1") + "\">1</a>";
            string lastStr = "<a href=\"" + znUtils.ReplaceStr(linkUrl, pageTag, pageCount.ToString()) + "\">" + pageCount.ToString() + "</a>";

            if (pageIndex <= 1)
            {
                firstBtn = "<span class=\"disabled\">上一页</span>";
            }
            if (pageIndex >= pageCount)
            {
                lastBtn = "<span class=\"disabled\">下一页</span>";
            }
            if (pageIndex == 1)
            {
                firstStr = "<span class=\"cur\">1</span>";
            }
            if (pageIndex == pageCount)
            {
                lastStr = "<span class=\"cur\">" + pageCount.ToString() + "</span>";
            }

            int firstNum = pageIndex - (centerSize / 2);
            if (pageIndex < centerSize)
            {
                firstNum = 2;
            }
            int lastNum = pageIndex + centerSize - ((centerSize / 2) + 1);
            if (lastNum >= pageCount)
            {
                lastNum = pageCount - 1;
            }
            pageListStr.Append(totalNum + firstBtn + firstStr);
            if (pageIndex >= centerSize)
            {
                pageListStr.Append("<span>...</span>");
            }
            for (int i = firstNum; i <= lastNum; i++)
            {
                if (i == pageIndex)
                {
                    pageListStr.Append("<span class=\"cur\">" + i + "</span>");
                }
                else
                {
                    pageListStr.Append("<a href=\"" + znUtils.ReplaceStr(linkUrl, pageTag, i.ToString()) + "\">" + i + "</a>");
                }
            }
            if (pageCount - pageIndex > centerSize - ((centerSize / 2)))
            {
                pageListStr.Append("<span>...</span>");
            }
            pageListStr.Append(lastStr + lastBtn);
            return pageListStr.ToString();
        }

        /// <summary>
        /// 格式化输出分页列表
        /// </summary>
        public static string PageListforMobile(int pageSize, int pageIndex, int totalCount, string linkUrl, int centerSize)
        {
            if (totalCount < 1 || pageSize < 1)
            {
                return "";
            }
            int pageCount = totalCount / pageSize;
            if (pageCount < 1)
            {
                return "";
            }
            if (totalCount % pageSize > 0)
            {
                pageCount += 1;
            }
            if (pageCount <= 1)
            {
                return "";
            }
            StringBuilder pageListStr = new StringBuilder();
            string pageTag = "znPage";
            string firstStr = "<a href=\"" + znUtils.ReplaceStr(linkUrl, pageTag, "1") + "\">1</a>";
            string lastStr = "<a href=\"" + znUtils.ReplaceStr(linkUrl, pageTag, pageCount.ToString()) + "\">" + pageCount.ToString() + "</a>";

            if (pageIndex == 1)
            {
                firstStr = "<span class=\"cur\">1</span>";
            }
            if (pageIndex == pageCount)
            {
                lastStr = "<span class=\"cur\">" + pageCount.ToString() + "</span>";
            }

            int firstNum = pageIndex - (centerSize / 2);
            if (pageIndex < centerSize)
            {
                firstNum = 2;
            }
            int lastNum = pageIndex + centerSize - ((centerSize / 2) + 1);
            if (lastNum >= pageCount)
            {
                lastNum = pageCount - 1;
            }
            pageListStr.Append(firstStr);
            if (pageIndex >= centerSize)
            {
                pageListStr.Append("<span>...</span>");
            }
            for (int i = firstNum; i <= lastNum; i++)
            {
                if (i == pageIndex)
                {
                    pageListStr.Append("<span class=\"cur\">" + i + "</span>");
                }
                else
                {
                    pageListStr.Append("<a href=\"" + znUtils.ReplaceStr(linkUrl, pageTag, i.ToString()) + "\">" + i + "</a>");
                }
            }
            if (pageCount - pageIndex > centerSize - ((centerSize / 2)))
            {
                pageListStr.Append("<span>...</span>");
            }
            pageListStr.Append(lastStr);
            return pageListStr.ToString();
        }

        /// <summary>
        /// 获得配置文件节点XML文件的绝对路径
        /// </summary>
        public static string GetXmlMapPath(string xmlName)
        {
            return znFile.GetMapPath(ConfigurationManager.AppSettings[xmlName].ToString());
        }

        /// <summary>
        /// 获取Html字符串中指定标签的指定属性的值 
        /// </summary>
        public static List<string> GetHtmlAttr(string html, string tag, string attr)
        {
            Regex re = new Regex(@"(<" + tag + @"[\w\W].+?>)");
            MatchCollection imgreg = re.Matches(html);
            List<string> m_Attributes = new List<string>();
            Regex attrReg = new Regex(@"([a-zA-Z1-9_-]+)\s*=\s*(\x27|\x22)([^\x27\x22]*)(\x27|\x22)", RegexOptions.IgnoreCase);
            for (int i = 0; i < imgreg.Count; i++)
            {
                MatchCollection matchs = attrReg.Matches(imgreg[i].ToString());
                for (int j = 0; j < matchs.Count; j++)
                {
                    GroupCollection groups = matchs[j].Groups;
                    if (attr.ToUpper() == groups[1].Value.ToUpper())
                    {
                        m_Attributes.Add(groups[3].Value);
                        break;
                    }
                }
            }
            return m_Attributes;
        }

        

        /// <summary>
        /// 写cookie值
        /// </summary>
        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = UrlEncode(strValue);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        public static void WriteCookie(string strName, string key, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = UrlEncode(strValue);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        public static void WriteCookie(string strName, string key, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = UrlEncode(strValue);
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = UrlEncode(strValue);
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        public static string GetCookie(string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
                return UrlDecode(HttpContext.Current.Request.Cookies[strName].Value.ToString());
            return "";
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        public static string GetCookie(string strName, string key)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null && HttpContext.Current.Request.Cookies[strName][key] != null)
                return UrlDecode(HttpContext.Current.Request.Cookies[strName][key].ToString());

            return "";
        }

        

    }
}
