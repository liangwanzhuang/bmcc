<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DrugDecoctingMachineDistribution.aspx.cs" Inherits="view_recipe_DrugDecoctingMachineDistribution" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
<%--<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">泡药管理</a></li>
    <li><a href="#">煎药机组分配</a></li>
    </ul>
    </div>--%> 
    <div class="rightinfo">
    <div class="tools">
        <ul class="toolbar">
        <li class="click"><span><img src="../../img/t01.png" /></span>查询</li>
        </ul>
     </div>
   <ul class="forminfo">
    <li><label>处方号</label><input id="PspNum" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
    <div>
    <div style="width:1000px; ">
        <div style="width:45%; ">
            <uc1:dotnetflexgrid ID="FlexGridDrugGlobal" runat="server" />
        </div>
        <div style="width:10%; ">
           &nbsp;&nbsp;&nbsp;&nbsp;
        </div>
    
        </div>
    </div>
</form>
    
</body>
</html>
