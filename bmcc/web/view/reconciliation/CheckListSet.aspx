<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckListSet.aspx.cs" Inherits="view_reconciliation_CheckListSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>设置对账信息</title>

   <script language="javascript" type="text/javascript">

         function btnRecipeOkClick() {
             var id = $("#idnum").val();
             var dPer = $("#dPer").val();

             //alert(dPer);
             $.ajax({ type: "POST",
                 url: "CheckListSet.aspx/updateInfo",
                 data: "{'id':'" + id + "','dPer':'" + dPer + "'}",
               
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     if (data.d == "0") {
                         alert('修改失败');

                     } else {
                         alert('修改成功');
                     }
                     var p = [];
                     FlexGridCheckList.applyQueryReload(p);
                 }
             });
         }
    </script>
</head>
<body>
       <form id="form1" runat="server">
   <div class="formbody">
    
     <div class="formtitle"><span>发货信息</span></div>
    <input id ="idnum" runat="server" type="hidden" name="FunName"/> 
    
   <ul class="forminfo">
   <li><label>对账人</label>
         <input id="dPer" runat="server" name="" type="text" class="dfinput"/></li>
        
   <li><label>&nbsp;</label><input id="update" runat="server" name="" type="button" class="btn" onclick="btnRecipeOkClick();" value="设置" /></li>
    </ul>
    
   </div>
  </form>
</body>
</html>