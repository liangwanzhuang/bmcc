<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DistributionStat.aspx.cs" Inherits="view_query_DistributionStat" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
        <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/time.js"></script>
    <script type="text/javascript" src="../../js/jquery.js"></script>

    <link rel="stylesheet" href="../../chart/style.css" type="text/css" />
    <script src="../../chart/amcharts.js" type="text/javascript"></script>
	<script src="../../chart/serial.js" type="text/javascript"></script>

    <script type="text/javascript">
        var chart;
        //查询
        function searchRecipeInfo() {

            var hospitalName = $("#hospitalname").val();
            var dtbcompany = $("#DCompany").val();
            var STime = $("#STime").val();
            var ETime = $("#ETime").val();

            var p = [{ name: "hospitalID", value: hospitalName }, { name: "dtbcompany", value: dtbcompany }, { name: "STime", value: STime }, { name: "ETime", value: ETime}];
            FlexGridRecipe.applyQueryReload(p);
            var strdata = "{'hospitalID':'" + hospitalName + "','STime':'" + STime + "','ETime':'" + ETime + "'"
                + ",'dtbcompany':'" + dtbcompany + "'}";
            
            $.ajax({ type: "POST",
                url: "DistributionStat.aspx/finDistributInfoCount",
                data: strdata,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobj = jQuery.parseJSON(data.d)

                    var chartData = [];

                    $.each(jsonobj, function (i, item) {
                        chartData.push({
                            date: item.data == '' ? '无' : item.data,
                            visits: item.count
                        });
                    });
                    chart.dataProvider = chartData;
                    chart.validateNow();
                    chart.validateData();
                }
            });

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
                url: "DistributionStat.aspx/deleteDistributById",
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
        
        $(function () {
            var chartDatas = $("#chartDatas").val();
            //alert(chartData);
            var jsonobj = jQuery.parseJSON(chartDatas)
            
            var chartData = [];
            var chartCursor;

            AmCharts.ready(function () {

                // generate some data first
                //generateChartData();
                  $.each(jsonobj, function (i, item) {
                    chartData.push({
                        date: item.data == '' ? '无' : item.data,
                        visits: item.count
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

        })
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
    <li><a href="#">查询统计</a></li>
    <li><a href="#">配送统计</a></li>
    <li><a href="#">配送统计</a></li>
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
      <label>配送公司</label>
      <select class="dfinput2" id="DCompany" runat="server" name="hostpitalname" onChange="" style="text-align:center">
      
        </select>
     
      <label>&nbsp;&nbsp;&nbsp;&nbsp;医院名称</label>
         <select class="dfinput2" id="hospitalname" runat="server" name="hostpitalname" onChange="" style="text-align:center">

        </select></li>
    <li>
       

        <label>开始时间</label>
        <input class="dfinput2" id="STime" runat="Server" name=""  onfocus="SetDate(this)" readonly="readonly"/>
        <label>&nbsp;&nbsp;&nbsp;&nbsp;结束时间</label>
        <input class="dfinput2" id="ETime" runat="Server" name=""   onfocus="SetDate(this)" readonly="readonly"/>
    </li>
   

   </ul>

      <div style="width:600px; ">
     <uc1:dotNetFlexGrid ID="FlexGridRecipe" runat="server"  
   
      />   
     <br /></div>
     <div id="chartdiv" style="width: 100%; height: 400px;"></div>
     </div>
      </form>
      <input type="hidden" runat="server" id="chartDatas"/>
</body>
</html>
