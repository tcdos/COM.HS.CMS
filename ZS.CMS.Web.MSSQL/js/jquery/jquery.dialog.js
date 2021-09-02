;(function ($) {
    $.extend({
        zs_alert: function (html, callback) {
            var dialog = new Dialog();
            dialog.build('zs_alert', callback, html);
        },
        zs_confirm: function (html, callback) {
            var dialog = new Dialog();
            dialog.build('zs_confirm', callback, html);
        },
        zs_tips: function (html, callback) {
            var dialog = new Dialog();
            dialog.build('zs_tips', callback, html);
        },
        zs_url: function (html, callback) {
            var dialog = new Dialog();
            dialog.build('zs_url', callback, html);
        }
    });
    var Dialog = function () {
        var render = {
            pannelAlert: ' <div class="dialogParent"><div class="dialogContent"><h2 class="dialogTitle">Message</h2><div class="dialogHtml">操作失败，请返回！</div><div class="dialogBar"><input type="button" value="确定" class="dialogBtn" id="dialog_ok"/></div></div></div>',
            pannelConfirm: ' <div class="dialogParent"><div class="dialogContent"><h2 class="dialogTitle">Message</h2><div class="dialogHtml">该操作不可恢复，请确认！</div><div class="dialogBar"><input type="button" class="dialogBtn dialogCancel" value="取消" id="dialog_cancel"/><input type="button" class="dialogBtn" value="确定" id="dialog_ok"/></div></div></div>',
            pannelTips: ' <div class="dialogParent"><div class="dialogContent"><h2 class="dialogTitle">Message</h2><div class="dialogHtml">未知操作，请返回！</div></div></div>',
            pannelUrl: ' <div class="dialogParent"><div class="dialogContent"><h2 class="dialogTitle">Message</h2><div class="dialogHtml dialogUrl"><iframe id="urlFrame" name="urlFrame" frameborder="0" src=""></iframe></div></div></div>',
            /** 
            * 根据需要生成对话框 
            * @param {Object} type 
            * @param {Object} callback 
            * @param {Object} html 
            */
            renderDialog: function (type, callback, html) {
                switch (type) {
                    case "zs_alert":
                        this.renderAlert(callback, html);
                        break;
                    case "zs_confirm":
                        this.renderConfirm(callback,html);
                        break;
                    case "zs_tips":
                        this.renderTips(callback, html);
                        break;
                    case "zs_url":
                        this.renderUrl(callback, html);
                        break;
                }
            },
            /** 
            * 生成alert 
            * @param {Object} callback 
            * @param {Object} html 
            */
            renderAlert: function (callback, html) {
                var bg = $('<div class="dialogBg"></div>').css({ opacity: 0.5 }).fadeIn("fast");
                $(document.body).append(bg);
                var temp = $(this.pannelAlert).clone().hide();
                temp.find('div.dialogHtml').html(html);
                $(document.body).append(temp);
                this.setPosition(temp);
                this.resizePosition(temp);
                temp.show();
                this.bindEvents('zs_alert', temp, callback);
            },
            /** 
            * 生成confirm 
            * @param {Object} callback 
            * @param {Object} html 
            */
            renderConfirm: function (callback, html) {
                var bg = $('<div class="dialogBg"></div>').css({ opacity: 0.5 }).fadeIn("fast");
                $(document.body).append(bg);
                var temp = $(this.pannelConfirm).clone().hide();
                temp.find('div.dialogHtml').html(html);
                $(document.body).append(temp);
                this.setPosition(temp);
                this.resizePosition(temp);
                temp.show();
                this.bindEvents('zs_confirm', temp, callback);
            },
            /** 
            * 生成tip
            * @param {Object} callback 
            * @param {Object} html 
            */
            renderTips: function (callback, html) {
                var bg = $('<div class="dialogBg"></div>').css({ opacity: 0 }).show();
                $(document.body).append(bg);
                var temp = $(this.pannelTips).clone().hide();
                temp.find('div.dialogHtml').html(html);
                $(document.body).append(temp);
                this.setPosition(temp);
                this.resizePosition(temp);
                temp.show().delay(1000).animate({ top: 0 }, 100, function () {
                    $('div.dialogParent').remove();
                    $('div.dialogBg').remove();
                });
            },
            /** 
            * 生成iframe  
            * @param {Object} callback 
            * @param {Object} html 
            */
            renderUrl: function (callback, html) {
                var bg = $('<div class="dialogBg"></div>').css({ opacity: 0.5 }).fadeIn("fast");
                $(document.body).append(bg);
                var temp = $(this.pannelUrl).clone().hide();
                temp.find('iframe').attr({ 'src': html });
                $(document.body).append(temp);
                this.setPosition(temp);
                this.resizePosition(temp);
                temp.show();
                $("#urlFrame").load(function () {
                    var btnclose = $("#urlFrame").contents().find("#closeFrame");
                    btnclose.click(function () {
                        $('div.dialogParent').remove();
                        $('div.dialogBg').remove();
                        callback();
                    })
                })
            },
            /** 
            * 设定对话框的位置 
            * @param {Object} el 
            */
            setPosition: function (el) {
                var width = el.width(),
                height = el.height()
                el.css({
                    top: ($(window).height() - height) / 2,
                    left: ($(window).width() - width) / 2
                });
            },
            resizePosition:function(el){
                var that = this;
                $(window).on("resize",function(){
                    that.setPosition(el);
                })
            },
            /** 
            * 绑定事件 
            * @param {Object} type 
            * @param {Object} el 
            * @param {Object} callback 
            */
            bindEvents: function (type, el, callback) {
                switch (type) {
                    case "zs_alert":
                        if ($.isFunction(callback)) {
                            $('#dialog_ok').click(function () {
                                $('div.dialogParent').remove();
                                $('div.dialogBg').remove();
                                callback();
                            });
                        } else {
                            $('#dialog_ok').click(function () {
                                $('div.dialogParent').remove();
                                $('div.dialogBg').remove();
                            });
                        }
                        break;
                    case "zs_confirm":
                        if ($.isFunction(callback)) {
                            $('#dialog_ok').click(function () {  
                                $('div.dialogParent').remove();
                                $('div.dialogBg').remove();
                                callback();
                            });
                        } else {
                            $('#dialog_ok').click(function () {
                                $('div.dialogParent').remove();
                                $('div.dialogBg').remove();
                            });
                        }
                        $('#dialog_cancel').click(function () {
                            $('div.dialogParent').remove();
                            $('div.dialogBg').remove();
                        });
                        break;
                }
            }
        }
        return {
            build: function (type, callback, html) {
                render.renderDialog(type, callback, html);
            }
        }
    }
})(jQuery);