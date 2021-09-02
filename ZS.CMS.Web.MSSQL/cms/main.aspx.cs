using System;
using System.Web.UI;
using ZS.KIT;
using ZS.TCDOS;


public partial class cms_main : znManage
{
    /// <summary>
    /// 页面初始
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Page.Title = znTech.clientName;
            this.ltClient.Text = znTech.clientName;
            this.ltZSCMSVer.Text = znTech.systemVersion;
            this.ltZSCMSTech.Text = "<a href='" + znTech.systemUrl + "' target='_blank' title='" + znTech.systemAuthor + "'>" + znTech.systemAuthor + "</a>";
            this.ltLoginIP.Text = znRequest.GetIP();

            ZS.BLL.znLog bll = new ZS.BLL.znLog();
            ZS.Model.znLog model = bll.GetModel(Session["UserName"].ToString());
            if (model != null)
            {
                this.ltLastLoginTime.Text = model.LoginTime;
                this.ltLastLoginIP.Text = model.LoginIP;
            }
            else
            {
                this.ltLastLoginTime.Text = "-";
                this.ltLastLoginIP.Text = "-";
            }
        }
    }

}