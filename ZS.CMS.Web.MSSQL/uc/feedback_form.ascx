<%@ Control Language="C#" AutoEventWireup="true" CodeFile="feedback_form.ascx.cs" Inherits="uc_feedback_form" %>
<div class="uc-form">
    <h3 id="feedbackMsg" runat="server"></h3>
    <dl>
        <dt>类型</dt>
        <dd><asp:RadioButtonList ID="rblCategory" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:RadioButtonList></dd>
    </dl>
    <dl>
        <dt>咨询内容</dt>
        <dd><asp:TextBox ID="tbContent" runat="server" TextMode="MultiLine" CssClass="textarea" datatype="*2-1000"></asp:TextBox></dd>
    </dl>
    <dl>
        <dt>联系人</dt>
        <dd><asp:TextBox ID="tbUserName" runat="server" CssClass="textbox" datatype="*2-20"></asp:TextBox></dd>
    </dl>
    <dl>
        <dt>联系电话</dt>
        <dd><asp:TextBox ID="tbTel" runat="server" CssClass="textbox" datatype="m"></asp:TextBox></dd>
    </dl>
    <dl>
        <dt>电子邮箱</dt>
        <dd><asp:TextBox ID="tbEmail" runat="server" CssClass="textbox" datatype="e"></asp:TextBox></dd>
    </dl>
    <dl>
        <dt></dt>
        <dd><asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="btn" OnClick="btnSubmit_Click" /></dd>
    </dl>
</div>
