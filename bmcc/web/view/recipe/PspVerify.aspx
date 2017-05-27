<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PspVerify.aspx.cs" Inherits="view_recipe_PspVerify" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery.js"></script>

    <style type="text/css">
        .label{vertical-align:middle;}
    </style>
    <script type="text/javascript">
        var hospital = 0;
        function hospitalSelectChange(select) {
            hospital = $(select).val();
        /*    var id = $(select).val();
            $("#recipeSelect option").remove();
          //  alert(id);
            if (id != 0) {
                $.ajax({ type: "POST",
                    url: "PspVerify.aspx/getRecipeByHospitalId",
                    data: "{'hospitalId':" + id + "}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        $("#recipeSelect").prepend("<option value='0'>&nbsp;&nbsp;-----请选择-----&nbsp;&nbsp;</option>"); //为Select插入一个Option(第一个位置)
                        setRecipeSelect(data.d);
                    }
                });
            }*/
        }
        function setRecipeSelect(str) {
            if (str.length > 0) {
                var recipeSelect = $("#recipeSelect");
                var data = str.split(';');
                for (i = 0; i < data.length; i++) {
                    var recipe = data[i].split(",");
                    recipeSelect.append("<option value=" + recipe[0] + ">" + recipe[1] + "</option>");
                }

            }

        }


        var hospitalIdParam = "0";
        var pspnumParam = "";
        var patientParam = "";
        function findBtn() {
            var recipeNum = $("#recipeNum");
            var hospitalSelect = $("#hospitalSelect");
            var patient = $("#patient");
          //  if (hospitalSelect.val() == 0) {
         //       alert('请选择客户');
         //       return;
          //  }

          //  window.location = "PspVerify.aspx?findRrescription=true&hospitalId=" + hospitalSelect.val() + "&recipeNum=" + recipeSelect.find("option:selected").text();

            var p = [
                    { name: "hospitalId", value: "" + hospitalSelect.val() + "" },
                    { name: "pspnum", value: "" + recipeNum.val() + "" },
                    { name: "patient", value: "" + patient.val() + "" }
                ];

            hospitalIdParam = hospitalSelect.val();
            pspnumParam = recipeNum.val();
            patientParam = patient.val();

            findParam = p;
            FlexGridRecipe.applyQueryReload(p);

        }
        countstatistics();
        function countstatistics() {
            $.ajax({ type: "POST",
                url: "DrugGlobalInfo.aspx/countstatistics",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    // alert(data.d);
                    // $("#count").val(data.d);
                    //var a = $("#count").val();
                    // alert(a);
                    // $("#count").val() = data.d;
                    // count.text = a;

                    document.getElementById("count").innerHTML = data.d;
                }
            });
        }
        setInterval("countstatistics()", 15000);

        var FlexGridRecipe_selectId = "0";
        DotNetFlexiGrid_onChecked = function (e) {


            // alert("onUnChecked" + e);
            FlexGridRecipe_selectId = e;
            var array = FlexGridRecipe.getCellDatas(e);


            //  $('#Pspnum').val(array[4]);
            //传递给Grid2一个查询选项数组并让其刷新
            // var p = [{ name: "drugpspnum", value: "" + array[4] + "" }, { name: "hospitalId", value: "" + array[37] + ""}];

            var p = [{ name: "pid", value: "" + array[0] + ""}];

            FlexGridDrug.applyQueryReload(p);

            $.ajax({ type: "POST",
                url: "PspVerify.aspx/defaultcheck",
                data: "{'id':'" + FlexGridRecipe_selectId + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "0") {
                       
                    } else {
                       
                        $("input[name='check']").eq(0).removeAttr("checked");
                        $("input[name='check']").eq(1).attr("checked", "checked");
                        $("#reasonText").val(data.d);
                        $("#reason").show();
                    }
                }
            });



            //alert(array[4]);
            //   document.getElementById('select_checked').click();
        };


        DotNetFlexiGrid_onunChecked = function (e) {

            FlexGridRecipe_selectId = 0;
            var array = FlexGridRecipe.getCellDatas(0);
            $('#Pspnum').val(array[4]);
            //传递给Grid2一个查询选项数组并让其刷新
            //  var p = [{ name: "drugpspnum", value: "" + array[4] + "" }, { name: "hospitalId", value: "" + array[37] + ""}];
            var a = "0";
            var p = [{ name: "pid", value: "" + a + ""}];
            FlexGridDrug.applyQueryReload(p);

            //   document.getElementById('select_checked').click();
        };

        var marqueeContent
        var item_i = 0;
        var timer;

        function getpcwarning() {

            $.ajax({ type: "POST",
                url: "PspVerify.aspx/getpcwarning",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    //alert('煎药id'+data.d);
                    showWarning(data.d);
                }
            });
        }

        $(function () {
            getpcwarning();
            setInterval(function () {
                // var warningstr = $("#warning").val(); 
                getpcwarning();
            }, 1000 * 60);
        })


      
        function showWarning(warningstr) {
            window.clearInterval(timer);
             item_i = 0;
            marqueeContent = new Array();   //滚动主题
            //  var warningstr = $("#warning").val();
            if (warningstr.length > 0) {
                var lastStr = warningstr.substring(warningstr.length - 1, warningstr.length);
                if (lastStr == ",") {
                    warningstr = warningstr.substring(0, warningstr.length - 1);
                }
            }
            var strzero = "0000000000";

            var strRows1Id = warningstr.split(',');



            if (strRows1Id.length == 0 || strRows1Id == "") {
                marqueeContent[0] = "预警提示：暂无预警";
            } else {

                for (i = 0; i < strRows1Id.length; i++) {
                    marqueeContent[i] = "预警提示：煎药单号为" + strzero.substring(0, 10 - strRows1Id[i].length) + strRows1Id[i] + "" + "已过审核预警时间";

                }
            }


            $("#warning_span").html('<div class="warning_div" style="display:none;">' + marqueeContent[item_i] + '</div>');
            $(".warning_div").slideDown("slow");

            if (parseInt(item_i) >= marqueeContent.length - 1) {
                item_i = 0;
            } else {
                item_i++
            }



            timer = setInterval(function () {
              

                $("#warning_span").html('<div class="warning_div" style="display:none;">' + marqueeContent[item_i] + '</div>');
                $(".warning_div").slideDown("slow");

                if (parseInt(item_i) >= marqueeContent.length - 1) {
                    item_i = 0;
                } else {
                    item_i++
                }
            }, 15000);

        }




        var recipeCheckValue = '1';
        function recipeCheckSelect(obj) {
            recipeCheckValue = obj.value;
            if (recipeCheckValue == '2') {
                $("#reason").show();
            } else {
                $("#reason").hide();
            }
        }
        function recipeCheck() {
           
            var reasonText = $("#reasonText").val();
            var name = $("#name").val();
            var employid = $("#employid").val();
           
            if (recipeCheckValue == '2') {
                if (reasonText.length == 0) {
                    alert("请输入不通过原因");
                    return;
                } else if (reasonText.length > 99) {
                    alert("不通过原因的字数不能大于100个字符");
                    return;
                }
            }
            if (FlexGridRecipe_selectId == '0') {
                alert("请选择一个处方");
            } else {
                //FlexGridRecipe.deleteRows(FlexGridRecipe.getSelectedRowsIds());
            $.ajax({ type: "POST",
                url: "PspVerify.aspx/recipeCheck",
                data: "{'recipeCheckValue':'" + recipeCheckValue + "','reasonText':'" + reasonText + "','id':'" + FlexGridRecipe_selectId + "','name':'" + name + "','emid':'" + employid + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    if (data.d == 9) {
                        alert('还有药品未匹配完');
                        window.location.reload();
                    } else if (data.d != 0) {

                        if (data.d == 7) {
                            alert('操作成功');
                            var url = "printmode.aspx?id=" + FlexGridRecipe_selectId;

                            window.location.href = url;
                            // window.location.reload();
                        }

                        if (data.d == 8) {
                            alert('操作成功');
                            FlexGridRecipe.deleteRows(FlexGridRecipe.getSelectedRowsIds());
                            var p = [
                                { name: "hospitalId", value: "" + hospitalIdParam + "" },
                                { name: "pspnum", value: "" + pspnumParam + "" },
                                { name: "patient", value: "" + patientParam + "" }
                            ];
                            

                            FlexGridRecipe.applyQueryReload(p);
                            var pDrug = [{ name: "pid", value: "0"}];
                            FlexGridDrug.applyQueryReload(pDrug);
                            // window.location.reload();
                        }

                        //    FlexGridRecipe.deleteRows(FlexGridRecipe.getSelectedRowsIds());
                        //  var p = [{ name: "pid", value: "0"}];
                        //   FlexGridDrug.applyQueryReload(p);
                        //   FlexGridRecipe_selectId = '0';
                        //    window.location.reload();


                    } else {

                        alert('操作失败');
                        window.location.reload();
                    }
                }
            });
            }
            
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    
    <%--<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">处方管理</a></li>
    <li><a href="#">配方管理</a></li>
    <li><a href="#">处方审核</a></li>
    </ul>
    </div>--%> 
    
    <div class="rightinfo">
    
        <li><span style = "color : red"><label id="count" runat="server"/></span></li><br />
         <input id ="warning" runat="server" type="hidden" name="FunName"/>
         <input id ="name" runat="server" type="hidden" name="name"/>
           <input id ="employid" runat="server" type="hidden" name="name"/>
       <span id="warning_span" style ="color : red;height:20px;"></span>
        <br/>
        <div class="tools">
    
    	<ul class="toolbar">

        <li class="click" onclick="findBtn();"><span><img src="../../img/t01.png" /></span>查询</li>
        </ul>     
        </div>
    </div>
    <ul class="forminfo">
    <li><label>医院名称</label>
 
        <select id="hospitalSelect" class="dfinput" name="hostpital" onchange="hospitalSelectChange(this);"  style="text-align:center" runat="server" >
          <option value="0">&nbsp;&nbsp;-----请选择-----&nbsp;&nbsp;</option>
        
        </select>

        &nbsp;&nbsp;患者姓名&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="patient" runat="server"  name="patient" type="text" class="dfinput" />
       <!-- <select class="dfinput" name="patient" onChange="" style="text-align:center">
          <option value="" selected>&nbsp;&nbsp;-----请选择-----&nbsp;&nbsp;</option>
          <option value="">患者一</option>
          <option value="">患者二</option>
          <option value="">患者三</option>
          <option value="">患者四</option>
          <option value="">患者五</option>
        </select>-->
    </li>
    <li><label>处方号</label>
        <input id="recipeNum" runat="server"  name="patient" type="text" class="dfinput" />
       <!-- <select id="recipeSelect" class="dfinput" name="getperson" onChange="" style="text-align:center" runat="server" >
          <option value="0" selected>&nbsp;&nbsp;-----请选择-----&nbsp;&nbsp;</option>
          
        </select>-->
    </li>

   </ul>
         <uc1:dotNetFlexGrid ID="FlexGridRecipe" runat="server" 
            EventOnCheckedFunc="DotNetFlexiGrid_onChecked" 
            EventOnUnCheckedFunc="DotNetFlexiGrid_onunChecked"
         />
         <br/>
         <br/>
         <uc1:dotNetFlexGrid ID="FlexGridDrug" runat="server" 
         />
    <div>
        <div style="width:10%;">

           &nbsp;&nbsp;&nbsp;&nbsp;

                      &nbsp;&nbsp;&nbsp;&nbsp;
        </div>

        
        <ul class="toolbar" style="margin-left:10px;">
            <li>
                &nbsp;&nbsp;
                <label class="label"><input class="label"  id="radio1" name="check" type="radio" checked="checked" value="1" onclick="recipeCheckSelect(this);" style="margin-bottom:3px;"/>通过</label> 
                
            </li>
            <li>
                &nbsp;&nbsp;
                <label class="label"><input class="label" id="radio2"  name="check" type="radio" value="2" onclick="recipeCheckSelect(this);" style="margin-bottom:3px;"/>不通过</label> 
            </li>
            <li id="reason" style="padding-right:0px;padding-left:10px;display:none;">
               不通过原因：<input id="reasonText" runat="server"  name="" type="text" class="dfinput2" style="float:none;"/>
            </li>
            <li class="click" onclick="recipeCheck();" style="padding-left:10px;">审核</li>
            
        </ul> 
        


        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>

    </div>
    </form>
</body>
</html>
