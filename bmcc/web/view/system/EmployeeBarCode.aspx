<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeBarCode.aspx.cs" Inherits="view_recipe_EmployeeBarCode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><label style ="font-size:15px;">员工条码工牌</label></title>
 <style type="text/css" media=print>
    
.noprint{visibility:hidden} 
</style>      
</head>
<body>
<form id="form" runat="server">
 <input id ="idnum" runat="server" type="hidden" name="FunName"/> 

 <div style ="text-align:left;margin:0; padding:0;">
    <ul style ="list-style:none;text-align:left;margin:0; padding:0;">
    <li><asp:Label ID="employeenum" runat="server" style ="font-size:10px;"></asp:Label>
     <asp:Label ID="employeename" runat="server" style ="font-size:10px;"></asp:Label></li>
     <li><asp:Image ID="Image1" runat="server" Width="240" Height="64"/></li>
       <li><label style ="font-size:10px;">员工条码工牌</label></li>
    
       <div class="noprint">

       <li><label>&nbsp;</label><input id="ok" runat="server" name="" type="button"  style="width:80px;height:25px;line-height:20px;"  value="确认打印"  onclick="javascript:window.print()"   rel="external nofollow" target="_self" /> &nbsp;&nbsp;&nbsp;&nbsp;<input name="" type="button" onclick="javascript:history.go(-1)" style="width:90px;height:25px;line-height:20px;"  value="返回上一页"/></li> 
         </div>

    </ul>
     
   </div>
    
    
    </form>
</body>
</html>
