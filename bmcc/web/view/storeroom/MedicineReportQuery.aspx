<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MedicineReportQuery.aspx.cs" Inherits="view_storeroom_MedicineReportQuery" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="../../js/time.js"></script>
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript">
        //查询
        function searchCompInfo() {

            var Type = $("#Type").val();
            var STime = $("#STime").val();
            var ETime = $("#ETime").val();
            var p = [{ name: "Type", value: Type }, { name: "STime", value: STime }, { name: "ETime", value: ETime}];

            FlexGridReportQuery.applyQueryReload(p);

        }


        //重置
        function doReset() {

            $("select").val("0");
            document.getElementById("STime").value = "";
            document.getElementById("ETime").value = "";

            /*for (i = 0; i < document.all.tags("input").length; i++) {
                if (document.all.tags("input")[i].type == "text") {
                    document.all.tags("input")[i].value = "";
                }

            }
            alert("置空成功！");*/
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
    
}</style>
</head>
<body>
    <form id="form1" runat="server">
    
   <div class="rightinfo">
          
    <div class="tools">
    
    	<ul class="toolbar">
       
        <li class="click" onclick="searchCompInfo();"><span><img src="../../img/t01.png" /></span>查询</li>

         <li class="click" onclick="doReset();"><span><img src="../../img/r01.png" /></span>重置</li>
       
        <input type="Button" ID="Button1"  runat="server" onserverclick="ExportReportQuery_Click"   value='导出数据' class="btn3"/>
        </ul>         
     
    </div>
    <ul class="forminfo">
    <li>
       

        <label>开始时间</label>
        <input class="dfinput2" id="STime" runat="Server" name=""  onfocus="SetDate(this)" readonly="readonly"/>
        <label>&nbsp;&nbsp;&nbsp;&nbsp;结束时间</label>
        <input class="dfinput2" id="ETime" runat="Server" name=""   onfocus="SetDate(this)" readonly="readonly"/>
    </li>
   
     <li>
     
     
     <!-- <label>报单类型</label>
      <select class="dfinput2" id="Type" runat="server" name="hostpitalname" onChange="" style="text-align:center">
      <option value="0">全部</option>
       <option value="2">退货作废单</option>
            
            <option value="1">调拨申请单</option>
         
        </select>
         <br /> <br /><br />-->
      <div style="width:1000px; ">
     <uc1:dotNetFlexGrid ID="FlexGridReportQuery" runat="server"   />    </div>
     </li>
   </ul>

    
      </form>
</body>
</html>

   
