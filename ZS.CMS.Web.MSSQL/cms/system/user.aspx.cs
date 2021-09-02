using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ZS.KIT;
using ZS.TCDOS;

public partial class cms_system_user : znManage
{
    private string _labelName = "ZS.CMS.Config.System.User";
    private string _pageUrl = "user.aspx";
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
        ZS.BLL.znUser bll = new ZS.BLL.znUser();
        rptList.DataSource = bll.GetList(this._pageSize, this._curPage, CombSql(this._searchWord, this._property), this._sortFiled, out this._totalCount);
        rptList.DataBind();
        //数据分页
        string pageUrl = znUtils.CombUrl(this._pageUrl, "searchWord={0}&propetry={1}&page={2}", this._searchWord.ToString(), this._property.ToString(), "znPage");
        pageList.InnerHtml = znUtils.PageList(this._pageSize, this._curPage, this._totalCount, pageUrl, 6);
    }

    /// <summary>
    /// SQL组合
    /// </summary>
    protected string CombSql(string searchWord, string strProperty)
    {
        StringBuilder sql = new StringBuilder();
        if (Session["UserPurview"] != null)
        {
            sql.Append(" and Purview>=" + Session["UserPurview"] + ""); //用户类型控制
        }
        if (Session["UserName"] != null)
        {
            sql.Append(" and UserName<>'" + Session["UserName"].ToString() + "'"); //不加载当前登录帐号
        }
        searchWord = searchWord.Trim().Replace("'", "");
        if (!string.IsNullOrEmpty(searchWord))
        {
            sql.Append(" and UserName like '%" + searchWord + "%'");
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
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //登录日志
            Literal litTime = (Literal)e.Item.FindControl("litLastLoginTime");
            Literal litIP = (Literal)e.Item.FindControl("litLastLoginIP");
            string manageName = DataBinder.Eval(e.Item.DataItem, "UserName").ToString().Trim();
            ZS.BLL.znLog bll = new ZS.BLL.znLog();
            ZS.Model.znLog model = bll.GetModel(manageName);
            if (model != null)
            {
                litTime.Text = model.LoginTime;
                litIP.Text = model.LoginIP;
            }
            else
            {
                litTime.Text = "-";
                litIP.Text = "-";
            }

            //类型
            Literal litUserPurview = (Literal)e.Item.FindControl("litUserPurview");
            int purview = znConvert.ObjToInt(DataBinder.Eval(e.Item.DataItem, "Purview"), 0);
            string strPurview = string.Empty;
            switch (purview)
            {
                case 0:
                    strPurview = "<span class='red'>超级用户</span>";
                    break;
                case 1:
                    strPurview = "<span class='green'>系统用户</span>";
                    break;
                default:
                    strPurview = "<span class='gray'>未知类型</span>";
                    break;
            }
            litUserPurview.Text = strPurview;

            //Edit
            int id = znConvert.ObjToInt(DataBinder.Eval(e.Item.DataItem, "ID"), 0);
            HyperLink hlEdit = (HyperLink)e.Item.FindControl("hlEdit");
            hlEdit.NavigateUrl = znUtils.CombUrl("user_edit.aspx", "action={0}&id={1}&searchWord={2}&propetry={3}&page={4}", znEnum.Actions.Edit.ToString(), id.ToString(), this._searchWord, this._property.ToString(), this._curPage.ToString());
        }
    }

    /// <summary>
    /// 搜索
    /// </summary>
    protected void lbSearch_Click(object sender, EventArgs e)
    {
        string reUrl = znUtils.CombUrl(this._pageUrl, "searchWord={0}&propetry={1}", tbSearchWord.Text, this._property);
        Response.Redirect(reUrl);
    }

    /// <summary>
    /// 属性筛选
    /// </summary>
    protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        string reUrl = znUtils.CombUrl(this._pageUrl, "searchWord={0}&propetry={1}", this._searchWord, ddlProperty.SelectedValue.ToString());
        Response.Redirect(reUrl);
    }

    /// <summary>
    /// 属性更新
    /// </summary>
    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int ID = znConvert.StrToInt(((TextBox)e.Item.FindControl("tbID")).Text, 0);
        ZS.BLL.znUser bll = new ZS.BLL.znUser();
        ZS.Model.znUser model = bll.GetModel(ID);
        switch (e.CommandName.ToLower())
        {
            case "btncheck":
                if (model.isCheck == 1)
                    bll.UpdateField(ID, "isCheck=0");
                else
                    bll.UpdateField(ID, "isCheck=1");
                break;
        }
        string reUrl = znUtils.CombUrl(this._pageUrl, "searchWord={0}&propetry={1}&page={2}", this._searchWord, this._property, this._curPage.ToString());
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
            ZS.BLL.znUser bll = new ZS.BLL.znUser();
            ZS.Model.znUser model = bll.GetModel(ID);
            if (cb.Checked)
            {
                if (model.isCheck == 1)
                    bll.UpdateField(ID, "isCheck=0");
                else
                    bll.UpdateField(ID, "isCheck=1");
            }
        }
        string reUrl = znUtils.CombUrl(this._pageUrl, "searchWord={0}&propetry={1}&page={2}", this._searchWord, this._property, this._curPage.ToString());
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
            ZS.BLL.znUser bll = new ZS.BLL.znUser();
            if (cb.Checked)
            {
                bll.Delete(ID);
            }
        }
        string reUrl = znUtils.CombUrl(this._pageUrl, "searchWord={0}&propetry={1}&page={2}", this._searchWord, this._property, this._curPage.ToString());
        znUtils.Tips(this.Page, "提交成功，请返回！", reUrl);
    }

    /// <summary>
    /// 新增
    /// </summary>
    protected void lbAdd_Click(object sender, EventArgs e)
    {
        ChkUserLevel(_labelName, znEnum.Actions.Add.ToString());
        Response.Redirect("user_edit.aspx?action=" + znEnum.Actions.Add.ToString());
    }
}