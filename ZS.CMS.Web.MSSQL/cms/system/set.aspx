<%@ Page Language="C#" AutoEventWireup="true" CodeFile="set.aspx.cs" Inherits="cms_system_set" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <title></title>
    <link href="/style/init.css" rel="stylesheet" />
    <link href="/style/plugin.css" rel="stylesheet" />
    <link href="../style/zscms.css" rel="stylesheet" />
    <link href="/js/artdialog/ui-dialog.css" rel="stylesheet" />
    <script src="/js/jquery/jquery-1.7.2.min.js"></script>
    <script src="/js/jquery/jquery.validate.js"></script>
    <script src="/js/artdialog/dialog-plus-min.js"></script>
    <script src="/js/jquery/jquery.zsui.web.js"></script>
    <script src="../js/zscms.js"></script>
    <script type="text/javascript">
        $(function () {
            //表单检测
            $("#form_content").Validform();
        })
    </script>
</head>
<body class="zs-page">
    <form id="form_content" runat="server">
        <div class="zs-location">
          <a href="javascript:history.back(-1);" class="zs-back"><span>返回上一页</span></a>
          <a href="../main.aspx" class="zs-home"><span>首页</span></a>
          <i class="zs-arrow"></i>
          <span>系统设置</span>
        </div>
        <div class="zs-line-20"></div>       
        <div class="zs-form-nav">
            <ul id="form-tab">
                <li><a href="javascript:void(0)" class="selected">网站信息</a></li>
                <li><a href="javascript:void(0)">下载设置</a></li>
                <li><a href="javascript:void(0)">文件上传</a></li>
                <li><a href="javascript:void(0)">留言设置</a></li>
                
            </ul>    
        </div>
        <div class="zs-form-content" id="form-tabs">
            <div class="form-tabs-item">
                <table width="100%" class="zs-form-tab">
                    <tr>
                    <td class="right" width="120">网站名称</td>
                    <td><asp:TextBox ID="tbSiteName" runat="server" CssClass="zs-input" datatype="*"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">网站域名</td>
                    <td><asp:TextBox ID="tbSiteUrl" runat="server" CssClass="zs-input" datatype="*"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">公司名称</td>
                    <td><asp:TextBox ID="tbComName" runat="server" CssClass="zs-input" datatype="*"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">地址</td>
                    <td><asp:TextBox ID="tbComAddress" runat="server" CssClass="zs-input" datatype="*"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">电话</td>
                    <td><asp:TextBox ID="tbComTel" runat="server" CssClass="zs-input normal" datatype="*"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">传真</td>
                    <td><asp:TextBox ID="tbComFax" runat="server" CssClass="zs-input normal" datatype="*"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">邮箱</td>
                    <td><asp:TextBox ID="tbComMail" runat="server" CssClass="zs-input" datatype="e"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">网站备案号</td>
                    <td><asp:TextBox ID="tbICP" runat="server" CssClass="zs-input" datatype="*"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">是否关闭网站</td>
                    <td><div class="zs-single-checkbox"><asp:CheckBox ID="cbIsClose" Checked="true" runat="server"/></div></td>
                    </tr>
                    <tr>
                    <td class="right top">关闭原因</td>
                    <td><asp:TextBox ID="tbCloseInfor" runat="server" CssClass="zs-textarea" TextMode="MultiLine" datatype="*"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
            <div class="form-tabs-item">
                <table width="100%" class="zs-form-tab">
                    <tr>
                    <td class="right" width="120">是否开启防止盗链</td>
                    <td><div class="zs-single-checkbox"><asp:CheckBox ID="cbIsDown" Checked="true" runat="server"/></div></td>
                    </tr>
                    <tr>
                    <td class="right">允许下载的域名</td>
                    <td><asp:TextBox ID="tbAllowDwonUrl" runat="server" CssClass="zs-input" datatype="*"></asp:TextBox><span class="tip">以英文的逗号分隔开，如：“tcdos.com”</span></td>
                    </tr>
                </table>
            </div>
            <div class="form-tabs-item">
                <table width="100%" class="zs-form-tab">
                    <tr>
                    <td class="right" width="120">文件上传类型</td>
                    <td><asp:TextBox ID="tbAllowExt" runat="server" CssClass="zs-input long" datatype="*"></asp:TextBox><span class="tip">以英文的逗号分隔开，如：“zip,rar”</span></td>
                    </tr>
                    <tr>
                    <td class="right">文件上传大小</td>
                    <td><asp:TextBox ID="tbMaxUploadSize" runat="server" CssClass="zs-input normal" datatype="*"></asp:TextBox><span class="tip">KB 超过设定的文件大小不允许上传</span></td>
                    </tr>
                    <tr>
                    <td class="right">是否生成缩略图</td>
                    <td><div class="zs-single-checkbox"><asp:CheckBox ID="cbIsThumbnail" Checked="true" runat="server"/></div></td>
                    </tr>
                    <tr>
                    <td class="right">生成缩略图尺寸[宽度]</td>
                    <td><asp:TextBox ID="tbThumbnailW" runat="server" CssClass="zs-input normal" datatype="*"></asp:TextBox><span class="tip">px</span></td>
                    </tr>
                    <tr>
                    <td class="right">生成缩略图尺寸[高度]</td>
                    <td><asp:TextBox ID="tbThumbnailH" runat="server" CssClass="zs-input normal" datatype="*"></asp:TextBox><span class="tip">px</span></td>
                    </tr>
                    <tr>
                    <td class="right">生成缩略图方式</td>
                    <td><div class="zs-dropdown-list"><asp:DropDownList ID="ddlThumbnailMode" runat="server" datatype="*"><asp:ListItem Value="" Selected="True">请选择类型</asp:ListItem><asp:ListItem Value="hw">指定高宽缩放[可能变形]</asp:ListItem><asp:ListItem Value="w">指定宽，高按比例</asp:ListItem><asp:ListItem Value="h">指定高，宽按比例</asp:ListItem><asp:ListItem Value="cut">指定高宽裁减[不变形,推荐]</asp:ListItem></asp:DropDownList></div></td>
                    </tr>
                    <tr>
                    <td class="right">附件图片是否处理尺寸</td>
                    <td><div class="zs-single-checkbox"><asp:CheckBox ID="cbEditorAuto" Checked="true" runat="server"/></div><span class="tip">开启后编辑器上传附件图片会自动处理尺寸，防止撑破页面布局。建议开启。</span></td>
                    </tr>
                    <tr>
                    <td class="right">附件图片最大宽度</td>
                    <td><asp:TextBox ID="tbEditorMaxW" runat="server" CssClass="zs-input normal" datatype="*"></asp:TextBox><span class="tip">px</span></td>
                    </tr>
                </table>
            </div>
            <div class="form-tabs-item">
                <table width="100%" class="zs-form-tab">
                    <tr>
                    <td class="right" width="120">留言类型</td>
                    <td><asp:TextBox ID="tbFeedbackType" runat="server" CssClass="zs-input" datatype="*"></asp:TextBox><span class="tip">多种类型请以|分隔开，如：“业务咨询|投诉建议|其他”</span></td>
                    </tr>
                    <tr>
                    <td class="right">同步邮箱地址</td>
                    <td><asp:TextBox ID="tbReceiveMail" runat="server" CssClass="zs-input" datatype="*"></asp:TextBox><span class="tip">多个地址请以英文的逗号分隔开，如：“example@163.com”</span></td>
                    </tr>
                    <tr>
                    <td class="right">发件人地址</td>
                    <td><asp:TextBox ID="tbPostMail" runat="server" CssClass="zs-input" datatype="*"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">邮箱账号</td>
                    <td><asp:TextBox ID="tbMailUserName" runat="server" CssClass="zs-input" datatype="*"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">邮箱密码</td>
                    <td><asp:TextBox ID="tbMailUserPwd" TextMode="Password" runat="server" CssClass="zs-input" datatype="*"></asp:TextBox><asp:TextBox ID="tbOldMailUserPwd" runat="server" Visible="false"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">SMTP服务器</td>
                    <td><asp:TextBox ID="tbSmtpHost" runat="server" CssClass="zs-input normal" datatype="*"></asp:TextBox><span class="tip">发送邮件的SMTP服务器地址</span></td>
                    </tr>
                    <tr>
                    <td class="right">SMTP端口</td>
                    <td><asp:TextBox ID="tbSmtpPort" runat="server" CssClass="zs-input normal" datatype="*"></asp:TextBox><span class="tip">SMTP服务器的端口，大部分服务商都支持25端口</span></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="zs-line-20"></div>
        <div class="zs-btn-bott"><asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="zs-btn" OnClick="btnSubmit_Click"/></div> 
        <div class="zs-line-60"></div>          
    </form>
</body>
</html>