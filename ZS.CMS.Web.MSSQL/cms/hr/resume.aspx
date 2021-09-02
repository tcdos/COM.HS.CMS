﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="resume.aspx.cs" Inherits="cms_hr_resume" %>

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
    <form id="form_content" runat="server">
        <div class="zs-location">
            <a href="javascript:history.back(-1);" class="zs-back"><span>返回上一页</span></a>
            <a href="../main.aspx" class="zs-home"><span>首页</span></a>
            <i class="zs-arrow"></i>
            <span><a href="employ.aspx">招聘计划</a></span>
            <i class="zs-arrow"></i>
            <span>应聘简历</span>
        </div>
        <div class="zs-line-10"></div>
        <div class="zs-tool" id="floatTool">
            <div class="zs-left">
                <ul class="zs-tool-btn">
                    <li><a class="zs-btn-select" href="javascript:;" onclick="checkAll(this);"><span>全选</span></a></li>
                    <li><asp:LinkButton ID="lbCheck" runat="server" CssClass="zs-btn-check" OnClick="lbCheck_Click" OnClientClick="return checkPostBack('lbCheck')">审核</asp:LinkButton></li>
                    <li><asp:LinkButton ID="lbDel" runat="server" CssClass="zs-btn-del" OnClick="lbDel_Click" OnClientClick="return confirmPostBack('lbDel')">删除</asp:LinkButton></li>
                </ul>
            </div>
            <div class="zs-right">
                <div class="zs-dropdown-list">
                    <asp:DropDownList ID="ddlProperty" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProperty_SelectedIndexChanged">
                        <asp:ListItem Value="" Selected="True">所有属性</asp:ListItem>
                        <asp:ListItem Value="isCheck">待审</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="zs-tool-so">
                    <asp:TextBox ID="tbSearchWord" runat="server" CssClass="zs-input-so"></asp:TextBox><asp:LinkButton ID="lbSearch" runat="server" CssClass="zs-btn-so" OnClick="lbSearch_Click">查询</asp:LinkButton>
                </div>
            </div>
            <div class="clear"></div>
        </div>
        <div class="zs-line-20"></div>
        <div class="zs-main">
            <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound" OnItemCommand="rptList_ItemCommand">
                <HeaderTemplate>
                <table width="100%" class="zs-data-table">
                    <thead>
                        <tr>
                            <th width="5%">选择</th>
                            <th align="left" width="10%">应聘类别</th>
                            <th align="left">姓名</th>
                            <th align="left" width="100">性别</th>
                            <th align="left" width="15%">应聘职位</th>
                            <th align="left" width="15%">投递时间</th>
                            <th align="left" width="15%">电话</th>
                            <th align="left" width="100">属性</th>
                            <th width="100">操作</th>
                        </tr>
                    </thead>
                    <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                        <tr>
                            <td align="center"><asp:CheckBox ID="cbID" runat="server" CssClass="checkAll"/><asp:TextBox ID="tbID" runat="server" Text='<%# Eval("ID")%>' Visible="False"></asp:TextBox></td>
                            <td><%# new ZS.BLL.znCategory().GetTitle(new ZS.BLL.znHR().GetCategoryID(Convert.ToInt32(Eval("PositionID"))))%></td>
                            <td><%#Eval("Author")%></td>
                            <td><%#Eval("Sex").ToString()%></td>
                            <td><%# new ZS.BLL.znHR().GetTitle(Convert.ToInt32(Eval("PositionID")))%></td>
                            <td><%#Convert.ToDateTime(Eval("PostTime")).ToString("yyyy-MM-dd HH:mm:ss") %></td>
                            <td><%#Eval("Tel").ToString()%></td>
                            <td>
                            <div class="zs-quick-btn">
                                <asp:LinkButton ID="isCheck" CommandName="btnCheck" runat="server" CssClass='<%# Convert.ToInt32(Eval("isCheck")) == 1 ? "zs-lb-check" : "zs-lb-uncheck"%>' ToolTip='<%# Convert.ToInt32(Eval("isCheck")) == 1 ? "取消审核" : "通过审核"%>'></asp:LinkButton>
                            </div>
                            </td>
                            <td align="center" class="action"><asp:HyperLink ID="hlEdit" runat="server">编辑</asp:HyperLink></td>
                        </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
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
