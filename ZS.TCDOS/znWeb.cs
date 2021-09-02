using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ZS.KIT;
using ZS.TCDOS;

/// <summary>
/// 页面加载
/// </summary>
public partial class znWeb : Page
{
    /// <summary>
    /// 委托加载
    /// </summary>
    public znWeb()
    {
        this.Load += new EventHandler(SiteLoad);
    }

    /// <summary>
    /// 站点加载
    /// </summary>
    private void SiteLoad(object sender, EventArgs e)
    {
        //配置
        DataRow dr = SiteConfig().Rows[0];
        //是否关闭站点
        bool isClose = znConvert.StrToBool(dr["isClose"].ToString(), false);
        string closeInfor = dr["closeInfor"].ToString();
        if (isClose == true)
        {
            Response.Redirect("~/tips.aspx?msg=" + closeInfor, true);
        }
        else
        {
            //页面名称
            if (Page.Header != null)
                Page.Title = dr["siteName"].ToString();
            //名称
            Literal litComName = (Literal)Page.FindControl("litComName");
            if (litComName != null)
                litComName.Text = dr["comName"].ToString();
            //地址
            Literal litComAdd = (Literal)Page.FindControl("litComAdd");
            if (litComAdd != null)
                litComAdd.Text = dr["comAddress"].ToString();
            //电话
            Literal litComTel = (Literal)Page.FindControl("litComTel");
            if (litComTel != null)
                litComTel.Text = dr["comTel"].ToString();
            //传真
            Literal litComFax = (Literal)Page.FindControl("litComFax");
            if (litComFax != null)
                litComFax.Text = dr["comFax"].ToString();
            //邮箱
            Literal litcomMail = (Literal)Page.FindControl("litcomMail");
            if (litcomMail != null)
                litcomMail.Text = dr["comMail"].ToString();
            //ICP
            Literal litICP = (Literal)Page.FindControl("litICP");
            if (litICP != null)
                litICP.Text = dr["icp"].ToString();
            //域名
            Literal litSiteUrl = (Literal)Page.FindControl("litSiteUrl");
            if (litSiteUrl != null)
                litSiteUrl.Text = dr["siteUrl"].ToString();
            //技术支持
            Literal litTech = (Literal)Page.FindControl("litTech");
            if (litTech != null)
                litTech.Text = "<a href='" + znTech.systemUrl + "' target='_blank' title='" + znTech.systemAuthor + "'>" + znTech.systemAuthor + "</a>";

        }
    }

    /// <summary>
    /// MOBILE
    /// </summary>
    public void MobileLoad()
    {
        if (!znRequest.IsMobileDevice())
        {
            Response.Redirect("/index");
            Response.End();
        }
    }

    /// <summary>
    /// WEB
    /// </summary>
    public void WebLoad()
    {
        if (znRequest.IsMobileDevice())
        {
            Response.Redirect("/m/index");
            Response.End();
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