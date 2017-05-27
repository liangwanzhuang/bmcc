<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pdaImgSettingEdit.aspx.cs" Inherits="view_system_pdaImgSettingEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
  <script language="javascript" type="text/javascript">

      function btnUpdateOkClick() {


          var id = $("#idnum").val();
          var tiaoji = $("#tiaoji").val();
          var fuhe = $("#fuhe").val();
          var paoyao = $("#paoyao").val();
          var jianyao = $("#jianyao").val();
          var baozhuang = $("#baozhuang").val();
          var fahuo = $("#fahuo").val();

          $.ajax({ type: "POST",
              url: "pdaImgSettingEdit.aspx/editPdaImgSwitch",
              data: "{'id':'" + id + "','tiaoji':'" + tiaoji + "','fuhe':'" + fuhe + "','paoyao':'" + paoyao + "','jianyao':'" + jianyao + "','baozhuang':'" + baozhuang + "','fahuo':'" + fahuo + "'}",
              contentType: "application/json; charset=utf-8",
              success: function (data) {
                  //alert('fdsafdsfdasfdasfdasf');
                  // alert(data.d)
                  alert(data.d);
                  var p = [];
                  FlexGrid1.applyQueryReload(p);
              }
          });
      }


    </script>



   </head>
<body>
    <form id="form1" runat="server">
    <div style="overflow:scroll; width:570px; height:430px;">
    <input id ="idnum" runat="server" type="hidden" name="FunName"/> 
     <div class="formtitle"><span>拍照开关编辑</span></div>
    
   <ul class="forminfo">

    <li><label>调剂</label>
        <select id="tiaoji" class="dfinput" name="hostpital" style="text-align:center" runat="server" >
            <option value="0">关闭</option>
            <option value="1">开启</option>
        </select>
    </li>
    <li><label>复核</label>
        <select id="fuhe" class="dfinput" name="hostpital" style="text-align:center" runat="server" >
            <option value="0">关闭</option>
            <option value="1">开启</option>
        </select>
    </li>
    <li><label>泡药</label>
        <select id="paoyao" class="dfinput" name="hostpital" style="text-align:center" runat="server" >
            <option value="0">关闭</option>
            <option value="1">开启</option>
        </select>
    </li>
    <li><label>煎药</label>
        <select id="jianyao" class="dfinput" name="hostpital" style="text-align:center" runat="server" >
            <option value="0">关闭</option>
            <option value="1">开启</option>
        </select>
    </li>
    <li><label>包装</label>
        <select id="baozhuang" class="dfinput" name="hostpital" style="text-align:center" runat="server" >
            <option value="0">关闭</option>
            <option value="1">开启</option>
        </select>
    </li>
    <li><label>发货</label>
        <select id="fahuo" class="dfinput" name="hostpital" style="text-align:center" runat="server" >
            <option value="0">关闭</option>
            <option value="1">开启</option>
        </select>
    </li>
    <li><label>&nbsp;</label><input id="update" runat="server" name="" type="button" class="btn" onclick="btnUpdateOkClick();" value="更改" /></li> 
    </ul>
    
     </div>
    </form>
</body>
</html>