<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TisaneInfo.aspx.cs" Inherits="view_recipe_TisaneInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery.js"></script>
     <script type="text/javascript">
         function findTisaneBtn() {

             var tisaneid = $("#tisaneid");
             var p = [{ name: "tisaneid", value: tisaneid.val()}];
             FlexGridRecipe.applyQueryReload(p);
         }



         function findpackBtn() {

             var tisanenum = $("#tisanenum");
             var p = [{ name: "tisanenum", value: tisanenum.val()}];
             FlexGridDrug.applyQueryReload(p);
         }

    </script>







</head>
<body>
    <form id="form1" runat="server">
    <%--<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">处方管理</a></li>
    <li><a href="#">煎药管理</a></li>
    <li><a href="#">泡药信息</a></li>
    </ul>
    </div>--%> 
    
    <div class="rightinfo">


    <div class="num1"  style ="border:solid 1px white;  ">
       
    
   <div class="formtitle"><span>煎药单号查询</span></div>
       

    <ul class="forminfo">
     <li>
     <label>煎药单</label>
      
      <input id="tisaneid" runat="Server" name="" type="text" class="dfinput2"/>
         &nbsp;&nbsp;&nbsp;&nbsp; <input name="" type="button"   class="btn" onclick="findTisaneBtn();"   value="查询"/> 
       
    </li>
    </ul>

    <uc1:dotNetFlexGrid ID="FlexGridRecipe" runat="server" />            

</div>

     <div class="num1"  style ="border:solid 1px white;  ">
    
     <div class="formtitle"><span>煎药机号查询</span></div>
       
     <ul class="forminfo" >
     <li>
     <label>煎药机号</label>
      <select id="tisanenum" runat="server" class="dfinput2" name="" onchange="" style="text-align:center">
    <option value="0" selected>&nbsp;&nbsp;全部&nbsp;&nbsp;</option>    
    </select>
           &nbsp;&nbsp;&nbsp;&nbsp; <input name="" type="button"   class="btn" value="查询"  onclick="findpackBtn();" />
    </li>
    </ul>

    <uc1:dotNetFlexGrid ID="FlexGridDrug" runat="server" /> 

    </div>


    </div>
    
       
    </form>
</body>
</html>