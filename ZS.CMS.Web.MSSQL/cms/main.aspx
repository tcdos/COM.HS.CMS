<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="cms_main" %>

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
            <a href="javascript:history.back(-1);" class="zs-back"><span>返回上一页</span></a><a href="main.aspx" class="zs-home"><span>首页</span></a><i class="zs-arrow"></i><span>管理中心</span>
        </div>
        <div class="zs-main">
            <div class="zs-line-20"></div>
            <div class="zs-text-list">
                <h2>登录信息</h2>
                <ul>
                    <li>本次登录IP：<asp:Literal ID="ltLoginIP" runat="server"></asp:Literal></li>
                    <li>上次登录IP：<asp:Literal ID="ltLastLoginIP" runat="server"></asp:Literal></li>
                    <li>上次登录时间：<asp:Literal ID="ltLastLoginTime" runat="server"></asp:Literal></li>
                </ul>
            </div>
            <div class="zs-line-20"></div>
            <div class="zs-text-list">
                <h2>站点信息</h2>
                <ul>
                    <li>网站域名：<%=ZS.KIT.znRequest.GetHost() %></li>
                    <li>服务器IP：<%=ZS.KIT.znRequest.GetServerString("LOCAL_ADDR") %></li>
                    <li>操作系统：<%=Environment.OSVersion.ToString() %></li>
                    <li>IIS环境：<%=ZS.KIT.znRequest.GetServerString("SERVER_SOFTWARE") %></li>
                    <li>NET框架版本：<%=Environment.Version.ToString() %></li>
                    <li>目录物理路径：<%=ZS.KIT.znRequest.GetServerString("APPL_PHYSICAL_PATH") %></li>
                </ul>
            </div>
            <div class="zs-line-20"></div>
            <div class="zs-text-list">
                <h2>技术支持</h2>
                <ul>
                    <li>授权使用：<b><asp:Literal ID="ltClient" runat="server" /></b></li>
                    <li>系统版本：<b><asp:Literal ID="ltZSCMSVer" runat="server" /></b></li>
                    <li>开发者：<b><asp:Literal ID="ltZSCMSTech" runat="server" /></b></li>
                </ul>
            </div>
        </div>
    </form>
</body>
</html>
