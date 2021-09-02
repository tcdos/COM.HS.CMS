using System;
using System.Collections.Generic;
using System.Web.UI;
using ZS.KIT;

public partial class uc_article_view : System.Web.UI.UserControl
{
    private int _id = 0;
    private string _detailRoute = "news_detail";

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
        this._id = znConvert.ObjToInt(Page.RouteData.Values["id"], 0) | znRequest.GetQueryInt("id");
        if (this._id == 0)
        {
            Response.Redirect("~/tips.aspx?msg=参数不合法，请勿随意提交数据！", true);
            Response.End();
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
        ZS.BLL.znArticle bll = new ZS.BLL.znArticle();
        if (bll.Exists(id, true))
        {
            string title = string.Empty;
            string source = string.Empty;
            string postTime = string.Empty;
            int hits = 0;
            string content = string.Empty;
            int isUrl = 0;
            string linkUrl = string.Empty;

            string nextTitle = string.Empty;
            int nextID = 0;
            string nextUrl = string.Empty;
            string preTitle = string.Empty;
            int preID = 0;
            string preUrl = string.Empty;

            //当前记录
            ZS.Model.znArticle model = bll.GetModel(id);
            if (model == null)
            {
                Response.Redirect("~/tips.aspx?msg=该记录不存在，请浏览其它内容！", true);
                Response.End();
            }
            else
            {
                //更新浏览次数
                model.Hits = model.Hits + 1;
                bll.Update(model);
                //读取数据
                isUrl = Convert.ToInt32(model.isUrl);
                linkUrl = model.LinkUrl;
                title = model.Title;
                postTime = model.PostTime;
                source = model.Source;
                hits = Convert.ToInt32(model.Hits);
                content = model.Content;
            }

            //Url转跳
            if (isUrl == 1)
            {
                Response.Redirect(linkUrl, true);
            }

            //下一条记录
            List<ZS.Model.znArticle> nextM = bll.GetModelList("isCheck=1 and ID>" + this._id + " order by ID asc");
            if (nextM.Count > 0)
            {
                nextTitle = nextM[0].Title;
                nextID = nextM[0].ID;
            }
            nextUrl = string.IsNullOrEmpty(nextTitle) ? "下一条记录：-" : "下一条记录：<a href=\"" + Page.GetRouteUrl(this._detailRoute, new { id = nextID }) + "\" title=\"" + nextTitle + "\">" + nextTitle + "</a>";

            //上一条记录
            List<ZS.Model.znArticle> preM = bll.GetModelList("isCheck=1 and ID<" + this._id + " order by ID desc");
            if (preM.Count > 0)
            {
                preTitle = preM[0].Title;
                preID = preM[0].ID;
            }
            preUrl = string.IsNullOrEmpty(preTitle) ? "上一条记录：-" : "上一条记录：<a href=\"" + Page.GetRouteUrl(this._detailRoute, new { id = preID }) + "\" title=\"" + preTitle + "\">" + preTitle + "</a>";

            //数据绑定
            this.ltTitle.Text = title;
            this.ltProperty.Text = "<span class=\"time\" >发布时间：" + Convert.ToDateTime(postTime).ToString("yyyy-MM-dd HH:mm:ss") + "</span><span class=\"source\">来源：" + source + "</span><span class=\"hits\">浏览次数：" + hits + "</span>";
            this.ltContent.Text = content;
            this.ltUrls.Text = preUrl + "<br/>" + nextUrl;

        }
        else
        {
            Response.Redirect("~/tips.aspx?msg=该记录不存在，请浏览其它内容！", true);
            Response.End();
        }
    }
}