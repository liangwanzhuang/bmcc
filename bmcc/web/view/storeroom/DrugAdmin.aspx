<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DrugAdmin.aspx.cs" Inherits="view_storeroom_DrugAdmin" %>

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
            var medicaltype = $("#medicaltype");
            var medicalname = $("#medicalname");




            var p = [{ name: "medicaltype", value: medicaltype.val() }, { name: "medicalname", value: medicalname.val()}];
            dotNetFlexGrid1.applyQueryReload(p);



        }



        function deleteDrugAdminInfo() {

            var rows = dotNetFlexGrid1.getSelectedRowsIds();
            var strRowIDs = "";
            if (rows.length > 0) {
                strRowIDs = rows[0];


                for (var i = 1; i < rows.length; i++) {
                    strRowIDs += "," + rows[i]; // alert(rows[i]);
                }


                $.ajax({ type: "POST",
                    url: "DrugAdmin.aspx/deleteDrugAdminById",
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
        <li class="click" onclick="addDiv();"><span><img src=" ../../img/t05.png " /></span>添加</li>
        <li class="click" onclick="openDiv();"><span><img src="../../img/t02.png" /></span>修改</li>
        <li class="click" onclick="deleteDrugAdminInfo();"><span><img src="../../img/t03.png" /></span>删除</li>
        </ul>     
        
 <%--       <ul class="toolbar1">
        <li><span><img src="../../img/t05.png" /></span>设置</li>
        </ul>--%>
       
    </div>
    
    <ul class="forminfo">
  <li><label>药品种类</label><select id="medicaltype" runat="server" name="" type="text" class="dfinput2" style="text-align:center" onchange="hospitalSelectChange(this);" >
   <option value="0" selected>&nbsp;&nbsp;全部&nbsp;&nbsp;</option>
   <option value="西药" >&nbsp;&nbsp;西药&nbsp;&nbsp;</option>
   <option value="中药" >&nbsp;&nbsp;中药&nbsp;&nbsp;</option>
   <option value="藏药" >&nbsp;&nbsp;藏药&nbsp;&nbsp;</option>
   <option value="其他" >&nbsp;&nbsp;其他&nbsp;&nbsp;</option>
   </select>

 <label>药品名称</label><input id="medicalname" runat="Server" name="" type="text" class="dfinput2"/>  
 
  </li>

  <li><uc1:dotNetFlexGrid ID="dotNetFlexGrid1" runat="server" /></li>

   </ul>
         
    <script type="text/javascript">
        $('.tablelist tbody tr:odd').addClass('odd');
	</script>
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
        //编辑
        function openDiv() {
            var rows = dotNetFlexGrid1.getSelectedRowsIds();
            if (rows.length != 1) {
                alert("请选择需要编辑的一行");
                return;
            } else {

            }
            var d = new Date(), str = '';

            t = d.getHours();
            str += (t > 9 ? "" : "0") + t;
            t = d.getMinutes();
            str += (t > 9 ? "" : "0") + t;
            t = d.getSeconds();
            str += (t > 9 ? "" : "0") + t;
            var url = "DrugAdminUpdate.aspx?id=" + rows + "&randomnumber=" + str;
            $("#flowtitle").text("修改药品信息");
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
       
        //添加
        function addDiv() {
            var rows = dotNetFlexGrid1.getSelectedRowsIds();


            var url = "DrugAdminGet.aspx?id=" + rows;
            $("#flowtitle").text("添加药品信息");
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