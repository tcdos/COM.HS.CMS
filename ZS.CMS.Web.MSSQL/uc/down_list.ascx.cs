﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ZS.KIT;

public partial class uc_down_list : System.Web.UI.UserControl
{
    private int _channelID = 3;
    private int _categoryID = 0;
    private int _pageSize = 10;
    private int _totalCount;
    private string _sortFiled = "isTop desc,SortID desc,PostTime desc,ID desc";
    private int _curPage;

    private string _listRoute = "download_category_list";
    private string _detailRoute = "downfile";

    /// <summary>
    /// 频道ID
    /// </summary>
    public int channelID
    {
        get { return _channelID; }
        set { _channelID = value; }
    }

    /// <summary>
    /// 分页基数
    /// </summary>
    public int pageSize
    {
        get { return this._pageSize; }
        set { this._pageSize = value; }
    }

    /// <summary>
    /// 页面路由
    /// </summary>
    public string listRoute
    {
        get { return this._listRoute; }
        set { this._listRoute = value; }
    }

    /// <summary>
    /// 页面路由
    /// </summary>
    public string detailRoute
    {
        get { return this._detailRoute; }
        set { this._detailRoute = value; }
    }

    /// <summary>
    /// 控件初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        this._categoryID = znConvert.ObjToInt(Page.RouteData.Values["categoryID"], 0) | znRequest.GetQueryInt("categoryID");
        this._curPage = znConvert.ObjToInt(Page.RouteData.Values["page"], 1) | znRequest.GetQueryInt("page");

        ZS.BLL.znCategory bll = new ZS.BLL.znCategory();
        int defaultCategoryID = bll.GetDefaultID(this._channelID, 1);
        if (this._categoryID == 0 && defaultCategoryID != 0)
        {
            this._categoryID = defaultCategoryID;
            Response.RedirectToRoute(this._listRoute, new { categoryID = this._categoryID });
        }
        if (!Page.IsPostBack)
        {
            FillRepeater();
            if (rptDownload.Items.Count == 0)
            {
                this.ltNull.Text = "<div class=\"uc-null\">暂无内容，请浏览其它内容。</div>";
            }
        }
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    protected void FillRepeater()
    {

        //数据读取
        ZS.BLL.znDownload bll = new ZS.BLL.znDownload();
        rptDownload.DataSource = bll.GetList(this._categoryID, this._pageSize, this._curPage, " and isCheck=1 ", this._sortFiled, out this._totalCount);
        rptDownload.DataBind();
        //数据分页
        string pageUrl = znUtils.CombUrls("/download/", "list/{0}&{1}", this._categoryID.ToString(), "znPage");
        htPageList.InnerHtml = znUtils.PageList(this._pageSize, this._curPage, this._totalCount, pageUrl, 6);

    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    protected void rptDownload_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal ltItem = (Literal)e.Item.FindControl("ltItem");

            StringBuilder sb = new StringBuilder();

            int ID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "ID"));
            string categoryTitle = DataBinder.Eval(e.Item.DataItem, "CategoryTitle").ToString().Trim();
            string title = DataBinder.Eval(e.Item.DataItem, "Title").ToString().Trim();
            string summary = DataBinder.Eval(e.Item.DataItem, "Summary").ToString().Trim();
            string smallPic = DataBinder.Eval(e.Item.DataItem, "SmallPic").ToString().Trim();
            DateTime postTime = DateTime.Parse(DataBinder.Eval(e.Item.DataItem, "PostTime").ToString().Trim());
            string fileUrl= DataBinder.Eval(e.Item.DataItem, "FileUrl").ToString().Trim();
            string fileSize = "未知大小";
            string fileExt = string.Empty;
            string fileExtName = "未知类型";
            if (fileUrl.IndexOf("$") > 0)
            {
                fileSize = fileUrl.Split('$')[1];
                fileExt= fileUrl.Split('$')[2];
            }

            if (znDict.FileExtList().ContainsKey(fileExt))
            {
                fileExtName = znDict.FileExtList()[fileExt];
            }

            sb.Append("<a href=\"" + Page.GetRouteUrl(this._detailRoute, new { id = ID }) + "\">");
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

            ltItem.Text = sb.ToString();
        }
    }
}