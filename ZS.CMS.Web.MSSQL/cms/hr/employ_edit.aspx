<%@ Page Language="C#" AutoEventWireup="true" CodeFile="employ_edit.aspx.cs" Inherits="cms_hr_employ_edit" %>

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
    <script src="/js/jquery/jquery.datetimepicker.js"></script>
    <script src="/js/artdialog/dialog-plus-min.js"></script>
    <script src="/js/jquery/jquery.zsui.web.js"></script>
    <script src="../js/zscms.js"></script>
    <script type="text/javascript">
        $(function () {
            //表单检测
            $("#form_content").Validform();
            //日期控件初始化
            $(".zs-input-date").datetimepicker({
                lang: 'ch',
                timepicker: false,
                format: 'Y-m-d',
                formatDate: 'Y-m-d'
            });
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
            <span>职位编辑</span>
        </div>
        <div class="zs-line-20"></div>       
        <div class="zs-form-nav">
            <ul id="form-tab">
                <li><a href="javascript:void(0)" class="selected">基本信息</a></li>
            </ul>    
        </div>
        <div class="zs-form-content" id="form-tabs">
            <div class="form-tabs-item">
                <table width="100%" class="zs-form-tab">
                    <tr>
                    <td class="right" width="120">所属类别</td>
                    <td><div class="zs-dropdown-list"><asp:DropDownList ID="ddlCategory" runat="server" datatype="*"></asp:DropDownList></div></td>
                    </tr>
                    <tr>
                    <td class="right">职位名称</td>
                    <td><asp:TextBox ID="tbTitle" runat="server" CssClass="zs-input" datatype="*2-100"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">招聘人数</td>
                    <td><asp:TextBox ID="tbLimitNum" runat="server" CssClass="zs-input short" Text="1" datatype="n"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">起始日期</td>
                    <td><asp:TextBox ID="tbStartDate" runat="server" CssClass="zs-input zs-input-date" datatype="*10-10"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">结束日期</td>
                    <td><asp:TextBox ID="tbEndDate" runat="server" CssClass="zs-input zs-input-date" datatype="*10-10"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">工作地点</td>
                    <td><asp:TextBox ID="tbAddress" runat="server" CssClass="zs-input"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">薪酬待遇</td>
                    <td><asp:TextBox ID="tbSalary" runat="server" CssClass="zs-input normal"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">简历投递邮箱</td>
                    <td><asp:TextBox ID="tbEmail" runat="server" CssClass="zs-input"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right top">职位描述</td>
                    <td><asp:TextBox ID="tbInfor" runat="server" CssClass="zs-textarea txt" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right top">任职条件</td>
                    <td><asp:TextBox ID="tbRequest" runat="server" CssClass="zs-textarea txt" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">显示状态</td>
                    <td><div class="zs-radiobutton-list">
                        <asp:RadioButtonList ID="rblIsCheck" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Selected="True" Value="1">正常</asp:ListItem>
                            <asp:ListItem Value="0">待审核</asp:ListItem>
                        </asp:RadioButtonList>
                        </div></td>
                    </tr>
                    <tr>
                    <td class="right">发布属性</td>
                    <td><div class="zs-checkbox"><asp:CheckBox ID="cbIsTop" runat="server" /><label for="tbIsTop">固顶</label> <asp:CheckBox ID="cbIsElite" runat="server" /><label for="tcIsElite">推荐</label></div></td>
                    </tr>
                    <tr>
                    <td class="right">发布时间</td>
                    <td><asp:TextBox ID="tbPostTime" runat="server" CssClass="zs-input zs-input-date"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">发布者</td>
                    <td><asp:TextBox ID="tbUserName" runat="server" CssClass="zs-input normal" ReadOnly="true"></asp:TextBox></td>
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
