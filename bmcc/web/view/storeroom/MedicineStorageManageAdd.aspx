<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MedicineStorageManageAdd.aspx.cs" Inherits="view_storeroom_MedicineStorageManageAdd" %>

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


        function okbtn() {

            var pspstatus = $("#pspstatus");
            var StartTime = $("#StartTime");
            var EndTime = $("#EndTime");

        }


    function from(select) {
            var fromid = $(select).val();
           // $("#recipeSelect option").remove();
            //  alert(id);
            alert(fromid);
           /* function search() {
                alert(fromid);
                var p = [{ name: "fromid", value: fromid}];
                dotNetFlexGrid1.applyQueryReload(p);

                */

            }


            function hospitalSelectChange(select) {
                var fromid = $(select).val();
                $("#recipeSelect option").remove();
                alert(fromid);

                var p = [{ name: "fromid", value: fromid}];
                dotNetFlexGrid1.applyQueryReload(p);
                /*if (id != 0) {
                    $.ajax({ type: "POST",
                        url: "RecipeGet.aspx/getNumByHospitalId",
                        data: "{'hospitalId':" + id + "}",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            var datas = data.d.split(";");

                            $("#hospitalnum").val(datas[0]);
                            $("#delnum").val(datas[1]);

                        }
                    });
                }*/
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
       <li class="click"   onclick="okbtn();"><span><img src="../../img/t02.png" /></span>确定</li>
        </ul>     
        
 <%--       <ul class="toolbar1">
        <li><span><img src="../../img/t05.png" /></span>设置</li>
        </ul>--%>
       
    </div>
    
    <ul class="forminfo">
  <li><label>调出</label><select id="from" runat="server" name="" type="text" class="dfinput2" style="text-align:center" onchange="hospitalSelectChange(this);" >
   <option value="0" selected>&nbsp;&nbsp;全部&nbsp;&nbsp;</option> 
       </select>
       <label>调入</label><select id="into" runat="server" name="" type="text" class="dfinput2" style="text-align:center" onchange="into(this);" >
   <option value="0" selected>&nbsp;&nbsp;全部&nbsp;&nbsp;</option> 
       </select>

        <label>数量</label><input id="changenum" runat="Server" name="" type="text" class="dfinput2"/>  
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
