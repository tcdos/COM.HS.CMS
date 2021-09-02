using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ZS.KIT;
using ZS.TCDOS;

public partial class cms_case_content_edit : znManage
{
    private string _labelName = "ZS.CMS.Content.Case.Manage";
    private int _channelID = 7;
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
            FillGategory();
            if (this._action == znEnum.Actions.Edit.ToString())
            {
                ChkUserLevel(_labelName, znEnum.Actions.Edit.ToString());
                FillData(this._id);
            }
            else
            {
                ChkUserLevel(_labelName, znEnum.Actions.Add.ToString());
                tbPostTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                tbUserName.Text = Session["UserName"].ToString();
            }
        }
    }

    /// <summary>
    /// 类别控件绑定
    /// </summary>
    protected void FillGategory()
    {
        ZS.BLL.znCategory bll = new ZS.BLL.znCategory();
        DataTable dt = bll.GetList(0, this._channelID);
        this.ddlCategory.Items.Clear();
        this.ddlCategory.Items.Add(new ListItem("所有类别", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string ID = dr["ID"].ToString();
            int layer = int.Parse(dr["Layer"].ToString());
            string title = dr["Title"].ToString().Trim();

            if (layer == 1)
            {
                this.ddlCategory.Items.Add(new ListItem(title, ID));
            }
            else
            {
                title = "├ " + title;
                title = znUtils.StringOfChar("　", layer - 1) + title;
                this.ddlCategory.Items.Add(new ListItem(title, ID));
            }
        }
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public void FillData(int ID)
    {
        ZS.BLL.znCase bll = new ZS.BLL.znCase();
        ZS.Model.znCase model = bll.GetModel(ID);
        if (model != null)
        {
            ddlCategory.SelectedValue = model.CategoryID.ToString();
            tbTitle.Text = model.Title;
            tbUserName.Text = model.UserName;
            tbPostTime.Text = model.PostTime;
            tbSource.Text = model.Source;
            tbSortID.Text = model.SortID.ToString();
            tbHits.Text = model.Hits.ToString();
            tbSmallPic.Text = model.SmallPic;
            tbSummary.Text = model.Summary;
            tbContent.Value = model.Content;
            tbLinkUrl.Text = model.LinkUrl;
            if (model.isUrl == 1)
            {
                cbIsUrl.Checked = true;
            }
            if (model.isTop == 1)
            {
                cbIsTop.Checked = true;
            }
            if (model.isElite == 1)
            {
                cbIsElite.Checked = true;
            }
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
        ZS.BLL.znCase bll = new ZS.BLL.znCase();
        if (bll.Exists(ID, false))
        {
            ZS.Model.znCase model = bll.GetModel(ID);

            model.CategoryID = znConvert.StrToInt(ddlCategory.SelectedValue, 0);
            model.Title = tbTitle.Text.Trim();
            model.Source = tbSource.Text.Trim();
            model.SortID = znConvert.StrToInt(tbSortID.Text.Trim(), 0);
            model.Hits = znConvert.StrToInt(tbHits.Text.Trim(), 0);
            model.LinkUrl = tbLinkUrl.Text.Trim();
            model.SmallPic = tbSmallPic.Text.Trim();
            model.Summary = tbSummary.Text.Trim();
            model.Content = tbContent.Value;
            model.isUrl = 0;
            model.isTop = 0;
            model.isElite = 0;
            model.isCheck = Convert.ToInt32(rblIsCheck.SelectedValue);
            if (cbIsUrl.Checked == true)
            {
                model.isUrl = 1;
            }
            if (cbIsTop.Checked == true)
            {
                model.isTop = 1;
            }
            if (cbIsElite.Checked == true)
            {
                model.isElite = 1;
            }
            model.UserName = string.IsNullOrEmpty(tbUserName.Text.Trim()) ? Session["UserName"].ToString() : tbUserName.Text.Trim();
            model.PostTime = string.IsNullOrEmpty(tbPostTime.Text.Trim()) ? Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss") : tbPostTime.Text.Trim();

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
        ZS.BLL.znCase bll = new ZS.BLL.znCase();
        ZS.Model.znCase model = new ZS.Model.znCase();

        model.CategoryID = znConvert.StrToInt(ddlCategory.SelectedValue, 0);
        model.Title = tbTitle.Text.Trim();
        model.Source = tbSource.Text.Trim();
        model.SortID = znConvert.StrToInt(tbSortID.Text.Trim(), 0);
        model.Hits = znConvert.StrToInt(tbHits.Text.Trim(), 0);
        model.LinkUrl = tbLinkUrl.Text.Trim();
        model.SmallPic = tbSmallPic.Text.Trim();
        model.Summary = tbSummary.Text.Trim();
        model.Content = tbContent.Value;
        model.isUrl = 0;
        model.isTop = 0;
        model.isElite = 0;
        model.isCheck = Convert.ToInt32(rblIsCheck.SelectedValue);
        if (cbIsUrl.Checked == true)
        {
            model.isUrl = 1;
        }
        if (cbIsTop.Checked == true)
        {
            model.isTop = 1;
        }
        if (cbIsElite.Checked == true)
        {
            model.isElite = 1;
        }
        model.UserName = string.IsNullOrEmpty(tbUserName.Text.Trim()) ? Session["UserName"].ToString() : tbUserName.Text.Trim();
        model.PostTime = string.IsNullOrEmpty(tbPostTime.Text.Trim()) ? Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss") : tbPostTime.Text.Trim();

        if (bll.Add(model))
        {
            result = true;
        }
        return result;
    }
}