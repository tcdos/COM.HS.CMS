/*placeholder*/
$.fn.extend({
    placeholder: function () {
        if ('placeholder' in document.createElement('input')) {
            return this
        } else {
            return this.each(function () {
                var _this = $(this),
                this_placeholder = _this.attr('placeholder');
                _this.val(this_placeholder).focus(function () {
                    if (_this.val() === this_placeholder) {
                        _this.val('')
                    }
                }).blur(function () {
                    if (_this.val().length === 0) {
                        _this.val(this_placeholder)
                    }
                })
            })
        }
    }
})

//智能浮动
$.fn.znSmartFloat = function () {
    var position = function (element) {
        var top = element.position().top;
        var pos = element.css("position");
        $(window).scroll(function () {
            var scrolls = $(this).scrollTop();
            if (scrolls > top) {
                if (window.XMLHttpRequest) {
                    element.css({
                        position: "fixed",
                        top: 0,
                        padding: "10px 0px"
                    });
                } else {
                    element.css({
                        top: scrolls
                    });
                }
            } else {
                element.css({
                    position: pos,
                    top: top,
                    padding: "0px"
                });
            }
        });
    };
    return $(this).each(function () {
        position($(this));
    });
};

/*复选框：是/否*/
$.fn.znSingleCheckBox = function () {
    var singleCheckBox = function (parentObj) {
        var checkObj = parentObj.children('input:checkbox').eq(0);
        parentObj.children().hide();
        var newObj = $('<a href="javascript:;">'
		+ '<i class="off">否</i>'
		+ '<i class="on">是</i>'
		+ '</a>').prependTo(parentObj);
        if (checkObj.prop("checked") == true) {
            newObj.addClass("selected");
        }
        if (checkObj.prop("disabled") == true) {
            newObj.css("cursor", "default");
            return;
        }
        $(newObj).click(function () {
            if ($(this).hasClass("selected")) {
                $(this).removeClass("selected");
            } else {
                $(this).addClass("selected");
            }
            checkObj.trigger("click");
        });
    };
    return $(this).each(function () {
        singleCheckBox($(this));
    });
};

/*复选框*/
$.fn.znCheckBox = function () {
    var checkBox = function (parentObj) {
        parentObj.children().hide();
        var divObj = $('<ul></ul>').prependTo(parentObj);
        parentObj.find(":checkbox").each(function () {
            var indexNum = parentObj.find(":checkbox").index(this);
            var liObj = $('<li></li>').appendTo(divObj)
            var newObj = $('<a href="javascript:;">' + parentObj.find('label').eq(indexNum).text() + '</a><i></i>').appendTo(liObj);
            if ($(this).prop("checked") == true) {
                liObj.addClass("selected");
            }
            if ($(this).prop("disabled") == true) {
                newObj.css("cursor", "default");
                return;
            }
            $(newObj).click(function () {
                if ($(this).parent().hasClass("selected")) {
                    $(this).parent().removeClass("selected");
                } else {
                    $(this).parent().addClass("selected");
                }
                parentObj.find(':checkbox').eq(indexNum).trigger("click");
            });
        });
    };
    return $(this).each(function () {
        checkBox($(this));
    });
}

/*多项复选框*/
$.fn.znCheckBoxList = function () {
    var checkBoxList = function (parentObj) {
        parentObj.children().hide();
        var divObj = $('<div class="boxwrap"></div>').prependTo(parentObj);
        parentObj.find(":checkbox").each(function () {
            var indexNum = parentObj.find(":checkbox").index(this);
            var newObj = $('<a href="javascript:;">' + parentObj.find('label').eq(indexNum).text() + '</a>').appendTo(divObj);
            if ($(this).prop("checked") == true) {
                newObj.addClass("selected");
            }
            if ($(this).prop("disabled") == true) {
                newObj.css("cursor", "default");
                return;
            }
            $(newObj).click(function () {
                if ($(this).hasClass("selected")) {
                    $(this).removeClass("selected");
                } else {
                    $(this).addClass("selected");
                }
                parentObj.find(':checkbox').eq(indexNum).trigger("click");
            });
        });
    };
    return $(this).each(function () {
        checkBoxList($(this));
    });
}

/*多项单选按钮*/
$.fn.znRadioButtonList = function () {
    var radioButtonList = function (parentObj) {
        parentObj.children().hide();
        var divObj = $('<div class="boxwrap"></div>').prependTo(parentObj);
        parentObj.find('input[type="radio"]').each(function () {
            var indexNum = parentObj.find('input[type="radio"]').index(this);
            var newObj = $('<a href="javascript:;">' + parentObj.find('label').eq(indexNum).text() + '</a>').appendTo(divObj);
            if ($(this).prop("checked") == true) {
                newObj.addClass("selected");
            }
            if ($(this).prop("disabled") == true) {
                newObj.css("cursor", "default");
                return;
            }
            $(newObj).click(function () {
                $(this).siblings().removeClass("selected");
                $(this).addClass("selected");
                parentObj.find('input[type="radio"]').prop("checked", false);
                parentObj.find('input[type="radio"]').eq(indexNum).prop("checked", true);
                parentObj.find('input[type="radio"]').eq(indexNum).trigger("click");
            });
        });
    };
    return $(this).each(function () {
        radioButtonList($(this));
    });
}
/*单选下拉框*/
$.fn.znDropDownList = function () {
    var dropDownList = function (parentObj) {
        parentObj.children().hide();
        var divObj = $('<div class="boxwrap"></div>').prependTo(parentObj);
        var titObj = $('<a class="select-tit" href="javascript:;"><span></span><i></i></a>').appendTo(divObj);
        var itemObj = $('<div class="select-items"><ul></ul></div>').appendTo(divObj);
        var arrowObj = $('<i class="arrow"></i>').appendTo(divObj);
        var selectObj = parentObj.find("select").eq(0);
        selectObj.find("option").each(function (i) {
            var indexNum = selectObj.find("option").index(this);
            var liObj = $('<li>' + $(this).text() + '</li>').appendTo(itemObj.find("ul"));
            if ($(this).prop("selected") == true) {
                liObj.addClass("selected");
                titObj.find("span").text($(this).text());
            }
            if ($(this).prop("disabled") == true) {
                liObj.css("cursor", "default");
                return;
            }
            liObj.click(function () {
                $(this).siblings().removeClass("selected");
                $(this).addClass("selected");
                selectObj.find("option").prop("selected", false);
                selectObj.find("option").eq(indexNum).prop("selected", true);
                titObj.find("span").text($(this).text());
                arrowObj.hide();
                itemObj.hide();
                selectObj.trigger("change");
            });
        });
        if (selectObj.prop("disabled") == true) {
            titObj.css("cursor", "default");
            return;
        }
        titObj.click(function (e) {
            e.stopPropagation();
            if (itemObj.is(":hidden")) {
                $(".single-select .select-items").hide();
                $(".single-select .arrow").hide();
                arrowObj.css("z-index", "3");
                itemObj.css("z-index", "3");
                arrowObj.show();
                itemObj.show();
            } else {
                arrowObj.css("z-index", "");
                itemObj.css("z-index", "");
                arrowObj.hide();
                itemObj.hide();
            }
        });
        $(document).click(function (e) {
            selectObj.trigger("blur");
            arrowObj.hide();
            itemObj.hide();
        });
    };
    return $(this).each(function () {
        dropDownList($(this));
    });
}

//基于artdialog插件二次开发
//定时转向提示
function zsRedirect(msgtitle, url, ms) {
    var d = dialog({ content: msgtitle }).show();
    setTimeout(function () {
        d.close().remove();
    }, ms);
    if (url != "") {
        setTimeout(function () {
            window.location.href = url;
        }, ms);
    }
}
//自动关闭的提示
function zsTips(msgtitle, url, callback) {
    var d = dialog({ content: msgtitle }).show();
    setTimeout(function () {
        d.close().remove();
    }, 2000);
    if (url == "back") {
        frames["conframe"].history.back(-1);
    } else if (url != "") {
        frames["conframe"].location.href = url;
    }
    //执行回调函数
    if (arguments.length == 3) {
        callback();
    }
}
//弹出一个Dialog窗口
function zsDialog(msgtitle, msgcontent, url, callback) {
    var d = dialog({
        title: msgtitle,
        content: msgcontent,
        okValue: '确定',
        ok: function () { },
        onclose: function () {
            if (url == "back") {
                history.back(-1);
            } else if (url != "") {
                location.href = url;
            }
            //执行回调函数
            if (argnum == 4) {
                callback();
            }
        }
    }).showModal();
}
//Dialog
function ShowMaxDialog(tit, url) {
    dialog({
        title: tit,
        url: url
    }).showModal();
}
//执行回传函数
function confirmPostBack(objId, objmsg) {
    if ($(".checkAll input:checked").size() < 1) {
        parent.dialog({
            title: '提示',
            content: '对不起，请选中您要操作的记录！',
            okValue: '确定',
            ok: function () { }
        }).showModal();
        return false;
    }
    var msg = "删除记录后不可恢复，您确定吗？";
    if (arguments.length == 2) {
        msg = objmsg;
    }
    parent.dialog({
        title: '提示',
        content: msg,
        okValue: '确定',
        ok: function () {
            __doPostBack(objId, '');
        },
        cancelValue: '取消',
        cancel: function () { }
    }).showModal();

    return false;
}
//检查是否有选中再决定回传
function checkPostBack(objId, objmsg) {
    var msg = "对不起，请选中您要操作的记录！";
    if (arguments.length == 2) {
        msg = objmsg;
    }
    if ($(".checkAll input:checked").size() < 1) {
        parent.dialog({
            title: '提示',
            content: msg,
            okValue: '确定',
            ok: function () { }
        }).showModal();
        return false;
    }
    __doPostBack(objId, '');
    return false;

}
//执行回传无复选框确认函数
function uncheckPostBack(objId, objmsg) {
    debugger;
    var id = parseInt(objId) < 10 ? '0' + objId : objId;
    var fn = "rptList$ctl" + id + "$lbDel";
    var msg = "删除记录后不可恢复，您确定吗？";
    if (arguments.length == 2) {
        msg = objmsg;
    }
    parent.dialog({
        title: '提示',
        content: msg,
        okValue: '确定',
        ok: function () {
            __doPostBack(fn, '');
        },
        cancelValue: '取消',
        cancel: function () { }
    }).showModal();

    return false;
}

//ZSCMS上传组件功能函数
function uploadBack(type, controlID, isAll, data) { //上传类型：单文件|多文件，获取文件路径的控件ID，是否返回完整上传信息：路径+大小+格式， {"status":1/0,"msg":"提示文本","filePath":"attach/2016/04/08/201604081455.jpg","fileSize":"100KB","fileExt":"jpg"}
    var jd = $.parseJSON(data); //转成JSON
    if (jd.status == 1) {
        if (type == "single") {
            //单文件上传
            $("#" + controlID + "Msg").empty().html("<b class='zs-upload-msg-suc'>" + jd.msg + "</b>"); //提示文本
            if (isAll == "true") {
                $("#" + controlID).val(jd.filePath + "$" + jd.fileSize + "$" + jd.fileExt); //attach/2016/04/08/201604081455.jpg$100KB$jpg
            } else {
                $("#" + controlID).val(jd.filePath);//attach/2016/04/08/201604081455.jpg
            }
        } else {
            //多文件上传
            $("#" + controlID + "Msg").empty().html("<b class='zs-upload-msg-suc'>" + jd.msg + "</b>"); //提示文本
            //表单提交
            var list = $("#" + controlID + "Value").val().replace(/[]/g, ""); //更新文件列表 <asp:TextBox ID="tbPhotoListValue" runat="server"></asp:TextBox>
            if (list.length <= 0) {
                list += jd.filePath;
            } else {
                list += "|" + jd.filePath;
            }
            $("#" + controlID + "Value").val(list); //更新文件列表 <asp:TextBox ID="tbPhotoListValue" runat="server"></asp:TextBox>
            //清空默认提示
            if ($("#" + controlID).find("a").length <= 0) {
                $("#" + controlID).empty();
            }
            //ID赋值
            var id = jd.filePath.split('.')[0].replace(/\//g, "");
            $("#" + controlID).append("<i id='" + id + "'><a href='" + jd.filePath + "' target='_blank'>" + jd.filePath.split('/')[3] + "</a><b data-url='" + jd.filePath + "' data-id='" + id + "'></b></i>");//展示
            /*
            删除图片脚本，依赖页面处理，需要委托处理
            JS代码：
            $(".zs-upload-list").on("click", ".zs-upload-list b", function (e) {
                var curFile = $(this).attr("data-url");
                var id = $(this).attr("data-id");
                var fileList = $("#tbPhotoListValue").val().replace(curFile, "");
                $("#tbPhotoListValue").val(fileList);
                $("#" + id).remove();
                if ($(".zs-upload-list").find("a").length <= 0) {
                    $(".zs-upload-list").text("请上传图片");
                }
            })
            HTML代码：
            <tr>
                <td class="right">相册</td>
                <td><div class="zs-uploadFrame"><iframe name="upload" frameborder="0"  frameborder="no" style="" src="../upload/upload.aspx?type=multi&controlID=tbPhotoList&isThumbnail=true&mode=w&W=800"></iframe></div><div class="zs-upload-msg" id="tbPhotoListMsg"></div></td>
            </tr>
            <tr>
                <td class="right"></td>
                <td><div id="tbPhotoList" runat="server" class="zs-upload-list">请上传图片</div><div class="hidden"><asp:TextBox ID="tbPhotoListValue" runat="server"></asp:TextBox></div></td>
            </tr>

            */
        }
    } else {
        $("#" + controlID + "Msg").empty().html("<b class='zs-upload-msg-err'>" + jd.msg + "</b>");
    }
}
