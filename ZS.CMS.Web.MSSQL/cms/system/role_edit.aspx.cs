using System;
using System.Web.UI;
using ZS.KIT;
using ZS.TCDOS;

public partial class cms_system_role_edit : znManage
{
    private string _labelName = "ZS.CMS.Config.System.Role";
    private string _pageUrl = "role.aspx";
    private string _action = znEnum.Actions.Add.ToString();
    private int _id = 0;
    private int _curpage;
    private string _searchWord = string.Empty;

    /// <summary>
    /// 页面初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = znTech.clientName;
        this._searchWord = znRequest.GetQueryString("searchWord");
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
            if (this._action == znEnum.Actions.Edit.ToString())
            {
                ChkUserLevel(_labelName, znEnum.Actions.Edit.ToString());
                FillData(this._id);
                tbRoleName.Attributes.Remove("ajaxurl");
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
    protected void FillData(int ID)
    {
        ZS.BLL.znRole bll = new ZS.BLL.znRole();
        ZS.Model.znRole model = bll.GetModel(ID);
        if (model != null)
        {
            tbRoleName.Text = model.RoleName;
        }
    }

    /// <summary>
    /// 提交
    /// </summary>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string reUrl = znUtils.CombUrl(this._pageUrl, "searchWord={0}&page={1}", this._searchWord.ToString(), this._curpage.ToString());
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
    protected bool DoEdit(int ID)
    {
        bool result = false;
        ZS.BLL.znRole bll = new ZS.BLL.znRole();
        if (bll.Exists(ID))
        {
            ZS.Model.znRole model = bll.GetModel(ID);
            model.RoleName = tbRoleName.Text.Trim();
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
    protected bool DoAdd()
    {
        bool result = false;
        ZS.BLL.znRole bll = new ZS.BLL.znRole();
        ZS.Model.znRole model = new ZS.Model.znRole();
        model.RoleName = tbRoleName.Text.Trim();

        if (bll.Add(model))
        {
            result = true;
        }
        return result;
    }
}