using System;
using System.Web.UI;
using ZS.KIT;
using ZS.TCDOS;

public partial class cms_feedback_content_reply : znManage
{
    private string _labelName = "ZS.CMS.Plugin.Feedback.Manage";
    private string _pageUrl = "content.aspx";
    private string _action = string.Empty;
    private int _id = 0;
    private string _category = string.Empty;
    private int _curPage;
    private string _property = string.Empty;
    private string _searchWord = string.Empty;

    /// <summary>
    /// 页面初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = znTech.clientName;
        this._category = znRequest.GetQueryString("category", true);
        this._searchWord = znRequest.GetQueryString("searchWord", true);
        this._property = znRequest.GetQueryString("propetry");
        this._curPage = znRequest.GetQueryInt("page", 1);

        this._id = znRequest.GetQueryInt("id");
        string action = znRequest.GetQueryString("action");
        if (action == znEnum.Actions.Reply.ToString())
        {
            this._action = znEnum.Actions.Reply.ToString();
            if (this._id == 0)
            {
                znUtils.Redirect("参数不正确，请勿随意提交数据！");
            }
        }
        if (!Page.IsPostBack)
        {
            ChkUserLevel(_labelName, znEnum.Actions.Reply.ToString());
            if (this._action == znEnum.Actions.Reply.ToString())
            {
                FillData(this._id);
            }
        }
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public void FillData(int ID)
    {
        ZS.BLL.znFeedback bll = new ZS.BLL.znFeedback();
        ZS.Model.znFeedback model = bll.GetModel(ID);
        if (model!=null)
        {
            tbAuthor.Text = model.Author;
            tbTel.Text = model.Tel;
            tbEmail.Text = model.Email;
            tbCategory.Text = model.Category;
            tbContent.Text = model.Content;
            tbPostTime.Text = Convert.ToDateTime(model.PostTime).ToString("yyyy-MM-dd HH:mm:ss");
            tbPostIP.Text = model.PostIP;
            tbReplyContent.Text = model.ReplyContent;
            tbReplyUserName.Text = string.IsNullOrEmpty(model.ReplyUserName) ? Session["UserName"].ToString() : model.ReplyUserName.ToString();
            tbReplyTime.Text = string.IsNullOrEmpty(model.ReplyTime) ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : Convert.ToDateTime(model.ReplyTime).ToString("yyyy-MM-dd HH:mm:ss");
            rblIsCheck.SelectedValue = model.isCheck.ToString();
        }
    }

    /// <summary>
    /// 提交
    /// </summary>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string reUrl = znUtils.CombUrl(_pageUrl, "category={0}&searchWord={1}&propetry={2}&page={3}", this._category.ToString(), this._searchWord.ToString(), this._property.ToString(), this._curPage.ToString());
        ZS.BLL.znFeedback bll = new ZS.BLL.znFeedback();
        if (bll.Exists(this._id, false))
        {
            ZS.Model.znFeedback model = bll.GetModel(this._id);
            model.ReplyContent = tbReplyContent.Text.Trim();
            model.ReplyTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            model.ReplyUserName = Session["UserName"].ToString();
            model.isCheck = znConvert.StrToInt(rblIsCheck.SelectedValue, 0);
            if (bll.Update(model))
            {
                znUtils.Tips(this.Page, "提交成功，请返回！", reUrl);
            }
            else
            {
                znUtils.Tips(this.Page, "提交失败，请返回！", reUrl);
            }
        }
        else
        {
            znUtils.Redirect("参数不正确，请勿随意提交数据！");
        }
    }
}