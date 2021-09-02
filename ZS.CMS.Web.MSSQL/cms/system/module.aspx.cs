using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZS.KIT;
using ZS.TCDOS;

public partial class cms_system_module : znManage
{
    private string _labelName = "ZS.CMS.Config.System.Module";
    private string _pageUrl = "module.aspx";

    /// <summary>
    /// 页面初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = znTech.clientName;
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
        ZS.BLL.znModule bll = new ZS.BLL.znModule();
        rptList.DataSource = bll.GetList(0);
        rptList.DataBind();
    }

    /// <summary>
    /// 数据处理
    /// </summary>
    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            //TREE
            Literal litSpan = (Literal)e.Item.FindControl("litSpan");
            int layer = znConvert.ObjToInt(DataBinder.Eval(e.Item.DataItem, "Layer"), 0);
            string spanList = "<span style=\"display:inline-block;width:{0}px;\"></span>{1}{2}";
            string treeIcon = "<span class=\"tree-icon\"></span>";
            string treeLine = "<span class=\"tree-line\"></span>";
            if (layer == 1)
                litSpan.Text = treeIcon;
            else
                litSpan.Text = string.Format(spanList, (layer - 2) * 24, treeLine, treeIcon);
            //LINK
            HyperLink hlAdd = (HyperLink)e.Item.FindControl("hlAdd");
            HyperLink hlEdit = (HyperLink)e.Item.FindControl("hlEdit");
            int id = znConvert.ObjToInt(DataBinder.Eval(e.Item.DataItem, "ID"), 0);
            hlEdit.NavigateUrl = znUtils.CombUrl("module_edit.aspx", "action={0}&ID={1}", znEnum.Actions.Edit.ToString(), id.ToString());
            hlAdd.NavigateUrl = znUtils.CombUrl("module_edit.aspx", "action={0}&parentID={1}", znEnum.Actions.Add.ToString(), id.ToString());
            //模块操作
            Literal litActions = (Literal)e.Item.FindControl("litActions");
            TextBox tbActionList = (TextBox)e.Item.FindControl("tbActionList");
            string[] actionArr = tbActionList.Text.Split(',');
            string actions = string.Empty;
            for (int i = 0; i < actionArr.Length; i++)
            {
                if (znDict.ActionList().ContainsKey(actionArr[i]))
                {
                    actions += znDict.ActionList()[actionArr[i]] + "<i class='line'></i>";
                }
            }
            litActions.Text = actions;
        }
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void lbDel_Click(object sender, EventArgs e)
    {
        string reUrl = this._pageUrl;
        ChkUserLevel(_labelName, znEnum.Actions.Delete.ToString());
        foreach (RepeaterItem Item in rptList.Items)
        {
            CheckBox cb = (CheckBox)Item.FindControl("cbID");
            TextBox tb = (TextBox)Item.FindControl("tbID");
            int ID = znConvert.StrToInt(tb.Text.ToString(), 0);
            ZS.BLL.znModule bll = new ZS.BLL.znModule();
            if (cb.Checked)
            {
                bll.Delete(ID);
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
        Response.Redirect("module_edit.aspx?action=" + znEnum.Actions.Add.ToString());
    }
}