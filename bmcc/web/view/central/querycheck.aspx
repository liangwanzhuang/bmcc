<%@ Page Language="C#" AutoEventWireup="true" CodeFile="querycheck.aspx.cs" Inherits="view_central_querycheck" %>

<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
      <script type="text/javascript" src="../../js/time.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/My97DatePicker/WdatePicker.js"></script>
     <link rel="stylesheet" href="../../chart/style.css" type="text/css" />
    <script src="../../chart/amcharts.js" type="text/javascript"></script>
	<script src="../../chart/serial.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $(".click").click(function () {
                $(".tip").fadeIn(200);
            });

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

        function search() {
            var pspstatus = $("#pspstatus");
            var StartTime = $("#StartTime");
            var EndTime = $("#EndTime");
           // var employcode = $("#employcode");{ name: "employcode", value: employcode.val() },
            var qualityman = $("#qualityman");

          
       
            var p = [{ name: "pspstatus", value: pspstatus.val() }, { name: "StartTime", value: StartTime.val() }, { name: "EndTime", value: EndTime.val() },  { name: "qualityman", value: qualityman.val()}];
            dotNetFlexGrid1.applyQueryReload(p);



        }



        function deleteTisaneInfo() {

            var rows = dotNetFlexGrid1.getSelectedRowsIds();
            var strRowIDs = "";
            if (rows.length > 0) {
                strRowIDs = rows[0];


                for (var i = 1; i < rows.length; i++) {
                    strRowIDs += "," + rows[i]; // alert(rows[i]);
                }


                $.ajax({ type: "POST",
                    url: "QueryFunction.aspx/deleteTisaneById",
                    data: "{'strRowIds':\"" + strRowIDs + "\"}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d == false) {
                            alert('删除失败');
                        } else {
                            alert('删除成功');
                        }
                        var p = [];
                        dotNetFlexGrid1.applyQueryReload(p);
                    }
                });

            } else {
                alert('请选中要删除的行');
            }
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
     <%--<div class="place">
        <span>位置：</span>
        <ul class="placeul">
        <li><a href="#">中心监控</a></li>
        <li><a href="#">质量管理</a></li>
        <li><a href="#">抽检列表查询</a></li>
        </ul>
    </div>--%>
      <%-- 总部分--%> 
    <div class="rightinfo">

    <div class="tools">
    
       <ul class="toolbar">
       <li class="click" onclick="search();"><span><img src="../../img/t01.png" /></span>查询</li>
       <li class="click"   onclick="updatequalityucheckinfo();"><span><img src="../../img/t02.png" /></span>编辑</li>
      
      <%--<li class="click"  onserverclick="Button1_Click"><span><img src="../../img/t04.png" /></span>导出数据</li>--%>
        <asp:Button ID="Button1"  runat="server" OnClick="Button1_Click"   Text='导出数据' CssClass="btn3"/>
         
       
        </ul>     
        
 <%--       <ul class="toolbar1">
        <li><span><img src="../../img/t05.png" /></span>设置</li>
        </ul>--%>
       
    </div>
    
    <ul class="forminfo">
  <li>
  <label>开始时间</label><input id="StartTime" runat="server" name="" type="text" class="dfinput2" onfocus="SetDate(this)" readonly="readonly"/>
  <label>&nbsp;&nbsp;&nbsp;&nbsp;结束时间</label><input id="EndTime" runat="server" name="" type="text" class="dfinput2" onfocus="SetDate(this)" readonly="readonly"/>
  </li>
  <li>
  <label>是否合格</label><select id="pspstatus" runat="server" name="" type="text" class="dfinput2" style="text-align:center" onchange="hospitalSelectChange(this);" >
   <option value="0" selected>全部&nbsp;&nbsp;</option>
      
        
       </select>
 <%--  <label>员工编号</label><input id="employcode" runat="Server" name="" type="text" class="dfinput2"/>  --%>
  <label>&nbsp;&nbsp;&nbsp;&nbsp;质检人员</label><input id="qualityman" runat="Server" name="" type="text" class="dfinput2"/>
  </li>

  <li><uc1:dotNetFlexGrid ID="dotNetFlexGrid1" runat="server" /></li>
  
  
   </ul>
         
   



     <div id='pop_div' class="pop_box">
            <div class="p_head">
                <div class="p_h_title">
                    <span><asp:Label id="flowtitle" runat="server"/></span>
                </div>
                <div class="p_h_x" onclick="closeDiv();" title="关闭">关闭</div>
            </div>
            <div class="p_box_body" id="p_b_body"></div>
     </div>



    </div>
    
  


     <%--加载顺序要放到表格控件的后边--%>
    <link href="../../Css/ShowWin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery.divbox.js"> </script>
    <script type="text/javascript" src="../../Scripts/jquery.easydrag.handler.beta2.js"></script>
    <script type="text/javascript" src="../../js/DatePicker.js"></script> 
    <script language="javascript" type="text/javascript">
        function updatequalityucheckinfo() {
            var rows = dotNetFlexGrid1.getSelectedRowsIds();

            if (rows.length != 1) {
                alert("请选择需要修改的一行");
                return;
            } else {

            }
           
            var url = "checkupdate.aspx?id=" + rows;
            $("#flowtitle").text("修改抽检信息");
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


  <%--<script type="text/javascript">
      $('.tablelist tbody tr:odd').addClass('odd');
	</script>--%>
      </form>
</body>
</html>
