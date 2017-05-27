<%@ Page Language="C#" AutoEventWireup="true" CodeFile="setKey.aspx.cs" Inherits="view_logistics_setKey" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script language="JavaScript" src="../../js/jquery.js"></script>
    <script>
        function confirm() {
            var key = $('#key').val();
            if (key.length == 0) {
                alert('key值不允许为空');
                return;
            }
            $.ajax({ type: "POST",
                url: "setKey.aspx/updateLogisticsKey",
                data: "{'key':'" + key + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "0") {
                        alert("操作失败");
                    } else {

                        alert("操作成功");
                        history.go(0);
                    }
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="formbody">
    
        <div class="formtitle"><span>设置物流key</span></div>
    
        <ul class="forminfo">

        <li><label>key</label><input id="key" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
    
        <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" onclick="confirm();" type="button" class="btn" value="确认" /></li>
        </ul>
        </div>
    </div>
    </form>
</body>
</html>
