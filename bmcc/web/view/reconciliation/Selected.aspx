<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Selected.aspx.cs" Inherits="view_reconciliation_Selected" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
      <script type="text/javascript">

          function btnok_onclick() {
              var ReconciliaPer = $("#ReconciliaPer1").val();
              var ReconciliaT = $("#ReconciliaT1").val();
            
              if (ReconciliaT == "") {
                  alert('请输入对账时间！');
                  return false;
              } else if (ReconciliaPer == "") {
                  alert("请输入对账人！");
                  return false;

              }
              var strRowIds, Clearing, Remarks;
              strRowIds = $('#strRowIds').val();
              Clearing = $('#Clearing1').val();
              Remarks = $('#RemarksA').val();
              $.ajax({ type: "POST",
                  url: "Selected.aspx/AddReconciliation",
                  data: "{'strRowIds':'" + strRowIds + "','Clearing':'" + Clearing + "','ReconciliaT':'" + ReconciliaT + "','ReconciliaPer':'" + ReconciliaPer + "','Remarks':'" + Remarks + "'}",
                  contentType: "application/json; charset=utf-8",
                  success: function (data) {
                      refurbishFlexGridRecipe();
                      closeDiv();
                  }
              });
              
              return true;
              
          }
          function refurbishFlexGridRecipe() {
                var p = [];
                FlexGridRecipe.applyQueryReload(p);
          }
</script>
    
<style type="text/css">
.btn3 {
    font-size: 9pt;
    color: #003399;
    border: 1px #003399 solid;
    color: #006699;
    border-bottom: #93bee2 1px solid;
    border-left: #93bee2 1px solid;
    border-right: #93bee2 1px solid;
    border-top: #93bee2 1px solid;
 
    background-color: #F5F7F9;
    cursor: hand;
    font-style: normal;
    width: 80px;
    height: 34px;
    
}
</style>  
   
</head>
<body>
    <form id="form1" runat="server">
 <div style="overflow:scroll; width:570px; height:430px;">
  <input id="idnum1" runat="Server" name="" type="hidden" class="dfinput2" />
    
   <ul class="forminfo">
     <div class="formtitle"><span>对账信息</span></div>
      <li><label>结算方</label>
        <select id="Clearing1" runat="Server" class="dfinput">
            
        </select></li>
    <li><label>对账时间</label><input id="ReconciliaT1" runat="Server" name="" type="text" class="dfinput" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" readonly="readonly"/><i></i></li>
    <li><label>对账人</label><input id="ReconciliaPer1" runat="server" name="" type="text" class="dfinput"/></li>
    <li><label>备注</label><input id="RemarksA" runat="server" name="" type="text" class="dfinput" /></li>
    
   <input id="Button1" type="button"  value="生成对账单"  class="btn3" onclick="btnok_onclick();"/>
   <%--<asp:Button ID="Button1" runat="server" Text="生成对账单"  CssClass="btn3" OnClientClick="javascript: btnok_onclick();"/> --%>
    </ul>
    <input id="strRowIds" runat="Server" type="hidden" />
   </div>
  </form>
</body>
</html>