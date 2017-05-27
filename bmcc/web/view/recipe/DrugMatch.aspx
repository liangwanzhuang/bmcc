<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DrugMatch.aspx.cs" Inherits="view_recipe_DrugMatch" %>

<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript">

        var hospital = 0;
        function hospitalSelectChange(select) {
            hospital = $(select).val();
        }

        function findBtn() {
            var recipeNum = $("#recipeNum");
            var hospitalSelect = $("#hospitalSelect");

            var p = [
                        { name: "hospitalId", value: "" + hospitalSelect.val() + "" },
                        { name: "pspnum", value: "" + recipeNum.val() + "" }                 
                     ];
            FlexGridRecipe.applyQueryReload(p);

        }

        
        var drugpspnum = "0";
        var hospitalId = "0";
        var FlexGridRecipe_selectId = "0";
        DotNetFlexiGrid_onChecked = function (e) {
            //  alert("onUnChecked" + e);
            FlexGridRecipe_selectId = e;
            var array = FlexGridRecipe.getCellDatas(e);

            //传递给Grid2一个查询选项数组并让其刷新
            drugpspnum = array[4];
            hospitalId = array[37];
            
            var pDrug = [{ name: "pid", value: "" + array[0] + ""}];
            // var pDrug = [{ name: "drugpspnum", value: "" + drugpspnum + "" }, { name: "hospitalId", value: "" + hospitalId + ""}];
            FlexGridDrug.applyQueryReload(pDrug);

        };
        var drugId = 0;
        DotNetFlexiGridDrug_onChecked = function (e) {

            drugId = e;
            var array = FlexGridDrug.getCellDatas(e);
            //    $('#Pspnum').val(array[4]);
            //$("#delnum").val(array[1]);
            $("#hnum").val(array[1]);
            $("#hname").val(array[2]);
            $("#pspnum").val(array[3]);
            $("#Drugnum").val(array[4]);
            $("#Drugname").val(array[5]);
         //   $("#DrugDescription").val(array[6]);
            $("#DrugPosition").val(array[7]);
            $("#DrugAllNum").val(array[8]);
            $("#DrugWeight").val(array[9]);
            $("#footnote").val(array[6]);
            
        };
      
        function ypcDrugInfoDivHide() {
            $("#ypcDrugInfoDiv").hide();
        }
        function ypcDrugInfoDivShow() {
            $("#ypcDrugInfoDiv").show();
        }
        var size = 0;
        $(function () {
            ypcDrugInfoDivHide();
            $("#ypcInfo").keyup(function () {
                //  alert($(this).val());
                var value = $(this).val();
                if (size != value.length) {
                    size = value.length;
                    $.ajax({ type: "POST",
                        url: "DrugMatch.aspx/serchYpcDrugInfo",
                        data: "{'text':'" + value + "'}",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            var result = data.d;
                            if (result.length == 0) {
                               // alert('没有查询到该信息');
                            } else {
                                var row = result.split("[;]");
                                var ypcDrugInfoDiv = $("#ypcDrugInfoDiv");
                                ypcDrugInfoDiv.empty();
                                for (i = 0; i < row.length; i++) {
                                   // var col = row[i].split("[,]");
                                    ypcDrugInfoDiv.append('<div class="dfinput2 cursor" onclick="ypcDrugInfoClick(\'' + row[i] + '\');">' + row[i] + '</div>');
                                }

                                ypcDrugInfoDivShow();

                            }
                        }
                    });
                }

            });

        });

        function ypcDrugInfoClick(data) {
            var col = data.split("&");
            $('#ypcDrugNum').val(col[0]);
            $('#ypcDrugName').val(col[1]);

            $('#positionNum').val(col[3]);
            $('#drugOrigin').val(col[2]);
            ypcDrugInfoDivHide();

        }
       
        function matc() {
            var pspnum = $('#pspnum').val();
            var ypcDrugNum = $('#ypcDrugNum').val();
            if (pspnum.length == 0) {
                alert("请选择药品信息");
                return false;
            }
            if (ypcDrugNum.length == 0) {
                alert("请选择饮片厂药品信息");
                return false;
            }
            var data = "{'hospitalId':'" + hospitalId
                    + "','hospitalName':'" + $("#hname").val()
                    + "','hdrugNum':'" + $("#Drugnum").val()
                    + "','ypcdrugNum':'" + $("#ypcDrugNum").val()
                    + "','hdrugName':'" + $("#Drugname").val()
                    + "','ypcdrugName':'" + $("#ypcDrugName").val() 
                    + "','hdrugOriginAddress':'"+""
                    + "','ypcdrugOriginAddress':'" + $("#drugOrigin").val()
                    + "','hdrugSpecs':'" + ""
                    + "','ypcdrugSpecs':'" + $("#drugSpec").val()
                    + "','hdrugTotal':'" + $("#DrugAllNum").val()
                    + "','ypcdrugTotal':'" + ""
                    + "','pspNum':'" + $("#pspnum").val()
                    + "','ypcdrugPositionNum':'" + $("#positionNum").val()
                    + "','pspId':'" + FlexGridRecipe_selectId
                    + "','drugId':'" + drugId + "'}";
            $.ajax({ type: "POST",
                url: "DrugMatch.aspx/insertDrugMatching",
                data: data,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var result = data.d;
                    if (result != 0) {
                        alert("操作成功");
                        var pDrug = [{ name: "drugpspnum", value: "" + drugpspnum + "" }, { name: "hospitalId", value: "" + hospitalId + ""}];
                        FlexGridDrug.applyQueryReload(pDrug);
                        findBtn();
                        clear();


                    }
                }
            });
        }

        function clear() {
            $('#ypcDrugNum').val("");
            $('#ypcDrugName').val("");

            $('#drugSpec').val("");
            $('#positionNum').val("");
            $('#drugOrigin').val("");

            $("#hnum").val("");
            $("#hname").val("");
            $("#pspnum").val("");
            $("#Drugnum").val("");
            $("#Drugname").val("");
         //   $("#DrugDescription").val("");
            $("#DrugPosition").val("");
            $("#DrugAllNum").val("");
            $("#DrugWeight").val("");
            $("#footnote").val("");
        }
    </script>

    <style type="text/css">
        .cursor 
        {
            cursor:pointer;   
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   
    <div class="rightinfo">

        <div class="tools">
    
    	<ul class="toolbar">
        <li class="click" onclick="findBtn();"><span><img src="../../img/t01.png" /></span>查询</li>
        </ul>     
       
    </div>
    <ul class="forminfo">
    <li><label>医院名称</label>
        <select id="hospitalSelect" runat="server" class="dfinput" name="hostpital" onchange="hospitalSelectChange(this);" style="text-align:center">
          <option value="0" selected>&nbsp;&nbsp;-----请选择-----&nbsp;&nbsp;</option>
          
        </select>
        &nbsp;&nbsp;处方号&nbsp;&nbsp;
        <input id="recipeNum" runat="server"  name="patient" type="text" class="dfinput" />
    </li>


   </ul>

   <div style="width:1000px; ">
        <div style="width:45%; float:left">
            <uc1:dotNetFlexGrid ID="FlexGridRecipe" runat="server" 
            EventOnCheckedFunc="DotNetFlexiGrid_onChecked" />
        </div>
        <div style="width:10%; float:left">
           &nbsp;&nbsp;&nbsp;&nbsp;
        </div>
        <div style="width:45%; float:left">
             <uc1:dotNetFlexGrid ID="FlexGridDrug" runat="server" 
             EventOnCheckedFunc="DotNetFlexiGridDrug_onChecked"/>
        </div>
    </div>
     <table>
            <tr><td>
    <div style="width:1000px; ">
        <div style="width:45%; float:left">
            <div class="formtitle"><span>医院药品信息</span></div>
     
            <ul class="forminfo">
            <li><label>处方编号</label><input id="pspnum" name="" type="text" class="dfinput2" /><i></i></li>
            <li><label>医院编号</label><input id="hnum" name="" type="text" class="dfinput2" /><i></i></li>
            <li><label>医院名称</label><input id="hname" name="" type="text" class="dfinput2" /><i></i></li>
            <li><label>药品编号</label><input id="Drugnum" name="" type="text" class="dfinput2" /><i></i></li>
            <li><label>药品名称</label><input id="Drugname" name="" type="text" class="dfinput2" /><i></i></li>
            
            <li><label>药品规格</label><input id="DrugPosition" name="" type="text" class="dfinput2" /><i></i></li>
            <li><label>单剂量</label><input id="DrugAllNum" name="" type="text" class="dfinput2" /><i></i></li>
            <li><label>总剂量</label><input id="DrugWeight" name="" type="text" class="dfinput2" /><i></i></li>
            <li><label>脚注</label><input id="footnote" name="" type="text" class="dfinput2" /><i></i></li>

            </ul>
        </div>
        <div style="width:10%; float:left">
           &nbsp;&nbsp;&nbsp;&nbsp;
        </div>
      
        <div style="width:45%; float:left"> 
            
           <div class="formtitle"><span>饮片厂医院药品信息</span></div>

            <ul class="forminfo">
            <li style="position:relative;">
                <label>匹配信息</label>
                <input id="ypcInfo" name="" type="text" class="dfinput2" />
                <div id="ypcDrugInfoDiv" style="top:34px;left:70px; position:absolute; overflow-y:auto;overflow-x:hidden;height:320px;width:202px; ">

                </div>
            <i>
            </i></li>
            <li><label>药品编号</label><input id="ypcDrugNum" name="" type="text" class="dfinput2" /><i></i></li>
            <li><label>药品名称</label><input id="ypcDrugName" name="" type="text" class="dfinput2" /><i></i></li>
 
             <li><label>药品产地</label><input id="drugOrigin" name="" type="text" class="dfinput2" /><i></i></li>
            <li><label>药品货位号</label><input id="positionNum" name="" type="text" class="dfinput2" /><i></i></li>
             
          
            
            </ul>
           </div>

    </div>
        <div class="tools"></div>
    
    	<ul class="toolbar">
        <li class="click" onclick="matc();"><span><img src="../../img/t01.png" /></span>匹配</li>
        </ul>  
           
          </td></tr></table> 
    </form>
</body>
</html>