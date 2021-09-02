using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ZS.KIT;
using ZS.TCDOS;

public partial class cms_hr_category_edit : znManage
{
    private string _labelName = "ZS.CMS.Content.HR.Category";
    private int _channelID = 4;
    private string _pageUrl = "category.aspx";
    private string _action = znEnum.Actions.Add.ToString();
    private int _parentID = 0;
    private int _id = 0;

    /// <summary>
    /// 页面初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = znTech.clientName;
        this._id = znRequest.GetQueryInt("id");
        this._parentID = znRequest.GetQueryInt("parentID");
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
        this.ddlCategory.Items.Add(new ListItem("无父类别", ""));
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
        if (this._parentID > 0)
        {
            ddlCategory.SelectedValue = this._parentID.ToString();
        }
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public void FillData(int ID)
    {
        ZS.BLL.znCategory bll = new ZS.BLL.znCategory();
        ZS.Model.znCategory model = bll.GetModel(ID);
        if (model != null)
        {
            ddlCategory.SelectedValue = model.ParentID.ToString();
            tbTitle.Text = model.Title;
            tbLinkUrl.Text = model.LinkUrl;
            if (model.isUrl == 1)
            {
                cbIsUrl.Checked = true;
            }
            tbSortID.Text = model.SortID.ToString();
        }
    }

    /// <summary>
    /// 提交
    /// </summary>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string reUrl = this._pageUrl;
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
    /// 新增
    /// </summary>
    private bool DoAdd()
    {
        try
        {
            ZS.BLL.znCategory bll = new ZS.BLL.znCategory();
            ZS.Model.znCategory model = new ZS.Model.znCategory();
            model.ChannelID = this._channelID;
            model.ParentID = znConvert.StrToInt(ddlCategory.SelectedValue, 0);
            model.Title = tbTitle.Text.Trim();
            model.Path = string.Empty;
            model.Layer = 1;
            model.LinkUrl = tbLinkUrl.Text.Trim();
            model.isUrl = 0;
            model.SortID = znConvert.StrToInt(tbSortID.Text.Trim(), 0);
            if (cbIsUrl.Checked == true)
            {
                model.isUrl = 1;
            }
            if (bll.Add(model))
            {
                return true;
            }
        }
        catch
        {
            return false;
        }
        return false;
    }


    /// <summary>
    /// 编辑
    /// </summary>
    private bool DoEdit(int ID)
    {
        try
        {
            ZS.BLL.znCategory bll = new ZS.BLL.znCategory();
            ZS.Model.znCategory model = bll.GetModel(ID);

            int parentID = znConvert.StrToInt(ddlCategory.SelectedValue, 0);
            model.ChannelID = this._channelID;
            model.Title = tbTitle.Text.Trim();
            model.LinkUrl = tbLinkUrl.Text.Trim();
            model.isUrl = 0;
            model.SortID = int.Parse(tbSortID.Text.Trim());
            if (cbIsUrl.Checked == true)
            {
                model.isUrl = 1;
            }
            if (parentID != model.ID)
            {
                model.ParentID = parentID;
            }
            if (bll.Update(model))
            {
                return true;
            }
        }
        catch
        {
            return false;
        }
        return false;
    }
}