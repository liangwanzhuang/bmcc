<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TisaneManage.aspx.cs" Inherits="view_recipe_TisaneManage" %>

<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <%--<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">煎药信息</a></li>
    <li><a href="#">机组信息</a></li>
    <li><a href="#">查询功能</a></li>
    </ul>
    </div>--%> 
    
    <div class="rightinfo">


    <div class="num1"  style ="border:solid 1px white;  ">
        <div class="tools">
    
    	   	<ul class="toolbar">
        <li class="click"><span><img src="../../img/t01.png" /></span>查询</li>
        <li class="click"><span><img src="../../img/t03.png" /></span>删除</li>
        </ul>     
       
    </div>

    <ul class="forminfo">
     <li>
     <label>煎药单</label>
        <select id="txtRecipeNum" runat="server" class="dfinput2" name="getperson" onChange="" style="text-align:center">
          <option value="" selected>&nbsp;&nbsp;1234567&nbsp;&nbsp;</option>
          <option value="">12345678</option>
        </select>    
    </li>
    </ul>

    <uc1:dotNetFlexGrid ID="FlexGridRecipe" runat="server" /> 
            

</div>

    
     <div><label>煎药机温度检测</label></div>


     <div class="num1"  style ="border:solid 1px white;  ">

    <div  class="tools">
    	<ul class="toolbar">
        <li class="click"><span><img src="../../img/t01.png" /></span>查询</li>
        </ul>     
    </div>

     <ul class="forminfo" >
     <li>
     <label>煎药机号</label>
        <select id="Select1" runat="server" class="dfinput2" name="getperson" onChange="" style="text-align:center">
          <option value="" selected>&nbsp;&nbsp;1&nbsp;&nbsp;</option>
          <option value="">2</option>
        </select>
        
    </li>
    </ul>

    <uc1:dotNetFlexGrid ID="FlexGridDrug" runat="server" /> 

    </div>


    </div>
    
       
    </form>
</body>
</html>