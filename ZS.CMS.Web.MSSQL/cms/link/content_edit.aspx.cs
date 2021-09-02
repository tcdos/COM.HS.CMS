using System;
using System.Web.UI;
using ZS.KIT;
using ZS.TCDOS;


public partial class cms_link_content_edit : znManage
{
    private string _labelName = "ZS.CMS.Plugin.Link.Manage";
    private string _pageUrl = "content.aspx";
    private string _action = znEnum.Actions.Add.ToString();
    private int _id = 0;
    private int _categoryID;
    private int _curPage;
    private string _property = string.Empty;
    private string _searchWord = string.Empty;

    /// <summary>
    /// 页面初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = znTech.clientName;
        this._categoryID = znRequest.GetQueryInt("categoryID");
        this._searchWord = znRequest.GetQueryString("searchWord");
        this._property = znRequest.GetQueryString("propetry");
        this._curPage = znRequest.GetQueryInt("page", 1);

        this._id = znRequest.GetQueryInt("id");
        string action = znRequest.GetQueryString("action");
        if (action == znEnum.Actions.Edit.ToString())
        {
            this._action = znEnum.Actions.Edit.ToString();
            if (this._id == 0)
            {
                znUtils.Redirect("参数不正确，请勿随意提交数据！");
            }
        }
        if (!Page.IsPostBack)
        {
            if (this._action == znEnum.Actions.Edit.ToString())
            {
                ChkUserLevel(_labelName, znEnum.Actions.Edit.ToString());
                FillData(this._id);
            }
            else
            {
                ChkUserLevel(_labelName, znEnum.Actions.Add.ToString());
            }
        }
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public void FillData(int ID)
    {
        ZS.BLL.znLink bll = new ZS.BLL.znLink();
        ZS.Model.znLink model = bll.GetModel(ID);
        if (model != null)
        {
            ddlCategoryID.SelectedValue = model.CategoryID.ToString();
            pnlLogoUrl.Visible = Convert.ToInt32(Convert.ToString(model.CategoryID)) == 1 ? false : true;
            tbTitle.Text = model.Title;
            tbLinkUrl.Text = model.LinkUrl;
            tbLogoUrl.Text = model.LogoUrl;
            tbLinkNote.Text = model.LinkNote;
            tbSortID.Text = model.SortID.ToString();
            rblIsCheck.SelectedValue = model.isCheck.ToString();
        }
    }

    /// <summary>
    /// 提交
    /// </summary>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string reUrl = znUtils.CombUrl(this._pageUrl, "categoryID={0}&searchWord={1}&propetry={2}&page={3}", this._categoryID.ToString(), this._searchWord.ToString(), this._property.ToString(), this._curPage.ToString());
        if (this._action == znEnum.Actions.Edit.ToString())
        {
            ChkUserLevel(_labelName, znEnum.Actions.Edit.ToString());
            if (!DoEdit(this._id))
            {
                znUtils.Tips(this.Page, "提交失败，请返回！", reUrl);
                return;
            }
            znUtils.Tips(this.Page, "提交成功，请返回！", reUrl);
        }
        else
        {
            ChkUserLevel(_labelName, znEnum.Actions.Add.ToString());
            if (!DoAdd())
            {
                znUtils.Tips(this.Page, "提交失败，请返回！", reUrl);
                return;
            }
            znUtils.Tips(this.Page, "提交成功，请返回！", reUrl);
        }
    }

    /// <summary>
    /// 编辑
    /// </summary>
    private bool DoEdit(int ID)
    {
        bool result = false;
        ZS.BLL.znLink bll = new ZS.BLL.znLink();
        if (bll.Exists(ID, false))
        {
            ZS.Model.znLink model = bll.GetModel(ID);
            model.CategoryID = znConvert.StrToInt(ddlCategoryID.SelectedValue, 0);
            model.Title = tbTitle.Text.Trim();
            model.LinkUrl = tbLinkUrl.Text.Trim();
            model.LogoUrl = tbLogoUrl.Text.Trim();
            model.LinkNote = tbLinkNote.Text.Trim();
            model.SortID = znConvert.StrToInt(tbSortID.Text.Trim(), 0);
            model.isCheck = znConvert.StrToInt(rblIsCheck.SelectedValue, 0);
            if (bll.Update(model))
            {
                result = true;
            }
            return result;
        }
        else
        {
            return result;
        }
    }

    /// <summary>
    /// 新增
    /// </summary>
    private bool DoAdd()
    {
        bool result = false;
        ZS.BLL.znLink bll = new ZS.BLL.znLink();
        ZS.Model.znLink model = new ZS.Model.znLink();

        model.CategoryID = znConvert.StrToInt(ddlCategoryID.SelectedValue, 0);
        model.Title = tbTitle.Text.Trim();
        model.LinkUrl = tbLinkUrl.Text.Trim();
        model.LogoUrl = tbLogoUrl.Text.Trim();
        model.LinkNote = tbLinkNote.Text.Trim();
        model.SortID = znConvert.StrToInt(tbSortID.Text.Trim(), 0);
        model.isCheck = znConvert.StrToInt(rblIsCheck.SelectedValue, 0);

        if (bll.Add(model))
        {
            result = true;
        }
        return result;
    }

    /// <summary>
    /// 类型选择
    /// </summary>
    protected void ddlCategoryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        int categoryID = znConvert.StrToInt(ddlCategoryID.SelectedValue.ToString(), 0);
        if (categoryID == 1)
            pnlLogoUrl.Visible = false;
        else
            pnlLogoUrl.Visible = true;
    }
}