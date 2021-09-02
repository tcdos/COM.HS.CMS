<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="cms_index" %>

<!DOCTYPE HTML> 
 
<html>
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <link href="/style/init.css" rel="stylesheet" />
    <link href="/style/plugin.css" rel="stylesheet" />    
    <link href="style/zscms.css" rel="stylesheet" />
    <link href="/js/artdialog/ui-dialog.css" rel="stylesheet" />
    <script src="/js/jquery/jquery-1.7.2.min.js"></script>
    <script src="/js/artdialog/dialog-plus-min.js"></script>
    <script src="/js/jquery/jquery.zsui.web.js"></script>
    <script src="js/zscms.js"></script>
</head>
<body class="zs-index">
    <form id="form_index" runat="server">
        <div class="zs-top">
            <h2 class="zs-logo"></h2>
            <ul class="zs-module" id="module-tab">
                <asp:Literal ID="litUserModule" runat="server" />
            </ul>
            <div class="zs-user"><asp:Literal ID="litUser" runat="server"/></div>
        </div>
        <div class="zs-side">
            <div class="zs-sidebar" id="module-tabs">
                <asp:Literal ID="litUserModuleList" runat="server" />
            </div>            
        </div>
        <div class="zs-container">
            <iframe id="conframe" name="conframe" frameborder="0" src="main.aspx"></iframe>
        </div>
    </form>
    
</body>
</html>
