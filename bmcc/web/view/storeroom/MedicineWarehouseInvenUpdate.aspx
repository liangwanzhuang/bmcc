<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MedicineWarehouseInvenUpdate.aspx.cs" Inherits="view_storeroom_MedicineWarehouseInvenUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
<link href="../../css/style.css" rel="stylesheet" type="text/css" />
     <script language="javascript" type="text/javascript">

         function btnok_onclick() {
             var id = $("#idnum1").val();
             var Warehouse = $("#Warehouse1").val();
             var InventoryPer = $("#InventoryPer").val();

             var ActualCapacity = $("#ActualCapacity").val();
             var InventoryStatus = $("#InventoryStatus").val();
             var remark = $("#Rmarkes").val();
             var StorageCondition = $("#StorageCondition").val();

             // alert(id);

             $.ajax({ type: "POST",
                 url: "MedicineWarehouseInvenUpdate.aspx/MedicineWarehouseInvenUpdateInfo",
                 data: "{'id':'" + id + "','Warehouse':'" + Warehouse + "','InventoryPer':'" + InventoryPer + "','ActualCapacity':'" + ActualCapacity + "','InventoryStatus':'" + InventoryStatus + "','StorageCondition':'" + StorageCondition + "','remark':'" + remark + "'}",
                 contentType: "application/json; charset-=utf-8",
                 success: function (data) {
                     if (data.d == "0") {
                         alert('修改失败,可能药房已盘点！');

                     } else {
                         alert('修改成功！');
                     }
                     var p = [];
                     FlexGridMWarehouseInven.applyQueryReload(p);
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
     <div class="formtitle"><span>药房盘点基本信息</span></div>
    
    <li><label>盘点人</label><input id="InventoryPer" runat="server" name="" type="text" class="dfinput2" />
    <label>仓库</label><select id="Warehouse1" runat="Server" class="dfinput2">
            
        </select></li>
    <li>
       
    <label>实际容量</label><input id="ActualCapacity" runat="server" name="" type="text" class="dfinput2"/>
    <label>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注</label><input id ="Rmarkes" runat="Server" name="" type="text" class="dfinput2" /></li>
    <li> <label>库存状况</label> <select id="InventoryStatus" runat="Server" class="dfinput2" >
            <option value="0">安全</option>

            <option value="1">不安全</option>
            
        </select>

   <label>保管条件</label><select id="StorageCondition" runat="Server" class="dfinput2">
            <option value="0">合格</option>

            <option value="1">不合格</option>
            
        </select></li>
  
    
    
  <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" type="button" class="btn" value="确认" onclick=" btnok_onclick();"/></li>
    </ul>





   </div>
  </form>
</body>
</html>