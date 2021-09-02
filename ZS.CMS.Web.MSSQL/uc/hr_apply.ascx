<%@ Control Language="C#" AutoEventWireup="true" CodeFile="hr_apply.ascx.cs" Inherits="uc_hr_apply" %>
<div class="uc-form">
    <dl>
        <dt>应聘职位</dt>
        <dd><asp:TextBox ID="tbPosition" runat="server" CssClass="textbox" Enabled="false"></asp:TextBox></dd>
    </dl>
    <dl>
        <dt>姓名</dt>
        <dd><asp:TextBox ID="tbUserName" runat="server" CssClass="textbox" datatype="*2-20"></asp:TextBox></dd>
    </dl>
    <dl>
        <dt>性别</dt>
        <dd><asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem Selected="True">男</asp:ListItem>
                <asp:ListItem>女</asp:ListItem>
            </asp:RadioButtonList></dd>
    </dl>
    <dl>
        <dt>联系电话</dt>
        <dd><asp:TextBox ID="tbTel" runat="server" CssClass="textbox" datatype="m"></asp:TextBox></dd>
    </dl>
    <dl>
        <dt>邮箱</dt>
        <dd><asp:TextBox ID="tbEmail" runat="server" CssClass="textbox" datatype="e"></asp:TextBox></dd>
    </dl>
    <dl>
        <dt>简历</dt>
        <dd><asp:TextBox ID="tbResume" runat="server" CssClass="textarea long" TextMode="MultiLine" datatype="*2-1000"></asp:TextBox></dd>
    </dl>
    <dl>
        <dt></dt>
        <dd><asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="btn" OnClick="btnSubmit_Click" /></dd>
    </dl>
</div>
