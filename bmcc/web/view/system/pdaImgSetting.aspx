<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pdaImgSetting.aspx.cs" Inherits="view_system_pdaImgSetting" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>后台设置</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
       <script type="text/javascript" src="../../js/jquery.js"></script>

     <script type="text/javascript">

    </script>
</head>
<body>
    <form id="form1" runat="server">
   <%--医院预警 --%>
    <div class="formtitle"><span>拍照开关设置</span></div>
      <div class="rightinfo">
    <div class="tools">   
    	<ul class="toolbar">
        <!--<li class="click" ><a href="Backgdsetwarningtime.aspx"><span><img src="../../img/t05.png" /></span>添加</a></li>-->
        <li class="click" onclick="openDiv();"><span><img src="../../img/t02.png" /></span>编辑</li>
        <!--<li class="click" onclick="deletewarningInfo();"><span><img src="../../img/t03.png" /></span>删除</li>-->
        <!--<li class="click" onclick="updatewarningstatus();"><span><img src="../../img/c01.png" /></span>改变开启状态</li>-->
        </ul>        
    </div>

    <uc1:dotNetFlexGrid ID="FlexGrid1" runat="server" />

       <%--弹跳浮层 --%>
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
    <script type="text/javascript" src="../../Scripts/jquery.divbox.js"> </script>
    <script type="text/javascript" src="../../Scripts/jquery.easydrag.handler.beta2.js"></script>
    <script type="text/javascript" src="../../js/DatePicker.js"></script> 
    <script language="javascript" type="text/javascript">
        function openDiv() {
            var rows = FlexGrid1.getSelectedRowsIds();
            if (rows.length != 1) {
                alert("请选择需要编辑的一行");
                return;
            } else {

            }
            var d = new Date(), str = '';

            t = d.getHours();
            str += (t > 9 ? "" : "0") + t;
            t = d.getMinutes();
            str += (t > 9 ? "" : "0") + t;
            t = d.getSeconds();
            str += (t > 9 ? "" : "0") + t;



            var url = "pdaImgSettingEdit.aspx?id=" + rows + "&randomnumber=" + str;
            $("#flowtitle").text("pda拍照开关");
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

