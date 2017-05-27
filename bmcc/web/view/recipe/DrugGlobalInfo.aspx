<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DrugGlobalInfo.aspx.cs" Inherits="view_recipe_GlobalDrugInfo" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript">

        $(function () {
            getWarning();
             setInterval(function () {
                getWarning();

            }, 1000 * 60);

        })
        function getWarning() {
            $.ajax({ type: "POST",
                url: "DrugGlobalInfo.aspx/getWarning",
                data: "",
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    var warningstr = data.d;
                    //  alert(warningstr);
                    // var warningstr = "123,321,";
                    showWarning(warningstr);
                }
            });

        }
        var marqueeContent
        var item_i = 0;
        var timer;
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

          

            if (strRows1Id.length ==0 || strRows1Id == "") {
                marqueeContent[0] = "预警提示：暂无预警";
            } else {
           
                for (i = 0; i < strRows1Id.length; i++) {
                   
                    marqueeContent[i] = "预警提示：煎药单号为" + strzero.substring(0, 10 - strRows1Id[i].length) + strRows1Id[i] + "" + "已过泡药预警时间";
                 
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

        $(document).ready(function () {
            $(".click").click(function () {
                $(".tip").fadeIn(200);
            });

            $(".tiptop a").click(function () {
                $(".tip").fadeOut(200);
            });

            $(".sure").click(function () {
                $(".tip").fadeOut(100);
            });

            $(".cancel").click(function () {
                $(".tip").fadeOut(100);
            });

        });
        function findBtn() {
            var bubbleman = $("#bubbleman");
            var bubblestatus = $("#bubblestatus");



            var p = [{ name: "bubbleman", value: bubbleman.val() }, { name: "bubblestatus", value: bubblestatus.val()}];
            FlexGridDrugGlobal1.applyQueryReload(p);
            //window.location = "printRecipe.aspx?findRrescription=true&hospitalId=" + hospitalSelect.val() + "&recipeNum=" + recipeSelect.val();
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

        function fenfeimachine() {
            var rows = FlexGridDrugGlobal1.getSelectedRowsIds();
            var strRowIDs = "";
            if (rows.length > 0) {
                strRowIDs = rows[0];


                for (var i = 1; i < rows.length; i++) {
                    strRowIDs += "," + rows[i]; // alert(rows[i]);
                }


                $.ajax({ type: "POST",
                    url: "DrugGlobalInfo.aspx/distributionById",
                    data: "{'strRowIds':\"" + strRowIDs + "\"}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d == false) {
                            alert('删除失败');
                        } else {
                            alert('删除成功');
                        }
                        var p = [];
                        FlexGridDrugGlobal1.applyQueryReload(p);
                    }
                });

            } else {
                alert('请选中要删除的行');
            }
        }




        function print() {
            var rows = FlexGridDrugGlobal1.getSelectedRowsIds();
            if (rows.length != 1) {
                alert("请选择需要打印的一行");
                return;
            } else {


                //alert(quality);
            $.ajax({ type: "POST",
                url: "DrugGlobalInfo.aspx/checkisdone",
                data: "{'id':'" + rows + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                  
                    if (data.d == true) {

                        var url = "tisanebarcode.aspx?id=" + rows;
                        window.location.href = url;
                    } else {

                        alert('还未分配机组，不能打印煎药条码');

                    }

                }
            });



            }

            //var url = "tisanebarcode.aspx?id=" + rows;

        }





        function deleteRecipeInfo() {

            var rows = FlexGridDrugGlobal1.getSelectedRowsIds();
            var strRowIDs = "";
            if (rows.length > 0) {
                strRowIDs = rows[0];


                for (var i = 1; i < rows.length; i++) {
                    strRowIDs += "," + rows[i]; // alert(rows[i]);
                }


                $.ajax({ type: "POST",
                    url: "DrugGlobalInfo.aspx/deleteRecipeById",
                    data: "{'strRowIds':\"" + strRowIDs + "\"}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d == false) {
                            alert('删除失败');
                        } else {
                            alert('删除成功');
                        }
                        var p = [];
                        FlexGridDrugGlobal1.applyQueryReload(p);
                    }
                });

            } else {
                alert('请选中要删除的行');
            }
        }


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
    
}
</style>           
</head>
<body>
    <form id="form1" runat="server">
    <%-- <div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">处方管理</a></li>
    <li><a href="#">泡药管理</a></li>
    <li><a href="#">泡药信息</a></li>
    </ul>
    </div>--%> 
        <%-- 总部分--%> 
    <div class="rightinfo">
        <%-- 第一部分--%>
          <li><span style ="color : red"><label id="count"/></span></li><br />
           <li> <input id ="warning" runat="server" type="hidden" name="FunName"/> </li>
    <li><span id="warning_span" style ="color : red;height:20px;"></span></li><br />
      <div class="tools">
        <ul class="toolbar">
        <li class="click"  onclick="findBtn();"><span><img src="../../img/t01.png" /></span>查询</li>
        <%--<li class="click" onclick="openDiv12();"><span><img src="../../img/t02.png" /></span>编辑</li> --%>
        <li class="click" onclick="addDiv();"><span><img src="../../img/t05.png" /></span>添加</li>

         <li class="click" onclick="print();"><span><img src="../../img/t07.png" /></span>打印</li>

         <%--<li id="delete" onclick="deleteRecipeInfo();"><span><img src="../../img/t03.png" /></span>作废</li>
     <li class="click"  onserverclick="Button1_Click"><span><img src="../../img/t04.png" /></span>导出数据</li>--%>
        <asp:Button ID="Button1"  runat="server" OnClick="Button1_Click"   Text='导出数据' CssClass="btn3"/>
         
      
        </ul>  
    </div>
    
     <ul class="forminfo">
     <li><label>泡药人员</label>
        <input id="bubbleman" runat="Server" name="" type="text" class="dfinput2" />
      
    <label>&nbsp;&nbsp;&nbsp;&nbsp;泡药状态</label>
        <select id="bubblestatus" runat="server" class="dfinput2" name="hostpital" onChange="" style="text-align:center">
         
          <option value="0" selected>&nbsp;&nbsp;开始泡药&nbsp;&nbsp;</option> 
          <option value="1" >&nbsp;&nbsp;泡药完成&nbsp;&nbsp;</option> 
        </select>
    </li>
    <li><uc1:dotnetflexgrid ID="FlexGridDrugGlobal1" runat="server" /></li>
  
   
    </ul>

        <div style="width:10%; float:left">
           &nbsp;&nbsp;&nbsp;&nbsp;
        </div>

       
        <%-- 第二部分--%> 
    
    <br />
    <br />
    
 

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
        function openDiv() {
            var rows = FlexGridDrugGlobal1.getSelectedRowsIds();
            if (rows.length != 1) {
                alert("请选择需要编辑的一行");
                return;
            } else {

            }

            var url = "DrugGlobalInfoUpdate.aspx?id=" + rows;
            $("#flowtitle").text("处方信息");
            $("#p_b_body").load(url);

            $("#pop_div").OpenDiv();
        }
        function closeDiv() {
            $("#pop_div").CloseDiv();
        }
        $(function () {
            $(".pop_box").easydrag(); //拖动
            $(".pop_box").setHandler(".pop_box .p_head");
        });





        function fenpei() {
            var rows = FlexGridDrugGlobal1.getSelectedRowsIds();
            if (rows.length != 1) {
                alert("请选择需要分配的一行");
                return;
            } else {

            }

            var url = "DrugGlobaldistribution.aspx?id=" + rows;
            $("#flowtitle").text("机组分配");
            $("#p_b_body").load(url);

            $("#pop_div").OpenDiv();
        }
        function closeDiv() {
            $("#pop_div").CloseDiv();
        }
        $(function () {
            $(".pop_box").easydrag(); //拖动
            $(".pop_box").setHandler(".pop_box .p_head");
        });


        function addDiv() {
            var rows = FlexGridDrugGlobal1.getSelectedRowsIds();
            var d = new Date(), str = '';

            t = d.getHours();
            str += (t > 9 ? "" : "0") + t;
            t = d.getMinutes();
            str += (t > 9 ? "" : "0") + t;
            t = d.getSeconds();
            str += (t > 9 ? "" : "0") + t;

            var url = "DrugGlobalInfoGet.aspx?randomnumber=" + str;
            $("#flowtitle").text("添加泡药信息");
            $("#p_b_body").load(url);

            $("#pop_div").OpenDiv();
        }
        function closeDiv() {
            $("#pop_div").CloseDiv();
           // window.location.reload();
        }
        $(function () {
            $(".pop_box").easydrag(); //拖动
            $(".pop_box").setHandler(".pop_box .p_head");
        });

        
    </script>



    
</form>
</body>
</html>
