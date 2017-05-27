<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MeRoomAdd.aspx.cs" Inherits="view_system_MeRoomAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function btnok_onclick() {


            var meRoomName = $("#meRoomName").val();
            var meRoomNum = $("#meRoomNum").val();
           
            var Remarks = $("#Remarks").val();
            
          
            if (meRoomName == "") {
                alert('请输入煎药室名称');
                return false;
            } else if (meRoomNum == "") {
                alert('请添加煎药室编号');
                return false;
            }
           /*
            else if (Remarks == "") {
                alert('请添加备注');
                return false;
            }*/


            $.ajax({ type: "POST",
                url: "MeRoomAdd.aspx/addMeRoom",
                data: "{'meRoomName':'" + meRoomName + "','meRoomNum':'" + meRoomNum + "','Remarks':'" + Remarks + "'}",
                // "','SendTime':'" + SendTime +
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    if (data.d == "0") {
                        alert('添加失败,煎药信息已存在！');
                       
                    } else {
                        alert('添加成功！');
                        
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
   <div class="formbody">
    
     <div class="formtitle"><span>煎药室信息</span></div>
    <input id ="idnum" runat="server" type="hidden" name="FunName"/>
    <ul class="forminfo">
    
    <li><label>煎药室名称</label><input id="meRoomName" runat="Server" name="" type="text" class="dfinput"  /><i></i></li>
    <li><label>煎药室编号</label><input id="meRoomNum" runat="server" name="" type="text" class="dfinput"  /></li>
  
     <li><label>备注</label><input id ="Remarks" runat="Server" name="" type="text" class="dfinput" /></li>
    
    <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" type="button" class="btn" value="确认" onclick=" btnok_onclick();"/></li>
    </ul>
    </div>
   
  </form>
</body>
</html>