<%@ Page Language="C#" AutoEventWireup="true" CodeFile="autoPrintOnOff.aspx.cs" Inherits="view_system_autoPrintOnOff" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script>
        function confirm() {
            var onOff = $('#printOnOff').val();
            $.ajax({ type: "POST",
                url: "autoPrintOnOff.aspx/updatePrintOnOff",
                data: "{'onOff':'" + onOff + "'}",
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
    
            <div class="formtitle"><span>设置自动打印</span></div>
    
            <ul class="forminfo">

            <li><label>自动打印</label>

                <select id="printOnOff" runat="server" class="dfinput" name="Clearingparty" style="text-align:center">
                    <option value="0">关闭</option>
                    <option value="1">开启</option>
                </select>
            </li>
    
            <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" onclick="confirm();" type="button" class="btn" value="确认" /></li>
            </ul>
            </div>
        </div>
    </form>
</body>
</html>
