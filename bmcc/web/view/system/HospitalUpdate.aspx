<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HospitalUpdate.aspx.cs" Inherits="view_system_HospitalUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <link href="../../css/style.css" rel="stylesheet" type="text/css" />
     <script language="javascript" type="text/javascript">

         function btnRecipeOkClick() {
             var id = $("#idnum1").val();
             var hname = $("#hname11").val();
             var hshortname = $("#hshortname11").val();
             var hnum = $("#hnum11").val();
             var contacter = $("#contacter11").val();
             var phone = $("#phone11").val();
             var address = $("#address11").val();
             var pricetype = $("#pricetype11").val();
             //var settler = $("#settler11").val();

            // var HPerSetInfor = $("#HPerSetInfor11").val();
             //alert(JobNum);

             $.ajax({ type: "POST",
                 url: "HospitalUpdate.aspx/HospitalInfo",
                 data: "{'id':'" + id + "','hname':'" + hname + "','hshortname':'" + hshortname + "','hnum':'" + hnum + "','contacter':'" + contacter + "','phone':'" + phone + "','address':'" + address + "','pricetype':'" + pricetype + "'}",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     if (data.d == "0") {
                         alert('添加失败，医院编号已存在或结算方已存在！');

                     } else {
                         alert('修改成功！');
                     }
                     var p = [];
                     FlexGridHospital.applyQueryReload(p);
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
    <div class="formtitle"><span>医院信息</span></div>
   <li><label>医院名称</label><input id="hname11" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
    <li><label>医院简称</label><input id="hshortname11" runat="server" name="" type="text" class="dfinput"/></li>
    <li><label>医院编号</label><input id = "hnum11" runat="Server" name="" type="text" class="dfinput" /></li>
    <li><label>联系人</label><input id ="contacter11" runat="Server" name="" type="text" class="dfinput" /></li>
    <li><label>联系电话</label><input id ="phone11" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
    <li><label>地址</label><input id ="address11" runat="Server" name="" type="text" class="dfinput" /></li>
    <li><label>价格类型</label><input id="pricetype11" runat="Server" name="" type="text" class="dfinput" /></li>
    <%-- <li><label>结算方</label><input id="settler11" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
    <li><label>权限设置</label><input id="HPerSetInfor11" runat="Server" name="" type="text" class="dfinput" /><i></i></li>--%>
    <li><label>&nbsp;</label><input id="btnok1" runat="Server" name="" type="button" class="btn" value="确认" onclick="btnRecipeOkClick();"/></li>
    </ul>
    
   </div>
  </form>
</body>
</html>