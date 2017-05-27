<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Backgdsetwarningupdate.aspx.cs" Inherits="view_system_Backgdsetwarningupdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <script language="javascript" type="text/javascript">

      function hospitalSelectChange(select) {
          var id = $(select).val();
          $("#recipeSelect option").remove();
          //  alert(id);
          if (id != 0) {
              $.ajax({ type: "POST",
                  url: "RecipeGet.aspx/updateGlobalInfoById",
                  data: "{'hospitalId':" + id + "}",
                  contentType: "application/json; charset=utf-8",
                  success: function (data) {
                      $("#hospitalnum").val(data.d);
                  }
              });
          }
      }

      function CheckInputIntFloat(oInput) {
          if ('' != oInput.value.replace(/\d{1,}\.{0,1}\d{0,}/, '')) {
              oInput.value = oInput.value.match(/\d{1,}\.{0,1}\d{0,}/) == null ? '' : oInput.value.match(/\d{1,}\.{0,1}\d{0,}/);
          }
      }

      function btnUpdateOkClick() {

         
          var id = $("#idnum").val();
          var checkwarning = $("#checkwarning").val();
          var adjustwarning = $("#adjustwarning").val();
          var recheckwarning = $("#recheckwarning").val();
          var bubblewarning = $("#bubblewarning").val();
          var tisanewarning = $("#tisanewarning").val();
          var packwarning = $("#packwarning").val();
          var deliverwarning = $("#deliverwarning").val();
         

         



          $.ajax({ type: "POST",
              url: "Backgdsetwarningupdate.aspx/updatewarninginfoByid",
              data: "{'id':'" + id + "','checkwarning':'" + checkwarning + "','adjustwarning':'" + adjustwarning + "','recheckwarning':'" + recheckwarning + "','bubblewarning':'" + bubblewarning + "','tisanewarning':'" + tisanewarning + "','packwarning':'" + packwarning + "','deliverwarning':'" + deliverwarning + "'}",
              contentType: "application/json; charset=utf-8",
              success: function (data) {
                  //alert('fdsafdsfdasfdasfdasf');
                  // alert(data.d)
                  if (data.d == 0) {
                      alert('修改失败');

                  } else {
                      alert('修改成功');
                  }
                  var p = [];
                  FlexGrid1.applyQueryReload(p);
                  DotNetFlexGrid1.applyQueryReload(p);
              }
          });
      }
      
function update_onclick() {
   
}

function update_onclick() {

}

    </script>



   </head>
<body>
    <form id="form1" runat="server">
    <div style="overflow:scroll; width:570px; height:430px;">
    <input id ="idnum" runat="server" type="hidden" name="FunName"/> 
     <div class="formtitle"><span>医院预警时间修改</span></div>
    
   <ul class="forminfo">
    <li  runat="server" id="checkwarning_li"><label>审核预警时间(min)</label><input id="checkwarning" runat="server" name="" type="text" class="dfinput"/></li>
    <li><label>调剂预警时间(min)</label><input id = "adjustwarning" runat="Server" name="" type="text" class="dfinput" /></li>
    <li><label>复核预警时间(min)</label><input id ="recheckwarning" runat="Server" name="" type="text" class="dfinput" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')" /></li>
    <li><label>泡药预警时间(min)</label><input id = "bubblewarning" runat="Server" name="" type="text" class="dfinput" /></li>
    <li><label>煎药预警时间(min)</label><input id ="tisanewarning" runat="Server" name="" type="text" class="dfinput" /></li>
    <li><label>包装预警时间(min)</label><input id ="packwarning" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
    <li><label>发货预警时间(min)</label><input id ="deliverwarning" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
    <li><label>&nbsp;</label><input id="update" runat="server" name="" type="button" class="btn" onclick="btnUpdateOkClick();" value="更改" /></li> 
    </ul>
    
     </div>
    </form>
</body>
</html>
