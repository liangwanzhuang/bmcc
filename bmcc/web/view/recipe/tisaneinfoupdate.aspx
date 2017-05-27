<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tisaneinfoupdate.aspx.cs" Inherits="view_recipe_tisaneinfoupdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>处方编辑</title>
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

        function btnTisaneOkClick() {

            var tisaneid = $("#idnum").val();
            var tisaneman = $("#tisaneperson").val();
            var machinename = $("#machinename").val();
            var tisanestatus = $("#tisanestatus").val();
            alert('fdsfdsf' + tisaneid);
            alert('fdsfdsf' + tisaneman);
            alert('fdsfdsf' + machinename);
            alert('fdsfdsf' + tisanestatus);

            $.ajax({ type: "POST",
                url: "tisaneinfoupdate.aspx/tisaneinfoupdate",
                data: "{'id':'" + tisaneid + "','tisaneman':'" + tisaneman + "','machinename':'" + machinename + "','tisanestatus':'" + tisanestatus + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    //alert('fdsafdsfdasfdasfdasf');
                    // alert(data.d)
                    if (data.d == "0") {
                        alert('你没做任何修改');

                    } else {
                        alert('修改成功');
                    }
                    var p = [];
                    FlexGridDrugGlobal1.applyQueryReload(p);
                }
            });
        }
    </script>



   </head>
<body>
    <form id="form1" runat="server">
    <div class="formbody">
    
    <div class="formtitle"><span>煎药信息</span></div>
   <%--<div style="overflow:scroll; width:570px; height:430px;"> --%>
    
    <ul class="forminfo">
    
           <li><label>煎药单号</label>
           <input id="idnum" runat="server" name="" type="text" class="dfinput2"/></li>



          <li><label>煎药人员</label>
          <input id="tisaneperson" runat="server" name="" type="text" class="dfinput2"/></li>

          <li><label>机组号</label>
          <select id="machinename" runat="server" class="dfinput2" name="hostpital" onChange="" style="text-align:center">
          <option value="" selected>&nbsp;&nbsp;全部&nbsp;&nbsp;</option>
          </select></li>


    <li><label>煎药状态</label><select id="tisanestatus" runat="server" name="" type="text" class="dfinput2" style="text-align:center" onchange="hospitalSelectChange(this);" >
   <option value="0" selected>&nbsp;&nbsp;全部&nbsp;&nbsp;</option>
  </select></li>
    <li><label>&nbsp;</label><input id="update" runat="server" name="" type="button" class="btn" onclick="btnTisaneOkClick();" value="更新" /></li>
    </ul>
     </div>
    </form>
</body>
</html>
