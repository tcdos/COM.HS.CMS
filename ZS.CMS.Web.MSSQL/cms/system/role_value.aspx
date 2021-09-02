<%@ Page Language="C#" AutoEventWireup="true" CodeFile="role_value.aspx.cs" Inherits="cms_system_role_value" %>

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
            //权限全选
            $("input[name='checkAll']").click(function () {
                if ($(this).prop("checked") == true) {
                    $("input[name!='checkAll']").prop("checked", true);
                } else {
                    $("input[name!='checkAll']").prop("checked", false);
                }
            })
            //权限全选[模块]
            $("input[name='checkModule']").click(function () {
                if ($(this).prop("checked") == true) {
                    $(this).parent().siblings("td").find("input[type='checkbox']").prop("checked", true);
                } else {
                    $(this).parent().siblings("td").find("input[type='checkbox']").prop("checked", false);
                }
            });

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
            <span>权限分配</span>
        </div>
        <div class="zs-line-20"></div>      
        <div class="zs-form-nav">
            <ul id="form-tab">
                <li><a href="javascript:void(0)" class="selected">权限信息</a></li>
            </ul>    
        </div>
        <div class="zs-form-content" id="form-tabs">
            <div class="form-tabs-item">
                <table width="100%" class="zs-form-tab">
                    <tr>
                    <td class="right" width="120">角色名称</td>
                    <td><asp:TextBox ID="tbRoleName" runat="server" CssClass="zs-input" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right top">权限详情</td>
                    <td>
                        <table class="zs-data-table zs-data-table-in">
                            <thead>
                              <tr>
                                <th align="center" width="40%">模块名称</th>
                                <th align="center">权限分配</th>
                                <th align="center" width="10%"><input name="checkAll" type="checkbox" /></th>
                              </tr>
                            </thead>
                            <tbody>
                              <asp:Repeater ID="rptList" runat="server" onitemdatabound="rptList_ItemDataBound">
                              <ItemTemplate>
                              <tr>
                                <td>
                                  <asp:TextBox ID="tbID" runat="server" Text='<%#Eval("ID") %>' Visible="False"></asp:TextBox><asp:TextBox ID="tbLayer" runat="server" Text='<%#Eval("Layer") %>' Visible="False"></asp:TextBox><asp:TextBox ID="tbActionList" runat="server" Text='<%#Eval("ActionList") %>' Visible="False"></asp:TextBox>
                                  <asp:Literal ID="litSpan" runat="server"></asp:Literal><%#Eval("Title")%>
                                </td>
                                <td>
                                  <asp:CheckBoxList ID="cblActionList" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="cbllist"></asp:CheckBoxList>
                                </td>
                                <td class="center"><input name="checkModule" type="checkbox" /></td>
                              </tr>
                              </ItemTemplate>
                              </asp:Repeater>
                            </tbody>
                          </table>
                    </td>
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
