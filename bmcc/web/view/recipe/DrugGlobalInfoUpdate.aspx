<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DrugGlobalInfoUpdate.aspx.cs" Inherits="view_recipe_DrugGlobalInfoUpdate" %>

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

        function btnRecipeOkClick() {
            var id = $("#idnum").val();
            var bubbleperson = $("#bubbleperson").val();
          
          

            $.ajax({ type: "POST",
                url: "DrugGlobalInfoUpdate.aspx/updateGlobalInfo",
                data: "{'id':'" + id + "','bubbleperson':'" + bubbleperson + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    //alert('fdsafdsfdasfdasfdasf');
                    // alert(data.d)
                    if (data.d == "0") {
                        alert('修改失败，可能原因该处方号还未添加');

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
    
    <div class="formtitle"><span>泡药信息</span></div>
   <%-- <div style="overflow:scroll; width:570px; height:430px;">--%>
    <input id ="idnum" runat="server" type="hidden" name="FunName"/> 
    <ul class="forminfo">
    
    <li><label>泡药人员</label>
         <input id="bubbleperson" runat="server" name="" type="text" class="dfinput2"/></li>
    <li><label>&nbsp;</label><input id="update" runat="server" name="" type="button" class="btn" onclick="btnRecipeOkClick();" value="更新" />&nbsp;&nbsp;&nbsp;&nbsp;<input name="" type="button" class="btn" value="取消"/></li>
    </ul>
     </div>
    </form>
</body>
</html>
