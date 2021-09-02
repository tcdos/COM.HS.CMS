using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZS.KIT;
using ZS.TCDOS;

public partial class tips : System.Web.UI.Page
{
    /// <summary>
    /// 页面初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = znTech.clientName.ToString() + "[" + znTech.systemAuthor + "]";
        string msg = znRequest.GetQueryString("msg");
        this.litErrMsg.Text = string.IsNullOrEmpty(msg) ? "网站正在维护中，请稍候访问..." : msg;
        this.litTech.Text = "版权所有：" + znTech.clientName + " - 技术支持：<a href=\"" + znTech.systemUrl + "\" target=\"_blank\">" + znTech.systemAuthor + "</a>";
    }
}