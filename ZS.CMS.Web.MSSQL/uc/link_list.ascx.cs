using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ZS.KIT;

public partial class uc_link_list : System.Web.UI.UserControl
{
    private int _categoryID = 2;

    /// <summary>
    /// 类别ID
    /// </summary>
    public int categoryID
    {
        get { return _categoryID; }
        set { _categoryID = value; }
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
        string strSql = string.Format("CategoryID={0} and isCheck=1 order by SortID desc,ID desc", this._categoryID.ToString());
        ZS.BLL.znLink bll = new ZS.BLL.znLink();
        rptLink.DataSource = bll.GetList(strSql);
        rptLink.DataBind();
    }

    /// <summary>
    /// Url转跳
    /// </summary>
    protected void rptLink_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal ltItem = (Literal)e.Item.FindControl("ltItem");
            StringBuilder sb = new StringBuilder();

            int CID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "CategoryID"));
            string title = DataBinder.Eval(e.Item.DataItem, "Title").ToString().Trim();
            string linkUrl = DataBinder.Eval(e.Item.DataItem, "LinkUrl").ToString().Trim();
            string linkNote = DataBinder.Eval(e.Item.DataItem, "LinkNote").ToString().Trim();
            string logoUrl = DataBinder.Eval(e.Item.DataItem, "LogoUrl").ToString().Trim();
            if (CID == 1)
            {
                sb.Append("<dd>");
                sb.Append("<i class=\"i\"></i>");
                sb.Append("<a href =\"" + linkUrl + "\" title=\"" + linkNote + "" + title + "\">"+ title + "</a>");
                sb.Append("</dd>");
            }
            else
            {
                sb.Append("<dd class=\"img\">");
                sb.Append("<a href =\"" + linkUrl + "\" title=\"" + linkNote + "" + title + "\"><img src=\""+ logoUrl + "\"/></a>");
                sb.Append("</dd>");
            }

            ltItem.Text = sb.ToString();
        }
    }

}