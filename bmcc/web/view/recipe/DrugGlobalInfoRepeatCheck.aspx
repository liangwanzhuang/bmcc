<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DrugGlobalInfoRepeatCheck.aspx.cs" Inherits="view_recipe_DrugGlobalInfoRepeatCheck" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>该处方对应的药品信息</div>
    <div>
    <uc1:dotnetflexgrid ID="FlexGridDrugGlobal1" runat="server" />
    </div>
    </form>
</body>
</html>
