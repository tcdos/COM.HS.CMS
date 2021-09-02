using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// site_config 的摘要说明
/// </summary>

[Serializable] 
public class site_config
{

    /// <summary>
    /// 构造函数
    /// </summary>
	public site_config()
	{
	}

    /// <summary>
    /// 私有字段
    /// </summary>
    private string _siteName = "";
    private string _siteUrl = "";
    private string _comName = "";
    private string _comAddress = "";
    private string _comTel = "";
    private string _comFax = "";
    private string _comMail = "";
    private string _icp = "";
    private bool _isClose = false;
    private string _closeInfor = "";
    private string _allowExt = "jpeg,jpg,gif,png,bmp,pdf,txt,zip,rar";
    private int _maxUploadSize = 1073741824;
    private bool _isThumbnail = false;
    private int _thumbnailW = 0;
    private int _thumbnailH = 0;
    private string _thumbnailMode = "";
    private bool _editorAuto = true;
    private int _editorMaxW = 700;
    private string _feedbackType = "";
    private string _receiveMail = "";
    private string _postMail = "";
    private string _mailUserName = "";
    private string _mailUserPwd = "";
    private string _smtpHost = "";
    private int _smtpPort = 25;
    private bool _isDown = true;
    private string _allowDownUrl = "";

    /// <summary>
    /// 站点名称
    /// </summary>
    public string siteName
    {
        get { return _siteName; }
        set { _siteName = value; }
    }
    /// <summary>
    /// 站点域名
    /// </summary>
    public string siteUrl
    {
        get { return _siteUrl; }
        set { _siteUrl = value; }
    }
    /// <summary>
    /// 公司名称
    /// </summary>
    public string comName
    {
        get { return _comName; }
        set { _comName = value; }
    }
    /// <summary>
    /// 公司地址
    /// </summary>
    public string comAddress
    {
        get { return _comAddress; }
        set { _comAddress = value; }
    }
    /// <summary>
    /// 公司电话
    /// </summary>
    public string comTel
    {
        get { return _comTel; }
        set { _comTel = value; }
    }
    /// <summary>
    /// 公司传真
    /// </summary>
    public string comFax
    {
        get { return _comFax; }
        set { _comFax = value; }
    }
    /// <summary>
    /// 公司邮箱
    /// </summary>
    public string comMail
    {
        get { return _comMail; }
        set { _comMail = value; }
    }
    /// <summary>
    /// ICP
    /// </summary>
    public string icp
    {
        get { return _icp; }
        set { _icp = value; }
    }
    /// <summary>
    /// 是否关闭站点
    /// </summary>
    public bool isClose
    {
        get { return _isClose; }
        set { _isClose = value; }
    }
    /// <summary>
    /// 关闭说明
    /// </summary>
    public string closeInfor
    {
        get { return _closeInfor; }
        set { _closeInfor = value; }
    }
    /// <summary>
    /// 文件上传类型
    /// </summary>
    public string allowExt
    {
        get { return _allowExt; }
        set { _allowExt = value; }
    }
    /// <summary>
    /// 文件上传大小
    /// </summary>
    public int maxUploadSize
    {
        get { return _maxUploadSize; }
        set { _maxUploadSize = value; }
    }
    /// <summary>
    /// 是否生成缩略图
    /// </summary>
    public bool isThumbnail
    {
        get { return _isThumbnail; }
        set { _isThumbnail = value; }
    }
    /// <summary>
    /// 生成缩略图尺寸[W]
    /// </summary>
    public int thumbnailW
    {
        get { return _thumbnailW; }
        set { _thumbnailW = value; }
    }
    /// <summary>
    /// 生成缩略图尺寸[H]
    /// </summary>
    public int thumbnailH
    {
        get { return _thumbnailH; }
        set { _thumbnailH = value; }
    }
    /// <summary>
    /// 生成缩略图方式
    /// </summary>
    public string thumbnailMode
    {
        get { return _thumbnailMode; }
        set { _thumbnailMode = value; }
    }
    /// <summary>
    /// 编辑器上传是否自动处理尺寸
    /// </summary>
    public bool editorAuto
    {
        get { return _editorAuto; }
        set { _editorAuto = value; }
    }
    /// <summary>
    /// 编辑器上传图片最大宽度
    /// </summary>
    public int editorMaxW
    {
        get { return _editorMaxW; }
        set { _editorMaxW = value; }
    }
    /// <summary>
    /// 留言类型
    /// </summary>
    public string feedbackType
    {
        get { return _feedbackType; }
        set { _feedbackType = value; }
    }
    /// <summary>
    /// 数据同步地址
    /// </summary>
    public string receiveMail
    {
        get { return _receiveMail; }
        set { _receiveMail = value; }
    }
    /// <summary>
    /// 发件人地址
    /// </summary>
    public string postMail
    {
        get { return _postMail; }
        set { _postMail = value; }
    }
    /// <summary>
    /// 邮箱账号
    /// </summary>
    public string mailUserName
    {
        get { return _mailUserName; }
        set { _mailUserName = value; }
    }
    /// <summary>
    /// 邮箱密码
    /// </summary>
    public string mailUserPwd
    {
        get { return _mailUserPwd; }
        set { _mailUserPwd = value; }
    }
    /// <summary>
    /// SMTP服务器
    /// </summary>
    public string smtpHost
    {
        get { return _smtpHost; }
        set { _smtpHost = value; }
    }
    /// <summary>
    /// SMTP端口
    /// </summary>
    public int smtpPort
    {
        get { return _smtpPort; }
        set { _smtpPort = value; }
    }
    /// <summary>
    /// 是否开启防止盗链
    /// </summary>
    public bool isDown
    {
        get { return _isDown; }
        set { _isDown = value; }
    }
    /// <summary>
    /// 允许下载的域名列表
    /// </summary>
    public string allowDownUrl
    {
        get { return _allowDownUrl; }
        set { _allowDownUrl = value; }
    }
}