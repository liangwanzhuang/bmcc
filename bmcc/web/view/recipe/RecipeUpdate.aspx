<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecipeUpdate.aspx.cs" Inherits="view_recipe_RecipeUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>处方编辑</title>
        
<meta http-equiv="Expires" content="0"/> 
<meta http-equiv="Cache-Control" content="no-cache"/> 
<meta http-equiv="Pragma" content="no-cache"/> 





    <script language="javascript" type="text/javascript">

        function gettextvalue(data) {
            // alert('niaho....');
            var strRows1Id = data.split(';');
         
            $("#hospitalnum").val(strRows1Id[0]);
            $("#delnum").val(strRows1Id[1]);

        }

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
                        gettextvalue(data.d)
                       
                    }
                });
            }
        }

        function CheckInputIntFloat(oInput) {
            if ('' != oInput.value.replace(/\d{1,}\.{0,1}\d{0,}/, '')) {
                oInput.value = oInput.value.match(/\d{1,}\.{0,1}\d{0,}/) == null ? '' : oInput.value.match(/\d{1,}\.{0,1}\d{0,}/);
            }
        }
        function schemeSelectChange(select) {
          
            var id = $(select).val();
            var timeone = document.getElementById("timeone");
            var timetwo = document.getElementById("timetwo");

            if (id == 13) {

                timeone.readOnly = false;
                timetwo.readOnly = true;

            }
            else if (id == 14 || id == 15 || id == 16) {
                timeone.readOnly = false;
                timetwo.readOnly = false;
            } else {

                timeone.readOnly = true;
                timetwo.readOnly = true;
            }
        } 


        function btnUpdateOkClick() {
            var id = $("#idnum").val();
            $.ajax({ type: "POST",
                url: "RecipeUpdate.aspx/updateRecipeInfo",
                data: "{'id':'" + id + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    //alert('fdsafdsfdasfdasfdasf');
                    // alert(data.d)
                    if (data.d == "0") {
                        alert('修改失败，已审核过的处方信息和药品信息不能被修改');

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
        
    <div style="overflow:scroll; width:570px; height:430px;">
    <input id ="idnum" runat="server" type="hidden" name="FunName"/> 
    <ul class="forminfo">
    <div class="formtitle"><span>处方信息</span><br /><br />
    <li><label>医院名称</label><select id="hospitalname" runat="server" name="" type="text" class="dfinput" style="text-align:center" onchange="hospitalSelectChange(this);" ></select><i></i></li>
    <li><label>医院编号</label><input id="hospitalnum" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"  readonly="readonly"/><label>委托单号</label><input id="delnum" runat="server" name="" type="text" class="dfinput2"  readonly="readonly"/></li>
    <li><label>电子处方号</label><input id="pspnum" runat="server"  name="" type="text" class="dfinput2" /><label>煎药方式</label>
        <select id="decmothed" runat="server" class="dfinput2" name="decmothed" onChange="" style="text-align:center">

        </select>
    </li>
    <li><label>姓名</label><input id="name" runat="server" name="" type="text" class="dfinput2" /><label>性别</label>
        <select id="sex" runat="server" class="dfinput2" name="hostpital" onChange="" style="text-align:center">
 <%--         <option value="" selected>&nbsp;&nbsp;-----请选择-----&nbsp;&nbsp;</option>
          <option value="">男</option>
          <option value="">女</option>--%>
        </select>
    </li>
    <li><label>年龄</label><input id="age" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/><label>手机号</label><input id="phone" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/></li>
    <li><label>地址</label><input id="address" runat="server" name="" type="text" class="dfinput2" /><label>科室</label><input id="department" runat="server" name="" type="text" class="dfinput2" /></li>
    <li><label>病区号</label><input id="inpatientnum" runat="server" name="" type="text" class="dfinput2" /><label>病房号</label><input id="wardnum"  name="" runat="server" type="text" class="dfinput2" /></li>
    <li><label>病床号</label><input id="sickbed" runat="server" name="" type="text" class="dfinput2" /><label>诊断结果</label><input id="diagresult" runat="server" name="" type="text" class="dfinput2" /></li>
    <li><label>剂量</label><input id="dose" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/><label>次数</label><input name="num" id="num" runat="server" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/></li>   
    <li><label>服用方式</label><input id="takemethod" runat="server" name="" type="text" class="dfinput2" /><label>包装量</label><input id="packquantity" name="" runat="server" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/></li>
    <li><label>服用方法</label><select id="takeway" runat="server" name="" type="text" class="dfinput2"  style="text-align:center"> </select>
    <label>煎药方案</label>
        <select id="scheme" runat="server" class="dfinput2" name="scheme" onchange="schemeSelectChange(this);" style="text-align:center">
        </select>
    </li>

    <li><label>时间段一</label><input id="timeone" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/><label>时间段二</label><input id="timetwo" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/></li>
    <li><label>浸泡加水量</label><input id="soakwater" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/><label>浸泡时间</label><input id="soaktime" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/></li>
    <li><label>标签数量</label><input id="labelnum" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/><label>备注信息</label><input id="remark" runat="server" name="" type="text" class="dfinput2" /></li>
    <li><label>医生</label><input id="doctor" runat="server" name="" type="text" class="dfinput2" /><label>医生脚注</label><input id="footnote" runat="server" name="" type="text" class="dfinput2" /></li>
    <li><label>取药时间</label><input id="druggettime" runat="server" name="" type="text" class="dfinput2" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" readonly="readonly" /><label>取药号</label><input id="druggetnum" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/></li>
    <li><label>下单时间</label><input id="ordertime" runat="server" name="" type="text" class="dfinput" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" readonly="readonly"/></li>
    <li><label>配送公司</label><input id="dtbcompany" runat="server" name="" type="text" class="dfinput2" /><label>配送地址</label><input id="dtbaddress" runat="server" name="" type="text" class="dfinput2" /></li>
    <li><label>联系电话</label><input id="dtbphone" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/><label>快递类型</label><select id="dtbtype" runat="server" name="" type="text" class="dfinput2" style="text-align:center"> </select></li>
    <li><label>备注A</label><input id="RemarksA" runat="server" name="" type="text" class="dfinput" /></li>
    <li><label>备注B</label><input id="RemarksB" runat="server" name="" type="text" class="dfinput" /></li>
<li><label>&nbsp;</label><asp:Button ID="update" runat="Server" class="btn" Text="更新" onclick="btnUpdate_Click"/></li> 
  <%-- <li><label>&nbsp;</label><input id="update" runat="server" name="" type="button" class="btn" onclick="btnUpdateOkClick();" value="更新" />&nbsp;&nbsp;&nbsp;&nbsp;<input name="" type="button" class="btn" value="取消"/></li>--%>
     </div>
    </ul>
    </div>
    
    </form>
</body>
</html>
