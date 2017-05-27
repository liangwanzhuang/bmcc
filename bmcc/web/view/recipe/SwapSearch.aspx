<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SwapSearch.aspx.cs" Inherits="view_recipe_SwapSearch" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/time.js"></script>
     <script language="javascript" type="text/javascript" src="../../js/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/DatePicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
           // $(".click").click(function () {
          //      $(".tip").fadeIn(200);
          //  });

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
        var FlexGridRecipe_selectId = "0";
        DotNetFlexiGrid_onChecked = function (e) {
            // alert("onUnChecked" + e);
            FlexGridRecipe_selectId = e;
        };
        function serchFun() {
            var status = $('#status').val();
            var date = $('#date');
            var eName = $('#eName');
            var p = [
                    { name: "status", value:  status },
                   
                    { name: "date", value: "" + date.val() + "" },
                    { name: "eName", value: "" + eName.val() + "" }
                ];
            FlexGridRecipe.applyQueryReload(p);
        }

        function delFun() {
            if (confirm("是否确认删除")) {

                var rows = FlexGridRecipe.getSelectedRowsIds();
                if (rows.length != 1) {
                    alert("请选择需要删除的一行");
                } else {
                    var array = FlexGridRecipe.getCellDatas(rows[0]);
                $.ajax({ type: "POST",
                    url: "SwapSearch.aspx/delAdjust",
                    data: "{'id':'" + array[37] + "'}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d != 0) {
                            alert('操作成功');
                            serchFun();

                        } else {
                            alert('操作失败');
                        }
                    }
                });
                    
                    

                }

            }

        }

        function addRecipe() {
            window.location.href = "RecipeGet.aspx";
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




        function getpcwarning() {

            $.ajax({ type: "POST",
                url: "SwapSearch.aspx/getpcwarning",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
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
          
            if (strRows1Id.length == 0 || strRows1Id =="") {
                marqueeContent[0] = "预警提示：暂无预警";
            } else {

                for (i = 0; i < strRows1Id.length; i++) {
                    marqueeContent[i] = "预警提示：煎药单号为" + strzero.substring(0, 10 - strRows1Id[i].length) + strRows1Id[i] + "" + "已过调剂预警时间";

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



        DotNetFlexiGrid_onunChecked = function (e) {

            FlexGridRecipe_selectId = 0;
            var array = FlexGridRecipe.getCellDatas(0);
            $('#Pspnum').val(array[4]);
            //传递给Grid2一个查询选项数组并让其刷新
            var p = [{ name: "drugpspnum", value: "" + array[4] + "" }, { name: "hospitalId", value: "" + array[37] + ""}];
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
    
}
</style>
</head>
<body>
    <form id="form1" runat="server">
     <%--<div class="place">
        <span>位置：</span>
        <ul class="placeul">
        <li><a href="#">处方管理</a></li>
        <li><a href="#">调剂管理</a></li>
        <li><a href="#">调剂查询</a></li>
        </ul>
    </div>--%> 
      <%-- 总部分--%> 
    <div class="rightinfo">
    <%-- 第一部分--%> 
        <li><span style = "color : red"><label id="count"/></span></li><br />
         <li> <input id ="warning" runat="server" type="hidden" name="FunName"/> </li>
       <li>  <span id="warning_span" style ="color : red;height:20px;"></span></li>
   <br />
    <div class="tools">
    
    	<ul class="toolbar">
        <li class="click" onclick="serchFun();"><span><img src="../../img/t01.png" /></span>查询</li>
       <%-- <li class="click" onclick="openDiv();"><span><img src="../../img/t02.png" /></span>编辑</li>--%>
       <li class="click" onclick="addDiv();"><span><img src="../../img/t05.png" /></span>添加</li>
       
          <%--<li class="click" onclick="delFun();"><span><img src="../../img/t03.png" /></span>作废</li>
        <li class="click"  onserverclick="Button1_Click"><span><img src="../../img/t04.png" /></span>导出数据</li>--%>
        <asp:Button  runat="server" OnClick="Button1_Click"   Text='导出数据' CssClass="btn3"/>
        </ul>         
    </div>
    <%-- 第二部分--%> 
    <ul class="forminfo">
    <li><label>处方状态</label>
        <select id="status" class="dfinput" name="Formulation-state" runat="server" onChange="" style="text-align:center">
        <option value="0" selected>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;开始调剂&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</option>
          
          <option value="1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;调剂完成&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</option>
          
         
        </select>
        &nbsp;&nbsp;开始时间&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="date" runat="server"  name="patient" type="text" onClick="WdatePicker()"  readonly="readonly" class="dfinput" />
      
    </li>
    <li><label>调剂人员</label>
        <input id="eName" runat="server"  name="patient" type="text" class="dfinput" />
      
        
    </li> 
    
    
    
    
    
    
    

       
        <!--<div style="width:600%; float:left">
             <img src="../../img/t01.png" /><p>配方信息显示（扫描信息）</p>-->
        
  <li> <uc1:dotNetFlexGrid ID="FlexGridRecipe" runat="server" 
    EventOnCheckedFunc="DotNetFlexiGrid_onChecked" 
    EventOnUnCheckedFunc="DotNetFlexiGrid_onunChecked" 
         />
  </li> 
        
    
        
    
      <%--加载顺序要放到表格控件的后边--%>
     </ul>
        <div>
        <div id='pop_div' class="pop_box">
            <div class="p_head">
                <div class="p_h_title">
                    <span><asp:Lable id = "flowtitle" runet="server" /></span>
                </div>
                <div class="p_h_x" onclick="closeDiv();" title="关闭">关闭</div>
            </div>
            <div class="p_box_body" id="p_b_body"></div>
        </div>
    </div>
    </div>
    <link href="../../Css/ShowWin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery.divbox.js"></script>   
    <script type="text/javascript" src="../../Scripts/jquery.easydrag.handler.beta2.js"></script> 
    <script type="text/javascript" src="../../js/DatePicker.js"></script> 
    <script language="javascript" type="text/javascript">
        function openDiv() {
            var rows = FlexGridRecipe.getSelectedRowsIds();
            if (rows.length != 1) {
                alert("请选择需要编辑的一行");
                return;
            } else {

            }

            var url = "RecipeUpdate.aspx?id=" + rows;
            $("#flowtitle").text("调剂信息");
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
            var rows = FlexGridRecipe.getSelectedRowsIds();
            var d = new Date(), str = '';

            t = d.getHours();
            str += (t > 9 ? "" : "0") + t;
            t = d.getMinutes();
            str += (t > 9 ? "" : "0") + t;
            t = d.getSeconds();
            str += (t > 9 ? "" : "0") + t;



            var url = "SwapSearchGet.aspx?id=" + rows + "&randomnumber=" + str;

            $("#flowtitle").text("调剂信息");
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
