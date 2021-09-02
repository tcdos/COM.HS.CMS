<%@ Page Language="C#" AutoEventWireup="true" CodeFile="resume_edit.aspx.cs" Inherits="cms_hr_resume_edit" %>

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
            <span><a href="employ.aspx">招聘计划</a></span>
            <i class="zs-arrow"></i>
            <span><a href="resume.aspx">应聘简历</a></span>
            <i class="zs-arrow"></i>
            <span>编辑简历</span>
        </div>
        <div class="zs-line-20"></div>       
        <div class="zs-form-nav">
            <ul id="form-tab">
                <li><a href="javascript:void(0)" class="selected">简历信息</a></li>
            </ul>    
        </div>
        <div class="zs-form-content" id="form-tabs">
            <div class="form-tabs-item">
                <table width="100%" class="zs-form-tab">
                    <tr>
                    <td class="right" width="120">应聘职位</td>
                    <td><asp:TextBox ID="tbPosition" runat="server" CssClass="zs-input" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">姓名</td>
                    <td><asp:TextBox ID="tbAuthor" runat="server" CssClass="zs-input normal" datatype="*2-100"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">性别</td>
                    <td><div class="zs-dropdown-list"><asp:DropDownList ID="ddlSex" runat="server"><asp:ListItem Value="" Selected="True">请选择性别</asp:ListItem><asp:ListItem Value="男">男</asp:ListItem><asp:ListItem Value="女">女</asp:ListItem></asp:DropDownList></div></td>
                    </tr>
                    <tr>
                    <td class="right">联系电话</td>
                    <td><asp:TextBox ID="tbTel" runat="server" CssClass="zs-input normal" datatype="m"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">邮箱地址</td>
                    <td><asp:TextBox ID="tbEmail" runat="server" CssClass="zs-input" datatype="e"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right top">个人简历</td>
                    <td><asp:TextBox ID="tbResume" runat="server" CssClass="zs-textarea txt" TextMode="MultiLine" datatype="*"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">提交时间</td>
                    <td><asp:TextBox ID="tbPostTime" runat="server" CssClass="zs-input zs-input-date" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">状态</td>
                    <td><div class="zs-radiobutton-list">
                        <asp:RadioButtonList ID="rblIsCheck" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Selected="True" Value="1">正常</asp:ListItem>
                            <asp:ListItem Value="0">待审核</asp:ListItem>
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