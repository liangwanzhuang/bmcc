<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecipeSearch.aspx.cs" Inherits="view_recipe_RecipeSearch" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">

    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="../../js/time.js"></script>
          <script language="javascript" type="text/javascript" src="../../js/My97DatePicker/WdatePicker.js"></script>
     <script language="javascript" type="text/javascript" src="../../js/My98DatePicker/WdatePicker.js"></script>
     <link href="../../css/hDate.css" rel="stylesheet" />
<script type="text/javascript" src="../../js/jquery.date.js"></script>
<script type="text/javascript" src="../../js/hDate.js"></script>
<script type="text/javascript"language="javascript">
    function searchRecipeInfo() {

        var hospitalName = $("#hospitalname").val();
        var Pspnum = $("#Pspnum").val();
        var time = $("#time").val();
        var patient = $("#patient").val();
        var tisaneid = $("#tisaneid").val();
        var doper = $("#doper").val();
        var JTime = $("#JTime").val();      

        var p = [{ name: "hospitalID", value: hospitalName }, { name: "Pspnum", value: Pspnum }, { name: "time", value: time }, { name: "patient", value: patient }, { name: "tisaneid", value: tisaneid }, { name: "doper", value: doper }, { name: "JTime", value: JTime}];
        FlexGridRecipe.applyQueryReload(p);

    }

    function deleteRecipeInfo() {
        var rows = FlexGridRecipe.getSelectedRowsIds();
        var strRowIDs = "0";//处方
        var strRowIDs2 = "0";//药品

        if (rows.length == 0) {
            alert('请选择要删除的一项');
        } else {
            var rows2 = FlexGridDrug.getSelectedRowsIds();

            if (rows2 > 0) {
                strRowIDs2 = rows2[0];
                for (var i = 1; i < rows2.length; i++) {
                    strRowIDs2 += "," + rows2[i]; // alert(rows[i]);//药品
                }

            } else {
               
                    strRowIDs = rows[0];
                for (var i = 1; i < rows.length; i++) {
                    strRowIDs += "," + rows[i]; // alert(rows[i]);//处方
                }

              
            }
       

        var del = confirm("是否确认删除");
        if (del) {
            $.ajax({ type: "POST",
                url: "RecipeSearch.aspx/deleteRecipeById",
                data: "{'strRowIds':\"" + strRowIDs + "\",'strRowIds2':\"" + strRowIDs2 + "\"}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    if (data.d == 1) {
                        alert('删除成功');
                    } else {
                        alert('删除未成功，只能成功删除未审核的处方信息和药品信息');
                    }
                    var p = [];
                    FlexGridRecipe.applyQueryReload(p);
                    FlexGridDrug.applyQueryReload(p);
                }
            });
        }
        }
    }

    countstatistics();
    function countstatistics() {
        $.ajax({ type: "POST",
            url: "DrugGlobalInfo.aspx/countstatistics",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                document.getElementById("count").innerHTML = data.d;
            }
        });
    }
    setInterval("countstatistics()", 15000);

    //表2信息
    var FlexGridRecipe_selectId = "0";
    DotNetFlexiGrid_onChecked = function (e) {
      
        FlexGridRecipe_selectId = e;
        var array = FlexGridRecipe.getCellDatas(e);

        var p = [{ name: "pid", value: "" + array[0] + "" }];

        FlexGridDrug.applyQueryReload(p);
    };


    DotNetFlexiGrid_onunChecked = function (e) {

        FlexGridRecipe_selectId = 0;
        var array = FlexGridRecipe.getCellDatas(0);
        $('#Pspnum').val(array[4]);
        var a = "0";

        //传递给Grid2一个查询选项数组并让其刷新
        var p = [{ name: "pid", value: "" + a + ""}];
       // var p = [{ name: "drugpspnum", value: "" + array[4] + "" }, { name: "hospitalId", value: "" + array[37] + ""}];
        FlexGridDrug.applyQueryReload(p);

        //   document.getElementById('select_checked').click();
    };



</script>
 <style type="text/css">
.btn3 {
    font-size: 9pt;
    color: #003399;
    border: 1px #003399 solid;
    color: #006699;
    border-bottom: #93bee2 1px solid;
    border-left: #93bee2 1px solid;
    border-right: #93bee2 1px solid;
    border-top: #93bee2 1px solid;
 
    background-color: #F5F7F9;
    cursor: hand;
    font-style: normal;
    width: 80px;
    height: 34px;
    
}</style>
</head>
<body>
 <form id="form1" runat="server">
   
    <div class="rightinfo">
           <li><span style = "color : red"><label id="count" /></span></li><br />
    <div class="tools">
    
    	<ul class="toolbar">
        <li class="click" onclick="searchRecipeInfo();"><span><img src="../../img/t01.png" /></span>查询</li>
        <li class="click" onclick="openDiv();"><span><img src="../../img/t02.png" /></span>编辑</li>
        <li class="click" onclick="deleteRecipeInfo();"><span><img src="../../img/t03.png" /></span>删除</li>
        <input type="Button" ID="Button1"  runat="server" onserverclick="Button1_Click"   value='导出处方数据' class="btn3"/>
        <input type="Button" ID="Button2"  runat="server" onserverclick="Button2_Click"   value='导出药品数据' class="btn3"/>
        
        </ul>         
     
    </div>

    <ul class="forminfo">
    <li><label>医院名称</label>
        <select class="dfinput2" id="hospitalname" runat="server" name="hostpitalname" onChange="" style="text-align:center">

        </select>
       <label>&nbsp;&nbsp;&nbsp;&nbsp;患者姓名</label>
        <input class="dfinput2" id="patient" runat="Server" name="patient"  />

        <label>&nbsp;&nbsp;&nbsp;&nbsp;煎药单号</label>
        <input class="dfinput2" id="tisaneid" runat="Server" name="patient"  />

         <label>&nbsp;&nbsp;&nbsp;&nbsp;接方时间</label>
        <input class="dfinput2" id="JTime" runat="Server" name="patient"  onClick="WdatePicker()" readonly="readonly"/>


    </li>
    <li><label>取药时间</label>
        <input id="time" runat="server" name="" type="text" class="dfinput2" onClick="WdatePicker()" readonly="readonly"/>
    <label>&nbsp;&nbsp;&nbsp;&nbsp;处&nbsp;方&nbsp;号&nbsp;&nbsp;</label><input id="Pspnum" name="" runat="server" type="text" class="dfinput2" /><i></i>
     <label>&nbsp;&nbsp;&nbsp;&nbsp;操作人员</label><input id="doper" name="" type="text" runat="server" class="dfinput2" /><i></i></li>
   </ul>

      <div style="width:1000px; ">
     <uc1:dotNetFlexGrid ID="FlexGridRecipe" runat="server"  EventOnCheckedFunc="DotNetFlexiGrid_onChecked" 
      EventOnUnCheckedFunc="DotNetFlexiGrid_onunChecked" 
   
      />   
     <br /></div>

      <div style="width:10%;">
        &nbsp;&nbsp;&nbsp;&nbsp;

                      &nbsp;&nbsp;&nbsp;&nbsp;
     <uc1:dotNetFlexGrid ID="FlexGridDrug" runat="server" 
            
      /></div>
    </div>
             <div>
        <div id='pop_div' class="pop_box">
            <div class="p_head">
                <div class="p_h_title">
                    <span>处方修改</span>
                </div>
                <div class="p_h_x" onclick="closeDiv();" title="关闭">关闭</div>
            </div>
            <div class="p_box_body" id="p_b_body"></div>
        </div>
    </div>
     <%--加载顺序要放到表格控件的后边--%>
    <link href="../../Css/ShowWin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery.divbox.js"></script>   
    <script type="text/javascript" src="../../Scripts/jquery.easydrag.handler.beta2.js"></script> 
      <script type="text/javascript" src="../../js/DatePicker.js"></script> 
    <script language="javascript" type="text/javascript">
        function openDiv() {
            var rows = FlexGridRecipe.getSelectedRowsIds();
         
           
            var url = "";
            if (rows.length != 1) {
                alert("请选择需要编辑的一行");
                return;
            } else {
          
            var rows2 = FlexGridDrug.getSelectedRowsIds();
          
                if (rows2.length == 1) {
                    
                    url = "DrugUpdate.aspx?id=" + rows2;

                } else {
                // var oNow = new Date();
              //  var iNumber = oNow.getSeconds();
                var d = new Date(), str = '';
                
                t = d.getHours();
                str += (t > 9 ? "" : "0") + t ;
                t = d.getMinutes();
                str += (t > 9 ? "" : "0") + t ;
                t = d.getSeconds();
                str += (t > 9 ? "" : "0") + t;

                 //alert(str); //产生一个基于当前时间的0到59的整数


                url = "RecipeUpdate.aspx?id=" + rows + "&randomnumber=" + str;
                }
                
            }
          
            $("#p_b_body").load(url);
            $("#pop_div").OpenDiv();
        }
        function closeDiv() {
            $("#pop_div").CloseDiv();
          //  window.location.reload();
        }
        $(function () {
            $(".pop_box").easydrag(); //拖动
            $(".pop_box").setHandler(".pop_box .p_head");
        });

    </script>
      </form>
</body>
</html>
