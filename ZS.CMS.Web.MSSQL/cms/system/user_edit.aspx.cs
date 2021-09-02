using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ZS.KIT;
using ZS.TCDOS;

public partial class cms_system_user_edit : znManage
{
    private string _labelName = "ZS.CMS.Config.System.User";
    private string _pageUrl = "user.aspx";
    private string _defaultPwd = "0|0|0|0";
    private string _action = znEnum.Actions.Add.ToString();
    private int _id = 0;
    private int _curPage;
    private string _property = string.Empty;
    private string _searchWord = string.Empty;

    /// <summary>
    /// 页面初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = znTech.clientName;
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
            FillRole();
            if (this._action == znEnum.Actions.Edit.ToString())
            {
                ChkUserLevel(_labelName, znEnum.Actions.Edit.ToString());
                tbUserName.Attributes.Remove("ajaxurl");
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
        ZS.BLL.znUser bll = new ZS.BLL.znUser();
        ZS.Model.znUser model = bll.GetModel(ID);
        if (model != null)
        {
            ddlPurview.SelectedValue = model.Purview.ToString();
            ddlRoleID.SelectedValue = model.RoleID.ToString();
            tbUserName.Text = model.UserName;
            tbUserPwd.Attributes["value"] = tbCheckPwd.Attributes["value"] = this._defaultPwd;
            rblIsCheck.SelectedValue = model.isCheck.ToString();
            if (model.Purview == 0)
            {
                pnRoleSelect.Visible = false;
            }
        }
    }

    /// <summary>
    /// 所属角色
    /// </summary>
    protected void FillRole()
    {
        ZS.BLL.znRole bll = new ZS.BLL.znRole();
        DataTable dt = bll.GetList("").Tables[0];
        this.ddlRoleID.Items.Clear();
        this.ddlRoleID.Items.Add(new ListItem("请选择", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string ID = dr["ID"].ToString();
            string roleName = dr["RoleName"].ToString().Trim();
            this.ddlRoleID.Items.Add(new ListItem(roleName, ID));
        }
    }

    /// <summary>
    /// 类型控制
    /// </summary>
    protected void ddlPurview_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (znConvert.ObjToInt(ddlPurview.SelectedValue, 0) == 0)
        {
            this.pnRoleSelect.Visible = false;
        }
        else
        {
            this.pnRoleSelect.Visible = true;
        }
    }

    /// <summary>
    /// 提交
    /// </summary>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string reUrl = znUtils.CombUrl(this._pageUrl, "searchWord={0}&propetry={1}&page={2}", this._searchWord.ToString(), this._property.ToString(), this._curPage.ToString());
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
        ZS.BLL.znUser bll = new ZS.BLL.znUser();
        if (bll.Exists(ID, false))
        {
            ZS.Model.znUser model = bll.GetModel(ID);

            model.Purview = znConvert.ObjToInt(ddlPurview.SelectedValue, 0);
            model.UserName = tbUserName.Text.Trim();
            model.RoleID = znConvert.StrToInt(ddlRoleID.SelectedValue, 0);
            model.isCheck = znConvert.StrToInt(rblIsCheck.SelectedValue, 0);
            if (tbUserPwd.Text.Trim() != this._defaultPwd)
            {
                model.UserPwd = znSafe.MD5(tbUserPwd.Text.Trim());
            }

            if (znConvert.ObjToInt(ddlPurview.SelectedValue, 0) == 0)
            {
                model.RoleID = 0;
            }

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
        ZS.BLL.znUser bll = new ZS.BLL.znUser();
        ZS.Model.znUser model = new ZS.Model.znUser();

        model.Purview = znConvert.ObjToInt(ddlPurview.SelectedValue, 0);
        model.UserName = tbUserName.Text.Trim();
        model.UserPwd = znSafe.MD5(tbUserPwd.Text.Trim());
        model.RoleID = znConvert.StrToInt(ddlRoleID.SelectedValue, 0);
        model.isCheck = znConvert.StrToInt(rblIsCheck.SelectedValue, 0);

        if (znConvert.ObjToInt(ddlPurview.SelectedValue, 0) == 0)
        {
            model.RoleID = 0;
        }

        if (bll.Add(model))
        {
            result = true;
        }
        return result;
    }

}