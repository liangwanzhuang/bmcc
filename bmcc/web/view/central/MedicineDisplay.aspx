<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MedicineDisplay.aspx.cs" Inherits="view_central_MedicineDisplay" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>发药显示</title>
        <link href="../../css/style.css" rel="stylesheet" type="text/css" />
           <script type="text/javascript" src="../../js/jquery.js"></script>
        <script type="text/javascript">
       function current() {
                var t;
        var d = new Date(), str = '';
        str += d.getFullYear().toString(10) + '年'; //获取当前年份 
         
         t= d.getMonth() + 1 ; //获取当前月份（0——11）
         str += (t > 9 ? "" : "0") + t + '月'
         t= d.getDate();
         str += (t > 9 ? "" : "0") + t + '日' + " ";
         t= d.getHours();
         str += (t > 9 ? "" : "0") + t + ":";
         t= d.getMinutes() ;
         str += (t > 9 ? "" : "0") + t + ":";
         t= d.getSeconds();
         str += (t > 9 ? "" : "0") + t;  
        return str;
    }
    setInterval(function () { $("#nowTime").html(current) }, 1000);
    function findBtn() {
        var p = [];
        FlexGridMedicineDisplay.applyQueryReload(p);
        $(".loading").hide();
    }
    setInterval('findBtn()', 30000); //指定1秒刷新一次

    countstatistics();

    function countstatistics() {
        $.ajax({ type: "POST",
            url: "MedicineDisplay.aspx/countstatistics",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                // alert(data.d);
                // $("#count").val(data.d);
                //var a = $("#count").val();
                // alert(a);
                // $("#count").val() = data.d;
                // count.text = a;

                document.getElementById("deliveryinfo").innerHTML = data.d;
            }
        });


    }
    setInterval("countstatistics()", 20000);









    </script> 
 </head>
<body  class ="">

    <form id="form1" runat="server">
   
     <div id="Layer1" style="position:absolute; width:100%; height:100%; z-index:-1">    
     <img src="../../img/back.jpg" height="100%" width="100%"/>
   </div>
   <div class="aaa" ; >
    <uc1:dotNetFlexGrid ID="FlexGridMedicineDisplay" runat="server" />
 
    </div>
      <div class="bbb" ; id="nowTime"></div> 

       <div class="ddd"  id="info"><span><label id ="deliveryinfo" style ="font-size:23px;"/></span> </div> 
    </form>
   
</body>
</html>
