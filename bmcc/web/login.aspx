<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>北京东华原煎药管理系统</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="JavaScript" src="js/jquery.js"></script>
<script type="text/javascript" language="JavaScript" src="js/cloud.js"></script>
<script type="text/javascript" language="javascript">
    $(function () {
        $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
        $(window).resize(function () {
            $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
        })
        $("#txtUserName").focus();
    });

    //登录
    function winLogin() {

        if ($("#txtUserName").val() == "") {
            alert("请输入用户工号！");
            $("#txtUserName").focus();
            return false;
        } else if ($("#txtUserPwd").val() == "") {
            alert("请输入密码！");
            $("#txtUserPwd").focus();
            return false;
        }
        return true;




    }
    //关闭
    function winClose() {
        window.close();
    }

</script> 

</head>

<body style="background-color:#1c77ac; background-image:url(img/light.png); background-repeat:no-repeat; background-position:center top; overflow:hidden;">


<form runat="server" id="form1">
    <div id="mainBody">
      <div id="cloud1" class="cloud"></div>
      <div id="cloud2" class="cloud"></div>
    </div>  


<div class="logintop">    
    <span>欢迎登录北京东华原煎药管理系统</span>    
    <ul>
    <li><a href="###" >帮助</a></li>
    </ul>    
    </div>
    
    <div class="loginbody">
    
    <span style="margin-top:75px;text-align:center;font-size:40px;color:#fff;">北京东华原煎药管理系统</span> 
       
    <div class="loginbox">
    
    <ul>
    <li><input id="txtUserName" runat="server" name="" type="text" class="loginuser" value="" onclick="JavaScript:this.value=''"/></li>
    <li><input id="txtUserPwd" runat="server" name="" type="password" class="loginpwd" value="" onclick="JavaScript:this.value=''"/></li>
    <li>
    <asp:Button runat="server" ID="btnLogin" CssClass="loginbtn" Text="登录" 
            OnClientClick="return winLogin()" onclick="btnLogin_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input name="" type="button" class="loginbtn" value="关闭"  onclick="winClose()"  /></li>
   
    </ul>
    
    
    </div>
    
    </div>
    
    
    
    <div class="loginbm">&emsp;Ver:1.28(2015.03.18)&emsp;最佳分辨率：1024×768&emsp;</div>
	
  </form>  
</body>

</html>
