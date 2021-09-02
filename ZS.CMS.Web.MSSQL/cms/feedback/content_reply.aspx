<%@ Page Language="C#" AutoEventWireup="true" CodeFile="content_reply.aspx.cs" Inherits="cms_feedback_content_reply" %>

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
            <span><a href="content.aspx">留言管理</a></span>
            <i class="zs-arrow"></i>
            <span>留言回复</span>
        </div>
        <div class="zs-line-20"></div>
        <div class="zs-form-nav">
            <ul id="form-tab">
                <li><a href="javascript:void(0)" class="selected">留言信息</a></li>
                <li><a href="javascript:void(0)">回复信息</a></li>
            </ul>
        </div>
        <div class="zs-form-content" id="form-tabs">
            <div class="form-tabs-item">
                <table width="100%" class="zs-form-tab">
                    <tr>
                        <td class="right" width="120">姓名</td>
                        <td><asp:TextBox ID="tbAuthor" runat="server" CssClass="zs-input" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="right">联系电话</td>
                        <td><asp:TextBox ID="tbTel" runat="server" CssClass="zs-input" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="right">邮箱</td>
                        <td><asp:TextBox ID="tbEmail" runat="server" CssClass="zs-input" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="right">提交时间</td>
                        <td><asp:TextBox ID="tbPostTime" runat="server" CssClass="zs-input zs-input-date" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="right">提交IP</td>
                        <td><asp:TextBox ID="tbPostIP" runat="server" CssClass="zs-input normal" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="right">类型</td>
                        <td><asp:TextBox ID="tbCategory" runat="server" CssClass="zs-input normal" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="right top">内容</td>
                        <td><asp:TextBox ID="tbContent" runat="server" CssClass="zs-textarea" TextMode="MultiLine" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="right">状态</td>
                        <td>
                            <div class="zs-radiobutton-list">
                                <asp:RadioButtonList ID="rblIsCheck" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Selected="True" Value="1">正常</asp:ListItem>
                                    <asp:ListItem Value="0">待审核</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="form-tabs-item">
                <table width="100%" class="zs-form-tab">
                    <tr>
                        <td class="right top" width="120">回复内容</td>
                        <td><asp:TextBox ID="tbReplyContent" runat="server" CssClass="zs-textarea" TextMode="MultiLine"></asp:TextBox><span class="tip">回复内容会直接发送至用户邮箱，请认真回复</span></td>
                    </tr>
                    <tr>
                        <td class="right">回复人</td>
                        <td><asp:TextBox ID="tbReplyUserName" runat="server" CssClass="zs-input normal" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="right">回复时间</td>
                        <td><asp:TextBox ID="tbReplyTime" runat="server" ReadOnly="true" CssClass="zs-input zs-input-date"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="zs-line-20"></div>
        <div class="zs-btn-bott">
            <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="zs-btn" OnClick="btnSubmit_Click" /></div>
        <div class="zs-line-60"></div>
    </form>
</body>
</html>
