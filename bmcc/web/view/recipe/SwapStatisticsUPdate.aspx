<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SwapStatisticsUPdate.aspx.cs" Inherits="view_recipe_SwapStatisticsUPdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    

    <script type="text/javascript">
        function subFun() {
            var id = $("#idnum").val();
            var wordcontent = $("#WorkContent").val();
            var wordDate = $("#Date").val();
            var workload = $("#Workload").val();

            $.ajax({ type: "POST",
                url: "SwapStatisticsUPdate.aspx/updateAdjust",
                data: "{'id':'" + id + "','wordcontent':'" + wordcontent + "','wordDate':'" + wordDate + "','workload':'" + workload + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d != 0) {
                        alert('操作成功');
                        closeDiv();
                        serchFun();
                    } else {

                        alert('操作失败');
                    }
                }
            });

        }
        
    </script>
</head>
<body>
   <form id="form1" runat="server">
    <div style="overflow:scroll; width:570px; height:430px;">
    <input id ="idnum" runat="server" type="hidden" name="FunName"/> 
    
     <div class="formtitle"><span>调剂统计信息录入</span></div>
    
   <ul class="forminfo">
       <li><label>日期</label><input id="Date" runat="Server" onfocus="setday(this)" readonly="readonly" name="" type="text" class="dfinput" /><i></i></li>
       <li><label>工作内容</label><input id="WorkContent" runat="Server" name="" type="text"  class="dfinput" /><i></i></li>
       <li><label>工作量</label><input id="Workload" runat="Server" name="" type="text"  class="dfinput" /><i></i></li>  
    <li><label>&nbsp;</label><input id="btnok" name="" onclick="subFun();" type="button" class="btn" value="确认" />&nbsp;&nbsp;&nbsp;&nbsp;<a href="javascript:closeDiv();"><input name="" type="button" class="btn" value="取消"/></a></li>
    </ul>
    
   
  </form>
</body>
</html>
