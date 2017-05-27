<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogisticsInfor.aspx.cs" Inherits="view_logistics_LogisticsInfor" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../../css/style.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="../../js/time.js"></script>
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/My97DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        //查询
        function searchCompInfo() {
            var hospitalname = $("#hospitalname").val();
            var Pspnum = $("#Pspnum").val();
            var dtbtype = $("#dtbtype").val();
            var patient = $("#patient").val();
            var phone = $("#phone").val();
            var curstate = $("#curstate").val();
            var time = $("#time").val();
            var ftime = $("#ftime").val();

            var p = [{ name: "hospitalname", value: hospitalname }, { name: "dtbtype", value: dtbtype }, { name: "Pspnum", value: Pspnum }, { name: "patient", value: patient }, { name: "phone", value: phone }, { name: "curstate", value: curstate }, { name: "time", value: time }, { name: "ftime", value: ftime}];
            FlexGridRecipe.applyQueryReload(p);

        }
        function doReset() {
            
            $("select").val("0");
            //for (i = 0; i < document.all.tags("input").length; i++) {
             //   if (document.all.tags("input")[i].type == "text") {
             //       document.all.tags("input")[i].value = "";
              //  }

            //}
            document.getElementById("Pspnum").value = "";
            document.getElementById("patient").value = "";
            document.getElementById("phone").value = "";
            document.getElementById("time").value = "";
            document.getElementById("ftime").value = "";

            alert("重置成功！");
        }

        var FlexGridRecipe_selectId = "0";
        DotNetFlexiGrid_onChecked = function (e) {
          //    alert("onUnChecked" + e);
           // FlexGridRecipe_selectId = e;
           // var array = FlexGridRecipe.getCellDatas(e);
         //   closeDiv();
            openDiv();

        };
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
    <li><a href="#">物流管理</a></li>
    <li><a href="#">物流信息管理</a></li>
    <li><a href="#">物流信息</a></li>
    </ul>
    </div>--%>
   <div class="rightinfo">
          
    <div class="tools">
    
    	<ul class="toolbar">
        <li class="click" onclick="searchCompInfo();"><span><img src="../../img/t01.png" /></span>查询</li>
        <li class="click" onclick="doReset();"><span><img src="../../img/r01.png" /></span>重置</li>
         <input type="Button" ID="Button1"  runat="server" onserverclick="ExportMedicineStorage_Click"   value='导出数据' class="btn3"/>
        </ul>         
     
    </div>
    <ul class="forminfo">
     <li>
      <label>医院名称</label>
      <select class="dfinput2" id="hospitalname" runat="server" name="" onChange="" style="text-align:center">
       
         
         
        </select>
      <label>&nbsp;&nbsp;&nbsp;&nbsp;处方号</label><input id="Pspnum" runat="server" name="" type="text" class="dfinput2" /><i></i>
      
      <label>&nbsp;&nbsp;&nbsp;&nbsp;快递类型</label>
        <select class="dfinput2" id="dtbtype" runat="server" name="" onChange="" style="text-align:center">
        <option value="0">全部</option>
            <option value="1">顺丰</option>
            <option value="2">圆通</option>
            <option value="3">中通</option>
            <option value="4">EMS</option>
        </select></li>
    <li>
       <label>患者姓名</label>
        <input class="dfinput2" id="patient" runat="Server" name="patient"  />

        <label>&nbsp;&nbsp;&nbsp;&nbsp;患者电话</label>
        <input class="dfinput2" id="phone" runat="Server" name=""  />
        <label>&nbsp;&nbsp;&nbsp;&nbsp;当前状态</label>
        <select class="dfinput2" id="curstate" runat="server" name="" onChange="" style="text-align:center">
         <option value="0">全部</option>

            <option value="已签收">已签收</option>
           
            <option value="未签收">未签收</option>
        </select>
    </li>
    <li>
    <label>取药时间</label>
        <input id="time" runat="server" name="" type="text" class="dfinput2" onClick="WdatePicker()" readonly="readonly"/>
    <label>&nbsp;&nbsp;&nbsp;&nbsp;发货时间</label>
        <input id="ftime" runat="server" name="" type="text" class="dfinput2" onClick="WdatePicker()" readonly="readonly"/>
    
    
    
    </li>
   

   </ul>

      <div style="width:1000px; ">
     <uc1:dotNetFlexGrid ID="FlexGridRecipe" runat="server"  
   EventOnCheckedFunc="DotNetFlexiGrid_onChecked"
      />   
     <br /></div>
     </div>
     <div>
        <div id='pop_div' class="pop_box">
            <div class="p_head">
                <div class="p_h_title">
                    <span id="pop_title">物流信息</span>
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
        function openDiv() {
            var rows = FlexGridRecipe.getSelectedRowsIds();
            if (rows.length != 1) {
                alert("请选择需要编辑的一行");
                return;
            }
            var array = FlexGridRecipe.getCellDatas(rows);
            var dtbtype = array[4];
            var num = array[9];
            if (num.length == 0) {
                alert('物流单号不能为空');
                return;
            }
            var url = "kuaidi100.aspx?id=" + rows + "&dtbtype=" + dtbtype + "&num=" + num;
            $("#pop_title").text('物流信息');
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
