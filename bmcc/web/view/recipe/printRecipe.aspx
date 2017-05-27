<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printRecipe.aspx.cs" Inherits="view_recipe_printRecipe" %>

<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery.js"></script>

     <script type="text/javascript">
         $(document).ready(function () {
             $("click").click(function () {
                 alert("");
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

         var currentid;
         function findBtn() {
             var recipeSelect = $("#recipeSelect");
             var hospitalSelect = $("#hospitalSelect");
             var printStatus = $("#printStatus")

             var p = [{ name: "hospitalId", value: hospitalSelect.val() }, { name: "pspnum", value: recipeSelect.val() },{name:"printStatus",value: printStatus.val()}];
             FlexGridRecipe.applyQueryReload(p);

         }
         var FlexGridRecipe_selectId = "0";
         DotNetFlexiGrid_onChecked = function (e) {
             
             FlexGridRecipe_selectId = e;
             var array = FlexGridRecipe.getCellDatas(e);
             $('#Pspnum').val(array[4]);
             //传递给Grid2一个查询选项数组并让其刷新
             var p = [{ name: "pid", value: "" + array[0] + ""}];

             FlexGridDrug.applyQueryReload(p);

         };

         countstatistics();
         function countstatistics() {
             $.ajax({ type: "POST",
                 url: "DrugGlobalInfo.aspx/countstatistics",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     document.getElementById("count").innerHTML = data.d;
                 }
             });


         }
         setInterval("countstatistics()", 15000);


         DotNetFlexiGrid_onunChecked = function (e) {

             FlexGridRecipe_selectId = 0;
             var array = FlexGridRecipe.getCellDatas(0);
             $('#Pspnum').val(array[4]);
             //传递给Grid2一个查询选项数组并让其刷新
             //   var p = [{ name: "drugpspnum", value: "" + array[4] + "" }, { name: "hospitalId", value: "" + array[37] + ""}];
             var a = "0";

             var p = [{ name: "pid", value: "" + a + ""}];

             FlexGridDrug.applyQueryReload(p);

         };


         function printBtn() {

             var rows = FlexGridDrugGlobal1.getSelectedRowsIds();
             if (rows.length != 1) {
                 alert("请选择需要打印的一行");
                 return;
             } else {

             }

          }

</script>

</head>
<body>
    <form id="form1" runat="server">
 
    <div class="rightinfo">
      <li><span style = "color : red"><label id="count" runat="server"/></span></li><br />
        <div class="tools">
    
    	<ul class="toolbar">
        <li class="click" onclick="findBtn();"><span><img src="../../img/t01.png" /></span>查询</li>
         <li class="click" onclick="print();"><span><img src="../../img/t07.png" /></span>选择去打印</li>
        
        </ul>     
       
    </div>
    <ul class="forminfo">
    <li><label>医院名称</label>
        <select id="hospitalSelect" runat="server" class="dfinput2" name="hostpital" onChange="" style="text-align:center">
          <option value="0" selected>&nbsp;&nbsp;全部&nbsp;&nbsp;</option>
        </select>
   
     <label>&nbsp;&nbsp;&nbsp;&nbsp;处方号</label>
     <input id="recipeSelect" runat="Server" name="" type="text" class="dfinput2" />
       <label>&nbsp;&nbsp;&nbsp;&nbsp;打印状态 </label> 

          
        <select id="printStatus" runat="server" class="dfinput2" name="getperson" onChange="" style="text-align:center">
          <option value="0" selected>&nbsp;&nbsp;已审核未打印&nbsp;&nbsp;</option>
          <option value="1">&nbsp;&nbsp;已打印</option>
         
        </select>
    </li>

    <li> <uc1:dotNetFlexGrid ID="FlexGridRecipe" runat="server" 
              EventOnCheckedFunc="DotNetFlexiGrid_onChecked" 
               EventOnUnCheckedFunc="DotNetFlexiGrid_onunChecked" 
            /> </li>

    <li><uc1:dotNetFlexGrid ID="FlexGridDrug" runat="server" /></li>
   </ul>

    </div>

    <div id='pop_div' class="pop_box">
            <div class="p_head">
                <div class="p_h_title">
                    <span><asp:Label id="flowtitle" runat="server"/></span>
                </div>
                <div class="p_h_x" onclick="closeDiv();" title="关闭">关闭</div>
            </div>
            <div class="p_box_body" id="p_b_body"></div>
   </div>

    <%--加载顺序要放到表格控件的后边--%>
    <link href="../../Css/ShowWin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery.divbox.js"> </script>
    <script type="text/javascript" src="../../Scripts/jquery.easydrag.handler.beta2.js"></script>
    <script type="text/javascript" src="../../js/DatePicker.js"></script> 
    <script language="javascript" type="text/javascript">
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
        
    </script>
    <div style="width:10%;">

    &nbsp;&nbsp;&nbsp;&nbsp;

                &nbsp;&nbsp;&nbsp;&nbsp;

    </div>
    </form>
</body>
</html>