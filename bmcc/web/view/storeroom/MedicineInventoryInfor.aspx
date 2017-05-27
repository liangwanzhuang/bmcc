<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MedicineInventoryInfor.aspx.cs" Inherits="view_storeroom_MedicineInventoryInfor" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="../../js/time.js"></script>
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript">
        //查询
        function searchCompInfo() {
            var DrugName = $("#DrugName").val();
            var Warehouse = $("#Warehouse").val();
          
            var p = [{ name: "DrugName", value: DrugName }, { name: "Warehouse", value: Warehouse}];
            FlexGridInventoryInfor.applyQueryReload(p);

        }
        function doReset() {

            $("select").val("0");
            document.getElementById("DrugName").value = "";
          /*  for (i = 0; i < document.all.tags("input").length; i++) {
                if (document.all.tags("input")[i].type == "text") {
                    document.all.tags("input")[i].value = "";
                }

            }
            alert("置空成功！");*/
        }
        //作废
        function deleteInventoryInforInfo() {
            var rows = FlexGridInventoryInfor.getSelectedRowsIds();
            var strRowIDs = "";
            if (rows.length > 0) {
                strRowIDs = rows[0];
            } else {
                alert("请选择需要作废的一行");
                return;
            }

            for (var i = 1; i < rows.length; i++) {
                strRowIDs += "," + rows[i]; // alert(rows[i]);
            }

            $.ajax({ type: "POST",
                url: "InventoryInfor.aspx/deleteInventoryById",
                data: "{'strRowIds':\"" + strRowIDs + "\"}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "0") {
                        alert('作废失败,');
                    } else {
                        alert('作废成功');
                    }

                    var p = [];
                    FlexGridInventoryInfor.applyQueryReload(p);
                }
            });
        }
</script>
<style type="text/css">
.btn3 {
    font-size: 9pt;
    color: #003399;
    border: 1px #003399 solid;
    color: #006699;
    border-bottom: #93bee2 1px solid;
    border-left: #93bee2 1px solid;
    border-right: #93bee2 1px solid;
    border-top: #93bee2 1px solid;
 
    background-color: #F5F7F9;
    cursor: hand;
    font-style: normal;
    width: 80px;
    height: 34px;
    
}
</style>  
</head>
<body>
    <form id="form1" runat="server">
    
   <div class="rightinfo">
          
    <div class="tools">
    
    	<ul class="toolbar">
      
        <li class="click" onclick="searchCompInfo();"><span><img src="../../img/t01.png" /></span>查询</li>
        <li class="click" onclick="doReset();"><span><img src="../../img/r01.png" /></span>重置</li>
       
        
        <asp:Button ID="Button1"  runat="server" onclick="ExportMedicineInventoryInfor_Click"   Text='导出数据' CssClass="btn3"/>
        </ul>         
     
    </div>
    <ul class="forminfo">
     <li>
      <label>药品名称</label>
       <input class="dfinput2" id="DrugName" runat="Server" name=""  />
     
      <label>&nbsp;&nbsp;&nbsp;&nbsp;仓库</label>
      <select class="dfinput2" id="Warehouse" runat="server" name="hostpitalname" onChange="" style="text-align:center">
       
         
        </select>
     
     </li>
 
   

   </ul>

      <div style="width:1000px; ">
     <uc1:dotNetFlexGrid ID="FlexGridInventoryInfor" runat="server"  
   
      />   
     <br /></div>
     </div>
      </form>
</body>
</html>

   
