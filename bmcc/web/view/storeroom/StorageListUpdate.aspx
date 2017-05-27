<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StorageListUpdate.aspx.cs" Inherits="view_storeroom_StorageListUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>药品信息修改</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
     <script language="javascript" type="text/javascript">

         function btnok_onclick() {
             var id = $("#idnum1").val();
            
             var Amount = $("#Amount1").val();
             var Rmarkes = $("#Rmarkes1").val();
             var ProDate = $("#ProDate1").val();
             var ExpiryDate = $("#ExpiryDate1").val();
             var Quality = $("#Quality1").val();
             var LicenseNum = $("#LicenseNum1").val();
             
             //alert(JobNum);

             $.ajax({ type: "POST",
                 url: "StorageListUpdate.aspx/StorageListInfo",
                 data: "{'id':'" + id + "','Amount':'" + Amount + "','Rmarkes':'" + Rmarkes + "','ProDate':'" + ProDate + "','ExpiryDate':'" + ExpiryDate + "','Quality':'" + Quality + "','LicenseNum':'" + LicenseNum + "'}",

                 contentType: "application/json; charset-=utf-8",
                 success: function (data) {
                     if (data.d == "0") {
                         alert('修改失败！');

                     } else {
                         alert('修改成功！');
                     }
                     var p = [];
                     FlexGridStorage.applyQueryReload(p);
                 }
             });

         }
       
    </script>
</head>
<body>
   <form id="form1" runat="server">
    <div style="overflow:scroll; width:570px; height:430px;">
    <input id ="idnum1" runat="server" type="hidden" name="FunName"/> 
   
    
   <ul class="forminfo">
    <div class="formtitle"><span>药品信息</span></div>
    
    
       
    
    
    <li><label>数&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;量</label><input id ="Amount1" runat="Server" name="" type="text" class="dfinput2" /><i></i><label>质量情况</label>
     <select id="Quality1" runat="Server" class="dfinput2">
            <option value="优">优</option>

            <option value="良">良</option>
            <option value="差">差</option>
            
        </select>
     </li>
     
     <li><label>生产日期</label><input id ="ProDate1" runat="Server" name="" type="text" class="dfinput2" onfocus="calendar.show({ id: this });" readonly="readonly"/>
     <label>有效日期</label><input id ="ExpiryDate1" runat="Server" name="" type="text" class="dfinput2" onfocus="calendar.show({ id: this });" readonly="readonly"/><i></i></li>
   
     <li><label>批准文号</label><input id ="LicenseNum1" runat="Server" name="" type="text" class="dfinput2" /><i></i>
    
     <label>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注1</label><input id ="Rmarkes1" runat="Server" name="" type="text" class="dfinput2" /></li>
    
    <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" type="button" class="btn" value="确认" onclick=" btnok_onclick();"/></li>
    </ul>
    
    
   </div>
  </form>
</body>
</html>