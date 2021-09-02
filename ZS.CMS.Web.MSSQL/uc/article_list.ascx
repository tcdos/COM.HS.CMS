<%@ Control Language="C#" AutoEventWireup="true" CodeFile="article_list.ascx.cs" Inherits="uc_article_list" %>
<div class="uc-article">
    <asp:Repeater ID="rptArticle" runat="server" OnItemDataBound="rptArticle_ItemDataBound">
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
