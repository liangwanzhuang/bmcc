<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckList.aspx.cs" Inherits="view_reconciliation_CheckList" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>对账列表</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
 
    <script type="text/javascript" src="../../js/time.js"></script>
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript">
        //查询
        function searchCompInfo() {
            var Clearing = $("#Clearing").val();
            var ClearingS = $("#ff");
            var STime = $("#STime").val();
            var ETime = $("#ETime").val();

            var p = [{ name: "Clearing", value: Clearing }, { name: "ClearingS", value: "" + ClearingS.val() + "" }, { name: "STime", value: STime }, { name: "ETime", value: ETime}];
            FlexGridCheckList.applyQueryReload(p);

        }
        function doReset() {

            $("#ff").val("");
//            for (i = 0; i < document.all.tags("input").length; i++) {
//                if (document.all.tags("input")[i].type == "text") {
//                    document.all.tags("input")[i].value = "";
//                }

            //            }
            $("#Clearing").val("");
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
        <li class="click" onclick="searchCompInfo();"><span><img src="../../img/t01.png" /></span>查询</li>
        <li class="click" onclick="doReset();"><span><img src="../../img/r01.png" /></span>重置</li>
        <li class="click" onclick="addDiv();"><span><img src="../../img/t02.png" /></span>设置对账状态</li>
        </ul>         
     
    </div>
    <ul class="forminfo">
     <li>
      <label>结算方</label>
       <input class="dfinput2" id="Clearing" runat="Server" name=""  />
        
         <label>&nbsp;&nbsp;&nbsp;&nbsp;结算状态</label>
        <select id="ff" runat="server" class="dfinput2" name="hostpital" onchange="hospitalSelectChange(this);" style="text-align:center">
          <option value="" selected>&nbsp;&nbsp;全部&nbsp;&nbsp;</option>
          <option value="1">&nbsp;&nbsp;已结算&nbsp;&nbsp;</option>
          <option value="0">&nbsp;&nbsp;未结算&nbsp;&nbsp;</option>
        </select>
     
     </li>
     
    <li>
       

        <label>开始时间</label>
        <input class="dfinput2" id="STime" runat="Server" name=""  onfocus="SetDate(this)" readonly="readonly"/>
        <label>&nbsp;&nbsp;&nbsp;&nbsp;结束时间</label>
        <input class="dfinput2" id="ETime" runat="Server" name=""   onfocus="SetDate(this)" readonly="readonly"/>
    </li>
   

   </ul>
    <div style="width:1000px; ">
     <uc1:dotNetFlexGrid ID="FlexGridCheckList"  runat="server"  
   
      />   
     <br /></div>
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
       
        function addDiv() {
            var rows = FlexGridCheckList.getSelectedRowsIds();
            if (rows.length != 1) {
                alert("请选择需要编辑的一行");
                return;
            }
                
            
            var d = new Date(), str = '';

            t = d.getHours();
            str += (t > 9 ? "" : "0") + t;
            t = d.getMinutes();
            str += (t > 9 ? "" : "0") + t;
            t = d.getSeconds();
            str += (t > 9 ? "" : "0") + t;

            //alert(rows);
            //alert(str);
            var url = "CheckListSet.aspx?id=" + rows + "&randomnumber=" + str;
            $("#flowtitle").text("设置对账信息");
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
