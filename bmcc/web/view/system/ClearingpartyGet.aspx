﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClearingpartyGet.aspx.cs" Inherits="view_system_upload_ClearingpartyGet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function CheckInputIntFloat(oInput) {
            if ('' != oInput.value.replace(/\d{1,}\.{0,1}\d{0,}/, '')) {
                oInput.value = oInput.value.match(/\d{1,}\.{0,1}\d{0,}/) == null ? '' : oInput.value.match(/\d{1,}\.{0,1}\d{0,}/);
            }
        }
        function btnok_onclick() {
          
            var ClearPName = $("#ClearPName11").val();
            var ConPerson = $("#ConPerson11").val();
            var ConPhone = $("#ConPhone11").val();
            var Address = $("#Address11").val();
            //var PerSetInformation = $("#PerSetInformation11").val();
            var Remarks = $("#Remarks11").val();
            var GenDecoct = $("#GenDecoct11").val();
            //alert(ClearPName);
            if (ClearPName == "") {
                alert('请输入结算方名称！');
                return false;
            } else
            if (GenDecoct == "") {
                alert('请输入代煎费！');
                return false;
            } else
             if (ConPerson == "") {
                alert("请输入联系人！");
                return false;

            }else if (ConPhone == "") {
                alert("请输入联系电话！");
                return false;

            }else if (Address == "") {
                alert("请输入地址!");
                return false;

            }

            $.ajax({ type: "POST",
                url: "ClearingpartyGet.aspx/addClearingpartyinfo",
                data: "{'ClearPName':'" + ClearPName + "','ConPerson':'" + ConPerson + "','ConPhone':'" + ConPhone + "','Address':'" + Address + "','Remarks':'" + Remarks + "','GenDecoct':'" + GenDecoct + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "0") {
                        alert('添加失败,此结算方或联系人已存在');

                    } else {
                        alert('添加成功');
                    }
                    var p = [];
                    FlexGridClearingparty.applyQueryReload(p);
                }
            });

            return true;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div style="overflow:scroll; width:570px; height:430px;">
     <div class="formtitle"><span>结算方信息录入</span></div>
    
   <ul class="forminfo">
    <li><label>结算方名称</label><input id="ClearPName11" runat="server" name="" type="text" class="dfinput"/>

    </li>
    <li><label>代煎费</label><input id="GenDecoct11" runat="server" name="" type="text" class="dfinput" onkeyup="javascript:CheckInputIntFloat(this);"/></li>
    <li><label>联系人</label><input id="ConPerson11" runat="server" name="" type="text" class="dfinput"/></li>
    <li><label>联系电话</label><input id = "ConPhone11" runat="Server" name="" type="text" class="dfinput" /></li>
     <li><label>地址</label><input id ="Address11" runat="Server" name="" type="text" class="dfinput" /></li>
     <%-- <li><label>权限设置</label><input id ="PerSetInformation11" runat="Server" name="" type="text" class="dfinput" /></li>--%>
       <li><label>备注</label><input id ="Remarks11" runat="Server" name="" type="text" class="dfinput" /></li>
    <li><labe>&nbsp;</labe><input id="btnok" runat="Server" name="" type="button" class="btn" value="确认" onclick=" btnok_onclick();"/>
    </li>
    </ul>
    
   </div>
  </form>
</body>
</html>