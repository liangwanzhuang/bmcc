<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecipeQuery.aspx.cs" Inherits="view_recipe_RecipeQuery" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
         
    <script type="text/javascript" src="../../js/time.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript">
        var status = 0;
        var workContent = 0;
        var dateStatus = 0;
        var psp = [];
       /* function findBtn() {
            psp = [
                    { name: "status", value: "" + status + "" },
                    { name: "workContent", value: "" + workContent + "" },
                    { name: "dateStatus", value: "" + dateStatus + "" }
                ];
            FlexGridRecipe.applyQueryReload(psp);

        }*/
        function findBtn() {
            var Employeenum = $("#Employeenum");//员工姓名
            var STime = $("#STime"); //时间
            var ETime = $("#ETime"); 
            var RecipeStatus = $("#RecipeStatus"); //处方状态
            var Psnum = $("#Psnum");
            var JTime = $("#JTime");



            var p = [{ name: "Employeenum", value: Employeenum.val() }, { name: "STime", value: STime.val() }, { name: "ETime", value: ETime.val() }, { name: "RecipeStatus", value: RecipeStatus.val() }, { name: "Psnum", value: Psnum.val() }, { name: "JTime", value: JTime.val()}];
            FlexGridRecipe.applyQueryReload(p);
        
        }

        var FlexGridRecipe_selectId = "0";
        DotNetFlexiGrid_onChecked = function (e) {
            // alert("onUnChecked" + e);
            FlexGridRecipe_selectId = e;
            var array = FlexGridRecipe.getCellDatas(e);
            //  $('#Pspnum').val(array[4]);
            //传递给Grid2一个查询选项数组并让其刷新
          //  var p = [{ name: "drugpspnum", value: "" + array[4] + "" }, { name: "hospitalId", value: "" + array[5] + ""}];
            var p = [{ name: "pid", value: "" + array[0] + ""}];
            //var p = [{ name: "drugpspnum", value: "" + array[4] + "" }, { name: "hospitalId", value: "" + array[5] + ""}];
            FlexGridDrug.applyQueryReload(p);
            //alert(array[5]);
            //   document.getElementById('select_checked').click();
        };
      //  DotNetFlexiGrid_onUnChecked = function () {
       //     FlexGridRecipe_selectId = "0";
       // }



        DotNetFlexiGrid_onUnChecked = function (e) {
            FlexGridRecipe_selectId = "0";


            //FlexGridRecipe_selectId = 0;
            var array = FlexGridRecipe.getCellDatas(0);
            $('#Pspnum').val(array[4]);
            //传递给Grid2一个查询选项数组并让其刷新
            //  var p = [{ name: "drugpspnum", value: "" + array[4] + "" }, { name: "hospitalId", value: "" + array[37] + ""}];
            var a = "0";
            var p = [{ name: "pid", value: "" + a + ""}];
            FlexGridDrug.applyQueryReload(p);

            //   document.getElementById('select_checked').click();
        };





        function RecipeStatusSelect(obj) {
            status = $(obj).val();
        }
        function JobContentSelect(obj) {
            workContent = $(obj).val();
        }

        //重新审核
        function ReAuditRecipe() {
            var rows = FlexGridRecipe.getSelectedRowsIds();
            var strRowIDs = "";
            if (rows.length > 0) {
                strRowIDs = rows[0];
            } else {
                alert("请选择需要重审的一行");
                return;
            }
            for (var i = 1; i < rows.length; i++) {
                strRowIDs += "," + rows[i]; // alert(rows[i]);
            }

            $.ajax({ type: "POST",
                url: "RecipeQuery.aspx/ReAuditRecipeById",
                data: "{'strRowIds':\"" + strRowIDs + "\"}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "0") {
                        alert('重审失败，此处方还未审核或已进入调剂以下环节！');
                    } else {
                        alert('重审成功');
                    }
                    FlexGridRecipe.applyQueryReload(psp);
                    var p = [];
                    FlexGridDrug.applyQueryReload(p);
                }
            });
        
        }


        //作废
        function deleteRecipeInfo() {
            var rows = FlexGridRecipe.getSelectedRowsIds();
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
                url: "RecipeQuery.aspx/deleteRecipeById",
                data: "{'strRowIds':\"" + strRowIDs + "\"}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "0") {
                        alert('作废失败,此处方已经作废或已在调剂以下阶段');
                    } else {
                        alert('作废成功');
                    }
                    FlexGridRecipe.applyQueryReload(psp);
                    var p = [];
                    FlexGridDrug.applyQueryReload(p);
                }
            });
        }
        //取消作废



        function print() {

            var rows = FlexGridRecipe.getSelectedRowsIds();
            if (rows.length != 1) {
                alert("请选择需要打印的一行");
                return;
            } else {

            }

            var url = "printmode.aspx?id=" + rows;

            window.location.href = url; 




        }



        countstatistics();

        function countstatistics() {
            $.ajax({ type: "POST",
                url: "DrugGlobalInfo.aspx/countstatistics",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    // alert(data.d);
                    // $("#count").val(data.d);
                    //var a = $("#count").val();
                    // alert(a);
                    // $("#count").val() = data.d;
                    // count.text = a;

                    document.getElementById("count").innerHTML = data.d;
                }
            });


        }
        setInterval("countstatistics()", 15000);







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
        //添加
        function addRecipe() {
            window.location.href = "RecipeGet.aspx"; 
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
    
}</style>
</head>
<body>
    <form id="form1" runat="server">
       <%-- <div class="place">
        <span>位置：</span>
        <ul class="placeul">
        <li><a href="#">处方管理</a></li>
        <li><a href="#">配方管理</a></li>
        <li><a href="#">配方查询</a></li>
        </ul>
    </div>--%> 
      <%-- 总部分--%> 
    <div class="rightinfo">
    <li><span style = "color : red"><label id="count" runat="server"/></span></li><br />
    <div class="tools">
    
    	<ul class="toolbar">
        <li class="click" onclick="findBtn();"><span><img src="../../img/t01.png" /></span>查询</li>
      <li id="recheck" runat="server"  style="display:none;" class="click" onclick="ReAuditRecipe();"><span><img src="../../img/t02.png" /></span>重新审核</li>
          <li class="click" onclick="deleteRecipeInfo();"><span><img src="../../img/t03.png" /></span>作废</li>
         <%-- <li class="click" onclick="addRecipe();"><span><img src=" ../../img/t05.png " /></span>添加</li>--%>
        <li class="click" onclick="CloseRecipeInfo();"><span><img src="../../img/q01.png" /></span>取消作废</li>
        <%--<li class="click" onclick="window.print()"><span><img src=" ../../img/t07.png " /></span>打印数据</li>--%>
        <input ID="Button1" type="Button"  runat="server" onserverclick="Button1_Click"   value='导出处方数据' class="btn3"/>
          <input ID="Button2"  type="Button"  runat="server" onserverclick="Button2_Click"   value='导出药品数据' class="btn3"/>

         <%-- <li class="click" onclick="print();"><span><img src=" ../../img/t07.png " /></span>打印数据</li>--%>
        </ul>          
    </div>
    
    <ul class="forminfo">
    <li><label>审核人员</label>
         <input id="Employeenum" runat="server" name="" type="text" class="dfinput2"/>
         <label>&nbsp;&nbsp;开始时间</label>
        <input id="STime" runat="server" name="" type="text" class="dfinput2" onClick="WdatePicker()" readonly="readonly"/>
        <label>&nbsp;&nbsp;结束时间</label>
        <input id="ETime" runat="server" name="" type="text" class="dfinput2" onClick="WdatePicker()" readonly="readonly"/></li> 
    
    <li><label>处方状态</label>
        <select id="RecipeStatus" runat="server" class="dfinput2" name="getperson" onChange="RecipeStatusSelect(this);" style="text-align:center">
          <option value="" selected>全部&nbsp;&nbsp;</option>
          
          <option value="未匹配"> 未匹配</option>
          <option value="未审核"> 未审核</option>
          <option value="作废">作废</option>
          <option value="已审核">已审核</option>
          <option value="审核不通过"> 审核未通过</option>
        </select>
        <label>&nbsp;&nbsp;处方号&nbsp;&nbsp;</label>
       <input id="Psnum" runat="server" name="" type="text" class="dfinput2" />

      <label>&nbsp;&nbsp;&nbsp;&nbsp;接方时间</label>
      <input class="dfinput2" id="JTime" runat="Server" name="patient"  onClick="WdatePicker()" readonly="readonly"/>



    </li>
   
   </ul><div style="width:1000px; ">
         <uc1:dotNetFlexGrid ID="FlexGridRecipe" runat="server"
         EventOnCheckedFunc="DotNetFlexiGrid_onChecked"
         EventOnUnCheckedFunc="DotNetFlexiGrid_onUnChecked" 
          /></div>
         <br />
         <br />
         <div style="width:10%;">
         <uc1:dotNetFlexGrid ID="FlexGridDrug" runat="server" /></div>
   
    </div>
        <div style="width:10%;">

           &nbsp;&nbsp;&nbsp;&nbsp;

                      &nbsp;&nbsp;&nbsp;&nbsp;

        </div>

        
    <script type="text/javascript">
        $('.tablelist tbody tr:odd').addClass('odd');
	</script>
    <div>
        <div id='pop_div' class="pop_box">
            <div class="p_head">
                <div class="p_h_title">
                    <span>处方修改</span>
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
            } else {

            }

            var url = "RecipeUpdate.aspx?id=" + rows;

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
