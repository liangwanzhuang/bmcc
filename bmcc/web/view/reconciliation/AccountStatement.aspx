<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AccountStatement.aspx.cs" Inherits="view_reconciliation_AccountStatement" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>对账单</title>
     <link href="../../css/style.css" rel="stylesheet" type="text/css" />
 
 
    <script type="text/javascript" src="../../js/time.js"></script>
    <link href="../../css/hDate.css" rel="stylesheet" />
<script type="text/javascript" src="../../js/jquery.date.js"></script>
<script type="text/javascript" src="../../js/hDate.js"></script>
    <script type="text/javascript" src="../../js/jquery.js"></script>
     <script language="javascript" type="text/javascript" src="../../js/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        //查询
        function searchCompInfo() {
            var Pspnum = $("#Pspnum").val();
            var hospitalSelect = $("#hospitalSelect");
            var STime = $("#STime").val();
            var ETime = $("#ETime").val();

            var p = [{ name: "Pspnum", value: Pspnum }, { name: "hospitalId", value: "" + hospitalSelect.val() + "" }, { name: "STime", value: STime }, { name: "ETime", value: ETime}];
            FlexGridRecipe.applyQueryReload(p);

        }
     function doReset() {
        
            $("select").val("0");
//            for (i = 0; i < document.all.tags("input").length; i++) {
//                if (document.all.tags("input")[i].type == "text") {
//                    document.all.tags("input")[i].value = "";
//                }
//               
            //            }
            $("#Pspnum").val("");
            $("#STime").val("");
            $("#ETime").val("");
            alert("置空成功！");
        }
</script>
</head>
<body>
   <form id="form1" runat="server">
     
     <div class="rightinfo">
          
    <div class="tools">
    
    	<ul class="toolbar">
        <li class="click" onclick="addDiv();"><span><img src="../../img/cx01.png" /></span>当前查询生成对账单</li>
        <li class="click" onclick="openDiv();"><span><img src="../../img/xz01.png" /></span>选中运单生成对账单</li>
        <li class="click" onclick="searchCompInfo();"><span><img src="../../img/t01.png" /></span>查询</li>
        <li class="click" onclick="doReset();"><span><img src="../../img/r01.png" /></span>重置</li>
        
       <%--  <li class="click"><span><img src="../../img/t04.png" /></span>导出数据</li>--%>
        </ul>         
     
    </div>
    <ul class="forminfo">
     <li>
      <label>处方号</label>
       <input class="dfinput2" id="Pspnum" runat="Server" name=""  />
      
   <label>&nbsp;&nbsp;&nbsp;&nbsp;医院名称</label>
        <select id="hospitalSelect" runat="server" class="dfinput2" name="hostpital" onchange="hospitalSelectChange(this);" style="text-align:center">
          <option value="0" selected>全部&nbsp;&nbsp;</option>
          
        </select>
     
     </li>
     
    <li>
       

        <label>开始时间</label>
        <input class="dfinput2" id="STime" runat="Server" name=""  onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" readonly="readonly"/>
        <label>&nbsp;&nbsp;&nbsp;&nbsp;结束时间</label>
        <input class="dfinput2" id="ETime" runat="Server" name=""   onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" readonly="readonly"/>
    </li>
   

   </ul>

      <div style="width:1000px; ">
     <uc1:dotNetFlexGrid ID="FlexGridRecipe" runat="server"  
   
      />   
     <br /></div>
     </div>
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
   
    <%--加载顺序要放到表格控件的后边,编辑--%>
    <link href="../../Css/ShowWin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery.divbox.js"></script>   
    <script type="text/javascript" src="../../Scripts/jquery.easydrag.handler.beta2.js"></script> 
    <script type="text/javascript" src="../../js/DatePicker.js"></script> 
    <script language="javascript" type="text/javascript">
    //选中生成账单
        function openDiv() {
            var rows = FlexGridRecipe.getSelectedRowsIds();
            if (rows.length < 1) {
                alert("请选择需要生成的一行！");
                return;
            } else {
                var strRowIDs = rows[0];
                 for (var i = 1; i < rows.length; i++) {
                     strRowIDs += "," + rows[i];

                 }

                // alert(strRowIDs);
            }

              var url = "Selected.aspx?id=" + strRowIDs;
            $("#flowtitle").text("生成对账单信息");
            $("#p_b_body").load(url);
            $("#pop_div").OpenDiv();
        }
        function closeDiv() {
            $("#pop_div").CloseDiv();
            var p = [];
            FlexGridRecipe.applyQueryReload(p);
        }
        $(function () {
            $(".pop_box").easydrag(); //拖动
            $(".pop_box").setHandler(".pop_box .p_head");
        });
        //查询生成账单
        function addDiv() {
            var rows = FlexGridRecipe.getSelectedRowsIds();

            var Pspnum = $("#Pspnum").val();
           // var pp = Pspnum.val();

            var hospitalSelect = $("#hospitalSelect");
           var hh = hospitalSelect.val();

            var STime = $("#STime").val();
           // var ss = STime.val();

            var ETime = $("#ETime").val();
           // var ee = ETime.val();
           // alert(Pspnum);
           // alert(hospitalSelect);
            //alert(STime);
            //alert(ETime);
            if (Pspnum == "" && hh == "0" && STime == "" && ETime == "") {
                alert("请输入查询条件！");

                return;
            } else {
            
            
            
             }
            var url = "Query.aspx?Pspnum=" + Pspnum + "&hospitalSelect=" + hh + "&STime=" + STime + "&ETime=" + ETime;
            $("#flowtitle").text("生成对账单信息");
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
