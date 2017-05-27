<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Workrecordquery.aspx.cs" Inherits="view_recipe_Workrecordquery" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/time.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/DatePicker.js"></script> 
 
     
    <script type="text/javascript">
        //查询

        function findBtn() {
            var StartTime = $("#StartTime");
            var EndTime = $("#EndTime");
            var PNum = $("#PNum");
            var AuditPer = $("#AuditPer");



            var p = [{ name: "StartTime", value: StartTime.val() }, { name: "EndTime", value: EndTime.val() }, { name: "PNum", value: PNum.val()},{ name: "AuditPer", value: AuditPer.val()}];
            dotNetFlexGrid5.applyQueryReload(p);


            //window.location = "printRecipe.aspx?findRrescription=true&hospitalId=" + hospitalSelect.val() + "&recipeNum=" + recipeSelect.val();
        }
        //删除
        function deleteRecipeInfo() {
           
            var rows = dotNetFlexGrid5.getSelectedRowsIds()
            var strRowIDs = "";
            if (rows.length > 0) {
                strRowIDs = rows[0];
           

            for (var i = 1; i < rows.length; i++) {
                strRowIDs += "," + rows[i]; 
            }

            alert(strRowIDs);

            $.ajax({ type: "POST",
                url: "Workrecordquery.aspx/deleteWorkrecordqueryById",
                data: "{'strRowIds':\"" + strRowIDs + "\"}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == false) {
                        alert('删除失败');
                    } else {
                        alert('删除成功');
                    }
                    var p = [];
                    dotNetFlexGrid5.applyQueryReload(p);

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
</script>
</head>
<body>
    <form id="form1" runat="server">
    <%-- <div class="place">
        <span>位置：</span>
        <ul class="placeul">
        <li><a href="#">处方管理</a></li>
        <li><a href="#">复核管理</a></li>
        <li><a href="#">工作记录查询</a></li>
        </ul>
    </div>--%> 
     <%-- 总部分--%> 
    <div class="rightinfo">
    <%-- 第一部分--%> 
       
    <div class="tools">
    
    	<ul class="toolbar">
        <li class="click" onclick="findBtn();"><span><img src="../../img/t01.png" /></span>查询</li>
        <%-- <li class="click" onclick="openDiv();"><span><img src="../../img/t02.png" /></span>编辑</li>--%>

        <%-- <li class="click" onclick="addDiv();"><span><img src=" ../../img/t05.png  " /></span>添加</li>--%>
     <%-- <li class="click" onclick="deleteRecipeInfo();"><span><img src="../../img/t03.png" /></span>作废</li>
       <li class="click"  onserverclick="Button1_Click"><span><img src="../../img/t04.png" /></span>导出数据</li>--%>
        <asp:Button ID="Button1"  runat="server" OnClick="Button1_Click"   Text='导出数据' CssClass="btn3"/>
        </ul>         
    </div>
    <%-- 第二部分--%> 
    <ul class="forminfo">
    <li><label>开始时间</label>
        <input id="StartTime" runat="server" name="" type="text" class="dfinput2" onClick="WdatePicker()"  readonly="readonly"/>
       <label> &nbsp;&nbsp;结束时间&nbsp;&nbsp;&nbsp;</label>
        <input id="EndTime" runat="server" name="" type="text" class="dfinput2" onClick="WdatePicker()"  readonly="readonly"/>
    </li>
    <li><label>处方编号</label>
        <input id="PNum" runat="Server" name="" type="text" class="dfinput2" /><i></i>
       <label> &nbsp;&nbsp;复核人员&nbsp;&nbsp;&nbsp;</label>
        <input id="AuditPer" runat="Server" name="" type="text" class="dfinput2" /><i></i>
    </li> 

        
          <li>  <uc1:dotNetFlexGrid ID="dotNetFlexGrid5" runat="server" /></li>
           <li><span style = "color : red"><asp:Label id="Label1" runat="server"/></span></li>
        

  

    </ul>
    </div>
        <div style="width:10%;">

           &nbsp;&nbsp;&nbsp;&nbsp;

                      &nbsp;&nbsp;&nbsp;&nbsp;

        </div>

       
    <div>
        <div id='pop_div' class="pop_box">
            <div class="p_head">
                <div class="p_h_title">
                      <span><asp:Label id="flowtitle" runat="server"/></span>
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
     <%--编辑--%>
        function openDiv() {
            var rows = dotNetFlexGrid5.getSelectedRowsIds();
            if (rows.length != 1) {
                alert("请选择需要编辑的一行");
                return;
            } else {

            }

            var url = "WorkrecordqueryUPdate.aspx?id=" + rows;
            $("#flowtitle").text("编辑工作记录查询信息");
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
            var rows = dotNetFlexGrid5.getSelectedRowsIds();
           <%-- if (rows.length != 1) {
                alert("请选择需要添加的一行");
                return;
            } else {

            }--%> 

            var url = "WorkrecordqueryGet.aspx?id=" + rows;
            $("#flowtitle").text("添加工作记录查询信息");
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

        
    </script>
    </form>
</body>
</html>
