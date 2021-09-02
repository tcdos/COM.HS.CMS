using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZS.KIT;

public partial class uc_page_list : System.Web.UI.UserControl
{
    private int _categoryID = 0;
    private string _route = string.Empty;

    /// <summary>
    /// 频道ID
    /// </summary>
    public int categoryID
    {
        get { return this._categoryID; }
        set { this._categoryID = value; }
    }

    /// <summary>
    /// 页面路由
    /// </summary>
    public string route
    {
        get { return this._route; }
        set { this._route = value; }
    }

    /// <summary>
    /// 控件初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillRepeater();
        }
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    protected void FillRepeater()
    {
        ZS.BLL.znPage bll = new ZS.BLL.znPage();
        rptPageList.DataSource = bll.GetList(this._categoryID, "and isCheck=1", "SortID desc,PostTime asc,ID asc");
        rptPageList.DataBind();
    }

    /// <summary>
    /// Url转跳
    /// </summary>
    protected void rptPageList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal ltUrl = (Literal)e.Item.FindControl("ltUrl");
            int id = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "ID").ToString());
            string title = DataBinder.Eval(e.Item.DataItem, "Title").ToString();
            int isUrl = znConvert.StrToInt(DataBinder.Eval(e.Item.DataItem, "isUrl").ToString(), 0);
            string linkUrl = DataBinder.Eval(e.Item.DataItem, "LinkUrl").ToString();
            if (isUrl == 1)
            {
                ltUrl.Text = "<a href=\"" + linkUrl + "\" title=\"" + title + "\" target=\"_blank\"><i class=\"i\"></i>" + title + "</a>";
            }
            else
            {
                ltUrl.Text = "<a href=\"" + GetRouteUrl(this._route, new { id = id }) + "\" title=\"" + title + "\"><i class=\"i\"></i>" + title + "</a>";
            }
        }
    }
}