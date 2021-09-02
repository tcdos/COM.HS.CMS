<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="tool_upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/style/init.css" rel="stylesheet" />
    <link href="/style/plugin.css" rel="stylesheet" />
    <link href="../style/zscms.css" rel="stylesheet" />
    <script src="/js/jquery/jquery-1.7.2.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#filePath").change(function () {
                __doPostBack("lbUpload", '');
            })
        })
    </script>
</head>
<body>
    <form id="form_upload" runat="server">
        <div class="zs-upload"><i>
            <asp:FileUpload ID="filePath" runat="server" CssClass="fileUpload" /></i></div>
        <asp:LinkButton ID="lbUpload" runat="server" OnClick="lbUpload_Click"></asp:LinkButton>
    </form>
</body>
</html>
