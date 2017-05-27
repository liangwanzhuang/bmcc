<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WarehousepharmacyGet.aspx.cs" Inherits="view_system_WarehousepharmacyGet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function btnok_onclick() {

            var WName = $("#WName1").val();
            var WareNum = $("#WareNum1").val();
            var Type = $("#Type1").val();
            
            //alert(JobNum);
            if (WName == "") {
                alert('请输入名称！');
                return false;
            } else if (WareNum == "") {
                alert("请输入仓库编号！");
                return false;

            }


            $.ajax({ type: "POST",
                url: "WarehousepharmacyGet.aspx/addWarehousepharmacyGetinfo",
                data: "{'WName':'" + WName + "','WareNum':'" + WareNum + "','Type':'" + Type + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "0") {
                        alert('添加失败,仓库编号已存在!');

                    } else {
                        alert('添加成功!');
                        for (i = 0; i < document.all.tags("input").length; i++) {
                            if (document.all.tags("input")[i].type == "text") {
                                document.all.tags("input")[i].value = "";
                            }
                        }  
                    }
                    var p = [];
                    dotNetFlexGrid3.applyQueryReload(p);
                }
            });

            return true;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
 <div style="overflow:scroll; width:570px; height:430px;">
    
   
    
   <ul class="forminfo">
     <div class="formtitle"><span>药房库房信息</span></div>
      <li><label>类&nbsp;&nbsp;&nbsp;&nbsp;型</label>
        <select id="Type1" runat="Server" class="dfinput">
            <option value="库房">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;库房</option>
            <option value="药房">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;药房</option>
        </select></li>
    <li><label>名称</label><input id="WName1" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
    <li><label>仓库编号</label><input id="WareNum1" runat="server" name="" type="text" class="dfinput"/></li>
   
       
    <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" type="button" class="btn" value="确认" onclick=" btnok_onclick();"/></li>
    </ul>
    
   </div>
  </form>
</body>
</html>