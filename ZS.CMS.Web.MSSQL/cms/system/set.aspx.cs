using System;
using System.Web.UI;
using ZS.KIT;
using ZS.TCDOS;

public partial class cms_system_set : znManage
{
    private string _labelName = "ZS.CMS.Config.System.Set";
    private string _pageUrl = "set.aspx";
    private string _defaultPwd = "0|0|0|0";

    /// <summary>
    /// 页面初始化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = znTech.clientName;
        if (!Page.IsPostBack)
        {
            ChkUserLevel(_labelName, znEnum.Actions.Edit.ToString());
            FillData();
        }
    }

    
    /// <summary>
    /// 数据绑定
    /// </summary>
    public void FillData()
    {
        site_config sc = (site_config)znResialization.Load(typeof(site_config), znUtils.GetXmlMapPath("configPath"));
        tbSiteName.Text = sc.siteName;
        tbSiteUrl.Text = sc.siteUrl;
        tbComName.Text = sc.comName;
        tbComAddress.Text = sc.comAddress;
        tbComTel.Text = sc.comTel;
        tbComFax.Text = sc.comFax;
        tbComMail.Text = sc.comMail;
        tbICP.Text = sc.icp;
        cbIsClose.Checked = sc.isClose;
        tbCloseInfor.Text = sc.closeInfor;
        tbAllowExt.Text = sc.allowExt;
        tbMaxUploadSize.Text = Convert.ToString(sc.maxUploadSize / 1024);
        cbIsThumbnail.Checked = sc.isThumbnail;
        tbThumbnailW.Text = sc.thumbnailW.ToString();
        tbThumbnailH.Text = sc.thumbnailH.ToString();
        ddlThumbnailMode.SelectedValue = sc.thumbnailMode;
        cbEditorAuto.Checked = sc.editorAuto;
        tbEditorMaxW.Text = sc.editorMaxW.ToString();
        tbFeedbackType.Text = sc.feedbackType.ToString();
        tbReceiveMail.Text = sc.receiveMail.ToString();
        tbPostMail.Text = sc.postMail;
        tbMailUserName.Text = sc.mailUserName;
        if (!string.IsNullOrEmpty(sc.mailUserPwd))
        {
            tbMailUserPwd.Attributes["value"] = this._defaultPwd;
            tbOldMailUserPwd.Text = sc.mailUserPwd;
        }
        tbSmtpHost.Text = sc.smtpHost;
        tbSmtpPort.Text = sc.smtpPort.ToString();
        cbIsDown.Checked = sc.isDown;
        tbAllowDwonUrl.Text = sc.allowDownUrl;
    }

    /// <summary>
    /// 提交
    /// </summary>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ChkUserLevel(_labelName, znEnum.Actions.Edit.ToString());
        SaveData();
    }

    /// <summary>
    /// 保存
    /// </summary>
    public void SaveData()
    {
        string reUrl = this._pageUrl;
        site_config sc = new site_config();
        sc.siteName = tbSiteName.Text.Trim();
        sc.siteUrl = tbSiteUrl.Text.Trim();
        sc.comName = tbComName.Text.Trim();
        sc.comAddress = tbComAddress.Text.Trim();
        sc.comTel = tbComTel.Text.Trim();
        sc.comFax = tbComFax.Text.Trim();
        sc.comMail = tbComMail.Text.Trim();
        sc.icp = tbICP.Text.Trim();
        sc.isClose = cbIsClose.Checked;
        sc.closeInfor = tbCloseInfor.Text.Trim();
        sc.allowExt = tbAllowExt.Text.Trim();
        sc.maxUploadSize = Convert.ToInt32(tbMaxUploadSize.Text.Trim()) * 1024;
        sc.isThumbnail = cbIsThumbnail.Checked;
        sc.thumbnailW = Convert.ToInt32(tbThumbnailW.Text.Trim());
        sc.thumbnailH = Convert.ToInt32(tbThumbnailH.Text.Trim());
        sc.thumbnailMode = ddlThumbnailMode.SelectedValue.ToString();
        sc.editorAuto = cbEditorAuto.Checked;
        sc.editorMaxW = Convert.ToInt32(tbEditorMaxW.Text.Trim());
        sc.feedbackType = tbFeedbackType.Text.Trim();
        sc.receiveMail = tbReceiveMail.Text.Trim();
        sc.postMail = tbPostMail.Text.Trim();
        sc.mailUserName = tbMailUserName.Text.Trim();
        if (tbMailUserPwd.Text.Trim() != this._defaultPwd)
        {
            sc.mailUserPwd = znSafe.Encrypt(tbMailUserPwd.Text.Trim(), "tcdosCOM");
        }
        else
        {
            sc.mailUserPwd = tbOldMailUserPwd.Text.Trim();
        }
        sc.smtpHost = tbSmtpHost.Text.Trim();
        sc.smtpPort = Convert.ToInt32(tbSmtpPort.Text.Trim());
        sc.isDown = cbIsDown.Checked;
        sc.allowDownUrl = tbAllowDwonUrl.Text.Trim();
        znResialization.Save(sc, znUtils.GetXmlMapPath("configPath"));
        znUtils.Tips(this.Page, "提交成功，请返回！", reUrl);
    }

}