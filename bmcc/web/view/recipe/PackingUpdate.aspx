<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PackingUpdate.aspx.cs" Inherits="view_recipe_PackingUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title>包装信息编辑</title>
    <script language="javascript" type="text/javascript">
       

        function CheckInputIntFloat(oInput) {
            if ('' != oInput.value.replace(/\d{1,}\.{0,1}\d{0,}/, '')) {
                oInput.value = oInput.value.match(/\d{1,}\.{0,1}\d{0,}/) == null ? '' : oInput.value.match(/\d{1,}\.{0,1}\d{0,}/);
            }
        }

        function btnRecipeOkClick() {
            var id = $("#idnum").val();
            var DecoctingNum = $("#DecNum").val();
            var Pacpersonnel = $("#Pacper").val();
            var PacTime = $("#PacTi").val();
            var Fpactate = $("#Ftate").val();
            var Starttime = $("#Sttime").val();
            var Timeset = $("#Tset").val();

           
            $.ajax({ type: "POST",
                url: "PackingUpdate.aspx/updatepackingInfo",
                data: "{'id':'" + id + "','DecoctingNum':'" + DecoctingNum + "','Pacpersonnel':'" + Pacpersonnel + "','PacTime':'" + PacTime + "','Fpactate':'" + Fpactate + "','Starttime':'" + Starttime + "','Timeset':'" + Timeset + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "0") {
                        alert('修改失败，可能该煎药单号不存在，或该煎药单号已被分配');

                    } else {
                        alert('修改成功');
                    }
                    var p = [];
                    dotNetFlexGrid6.applyQueryReload(p);
                }
            });
        }
    </script>
    
</head>
<body>

     <form id="form1" runat="server">
   <div class="formbody">
    
    <div class="formtitle"><span>包装信息</span></div>
    <input id ="idnum" runat="server" type="hidden" name="FunName"/> 
    
   <ul class="forminfo">
    <li><label>煎药单号</label><input id="DecNum" runat="Server" name="" type="text" class="dfinput" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/><i></i></li>
    <li><label>包装人员</label><input id="Pacper" runat="server" name="" type="text" class="dfinput"/></li>
    <li><label>包装时间</label><input id = "PacTi" runat="Server" name="" type="text" class="dfinput" onfocus="calendar.show({ id: this });" readonly="readonly" /></li>
     <li><label>包装状态</label>
        <select class="dfinput" id="Ftate" runat="server" onChange="" name=""  style="text-align:center">
           <option value="1" selected>&nbsp;&nbsp;未包装&nbsp;&nbsp;</option>
          
           <option value="2" >&nbsp;&nbsp;已包装&nbsp;&nbsp;</option>
        </select>
        </li>
   
    <li><label>开始时间</label><input id="Sttime" runat="Server" name="" type="text" class="dfinput" onfocus="calendar.show({ id: this });" readonly="readonly"/></li>
    <li><label>时间设置</label><input id ="Tset" runat="Server" name="" type="text" class="dfinput" onfocus="calendar.show({ id: this });" readonly="readonly"/></li>
   
    <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" onclick="btnRecipeOkClick();" type="button" class="btn" value="更新"  /></li>
    </ul>
    </div>
  
  </form>
</body>
</html>