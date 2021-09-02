<%@ Control Language="C#" AutoEventWireup="true" CodeFile="category.ascx.cs" Inherits="uc_category" %>
<asp:Repeater ID="rptCategory" runat="server" OnItemDataBound="rptCategory_ItemDataBound">
    <HeaderTemplate>
        <ul class="uc-category">
    </HeaderTemplate>
    <ItemTemplate>
        <li><asp:Literal ID="ltUrl" runat="server"></asp:Literal></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>