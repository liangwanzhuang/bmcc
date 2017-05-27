<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LossiInforUpdate.aspx.cs" Inherits="view_storeroom_StorageListUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>报损信息修改</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
     <script language="javascript" type="text/javascript">

         function btnok_onclick() {
             var id = $("#idnum1").val();
            
             var Type = $("#Type1").val();
             var Per = $("#Per1").val();
             var Reason = $("#Reason1").val();
             var lossnum = $("#lossnum1").val();
             var Rmarkes = $("#Rmarkes1").val();
             
             
             //alert(JobNum);

             $.ajax({ type: "POST",
                 url: "LossiInforUpdate.aspx/lossiInforInfo",
                 data: "{'id':'" + id + "','Type':'" + Type + "','Per':'" + Per + "','Reason':'" + Reason + "','lossnum':'" + lossnum + "','Rmarkes':'" + Rmarkes + "'}",

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
     <div class="formtitle"><span>报损基本信息</span></div>
    
         <li><label>信息类别</label>
        <select class="dfinput2" id="Type1" runat="server" name="hostpitalname" onChange="" style="text-align:center">
        <option value="库房报损">库房报损单</option>    
        <option value="库房报溢">库房报溢单</option>
         </select>
         <label>人&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;员</label><input id="Per1" runat="server" name="" type="text" class="dfinput2" />
         </li>

    <li><label>原&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;因</label><input id="Reason1" runat="server" name="" type="text" class="dfinput2" />
    <label>数&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;量</label><input id="lossnum1" runat="server" name="" type="text" class="dfinput2" />

    </li>
   <li> <label>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注</label><input id ="Rmarkes1" runat="Server" name="" type="text" class="dfinput" /></li>
  <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" type="button" class="btn" value="确认" onclick=" btnok_onclick();"/></li>
    </ul>
    
    
   </div>
  </form>
</body>
</html>