<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecipeGet.aspx.cs" Inherits="view_recipe_RecipeGet" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>处方录入</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/time.js"></script>

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
                        var datas = data.d.split(";");

                        $("#hospitalnum").val(datas[0]);
                        $("#delnum").val(datas[1]);
                        
                    }
                });
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


        var FlexGridRecipe_selectId = "0";
        FlexGridRecipe_onChecked = function (rowId) {
            var id = FlexGridRecipe.getSelectedRowsIds()[0];
            pid = id;
            

            if (id) {
                var array = FlexGridRecipe.getCellDatas(id);
                pspnum = array[5];
                Hospitalid = array[4];
                if (array) {
                    $("#drughospitalnum").val(array[1]);
                    $("#drughospitalname").val(array[2]);
                    $("#drugdelnum").val(array[3]);
                    $("#drugpspnum").val(array[5]);
                }
            }
            FlexGridRecipe_selectId = rowId;
            var array = FlexGridRecipe.getCellDatas(rowId);
            var p = [{ name: "pid", value: "" + array[0] + ""}];

            FlexGridDrug.applyQueryReload(p);
        };


        var pid = "0";
        var pspnum = "0";
        var Hospitalid = "0";
        DotNetFlexiGrid_onunChecked = function (rowId) {
            var id = FlexGridRecipe.getSelectedRowsIds()[0];
            pspnum = "0";
            pid = "0";
            Hospitalid = "0";
            $("#drughospitalnum").val("");
            $("#drughospitalname").val("");
            $("#drugdelnum").val("");
            $("#drugpspnum").val("");


            FlexGridRecipe_selectId = rowId;
            var array = FlexGridRecipe.getCellDatas(0);
            var a = "0";
            //$('#Pspnum').val(array[4]);
            //传递给Grid2一个查询选项数组并让其刷新
            var p = [{ name: "pid", value: "" + a + ""}];
            //var p = [{ name: "drugpspnum", value: "" + array[5] + "" }, { name: "Hospitalid", value: "" + array[4] + ""}];
            FlexGridDrug.applyQueryReload(p);
        };
        function CheckInputIntFloat(oInput) {
            if ('' != oInput.value.replace(/\d{1,}\.{0,1}\d{0,}/, '')) {
                oInput.value = oInput.value.match(/\d{1,}\.{0,1}\d{0,}/) == null ? '' : oInput.value.match(/\d{1,}\.{0,1}\d{0,}/);
            }
        }

        function doReset() {
           
            $(".dfinput9").val("1");
           
            for (i = 0; i < document.all.tags("input").length; i++) {

                if (document.all.tags("input")[i].type == "text") {
                    if (document.all.tags("input")[i].id == "drughospitalnum" || document.all.tags("input")[i].id == "drughospitalname" || document.all.tags("input")[i].id == "doperson" || document.all.tags("input")[i].id == "drugpspnum" || document.all.tags("input")[i].id == "delnum" || document.all.tags("input")[i].id == "hospitalnum") {

                    } else {
                      
                        document.all.tags("input")[i].value = "";
                    }

                }

            }
            alert("置空成功！");
        }
        function doReset12() {

            for (i = 0; i < document.all.tags("input").length; i++) {

                if (document.all.tags("input")[i].type == "text") {
                    if (document.all.tags("input")[i].id == "drughospitalnum" || document.all.tags("input")[i].id == "drughospitalname" || document.all.tags("input")[i].id == "doperson" || document.all.tags("input")[i].id == "drugpspnum" || document.all.tags("input")[i].id == "delnum" || document.all.tags("input")[i].id == "hospitalnum") {

                    } else {
                        document.all.tags("input")[i].value = "";
                    }

                }

            }
            alert("置空成功！");
        }
        var pspnum = "0";
        var Hospitalid = "0";
        function confirmDrug() {
    
            if (pid != 0) {
                /**/
                $.ajax({ type: "POST",
                    url: "RecipeGet.aspx/confirmDrug",
                    data: "{'pid':'" + pid + "','pspnum':'" + pspnum + "','Hospitalid':'" + Hospitalid + "'}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        alert(data.d);
                    }
                });

            } else {
                alert("请选择一个处方");
            }
        }
        function submitDrugInfo() {
            if (pid != 0) {
                var drugpspnum = $("#drugpspnum").val();
                var drugnum = $("#drugnum").val();
                var drugname = $("#drugname").val();
                var drugposition = $("#drugposition").val();

                var drugweight = $("#drugweight").val();
                var drugallnum = $("#drugallnum").val();
                var tienum = $("#tienum").val();
                var strTip = "";
                if (drugpspnum.length == 0)
                {
                    strTip += "处方号；";
                }
                if (drugnum.length == 0)
                {
                    strTip += "药品编号；";
                }
                if (drugname.length == 0)
                {
                    strTip += "药品名称；";
                }
                if (drugposition.length == 0)
                {
                    strTip += "药品规格；";
                }
                if (drugallnum.length == 0)
                {
                    strTip += "单剂量；";
                }
                if (drugweight.length == 0)
                {
                    strTip += "总剂量；";

                }
                if (tienum.length == 0)
                {
                    strTip += "贴数；";
                }

                if (strTip.length > 0)
                {
                    strTip = "以下信息不能空，请填写: " + strTip;
                    alert(strTip);
                
                    return;
                }
                
                var description = $("#description").val();
                var wholesaleprice = $("#wholesaleprice").val();
                var retailprice = $("#retailprice").val();
                var drugdescription = $("#drugdescription").val();
                if (description.length == 0) {
                    description = "";
                }
                if (wholesaleprice.length == 0) {
                    wholesaleprice = "";
                }
                if (retailprice.length == 0) {
                    retailprice = "";
                }
                if (drugdescription.length == 0) {
                    drugdescription = "";
                }
                var strdata = "{'hospitalid':'" + Hospitalid + "','drugpspnum':'" + drugpspnum + "','drugnum':'" + drugnum + "'"
                + ",'drugname':'" + drugname + "','drugdescription':'" + drugdescription + "','drugposition':'" + drugposition + "'"
                + ",'drugallnum':'" + drugallnum + "','drugweight':'" + drugweight + "','tienum':'" + tienum + "','description':'"+ description +"'"
                + ",'wholesaleprice':'" + wholesaleprice + "','retailprice':'" + retailprice + "','pid':'" + pid + "'}";
                $.ajax({ type: "POST",
                    url: "RecipeGet.aspx/submitDrugInfo",
                    data: strdata,
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        alert(data.d);
                        var p = [{ name: "pid", value: "" + pid + ""}];
                        FlexGridDrug.applyQueryReload(p);
                    }
                });

            } else {
                alert("请选择一个处方");
            }

        }
     </script>
</head>
<body >
    <form id="form1" runat="server">

    
    <div class="formbody">
    
    <div class="formtitle"><span>录入电子处方</span> <input id="doperson" runat="server" name="" type="text" class="dfinput5" style="border-style:none" readonly="readonly" onclick="return doperson_onclick()" /><label>&nbsp;&nbsp;操作人员:</label></div>
    
    <ul class="forminfo">
      
   <li><label><strong style ="color:Red">*</strong>医院名称</label><select id="hospitalname" runat="server" name="sect" type="text" class="dfinput2" style="text-align:center" onchange="hospitalSelectChange(this);" readonly="readonly" ></select>
   <label>&nbsp;&nbsp;<strong style ="color:Red">*</strong>医院编号</label><input id="hospitalnum" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"  readonly="readonly" />
   <label><strong style ="color:Red">*</strong>委托单号</label><input id="delnum" runat="server" name="" type="text" class="dfinput2"  readonly="readonly" /><i></i>
   <label>&nbsp;&nbsp;<strong style ="color:Red">*</strong>处方号</label><input id="pspnum" runat="server"  name="" type="text" class="dfinput2"  onkeypress="javascript:if(event.keyCode == 32)event.returnValue = false;" onkeyup="this.value=this.value.replace(/[, ]/g,'')"/></li>

    <li><label>患者姓名</label><input id="name" runat="server" name="" type="text" class="dfinput2" />
   <label>&nbsp;&nbsp;煎药方式</label>
        <select id="decmothed" runat="server" class="dfinput9" name="decmothed" onChange="" style="text-align:center">

        </select>
   
   <label>年龄</label><input id="age" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/>
    <label>&nbsp;&nbsp;性别</label>
        <select id="sex" runat="server" class="dfinput9" name="hostpital" onChange="" style="text-align:center">
        </select>
    </li>

    <li><label>地址</label><input id="address" runat="server" name="" type="text" class="dfinput2" />
    <label>&nbsp;&nbsp;手机号</label><input id="phone" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^((13[0-9]{9})|(159[0-9]{8}))$]/ig,'')"/>
    <label>病区号</label><input id="inpatientnum" runat="server" name="" type="text" class="dfinput2" />
   <label>&nbsp;&nbsp;科室</label><input id="department" runat="server" name="" type="text" class="dfinput2" /></li>

    <li><label>病床号</label><input id="sickbed" runat="server" name="" type="text" class="dfinput2" />
  <label>&nbsp;&nbsp; 病房号</label><input id="wardnum"  name="" runat="server" type="text" class="dfinput2" />
   <label><strong style ="color:Red">*</strong>贴数</label><input id="dose" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/>
   <label>&nbsp;&nbsp;诊断结果</label><input id="diagresult" runat="server" name="" type="text" class="dfinput2" /></li>


    <li><label>服用方式</label><input id="takemethod" runat="server" name="" type="text" class="dfinput2" />
   <label>&nbsp;&nbsp;<strong style ="color:Red">*</strong>次数</label><input name="num" id="num" runat="server" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/>  
   <label>服用方法</label><select id="takeway" runat="server" name="" type="text" class="dfinput9"  style="text-align:center"> </select>
   <label>&nbsp;&nbsp;<strong style ="color:Red">*</strong>包装量</label><input id="packquantity" name="" runat="server" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/></li>


    <li><label>浸泡加水量</label><input id="soakwater" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/>
 <label>&nbsp;&nbsp; <strong style ="color:Red">*</strong>煎药方案</label>
        <select id="scheme" runat="server" class="dfinput9" name="scheme" onchange="schemeSelectChange(this);" style="text-align:center">
        </select>
   

   <label>时间段一</label><input id="timeone" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"  readonly/><label>&nbsp;&nbsp;时间段二</label><input id="timetwo" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')" readonly/></li>


    <li><label><strong style ="color:Red">*</strong>浸泡时间</label><input id="soaktime" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/><label>&nbsp;&nbsp;标签数量</label><input id="labelnum" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/>
    <label>备注信息</label><input id="remark" runat="server" name="" type="text" class="dfinput2" /><label>&nbsp;&nbsp;医生</label><input id="doctor" runat="server" name="" type="text" class="dfinput2" /></li>
    <li><label>医生脚注</label><input id="footnote" runat="server" name="" type="text" class="dfinput2" /><label>&nbsp;&nbsp;<strong style ="color:Red">*</strong>取药时间</label><input id="druggettime" runat="server" name="" type="text" class="dfinput2"  onfocus="SetDate(this,'yyyy-MM-dd hh:00:00')" readonly="readonly"/>


   <label>取药号</label><input id="druggetnum" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/><label>&nbsp;&nbsp;下单时间</label><input id="ordertime" runat="server" name="" type="text" class="dfinput2"  onfocus="SetDate(this,'yyyy-MM-dd hh:mm:ss')" readonly="readonly"/>

    
   <li> <label>配送公司</label><input id="dtbcompany" runat="server" name="" type="text" class="dfinput2" /><label>&nbsp;&nbsp;配送地址</label><input id="dtbaddress" runat="server" name="" type="text" class="dfinput2" />


    <label>联系电话</label><input id="dtbphone" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(^((13[0-9]{9})|(159[0-9]{8}))$,'')"/><label>&nbsp;&nbsp;快递类型</label><select id="dtbtype" runat="server" name="" type="text" class="dfinput9" style="text-align:center"> </select></li>
    <li><label>备注A</label><input id="RemarksA" runat="server" name="" type="text" class="dfinput2" />


    <label>备注B</label><input id="RemarksB" runat="server" name="" type="text" class="dfinput2" /></li>
   <li> <label>&nbsp;</label><input id="ok" runat="server" name="" type="button" class="btn" value="确认" onserverclick="btnRecipeOkClick" />&nbsp;&nbsp;&nbsp;&nbsp;<input name="" type="button" onclick="excelimport();" class="btn"   value="批量导入"/></li> 

    </ul>
 
    </div>
    
   
    <uc1:dotNetFlexGrid ID="FlexGridRecipe" runat="server"  EventOnCheckedFunc="FlexGridRecipe_onChecked"  
        EventOnUnCheckedFunc="DotNetFlexiGrid_onunChecked"       
      />

    <div class="formbody">
    
    <div class="formtitle"><span>录入药品</span></div>
    
    <ul class="forminfo">

   

    <li><label><strong style ="color:Red">*</strong>医院名称</label><input id="drughospitalname" runat="server" name="" type="text" class="dfinput2" readonly="readonly"/><i></i><label>&nbsp;&nbsp;<strong style ="color:Red">*</strong>医院编号</label><input id="drughospitalnum" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')" readonly="readonly"/></li>
    <%-- <li> <label><strong style ="color:Red">*</strong>委托单号</label><input id="drugdelnum" runat="Server" name="" type="text" class="dfinput2" readonly="readonly" />--%>
    <li><label><strong style ="color:Red">*</strong>处方号</label><input id = "drugpspnum" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/> <label>&nbsp;&nbsp;<strong style ="color:Red">*</strong>药品编号</label><input id ="drugnum" runat="Server" name="" type="text" class="dfinput2"  onkeypress="javascript:if(event.keyCode == 32)event.returnValue = false;" onkeyup="this.value=this.value.replace(/[, ]/g,'')"/></li>
   
    <li><label><strong style ="color:Red">*</strong>药品名称</label><input id="drugname" runat="Server" name="" type="text" class="dfinput2" onkeypress="javascript:if(event.keyCode == 32)event.returnValue = false;"/><label>&nbsp;&nbsp;&nbsp;&nbsp;脚&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注</label><input id ="drugdescription" runat="Server" name="" type="text" class="dfinput2" /><i></i></li>
    
    <li><label><strong style ="color:Red">*</strong>药品规格</label><input id ="drugposition" runat="Server" name="" type="text" class="dfinput2"  onkeypress="javascript:if(event.keyCode == 32)event.returnValue = false;" onkeyup="this.value=this.value.replace(/[, ]/g,'')"/><label>&nbsp;&nbsp;<strong style ="color:Red">*</strong>单剂量</label><input id="drugallnum" runat="Server" name="" type="text" class="dfinput2"  onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/></li>
    <li><label><strong style ="color:Red">*</strong>总剂量</label><input id="drugweight" runat="Server" name="" type="text" class="dfinput2" onkeyup="javascript:CheckInputIntFloat(this);"/><label>&nbsp;&nbsp;<strong style ="color:Red">*</strong>贴&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数</label><input id="tienum" runat="Server" name="" type="text" class="dfinput2"  onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/></li>
    <li><label>说&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;明</label><input id="description" runat="Server" name="" type="text" class="dfinput3" /><i></i></li>
    <li><label>批发价格</label><input id="wholesaleprice" runat="Server" name="" type="text" class="dfinput2" onkeyup="javascript:CheckInputIntFloat(this);"/><label>&nbsp;&nbsp;零售价格</label><input id="retailprice"  runat="Server" name="" type="text" class="dfinput2" onkeyup="javascript:CheckInputIntFloat(this);"/></li>

    <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" type="button" class="btn" value="确认" onclick="submitDrugInfo();"/>&nbsp;&nbsp;&nbsp;&nbsp;<input name="" type="button" onclick="drugexcelimport();" class="btn"   value="批量导入"/>&nbsp;&nbsp;&nbsp;&nbsp;<input name="" type="button" onclick="confirmDrug();" class="btn"   value="确认药品录入完成"/></li> 
    </ul>
    <br />
    
      <uc1:dotNetFlexGrid ID="FlexGridDrug" runat="server"       
      />
    
    </div>

     <div id='pop_div' class="pop_box">
            <div class="p_head">
                <div class="p_h_title">
                    <span><asp:Label id="flowtitle" runat="server"/></span>
                </div>
                <div class="p_h_x" onclick="closeDiv();" title="关闭">关闭</div>
            </div>
            <div class="p_box_body" id="p_b_body"></div>
   </div>



         <%--加载顺序要放到表格控件的后边--%>
    <link href="../../Css/ShowWin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery.divbox.js"> </script>
    <script type="text/javascript" src="../../Scripts/jquery.easydrag.handler.beta2.js"></script>
    <script type="text/javascript" src="../../js/DatePicker.js"></script> 
    <script language="javascript" type="text/javascript">

        var refurbishFlag = 0;
        function excelimport() {
            refurbishFlag = 1;

            var url = "excelimport.aspx";
            $("#flowtitle").text("处方导入信息");
            $("#p_b_body").load(url);

            $("#pop_div").OpenDiv();
        }
        function closeDiv() {
            $("#pop_div").CloseDiv();
            window.location.reload();
        }
        $(function () {
            $(".pop_box").easydrag(); //拖动
            $(".pop_box").setHandler(".pop_box .p_head");
        });



        function drugexcelimport() {
            refurbishFlag = 2;
            
           var url = "excelimportdrug.aspx";
            $("#flowtitle").text("药品导入信息");
            $("#p_b_body").load(url);

            $("#pop_div").OpenDiv();
        }
        function closeDiv() {
            if (refurbishFlag == 1) {
                FlexGridRecipe.applyQueryReload([]);
            } else if (refurbishFlag == 2) {
                if (FlexGridRecipe_selectId != 0) {
                    var array = FlexGridRecipe.getCellDatas(FlexGridRecipe_selectId);
                    var p = [{ name: "pid", value: "" + array[0] + ""}];
                    FlexGridDrug.applyQueryReload(p);
                }
            }
            $("#pop_div").CloseDiv();
        }
        $(function () {
            $(".pop_box").easydrag(); //拖动
            $(".pop_box").setHandler(".pop_box .p_head");
        });

    </script>


    </form>
</body>
</html>
