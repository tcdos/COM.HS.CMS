<%@ Control Language="C#" AutoEventWireup="true" CodeFile="down_ajax.ascx.cs" Inherits="uc_down_ajax" %>

<div class="uc-list uc-data-list">
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
    <asp:Literal ID="ltMore" runat="server"></asp:Literal>
</div>

<script src="/js/jquery/jquery-1.7.2.min.js"></script>
<script src="/js/jquery/jquery.scrollto.js"></script>
<script>
    $(function () {
        $(".uc-load-more").click(function () {
            var _categoryID = $(this).attr("data-cid");
            var n = $(".uc-data-list .list a").length;
            var _pageSize = $(this).attr("data-pagesize");
            var _curPage = Math.ceil(n / _pageSize) + 1;
            var _route = "news_detail";
            $.ajax({
                type: "post",
                cache: false,
                async: false,
                url: "/ashx/ajax_web.ashx?module=download",
                data: { categoryID: _categoryID, curPage: _curPage, pageSize: _pageSize, route: _route },
                beforeSend: function () {
                    $(".uc-load-more").text("加载中");
                },
                success: function (data) {
                    var moreBtn = data.split("$$")[1];
                    if (moreBtn != "true") {
                        $(".uc-load-more").hide();
                    }
                    $(".uc-load-more").text("获取更多");
                    $(".uc-data-list .list").append(data.split("$$")[0]);
                    $(".uc-data-list .list a.page" + _curPage + "").ScrollTo(1000);
                },
                error: function () {
                    $(".uc-load-more").text("加载失败");
                }
            })
        })
    })
</script>
