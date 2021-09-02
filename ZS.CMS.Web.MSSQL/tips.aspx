<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeFile="tips.aspx.cs" Inherits="tips" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        /*系统提示*/
        * {
            padding: 0px;
            margin: 0px;
        }
        html, body {
            position: relative;
            width: 100%;
            height: 100%;
            background: #fff;
            overflow: hidden;
        }
        body, td, th, a {
            color: #444;
            font-size: 12px;
            font-family: "Microsoft YaHei";
            text-decoration: none;
        }
        .zs-tips-bg {
            background: #fff;
        }
        .zs-tips {
            margin: 150px auto 0px auto;
            width: 500px;
            text-align: center;
            border: 1px dotted #ddd;
        }
        .zs-tips p.msg {
            padding: 30px 0px;
            line-height: 2em;
            background: #f8f8f8;
        }
        .zs-tips p.msg a {
            display: inline-block;
            margin: 10px 0px 0px 0px;
            width: 60px;
            color: #fff;
            line-height: 2em;
            background: #5299E7;
            text-decoration: none;
        }
        .zs-tips p.tech {
            padding: 5px 0px;
            line-height: 2em;
            background: #f0f0f0;
        }
    </style>
</head>
<body class="zs-tips-bg">
    <form id="form_tips" runat="server">
        <div class="zs-tips">
            <p class="msg">
                <asp:Literal ID="litErrMsg" runat="server"></asp:Literal><br />
                <a href="javascript:history.back(-1);"><span>返回</span></a></p>
            <p class="tech">
                <asp:Literal ID="litTech" runat="server"></asp:Literal></p>
        </div>
    </form>
</body>
</html>
