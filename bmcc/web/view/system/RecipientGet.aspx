<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecipientGet.aspx.cs" Inherits="view_system_RecipientGet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>添加收件人信息</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function btnok_onclick() {

            var ClearPName = $("#ClearPName1").val();
            var Telephone = $("#Telephone").val();
            var Remarks = $("#Remarks").val();
            var Address = $("#Address").val();
           
            //alert(JobNum);
            if (ClearPName == "") {
                alert('请输入收件人姓名！');
                return false;
            } else if (Telephone == "") {
                alert("请输入联系电话！");
                return false;

            } else if (Address == "") {
                alert("请输地址！");
                return false;

            }
           

            $.ajax({ type: "POST",
                url: "RecipientGet.aspx/addRecipientinfo",
                data: "{'ClearPName':'" + ClearPName + "','Telephone':'" + Telephone + "','Address':'" + Address + "','Remarks':'" + Remarks + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "0") {
                        alert('添加失败');

                    } else {
                        alert('添加成功');
                    }
                    var p = [];
                    FlexGridRecipient.applyQueryReload(p);
                }
            });

            return true;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
 <div style="overflow:scroll; width:570px; height:430px;">
    
   
    
   <ul class="forminfo">
     <div class="formtitle"><span>收件人信息</span></div>
    <li><label>收件人名称</label><input id="ClearPName1" runat="Server" name="" type="text" class="dfinput2" /><i></i></li>
    <li><label>联系电话</label><input id="Telephone" runat="server" name="" type="text" class="dfinput2"/></li>
    
    <li><label>住&nbsp;&nbsp;&nbsp;&nbsp;址</label><input id ="Address" runat="Server" name="" type="text" class="dfinput2" /><i></i></li>
     <li><label>备&nbsp;&nbsp;&nbsp;&nbsp;注</label><input id ="Remarks" runat="Server" name="" type="text" class="dfinput2"  /></li>
    <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" type="button" class="btn" value="确认" onclick=" btnok_onclick();"/></li>
    </ul>
    
   </div>
  </form>
</body>
</html>