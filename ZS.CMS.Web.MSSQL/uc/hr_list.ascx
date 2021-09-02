<%@ Control Language="C#" AutoEventWireup="true" CodeFile="hr_list.ascx.cs" Inherits="uc_hr_list" %>
<div class="uc-employ">
    <asp:Repeater ID="rptHR" runat="server" OnItemDataBound="rptHR_ItemDataBound">
        <ItemTemplate>
            <asp:Literal ID="ltItem" runat="server"></asp:Literal>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Literal ID="ltNull" runat="server"></asp:Literal>
</div>
