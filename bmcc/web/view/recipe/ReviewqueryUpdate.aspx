<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReviewqueryUpdate.aspx.cs" Inherits="view_recipe_ReviewqueryUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>复核查询编辑</title>
     
    <script language="javascript" type="text/javascript">
        function hospitalSelectChange(select) {
            var id = $(select).val();
            $("#recipeSelect option").remove();
            //  alert(id);
            if (id != 0) {
                $.ajax({ type: "POST",
                    url: "RecipeGet.aspx/getNumByHospitalId",
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
            var AuditPer = $("#AuditPer").val();
            var AuditTime = $("#AuditTime").val();
            var hospitalSelect = $("#hospitalSelect").val();
            var pspnum = $("#pspnum").val();
          
            $.ajax({ type: "POST",
                url: "ReviewqueryUpdate.aspx/updateRecipeInfo",
                data: "{'id':'" + id + "','AuditPer':'" + AuditPer + "','AuditTime':'" + AuditTime + "','hospitalSelect':'" + hospitalSelect + "','pspnum':'" + pspnum + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "0") {
                        alert('修改失败，可能该处方号不存在，或该处方号已被分配');

                    } else {
                        alert('修改成功');
                    }
                    var p = [];
                    dotNetFlexGrid3.applyQueryReload(p);
                }
            });
        }
    </script>
   </head>
<body>
  
     <form id="form1" runat="server">
   <div class="formbody">
    
    <div class="formtitle"><span>复核查询</span></div>
    <input id ="idnum" runat="server" type="hidden" name="FunName"/> 
    <ul class="forminfo">

         <li><label>复核时间</label>
       
         <input id="AuditTime"  runat="server" name="" type="text" class="dfinput2" onfocus="calendar.show({ id: this });" readonly="readonly"/></li>
         <li><label>医院</label><select id="hospitalSelect" runat="server" class="dfinput2" name="hostpital" onChange="" style="text-align:center">
          <option value="" selected>&nbsp;&nbsp;全部&nbsp;&nbsp;</option>
         
        
        </select></li>

    <li><label>处方号</label><input id="pspnum" runat="server" name="" type="text" class="dfinput2"/></li>

    <li><label>&nbsp;</label><input id="update" runat="server" name="" type="button" class="btn" onclick="btnRecipeOkClick();" value="更新" /></li>
    </ul>
     </div>
    </form>
</body>
</html>
