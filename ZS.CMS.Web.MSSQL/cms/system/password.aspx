<%@ Page Language="C#" AutoEventWireup="true" CodeFile="password.aspx.cs" Inherits="cms_system_password" %>

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
          <span><a href="password.aspx">修改密码</a></span>
        </div>
        <div class="zs-line-20"></div>       
        <div class="zs-form-nav">
            <ul id="form-tab">
                <li><a href="javascript:void(0)" class="selected">密码信息</a></li>
            </ul>    
        </div>
        <div class="zs-form-content" id="form-tabs">
            <div class="form-tabs-item">
                <table width="100%" class="zs-form-tab">
                    <tr>
                    <td class="right" width="120">帐号名称</td>
                    <td><asp:TextBox ID="tbManageName" runat="server" CssClass="zs-input" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">旧密码</td>
                    <td><asp:TextBox ID="tbOldPwd" runat="server" TextMode="Password" CssClass="zs-input" datatype="*5-20"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">新密码</td>
                    <td><asp:TextBox ID="tbNewPwd" runat="server" TextMode="Password" CssClass="zs-input" datatype="*5-20"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">确认密码</td>
                    <td><asp:TextBox ID="tbCheckPwd" runat="server" TextMode="Password" CssClass="zs-input" datatype="*5-20"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="zs-line-60"></div>
        <div class="zs-btn-bott"><asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="zs-btn" OnClick="btnSubmit_Click"/></div>         
    </form>
</body>
</html>
