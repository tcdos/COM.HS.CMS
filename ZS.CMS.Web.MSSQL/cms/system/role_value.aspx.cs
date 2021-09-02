using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ZS.KIT;
using ZS.TCDOS;

public partial class cms_system_role_value : znManage
{
    private string _labelName = "ZS.CMS.Config.System.Role";
    private string _pageUrl = "role.aspx";
    private string _action = znEnum.Actions.Edit.ToString();
    private int _id = 0;

    /// <summary>
    /// 页面初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = znTech.clientName;
        this._id = znRequest.GetQueryInt("id");
        string action = znRequest.GetQueryString("action");
        if (action != znEnum.Actions.Edit.ToString() || this._id == 0)
        {
            znUtils.Redirect("参数不正确，请勿随意提交数据！");
        }
        else
        {
            ZS.BLL.znRole bll = new ZS.BLL.znRole();
            if (!bll.Exists(this._id))
            {
                znUtils.Redirect("参数不正确，请勿随意提交数据！");
            }
        }
        if (!Page.IsPostBack)
        {
            ChkUserLevel(_labelName, znEnum.Actions.Edit.ToString());
            GetRoleName(this._id);
            FillModule();
            FillModuleValue(this._id);
        }
    }

    /// <summary>
    /// 角色名称
    /// </summary>
    protected void GetRoleName(int ID)
    {
        ZS.BLL.znRole bll = new ZS.BLL.znRole();
        ZS.Model.znRole model = bll.GetModel(ID);
        if (model != null)
        {
            tbRoleName.Text = model.RoleName;
        }
    }

    /// <summary>
    /// 模块列表
    /// </summary>
    protected void FillModule()
    {
        ZS.BLL.znModule bll = new ZS.BLL.znModule();
        rptList.DataSource = bll.GetList(0);
        rptList.DataBind();
    }

    /// <summary>
    /// TREE结构化
    /// </summary>
    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            //结构化
            Literal litSpan = (Literal)e.Item.FindControl("litSpan");
            TextBox tbLayer = (TextBox)e.Item.FindControl("tbLayer");
            string spanList = "<span style=\"display:inline-block;width:{0}px;\"></span>{1}{2}";
            string treeIcon = "<span class=\"tree-icon\"></span>";
            string treeLine = "<span class=\"tree-line\"></span>";
            int layer = Convert.ToInt32(tbLayer.Text);
            if (layer == 1)
            {
                litSpan.Text = treeIcon;
            }
            else
            {
                litSpan.Text = string.Format(spanList, (layer - 2) * 24, treeLine, treeIcon);
            }
            //模块操作
            CheckBoxList cblActionList = (CheckBoxList)e.Item.FindControl("cblActionList");
            TextBox tbActionList = (TextBox)e.Item.FindControl("tbActionList");
            string[] actionArr = tbActionList.Text.Split(',');
            for (int i = 0; i < actionArr.Length; i++)
            {
                if (znDict.ActionList().ContainsKey(actionArr[i]))
                {
                    cblActionList.Items.Add(new ListItem(" " + znDict.ActionList()[actionArr[i]] + " ", actionArr[i]));
                }
            }
        }
    }

    /// <summary>
    /// 模块绑定
    /// </summary>
    protected void FillModuleValue(int ID)
    {
        ZS.BLL.znRoleValue bll = new ZS.BLL.znRoleValue();
        DataTable dt = bll.GetList(ID).Tables[0];
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int moduleID = Convert.ToInt32(((TextBox)rptList.Items[i].FindControl("tbID")).Text);
            CheckBoxList cblActionList = (CheckBoxList)rptList.Items[i].FindControl("cblActionList");
            DataRow[] dr = dt.Select("ModuleID=" + moduleID);
            if (dr.Length > 0)
            {
                string[] actionArr = dr[0]["ActionList"].ToString().Split(',');
                foreach (string ac in actionArr)
                {
                    for (int n = 0; n < cblActionList.Items.Count; n++)
                    {
                        if (cblActionList.Items[n].Value == ac)
                        {
                            cblActionList.Items[n].Selected = true;
                        }
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
        ChkUserLevel(_labelName, znEnum.Actions.Edit.ToString());
        string reUrl = this._pageUrl;
        if (!DoEdit(this._id))
        {
            znUtils.Tips(this.Page, "提交失败，请返回！", reUrl);
            return;
        }
        znUtils.Tips(this.Page, "提交成功，请返回！", reUrl);
    }

    /// <summary>
    /// 编辑
    /// </summary>
    protected bool DoEdit(int RoleID)
    {
        ZS.BLL.znRoleValue bll = new ZS.BLL.znRoleValue();
        try
        {
            bll.Delete(RoleID);
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int moduleID = Convert.ToInt32(((TextBox)rptList.Items[i].FindControl("tbID")).Text);
                CheckBoxList cblActionList = (CheckBoxList)rptList.Items[i].FindControl("cblActionList");
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
                    ZS.Model.znRoleValue model = new ZS.Model.znRoleValue();
                    model.RoleID = RoleID;
                    model.ModuleID = moduleID;
                    model.ActionList = actionList.Trim(',');
                    bll.Add(model);
                }
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
}