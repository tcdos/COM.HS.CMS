using System;
using System.Web.UI;
using ZS.KIT;
using ZS.TCDOS;

public partial class cms_hr_resume_edit : znManage
{
    private string _labelName = "ZS.CMS.Content.HR.Resume";
    private string _pageUrl = "resume.aspx";
    private string _action = string.Empty;
    private int _id = 0;
    private int _curpage;
    private string _property = string.Empty;
    private string _searchWord = string.Empty;

    /// <summary>
    /// 页面初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = znTech.clientName;
        this._searchWord = znRequest.GetQueryString("searchWord", true);
        this._property = znRequest.GetQueryString("propetry");
        this._curpage = znRequest.GetQueryInt("page", 1);

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
            ChkUserLevel(_labelName, znEnum.Actions.View.ToString());
            FillData(this._id);
        }
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public void FillData(int ID)
    {
        ZS.BLL.znResume bll = new ZS.BLL.znResume();
        ZS.Model.znResume model = bll.GetModel(ID);
        if (model!=null)
        {
            tbAuthor.Text = model.Author;
            tbPosition.Text = new ZS.BLL.znHR().GetTitle(Convert.ToInt32(model.PositionID));
            ddlSex.SelectedValue = model.Sex;
            tbTel.Text = model.Tel;
            tbEmail.Text = model.Email;
            tbPostTime.Text = Convert.ToDateTime(model.PostTime).ToString("yyyy-MM-dd HH:mm:ss");
            tbResume.Text = model.Resume;
            rblIsCheck.SelectedValue = model.isCheck.ToString();
        }
    }

    /// <summary>
    /// 提交
    /// </summary>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string reUrl = znUtils.CombUrl(this._pageUrl, "searchWord={0}&propetry={1}&page={2}", this._searchWord.ToString(), this._property.ToString(), this._curpage.ToString());
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
    }

    /// <summary>
    /// 编辑
    /// </summary>
    private bool DoEdit(int ID)
    {
        bool result = false;
        ZS.BLL.znResume bll = new ZS.BLL.znResume();
        if (bll.Exists(ID, false))
        {
            ZS.Model.znResume model = bll.GetModel(ID);
            model.Author = tbAuthor.Text.Trim();
            model.Email = tbEmail.Text.Trim();
            model.Sex = ddlSex.SelectedValue.ToString();
            model.Tel = tbTel.Text.Trim();
            model.Resume = tbResume.Text.Trim();
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

}