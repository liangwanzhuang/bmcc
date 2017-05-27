<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Deliveryinformation.aspx.cs" Inherits="view_recipe_Deliveryinformation" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" src="../../js/time.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/My97DatePicker/WdatePicker.js"></script>
       <link href="../../css/hDate.css" rel="stylesheet" />
<script type="text/javascript" src="../../js/jquery.date.js"></script>
<script type="text/javascript" src="../../js/hDate.js"></script>
    <script type="text/javascript">
        var hospital = 0;
        function hospitalSelectChange(select) {
            hospital = $(select).val();
        }
       
        /**/
        $(function () {
            getWarning();
            setInterval(function () {
                getWarning();
            }, 1000 * 60);

        })
        function getWarning() {
            $.ajax({ type: "POST",
                url: "Deliveryinformation.aspx/getWarning",
                data: "",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var warningstr = data.d;
                    showWarning(warningstr);
                }
            });

        }
        var marqueeContent
        var item_i = 0;
        var timer;
        function showWarning(warningstr) {
            window.clearInterval(timer);
            item_i = 0;
            marqueeContent = new Array();   //滚动主题
            //  var warningstr = $("#warning").val();
            if (warningstr.length > 0) {
                var lastStr = warningstr.substring(warningstr.length - 1, warningstr.length);
                if (lastStr == ",") {
                    warningstr = warningstr.substring(0, warningstr.length - 1);
                }
            }
            var strzero = "0000000000";

            var strRows1Id = warningstr.split(',');
            if (strRows1Id.length == 0 || strRows1Id == "") {
                marqueeContent[0] = "预警提示：暂无预警";
            } else {

                for (i = 0; i < strRows1Id.length; i++) {
                    marqueeContent[i] = "预警提示：煎药单号为" + strzero.substring(0, 10 - strRows1Id[i].length) + strRows1Id[i] + "" + "已过发货预警时间";

                }
            }
            $("#warning_span").html('<div class="warning_div" style="display:none;">' + marqueeContent[item_i] + '</div>');
            $(".warning_div").slideDown("slow");

            if (parseInt(item_i) >= marqueeContent.length - 1) {
                item_i = 0;
            } else {
                item_i++
            }
            timer = setInterval(function () {

                $("#warning_span").html('<div class="warning_div" style="display:none;">' + marqueeContent[item_i] + '</div>');
                $(".warning_div").slideDown("slow");

                if (parseInt(item_i) >= marqueeContent.length - 1) {
                    item_i = 0;
                } else {
                    item_i++
                }
            }, 15000);

        }
        
        //查询
        countstatistics();
        function countstatistics() {
            $.ajax({ type: "POST",
                url: "DrugGlobalInfo.aspx/countstatistics",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    document.getElementById("count").innerHTML = data.d;
                }
            });
        }

        setInterval("countstatistics()", 5000);


        function findBtn() {
            var Sendstate = $("#Sendstate");
            var SendTime = $("#SendTime");
            var Sendpersonnel = $("#Sendpersonnel");
            var hospitalSelect = $("#hospitalSelect");
            var GetDrugTime = $("#GetDrugTime");

            var p = [{ name: "Sendstate", value: Sendstate.val() }, { name: "SendTime", value: SendTime.val() }, { name: "Sendpersonnel", value: Sendpersonnel.val() }, { name: "hospitalId", value: hospitalSelect.val() }, { name: "GetDrugTime", value: GetDrugTime.val()}];
            dotNetFlexGrid7.applyQueryReload(p);
       }

        //删除
        function deleteDeliveryInfo() {
            var rows = dotNetFlexGrid7.getSelectedRowsIds();
            var strRowIDs = "";
            if (rows.length > 0) {
                strRowIDs = rows[0];

                for (var i = 1; i < rows.length; i++) {
                    strRowIDs += "," + rows[i]; // alert(rows[i]);
                }

                alert(strRowIDs);

                $.ajax({ type: "POST",
                    url: "Deliveryinformation.aspx/deleteDeliveryById",
                    data: "{'strRowIds':\"" + strRowIDs + "\"}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d == false) {
                            alert('删除失败');
                        } else {
                            alert('删除成功');
                        }
                        var p = [];
                        dotNetFlexGrid7.applyQueryReload(p);
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
    
}
</style>           
</head>
    <body>
    <form id="form1" runat="server">

 <%-- 总部分--%> 
    <div class="rightinfo">
    <%-- 第一部分--%> 
     <span style = "color : red"><label id="count" runat="server"/></span><br />
      <li><span style = "color : red"><asp:Label id="Label1" runat="server"/></span></li>
  <li> <input id ="warning" runat="server" type="hidden" name="FunName"/> </li>
         <li><span id="warning_span" style ="color : red;height:20px;"></span></li>
 <br />
    <div class="tools">   
    	 <ul class="toolbar">
         <li class="click" onclick="findBtn();"><span><img src="../../img/t01.png" /></span>查询</li>
         <li class="click" onclick="addDiv();"><span><img src=" ../../img/t08.png "></span>发货</li>
         <asp:Button ID="Button1"  runat="server" OnClick="Button1_Click"   Text='导出数据' CssClass="btn3"/>        
        </ul>         
    </div>
      </div>
     <%--第二部分--%> 
     <ul class="forminfo">
    <li><label>发货状态</label>
        <select class="dfinput2" id="Sendstate" runat="server" onChange="" name=""  style="text-align:center">
           <option value="0" selected>&nbsp;&nbsp;待发货&nbsp;&nbsp;</option>
           <option value="1" >&nbsp;&nbsp;已发货&nbsp;&nbsp;</option>
        </select>
             
          <label>&nbsp;&nbsp;&nbsp;&nbsp;发货时间&nbsp;</label>
        <input id="SendTime" runat="server" name="" type="text" class="dfinput2" onClick="WdatePicker()"  readonly="readonly"/>
   <br/><br/><br/>
      <label>发货人员</label>
        <input id="Sendpersonnel" runat="Server" name="" type="text" class="dfinput2" /><i></i>
        <label>&nbsp;&nbsp;&nbsp;&nbsp;医院名称</label>
         <select id="hospitalSelect" runat="server" class="dfinput2" name="hostpital" onchange="hospitalSelectChange(this);" style="text-align:center">
            <option value="0" selected>&nbsp;&nbsp;-----请选择-----&nbsp;&nbsp;</option>       
        </select>
        <label>&nbsp;&nbsp;&nbsp;&nbsp;取药时间</label>
        <input id="GetDrugTime" runat="server" name="" type="text" class="dfinput2" onClick="WdatePicker()"  readonly="readonly"/>
    </li> 
    
      <li> <div style="width:1000px; ">
        
         <uc1:dotNetFlexGrid ID="dotNetFlexGrid7" runat="server" />
         </div>
      </li>     
      
      
       
 </ul>
 
   
    
    <div>
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
    <script type="text/javascript" src="../../Scripts/jquery.divbox.js"></script>   
    <script type="text/javascript" src="../../Scripts/jquery.easydrag.handler.beta2.js"></script> 
    <script type="text/javascript" src="../../js/DatePicker.js"></script> 
    <script language="javascript" type="text/javascript">
    <%--编辑--%>
     
         function openDiv() {
            var rows = dotNetFlexGrid7.getSelectedRowsIds();
            if (rows.length != 1) {
                alert("请选择需要编辑的一行");
                return;
            } else {

            }
            //alert('fsadfsdfsdfsdf');
            //alert(rows);
            var url = "DeliveryUpdate.aspx?id=" + rows;
             $("#flowtitle").text("编辑发货信息");
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



     
        function addDiv() {
            var rows = dotNetFlexGrid7.getSelectedRowsIds();
            if (rows.length != 1) {
                alert("请选择需要发货的一行");
                return;
            } else {

            }
              var d = new Date(), str = '';
                
                t = d.getHours();
                str += (t > 9 ? "" : "0") + t ;
                t = d.getMinutes();
                str += (t > 9 ? "" : "0") + t ;
                t = d.getSeconds();
                str += (t > 9 ? "" : "0") + t;

                // alert(str); //产生一个基于当前时间的0到59的整数
            var url = "DeliveryinformationGet.aspx?id=" +  rows + "&randomnumber=" + str;
            $("#flowtitle").text("发货信息");
            $("#p_b_body").load(url);

            $("#pop_div").OpenDiv();
        }
        function closeDiv() {
            $("#pop_div").CloseDiv();
            //window.location.reload();
        }
        $(function () {
            $(".pop_box").easydrag(); //拖动
            $(".pop_box").setHandler(".pop_box .p_head");
        }); 
 
    </script>
    </form>
</body>
</html>
