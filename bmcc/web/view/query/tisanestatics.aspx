<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tisanestatics.aspx.cs" Inherits="view_query_tisanestatics" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
      <script type="text/javascript" src="../../js/time.js"></script>
    <link href="../../css/hDate.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/jquery.date.js"></script>
    <script type="text/javascript" src="../../js/hDate.js"></script>
     <link rel="stylesheet" href="../../chart/style.css" type="text/css" />
    <script src="../../chart/amcharts.js" type="text/javascript"></script>
	<script src="../../chart/serial.js" type="text/javascript"></script>
 
     <script type="text/javascript">
        
         function findTisaneBtn() {
             var tisanenum = $("#tisanenum");
             var StartTime = $("#StartTime");
             var EndTime = $("#EndTime");
          

             var p = [{ name: "tisanenum", value: tisanenum.val() }, { name: "StartTime", value: StartTime.val() }, { name: "EndTime", value: EndTime.val()}];
             FlexGrid2.applyQueryReload(p);
             var strdata = "{'tisanenum':'" + tisanenum.val() + "','StartTime':'" + StartTime.val() + "','EndTime':'" + EndTime.val() + "'}";
             $.ajax({ type: "POST",
                 url: "tisanestatics.aspx/findtisanemachineInfo",
                 data: strdata,
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {

                    
                     var jsonobj = jQuery.parseJSON(data.d)

                     var chartData = [];

                     $.each(jsonobj, function (i, item) {

                         chartData.push({
                             date: item.workdate,
                             visits: item.workload
                         });

                     });

                     chart.dataProvider = chartData;
                     chart.validateNow();
                     chart.validateData();
                 }
             });
         }
         $(function () {
             setChart();

         })
         var chart;
         function setChart() {
             var chartData = $("#chartData").val();

             //alert(chartData);
             var jsonobj = jQuery.parseJSON(chartData)

             var chartData = [];
             var chartCursor;


             AmCharts.ready(function () {

                 // generate some data first
                 //generateChartData();
                 $.each(jsonobj, function (i, item) {
                     chartData.push({
                         date: item.workdate,
                         visits: item.workload
                     });

                 });
                 /*
                 chartData.push({
                 date: '2015-05-04',
                 visits: '3'
                 });
                 chartData.push({
                 date: '2015-05-05',
                 visits: '12'
                 });
                 chartData.push({
                 date: '2015-05-06',
                 visits: '23'
                 });
                 chartData.push({
                 date: '2015-05-07',
                 visits: '27'
                 });
                 chartData.push({
                 date: '2015-05-08',
                 visits: '35'
                 });
                 chartData.push({
                 date: '2015-05-09',
                 visits: '38'
                 });*/

                 // SERIAL CHART
                 chart = new AmCharts.AmSerialChart();
                 //    chart.pathToImages = "../amcharts/images/";
                 chart.dataProvider = chartData;
                 chart.categoryField = "date";
                 chart.balloon.bulletSize = 5;

                 // listen for "dataUpdated" event (fired when chart is rendered) and call zoomChart method when it happens
                 //  chart.addListener("dataUpdated", zoomChart);

                 // AXES
                 // category
                 var categoryAxis = chart.categoryAxis;
                 // categoryAxis.parseDates = true; // as our data is date-based, we set parseDates to true
                 //  categoryAxis.minPeriod = "DD"; // our data is daily, so we set minPeriod to DD
                 categoryAxis.dashLength = 0;
                 //    categoryAxis.minorGridEnabled = true;
                 //    categoryAxis.twoLineMode = true;
                 categoryAxis.dateFormats = [{
                     period: 'fff',
                     format: 'fff'
                 }, {
                     period: 'ss',
                     format: 'ss'
                 }, {
                     period: 'mm',
                     format: 'mm'
                 }, {
                     period: 'hh',
                     format: 'hh'
                 }, {
                     period: 'DD',
                     format: 'DD'
                 }, {
                     period: 'WW',
                     format: 'DD'
                 }, {
                     period: 'MM',
                     format: 'MMM'
                 }, {
                     period: 'YYYY',
                     format: 'YYYY'
                 }];

                 categoryAxis.axisColor = "#DADADA";

                 // value
                 //  var valueAxis = new AmCharts.ValueAxis();
                 //  valueAxis.axisAlpha = 0;
                 //   valueAxis.dashLength = 1;
                 //   chart.addValueAxis(valueAxis);

                 // GRAPH
                 var graph = new AmCharts.AmGraph();
                 graph.title = "red line";
                 graph.valueField = "visits";
                 graph.bullet = "round";
                 graph.bulletBorderColor = "#7EA0CC";
                 graph.bulletBorderThickness = 1;
                 graph.bulletBorderAlpha = 1;
                 graph.lineThickness = 2;
                 graph.lineColor = "#7EA0CC";
                 graph.bulletColor = "#ffffff";

                 graph.negativeLineColor = "#efcc26";
                 //graph.hideBulletsCount = 50; // this makes the chart to hide bullets when there are more than 50 series in selection
                 chart.addGraph(graph);

                 // CURSOR
                 chartCursor = new AmCharts.ChartCursor();
                 chartCursor.cursorPosition = "mouse";
                 chartCursor.color = "#FFFFFF";
                 chartCursor.pan = true; // set it to fals if you want the cursor to work in "select" mode
                 chart.addChartCursor(chartCursor);

                 // SCROLLBAR
                 //   var chartScrollbar = new AmCharts.ChartScrollbar();
                 //   chart.addChartScrollbar(chartScrollbar);

                 //    chart.creditsPosition = "bottom-right";
                 // WRITE
                 chart.write("chartdiv");

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
   <%-- <div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">工作量统计</a></li>
    <li><a href="#">工作量统计</a></li>
    <li><a href="#">工作量统计</a></li>
    </ul>
    </div>--%>


     <div class="tools">
        <ul class="toolbar">
        <li class="click"  onclick="findTisaneBtn();"><span><img src="../../img/t01.png" /></span>查询</li>
 <%--<li class="click"  onserverclick="Button1_Click"><span><img src="../../img/t04.png" /></span>导出数据</li>--%>
        <input ID="Button1" type="button"  runat="server" onserverclick="Button1_Click"   value='导出数据' class="btn3"/>
           
      
        </ul>  
    </div>
    
    <div class="rightinfo">



     <div class="num1"  style ="border:solid 1px white;  ">
    
   
       
     <ul class="forminfo" >
     <li>
     <label>煎药机号</label>
      <select id="tisanenum" runat="server" class="dfinput2" name="" onchange="" style="text-align:center">
    <option value="0" selected>&nbsp;&nbsp;全部&nbsp;&nbsp;</option>    
    </select>
     <label>&nbsp;&nbsp;&nbsp;&nbsp;开始时间</label>
     <input id="StartTime" runat="server" name="" type="text" class="dfinput2" onfocus="SetDate(this)" readonly="readonly"/>
        
       <label>&nbsp;&nbsp;&nbsp;&nbsp;结束时间&nbsp;</label>
         <input id="EndTime" runat="server" name="" type="text" class="dfinput2" onfocus="SetDate(this)" readonly="readonly"/></li>
    <li><uc1:dotNetFlexGrid ID="FlexGrid2" runat="server" /> </li>

   
   <li><div id="chartdiv" style="width: 100%; height: 400px;"></div></li>
    </ul>
     <input type="hidden" runat="server" id="chartData"/>
    

    </div>
    </div>
    
       
    </form>
</body>
</html>
