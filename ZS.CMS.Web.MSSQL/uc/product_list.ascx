<%@ Control Language="C#" AutoEventWireup="true" CodeFile="product_list.ascx.cs" Inherits="uc_product_list" %>
<div class="uc-product">
    <asp:Repeater ID="rptProduct" runat="server" OnItemDataBound="rptProduct_ItemDataBound">
        <HeaderTemplate>
            <ul class="list">
        </HeaderTemplate>
        <ItemTemplate>
            <asp:Literal ID="ltItem" runat="server"></asp:Literal>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Literal ID="ltNull" runat="server"></asp:Literal>
    <div class="uc-pagination" id="htPageList" runat="server"></div>
</div>
