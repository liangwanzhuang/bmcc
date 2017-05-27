<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

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
        var regtel = /^((13[0-9]{9})|(159[0-9]{8}))$/;
        var regEmail = /^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$/;
        var regusername = /^[a-zA-Z\u4e00-\u9fa5][a-zA-Z0-9_\u4E00-\u9FA5]{5,15}$/;
        var regpassword = /^[a-zA-Z0-9]{6,16}$/;
        if ($("#txtUserName").val() == "") {
            alert("请输入用户名！");
            $("#txtUserName").focus();
            return false;
        }else if (!regusername.test(document.getElementById("txtUserName").value)){
            alert("用户名可以由字母、数字、下划线和中文组成，以中文或字母开头，长度为6-16位");
            return false;
        }
        else if ($("#txtUserPwd").val() == "") {
            alert("请输入密码！");
            $("#txtUserPwd").focus();
            return false;
        } else if (!regpassword.test(document.getElementById("txtUserPwd").value)) {
            alert("密码可以由字母、数字组成，长度为6-16位");
            return false;
        }
         else if ($("#txtUserPwd2").val() == "") {
            alert("请确认密码！");
            return false;
        } else if ($("#txtUserPwd2").val() != $("#txtUserPwd").val()) {
            alert("两次输入的密码不一样");
            return false;
        } else if ($("#txtTel").val() == "") {
            alert("请输入手机号！");
            return false;
        } else if (!regtel.test(document.getElementById("txtTel").value)) {
        alert("输入的手机号不正确");
            return false;
        } else if ($("#txtEmail").val() == "") {
            alert("请输入邮箱号！");
            return false;
        }
        else if (!regEmail.test(document.getElementById("txtEmail").value)) {
            alert("输入的邮箱不正确！");
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
    <span>欢迎注册北京东华原煎药管理系统</span>    
    <ul>
    <li><a href="###" >帮助</a></li>
    </ul>    
    </div>
    
    <div class="loginbody">
    
    <span style="margin-top:10px;text-align:center;font-size:40px;color:#fff;">北京东华原煎药管理系统</span> 
       
    <div class="regbox">
    <ul class ="">
    <li><label>用户名：</label><input id="txtUserName" runat="server" name="uname" type="text" class="loginuser" value="" onclick="JavaScript:this.value=''"/></li>
    <li><label>密 码 ：</label><input id="txtUserPwd" runat="server" name="pword" type="password" class="loginpwd" value="" placeholder="" onclick="JavaScript:this.value=''"/></li>
    <li><label>确认密码：</label><input id="txtUserPwd2" runat="server" name="pword" type="password" class="loginpwd" value=""  placeholder="" onclick="JavaScript:this.value=''"/></li>
    <li> <label>手机号：</label><input id="txtTel" runat="server" name="uname" type="text" class="regtel" value="" onclick="JavaScript:this.value=''"/></li>
    <li><label>邮 箱：</label><input id="txtEmail" runat="server" name="uname" type="text" class="regemail" value="" onclick="JavaScript:this.value=''"/></li>
    <li>
    <label>&nbsp;&nbsp;  &nbsp;&nbsp;  &nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label><asp:Button runat="server" ID="btnRegister" CssClass="loginbtn" Text="注册" 
            OnClientClick="return winLogin()" onclick="btnLogin_Click" />
        <input name="" type="button" class="loginbtn" value="关闭"  onclick="winClose()"  />
        已经注册？快去<a href="login.aspx"><strong><font color="#FF0000">登录</font></strong></a>吧
        </li>
    </ul>
    
    
    </div>
    
    </div>
    
    <div class="loginbm">© 技术支持：<a href="" target="_blank"> *********有限公司</a>&emsp;Ver:1.28(2015.03.18)&emsp;最佳分辨率：1024×768&emsp;</div>
	
  </form>  
</body>

</html>
