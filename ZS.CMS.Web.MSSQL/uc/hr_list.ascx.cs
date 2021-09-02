using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ZS.KIT;

public partial class uc_hr_list : System.Web.UI.UserControl
{
    private int _channelID = 4;
    private int _categoryID = 0;
    private string _sortFiled = "isTop desc,PostTime desc,ID desc";
    private string _listRoute = "hr_category_list";
    private string _applyRoute = "hr_apply";
    private int _isApply = 0;

    /// <summary>
    /// 频道ID
    /// </summary>
    public int channelID
    {
        get { return _channelID; }
        set { _channelID = value; }
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
    public string applyRoute
    {
        get { return this._applyRoute; }
        set { this._applyRoute = value; }
    }

    /// <summary>
    /// 在线应聘
    /// </summary>
    public int isApply
    {
        get { return this._isApply; }
        set { this._isApply = value; }
    }

    /// <summary>
    /// 控件初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        this._categoryID = znConvert.ObjToInt(Page.RouteData.Values["categoryID"], 0) | znRequest.GetQueryInt("categoryID");

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
            if (rptHR.Items.Count == 0)
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
        ZS.BLL.znHR bll = new ZS.BLL.znHR();
        rptHR.DataSource = bll.GetList(this._categoryID, "and isCheck=1", this._sortFiled);
        rptHR.DataBind();
    }

    /// <summary>
    /// Url转跳
    /// </summary>
    protected void rptHR_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal ltItem = (Literal)e.Item.FindControl("ltItem");
            StringBuilder sb = new StringBuilder();

            int ID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "ID"));
            string categoryTitle = DataBinder.Eval(e.Item.DataItem, "CategoryTitle").ToString().Trim();
            string title = DataBinder.Eval(e.Item.DataItem, "Title").ToString().Trim();
            string limitNum = DataBinder.Eval(e.Item.DataItem, "LimitNum").ToString().Trim();
            string address = DataBinder.Eval(e.Item.DataItem, "Address").ToString().Trim();
            string salary = DataBinder.Eval(e.Item.DataItem, "Salary").ToString().Trim();
            string email = DataBinder.Eval(e.Item.DataItem, "Email").ToString().Trim();
            string infor = DataBinder.Eval(e.Item.DataItem, "Infor").ToString().Trim();
            string request = DataBinder.Eval(e.Item.DataItem, "Request").ToString().Trim();
            string startDate = DataBinder.Eval(e.Item.DataItem, "StartDate").ToString().Trim();
            string endDate = DataBinder.Eval(e.Item.DataItem, "EndDate").ToString().Trim();

            sb.Append("<div class=\"item\">");
            sb.Append("<h2><span>"+ categoryTitle + "</span>"+ title + "</h2><div class=\"clear\"></div>");
            if (this._isApply == 1) { sb.Append("<i class=\"apply\"><a href=\"" + Page.GetRouteUrl(this._applyRoute, new { id = ID }) + "\">投个简历</a></i>"); }
            sb.Append("<div class=\"tag\"><span>招聘人数：</span>"+ limitNum + "<span>工作地点：</span>"+ address + "<span>薪酬待遇：</span>"+ salary + "<br/><span>招聘周期：</span>"+ startDate + "~"+ endDate + "<span>简历投递邮箱：</span>"+ email + "</div>");
            sb.Append("<div class=\"text\">");
            sb.Append("<h3>职位描述</h3>");
            sb.Append("<p>"+ znUtils.ToHtml(infor) + "</p>");
            sb.Append("<h3>岗位要求</h3>");
            sb.Append("<p>"+ znUtils.ToHtml(request) + "</p>");
            sb.Append("</div>");
            sb.Append("</div>");

            ltItem.Text = sb.ToString();
        }
    }

}