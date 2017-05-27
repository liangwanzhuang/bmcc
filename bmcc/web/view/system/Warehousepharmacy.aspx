<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Warehousepharmacy.aspx.cs" Inherits="view_system_Warehousepharmacy" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" language="javascript">
       
         //查询

         function findBtn() {
             var Type = $("#Type");

             var p = [{ name: "Type", value: Type.val() }];
             dotNetFlexGrid3.applyQueryReload(p);


             //window.location = "printRecipe.aspx?findRrescription=true&hospitalId=" + hospitalSelect.val() + "&recipeNum=" + recipeSelect.val();
         }

         //删除
         function deleteWarehousepharmacyInfo() {
             var rows = dotNetFlexGrid3.getSelectedRowsIds();
             var strRowIDs = "";
             if (rows.length > 0) {
                 strRowIDs = rows[0];


                 for (var i = 1; i < rows.length; i++) {
                     strRowIDs += "," + rows[i]; // alert(rows[i]);
                 }

                 //alert(strRowIDs);

                 $.ajax({ type: "POST",
                     url: "Warehousepharmacy.aspx/deleteWarehousepharmacyById",
                     data: "{'strRowIds':\"" + strRowIDs + "\"}",
                     contentType: "application/json; charset=utf-8",
                     success: function (data) {
                         if (data.d == false) {
                             alert('删除失败');
                         } else {
                             alert('删除成功');
                         }
                         var p = [];
                         dotNetFlexGrid3.applyQueryReload(p);
                     }
                 });
             } else {
                 alert('请选中要删除的一行');
             }
         }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <%--<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">系统设置</a></li>
    <li><a href="#">系统设置</a></li>
    <li><a href="#">库房药房管理</a></li>
    </ul>
    </div>--%> 
 <%-- 总部分--%> 
    <div class="rightinfo">
    <%-- 第一部分--%> 
    <div class="tools">
    
    	<ul class="toolbar">
         <li class="click" onclick="findBtn();"><span><img src="../../img/t01.png" /></span>查询</li>
        <li class="click" onclick="openDiv();"><span><img src="../../img/t02.png" /></span>编辑</li>

         <li class="click" onclick="addDiv();"><span><img src="../../img/t05.png  " /></span>添加</li>
       <li class="click" onclick="deleteWarehousepharmacyInfo()"><span><img src="../../img/t03.png" /></span>删除</li>
       
        </ul>         
    </div>
    <%-- 第二部分--%> 
    <ul class="forminfo">
    <li><label>类&nbsp;&nbsp;&nbsp;&nbsp;型</label>
        <select id="Type" runat="Server" class="dfinput">
            <option value="0" selected>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;全部</option>
            <option value="库房">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;库房</option>
            <option value="药房">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;药房</option>
        </select></li>
       
    
   <li> <div style="width:1000px; ">
        
          <uc1:dotNetFlexGrid ID="dotNetFlexGrid3" runat="server" />
       </div></li>
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

     <%--加载顺序要放到表格控件的后边,编辑--%>
    <link href="../../Css/ShowWin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery.divbox.js"></script>   
    <script type="text/javascript" src="../../Scripts/jquery.easydrag.handler.beta2.js"></script> 
    <script type="text/javascript" src="../../js/DatePicker.js"></script> 
    <script language="javascript" type="text/javascript">
        function openDiv() {
            var rows = dotNetFlexGrid3.getSelectedRowsIds();
            if (rows.length != 1) {
                alert("请选择需要编辑的一行！");
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

            var url = "WarehousepharmacyUpdate.aspx?id=" + rows + "&randomnumber=" + str;
            $("#flowtitle").text("编辑库房药房信息");
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
            var rows = dotNetFlexGrid3.getSelectedRowsIds();


            var url = "WarehousepharmacyGet.aspx?id=" + rows;
            $("#flowtitle").text("添加库房药房信息");
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
