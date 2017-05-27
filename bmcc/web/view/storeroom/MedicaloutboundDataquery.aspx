<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MedicaloutboundDataquery.aspx.cs" Inherits="view_storeroom_MedicaloutboundDataquery" %>
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
    <script language="javascript" type="text/javascript" src="../../js/My97DatePicker/WdatePicker.js"></script>
    
   <script type="text/javascript"language="javascript">
       //入库单查询
       function findStorageBtn() {

           var STime = $("#STime"); //时间
           var ETime = $("#ETime");

           var p = [{ name: "STime", value: STime.val() }, { name: "ETime", value: ETime.val()}];
           FlexGridStorage.applyQueryReload(p);

       }
       //入库单列表查询
       function findStorageListBtn() {

           var LSTime = $("#STimeL"); //时间
           var LETime = $("#ETimeL");
           var Warehousing = $("#Warehousing1");
           var DrugName = $("#DrugName1");
           var p = [{ name: "LSTime", value: LSTime.val() }, { name: "LETime", value: LETime.val() }, { name: "Warehousing", value: Warehousing.val() }, { name: "DrugName", value: DrugName.val()}];
           FlexGridStorageList.applyQueryReload(p);

       }



       //入库单作废
       function deleteStorageInfo() {
           var rows = FlexGridStorage.getSelectedRowsIds();
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
               url: "StorageManage.aspx/deleteStorageById",
               data: "{'strRowIds':\"" + strRowIDs + "\"}",
               contentType: "application/json; charset=utf-8",
               success: function (data) {
                   if (data.d == "0") {
                       alert('作废失败,此处已经作废或已在调剂以下阶段');
                   } else {
                       alert('作废成功');
                   }
                   FlexGridStorage.applyQueryReload(psp);
                   var p = [];
                   FlexGridStorageList.applyQueryReload(p);
               }
           });
       }
       //入库单列表作废
       function deleteStorageListInfo() {
           var rows = FlexGridStorageList.getSelectedRowsIds();
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
               url: "MedicaloutboundDataquery.aspx/deletemedicaloutboundById",
               data: "{'strRowIds':\"" + strRowIDs + "\"}",
               contentType: "application/json; charset=utf-8",
               success: function (data) {
                   if (data.d == "0") {
                       alert('作废失败,此处已经作废或已在调剂以下阶段');
                   } else {
                       alert('作废成功');
                   }
                   FlexGridStorage.applyQueryReload(psp);
                   var p = [];
                   FlexGridStorageList.applyQueryReload(p);
               }
           });
       }
       //取消作废

       function CloseRecipeInfo() {
           var rows = FlexGridRecipe.getSelectedRowsIds();
           var strRowIDs = "";
           if (rows.length > 0) {
               strRowIDs = rows[0];
           } else {
               alert("请选择需要取消作废的一行");
               return;
           }

           for (var i = 1; i < rows.length; i++) {
               strRowIDs += "," + rows[i]; // alert(rows[i]);
           }

           $.ajax({ type: "POST",
               url: "RecipeQuery.aspx/CloseRecipeById",
               data: "{'strRowIds':\"" + strRowIDs + "\"}",
               contentType: "application/json; charset=utf-8",
               success: function (data) {
                   if (data.d == "0") {
                       alert('此处方未作废，取消失败');
                   } else {
                       alert('取消成功');
                   }
                   FlexGridRecipe.applyQueryReload(psp);
                   var p = [];
                   FlexGridDrug.applyQueryReload(p);
               }
           });
       }

       //删除入库药品信息
       function deleteStorageInfo() {


           var rows = FlexGridStorage.getSelectedRowsIds();
           var strRowIDs = "";
           if (rows.length > 0) {
               strRowIDs = rows[0];


               for (var i = 1; i < rows.length; i++) {
                   strRowIDs += "," + rows[i]; // alert(rows[i]);
               }

               //alert(rows[i]);
               $.ajax({ type: "POST",
                   url: "StorageManage.aspx/deletedrugtoroominfoById",
                   data: "{'strRowIds':\"" + strRowIDs + "\"}",
                   contentType: "application/json; charset=utf-8",
                   success: function (data) {
                       if (data.d == false) {
                           alert('删除失败');
                       } else {
                           alert('删除成功');
                       }
                       var p = [];
                       FlexGridStorage.applyQueryReload(p);
                   }
               });

           } else {
               alert('请选中要删除的行');
           }


       }


       //入库
       function drugintoroom() {
           var Warehouse1 = $("#Warehouse1").val();
           var intoman = $("#intoman").val();
           var OSingle1 = $("#OSingle1").val();
           var OSTime1 = $("#OSTime1").val();

           // alert(Warehouse1);
           // alert(intoman);
           // alert(OSingle1);
           // alert(OSTime1);
           if (intoman == "") {
               alert("请添加入库人！");
               return false;
           } else if (OSingle1 == "") {
               alert("请添加开单人！");
               return false;
           } else if (OSTime1 == "") {
               alert("请添加开单时间！");
               return false;
           }
           var rows = FlexGridStorage.getSelectedRowsIds();
           var strRowIDs = "";
           if (rows.length > 0) {
               strRowIDs = rows[0];


               for (var i = 1; i < rows.length; i++) {
                   strRowIDs += "," + rows[i];

               }
               //alert('ceshi');
               //alert('测试id'+strRowIDs);

               $.ajax({ type: "POST",
                   url: "MedicineOutboundData.aspx/enterStorage",
                   data: "{'strRowIds':'" + strRowIDs + "','Warehouse1': '" + Warehouse1 + "','intoman': '" + intoman + "','OSingle1': '" + OSingle1 + "','OSTime1': '" + OSTime1 + "'}",
                   contentType: "application/json; charset=utf-8",
                   success: function (data) {
                       if (data.d == 0) {
                           alert('入库失败');
                       } else {
                           alert('入库成功');
                       }
                       var p = [];
                       FlexGridStorage.applyQueryReload(p);
                       FlexGridStorageList.applyQueryReload(p);
                   }
               });
               return true;
           } else {
               alert('请选中要入库的行');
           }

       }



       DotNetFlexiGrid_onChecked = function (e) {
           //  alert("onUnChecked" + e);
           FlexGridStorageList_selectId = e;
           var array = FlexGridStorageList.getCellDatas(e);
           //    $('#Pspnum').val(array[4]);
           //传递给Grid2一个查询选项数组并让其刷新
           var operatenum = array[2];

           var pDrug = [{ name: "operatenum", value: "" + array[2] + ""}];
           // var pDrug = [{ name: "drugpspnum", value: "" + drugpspnum + "" }, { name: "hospitalId", value: "" + hospitalId + ""}];
           FlexGriddrug.applyQueryReload(pDrug);
           //alert(array[4]);
           //   document.getElementById('select_checked').click();
       };

       DotNetFlexiGrid_onunChecked = function (rowId) {
           //  var id = FlexGridStorageList.getSelectedRowsIds()[0];


           FlexGridStorageList_selectId = rowId;
           var array = FlexGridStorageList.getCellDatas(0);

           //$('#Pspnum').val(array[4]);
           //传递给Grid2一个查询选项数组并让其刷新
           var p = [{ name: "operatenum", value: "" + array[0] + ""}];
           //var p = [{ name: "drugpspnum", value: "" + array[5] + "" }, { name: "Hospitalid", value: "" + array[4] + ""}];
           FlexGriddrug.applyQueryReload(p);
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
     <%--<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">库房管理</a></li>
    <li><a href="#">入库管理</a></li>
    <li><a href="#">入库管理</a></li>
    </ul>
    </div>--%>
    <div>
     <%-- 总部分--%> 
   
 
         <div class="rightinfo">
   <div class="formtitle"><span>调拨单列表</span></div>
    <div class="tools">
    
    	<ul class="toolbar">
        <li class="click" onclick="findStorageListBtn();"><span><img src="../../img/t01.png" /></span>查询</li>
         
         <li class="click" onclick="openDiv();"><span><img src="../../img/t02.png" /></span>修改</li>
        
           <li class="click" onclick="deleteStorageListInfo();"><span><img src="../../img/t03.png" /></span>作废</li>
             <input type="Button" ID="Button1"  runat="server" onserverclick="ExportStorageManageModel_Click"   value='导出数据' class="btn3"/>
       
        </ul> 
                 
    </div>
    <ul class="forminfo">
    
        <li> <label>&nbsp;&nbsp;开始时间</label>
        <input id="STimeL" runat="server" name="" type="text" class="dfinput2" onfocus="SetDate(this)" readonly="readonly"/>
        <label>&nbsp;&nbsp;结束时间</label>
        <input id="ETimeL" runat="server" name="" type="text" class="dfinput2" onfocus="SetDate(this)" readonly="readonly"/></li> 
       <li> <label>&nbsp;&nbsp;出库人</label>
        <input id="Warehousing1" runat="server" name="" type="text" class="dfinput2" />
        <label>&nbsp;&nbsp;药品名称</label>
        <input id="DrugName1" runat="server" name="" type="text" class="dfinput2" /></li> 
   </ul>
          <br /> <br /> <br />
     <div style="width:1000px; ">
        <div style="width:45%; float:left">
           <uc1:dotNetFlexGrid ID="FlexGridStorageList" runat="server" 
          EventOnUnCheckedFunc="DotNetFlexiGrid_onunChecked"
          EventOnCheckedFunc="DotNetFlexiGrid_onChecked"
           />  
        </div>
         
        <div style="width:10%; float:left">
           &nbsp;&nbsp;&nbsp;&nbsp;
        </div>
        <div style="width:45%; float:left">
            <uc1:dotNetFlexGrid ID="FlexGriddrug" runat="server" 
           />  
        </div>
    
    </div>

        </div>
        
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
        //入库单编辑
        function openDiv() {
            var rows = FlexGridStorageList.getSelectedRowsIds();
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
            var url = "medicaloutboundDataqueryUpdate.aspx?id=" + rows + "&randomnumber=" + str;
            $("#flowtitle").text("修改入库单信息");
            $("#p_b_body").load(url);
            $("#pop_div").OpenDiv();
        }
        function closeDiv() {
            $("#pop_div").CloseDiv();
            window.location.reload();

        }
        $(function () {
            $(".pop_box").easydrag(); //拖动
            $(".pop_box").setHandler(".pop_box .p_head");
        });
        //药品修改
        function UpdateDiv() {
            var rows = FlexGridStorage.getSelectedRowsIds();
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
            var url = "StorageListUpdate.aspx?id=" + rows + "&randomnumber=" + str;
            $("#flowtitle").text("修改出库单列表药品信息");
            $("#p_b_body").load(url);
            $("#pop_div").OpenDiv();
        }
        function closeDiv() {
            $("#pop_div").CloseDiv();
            window.location.reload();

        }
        $(function () {
            $(".pop_box").easydrag(); //拖动
            $(".pop_box").setHandler(".pop_box .p_head");
        });
        /*//入库单添加
        function addDiv() {
        var rows = FlexGridStorageList.getSelectedRowsIds();


        var url = "StorageGet.aspx?id=" + rows;
        $("#flowtitle").text("添加入库单信息");
        $("#p_b_body").load(url);
        $("#pop_div").OpenDiv();
        }
        function closeDiv() {
        $("#pop_div").CloseDiv();
        }
        $(function () {
        $(".pop_box").easydrag(); //拖动
        $(".pop_box").setHandler(".pop_box .p_head");
        });*/
        //添加药品
        function addDrugDiv() {
            var rows = FlexGridStorage.getSelectedRowsIds();


            var url = "medicalOutbounddataadd.aspx";
            $("#flowtitle").text("添加入库单药品信息");
            $("#p_b_body").load(url);
            $("#pop_div").OpenDiv();
        }
        function closeDiv() {
            $("#pop_div").CloseDiv();
            window.location.reload();

        }
        $(function () {
            $(".pop_box").easydrag(); //拖动
            $(".pop_box").setHandler(".pop_box .p_head");
        });
    </script>
      </form>
</body>
</html>
