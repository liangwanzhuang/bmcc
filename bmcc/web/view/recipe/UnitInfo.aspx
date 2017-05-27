<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UnitInfo.aspx.cs" Inherits="view_recipe_UnitInfo" %>

<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery.js"></script>

     <script type="text/javascript">

         function findTisaneBtn() {

             var TisaneMachine = $("#TisaneMachine");
             var p = [{ name: "TisaneMachine", value: TisaneMachine.val() }];
             FlexGridRecipe.applyQueryReload(p);

         }

         function findPackBtn() {
            
             var PackMachine = $("#PackMachine");
             

             var p = [{ name: "PackMachine", value: PackMachine.val()}];
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
    <li><a href="#">机组信息</a></li>
    </ul>
    </div>--%> 


    
    
    <div class="rightinfo">


    <div class="num1"  style ="border:solid 1px white;  ">
        <div class="formtitle"><span>煎药机查询</span></div>
      
       

    <ul class="forminfo">
     <li>
     <label>煎药机</label>
        <select id="TisaneMachine" runat="server" class="dfinput2" name="getperson" onChange="" style="text-align:center">
          <option value="0" selected>&nbsp;&nbsp;全部&nbsp;&nbsp;</option>
         
        </select>  
        &nbsp;&nbsp;&nbsp;&nbsp; <input name="" type="button"   class="btn" value="查询" onclick="findTisaneBtn();" />
    </li>
    <li> <uc1:dotNetFlexGrid ID="FlexGridRecipe" runat="server" /> </li>
    </ul>

   
            

</div>

    
    

     <div class="num1"  style ="border:solid 1px white;  ">

    <div class="formtitle"><span>包装机查询</span></div>

   


     <ul class="forminfo" >
     <li>
     <label>包装机</label>
        <select id="PackMachine" runat="server" class="dfinput2" name="getperson" onChange="" style="text-align:center">
          <option value="0" selected>&nbsp;&nbsp;全部&nbsp;&nbsp;</option>
        </select>
       
        &nbsp;&nbsp;&nbsp;&nbsp; <input name="" type="button"   class="btn" value="查询"  onclick="findPackBtn();" />
    </li>
    <li><uc1:dotNetFlexGrid ID="FlexGridDrug" runat="server" /> </li>
    </ul>

  

    </div>


    </div>
    
       
    </form>
</body>
</html>