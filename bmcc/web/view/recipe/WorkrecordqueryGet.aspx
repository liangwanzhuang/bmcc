<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkrecordqueryGet.aspx.cs" Inherits="view_recipe_WorkrecordqueryGet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        
        function btnok_onclick() {

            var DecoctingNum = $("#DecoctingNum").val();

            var num = /^\d{24}$/;

            if (DecoctingNum == "") {
                alert('请输入煎药条码');
                return false;
            } else if (!num.test(document.getElementById("DecoctingNum").value)) {
                alert("请输入24位数字");
                return false;

            }
          
            $.ajax({ type: "POST",
                url: "WorkrecordqueryGet.aspx/addWorkrecordqueryinfo",
                data: "{'DecoctingNum':'" + DecoctingNum +  "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "0") {
                        alert('添加失败');

                    } else {
                        alert('添加成功');
                    }
                    var p = [];
                    dotNetFlexGrid5.applyQueryReload(p);
                }
            });

            return true;
        }

    </script>
</head>
<body>
  
    
     <form id="form1" runat="server">
   <div class="formbody">
    
    <div class="formtitle"><span>工作记录查询</span></div>
    <input id ="idnum" runat="server" type="hidden" name="FunName"/> 
    
    <ul class="forminfo">
    

    <li><label>煎药条码</label><input id="DecoctingNum" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/></li>
    <li><label>&nbsp;</label><input id="ok" runat="server" name="" type="button" class="btn" value="确认" onclick=" btnok_onclick();" /></li>
    </ul>
    
    
    </div>


    </form>
</body>
</html>
