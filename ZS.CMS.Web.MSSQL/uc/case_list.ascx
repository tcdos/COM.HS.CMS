<%@ Control Language="C#" AutoEventWireup="true" CodeFile="case_list.ascx.cs" Inherits="uc_case_list" %>
<div class="uc-list">
    <asp:Repeater ID="rptCase" runat="server" OnItemDataBound="rptCase_ItemDataBound">
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