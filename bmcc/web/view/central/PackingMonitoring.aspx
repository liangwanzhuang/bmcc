<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PackingMonitoring.aspx.cs" Inherits="view_central_PackingMonitoring" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>包装机监控</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        //查询

        function findBtn() {
            var unitnum = $("#unitnum");
            var roomnum = $("#roomnum");
            var p = [{ name: "unitnum", value: unitnum.val() }, { name: "roomnum", value: roomnum.val()}];
            FlexGridDecoctingMonitoring.applyQueryReload(p);


            //window.location = "printRecipe.aspx?findRrescription=true&hospitalId=" + hospitalSelect.val() + "&recipeNum=" + recipeSelect.val();
        }
        //setInterval('findBtn()', 3000); //指定1秒刷新一次
    
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
    
    <div class="rightinfo">
    <div class="tools">   
    	<ul class="toolbar">
       
         <li class="click" onclick="findBtn();"><span><img src="../../img/t01.png" /></span>确定</li>
         
           <%--<li class="click"  onserverclick="Button1_Click"><span><img src="../../img/t04.png" /></span>导出数据</li>--%>
        <input ID="Button1" type="button"  runat="server" onserverclick="Button1_Click"   value='导出数据' class="btn3"/>
        
      
          
        </ul>        
    </div>
     <ul class="for1">
     <li>
    <label class="yy">包装机组编号</label>
        <select class="dfinput2" id="unitnum" runat="server" name="hostpitalname" onChange="" style="text-align:center">

        </select>
        <label >&nbsp;&nbsp;&nbsp;&nbsp;煎药室</label>
        <select class="dfinput2" id="roomnum" runat="server" name="" onChange="" style="text-align:center">

        </select>
        </li>
  
   

   </ul>
  
    
    </div>
     <div style="width:600px; ">
    <uc1:dotNetFlexGrid ID="FlexGridDecoctingMonitoring" runat="server" />
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
        function openDiv() {
            var rows = FlexGridClearingparty.getSelectedRowsIds();
            if (rows.length != 1) {
                alert("请选择需要修改的一行");
                return;
            } else {

            }

            var url = "MeRoomUpdate.aspx?id=" + rows;
            $("#flowtitle").text("修改煎药室信息");
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
