<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SwapStatistics.aspx.cs" Inherits="view_recipe_SwapStatistics" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/DatePicker.js"></script>
 <script type="text/javascript" src="../../js/time.js"></script>
 <script language="javascript" type="text/javascript" src="../../js/My97DatePicker/WdatePicker.js"></script>
    <link rel="stylesheet" href="../../chart/style.css" type="text/css">
	<script src="../../chart/amcharts.js" type="text/javascript"></script>
	<script src="../../chart/serial.js" type="text/javascript"></script>
 
 	
   
    <script type="text/javascript">

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
                        date: item.wordDate,
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
     
    <script type="text/javascript">
        $(document).ready(function () {
        //    $(".click").click(function () {
        //        $(".tip").fadeIn(200);
        //    });

            $(".tiptop a").click(function () {
                $(".tip").fadeOut(200);
            });

            $(".sure").click(function () {
                $(".tip").fadeOut(100);
            });

            $(".cancel").click(function () {
                $(".tip").fadeOut(100);
            });

        });
        function serchFun() {

            var status = $('#status');
            var begindate = $('#begindate');
            var enddate = $('#enddate');
            var eName = $('#eName');
            var p = [
                    { name: "status", value: "" + status.val() + "" },
                    { name: "begindate", value: "" + begindate.val() + "" },
                    { name: "enddate", value: "" + enddate.val() + "" },
                    { name: "eName", value: "" + eName.val() + "" }
                ];
            dotNetFlexGrid2.applyQueryReload(p);
            var strdata = "{'status':'" + status.val() + "','begindate':'" + begindate.val() + "','enddate':'" + enddate.val() + "'"
                + ",'eName':'" + eName.val() + "'}";
            //"{'status':'" + status.val() + "','begindate':'" + begindate.val() + "','enddate':'" + enddate.val() + "','eName':'" + eName.val() + "'}"
            $.ajax({ type: "POST",
                url: "SwapStatistics.aspx/findRecipeInfo",
                data: strdata,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var jsonobj = jQuery.parseJSON(data.d)
            
                    var chartData = [];
                
                    $.each(jsonobj, function (i, item) {
                        chartData.push({
                            date: item.wordDate,
                            visits: item.workload
                        });
                    
                    });
                    chart.dataProvider = chartData;
                    chart.validateNow();
                    chart.validateData(); 
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
</script>
</head>
<body>
    <form id="form1" runat="server">
    <%-- <div class="place">
        <span>位置：</span>
        <ul class="placeul">
        <li><a href="#">处方管理</a></li>
        <li><a href="#">调剂管理</a></li>
        <li><a href="#">调剂统计</a></li>
        </ul>
    </div>--%> 
     <%-- 总部分--%> 
    <div class="rightinfo">
    <%-- 第一部分--%> 
    <div class="tools">
    
    	<ul class="toolbar">
        <li class="click" onclick="serchFun();"><span><img src="../../img/t01.png" /></span>查询</li>
       <!-- <li class="click" onclick="openDiv();"><span><img src="../../img/t02.png" /></span>编辑</li>

        <li class="click"><a href ="SwapStatisticsGet.aspx"><span><img src=" ../../img/t05.png "></span>添加</a></li>
        <li class="click"><span><img src="../../img/t03.png" /></span>删除</li>-->
      <%-- <li class="click"  onserverclick="Button1_Click"><span><img src="../../img/t04.png" /></span>导出数据</li>--%>
        <asp:Button ID="Button1"  runat="server" OnClick="Button1_Click"   Text='导出数据' CssClass="btn3"/>
        </ul>         
    </div>
    <%-- 第二部分--%> 
    <ul class="forminfo">
    <li><label>调剂状态</label>
        <select id="status" class="dfinput" runat="server" name="Formulation-state" onChange="" style="text-align:center;width: 347px;">
          <option value="2" selected>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;全部&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</option>
          <option value="1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;调剂完成&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</option>
          <option value="0">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;开始调剂&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</option>
          
        </select>
        &nbsp;&nbsp;开始时间&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="begindate" runat="server"  name="patient" type="text"  onClick="WdatePicker()"  readonly="readonly" class="dfinput" />
       <!-- <select class="dfinput" name="Start-Time" onChange="" style="text-align:center">
          <option value="" selected>&nbsp;&nbsp;年/月/日&nbsp;&nbsp;</option>
         <option value=""></option>
          <option value=""></option>
          <option value=""></option>
          <option value=""></option>
          <option value=""></option>
        </select>-->
    </li>
    <li><label>调剂人员</label>
    <input id="eName" runat="server"  name="patient" type="text" class="dfinput" />
        <!--<select class="dfinput" name="Formulation-person" onChange="" style="text-align:center">
          <option value="" selected>&nbsp;&nbsp;全部&nbsp;&nbsp;</option>
          <option value="">王一</option>
          <option value="">王二</option>
          <option value="">王三</option>
          <option value="">王四</option>
          <option value="">王五</option>
        </select>-->
        &nbsp;&nbsp;结束时间&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="enddate" runat="server"  name="patient" type="text"  onClick="WdatePicker()"  readonly="readonly" class="dfinput" />
        <!--<select class="dfinput" name="End-time" onChange="" style="text-align:center">
          <option value="" selected>&nbsp;&nbsp;年/月/日&nbsp;&nbsp;</option>
          <option value=""></option>
          <option value=""></option>
          <option value=""></option>
          <option value=""></option>
          <option value=""></option>
        </select>-->
    </li> </ul>

        <div style="width:1000px; ">
        <div style="width:45%; float:left">
            <uc1:dotNetFlexGrid ID="dotNetFlexGrid2" runat="server" />
        </div>
        <div style="width:10%; float:left">
           &nbsp;&nbsp;&nbsp;&nbsp;
        </div>
        <div style="width:45%; float:left">
            <!-- <img src="../../img/t01.png" /><p>图表显示内容</p>-->
             

        </div>
    </div>
    <input type="hidden" runat="server" id="chartData"/>
   <div id="chartdiv" style="width: 100%; height: 400px;"></div>
       
     <div class="tip">
    	<div class="tiptop"><span>提示信息</span><a></a></div>
        
      <div class="tipinfo">
        <span><img src="images/ticon.png" /></span>
        <div class="tipright">
        <p>是否确认对信息的修改 ？</p>
        <cite>如果是请点击确定按钮 ，否则请点取消。</cite>
        </div>
        </div>
        
        <div class="tipbtn">
        <input name="" type="button"  class="sure" value="确定" />&nbsp;
        <input name="" type="button"  class="cancel" value="取消" />
        </div>
    
    </div>
   <div>
        <div id='pop_div' class="pop_box">
            <div class="p_head">
                <div class="p_h_title">
                    <span>调剂统计信息修改</span>
                </div>
                <div class="p_h_x" onclick="closeDiv();" title="关闭">关闭</div>
            </div>
            <div class="p_box_body" id="p_b_body"></div>
        </div>
    </div>
    </div>
     <%--加载顺序要放到表格控件的后边,编辑--%>
    <link href="../../Css/ShowWin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery.divbox.js"></script>   
    <script type="text/javascript" src="../../Scripts/jquery.easydrag.handler.beta2.js"></script> 
    <script type="text/javascript" src="../../js/DatePicker.js"></script> 
    <script language="javascript" type="text/javascript">
        function openDiv() {
            var rows = dotNetFlexGrid2.getSelectedRowsIds();
            if (rows.length != 1) {
                alert("请选择需要编辑的一行");
                return;
            } else {

            }

            var url = "SwapStatisticsUPdate.aspx?id=" + rows;

            $("#p_b_body").load(url);
            $("#pop_div").OpenDiv();
        }
        function closeDiv() {
            $("#pop_div").CloseDiv();
        }
        $(function () {
            $(".pop_box").easydrag(); //拖动
            $(".pop_box").setHandler(".pop_box .p_head");
        });

        
    </script>
    </form>
</body>
</html>
