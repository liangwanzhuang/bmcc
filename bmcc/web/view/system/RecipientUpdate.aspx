<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecipientUpdate.aspx.cs" Inherits="view_system_RecipientUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <title>收件人信息修改</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
     <script language="javascript" type="text/javascript">

         function btnRecipeOkClick() {
             var id = $("#idnum1").val();
             var ClearPName = $("#ClearPName1").val();
             var Telephone = $("#Telephone").val();
             var Remarks = $("#Remarks").val();


             var Address = $("#Address").val();
            
             //alert(JobNum);

             $.ajax({ type: "POST",
                 url: "RecipientUpdate.aspx/RecipientUpdateInfo",
                 data: "{'id':'" + id + "','ClearPName':'" + ClearPName + "','Telephone':'" + Telephone + "','Remarks':'" + Remarks + "','Address':'" + Address + "'}",
                 contentType: "application/json; charset-=utf-8",
                 success: function (data) {
                     if (data.d == "0") {
                         alert('修改失败！');

                     } else {
                         alert('修改成功！');
                     }
                     var p = [];
                     FlexGridRecipient.applyQueryReload(p);
                 }
             });

         }
       
    </script>
</head>
<body>
   <form id="form1" runat="server">
    <div style="overflow:scroll; width:570px; height:430px;">
    <input id ="idnum1" runat="server" type="hidden" name="FunName"/> 
   
    
   <ul class="forminfo">
     <li><label>收件人名称</label><input id="ClearPName1" runat="Server" name="" type="text" class="dfinput2" /><i></i></li>
    <li><label>联系电话</label><input id="Telephone" runat="server" name="" type="text" class="dfinput2"/></li>
    
    <li><label>住&nbsp;&nbsp;&nbsp;&nbsp;址</label><input id ="Address" runat="Server" name="" type="text" class="dfinput2" /><i></i></li>
     <li><label>备&nbsp;&nbsp;&nbsp;&nbsp;注</label><input id ="Remarks" runat="Server" name="" type="text" class="dfinput2"  /></li>
    
    <li><label>&nbsp;</label><input id="btnok1" runat="Server" name="" type="button" class="btn" value="确认" onclick="btnRecipeOkClick();"/></li>
    </ul>
    
   </div>
  </form>
</body>
</html>