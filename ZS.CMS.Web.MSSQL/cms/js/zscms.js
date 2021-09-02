//ZSCMS后台管理页面私有函数
//作者：天草工坊

//页面初始化
$(document).ready(function () {
    initNav();
    $.tabs("#module-tab", "#module-tabs", ".module-tabs-item", "click");
    $.tabs("#form-tab", "#form-tabs", ".form-tabs-item", "click");
    $(".zs-data-table tbody tr:nth-child(odd)").addClass("odd");
    $(".zs-data-table tr").hover(function () { $(this).addClass("on"); }, function () { $(this).removeClass("on"); })
    $(".zs-single-checkbox").znSingleCheckBox();
    $(".zs-checkbox-list").znCheckBoxList();
    $(".zs-radiobutton-list").znRadioButtonList();
    $(".zs-dropdown-list").znDropDownList();
    $(".zs-checkbox").znCheckBox();
    //验证提示定位
    $("#btnSubmit").on("click", function () {
        if ($(".Validform_wrong").length > 0) {
            var i = $("#form-tabs").find(".Validform_wrong:first").parents(".form-tabs-item").index();
            $("#form-tab li").eq(i).find("a").addClass("selected").parent().siblings("li").find("a").removeClass("selected");
            $(".form-tabs-item").eq(i).show().siblings().hide();
        }
    })
});

/*
    私有函数与方法
*/

//功能：导航
function initNav() {
    $('.zs-nav li:not(.group)').hide();
    $(".zs-nav").each(function () {
        $(this).find("li.group:first").nextUntil("li.group").show();
    });
    $('.zs-nav li.group').click(function () {
        var that = $(this).nextUntil("li.group");
        if (that.is(':visible')) {
            return false;
        } else {
            $('.zs-nav li:not(.group)::visible').slideUp('fast');
            that.slideDown('fast');
        }
    });
    $('.zs-nav li:not(.group) a').click(function () {
        $(this).addClass("selected");
        $(this).parent().siblings("li").children().removeClass("selected");
    })
}

//功能：全选
function checkAll(chkobj) {
    if ($(chkobj).text() == "全选") {
        $(chkobj).children("span").text("取消");
        $(".checkAll input:enabled").prop("checked", true);
    } else {
        $(chkobj).children("span").text("全选");
        $(".checkAll input:enabled").prop("checked", false);
    }
}

//功能：回车提交
function submitKeyClick(btnID) {
    if (event.keyCode == 13) {
        event.keyCode = 9;
        event.returnValue = false;
        document.all[btnID].click();
    }
}

//功能：Tab选项卡
$.tabs = function (tab, tabs, tabsitem, ex) {
    $(tab).find("li:first a").addClass("selected");
    $(tabs).find(tabsitem).hide();
    $(tabs).find(tabsitem + ":first").show();
    $(tabs).find(".zs-module-title").text($(tab).find("li:first a span").text());
    $(tab).find("li").on(ex, function () {
        $(this).find("a").addClass("selected").parent().siblings("li").find("a").removeClass("selected");
        var i = $(tab).find("li").index(this);
        $(tabs).find(".zs-module-title").text($(this).find("span").text());
        $(tabs).children().eq(i).show().siblings().hide();
        return false;
    });
};



