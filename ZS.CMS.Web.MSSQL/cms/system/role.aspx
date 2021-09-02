<%@ Page Language="C#" AutoEventWireup="true" CodeFile="role.aspx.cs" Inherits="cms_system_role" %>

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
    <script src="/js/artdialog/dialog-plus-min.js"></script>
    <script src="/js/jquery/jquery.zsui.web.js"></script>
    <script src="../js/zscms.js"></script>
</head>
<body class="zs-page">
    <form id="form_content" runat="server">
        <div class="zs-location">
            <a href="javascript:history.back(-1);" class="zs-back"><span>返回上一页</span></a>
            <a href="../main.aspx" class="zs-home"><span>首页</span></a>
            <i class="zs-arrow"></i>
            <span><a href="../system/role.aspx">角色管理</a></span>
            <i class="zs-arrow"></i>
            <span>角色列表</span>
        </div>
        <div class="zs-line-10"></div>
        <div class="zs-tool" id="floatTool">
            <div class="zs-left">
                <ul class="zs-tool-btn">
                    <li><a class="zs-btn-select" href="javascript:;" onclick="checkAll(this);"><span>全选</span></a></li>
                    <li><asp:LinkButton ID="lbAdd" runat="server" CssClass="zs-btn-add" OnClick="lbAdd_Click">新增</asp:LinkButton></li>
                    <li><asp:LinkButton ID="lbDel" runat="server" CssClass="zs-btn-del" OnClick="lbDel_Click" OnClientClick="return confirmPostBack('lbDel')">删除</asp:LinkButton></li>
                </ul>
            </div>
            <div class="zs-right">
                <div class="zs-tool-so">
                    <asp:TextBox ID="tbSearchWord" runat="server" CssClass="zs-input-so"></asp:TextBox><asp:LinkButton ID="lbSearch" runat="server" CssClass="zs-btn-so" OnClick="lbSearch_Click">查询</asp:LinkButton>
                </div>
            </div>
            <div class="clear"></div>
        </div>
        <div class="zs-line-20"></div>
        <div class="zs-main">
            <asp:Repeater ID="rptList" runat="server">
                <HeaderTemplate>
                    <table width="100%" class="zs-data-table">
                        <thead>
                        <tr>
                            <th width="5%">选择</th>
                            <th align="left">名称</th>
                            <th width="20%">权限</th>
                            <th width="100">操作</th>
                        </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center"><asp:CheckBox ID="cbID" runat="server" CssClass="checkAll" /><asp:TextBox ID="tbID" runat="server" Text='<%# Eval("ID")%>' Visible="False"></asp:TextBox></td>
                        <td><%#Eval("RoleName")%></td>
                        <td align="center" class="action"><a href="role_value.aspx?action=<%#ZS.KIT.znEnum.Actions.Edit %>&id=<%#Eval("ID")%>">权限分配</a></td>
                        <td align="center" class="action"><a href="role_edit.aspx?action=<%#ZS.KIT.znEnum.Actions.Edit %>&id=<%#Eval("ID")%>">编辑</a></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"5\">暂无记录</td></tr>" : ""%>
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <div class="zs-line-20"></div>
            <div id="pageList" runat="server" class="zs-page-list"></div>
            <div class="zs-line-20"></div>
        </div>
    </form>
</body>
</html>
