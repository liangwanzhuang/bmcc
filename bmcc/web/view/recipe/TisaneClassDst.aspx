<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TisaneClassDst.aspx.cs" Inherits="view_recipe_DrugDecoctingMachineDistribution" %>
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
       function findBtn() {
           var PspNum = $("#PspNum");

    

           var p = [{ name: "PspNum", value: PspNum.val() }];
           FlexGridTisaneClass.applyQueryReload(p);


             //window.location = "printRecipe.aspx?findRrescription=true&hospitalId=" + hospitalSelect.val() + "&recipeNum=" + recipeSelect.val();
       }



       function print() {
           var rows = FlexGridTisaneClass.getSelectedRowsIds();
           if (rows.length != 1) {
               alert("请选择需要打印的一行");
               return;
           } else {

           }

           var url = "tisanebarcode.aspx?id=" + rows;

           window.location.href = url;



       }


</script>
</head>
<body>
<form id="form1" runat="server">
<%--<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">处方管理</a></li>
    <li><a href="#">泡药管理</a></li>
    <li><a href="#">煎药机组分配</a></li>
    </ul>
    </div>--%> 
    <div class="rightinfo">
    <div class="tools">
        <ul class="toolbar">
        <li class="click" onclick="findBtn();"><span><img src="../../img/t01.png" /></span>查询</li>
       
        </ul>
     </div>
   <ul class="forminfo">
    <li><label>处方号</label><input id="PspNum" runat="Server" name="" type="text" class="dfinput" /><i></i></li>

    <uc1:dotnetflexgrid ID="FlexGridTisaneClass" runat="server" />

</form>
    
</body>
</html>
