<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ComprehensiveInquiry.aspx.cs" Inherits="view_query_ComprehensiveInquiry" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/time.js"></script>
     <script language="javascript" type="text/javascript" src="../../js/My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript" src="../../js/jquery.js"></script>
     <link rel="stylesheet" href="../../chart/style.css" type="text/css"/>    
    <script src="../../chart/amcharts.js" type="text/javascript"></script>
	<script src="../../chart/serial.js" type="text/javascript"></script>


    
    <script type="text/javascript">
        //查询
        function searchCompInfo() {
            var RecipeStatus = $("#RecipeStatus").val();
            var Pspnum = $("#Pspnum").val();
            var hospitalName = $("#hospitalname").val();
            var patient = $("#patient").val();
            var tisaneid = $("#tisaneid").val();
            var STime = $("#STime").val();
            var ETime = $("#ETime").val();
//            var JTime = $("#JTime").val();
            var JTime = '';


            var p = [{ name: "hospitalID", value: hospitalName }, { name: "RecipeStatus", value: RecipeStatus }, { name: "Pspnum", value: Pspnum }, { name: "patient", value: patient }, { name: "tisaneid", value: tisaneid }, { name: "STime", value: STime }, { name: "ETime", value: ETime }, { name: "JTime", value: JTime}];
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
                url: "ComprehensiveInquiry.aspx/deleteCompById",
                data: "{'strRowIds':\"" + strRowIDs + "\"}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "0") {
                        alert('作废失败，此处方已经作废！');
                    } else {
                        alert('作废成功');
                    }
                   
                    var p = [];
                    FlexGridRecipe.applyQueryReload(p);
                }
            });
        }
        //取消作废

        function CloseRecipeInfo() {
            var rows = FlexGridRecipe.getSelectedRowsIds();
            var strRowIDs = "";
            if (rows.length > 0) {
                strRowIDs = rows[0];
            } else {
                alert("请选择需要取消作废的一行");
                return;
            }

            for (var i = 1; i < rows.length; i++) {
                strRowIDs += "," + rows[i]; // alert(rows[i]);
            }

            $.ajax({ type: "POST",
                url: "ComprehensiveInquiry.aspx/CloseRecipeById",
                data: "{'strRowIds':\"" + strRowIDs + "\"}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "0") {
                        alert('此处方未作废，取消失败');
                    } else {
                        alert('取消成功');
                    }
                   
                    var p = [];
                    FlexGridRecipe.applyQueryReload(p);
                }
            });
        }
        //重置
        function doReset() {

            $("select").val("0");
            $("#patient").val("");
            $("#Pspnum").val("");
            $("#tisaneid").val("");
            $("#STime").val("");
            $("#ETime").val("");
          /*  for (i = 0; i < document.all.tags("input").length; i++) {
                if (document.all.tags("input")[i].type == "text") {
                    document.all.tags("input")[i].value = "";
                }

            }
            alert("置空成功！");*/
        }




        DotNetFlexiGrid_onunChecked = function (e) {

            FlexGridRecipe_selectId = e;
            var array = FlexGridRecipe.getCellDatas(0);

            tid = array[0];

            gettemperturechart(tid);

            //   document.getElementById('select_checked').click();
        };


        var FlexGridRecipe_selectId = "0";
        DotNetFlexiGrid_onChecked = function (e) {
          
            FlexGridRecipe_selectId = e;
            var array = FlexGridRecipe.getCellDatas(e);

            tid = array[0];
           
            gettemperturechart(tid);

        };




        var tid = "";
        function gettemperturechart(tid) {

            $.ajax({ type: "POST",
                url: "ComprehensiveInquiry.aspx/gettempertureById",
                data: "{'tid':\"" + tid + "\"}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                
                    // $("#chartData").val(data.d);
                    // setChart();

                    var jsonobj = jQuery.parseJSON(data.d)

                    var chartData = [];

                    $.each(jsonobj, function (i, item) {
                        chartData.push({
                            date: item.time,
                            visits: item.temperature
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

        //温度曲线
        var chart;
        function setChart() {
            //var chartData = $("#chartData").val();

         //   alert(chartData);
          //  var jsonobj = jQuery.parseJSON(chartData)

           var chartData = [];
           var chartCursor;


           AmCharts.ready(function () {
               //   alert(jsonobj);
               // generate some data first
               //generateChartData();
               //    $.each(jsonobj, function (i, item) {
               //       chartData.push({
               //           date: item.wordDate,
               //           visits: item.workload
               //      });
               //
               //    });
               //     /*
             /*  chartData.push({
                   date: '2015-05-04 00:00:00',
                   visits: '3'
               });
               chartData.push({
                   date: '2015-05-05 00:00:00',
                   visits: '12'
               });
               chartData.push({
                   date: '2015-05-06 00:00:00',
                   visits: '23'
               });
               chartData.push({
                   date: '2015-05-07 00:00:00',
                   visits: '27'
               });
               chartData.push({
                   date: '2015-05-08 00:00:00',
                   visits: '35'
               });
               chartData.push({
                   date: '2015-05-09 00:00:00',
                   visits: '38'
               });
               */
               // SERIAL CHART
               chart = new AmCharts.AmSerialChart();
             //  chart.categoryField = "datetime";
             //  chart.dataDateFormat = "yyyy-MM-dd HH:mm:ss";
               //    chart.pathToImages = "../amcharts/images/";
                //chart.dataProvider = chartData;
                chart.categoryField = "date";
               // chart.balloon.bulletSize = 5;

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
      <%--<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">查询统计</a></li>
    <li><a href="#">综合查询</a></li>
    <li><a href="#">综合查询</a></li>
    </ul>
    </div>--%>
    <div class="rightinfo">
          
    <div class="tools">
    
    	<ul class="toolbar">
        <li class="click" onclick="searchCompInfo();"><span><img src="../../img/t01.png" /></span>查询</li>
         <li class="click" onclick="doReset();"><span><img src="../../img/r01.png" /></span>重置</li>
        <li class="click" onclick="deleteRecipeInfo();"><span><img src="../../img/t03.png" /></span>作废</li>
        <li class="click" onclick="CloseRecipeInfo();"><span><img src="../../img/q01.png" /></span>取消作废</li>
       <%-- <li class="click"  onserverclick="Button1_Click"><span><img src="../../img/t04.png" /></span>导出数据</li>--%>
        <input type ="button" ID="Button1"  runat="server" onserverclick="Button1_Click"   value='导出数据' class="btn3"/>
        </ul>         
     
    </div>
    <ul class="forminfo">
     <li>
      <label>处方状态</label>
      <select class="dfinput2" id="RecipeStatus" runat="server" name="hostpitalname" onChange="" style="text-align:center">
       <option value="0" selected>全部&nbsp;&nbsp;</option>
          
         <%-- <option value="接方">接方</option>--%>
          <option value="未匹配">未匹配</option>
          <option value="未审核">未审核</option>
          <option value="审核不通过">审核未通过</option>
          <option value="作废">作废</option>
          <option value="已审核">已审核</option>
          <option value="打印">打印</option>
          <option value="开始调剂">开始调剂</option>
          <option value="调剂完成">调剂完成</option>
          <option value="复核">复核</option>
          <option value="开始泡药">开始泡药</option>
          <option value="泡药完成">泡药完成</option>
          <option value="开始煎药">开始煎药</option>
          <option value="煎药完成">煎药完成</option>
          <option value="开始包装">开始包装</option>
          <option value="包装完成">包装完成</option>
          <option value="发货">发货</option>

         
        </select>
      <label>&nbsp;&nbsp;&nbsp;&nbsp;处方号</label><input id="Pspnum" name="" runat="server" type="text" class="dfinput2" /><i></i>
      <label>&nbsp;&nbsp;&nbsp;&nbsp;煎药单号</label><input id="tisaneid" runat="server"  name="" type="text" class="dfinput2" /><i></i>
      <label>&nbsp;&nbsp;&nbsp;&nbsp;医院名称</label>
        <select class="dfinput2" id="hospitalname" runat="server" name="hostpitalname" onChange="" style="text-align:center">

        </select></li>
    <li>
       <label>患者姓名</label>
        <input class="dfinput2" id="patient" runat="Server" name="patient"  />

        <label>&nbsp;&nbsp;&nbsp;&nbsp;开始时间</label>
        <input class="dfinput2" id="STime" runat="Server" name=""  onClick="WdatePicker()"  readonly="readonly"/>
        <label>&nbsp;&nbsp;&nbsp;&nbsp;结束时间</label>
        <input class="dfinput2" id="ETime" runat="Server" name=""   onClick="WdatePicker()"  readonly="readonly"/>

        <!-- <label>&nbsp;&nbsp;&nbsp;&nbsp;接方时间</label>
        <input class="dfinput2" id="JTime" runat="Server" name="patient"  onClick="WdatePicker()" readonly="readonly"/>-->

    </li>
   

   </ul>
      <div style="width:1000px; ">
     <uc1:dotNetFlexGrid ID="FlexGridRecipe" runat="server" 
       EventOnCheckedFunc="DotNetFlexiGrid_onChecked" 
        EventOnUnCheckedFunc="DotNetFlexiGrid_onunChecked" 
     
        
      />   
     <br /></div>

      <input type="hidden" runat="server" id="chartData"/>
   <div id="chartdiv" style="width: 100%; height: 400px;"></div>
     </div>
      </form>
</body>
</html>
