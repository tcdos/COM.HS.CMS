<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="cms_login" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <link rel="stylesheet" href="style/login.css" >
    <title></title>
    <script type="text/javascript">
        if (top.location !== self.location) {
            top.location.href = self.location.href;
        }
</script> 
</head>
<body>
    <form id="form_login" runat="server">
    <div class="zs-login-content">
	    <div class="zs-login-head">
		    <h1>Welcome and Login</h1>
	    </div>
        <div class="zs-login-msg" id="msg" runat="server"></div>
	    <div class="zs-login-main">
		    <div class="row">
                <asp:TextBox ID="tbUserName" runat="server" maxlength="20" placeholder="帐号"></asp:TextBox>
		    </div>
		    <div class="row">
                <asp:TextBox ID="tbUserPwd" runat="server" TextMode="Password" maxlength="20" placeholder="密码"></asp:TextBox>
		    </div>
		    <div class="row">
                <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" />
		    </div>
	    </div>
    </div>
    </form>
</body>
</html>
