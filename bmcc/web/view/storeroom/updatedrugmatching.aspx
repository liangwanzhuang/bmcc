<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updatedrugmatching.aspx.cs" Inherits="view_storeroom_updatedrugmatching" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>药品添加信息</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">



        function okonclick() {
         




        }

        function btnok_onclick() {
            var id = $("#idnum1").val();
            var hospitalname = $("#hospitalname123").val();
          
            var DrugName12 = $("#DrugName12").val();
            var DrugCode1 = $("#DrugCode1").val();

            var ypcdrugname = $("#ypcdrugname").val();
            var ypcdrugcode = $("#ypcdrugcode").val();

            var positionnum = $("#positionnum").val();

            if (DrugName12 == "") {
                alert("请输入医院药品名称!");
                return false;

            } else if (DrugCode1 == "") {
                alert("请输入医院药品编号！");
                return false;

            }
            else if (ypcdrugname == "") {
                alert("请输入饮片厂药品药品名字！");
                return false;

            }
            else if (ypcdrugcode == "") {
                alert("请输入饮片厂药品药品编号！");
                return false;

            }
            else if (positionnum == "") {
                alert("请输入货位号！");
                return false;
            }

            $.ajax({ type: "POST",
                url: "updatedrugmatching.aspx/updatematchingInfo",
                data: "{'hospitalname':'" + hospitalname + "','DrugName12':'" + DrugName12 + "','DrugCode1':'" + DrugCode1 + "','ypcdrugname':'" + ypcdrugname + "','ypcdrugcode':'" + ypcdrugcode + "','positionnum':'" + positionnum + "','id':'" + id + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "0") {
                        alert('修改失败');

                    } else {
                        alert('修改成功');
                    }
                    var p = [];
                    dotNetFlexGrid1.applyQueryReload(p);
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
     <div class="formtitle"><span>修改匹配表信息</span></div>
     <li> <label  style="width:80px;">医院名称</label> <select id="hospitalname123" style="width:182px;" runat="Server" class="dfinput2"> 
        </select>
    <label style="width:80px;">医院药品名称</label><input id="DrugName12" style="width:180px;" runat="server" name="" type="text" class="dfinput2"/></li>
  <li>  <label style="width:80px;">医院药品编号</label><input id="DrugCode1"  style="width:180px;" runat="server" name="" type="text" class="dfinput2" />  
    
    <label  style="width:80px;">饮药品名称</label><input id="ypcdrugname" style="width:180px;" runat="Server" name="" type="text" class="dfinput2" /></li>
    <li>
    <label  style="width:80px;">饮药品编号</label><input id ="ypcdrugcode" style="width:180px;" runat="Server" name="" type="text" class="dfinput2" />

    <%-- <label>货位号</label><input id="positionnum" runat="Server" name="" type="text" class="dfinput2" />--%></li>
     
     <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" type="button" class="btn" value="确认"  onclick="return btnok_onclick()" /></li>
    
    </ul>
    
   </div>
  </form>
</body>
</html>