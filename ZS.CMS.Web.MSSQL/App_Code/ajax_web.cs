using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;
using System.Text;
using ZS.KIT;


public class ajax_web : IHttpHandler, IRequiresSessionState
{

    /// <summary>
    /// 数据服务
    /// </summary>
    /// <param name="context"></param>
    public void ProcessRequest(HttpContext context)
    {
        string module = znRequest.GetQueryString("module");
        switch (module)
        {
            //资讯
            case "article":
                GetArticle(context);
                break;
            //产品
            case "product":
                GetProduct(context);
                break;
            //案例
            case "case":
                GetCase(context);
                break;
            //下载
            case "download":
                GetDownload(context);
                break;
        }
    }


    /// <summary>
    /// 资讯
    /// </summary>
    private void GetArticle(HttpContext context)
    {
        int _categoryID= znConvert.ObjToInt(znRequest.GetString("categoryID"), 0);
        int _curPage = znConvert.ObjToInt(znRequest.GetString("curPage"), 1);
        int _pageSize = znConvert.ObjToInt(znRequest.GetString("pageSize"), 1);
        string _route = znRequest.GetString("route");
        string _sortFiled = "isTop desc,SortID desc,PostTime desc,ID desc";
        int _totalCount = 0;
        string _pageFix = string.Empty;
        string _isEnd = "$$false";

        if (_curPage >= 1)
        {
            ZS.BLL.znArticle bll = new ZS.BLL.znArticle();
            DataTable dt = bll.GetPageList(_categoryID, _pageSize, _curPage, " and isCheck=1 ", _sortFiled, out _totalCount).Tables[0];
            if (dt.Rows.Count > 0 && (_pageSize * (_curPage - 1) + dt.Rows.Count) <= _totalCount)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    string title = dt.Rows[i]["Title"].ToString();
                    string summary = dt.Rows[i]["summary"].ToString();
                    DateTime postTime = DateTime.Parse(dt.Rows[i]["PostTime"].ToString());
                    if (i == 0) { _pageFix = "page" + _curPage; } else { _pageFix = string.Empty; }//页面滚动标示
                    sb.Append("<a class=\"" + _pageFix + "\" href=\"" + new Page().GetRouteUrl(_route, new { id = ID }) + "\">");
                    sb.Append("<dl class=\"item clearfix\">");
                    sb.Append("<dt><span class=\"month\">" + postTime.ToString("yyyy-MM") + "</span><span class=\"date\">" + postTime.ToString("dd") + "</span></dt>");
                    sb.Append("<dd class=\"title\">" + title + "</dd>");
                    sb.Append("<dd class=\"summary\">" + znUtils.GetSubStr(summary, 180) + "</dd>");
                    sb.Append("</dl>");
                    sb.Append("</a>");
                }
                if ((_pageSize * (_curPage - 1) + dt.Rows.Count) >= _totalCount) { _isEnd = "$$false"; } else { _isEnd = "$$true"; }
                context.Response.Write(sb.ToString()+ _isEnd);
            }
            else
            {
                context.Response.Write(_isEnd);
            }
        }
        else
        {
            //请求非Page
            context.Response.Write("<span class='err'>数据查询有误，请勿随意提交数据</span>"+ _isEnd);
        }
        return;
    }

    /// <summary>
    /// 产品
    /// </summary>
    private void GetProduct(HttpContext context)
    {
        int _categoryID = znConvert.ObjToInt(znRequest.GetString("categoryID"), 0);
        int _curPage = znConvert.ObjToInt(znRequest.GetString("curPage"), 1);
        int _pageSize = znConvert.ObjToInt(znRequest.GetString("pageSize"), 1);
        string _route = znRequest.GetString("route");
        string _sortFiled = "isTop desc,SortID desc,PostTime desc,ID desc";
        int _totalCount = 0;
        string _pageFix = string.Empty;
        string _isEnd = "$$false";

        if (_curPage >= 1)
        {
            ZS.BLL.znProduct bll = new ZS.BLL.znProduct();
            DataTable dt = bll.GetPageList(_categoryID, _pageSize, _curPage, " and isCheck=1 ", _sortFiled, out _totalCount).Tables[0];
            if (dt.Rows.Count > 0 && (_pageSize * (_curPage - 1) + dt.Rows.Count) <= _totalCount)
            {
                StringBuilder sb = new StringBuilder();
                
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    int ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    string title = dt.Rows[i]["Title"].ToString();
                    string categoryTitle = dt.Rows[i]["CategoryTitle"].ToString();
                    string summary = dt.Rows[i]["Summary"].ToString();
                    string smallPic = string.IsNullOrEmpty(dt.Rows[i]["SmallPic"].ToString()) ? dt.Rows[i]["SmallPic"].ToString() : "/images/noimg.jpg";

                    if (i == 0) { _pageFix = "page" + _curPage; } else { _pageFix = string.Empty; }//页面滚动标示
                    sb.Append("<a class=\"" + _pageFix + "\" href=\"" + new Page().GetRouteUrl(_route, new { id = ID }) + "\" title=\"" + summary + "\">");
                    sb.Append("<li>");
                    sb.Append("<div class=\"img\"><img src=\"" + smallPic + "\" alt=\"" + title + "\"></div>");
                    sb.Append("<h2 class=\"title\">" + title + "</h2>");
                    sb.Append("<p class=\"model\">" + categoryTitle + "</p>");
                    sb.Append("</li>");

                    sb.Append("</a>");

                }
                if ((_pageSize * (_curPage - 1) + dt.Rows.Count) >= _totalCount) { _isEnd = "$$false"; } else { _isEnd = "$$true"; }
                context.Response.Write(sb.ToString() + _isEnd);
            }
            else
            {
                context.Response.Write(_isEnd);
            }
        }
        else
        {
            //请求非Page
            context.Response.Write("<span class='err'>数据查询有误，请勿随意提交数据</span>" + _isEnd);
        }
        return;
    }

    /// <summary>
    /// 案例
    /// </summary>
    private void GetCase(HttpContext context)
    {
        int _categoryID = znConvert.ObjToInt(znRequest.GetString("categoryID"), 0);
        int _curPage = znConvert.ObjToInt(znRequest.GetString("curPage"), 1);
        int _pageSize = znConvert.ObjToInt(znRequest.GetString("pageSize"), 1);
        string _route = znRequest.GetString("route");
        string _sortFiled = "isTop desc,SortID desc,PostTime desc,ID desc";
        int _totalCount = 0;
        string _pageFix = string.Empty;
        string _isEnd = "$$false";

        if (_curPage >= 1)
        {
            ZS.BLL.znCase bll = new ZS.BLL.znCase();
            DataTable dt = bll.GetPageList(_categoryID, _pageSize, _curPage, " and isCheck=1 ", _sortFiled, out _totalCount).Tables[0];
            if (dt.Rows.Count > 0 && (_pageSize * (_curPage - 1) + dt.Rows.Count) <= _totalCount)
            {
                StringBuilder sb = new StringBuilder();

                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    int ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    string title = dt.Rows[i]["Title"].ToString();
                    string categoryTitle = dt.Rows[i]["CategoryTitle"].ToString();
                    string summary = dt.Rows[i]["Summary"].ToString();
                    string smallPic = dt.Rows[i]["SmallPic"].ToString();
                    DateTime postTime = DateTime.Parse(dt.Rows[i]["PostTime"].ToString());

                    if (i == 0) { _pageFix = "page" + _curPage; } else { _pageFix = string.Empty; }//页面滚动标示
                    sb.Append("<a class=\"" + _pageFix + "\" href=\"" + new Page().GetRouteUrl(_route, new { id = ID }) + "\">");

                    sb.Append("<div class=\"item\">");
                    if (!string.IsNullOrEmpty(smallPic))
                    {
                        sb.Append("<p class=\"smallPic\"><img src=\"" + smallPic + "\" /></p>");
                    }
                    sb.Append("<h2 class=\"title\">" + title + "</h2>");
                    sb.Append("<p class=\"summary\">" + znUtils.GetSubStr(summary, 180) + "</p>");
                    sb.Append("<p class=\"property\"><span class=\"time\" >发布时间：" + postTime.ToString("yyyy-MM-dd") + "</span></p>");
                    sb.Append("</div>");

                    sb.Append("</a>");

                }
                if ((_pageSize * (_curPage - 1) + dt.Rows.Count) >= _totalCount) { _isEnd = "$$false"; } else { _isEnd = "$$true"; }
                context.Response.Write(sb.ToString() + _isEnd);
            }
            else
            {
                context.Response.Write(_isEnd);
            }
        }
        else
        {
            //请求非Page
            context.Response.Write("<span class='err'>数据查询有误，请勿随意提交数据</span>" + _isEnd);
        }
        return;
    }

    /// <summary>
    /// 下载
    /// </summary>
    private void GetDownload(HttpContext context)
    {
        int _categoryID = znConvert.ObjToInt(znRequest.GetString("categoryID"), 0);
        int _curPage = znConvert.ObjToInt(znRequest.GetString("curPage"), 1);
        int _pageSize = znConvert.ObjToInt(znRequest.GetString("pageSize"), 1);
        string _route = znRequest.GetString("route");
        string _sortFiled = "isTop desc,SortID desc,PostTime desc,ID desc";
        int _totalCount = 0;
        string _pageFix = string.Empty;
        string _isEnd = "$$false";

        if (_curPage >= 1)
        {
            ZS.BLL.znDownload bll = new ZS.BLL.znDownload();
            DataTable dt = bll.GetPageList(_categoryID, _pageSize, _curPage, " and isCheck=1 ", _sortFiled, out _totalCount).Tables[0];
            if (dt.Rows.Count > 0 && (_pageSize * (_curPage - 1) + dt.Rows.Count) <= _totalCount)
            {
                StringBuilder sb = new StringBuilder();

                for (var i = 0; i < dt.Rows.Count; i++)
                {

                    int ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    string title = dt.Rows[i]["Title"].ToString();
                    string categoryTitle = dt.Rows[i]["CategoryTitle"].ToString();
                    string summary = dt.Rows[i]["Summary"].ToString();
                    string smallPic = dt.Rows[i]["SmallPic"].ToString();
                    DateTime postTime = DateTime.Parse(dt.Rows[i]["PostTime"].ToString());
                    string fileUrl = dt.Rows[i]["FileUrl"].ToString().Trim();
                    string fileSize = "未知大小";
                    string fileExt = string.Empty;
                    string fileExtName = "未知类型";
                    if (fileUrl.IndexOf("$") > 0)
                    {
                        fileSize = fileUrl.Split('$')[1];
                        fileExt = fileUrl.Split('$')[2];
                    }

                    if (znDict.FileExtList().ContainsKey(fileExt))
                    {
                        fileExtName = znDict.FileExtList()[fileExt];
                    }

                    if (i == 0) { _pageFix = "page" + _curPage; } else { _pageFix = string.Empty; }//页面滚动标示
                    sb.Append("<a class=\"" + _pageFix + "\" href=\"" + new Page().GetRouteUrl(_route, new { id = ID }) + "\">");

                    sb.Append("<div class=\"item\">");
                    if (!string.IsNullOrEmpty(smallPic))
                    {
                        sb.Append("<p class=\"smallPic\"><img src=\"" + smallPic + "\" /></p>");
                    }
                    sb.Append("<h2 class=\"title\">" + title + "</h2>");
                    sb.Append("<p class=\"summary\">" + summary + "</p>");
                    sb.Append("<p class=\"property\"><span class=\"size\" >文件大小：" + fileSize + "</span><span class=\"ext\" >文件类型：" + fileExtName + "</span><span class=\"time\" >更新时间：" + postTime.ToString("yyyy-MM-dd") + "</span></p>");
                    sb.Append("</div>");

                    sb.Append("</a>");

                }
                if ((_pageSize * (_curPage - 1) + dt.Rows.Count) >= _totalCount) { _isEnd = "$$false"; } else { _isEnd = "$$true"; }
                context.Response.Write(sb.ToString() + _isEnd);
            }
            else
            {
                context.Response.Write(_isEnd);
            }
        }
        else
        {
            //请求非Page
            context.Response.Write("<span class='err'>数据查询有误，请勿随意提交数据</span>" + _isEnd);
        }
        return;
    }

    /// <summary>
    /// 线程控制
    /// </summary>
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}