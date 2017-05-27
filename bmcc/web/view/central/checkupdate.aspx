<%@ Page Language="C#" AutoEventWireup="true" CodeFile="checkupdate.aspx.cs" Inherits="view_central_checkupdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <input id ="idnum" runat="server" type="hidden" name="FunName"/> 
    <div>
      <ul class="forminfo">
  
    <li><label>质检时间</label> <input id="qualitycheckTime1" runat="server" name="" type="text" class="dfinput2" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" readonly="readonly"/><label>&nbsp;&nbsp;质检人员&nbsp;&nbsp</label><input id="qualitycheckperson1" runat="Server" name="" type="text" class="dfinput2" /></li>
    <li><label>煎药单号</label><input id ="tisaneid1" runat="Server" name="" type="text" class="dfinput" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/><i></i></li>
    <li><label>处方重量</label><input id ="pspnumweight1" runat="Server" name="" type="text" class="dfinput2" onkeyup="javascript:CheckInputIntFloat(this);"/><label>&nbsp;&nbsp;实际重量&nbsp;&nbsp;</label><input id="actualweight1" runat="Server" name="" type="text" class="dfinput2" onkeyup="javascript:CheckInputIntFloat(this);"/></li>
    <%-- <li><label>误差</label><input id="deviation1" runat="Server" name="" type="text" class="dfinput2" onkeyup="javascript:CheckInputIntFloat(this);"/><label>&nbsp;&nbsp;误差百分百</label><input id="deviationpercent1" runat="Server" name="" type="text" class="dfinput2" onkeyup="javascript:CheckInputIntFloat(this);"/></li>--%>
    <li><label>处理情况</label><input id="casetodo1" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
    <li><label>药味</label><input id="taste1" runat="Server" name="" type="text" class="dfinput2" /><label>&nbsp;&nbsp;实际药味&nbsp;&nbsp;</label><input id="actualtaste1"  runat="Server" name="" type="text" class="dfinput2" /></li>
    <li><label>是否合格</label> <select id="ischeck1" runat="server" class="dfinput2" name="hostpital" onChange="" style="text-align:center">
    </select><label>&nbsp;&nbsp;配方员&nbsp;&nbsp;</label><input id ="matchperson1" runat="Server" name="" type="text" class="dfinput2" /></li>
    <li><label>验方员</label><input id="checkperson1" runat="Server" name="" type="text" class="dfinput2" /><label>&nbsp;&nbsp;贴数&nbsp;&nbsp;</label><input id="tienum1" runat="Server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/></li>
    <li><label>备注</label><input id="remark1" runat="Server" name="" type="text" class="dfinput" /></li>
    <li><label>&nbsp;&nbsp</label><asp:Button ID="Button1" runat="server" OnClick="Button2_Click"  class="btn" CommandName="A" Text="更改" /></li>
   
    </ul>
    </div>
    </form>
</body>
</html>
