<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeliveryinformationGet.aspx.cs" Inherits="view_recipe_DeliveryinformationGet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function btnok_onclick() {
            var id = $("#idnum").val();
            
            var DecoctingBar = $("#DecoctingBar").val();
            var Sendpersonnel = $("#Sendper").val();
           // var SendTime = $("#SendT").val();
            var Remarks = $("#Remarks").val();
            var dtbtype = $("#dtbtype").val();
            var logisticsnum = $("#logisticsnum").val();
           // alert(id);
             //alert(DecoctingNum);
            var num = /^\d{24}$/;

            if (DecoctingBar == "") {
                alert('请输入煎药条码');
                 return false;
            } else if  (!num.test(document.getElementById("DecoctingBar").value)){
                alert("请输入24位数字");
                return false;
                 
                } else if (Sendpersonnel == "") {
                alert('请添加发货人员');
                return false;
            } else if (dtbtype == "") {
                alert('请添加快递类型');
                return false;
            }else if (logisticsnum == "") {
                alert('请添加物流单号');
                return false;
            }  

            
            $.ajax({ type: "POST",
                url: "DeliveryinformationGet.aspx/addDeliveryinfo",
                data: "{'id':'" + id + "','DecoctingBar':'" + DecoctingBar + "','Sendpersonnel':'" + Sendpersonnel + "','Remarks':'" + Remarks + "','dtbtype':'" + dtbtype + "','logisticsnum':'" + logisticsnum + "'}",
                // "','SendTime':'" + SendTime +
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    if (data.d == "0") {
                        alert('添加失败，此处方可能已完成发货！');
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
                   // window.location.reload();
                    var p = [];
                    dotNetFlexGrid7.applyQueryReload(p);
                }
            });
            return true;

        }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
   <div class="formbody">
    
     <div class="formtitle"><span>发货信息</span></div>
    <input id ="idnum" runat="server" type="hidden" name="FunName"/>
    <ul class="forminfo">
    
    <li><label>煎药条码</label><input id="DecoctingBar" runat="Server" name="" type="text" class="dfinput" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"  readonly="readonly"/><i></i></li>
    <li><label>发货人员</label>
      <select id="Sendper" runat="server" name="sect" type="text" class="dfinput" style="text-align:center"  readonly="readonly" ></select></li> 
    <%-- <input id="Sendper" runat="server" name="" type="text" class="dfinput"/></li>
    <li><label>发货时间</label><input id = "SendT" runat="Server" name="" type="text" class="dfinput" onfocus="calendar.show({ id: this });" readonly="readonly"/></li>--%>
     <li><label>快递类型</label>
     <select class="dfinput2" id="dtbtype" runat="server" name="" onChange="" style="text-align:center">
        <option value="0">厂内配送</option>
            <option value="1">顺丰</option>
            <option value="2">圆通</option>
            <option value="3">中通</option>
            <option value="4">EMS</option>
        </select></li>
     
      <li><label>物流单号</label><input id ="logisticsnum" runat="Server" name="" type="text" class="dfinput" /></li>
     <li><label>备注</label><input id ="Remarks" runat="Server" name="" type="text" class="dfinput" /></li>
    
    <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" type="button" class="btn" value="确认" onclick=" btnok_onclick();"/></li>
    </ul>
    </div>
   
  </form>
</body>
</html>