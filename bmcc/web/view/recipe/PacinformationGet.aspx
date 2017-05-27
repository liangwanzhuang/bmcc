<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PacinformationGet.aspx.cs" Inherits="view_recipe_PacinformationGet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
 <script type="text/javascript">
    

     function btnok_onclick() {

         var DecoctingBar = $("#DecoctingBar").val();
         var PackPer = $("#PackPer").val();
         
         var num = /^\d{24}$/;

         if (DecoctingBar == "") {
             alert('请输入煎药条码');
             return false;
         } else if (!num.test(document.getElementById("DecoctingBar").value)) {
             alert("请输入24位数字");
             return false;

         } if (PackPer == "") {
             alert('请输入包装人员');
             return false;
         }
      
         $.ajax({ type: "POST",
             url: "PacinformationGet.aspx/addPackingGetinfo",
             data: "{'DecoctingBar':'" + DecoctingBar +"','PackPer':'"+PackPer+"'}",
             contentType: "application/json; charset=utf-8",
             success: function (data) {
                 //  alert('fdsafdsfdasfdasfdasf');
                 // alert(data.d)

                 if (data.d == "0") {
                     alert('添加失败，此处方已包装完成，或还未煎药！');
                     for (i = 0; i < document.all.tags("input").length; i++) {
                         if (document.all.tags("input")[i].type == "text") {
                             document.all.tags("input")[i].value = "";
                         }
                     }  
                 } else {
                     alert('添加成功');
                     for (i = 0; i < document.all.tags("input").length; i++) {
                         if (document.all.tags("input")[i].type == "text") {
                             document.all.tags("input")[i].value = "";
                         }
                     }
                 }
                 //window.location.reload();
                 var p = [];
                 dotNetFlexGrid6.applyQueryReload(p);
             }
         });

         return true;
     }


    </script>
</head>
<body>
   <form id="form1" runat="server">
   <div class="formbody">
    
    <div class="formtitle"><span>包装信息</span></div>
    <ul class="forminfo">
    <li><label>煎药条码</label><input id="DecoctingBar" runat="Server" name="" type="text" class="dfinput" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')" /><i></i></li>
   <li><label>包装人员</label>
 <select id="PackPer" runat="server" name="sect" type="text" class="dfinput" style="text-align:center"  readonly="readonly" ></select></li> 
   <%-- <input id="PackPer" runat="server" name="" type="text" class="dfinput" /></li>--%>
   
     <li><label>&nbsp;</label><input id="btnok" runat="server" name="" type="button" class="btn" onclick=" btnok_onclick();" value="确认" /></li>
    </ul>
    
   </div>
  </form>
</body>
</html>