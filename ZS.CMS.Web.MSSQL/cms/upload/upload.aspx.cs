using System;
using System.Web.UI;
using System.Xml;
using ZS.KIT;
using ZS.TCDOS;

public partial class tool_upload : znManage
{
    private string _type = string.Empty;
    private string _controlID = string.Empty;
    private bool _isThumbnail;
    private int _w;
    private int _h;
    private string _mode = string.Empty;
    private bool _delOriginalImage;
    private bool _backThumbnailUrl;
    private bool _backAllInfor = false;

    /// <summary>
    /// 页面初始化
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        //上传配置
        bool isThumbnail = false;
        int thumbnailW = 0;
        int thumbnailH = 0;
        string thumbnailMode = string.Empty;
        XmlDocument xmlDoc = new XmlDocument();
        try
        {
            xmlDoc.Load(znUtils.GetXmlMapPath("configPath"));
            XmlNode root = xmlDoc.SelectSingleNode("//site_config");
            isThumbnail = znConvert.StrToBool((root.SelectSingleNode("isThumbnail")).InnerText, false); //是否生成缩略图
            thumbnailW = znConvert.StrToInt((root.SelectSingleNode("thumbnailW")).InnerText, 120); // 缩略图宽度
            thumbnailH = znConvert.StrToInt((root.SelectSingleNode("thumbnailH")).InnerText, 90); //缩略图高度
            thumbnailMode = (root.SelectSingleNode("thumbnailMode")).InnerText; //切图方式
        }
        catch (Exception ex)
        {
            znUtils.Redirect("上传配置出错，请返回！");
            Response.End();
        }
        this._type = znRequest.GetQueryString("type"); //上传类型：单文件+多文件
        this._controlID = znRequest.GetQueryString("controlID"); //获取文件路径的控件ID
        this._isThumbnail = znConvert.StrToBool(znRequest.GetQueryString("isThumbnail"), isThumbnail); //是否生成缩略图
        this._w = znRequest.GetQueryInt("W", thumbnailW); // 缩略图宽度
        this._h = znRequest.GetQueryInt("H", thumbnailH); //缩略图高度
        this._mode = string.IsNullOrEmpty(znRequest.GetQueryString("mode")) ? thumbnailMode : znRequest.GetQueryString("mode"); //切图方式
        this._delOriginalImage = znConvert.StrToBool(znRequest.GetQueryString("delOriginalImage"), true); //是否删除原文件
        this._backThumbnailUrl = znConvert.StrToBool(znRequest.GetQueryString("backThumbnailUrl"), true); //是否返回缩略图文件路径
        this._backAllInfor = znConvert.StrToBool(znRequest.GetQueryString("backAllInfor"), false); //是否返回完整上传信息：路径+大小+格式

    }

    /// <summary>
    /// 上传
    /// </summary>
    protected void lbUpload_Click(object sender, EventArgs e)
    {
        znUpload up = new znUpload();
        string data = up.SaveFile(filePath.PostedFile, this._isThumbnail, this._w, this._h, this._mode, this._delOriginalImage, this._backThumbnailUrl);
        string msbox = "parent.uploadBack('" + this._type + "','" + this._controlID + "', '" + this._backAllInfor.ToString().ToLower() + "', '" + data + "')"; //脚本内容
        ClientScript.RegisterClientScriptBlock(Page.GetType(), "uploadBack", msbox, true); //注册脚本
    }
}