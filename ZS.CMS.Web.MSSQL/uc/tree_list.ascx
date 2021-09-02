<%@ Control Language="C#" AutoEventWireup="true" CodeFile="tree_list.ascx.cs" Inherits="uc_tree_list" %>
<asp:Repeater ID="rptCategory" runat="server" OnItemDataBound="rptCategory_ItemDataBound">
    <HeaderTemplate>
        <ul class="uc-tree">
    </HeaderTemplate>
    <ItemTemplate>
        <asp:Literal ID="ltUrl" runat="server"></asp:Literal><asp:Literal ID="ltLayer" runat="server" Visible="false"></asp:Literal>
        <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
            <ItemTemplate>
                <asp:Literal ID="ltDetail" runat="server"></asp:Literal><asp:Literal ID="ltLayer" runat="server" Visible="false" Text='<%#(Container.Parent.Parent.FindControl("ltLayer") as Literal).Text%>'></asp:Literal>
            </ItemTemplate>
        </asp:Repeater>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
