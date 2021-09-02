using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ZS.KIT;
using ZS.TCDOS;

public partial class cms_banner_content : znManage
{ 
    private string _labelName = "ZS.CMS.Plugin.Banner.Manage";
    private string _pageUrl = "content.aspx";
    public int _categoryID;
    private int _pageSize = 15;
    private string _sortFiled = "ID desc";
    private int _totalCount;
    public int _curPage;
    public string _property = string.Empty;
    public string _searchWord = string.Empty;

    /// <summary>
    /// 页面初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = znTech.clientName;
        this._categoryID = znRequest.GetQueryInt("categoryID");
        this._searchWord = znRequest.GetQueryString("searchWord", true);
        this._property = znRequest.GetQueryString("propetry");
        this._curPage = znRequest.GetQueryInt("page", 1);
        this.tbSearchWord.Attributes.Add("onkeydown", "submitKeyClick('lbSearch')");
        if (!Page.IsPostBack)
        {
            ChkUserLevel(_labelName, znEnum.Actions.View.ToString());
            FillRepeater();
        }
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    protected void FillRepeater()
    {
        this.ddlProperty.SelectedValue = this._property.ToString();
        this.tbSearchWord.Text = this._searchWord.ToString();

        //数据读取
        ZS.BLL.znBanner bll = new ZS.BLL.znBanner();
        rptList.DataSource = bll.GetList(this._categoryID, this._pageSize, this._curPage, CombSql(this._searchWord, this._property), this._sortFiled, out this._totalCount);
        rptList.DataBind();
        //数据分页
        string pageUrl = znUtils.CombUrl(this._pageUrl, "categoryID={0}&searchWord={1}&propetry={2}&page={3}", this._categoryID.ToString(), this._searchWord, this._property.ToString(), "znPage");
        pageList.InnerHtml = znUtils.PageList(this._pageSize, this._curPage, this._totalCount, pageUrl, 6);
    }

    /// <summary>
    /// SQL组合
    /// </summary>
    protected string CombSql(string searchWord, string strProperty)
    {
        StringBuilder sql = new StringBuilder();
        searchWord = searchWord.Trim().Replace("'", "");
        if (!string.IsNullOrEmpty(searchWord))
        {
            sql.Append(" and Title like '%" + searchWord + "%'");
        }
        if (!string.IsNullOrEmpty(strProperty))
        {
            switch (strProperty)
            {
                case "isCheck":
                    sql.Append(" and isCheck=0");
                    break;
            }
        }
        return sql.ToString();
    }

    /// <summary>
    /// 数据处理
    /// </summary>
    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            //Edit
            int id = znConvert.ObjToInt(DataBinder.Eval(e.Item.DataItem, "ID"), 0);
            HyperLink hlEdit = (HyperLink)e.Item.FindControl("hlEdit");
            hlEdit.NavigateUrl = znUtils.CombUrl("content_edit.aspx", "action={0}&id={1}&categoryID={2}&searchWord={3}&propetry={4}&page={5}", znEnum.Actions.Edit.ToString(), id.ToString(), this._categoryID.ToString(), this._searchWord, this._property.ToString(), this._curPage.ToString());
        }
    }

    /// <summary>
    /// 搜索
    /// </summary>
    protected void lbSearch_Click(object sender, EventArgs e)
    {
        string reUrl = znUtils.CombUrl(this._pageUrl, "categoryID={0}&searchWord={1}&propetry={2}", this._categoryID.ToString(), tbSearchWord.Text, this._property);
        Response.Redirect(reUrl);
    }

    /// <summary>
    /// 属性筛选
    /// </summary>
    protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        string reUrl = znUtils.CombUrl(this._pageUrl, "categoryID={0}&searchWord={1}&propetry={2}", this._categoryID.ToString(), this._searchWord, ddlProperty.SelectedValue.ToString());
        Response.Redirect(reUrl);
    }

    /// <summary>
    /// 属性更新
    /// </summary>
    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int ID = znConvert.StrToInt(((TextBox)e.Item.FindControl("tbID")).Text, 0);
        ZS.BLL.znBanner bll = new ZS.BLL.znBanner();
        ZS.Model.znBanner model = bll.GetModel(ID);
        switch (e.CommandName.ToLower())
        {
            case "btncheck":
                if (model.isCheck == 1)
                    bll.UpdateField(ID, "isCheck=0");
                else
                    bll.UpdateField(ID, "isCheck=1");
                break;
        }
        string reUrl = znUtils.CombUrl(this._pageUrl, "categoryID={0}&searchWord={1}&propetry={2}&page={3}", this._categoryID.ToString(), this._searchWord, this._property, this._curPage.ToString());
        Response.Redirect(reUrl);
    }

    /// <summary>
    /// 批量审核
    /// </summary>
    protected void lbCheck_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem Item in rptList.Items)
        {
            CheckBox cb = (CheckBox)Item.FindControl("cbID");
            TextBox tb = (TextBox)Item.FindControl("tbID");
            int ID = znConvert.StrToInt(tb.Text.ToString(), 0);
            ZS.BLL.znBanner bll = new ZS.BLL.znBanner();
            ZS.Model.znBanner model = bll.GetModel(ID);
            if (cb.Checked)
            {
                if (model.isCheck == 1)
                    bll.UpdateField(ID, "isCheck=0");
                else
                    bll.UpdateField(ID, "isCheck=1");
            }
        }
        string reUrl = znUtils.CombUrl(this._pageUrl, "categoryID={0}&searchWord={1}&propetry={2}&page={3}", this._categoryID.ToString(), this._searchWord, this._property, this._curPage.ToString());
        Response.Redirect(reUrl);
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void lbDel_Click(object sender, EventArgs e)
    {
        ChkUserLevel(_labelName, znEnum.Actions.Delete.ToString());
        foreach (RepeaterItem Item in rptList.Items)
        {
            CheckBox cb = (CheckBox)Item.FindControl("cbID");
            TextBox tb = (TextBox)Item.FindControl("tbID");
            int ID = znConvert.StrToInt(tb.Text.ToString(), 0);
            ZS.BLL.znBanner bll = new ZS.BLL.znBanner();
            if (cb.Checked)
            {
                bll.Delete(ID);
            }
        }
        string reUrl = znUtils.CombUrl(this._pageUrl, "categoryID={0}&searchWord={1}&propetry={2}&page={3}", this._categoryID.ToString(), this._searchWord, this._property, this._curPage.ToString());
        znUtils.Tips(this.Page, "提交成功，请返回！", reUrl);
    }

    /// <summary>
    /// 新增
    /// </summary>
    protected void lbAdd_Click(object sender, EventArgs e)
    {
        ChkUserLevel(_labelName, znEnum.Actions.Add.ToString());
        Response.Redirect("content_edit.aspx?action=" + znEnum.Actions.Add.ToString());
    }
}