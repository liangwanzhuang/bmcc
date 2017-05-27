<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SwapStatisticsGet.aspx.cs" Inherits="view_recipe_SwapStatisticsGet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
    <form id="form1" runat="server">
    <div class="place">
    <span>位置：</span>
    <ul class="placeul">
   <li><a href="#">处方管理</a></li>
        <li><a href="#">调剂管理</a></li>
        <li><a href="#">调剂统计</a></li>
    <li><a href="#">信息录入</a></li>
    </ul>

    </div>
    
     <div class="formtitle"><span>调剂统计信息录入</span></div>
    
   <ul class="forminfo">
       <li><label>日期</label><input id="Date" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
       <li><label>工作内容</label><input id="WorkContent" runat="Server" name="" type="text"  class="dfinput" /><i></i></li>
       <li><label>工作量</label><input id="Workload" runat="Server" name="" type="text"  class="dfinput" /><i></i></li>  
    <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" type="button" class="btn" value="确认" onserverclick="btnDrugGlobalInfoGetClick"/>&nbsp;&nbsp;&nbsp;&nbsp;<a href="SwapStatistics.aspx"><input name="" type="button" class="btn" value="取消"/></a></li>
    </ul>
    
   
  </form>
</body>
</html>
