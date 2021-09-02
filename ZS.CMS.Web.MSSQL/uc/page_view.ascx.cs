using System;
using System.Web.UI;
using ZS.KIT;

public partial class uc_page_view : System.Web.UI.UserControl
{
    private int _id = 0;
    private int _categoryID = 0;
    private string _route = string.Empty;

    /// <summary>
    /// 类别
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
        this._id = znConvert.ObjToInt(Page.RouteData.Values["id"], 0) | znRequest.GetQueryInt("id");
        ZS.BLL.znPage bll = new ZS.BLL.znPage();
        int defaultID = bll.GetDefaultID(this._categoryID);
        if (this._id == 0 && defaultID != 0)
        {
            this._id = defaultID;
            Response.RedirectToRoute(this._route, new { id = this._id });
        }

        if (!Page.IsPostBack)
        {
            Detail(this._id);
        }
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    protected void Detail(int id)
    {
        ZS.BLL.znPage bll = new ZS.BLL.znPage();
        if (bll.Exists(id, true))
        {
            int isUrl = 0;
            string linkUrl = string.Empty;
            string content = string.Empty;
            ZS.Model.znPage model = bll.GetModel(id);
            if (model != null)
            {
                isUrl = Convert.ToInt32(model.isUrl);
                linkUrl = model.LinkUrl;
                content = model.Content;
            }
            //Url转跳
            if (isUrl == 1)
            {
                Response.Redirect(linkUrl, true);
            }

            //数据绑定
            this.ltContent.Text = content;
        }
    }
}