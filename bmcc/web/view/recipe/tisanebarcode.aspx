<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tisanebarcode.aspx.cs" Inherits="view_recipe_tisanebarcode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
     <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript"language="javascript">
     //
        var HKEY_Root, HKEY_Path, HKEY_Key;
        HKEY_Root = "HKEY_CURRENT_USER";
        HKEY_Path = "\\Software\\Microsoft\\Internet Explorer\\PageSetup\\";
        //设置网页打印的页眉页脚为空 
        function PageSetup_Null() {
            try {
                var Wsh = new ActiveXObject("WScript.Shell");
                HKEY_Key = "header";
                Wsh.RegWrite(HKEY_Root + HKEY_Path + HKEY_Key, "");
                HKEY_Key = "footer";
                Wsh.RegWrite(HKEY_Root + HKEY_Path + HKEY_Key, "");
            }
            catch (e)
               { }

           }
           function preview() {
             bdhtml = window.document.body.innerHTML;
               sprnstr = "<!--startprint-->";
               eprnstr = "<!--endprint-->";

               prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
               prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
              // window.document.body.innerHTML = prnhtml;//预览功能
               window.print();
           }
           //

           function goback() {

               var url = "DrugGlobalInfo.aspx";

               window.location.href = url;

           }

           function printok() {
              
               var id = $("#idnum123").val();
             

               $.ajax({ type: "POST",
                   url: "printmode.aspx/printokbyid",
                   data: "{'id':\"" + id + "\"}",
                   contentType: "application/json; charset=utf-8",
                   success: function (data) {
                       if (data.d == 1) {
                           alert('打印确认成功');

                           //window.location.href = "PspVerify.aspx";
                           //window.history(-1);


                       } else {
                           alert('打印确认未成功');
                       }
                   }
               });
           }





       </script>
 <style type="text/css" media=print>
    
.noprint{visibility:hidden} 
</style>      
</head>
<body>
<form id="form1" runat="server">



 
 <!--startprint--> 
<div id="print2" style="display:none;  Width:100%;" runat="server" >
<input id ="idnum123" runat="server" type="hidden" name="FunName"/> 

 <div><ul style ="list-style:none;text-align:left;margin:0; padding:0;">
   
  <li><label style ="font-size:10px;">煎药条码</label></li>
     <li><asp:Image ID="Image1" runat="server" Width="270" Height="36"/> 
     </li>



      <li><asp:Label ID="barcode" runat="server" style ="font-size:10px;"></asp:Label></li>
</ul>
   </div> 


<div style="width:250px; height:14px;">
<div id ="div16" runat="server" style="display:none;float:left; width:75px" ><asp:Label id="namebar" runat="server" Text=""  style ="font-size:10px;"/></div>
<div id ="div17" runat="server" style="display:none;float:left; width:15px" > <asp:Label id="sexbar" runat="server" Text="" style ="font-size:10px;"/></div>
<div id ="div18" runat="server" style="display:none;float:left; width:15px"> <asp:Label id="agebar" runat="server" Text="" style ="font-size:10px;"/></div>
<div id ="div19" runat="server" style="display:none;float:left; width:40px"> <asp:Label id="roomnumbar" runat="server" Text="" style ="font-size:10px;"/></div>
</div>




<div style="width:250px; height:12px; ">
<div id ="div1" runat="server" style="display:none;position:absolute;left :10px;width:120px" ><label style ="font-size:10px;">来源:&nbsp;</label><asp:Label id="hospitalnamebar" runat="server" style ="font-size:10px;"/></div>
<div id ="div14" runat="server" style="display:none;position:absolute;left :150px;width:80px" ><asp:Label id="takemethodbar" runat="server" style ="font-size:15px;"/></div>
</div>


<div runat="server" style=" width:250px; height:12px;">

<div id ="div2" runat="server" style="display:none;float:left;width:150px;height:12px"><label style ="font-size:10px;">处方号:&nbsp;</label><asp:Label id="pspnumbar" runat="server" style ="font-size:10px;"/></div>

<div id ="div3" runat="server" style="display:none;float:left;width:80px;"><label style ="font-size:10px;">煎药方案:&nbsp;</label><asp:Label id="strSchemebar" runat="server" style ="font-size:10px;"/></div>


<div id ="div7" runat="server" style="display:none;float:left;width:60px;"><label style ="font-size:10px;">贴数:&nbsp;</label><asp:Label id="dosebar" runat="server" style ="font-size:10px;"/></div>

<div id ="div8" runat="server" style="display:none;float:left;width:60px;"><label style ="font-size:10px;">次数:&nbsp;</label><asp:Label id="nNumbar" runat="server" style ="font-size:10px;"/></div>

<div id ="div9" runat="server" style="display:none; float:left;width:80px;"><label style ="font-size:10px;">包装量:&nbsp;</label><asp:Label id="nPackageNumbar" runat="server" style ="font-size:10px;"/></div>


<div id ="div4" runat="server" style="display:none;float:left;width:80px;"><label style ="font-size:10px;">病区号:&nbsp;</label><asp:Label id="strInpatientAreaNumbar" runat="server" style ="font-size:10px;"/></div>

<div id ="div5" runat="server" style="display:none;float:left;width:80px; "><label style ="font-size:10px;">病房号:&nbsp;</label><asp:Label id="strWardbar" runat="server" style ="font-size:10px;"/></div>

<div id ="div6" runat="server" style="display:none;float:left;width:80px; "><label style ="font-size:10px;">科室:&nbsp;</label><asp:Label id="strDepartmentbar" runat="server" style ="font-size:10px;"/></div>





<div id ="div12" runat="server" style="display:none;float:left;width:80px;"><label style ="font-size:10px;">取药号:&nbsp;</label><asp:Label id="strDrugGetNumbar" runat="server" style ="font-size:10px;"/></div>

<div id ="div13" runat="server" style="display:none; float:left;width:100px;"><label style ="font-size:10px;">煎药方式:&nbsp;</label><asp:Label id="decmothedbar" runat="server" style ="font-size:10px;"/></div>


<div id ="div15" runat="server" style="display:none;float:left;width:100px;"><label style ="font-size:10px;">服用方法:&nbsp;</label><asp:Label id="takewaybar" runat="server" style ="font-size:10px;"/></div>


<div id ="div10" runat="server" style="display:none;float:left;width:175px; "><label style ="font-size:10px;">取药时间:&nbsp;</label><asp:Label id="strDrugGetTimebar" runat="server" style ="font-size:10px;"/></div>
<div id ="div11" runat="server" style="display:none; float:left;width:175px;"><label style ="font-size:10px;">下单时间:&nbsp;</label><asp:Label id="ordertimebar" runat="server" style ="font-size:10px;"/></div>


</div>

</div>
 
     


  <!--endprint--> 
  
<div  style="float:left;margin-left:30px;" class="noprint">

 <p class="noprint">
<input name="" type="button" class="btn" value="打印"  onclick="preview()"   rel="external nofollow" target="_self" />
<input name="" type="button" class="btn" value="确认已打印"  onclick="printok()"/>
<input name="" type="button" class="btn" value="返回上一页"  onclick="goback()"/>
 </p> 

</div>
    </form>
</body>
</html>
