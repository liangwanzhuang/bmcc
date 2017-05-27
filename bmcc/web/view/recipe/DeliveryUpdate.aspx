<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeliveryUpdate.aspx.cs" Inherits="view_recipe_DeliveryUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>发货信息编辑</title>

     <script language="javascript" type="text/javascript">


         function CheckInputIntFloat(oInput) {
             if ('' != oInput.value.replace(/\d{1,}\.{0,1}\d{0,}/, '')) {
                 oInput.value = oInput.value.match(/\d{1,}\.{0,1}\d{0,}/) == null ? '' : oInput.value.match(/\d{1,}\.{0,1}\d{0,}/);
             }
         }

         function btnRecipeOkClick() {
             var id = $("#idnum").val();
             var DecoctingNum = $("#DecNum").val();
             var Sendpersonnel = $("#Sendper").val();
             var SendTime = $("#SendT").val();
             var Sendstate = $("#SendS").val();
             var Starttime = $("#StartT").val();
             var Remarks = $("#Rems").val();

             alert(id);
             $.ajax({ type: "POST",
                 url: "DeliveryUpdate.aspx/updateDeliveryInfo",
                 data: "{'id':'" + id + "','DecoctingNum':'" + DecoctingNum + "','Sendpersonnel':'" + Sendpersonnel + "','SendTime':'" + SendTime + "','Sendstate':'" + Sendstate + "','Starttime':'" + Starttime + "','Remarks':'" + Remarks + "'}",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     if (data.d == "0") {
                         alert('修改失败');

                     } else {
                         alert('修改成功');
                     }
                     var p = [];
                     dotNetFlexGrid7.applyQueryReload(p);
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
    <li><label>煎药单号</label><input id="DecNum" runat="Server" name="" type="text" class="dfinput" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"  /><i></i></li>
    <li><label>发货人员</label><input id="Sendper" runat="server" name="" type="text" class="dfinput"/></li>
    <li><label>发货时间</label><input id = "SendT" runat="Server" name="" type="text" class="dfinput" onfocus="calendar.show({ id: this });" readonly="readonly"/></li>
     <li><label>发货状态</label><select class="dfinput" id="SendS" runat="server" onChange="" name=""  style="text-align:center">
         <option value="1" selected>&nbsp;&nbsp;未发货&nbsp;&nbsp;</option>
           <option value="2" >&nbsp;&nbsp;已发货&nbsp;&nbsp;</option>
        </select></li>
        
   
    <li><label>开始时间</label><input id="StartT" runat="Server" name="" type="text" class="dfinput" onfocus="calendar.show({ id: this });" readonly="readonly"/><i></i></li>
    <li><label>备注</label><input id ="Rems" runat="Server" name="" type="text" class="dfinput" /></li>
    
   <li><label>&nbsp;</label><input id="update" runat="server" name="" type="button" class="btn" onclick="btnRecipeOkClick();" value="更新" /></li>
    </ul>
    
   </div>
  </form>
</body>
</html>