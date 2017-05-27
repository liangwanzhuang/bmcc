<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MedicineWarehouseInven.aspx.cs" Inherits="view_storeroom_MedicineWarehouseInven" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>药房盘点信息</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="../../js/time.js"></script>
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript">
        //查询
        function searchCompInfo() {
           
            var Warehouse = $("#Warehouse").val();
            var STime = $("#STime").val();
            var ETime = $("#ETime").val();
            var drugname = $("#drugname").val();
            var p = [{ name: "Warehouse", value: Warehouse }, { name: "STime", value: STime }, { name: "ETime", value: ETime }, { name: "drugname", value: drugname}];
     
            FlexGridMWarehouseInven.applyQueryReload(p);

        }
       
        //作废
        function deleteMWarehouseInvenInfo() {
            var rows = FlexGridMWarehouseInven.getSelectedRowsIds();
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
                url: "MedicineWarehouseInven.aspx/deleteMWarehouseInvenById",
                data: "{'strRowIds':\"" + strRowIDs + "\"}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "0") {
                        alert('作废失败,');
                    } else {
                        alert('作废成功');
                    }

                    var p = [];
                    FlexGridMWarehouseInven.applyQueryReload(p);
                }
            });
        }
        //重置
         function doReset() {

             $("select").val("0");
             document.getElementById("STime").value = "";
             document.getElementById("ETime").value = "";
             document.getElementById("drugname").value = "";

          /*  for (i = 0; i < document.all.tags("input").length; i++) {
                if (document.all.tags("input")[i].type == "text") {
                    document.all.tags("input")[i].value = "";
                }
               
            }
            alert("置空成功！");*/
        }
</script>
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
       
        <li class="click" onclick="searchCompInfo();"><span><img src="../../img/t01.png" /></span>查询</li>
        <li class="click" onclick="addDiv();"><span><img src="../../img/t05.png" /></span>添加</li>
        <li class="click" onclick="openDiv();"><span><img src="../../img/t02.png" /></span>修改</li>
        <li class="click" onclick="doReset();"><span><img src="../../img/r01.png" /></span>重置</li>
      
        <input type="Button" ID="Button1"  runat="server" onserverclick="ExportMedicineWarehouseInven_Click"   value='导出数据' class="btn3"/>
        </ul>         
     
    </div>
    <ul class="forminfo">
    <li>
       

        <label>开始时间</label>
        <input class="dfinput2" id="STime" runat="Server" name=""  onfocus="SetDate(this)" readonly="readonly"/>
        <label>&nbsp;&nbsp;&nbsp;&nbsp;结束时间</label>
        <input class="dfinput2" id="ETime" runat="Server" name=""   onfocus="SetDate(this)" readonly="readonly"/>
    </li>
   
     <li>
      
     
      <label>仓库</label>
      <select class="dfinput2" id="Warehouse" runat="server" name="hostpitalname" onChange="" style="text-align:center">  
        </select>

           <label>&nbsp;&nbsp;&nbsp;&nbsp;药品名称</label>
           <input id="drugname" runat="server" name="" type="text" class="dfinput2" />


        </li>



   
     
   <li>  <uc1:dotNetFlexGrid ID="FlexGridMWarehouseInven" runat="server"  />
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
        //编辑
        function openDiv() {
            var rows = FlexGridMWarehouseInven.getSelectedRowsIds();
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

            var url = "MedicineWarehouseInvenUpdate.aspx?id=" + rows + "&randomnumber=" + str;
            $("#flowtitle").text("修改药房盘点信息");
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
            var rows = FlexGridMWarehouseInven.getSelectedRowsIds();
            var d = new Date(), str = '';

            t = d.getHours();
            str += (t > 9 ? "" : "0") + t;
            t = d.getMinutes();
            str += (t > 9 ? "" : "0") + t;
            t = d.getSeconds();
            str += (t > 9 ? "" : "0") + t;

            var url = "MedicineWarehouseInvenGet.aspx?id=" + rows + "&randomnumber=" + str;
            $("#flowtitle").text("添加药房盘点信息");
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

   
