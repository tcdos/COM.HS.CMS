<%@ Control Language="C#" AutoEventWireup="true" CodeFile="link_list.ascx.cs" Inherits="uc_link_list" %>
<dl class="uc-link clear">
    <asp:Repeater ID="rptLink" runat="server" OnItemDataBound="rptLink_ItemDataBound">
        <HeaderTemplate><dt><i class="i"></i><b>相关网站</b></dt></HeaderTemplate>
        <ItemTemplate>
            <asp:Literal ID="ltItem" runat="server"></asp:Literal>
        </ItemTemplate>
    </asp:Repeater>
</dl>
