using System;
using ZS.KIT;
using ZS.TCDOS;

public partial class cms_error : znManage
{   
    /// <summary>
    /// 页面初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = znTech.clientName;
        string msg = string.IsNullOrEmpty(znRequest.GetQueryString("msg").ToString().Trim()) ? "系统发生未知错误，请勿随意提交数据！" : znRequest.GetQueryString("msg").ToString().Trim();
        this.litErrMsg.Text = msg;
    }
}