using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ZS.KIT;
using ZS.TCDOS;

public partial class cms_system_log : znManage
{
    private string _labelName = "ZS.CMS.Config.System.Log";
    private string _pageUrl = "log.aspx";
    private int _pageSize = 15;
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
        this._searchWord = znRequest.GetQueryString("searchWord");
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
        this.tbSearchWord.Text = this._searchWord.ToString();

        //数据读取
        ZS.BLL.znLog bll = new ZS.BLL.znLog();
        rptList.DataSource = bll.GetList(this._pageSize, this._curPage, CombSql(this._searchWord), this._sortFiled, out this._totalCount);
        rptList.DataBind();
        //数据分页
        string pageUrl = znUtils.CombUrl(this._pageUrl, "searchWord={0}&page={1}", this._searchWord.ToString(), "znPage");
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
            sql.Append(" and UserName like '%" + searchWord + "%'");
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
        ChkUserLevel(_labelName, znEnum.Actions.Delete.ToString());
        foreach (RepeaterItem Item in rptList.Items)
        {
            CheckBox cb = (CheckBox)Item.FindControl("cbID");
            TextBox tb = (TextBox)Item.FindControl("tbID");
            int ID = znConvert.StrToInt(tb.Text.ToString(), 0);
            ZS.BLL.znLog bll = new ZS.BLL.znLog();
            if (cb.Checked)
            {
                bll.Delete(ID);
            }
        }
        string reUrl = znUtils.CombUrl(this._pageUrl, "searchWord={0}&page={1}", this._searchWord, this._curPage.ToString());
        znUtils.Tips(this.Page, "提交成功，请返回！", reUrl);
    }

}