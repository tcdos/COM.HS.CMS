<%@ Control Language="C#" AutoEventWireup="true" CodeFile="page_list.ascx.cs" Inherits="uc_page_list" %>
<asp:Repeater ID="rptPageList" runat="server" OnItemDataBound="rptPageList_ItemDataBound">
    <HeaderTemplate>
        <ul class="uc-page-list">
    </HeaderTemplate>
    <ItemTemplate>
        <li><asp:Literal ID="ltUrl" runat="server"></asp:Literal></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </table>
    </FooterTemplate>
</asp:Repeater>
