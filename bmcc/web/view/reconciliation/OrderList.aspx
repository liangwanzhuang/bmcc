<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" Inherits="view_reconciliation_OrderList" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>订单列表</title>
     <link href="../../css/style.css" rel="stylesheet" type="text/css" />
         <script type="text/javascript" src="../../js/time.js"></script>
     <script type="text/javascript">
         //查询
         function searchCompInfo() {
             var per = $("#per").val();
             var hospitalSelect = $("#hospitalSelect");
             var STime = $("#STime").val();
             var ETime = $("#ETime").val();

             var p = [{ name: "per", value: per }, { name: "hospitalId", value: "" + hospitalSelect.val() + "" }, { name: "STime", value: STime }, { name: "ETime", value: ETime}];
             FlexGridOrderList.applyQueryReload(p);

         }
         function doReset() {

             $("select").val("0");
//             for (i = 0; i < document.all.tags("input").length; i++) {
//                 if (document.all.tags("input")[i].type == "text") {
//                     document.all.tags("input")[i].value = "";
//                 }

             //             }
             $("#per").val("");
             $("#STime").val("");
             $("#ETime").val("");
             alert("置空成功！");
         }
     </script>
</head>
<body>
    <form id="form1" runat="server">
      <div class="rightinfo">
          
    <div class="tools">
    
    	<ul class="toolbar">
       
        <li class="click" onclick="searchCompInfo();"><span><img src="../../img/t01.png" /></span>查询</li>
        <li class="click" onclick="doReset();"><span><img src="../../img/r01.png" /></span>重置</li>
        
       <%--  <li class="click"><span><img src="../../img/t04.png" /></span>导出数据</li>--%>
        </ul>         
     
    </div>
      <ul class="forminfo">
     <li>
      <label>对账人</label>
       <input class="dfinput2" id="per" runat="Server" name=""  />
      
   <label>&nbsp;&nbsp;&nbsp;&nbsp;医院名称</label>
        <select id="hospitalSelect" runat="server" class="dfinput2" name="hostpital" onchange="hospitalSelectChange(this);" style="text-align:center">
          <option value="0" selected>全部&nbsp;&nbsp;</option>
          
        </select>
     
     </li>
     
    <li>
       

        <label>开始时间</label>
        <input class="dfinput2" id="STime" runat="Server" name=""  onfocus="SetDate(this)" readonly="readonly"/>
        <label>&nbsp;&nbsp;&nbsp;&nbsp;结束时间</label>
        <input class="dfinput2" id="ETime" runat="Server" name=""   onfocus="SetDate(this)" readonly="readonly"/>
    </li>
   

   </ul>
     <div style="width:1000px; ">
     <uc1:dotNetFlexGrid ID="FlexGridOrderList" runat="server"  
   
      /> </div></div>
    </form>
</body>
</html>
