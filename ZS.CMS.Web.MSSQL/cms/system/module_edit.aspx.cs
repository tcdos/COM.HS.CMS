using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ZS.KIT;
using ZS.TCDOS;
using System.Collections.Generic;

public partial class cms_system_module_edit : znManage
{
    private string _labelName = "ZS.CMS.Config.System.Module";
    private string _pageUrl = "module.aspx";
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
            FillModule();
            FillAction();
            if (this._action == znEnum.Actions.Edit.ToString())
            {
                ChkUserLevel(_labelName, znEnum.Actions.Edit.ToString());
                FillData(this._id);
                tbLabelName.Attributes.Remove("ajaxurl");
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
    protected void FillModule()
    {
        ZS.BLL.znModule bll = new ZS.BLL.znModule();
        DataTable dt = bll.GetList(0);
        this.ddlModule.Items.Clear();
        this.ddlModule.Items.Add(new ListItem("无父模块", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string ID = dr["ID"].ToString();
            int layer = int.Parse(dr["Layer"].ToString());
            string title = dr["Title"].ToString().Trim();
            if (layer == 1)
            {
                this.ddlModule.Items.Add(new ListItem(title, ID));
            }
            else
            {
                title = "├ " + title;
                title = znUtils.StringOfChar("　", layer - 1) + title;
                this.ddlModule.Items.Add(new ListItem(title, ID));
            }
        }
        if (this._parentID > 0)
        {
            ddlModule.SelectedValue = this._parentID.ToString();
        }
    }
    
    /// <summary>
    /// 操作权限标签
    /// </summary>
    protected void FillAction()
    {
        cblActionList.Items.Clear();
        foreach (KeyValuePair<string, string> kvp in znDict.ActionList())
        {
            cblActionList.Items.Add(new ListItem(kvp.Value + "[" + kvp.Key + "]", kvp.Key));
        }
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    protected void FillData(int ID)
    {
        ZS.BLL.znModule bll = new ZS.BLL.znModule();
        ZS.Model.znModule model = bll.GetModel(ID);
        if (model != null)
        {
            ddlModule.SelectedValue = model.ParentID.ToString();
            tbTitle.Text = model.Title;
            tbLinkUrl.Text = model.LinkUrl;
            tbLabelName.Text = model.LabelName;
            //tbActionList.Text = model.ActionList;
            tbCssName.Text = model.CssName;
            tbSortID.Text = model.SortID.ToString();
            string[] actionArr = model.ActionList.Split(',');
            for (int i = 0; i < cblActionList.Items.Count; i++)
            {
                for (int n = 0; n < actionArr.Length; n++)
                {
                    if (actionArr[n].ToLower() == cblActionList.Items[i].Value.ToLower())
                    {
                        cblActionList.Items[i].Selected = true;
                    }
                }
            }
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
    protected bool DoAdd()
    {
        try
        {
            ZS.BLL.znModule bll = new ZS.BLL.znModule();
            ZS.Model.znModule model = new ZS.Model.znModule();
            model.ParentID = znConvert.StrToInt(ddlModule.SelectedValue, 0);
            model.Title = tbTitle.Text.Trim();
            model.LinkUrl = tbLinkUrl.Text.Trim();
            model.LabelName = tbLabelName.Text.Trim();
            //model.ActionList = tbActionList.Text.Trim();
            model.CssName = tbCssName.Text.Trim();
            model.SortID = znConvert.ObjToInt(tbSortID.Text.Trim(), 0);
            model.Path = string.Empty;
            model.Layer = 1;

            string actionList = string.Empty;
            for (int n = 0; n < cblActionList.Items.Count; n++)
            {
                if (cblActionList.Items[n].Selected == true)
                {
                    actionList += cblActionList.Items[n].Value + ",";
                }
            }
            if (!string.IsNullOrEmpty(actionList))
            {
                model.ActionList = actionList.Trim(',');
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
            ZS.BLL.znModule bll = new ZS.BLL.znModule();
            if (bll.Exists(ID))
            {
                ZS.Model.znModule model = bll.GetModel(ID);
                int parentID = znConvert.StrToInt(ddlModule.SelectedValue, 0);
                model.Title = tbTitle.Text.Trim();
                model.LinkUrl = tbLinkUrl.Text.Trim();
                model.LabelName = tbLabelName.Text.Trim();
                //model.ActionList = tbActionList.Text.Trim();
                model.CssName = tbCssName.Text.Trim();
                model.SortID = znConvert.ObjToInt(tbSortID.Text.Trim(), 0);
                if (parentID != model.ID)
                {
                    model.ParentID = parentID;
                }

                string actionList = string.Empty;
                for (int n = 0; n < cblActionList.Items.Count; n++)
                {
                    if (cblActionList.Items[n].Selected == true)
                    {
                        actionList += cblActionList.Items[n].Value + ",";
                    }
                }
                if (!string.IsNullOrEmpty(actionList))
                {
                    model.ActionList = actionList.Trim(',');
                }

                if (bll.Update(model))
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
        return false;
    }
}