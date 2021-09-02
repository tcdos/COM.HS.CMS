<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_edit.aspx.cs" Inherits="cms_system_user_edit" %>

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
          <span><a href="user.aspx">管理员管理</a></span>
          <i class="zs-arrow"></i>
          <span>管理员编辑</span>
        </div>
        <div class="zs-line-20"></div>       
        <div class="zs-form-nav">
            <ul id="form-tab">
                <li><a href="javascript:void(0)" class="selected">用户信息</a></li>
            </ul>    
        </div>
        <div class="zs-form-content" id="form-tabs">
            <div class="form-tabs-item">
                <table width="100%" class="zs-form-tab">
                    <tr>
                    <td class="right" width="120">类型</td>
                    <td>
                        <div class="zs-dropdown-list"><asp:DropDownList ID="ddlPurview" runat="server"  datatype="*" OnSelectedIndexChanged="ddlPurview_SelectedIndexChanged" AutoPostBack="true"><asp:ListItem Value="" Selected="True">请选择类型</asp:ListItem><asp:ListItem Value="1">系统用户</asp:ListItem><asp:ListItem Value="0">超级用户</asp:ListItem></asp:DropDownList></div>
                    </td>
                    </tr>
                    <asp:Panel runat="server" ID="pnRoleSelect">
                    <tr>
                    <td class="right">所属角色</td>
                    <td>
                        <div class="zs-dropdown-list"><asp:DropDownList ID="ddlRoleID" runat="server" datatype="*"></asp:DropDownList></div>
                    </td>
                    </tr>
                    </asp:Panel>
                    <tr>
                    <td class="right">帐号</td>
                    <td><asp:TextBox ID="tbUserName" runat="server" CssClass="zs-input" datatype="*2-100" ajaxurl="/ashx/ajax_check.ashx?action=checkUserName"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">登录密码</td>
                    <td><asp:TextBox ID="tbUserPwd" runat="server" TextMode="Password" CssClass="zs-input" datatype="*5-20"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">确认密码</td>
                    <td><asp:TextBox ID="tbCheckPwd" runat="server" TextMode="Password" CssClass="zs-input" datatype="*5-20" recheck="tbUserPwd"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">是否启用</td>
                    <td><div class="zs-radiobutton-list">
                        <asp:RadioButtonList ID="rblIsCheck" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Selected="True" Value="1">启用</asp:ListItem>
                            <asp:ListItem Value="0">禁用</asp:ListItem>
                        </asp:RadioButtonList>
                        </div></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="zs-line-20"></div>
        <div class="zs-btn-bott"><asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="zs-btn" OnClick="btnSubmit_Click" /></div>
        <div class="zs-line-60"></div>           
    </form>
</body>
</html>
