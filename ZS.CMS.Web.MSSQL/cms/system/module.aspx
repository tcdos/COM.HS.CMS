<%@ Page Language="C#" AutoEventWireup="true" CodeFile="module.aspx.cs" Inherits="cms_system_module" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
    <form id="form_category" runat="server">
        <div class="zs-location">
            <a href="javascript:history.back(-1);" class="zs-back"><span>返回上一页</span></a>
            <a href="../main.aspx" class="zs-home"><span>首页</span></a>
            <i class="zs-arrow"></i>
            <span><a href="../system/module.aspx">模块管理</a></span>
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
        </div>
        <div class="zs-line-20"></div>
        <div class="zs-main">
            <asp:Repeater ID="rptList" runat="server" onitemdatabound="rptList_ItemDataBound">
                <HeaderTemplate>
                <table width="100%" class="zs-data-table">
                    <thead>
                        <tr>
                            <th width="5%">选择</th>
                            <th align="left">名称</th>
                            <th align="left" width="10%">级别</th>
                            <th align="left" width="25%">模块标签</th>
                            <th align="left" width="20%">模块操作</th>
                            <th width="200">操作</th>
                        </tr>
                    </thead>
                    <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                        <tr>
                            <td align="center"><asp:CheckBox ID="cbID" CssClass="checkAll" runat="server" style="vertical-align:middle;" /><asp:TextBox ID="tbID" runat="server" Text='<%#Eval("ID") %>' Visible="False"></asp:TextBox><asp:TextBox ID="tbLayer" runat="server" Text='<%#Eval("Layer") %>' Visible="False"></asp:TextBox><asp:TextBox ID="tbActionList" runat="server" Text='<%#Eval("ActionList") %>' Visible="False"></asp:TextBox></td>
                            <td><asp:Literal ID="litSpan" runat="server"></asp:Literal><%#Eval("Title")%></td>
                            <td><%#Eval("Layer")%></td>
                            <td><%#Eval("LabelName")%></td>
                            <td><asp:Literal ID="litActions" runat="server"></asp:Literal></td>
                            <td align="center" class="action"><asp:HyperLink ID="hlAdd" runat="server">添加子模块</asp:HyperLink><i class="line"></i><asp:HyperLink ID="hlEdit" runat="server">编辑</asp:HyperLink></td>
                        </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"6\">暂无记录</td></tr>" : ""%>
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>   
        </div>  
    </form>
</body>
</html>

