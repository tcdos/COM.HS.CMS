using System;
using System.Web.UI;
using ZS.KIT;
using ZS.TCDOS;

public partial class cms_system_password : znManage
{
    private string _pageUrl = "password.aspx";

    /// <summary>
    /// 页面初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = znTech.clientName;
        if (!Page.IsPostBack)
        {
            tbManageName.Text = Session["UserName"].ToString();
        }
    }

    /// <summary>
    /// 提交
    /// </summary>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SaveData();
    }

    /// <summary>
    /// 保存
    /// </summary>
    public void SaveData()
    {
        string reUrl = this._pageUrl;
        ZS.BLL.znUser bll = new ZS.BLL.znUser();
        ZS.Model.znUser model = bll.GetModel(znConvert.ObjToInt(Session["UserID"], 0));
        if (znSafe.MD5(tbNewPwd.Text.Trim()) != znSafe.MD5(tbCheckPwd.Text.Trim()))
        {
            znUtils.Redirect("新密码与确认密码不一致！");
            return;
        }
        if (znSafe.MD5(tbOldPwd.Text.Trim()) != model.UserPwd.ToString())
        {
            znUtils.Redirect("旧密码错误，请返回！");
            return;
        }
        model.UserPwd = znSafe.MD5(tbNewPwd.Text.Trim());
        if (bll.Update(model))
        {
            znUtils.Tips(this.Page, "提交成功，请返回！", reUrl);
            Session["UserPwd"] = znSafe.MD5(tbNewPwd.Text.Trim());
            return;
        }
        else
        {
            znUtils.Tips(this.Page, "提交失败，请返回！", reUrl);
            return;
        }
    }
}