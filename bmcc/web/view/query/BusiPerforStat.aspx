<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BusiPerforStat.aspx.cs" Inherits="view_query_BusiPerforStat" %>
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
        function searchRecipeInfo() {

            var Salesman = $("#Salesman").val();
            var StaffId = $("#StaffId").val();
            var STime = $("#STime").val();
            var ETime = $("#ETime").val();

            var p = [{ name: "Salesman", value: Salesman }, { name: "StaffId", value: StaffId }, { name: "STime", value: STime }, { name: "ETime", value: ETime}];
            FlexGridRecipe.applyQueryReload(p);

        }
        //作废
        function deleteRecipeInfo() {
            var rows = FlexGridRecipe.getSelectedRowsIds();
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
                url: "BusiPerforStat.aspx/deleteBusiPerforStatById",
                data: "{'strRowIds':\"" + strRowIDs + "\"}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "0") {
                        alert('作废失败');
                    } else {
                        alert('作废成功');
                    }

                    var p = [];
                    FlexGridRecipe.applyQueryReload(p);
                }
            });
        }
       
           </script>
 
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
      <%--<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">查询统计</a></li>
    <li><a href="#">业务员业绩统计</a></li>
    <li><a href="#">业务员业绩统计</a></li>
    </ul>
    </div>--%>
   <div class="rightinfo">
          
    <div class="tools">
    
    	<ul class="toolbar">
        <li class="click" onclick="searchRecipeInfo();"><span><img src="../../img/t01.png" /></span>查询</li>
      
     
      <%--<li class="click"  onserverclick="Button1_Click"><span><img src="../../img/t04.png" /></span>导出数据</li>--%>
        <asp:Button ID="Button1"  runat="server" OnClick="Button1_Click"   Text='导出数据' CssClass="btn3"/>
           
        </ul>         
     
    </div>
    <ul class="forminfo">
     <li>
      <label>&nbsp;&nbsp;&nbsp;&nbsp;业务员</label><input id="Salesman" name="" runat="Server" type="text" class="dfinput2" /><i></i>
      <label>&nbsp;&nbsp;&nbsp;&nbsp;员工编号</label><input id="StaffId" name="" runat="Server" type="text" class="dfinput2" /><i></i></li>
    <li>
       

        <label>&nbsp;&nbsp;&nbsp;&nbsp;开始时间</label>
        <input class="dfinput2" id="STime" runat="Server" name=""  onfocus="SetDate(this)" readonly="readonly"/>
        <label>&nbsp;&nbsp;&nbsp;&nbsp;结束时间</label>
        <input class="dfinput2" id="ETime" runat="Server" name=""   onfocus="SetDate(this)" readonly="readonly"/>
    </li>
   

   </ul>

      <div style="width:600px; ">
     <uc1:dotNetFlexGrid ID="FlexGridRecipe" runat="server"  
   
      />   
     <br /></div>
     </div>
      </form>
</body>
</html>
