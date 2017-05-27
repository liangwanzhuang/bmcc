<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuthorityGet.aspx.cs" Inherits="view_system_AuthorityGet" %>

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
    <li><a href="#">系统设置</a></li>
    <li><a href="#">系统设置</a></li>
    <li><a href="#">权限管理</a></li>
    <li><a href="#">权限设置</a></li>
    </ul>

    </div>
    
     <div class="formtitle"><span>权限设置</span></div>
    
   <ul class="forminfo">
    <li><label>人员</label><input id="Personnel" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
    
   
    <li><label>选择权限</label>
   <%-- <select id="Jurisdiction" runat="server" class="dfinput" name="" onChange="" style="text-align:center">--%> 
   <br/>

      <input id="subBoxSup1" name="subBoxSup1" type="checkbox" />
        接方权限
   <br/>
        &nbsp;&nbsp;&nbsp;&nbsp;<input name="subBox1" type="checkbox" />
          处方录入
        &nbsp;&nbsp;<input name="subBox1" type="checkbox" />
          药品录入
        &nbsp;&nbsp;<input name="subBox1" type="checkbox" />
          接方信息查看
        <br/>
   
     <input id="Checkbox1" name="subBoxSup1" type="checkbox" />
        配方权限
       <br/>
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <input name="subBox1" type="checkbox" />
        药方审核
       &nbsp;&nbsp; &nbsp;&nbsp; <input name="subBox1" type="checkbox" />
        药方匹配
        &nbsp;&nbsp;&nbsp;&nbsp; <input name="subBox1" type="checkbox" />
        打印条形码和调配单
        &nbsp;&nbsp; &nbsp;&nbsp; <input name="subBox1" type="checkbox" />
        配方信息查看
        <br/>
       &nbsp;&nbsp;&nbsp;&nbsp; <input id="Checkbox2" name="subBoxSup1" type="checkbox" />
        调剂权限
      <br/>
        &nbsp;&nbsp;<input name="subBox1" type="checkbox" />
        调剂信息查看
        
        <br/>
     &nbsp;&nbsp;&nbsp;&nbsp;<input id="Checkbox3" name="subBoxSup1" type="checkbox" />
        复核权限
      <br/>
       &nbsp;&nbsp; <input name="subBox1" type="checkbox" />
        复核信息查询
        &nbsp;&nbsp;<input name="subBox1" type="checkbox" />
        复核功能（包括重审、强制合格等）
       &nbsp;&nbsp; <input name="subBox1" type="checkbox" />
        工作记录查看
       
        <br/>
        &nbsp;&nbsp;&nbsp;&nbsp; <input id="Checkbox4" name="subBoxSup1" type="checkbox" />
        泡药权限
<br/>
        &nbsp;&nbsp;<input name="subBox1" type="checkbox" />
        泡药信息查询
       &nbsp;&nbsp; <input name="subBox1" type="checkbox" />
        煎药机组分配信息显示
       
       
        <br/>
        &nbsp;&nbsp;&nbsp;&nbsp; <input id="Checkbox5" name="subBoxSup1" type="checkbox" />
        煎药权限
<br/>
        &nbsp;&nbsp;<input name="subBox1" type="checkbox" />
        煎药处方信息查询
        &nbsp;&nbsp;<input name="subBox1" type="checkbox" />
        机组信息查询
       
       
        <br/>
       &nbsp;&nbsp;&nbsp;&nbsp;  <input id="Checkbox6" name="subBoxSup1" type="checkbox" />
        包装权限
<br/>
        &nbsp;&nbsp;&nbsp;&nbsp;<input name="subBox1" type="checkbox" />
        包装信息查看
        
       
        <br/>
        &nbsp;&nbsp;&nbsp;&nbsp; <input id="Checkbox7" name="subBoxSup1" type="checkbox" />
        发货权限
<br/>
        &nbsp;&nbsp;<input name="subBox1" type="checkbox" />
        发货信息查看
        
       
        <br/>
        &nbsp;&nbsp;&nbsp;&nbsp; <input id="Checkbox8" name="subBoxSup1" type="checkbox" />
        医院登录权限
<br/>
        &nbsp;&nbsp;<input name="subBox1" type="checkbox" />
        查看中心监控
       &nbsp;&nbsp; <input name="subBox1" type="checkbox" />
        大屏显示
       &nbsp;&nbsp;<input name="subBox1" type="checkbox" />
        查询统计页面
        <br/>
        &nbsp;&nbsp;&nbsp;&nbsp; <input id="Checkbox9" name="subBoxSup1" type="checkbox" />
        管理权限
<br/>
       &nbsp;&nbsp; <input name="subBox1" type="checkbox" />
        查看所有页面
       &nbsp;&nbsp; <input name="subBox1" type="checkbox" />
        具备全部权限
       
       
        <br/>
    </li>
    
    <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" type="button" class="btn" value="确认" onserverclick="btnAddClick"/>&nbsp;&nbsp;&nbsp;&nbsp;<a href="Authority.aspx"><input name="" type="button" class="btn" value="取消"/></a></li>
    </ul>
    
   
  </form>
</body>
</html>