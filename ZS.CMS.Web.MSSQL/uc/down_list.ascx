<%@ Control Language="C#" AutoEventWireup="true" CodeFile="down_list.ascx.cs" Inherits="uc_down_list" %>
<div class="uc-list">
    <asp:Repeater ID="rptDownload" runat="server" OnItemDataBound="rptDownload_ItemDataBound">
        <HeaderTemplate>
            <div class="list">
        </HeaderTemplate>
        <ItemTemplate>
            <asp:Literal ID="ltItem" runat="server"></asp:Literal>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Literal ID="ltNull" runat="server"></asp:Literal>
    <div class="uc-pagination" id="htPageList" runat="server"></div>
</div>