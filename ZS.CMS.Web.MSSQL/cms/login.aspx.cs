using System;
using System.Web.UI;
using ZS.KIT;
using ZS.TCDOS;

public partial class cms_login : System.Web.UI.Page
{
    private string _action = string.Empty;
    int _userID = 0;

    /// <summary>
    /// 页面初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = znTech.clientName;
        this._action = znRequest.GetQueryString("action", true);
        this._userID = znRequest.GetQueryInt("userID");
        if (!Page.IsPostBack)
        {
            if (this._action.ToLower() == "exit")
            {
                Logout(this._userID);
            }
        }

    }

    /// <summary>
    /// 登录
    /// </summary>
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        CheckLogin();
    }

    /// <summary>
    /// 登录核查
    /// </summary>
    protected void CheckLogin()
    {
        string userName = tbUserName.Text.Trim();
        string userPwd = tbUserPwd.Text.Trim();

        if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userPwd))
        {
            msg.InnerText = "请输入帐号与密码！";
            return;
        }

        if (Session["LoginErr"] == null)
        {
            Session["LoginErr"] = 1;
        }
        else
        {
            Session["LoginErr"] = Convert.ToInt32(Session["LoginErr"]) + 1;
        }
        if (Session["LoginErr"] != null && Convert.ToInt32(Session["LoginErr"]) > 5)
        {
            msg.InnerText = "登录信息错误超过5次，请关闭浏览器重新登录！";
            return;
        }

        if (!znSafe.IsSafeStr(userName))
        {
            msg.InnerText = "您输入的帐号含有非法字符，请勿随意提交数据！";
            return;
        }
        userName = znUtils.FilterHtml(userName);
        userPwd = znSafe.MD5(userPwd);
        ZS.BLL.znUser bll = new ZS.BLL.znUser();
        ZS.Model.znUser model = bll.GetModel(userName, userPwd);
        if (model == null)
        {
            msg.InnerText = "您输入的帐号与密码错误，请重新输入！";
            new ZS.BLL.znLog().Add(userName, "登录失败：帐号与密码错误");
            return;
        }
        else
        {
            Session["UserID"] = model.ID;
            Session["UserName"] = model.UserName;
            Session["UserPwd"] = model.UserPwd;
            Session["UserPurview"] = model.Purview;
            new ZS.BLL.znLog().Add(model.UserName, "登录成功");
            Response.Redirect("index.aspx", true);
            Response.End();
        }
    }

    /// <summary>
    /// 注销登录
    /// </summary>
    protected void Logout(int userID)
    {
        //清空缓存
        znCache.ClearCache();
        //释放Session
        Session["UserID"] = null;
        Session["UserName"] = null;
        Session["UserPwd"] = null;
        Session["UserPurview"] = null;
        Session.Abandon();
        Response.Redirect("login.aspx");
    }
}