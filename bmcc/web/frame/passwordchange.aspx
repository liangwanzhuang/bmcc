<%@ Page Language="C#" AutoEventWireup="true" CodeFile="passwordchange.aspx.cs" Inherits="frame_passwordchange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

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

        if ($("#Password1").val() == "") {
            alert('请输入旧密码');
            $("#Password1").focus();
            return false;
        } else if ($("#txtUserPwd").val() == "") {
            alert('请输入新密码！');
            $("#txtUserPwd").focus();
            return false;
        } else if ($("#txtUserPwd2").val() == "") {
            alert('请确认密码！');
            $("#txtUserPwd2").focus();
            return false;
        }
        return true;
    }
    //关闭
    function winClose() {
        window.close();
    }

</script> 

<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <div class="regbox">
    <ul class ="" style ="list-style:none;">
    <li><label>旧 密 码 ：</label><input id="Password1" runat="server" name="pword" type="password" class="loginpwd" value="" onclick="JavaScript:this.value=''"/></li>
    <li><label>新 密 码 ：</label><input id="txtUserPwd" runat="server" name="pword" type="password" class="loginpwd" value=""  onclick="JavaScript:this.value=''"/></li>
    <li><label>确认密码 ：</label><input id="txtUserPwd2" runat="server" name="pword" type="password" class="loginpwd" value=""  onclick="JavaScript:this.value=''"/></li>
    <li>
    <label></label><asp:Button runat="server" ID="btnRegister" CssClass="loginbtn" Text="确定" 
            OnClientClick="return winLogin()" onclick="btnLogin_Click" />
        <input name="" type="button" class="loginbtn" value="关闭"  onclick="winClose()"  />
        </li>
    </ul>
    
    
    </div>
    </form>
</body>
</html>
