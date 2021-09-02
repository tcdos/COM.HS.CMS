﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ZS.KIT;
using ZS.TCDOS;

public partial class cms_system_role : znManage
{
    private string _labelName = "ZS.CMS.Config.System.Role";
    private string _pageUrl = "role.aspx";
    private int _pageSize = 20;
    private string _sortFiled = "ID desc";
    private int _totalCount;
    public int _curPage;
    public string _searchWord = string.Empty;

    /// <summary>
    /// 页面初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = znTech.clientName;
        this._searchWord = znRequest.GetQueryString("searchWord", true);
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
        //搜索
        this.tbSearchWord.Text = this._searchWord.ToString();

        //数据读取
        ZS.BLL.znRole bll = new ZS.BLL.znRole();
        rptList.DataSource = bll.GetList(this._pageSize, this._curPage, CombSql(this._searchWord), this._sortFiled, out this._totalCount);
        rptList.DataBind();

        //数据分页
        string pageUrl = znUtils.CombUrl(this._pageUrl, "searchWord={0}&page={1}", this._searchWord, "znPage");
        pageList.InnerHtml = znUtils.PageList(this._pageSize, this._curPage, this._totalCount, pageUrl, 6);
    }

    /// <summary>
    /// SQL组合
    /// </summary>
    protected string CombSql(string searchWord)
    {
        StringBuilder sql = new StringBuilder();
        searchWord = searchWord.Trim().Replace("'", "");
        if (!string.IsNullOrEmpty(searchWord))
        {
            sql.Append(" and RoleName like '%" + searchWord + "%'");
        }
        return sql.ToString();
    }

    /// <summary>
    /// 搜索
    /// </summary>
    protected void lbSearch_Click(object sender, EventArgs e)
    {
        string reUrl = znUtils.CombUrl(this._pageUrl, "searchWord={0}", tbSearchWord.Text);
        Response.Redirect(reUrl);
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void lbDel_Click(object sender, EventArgs e)
    {
        string reUrl = znUtils.CombUrl(this._pageUrl, "searchWord={0}&page={1}", this._searchWord, this._curPage.ToString());
        ChkUserLevel(_labelName, znEnum.Actions.Delete.ToString());
        foreach (RepeaterItem Item in rptList.Items)
        {
            CheckBox cb = (CheckBox)Item.FindControl("cbID");
            TextBox tb = (TextBox)Item.FindControl("tbID");
            int ID = znConvert.StrToInt(tb.Text.ToString(), 0);
            ZS.BLL.znRole bll = new ZS.BLL.znRole();
            ZS.BLL.znRoleValue bllValue = new ZS.BLL.znRoleValue();
            if (cb.Checked)
            {
                bll.Delete(ID);
                bllValue.Delete(ID);
            }
        }

        znUtils.Tips(this.Page, "提交成功，请返回！", reUrl);
    }

    /// <summary>
    /// 新增
    /// </summary>
    protected void lbAdd_Click(object sender, EventArgs e)
    {
        ChkUserLevel(_labelName, znEnum.Actions.Add.ToString());
        Response.Redirect("role_edit.aspx?action=" + znEnum.Actions.Add.ToString());
    }
}