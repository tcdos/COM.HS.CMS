using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZS.KIT;
using ZS.TCDOS;

public partial class cms_product_category : znManage
{
    private string _labelName = "ZS.CMS.Content.Product.Category";
    private int _channelID = 2;
    private string _pageUrl = "category.aspx";

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
        ZS.BLL.znCategory bll = new ZS.BLL.znCategory();
        rptList.DataSource = bll.GetList(0, this._channelID);
        rptList.DataBind();
    }

    /// <summary>
    /// TREE结构化
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
            hlEdit.NavigateUrl = znUtils.CombUrl("category_edit.aspx", "action={0}&ID={1}", znEnum.Actions.Edit.ToString(), id.ToString());
            hlAdd.NavigateUrl = znUtils.CombUrl("category_edit.aspx", "action={0}&parentID={1}", znEnum.Actions.Add.ToString(), id.ToString());

        }
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void lbDel_Click(object sender, EventArgs e)
    {
        ChkUserLevel(_labelName, znEnum.Actions.Delete.ToString());
        string reUrl = this._pageUrl;
        foreach (RepeaterItem Item in rptList.Items)
        {
            CheckBox cb = (CheckBox)Item.FindControl("cbID");
            TextBox tb = (TextBox)Item.FindControl("tbID");
            int ID = znConvert.StrToInt(tb.Text.ToString(), 0);
            ZS.BLL.znCategory bll = new ZS.BLL.znCategory();
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
        Response.Redirect("category_edit.aspx?action=" + znEnum.Actions.Add.ToString());
    }
}