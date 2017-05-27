<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reviewquery.aspx.cs" Inherits="view_recipe_Reviewquery" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
      <script type="text/javascript" src="../../js/time.js"></script>
           <script language="javascript" type="text/javascript" src="../../js/My97DatePicker/WdatePicker.js"></script>
    <link href="../../css/hDate.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/jquery.date.js"></script>
    <script type="text/javascript" src="../../js/hDate.js"></script>
 
     
    <script type="text/javascript"  language="javascript">
        //查询
       
        function findBtn() {
            var StartTime = $("#StartTime");
            var EndTime = $("#EndTime");
            var AuditPer = $("#AuditPer");
            var num = $("#id");


            var p = [{ name: "StartTime", value: StartTime.val() }, { name: "EndTime", value: EndTime.val() }, { name: "AuditPer", value: AuditPer.val() }, { name: "num", value: num.val()}];
            dotNetFlexGrid3.applyQueryReload(p);


            //window.location = "printRecipe.aspx?findRrescription=true&hospitalId=" + hospitalSelect.val() + "&recipeNum=" + recipeSelect.val();
        }
        //b2信息

     
        var hospitalId = "0";

        var dotNetFlexGrid3_selectId = "0";
        DotNetFlexiGrid_onChecked = function (e) {
          
            // alert("onUnChecked" + e);
            dotNetFlexGrid3_selectId = e;
            var array = dotNetFlexGrid3.getCellDatas(e);
            //  $('#Pspnum').val(array[4]);
            //传递给Grid2一个查询选项数组并让其刷新
          
            var pDrug = [{ name: "drugpspnum", value: "" + array[5] + "" }, { name: "hospitalId", value: "" + array[3] + ""}];
            dotNetFlexGrid4.applyQueryReload(pDrug);
            //alert(array[5]);
            //   document.getElementById('select_checked').click();
        };

        DotNetFlexiGrid_onunChecked = function (e) {
            // alert("onUnChecked" + e);
            dotNetFlexGrid3_selectId = e;
            var array = dotNetFlexGrid3.getCellDatas(0);
            //  $('#Pspnum').val(array[4]);
            //传递给Grid2一个查询选项数组并让其刷新

            var pDrug = [{ name: "drugpspnum", value: "" + array[5] + "" }, { name: "hospitalId", value: "" + array[3] + ""}];
            dotNetFlexGrid4.applyQueryReload(pDrug);
            //alert(array[5]);
            //   document.getElementById('select_checked').click();

            //   document.getElementById('select_checked').click();
        };

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
                url: "Reviewquery.aspx/getpcwarning",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    showWarning(data.d);
                }
            });
        }

        $(function () {
            heidBigImg();

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
          
            if (strRows1Id.length == 0 || strRows1Id == "") {
             
                marqueeContent[0] = "预警提示：暂无预警";
            } else {

                for (i = 0; i < strRows1Id.length; i++) {
                    marqueeContent[i] = "预警提示：煎药单号为" + strzero.substring(0, 10 - strRows1Id[i].length) + strRows1Id[i] + "" + "已过复核预警时间";

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







        //重审
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
            /*if (recipeCheckValue == '2') {
                if (reasonText.length == 0) {
                    alert("请输入不通过原因");
                    return;
                } else if (reasonText.length > 99) {
                    alert("不通过原因的字数不能大于100个字符");
                    return;
                }
            }*/
            if (dotNetFlexGrid3_selectId == '0') {
                alert("请选择一个处方");
            } else {
                //FlexGridRecipe.deleteRows(FlexGridRecipe.getSelectedRowsIds());
                $.ajax({ type: "POST",
                    url: "Reviewquery.aspx/recipeCheck",
                    data: "{'id':'" + dotNetFlexGrid3_selectId + "'}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d != 0) {
                            alert('重审成功，此处方已返回调剂');
                            dotNetFlexGrid3.deleteRows(dotNetFlexGrid3.getSelectedRowsIds());
                            var p = [{ name: "drugpspnum", value: "0" }, { name: "hospitalId", value: "0"}];
                            dotNetFlexGrid4.applyQueryReload(p);
                            dotNetFlexGrid3_selectId = '0';

                        } else {

                            alert('此处方已进入下一环节，重审失败');
                        }
                    }
                });
            }

        }
        //删除
        function deleteRecipeInfo() {

               
                var rows = dotNetFlexGrid3.getSelectedRowsIds()
                var strRowIDs = "";

                 if (rows.length > 0) { 
                    strRowIDs = rows[0];
               

                for (var i = 1; i < rows.length; i++) {
                    strRowIDs += "," + rows[i]; // alert(rows[i]);
                }

                alert(strRowIDs);
                $.ajax({ type: "POST",
                    url: "Reviewquery.aspx/deleteReviewqueryById",
                    data: "{'strRowIds':\"" + strRowIDs + "\"}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d == false) {
                            alert('删除失败');
                        } else {
                            alert('删除成功');
                        }
                        var p = [];
                        dotNetFlexGrid3.applyQueryReload(p);

                    }
                });
            } else 
            {
                alert('请选中要删除的行');
            }
        }

        function showBigImg(img) {
            var bigImg = $("#bigImg");
            $("#floating_div").show();
            $("#floating_div").css('height', $('body').height());
            bigImg.show();

            bigImg.attr('src', img.src)
            var bigImg_w = bigImg.width();
            var bigImg_h = bigImg.height();
            var width = window.innerWidth;
            var height = window.innerHeight;
            bigImg.css('top', ((height - bigImg_h)/2));
            bigImg.css('left', ((width - bigImg_w) / 2));
            
            return true;
        }
        function heidBigImg() {
            $("#floating_div").hide();
            $("#bigImg").hide();

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
.transparent_class   
{
    background:#000000;
      filter:alpha(opacity=50);  
      -moz-opacity:0.5;  
      -khtml-opacity: 0.5;  
      opacity: 0.5;  
}  
#floating_div
{
        
       width:100%;
       height:100%;
       position:absolute;
       z-index:10;
       left:0px;
       top:0px;
}
#bigImg
{
    position:absolute;
    z-index:11;
    
}

</style>
</head>
    <body>
    <div id="floating_div" onclick="heidBigImg();" class="transparent_class"></div>
    <img id="bigImg" onclick="heidBigImg();"/>
    <form id="form1" runat="server">
      <%--<div class="place">
        <span>位置：</span>
        <ul class="placeul">
        <li><a href="#">处方管理</a></li>
        <li><a href="#">复核管理</a></li>
        <li><a href="#">复核查询</a></li>
        </ul>
    </div>--%> 
 <%-- 总部分--%> 
  

    <div class="rightinfo" >
    <li><span style = "color : red"><label id="count" /></span></li><br />
        <li> <input id ="warning" runat="server" type="hidden" name="FunName"/> </li>
         <li><span id="warning_span" style ="color : red;height:20px;"></span></li>
      <br />




    <div class="tools">
    
    	<ul class="toolbar">
         <li class="click" onclick="findBtn();"><span><img src="../../img/t01.png" /></span>查询</li>
        <%-- <li class="click" onclick="openDiv();"><span><img src="../../img/t02.png" /></span>编辑</li>--%>
         <li class="click" onclick="addDiv();"><span><img src="../../img/t05.png  " /></span>添加</li>
       
       <%--<li class="click" onclick="deleteRecipeInfo(),deleteDrugInfo();"><span><img src="../../img/t03.png" /></span>作废</li>--%>
        <%--<li class="click"  onserverclick="Button1_Click"><span><img src="../../img/t04.png" /></span>导出数据</li>
        <li class="click" onclick="window.print()"><span><img src=" ../../img/t07.png " /></span>打印数据</li>--%>
        <asp:Button ID="Button1"  runat="server" OnClick="Button1_Click"   Text='导出处方数据' CssClass="btn3"/>
          <asp:Button ID="Button2"  runat="server" OnClick="Button2_Click"   Text='导出药品数据' CssClass="btn3"/>
         
        </ul>         
    </div>
    <%-- 第二部分--%> 
    <ul class="forminfo">
    <li><label>开始时间</label>
     <input id="StartTime" runat="server" name="" type="text" class="dfinput2" onClick="WdatePicker()"  readonly="readonly"/>
        
       <label>&nbsp;&nbsp;&nbsp;&nbsp;结束时间&nbsp;</label>
         <input id="EndTime" runat="server" name="" type="text" class="dfinput2" onClick="WdatePicker()"  readonly="readonly"/>
         
    <br/><br/><br/>
     <label>复核人员</label>
       <input id="AuditPer" runat="Server" name="" type="text" class="dfinput2" /><i></i>

        <label>&nbsp;&nbsp;&nbsp;&nbsp;煎药单号&nbsp;</label>
        <input id="id" runat="server" name="" type="text" class="dfinput2" />
          
    </li> </ul>

      <div style="width:1000px; ">
        
          <uc1:dotNetFlexGrid ID="dotNetFlexGrid3" runat="server" 
          EventOnCheckedFunc="DotNetFlexiGrid_onChecked"
            EventOnUnCheckedFunc="DotNetFlexiGrid_onunChecked" 
          />
       
        <div style="width:10%;">
           &nbsp;&nbsp;&nbsp;&nbsp;
                      &nbsp;&nbsp;&nbsp;&nbsp;
        
    
        
              <uc1:dotNetFlexGrid ID="dotNetFlexGrid4" runat="server" />
        </div>
      <div style="width:10%;">
           &nbsp;&nbsp;&nbsp;&nbsp;
                      &nbsp;&nbsp;&nbsp;&nbsp;
        </div></div>
       

    
    <div style="width:10%;">
           &nbsp;&nbsp;&nbsp;&nbsp;
                      &nbsp;&nbsp;&nbsp;&nbsp;
        </div>
    <%-- <ul class="toolbar" style="margin-left:10px;">
            <li>
                &nbsp;&nbsp;
                <label class="label"><input class="label" name="check" type="radio" checked="checked" value="1" onclick="recipeCheckSelect(this);" style="margin-bottom:3px;"/>通过</label> 
                
            </li>
       <li>
      &nbsp;&nbsp;
                <label class="label"><input class="label" name="check" type="radio"value="2" onclick="recipeCheckSelect(this);" style="margin-bottom:3px;"/>不通过</label> 
            </li>
           
              <li id="reason" style="padding-right:0px;padding-left:10px;display:none;">
               不通过原因：<input id="reasonText" runat="server"  name="" type="text" class="dfinput2"/>
            </li> </ul> --%>
             <input name="" onclick="recipeCheck();" type="button" class="btn" value="重审"/>
  
   <div style="width:10%;">
           &nbsp;&nbsp;&nbsp;&nbsp;
                      &nbsp;&nbsp;&nbsp;&nbsp;
        </div>
          

     
   <div> <div  id='pop_div' class="pop_box" >
            <div class="p_head">
                <div class="p_h_title">
                    <span><asp:Label id="flowtitle" runat="server"/></span>
                </div>
                <div class="p_h_x" onclick="closeDiv();" title="关闭">关闭</div>
            </div>
            <div class="p_box_body" id="p_b_body"></div>
        </div>
    </div>
    </div>


     <%--加载顺序要放到表格控件的后边--%>
    <link href="../../Css/ShowWin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery.divbox.js"></script>   
    <script type="text/javascript" src="../../Scripts/jquery.easydrag.handler.beta2.js"></script> 
    <script type="text/javascript" src="../../js/DatePicker.js"></script> 
    <script language="javascript" type="text/javascript">
    <%--编辑--%>
        function openDiv() {
            var rows = dotNetFlexGrid3.getSelectedRowsIds();
            
            if (rows.length != 1) {
                alert("请选择需要编辑的一行");
                return;
            } else {

            }
           
            var url = "ReviewqueryUpdate.aspx?id=" + rows;
            $("#flowtitle").text("编辑复核查询信息");
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
        <%--添加--%>
        function addDiv() {
            var rows = dotNetFlexGrid3.getSelectedRowsIds();
           /* if (rows.length != 1) {
                alert("请选择需要添加的一行");
                return;
            } else {

            }*/
            var d = new Date(), str = '';
                
                t = d.getHours();
                str += (t > 9 ? "" : "0") + t ;
                t = d.getMinutes();
                str += (t > 9 ? "" : "0") + t ;
                t = d.getSeconds();
                str += (t > 9 ? "" : "0") + t;



            var url = "ReviewqueryGet.aspx?id=" +  rows + "&randomnumber=" + str;
            $("#flowtitle").text("添加复核查询信息");
            $("#p_b_body").load(url);

            $("#pop_div").OpenDiv();
        }
        function closeDiv() {
            $("#pop_div").CloseDiv();
            //window.location.reload();
        }
        $(function () {
            $(".pop_box").easydrag(); //拖动
            $(".pop_box").setHandler(".pop_box .p_head");
        });

        
    </script>
    </form>
</body>
</html>
