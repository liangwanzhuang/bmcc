<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WarehousepharmacyUpdate.aspx.cs" Inherits="view_system_WarehousepharmacyUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>库房药房信息修改</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
     <script language="javascript" type="text/javascript">

         function btnRecipeOkClick() {
             var id = $("#idnum1").val();
             var WName = $("#WName1").val();
             var WareNum = $("#WareNum1").val();
             var Type = $("#Type1").val();

             //alert(WareNum);

             $.ajax({ type: "POST",
                 url: "WarehousepharmacyUpdate.aspx/WarehousepharmacyInfo",
                 data: "{'id':'" + id  + "','WName':'" + WName + "','WareNum':'" + WareNum + "','Type':'" + Type + "'}",
                 contentType: "application/json; charset-=utf-8",
                 success: function (data) {
                     if (data.d == "0") {
                         alert('修改失败,仓库编号已存在！');

                     } else {
                         alert('修改成功！');
                     }
                     var p = [];
                     dotNetFlexGrid3.applyQueryReload(p);
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
    <li><label>类&nbsp;&nbsp;&nbsp;&nbsp;型</label>
        <select id="Type1" runat="Server" class="dfinput">
            <option value="库房">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;库房</option>
            <option value="药房">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;药房</option>
        </select></li>
    <li><label>名称</label><input id="WName1" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
    <li><label>仓库编号</label><input id="WareNum1" runat="server" name="" type="text" class="dfinput"/></li>
   
       
    <li><label>&nbsp;</label><input id="btnok1" runat="Server" name="" type="button" class="btn" value="确认" onclick="btnRecipeOkClick();"/></li>
    </ul>
    
   </div>
  </form>
</body>
</html>