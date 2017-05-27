<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ComprehenWarning.aspx.cs" Inherits="view_central_ComprehenWarning" %>
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
           
            var HandleStatus = $("#HandleStatus").val();
            var Pspnum = $("#Pspnum").val();
            var hospitalSelect = $("#hospitalSelect").val();
            var EarlyWarning = $("#EarlyWarning").val();
            var STime = $("#STime").val();
            var ETime = $("#ETime").val();
            
            

            //var p = [{ name: "bubbleman", value: bubbleman.val() }, { name: "bubblestatus", value: bubblestatus.val()}];
           // FlexGridDrugGlobal1.applyQueryReload(p);
            var p = [{ name: "hospitalId", value: hospitalSelect }, { name: "HandleStatus", value: HandleStatus }, { name: "Pspnum", value: Pspnum }, { name: "EarlyWarning", value: EarlyWarning }, { name: "STime", value: STime }, { name: "ETime", value: ETime}];
            FlexGridRecipe.applyQueryReload(p);
           // setTimeout('searchCompInfo()', 1000); //指定1秒刷新一次
        }
        function doReset() {

            $("select").val("0");
            $("#Pspnum").val("");
            $("#STime").val("");
            $("#ETime").val("");
          /*  for (i = 0; i < document.all.tags("input").length; i++) {
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
    <%-- <div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">中心监控</a></li>
    <li><a href="#">综合预警</a></li>
    <li><a href="#">综合预警</a></li>
    </ul>
    </div>--%>
    <div class="rightinfo">
          
    <div class="tools">
    
    	<ul class="toolbar">
        <li class="click" onclick="searchCompInfo();"><span><img src="../../img/t01.png" /></span>查询</li>
        <li class="click" onclick="doReset();"><span><img src="../../img/r01.png" /></span>重置</li>
        
       <%--<li class="click"  onserverclick="Button1_Click"><span><img src="../../img/t04.png" /></span>导出数据</li>--%>
        <asp:Button ID="Button1"  runat="server" OnClick="Button1_Click"   Text='导出数据' CssClass="btn3"/>
        </ul>         
     
    </div>
    <ul class="forminfo">
     <li>
      <label>异常类型</label>
        <select class="dfinput2" id="EarlyWarning" runat="server" name="" onChange="" style="text-align:center">
        <option value="0" selected>全部&nbsp;&nbsp;</option>
          <option value="审核异常">审核异常</option>
          <option value="审核预警">审核警告</option>
          <option value="调剂预警">调剂警告</option>
          <option value="复核预警">复核警告</option>
          <option value="泡药预警">泡药警告</option>
          <option value="煎药预警">煎药警告</option>
          <option value="包装预警">包装警告</option>
          <option value="发货预警">发货警告</option>
         

          
         
        </select>
      <label>&nbsp;&nbsp;&nbsp;&nbsp;处理状态</label>
      <select class="dfinput2" id="HandleStatus" runat="server" name="hostpitalname" onChange="" style="text-align:center">
      <option value="0" selected>全部&nbsp;&nbsp;</option>
          
          <option value="1" > 未处理</option>
          <option value="2"> 已处理</option>
         
         
        </select>
      
        <label>&nbsp;&nbsp;&nbsp;&nbsp;医院名称</label>
 
        <select id="hospitalSelect" class="dfinput2" name="hostpital" onchange="hospitalSelectChange(this);"  style="text-align:center" runat="server" >
          
        </select>
     </li>
     
    <li>
       
       <label>处方号</label>
        <input class="dfinput2" id="Pspnum" runat="Server" name=""  />
        <label>&nbsp;&nbsp;&nbsp;&nbsp;开始时间</label>
        <input class="dfinput2" id="STime" runat="Server" name=""  onfocus="SetDate(this)" readonly="readonly"/>
        <label>&nbsp;&nbsp;&nbsp;&nbsp;结束时间</label>
        <input class="dfinput2" id="ETime" runat="Server" name=""   onfocus="SetDate(this)" readonly="readonly"/>
    </li>
   </ul>

      <div style="width:1000px; ">
     <uc1:dotNetFlexGrid ID="FlexGridRecipe" runat="server"  
   
      />   
     <br /></div>
     </div>
      </form>
</body>
</html>

   
