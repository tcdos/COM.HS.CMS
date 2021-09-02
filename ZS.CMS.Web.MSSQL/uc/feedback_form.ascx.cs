using System;
using System.Data;
using System.Web.UI;
using ZS.KIT;

public partial class uc_feedback_form : System.Web.UI.UserControl
{
    /// <summary>
    /// 控件初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataRow dr = SiteConfig().Rows[0];
            string[] feedbackType = dr["feedbackType"].ToString().Split('|'); 
            rblCategory.DataSource = feedbackType;
            rblCategory.SelectedValue = feedbackType[0];
            rblCategory.DataBind();
        }
    }

    /// <summary>
    /// 提交数据
    /// </summary>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        string category = rblCategory.SelectedValue.ToString().Trim();
        string author = tbUserName.Text.Trim();
        string content = tbContent.Text.Trim();
        string tel = tbTel.Text.Trim();
        string email = tbEmail.Text.Trim();

        if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(content) || string.IsNullOrEmpty(tel) || string.IsNullOrEmpty(email))
        {
            Response.Redirect("~/tips.aspx?msg=您输入的信息不完整，请返回！", true);
        }

        ZS.BLL.znFeedback bll = new ZS.BLL.znFeedback();
        ZS.Model.znFeedback model = new ZS.Model.znFeedback();
        model.MemberID = 0;
        model.Category = znUtils.FilterStr(category);
        model.Author = znUtils.FilterStr(author);
        model.Content = znUtils.ToTxt(znUtils.FilterStr(content));
        model.Tel = znUtils.FilterStr(tel);
        model.Email = znUtils.FilterStr(email);
        model.PostIP = znRequest.GetIP().ToString();
        model.PostTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        model.isCheck = 0;

        if (bll.Add(model))
        {
            string mailContent = string.Empty;
            mailContent += "<b>类型：</b>" + znUtils.FilterHtml(category) + "<br/>";
            mailContent += "<b>姓名：</b>" + znUtils.FilterHtml(author) + "<br/>";
            mailContent += "<b>电话：</b>" + znUtils.FilterHtml(tel) + "<br/>";
            mailContent += "<b>邮箱：</b>" + znUtils.FilterHtml(email) + "<br/>";
            mailContent += "<b>内容：</b>" + znUtils.FilterHtml(content) + "<br/>";

            DataRow dr = SiteConfig().Rows[0];
            string receiveMail = dr["receiveMail"].ToString();
            string postMail = dr["postMail"].ToString();
            string mailUserName = dr["mailUserName"].ToString();
            string mailUserPwd = dr["mailUserPwd"].ToString();
            string smtpHost = dr["smtpHost"].ToString();
            int smtpPort = znConvert.ObjToInt(dr["smtpPort"], 0);
            if (!string.IsNullOrEmpty(receiveMail))
            {
                string[] receiveMailList = receiveMail.Split(',');
                foreach (string receiveMailItem in receiveMailList)
                {
                    try
                    {
                        znMail.sendMail(receiveMailItem, "来自" + dr["siteName"].ToString() + "官方网站的留言信息[请勿回复此邮件]", mailContent, "", postMail, mailUserName, znSafe.Decrypt(mailUserPwd, "tcdosCOM"), smtpHost, smtpPort);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            znUtils.Alert("提交成功，请勿重复提交！", znRequest.GetUrl());
        }
        else
        {
            znUtils.Alert("提交失败，请稍后再提交！", znRequest.GetUrl());
        }
    }


    /// <summary>
    /// 站点设置
    /// </summary>
    public DataTable SiteConfig()
    {
        DataSet ds = new DataSet();
        DataTable dt;
        int isCache = znConvert.ObjToInt(znConfig.GetConfigInt("isCache"), 0);
        if (isCache == 0)
        {
            ds.ReadXml(znUtils.GetXmlMapPath("configPath"));
            dt = ds.Tables[0];
        }
        else
        {
            string CacheKey = "znSiteConfig";
            object siteConfig = znCache.GetCache(CacheKey);
            if (siteConfig == null)
            {
                try
                {
                    ds.ReadXml(znUtils.GetXmlMapPath("configPath"));
                    siteConfig = ds;
                    if (siteConfig != null)
                    {
                        int CacheTime = znConfig.GetConfigInt("CacheTime");
                        znCache.SetCache(CacheKey, siteConfig, DateTime.Now.AddMinutes(CacheTime), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            dt = (DataTable)siteConfig;
        }
        if (dt != null)
        {
            return dt;
        }
        else
        {
            return null;
        }
    }
}