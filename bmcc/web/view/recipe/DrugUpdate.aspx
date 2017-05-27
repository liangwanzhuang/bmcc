<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DrugUpdate.aspx.cs" Inherits="view_recipe_DrugUpdate" %>

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

        function btnUpdateOkClick() {
            var id = $("#idnum").val();



            $.ajax({ type: "POST",
                url: "RecipeUpdate.aspx/updateRecipeInfo",
                data: "{'id':'" + id + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
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

        function btnok_onclick() {


            var id = $("#idnum").val();
            var drugnum = $("#drugnum").val();
            var drugdescription = $("#drugdescription").val();
            var drugposition = $("#drugposition").val();
            var drugweight = $("#drugweight").val();
            var description = $("#description").val();
            var wholesaleprice = $("#wholesaleprice").val();
            var wholesalecost = $("#wholesalecost").val();
            var moneywithtax = $("#moneywithtax").val();



            var drugname = $("#drugname").val();
            var drugallnum = $("#drugallnum").val();
            var tienum = $("#tienum").val();
            var retailprice = $("#retailprice").val();
            var retailcost = $("#retailcost").val();
            var fee = $("#fee").val();
           

            $.ajax({ type: "POST",
                url: "DrugUpdate.aspx/updateDrugInfo",
                // data: "{'id':'" + id + "','drugnum':'" + drugnum + "','drugdescription':'" + drugdescription + "',' drugposition':'" + drugposition + "',' drugweight':'" + drugweight + "','description':'" + description + "','wholesaleprice':'" + wholesaleprice + "','wholesalecost':'" + wholesalecost + "','moneywithtax':'" + moneywithtax + "','drugname':'" + drugname + "','drugallnum':'" + drugallnum + "','tienum':'" + tienum + "','retailprice':'" + retailprice + "','retailcost':'" + retailcost + "','fee':'" + fee + "'}",
                data: "{'id':'" + id + "','drugnum':'" + drugnum + "','drugdescription':'" + drugdescription + "','drugposition':'" + drugposition + "','drugweight':'" + drugweight + "','description':'" + description + "','wholesaleprice':'" + wholesaleprice + "','wholesalecost':'" + wholesalecost + "','moneywithtax':'" + moneywithtax + "','drugname':'" + drugname + "','drugallnum':'" + drugallnum + "','tienum':'" + tienum + "','retailprice':'" + retailprice + "','retailcost':'" + retailcost + "','fee':'" + fee + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == 1) {
                        alert('修改成功');

                    } else {
                        alert('修改失败，已审核的处方信息和药品信息不能被修改');
                    }
                    var p = [];
                    FlexGridDrug.applyQueryReload(p);
                }
            });







        }

    </script>
   </head>
<body>
       <form id="form1" runat="server">

    <div style="overflow:scroll; width:570px; height:430px;">
    <input id ="idnum" runat="server" type="hidden" name="FunName"/> 
     <ul class="forminfo">
       <div class="formtitle"><span>药品信息</span></div>
    <li><label>药品编号</label><input id ="drugnum" runat="Server" name="" type="text" class="dfinput2" /><label>药品名称</label><input id="drugname" runat="Server" name="" type="text" class="dfinput2" /></li>
    <li><label>脚注</label><input id ="drugdescription" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
    <li><label>药品规格</label><input id ="drugposition" runat="Server" name="" type="text" class="dfinput2" /><label>单剂量</label><input id="drugallnum" runat="Server" name="" type="text" class="dfinput2"  onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/></li>
    <li><label>总剂量</label><input id="drugweight" runat="Server" name="" type="text" class="dfinput2" onkeyup="javascript:CheckInputIntFloat(this);"/><label>贴数</label><input id="tienum" runat="Server" name="" type="text" class="dfinput2"  onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/></li>
    <li><label>说明</label><input id="description" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
    <li><label>批发价格</label><input id="wholesaleprice" runat="Server" name="" type="text" class="dfinput2" onkeyup="javascript:CheckInputIntFloat(this);"/><label>零售价格</label><input id="retailprice"  runat="Server" name="" type="text" class="dfinput2" onkeyup="javascript:CheckInputIntFloat(this);"/></li>
    <!--<li><label>批发费用</label><input id="wholesalecost" runat="Server" name="" type="text" class="dfinput2" onkeyup="javascript:CheckInputIntFloat(this);"/><label>零售费用</label><input id ="retailcost" runat="Server" name="" type="text" class="dfinput2" onkeyup="javascript:CheckInputIntFloat(this);"/></li>
    <li><label>含税金额</label><input id="moneywithtax" runat="Server" name="" type="text" class="dfinput2" onkeyup="javascript:CheckInputIntFloat(this);" /><label>扣率</label><input id="fee" runat="Server" name="" type="text" class="dfinput2" onkeyup="javascript:CheckInputIntFloat(this);" /></li>-->
      <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" type="button" class="btn" value="确认" onclick="btnok_onclick()" />&nbsp;&nbsp;&nbsp;&nbsp;</li>
   
    </ul>
    </div>
   
    </form>
</body>
</html>
