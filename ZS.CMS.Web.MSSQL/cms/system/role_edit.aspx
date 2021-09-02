<%@ Page Language="C#" AutoEventWireup="true" CodeFile="role_edit.aspx.cs" Inherits="cms_system_role_edit" %>

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
            $("#form_category").Validform();
        });
    </script>
</head>
<body class="zs-page">
    <form id="form_category" runat="server">
        <div class="zs-location">
            <a href="javascript:history.back(-1);" class="zs-back"><span>返回上一页</span></a>
            <a href="../main.aspx" class="zs-home"><span>首页</span></a>
            <i class="zs-arrow"></i>
            <span><a href="../system/role.aspx">角色管理</a></span>
            <i class="zs-arrow"></i>
            <span>角色编辑</span>
        </div>
        <div class="zs-line-20"></div>      
        <div class="zs-form-nav">
            <ul id="form-tab">
                <li><a href="javascript:void(0)" class="selected">角色信息</a></li>
            </ul>    
        </div>
        <div class="zs-form-content" id="form-tabs">
            <div class="form-tabs-item">
                <table width="100%" class="zs-form-tab">
                    <tr>
                    <td class="right" width="120">名称</td>
                    <td><asp:TextBox ID="tbRoleName" runat="server" CssClass="zs-input" datatype="*" ajaxurl="/ashx/ajax_check.ashx?action=checkRoleName"></asp:TextBox></td>
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