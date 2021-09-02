<%@ Page Language="C#" AutoEventWireup="true" CodeFile="error.aspx.cs" Inherits="cms_error" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/style/init.css" rel="stylesheet" />
    <link href="/style/plugin.css" rel="stylesheet" />
    <link href="style/zscms.css" rel="stylesheet" />
</head>
<body class="zs-page">
    <form id="form_main" runat="server">
        <div class="zs-location">
            <a href="javascript:history.back(-1);" class="zs-back"><span>返回上一页</span></a><i class="zs-arrow"></i><span>系统提示</span>
        </div>
        <div class="zs-main">
            <div class="zs-line-20"></div>
            <div class="zs-error">
                <p>
                    <asp:Literal ID="litErrMsg" runat="server"></asp:Literal></p>
                <p><a href="javascript:history.back(-1);" class="zs-error-back"><span>返回</span></a></p>
            </div>
            <div class="zs-line-20"></div>
        </div>
    </form>
</body>
</html>
