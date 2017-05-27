﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MedicineLossiInforGet.aspx.cs" Inherits="view_storeroom_MedicineLossiInforGet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
<link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        /*  function WarehouseSelectChange(select) {
        var id = $(select).val();
        $("#recipeSelect option").remove();
        // alert(id);
        if (id != "") {
        // alert('fdsfs');
        $.ajax({ type: "POST",
        url: "LossiInforGet.aspx/getNumByWarehouse",
        data: "{'Warehouse':'" + id + "'}",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
        var datas = data.d.split(";");
        //alert('fdsfs');
        $("#WarehouseNum").val(datas[0]);
        // $("#DeugName").val(datas[1]);
        }
        });
        }
        }*/
        /*  function DeugNameSelectChange(select) {
        var id = $(select).val();
        $("#recipeSelect option").remove();
        //alert(id);
        if (id != "") {
        // alert('fdsfs');
        $.ajax({ type: "POST",
        url: "LossiInforGet.aspx/getNumByDeugName",
        data: "{'DeugName':'" + id + "'}",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
        var datas = data.d.split(";");
        // alert('fdsfs');
        $("#DrugCode").val(datas[0]);
                        
        }
        });
        }
        }*/

        function drugnameDivHide() {
            $("#drugnameDiv").hide();
        }
        function drugnameDivShow() {
            $("#drugnameDiv").show();
        }
        function fuzzySearch() {


            if ($("#DrugName").val().length == 0 || $("#DrugName").val().length > 10) {
                drugnameDivHide();
                return;
            }
            var fromid = $("#fromid").val();
            $.ajax({ type: "POST",
                url: "medicalOutbounddataadd.aspx/serchDrugInfo",
                data: "{'text':'" + $("#DrugName").val() + "','fromid':'" + fromid + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    var result = data.d;

                    if (result.length == 0) {
                        drugnameDivHide();
                        return;
                    }
                    drugnameDivShow();

                    var row = result.split(",");
                    // var drugnameDiv = $("#drugnameDiv");

                    //drugnameDiv.empty();
                    var contents = "";
                    for (i = 0; i < row.length - 1; i++) {

                        //drugnameDiv.append('<div class="dfinput2 cursor" onclick="ypcDrugInfoClick(\'' + row[i] + '\');">' + row[i] + '</div>');
                        contents = contents + "<li onclick='ypcDrugInfoClick(\"" + row[i] + "\");' class='suggest_li" + (i + 1) + "'>" + row[i] + "</li>";

                    }

                    $("#drugnameDiv").html(contents);
                }
            });

        }


        $(function () {

            //按下按键后300毫秒显示下拉提示 
            $("#DrugName").keyup(function () {
                setInterval(changehover, 300);
                function changehover() {
                    $("#drugnameDiv li").hover(function () { $(this).css("background", "#eee"); }, function () { $(this).css("background", "#fff"); });
                }
            });

        });



        function ypcDrugInfoClick(dataname) {
            var fromid = $("#fromid").val();
            $("#DrugName").val(dataname);
            $.ajax({ type: "POST",
                url: "medicalOutbounddataadd.aspx/getproductbatch",
                data: "{'dataname':'" + dataname + "','fromid':'" + fromid + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    var datas = data.d.split(",");

                    document.getElementById("drugnum").innerHTML = "";
                    document.getElementById("drugnum").options[document.getElementById("drugnum").length] = new Option("请选择", "0")
                    for (var i = 0; i < datas.length - 1; i++) {

                        document.getElementById("drugnum").options[document.getElementById("drugnum").length] = new Option(datas[i], datas[i]);
                    }

                    //alert(datas[3]);

                    drugnameDivHide();

                }
            });


        }









        function hospitalSelect(select) {
            var id = $(select).val();
            $("#recipeSelect option").remove();

            var fromid = $("#fromid").val();
            if (id != 0) {
                $.ajax({ type: "POST",
                    url: "medicalOutbounddataadd.aspx/getdruginfobydrugnum",
                    data: "{'drugnum':'" + id + "','fromid':'" + fromid + "'}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        //alert('fdsfs');
                        var datas = data.d.split(",");
                        //alert(datas[3]);

                        $("#DrugCode1").val(datas[1]);
                        $("#DrugName").val(datas[3]);
                        $("#DrugType1").val(datas[0]);
                        $("#DrugSpecificat1").val(datas[4]);
                        $("#PositionNum1").val(datas[5]);
                        $("#PurUnits1").val(datas[2]);
                        $("#Univalent1").val(datas[6]);
                        $("#Mnemonic1").val(datas[7]);
                        $("#Producer1").val(datas[9]);

                        $("#ProducingArea1").val(datas[10]);
                        $("#UpperLimit1").val(datas[12]);
                        $("#LowerLimit1").val(datas[13]);
                        $("#Rmarkes1").val(datas[8]);
                        $("#Rmarkes21").val(datas[14]);
                        $("#Rmarkes31").val(datas[15]);



                        $("#num").val(datas[16]);



                    }
                });
            }
        }






        function btnok_onclick() {

            var fromid = $("#fromid").val();
            var drugnum = $("#drugnum").val();
            var Rmarkes = $("#Rmarkes").val();

            var losstype = $("#Type1").val();
            var Per = $("#Per").val();
            var Reason = $("#Reason").val();
            var lossnum = $("#lossnum").val();

            if (fromid == "") {
                alert("请先选择房间！");
                return false;

            } else if (drugnum == "") {
                alert("请先选择药品批次！");
                return false;

            } else if (Per == "") {
                alert("请输入人员！");
                return false;

            }
            else if (Reason == "") {
                alert("请输入原因！");
                return false;
            } else if (lossnum == "") {
                alert("请输入报损数量！");
                return false;
            }

            $.ajax({ type: "POST",
                url: "MedicineLossiInforGet.aspx/MedicineLossiInforGet",
                data: "{'fromid':'" + fromid + "','drugnum':'" + drugnum + "','losstype':'" + losstype + "','Per':'" + Per + "','Reason':'" + Reason + "','Rmarkes':'" + Rmarkes + "','lossnum':'" + lossnum + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "0") {
                        alert('添加失败');
                    } else {
                        alert('添加成功');
                    }
                    var p = [];
                    FlexGridMedicineLossiInfor.applyQueryReload(p);
                }
            });

            return true;
        }

    </script>

      <style> 
    #drugnameDiv
    {
        border-left:1px solid #a7b5bc;
        border-top:1px solid #a7b5bc;
        border-right:1px solid #a7b5bc;
    }
    #drugnameDiv li 
    {
        margin:0px;
        border-bottom:1px solid #a7b5bc;
        padding-left:5px; 
        height:30px; 
        line-height:30px; 
        font-size:14px; 
        width:195px; 
        cursor:default; 
    } 
</style> 


</head>
<body>
    <form id="form1" runat="server">
   <div style="overflow:scroll; width:570px; height:430px;">
    


     <ul class="forminfo">
     <div class="formtitle"><span>药品基本信息</span></div>
     <input id="rnum" runat="server" name="" type="hidden" class="dfinput2" />

      <li><label>仓库</label><select id="fromid" runat="server" name=""  class="dfinput" onchange="fromSelectChange(this);">
     <option value="0" selected>请选择</option>
    </select></li>

    
    <li><label>药品名称</label><input id="DrugName" runat="server" name="" type="text" class="dfinput2"   autocomplete="off" value="search..." oninput="fuzzySearch();" onblur="if(this.value==''){this.value='search...'}" onfocus="if(this.value=='search...'){this.value=''}"/>
    <ul id="drugnameDiv" style="top:180px;left:80px; position:absolute; background:white " list-style-type:none;> </ul> 
    <label>药品批次</label><select id="drugnum" runat="server" name=""  class="dfinput2" onchange="hospitalSelect(this);">
     <option value="0" selected>请选择</option>
    </select></li>
   <li> <label>药品编号</label><input id="DrugCode1" runat="server" name="" type="text" class="dfinput2" readonly="readonly"/>

     <label>药品种类</label> <select id="DrugType1" runat="Server" class="dfinput2" readonly="readonly">
            <option value="西药">西药</option>

            <option value="中药">中药</option>
            <option value="藏药">藏药</option>
            <option value="其他">其他</option>
            
        </select></li>

    <li><label>药品规格</label><input id="DrugSpecificat1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/>
   <label>货位号</label><input id ="PositionNum1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/></li>

   <li> <label>基本单位</label><input id="PurUnits1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/>
     <label>单&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;价</label><input id ="Univalent1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/></li>

     <li><label>助记符</label><input id ="Mnemonic1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/>
     <label>生产商</label><input id ="Producer1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/></li>


     <li><label>产&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;地</label><input id ="ProducingArea1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/>
     <label>上&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;限</label><input id ="UpperLimit1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/></li>

    <li> <label>下&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;限</label><input id ="LowerLimit1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/>
   <label>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注1</label><input id ="Rmarkes1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/></li>

     <li><label>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注2</label><input id ="Rmarkes21" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/>
    <label>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注3</label><input id ="Rmarkes31" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/></li>
    <li><label>&nbsp;&nbsp;</label></li>
    </ul>
    
   
     
   <ul class="forminfo">
     <div class="formtitle"><span>报损基本信息</span></div>
    
         <li><label>信息类别</label>
        <select class="dfinput2" id="Type1" runat="server" name="hostpitalname" onChange="" style="text-align:center">
        <option value="药房报损">药房报损单</option>    
        <option value="药房报溢">药房报溢单</option>
         </select>
         <label>人&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;员</label><input id="Per" runat="server" name="" type="text" class="dfinput2" />
         </li>

    <li><label>原&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;因</label><input id="Reason" runat="server" name="" type="text" class="dfinput2" />
    <label>数&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;量</label><input id="lossnum" runat="server" name="" type="text" class="dfinput2" />

    </li>
   <li> <label>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注</label><input id ="Rmarkes" runat="Server" name="" type="text" class="dfinput" /></li>
  <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" type="button" class="btn" value="确认" onclick=" btnok_onclick();"/></li>
    </ul>
   </div>
  </form>
</body>
</html>