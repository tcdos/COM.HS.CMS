using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZS.KIT;


public partial class uc_tree_list : System.Web.UI.UserControl
{
    private int _channelID = 2;
    private string _route = string.Empty;

    /// <summary>
    /// 频道ID
    /// </summary>
    public int channelID
    {
        get { return this._channelID; }
        set { this._channelID = value; }
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
        ZS.BLL.znCategory bll = new ZS.BLL.znCategory();
        rptCategory.DataSource = bll.GetList(0, this._channelID);
        rptCategory.DataBind();
    }

    /// <summary>
    /// TREE结构化&Url转跳
    /// </summary>
    protected void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            //TREE结构化
            int layer = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Layer").ToString());
            string span = "<span class=\"tree-space\" style=\"width:{0}px\"></span>{1}";
            string spanList = string.Empty;
            string icon = "<span class=\"tree-icon\"></span>";
            spanList = string.Format(span, (layer-1) * 18, icon);

            Literal ltLayer = (Literal)e.Item.FindControl("ltLayer");
            ltLayer.Text = layer.ToString();

            //Url转跳
            Literal ltUrl = (Literal)e.Item.FindControl("ltUrl");
            int id = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "ID").ToString());
            string title = DataBinder.Eval(e.Item.DataItem, "Title").ToString();
            int isUrl = znConvert.StrToInt(DataBinder.Eval(e.Item.DataItem, "isUrl").ToString(), 0);
            string linkUrl = DataBinder.Eval(e.Item.DataItem, "LinkUrl").ToString();
            if (isUrl == 1)
            {
                ltUrl.Text = "<li class=\"category layer" + layer + "\"><a href=\"" + linkUrl + "\" title=\"" + title + "\" target=\"_blank\" >" + spanList + title + "</a></li>";
            }
            else
            {
                ltUrl.Text = "<li class=\"category layer" + layer + "\"><a href=\"javascript:void(0)\" title=\"" + title + "\">" + spanList + title + "</a></li>";
            }

            //数据绑定
            Repeater rptList = (Repeater)e.Item.FindControl("rptList");
            string listSql = string.Format("isCheck=1 and CategoryID={0} order by isTop desc,SortID desc,PostTime desc,ID desc", id.ToString());
            switch (channelID)
            {
                case 1:
                    rptList.DataSource = new ZS.BLL.znArticle().GetList(listSql);
                    rptList.DataBind();
                    break;
                case 2:
                    rptList.DataSource = new ZS.BLL.znProduct().GetList(listSql);
                    rptList.DataBind();
                    break;
                default:
                    rptList.DataSource = new ZS.BLL.znProduct().GetList(listSql);
                    rptList.DataBind();
                    break;

            }
        }
    }

    /// <summary>
    /// TREE结构化&Url转跳
    /// </summary>
    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            //TREE结构化
            Literal ltLayer = (Literal)e.Item.FindControl("ltLayer");
            int layer = Convert.ToInt32(ltLayer.Text);
            string span = "<span class=\"tree-space\" style=\"width:{0}px\"></span>{1}";
            string spanList = string.Empty;
            string icon = "<span class=\"tree-icon\"></span>";
            spanList = string.Format(span, (layer-1) * 18, icon);

            //Url转跳
            Literal ltDetail = (Literal)e.Item.FindControl("ltDetail");
            int id = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "ID").ToString());
            string title = DataBinder.Eval(e.Item.DataItem, "Title").ToString();
            int isUrl = znConvert.StrToInt(DataBinder.Eval(e.Item.DataItem, "isUrl").ToString(), 0);
            string linkUrl = DataBinder.Eval(e.Item.DataItem, "LinkUrl").ToString();
            if (isUrl == 1)
            {
                ltDetail.Text = "<li class=\"list\"><a href=\"" + linkUrl + "\" title=\"" + title + "\" target=\"_blank\" >" + spanList + title + "</a></li>";
            }
            else
            {
                ltDetail.Text = "<li class=\"list\"><a href=\"" + Page.GetRouteUrl(this._route, new { id = id }) + "\" title=\"" + title + "\">" + spanList + title + "</a></li>";
            }
        }
    }
}