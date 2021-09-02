<%@ Page Language="C#" AutoEventWireup="true" CodeFile="content_edit.aspx.cs" Inherits="cms_solution_content_edit" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <title></title>
    <link href="/style/init.css" rel="stylesheet" />
    <link href="/style/plugin.css" rel="stylesheet" />
    <link href="../style/zscms.css" rel="stylesheet" />
    <link href="/js/artdialog/ui-dialog.css" rel="stylesheet" />
    <script src="/js/jquery/jquery-1.7.2.min.js"></script>
    <script src="/js/jquery/jquery.validate.js"></script>
    <script src="/js/jquery/jquery.datetimepicker.js"></script>
    <script src="/js/artdialog/dialog-plus-min.js"></script>
    <script src="/js/jquery/jquery.zsui.web.js"></script>
    <script src="../js/zscms.js"></script>
    <!--在线编辑器-->
    <script src="/editor/kindeditor-min.js"></script>
    <script src="/editor/lang/zh_CN.js"></script>
    <link href="/editor/themes/default/default.css" rel="stylesheet" />
    <!--在线编辑器-->
    <script type="text/javascript">
        $(function () {
            //表单检测
            $("#form_content").Validform();
            //日期控件初始化
            $(".zs-input-date").datetimepicker({
                lang: 'ch',
                timepicker: true,
                step: 1,
                format: 'Y-m-d H:i:s',
                formatDate: 'Y-m-d'
            });
            //初始化编辑器
            var editor = KindEditor.create('.editor', {
                uploadJson: '../ashx/ajax_upload.ashx?action=FileUpload',
                fileManagerJson: '../ashx/ajax_upload.ashx?action=FileManage',
                width: '92%',
                height: '350px',
                resizeType: 1,
                allowFileManager: true
            });
        })
    </script>
</head>
<body class="zs-page">
    <form id="form_content" runat="server">
        <div class="zs-location">
          <a href="javascript:history.back(-1);" class="zs-back"><span>返回上一页</span></a>
          <a href="../main.aspx" class="zs-home"><span>首页</span></a>
          <i class="zs-arrow"></i>
          <span><a href="content.aspx">解决方案</a></span>
          <i class="zs-arrow"></i>
          <span>方案编辑</span>
        </div>
        <div class="zs-line-20"></div>       
        <div class="zs-form-nav">
            <ul id="form-tab">
                <li><a href="javascript:void(0)" class="selected">基本信息</a></li>
                <li><a href="javascript:void(0)">详细描述</a></li>
            </ul>    
        </div>
        <div class="zs-form-content" id="form-tabs">
            <div class="form-tabs-item">
                <table width="100%" class="zs-form-tab">
                    <tr>
                    <td class="right" width="120">所属类别</td>
                    <td><div class="zs-dropdown-list"><asp:DropDownList ID="ddlCategory" runat="server" datatype="*"></asp:DropDownList></div></td>
                    </tr>
                    <tr>
                    <td class="right">名称</td>
                    <td><asp:TextBox ID="tbTitle" runat="server" CssClass="zs-input" datatype="*2-100"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">名称(简短)</td>
                    <td><asp:TextBox ID="tbShortTitle" runat="server" CssClass="zs-input" datatype="*2-100"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">缩略图</td>
                    <td><asp:TextBox ID="tbSmallPic" runat="server" CssClass="zs-input"></asp:TextBox><div class="zs-uploadFrame"><iframe name="upload" frameborder="0"  frameborder="no" style="" src="../upload/upload.aspx?type=single&controlID=tbSmallPic&mode=cut"></iframe></div><div class="zs-upload-msg" id="tbSmallPicMsg"></div></td>
                    </tr>
                    <tr>
                    <td class="right">图标(首页)</td>
                    <td><asp:TextBox ID="tbIdxPic" runat="server" CssClass="zs-input"></asp:TextBox><div class="zs-uploadFrame"><iframe name="upload" frameborder="0"  frameborder="no" style="" src="../upload/upload.aspx?type=single&controlID=tbIdxPic&isThumbnail=false"></iframe></div><div class="zs-upload-msg" id="tbIdxPicMsg"></div></td>
                    </tr>
                    <tr>
                    <td class="right">URL转跳</td>
                    <td><asp:TextBox ID="tbLinkUrl" runat="server" CssClass="zs-input" Text="http://"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">是否使用URL转跳</td>
                    <td><div class="zs-single-checkbox"><asp:CheckBox ID="cbIsUrl" runat="server" /></div></td>
                    </tr>
                    <tr>
                    <td class="right">显示状态</td>
                    <td><div class="zs-radiobutton-list">
                        <asp:RadioButtonList ID="rblIsCheck" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Selected="True" Value="1">正常</asp:ListItem>
                            <asp:ListItem Value="0">待审核</asp:ListItem>
                        </asp:RadioButtonList>
                        </div></td>
                    </tr>
                    <tr>
                    <td class="right">发布属性</td>
                    <td><div class="zs-checkbox"><asp:CheckBox ID="cbIsTop" runat="server" /><label for="tbIsTop">固顶</label> <asp:CheckBox ID="cbIsElite" runat="server" /><label for="tcIsElite">推荐</label></div></td>
                    </tr>
                    <tr>
                    <td class="right">发布时间</td>
                    <td><asp:TextBox ID="tbPostTime" runat="server" CssClass="zs-input zs-input-date"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">发布者</td>
                    <td><asp:TextBox ID="tbUserName" runat="server" CssClass="zs-input normal" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right">排序ID</td>
                    <td><asp:TextBox ID="tbSortID" runat="server" CssClass="zs-input short" Text="0" datatype="n"></asp:TextBox><span class="tip">数字，越大越靠前</span></td>
                    </tr>
                    <tr>
                    <td class="right">浏览次数</td>
                    <td><asp:TextBox ID="tbHits" runat="server" CssClass="zs-input short" Text="0" datatype="n"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
            <div class="form-tabs-item">
                <table width="100%" class="zs-form-tab">
                    <tr>
                    <td class="right top" width="120">简介</td>
                    <td><asp:TextBox ID="tbSummary" runat="server" CssClass="zs-textarea" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td class="right top">详情</td>
                    <td><textarea id="tbContent" class="editor" style="visibility:hidden;" runat="server"></textarea></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="zs-line-20"></div>
        <div class="zs-btn-bott"><asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="zs-btn" OnClick="btnSubmit_Click" /></div> 
        <div class="zs-line-60"></div>          
    </form>
</body>
</html>