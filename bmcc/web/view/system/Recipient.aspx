<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Recipient.aspx.cs" Inherits="view_system_Recipient" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" language="javascript">
        
         //查询

         function findBtn() {
             var ClearPName = $("#ClearPName");


             var p = [{ name: "ClearPName", value: ClearPName.val() }];
             FlexGridRecipient.applyQueryReload(p);

         }

         //删除
         function deleteRecipientInfo() {
             var rows = FlexGridRecipient.getSelectedRowsIds();
             var strRowIDs = "";
             if (rows.length > 0) {
                 strRowIDs = rows[0];


                 for (var i = 1; i < rows.length; i++) {
                     strRowIDs += "," + rows[i]; // alert(rows[i]);
                 }

                 //alert(strRowIDs);

                 $.ajax({ type: "POST",
                     url: "Recipient.aspx/deleteRecipientById",
                     data: "{'strRowIds':\"" + strRowIDs + "\"}",
                     contentType: "application/json; charset=utf-8",
                     success: function (data) {
                         if (data.d == false) {
                             alert('删除失败');
                         } else {
                             alert('删除成功');
                         }
                         var p = [];
                         FlexGridRecipient.applyQueryReload(p);
                     }
                 });
             } else {
                 alert('请选中要删除的一行');
             }
         }
</script>
</head>
<body>
    <form id="form1" runat="server">
     <%--<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">系统设置</a></li>
    <li><a href="#">系统设置</a></li>
    <li><a href="#">收件人管理</a></li>
    </ul>
     </div>--%> 
    <div class="rightinfo">
    <div class="tools">   
    	<ul class="toolbar">
        <li class="click" onclick="findBtn();"><span><img src="../../img/t01.png" /></span>查询</li>

        <li class="click" onclick="addDiv();"><span><img src="../../img/t05.png" /></span>添加</li>
        <li class="click" onclick="openDiv();"><span><img src="../../img/t02.png" /></span>修改</li>
        <li class="click" onclick="deleteRecipientInfo();"><span><img src="../../img/t03.png" /></span>删除</li>
      
          
        </ul>        
    </div>
 
   
    <ul class="forminfo">
    <li><label>收件人</label>
        <select id="ClearPName" runat="server" class="dfinput" name="Clearingparty" onChange="" style="text-align:center">

        </select>
    </li>
   <li><div style="width:1000px; ">
    <uc1:dotNetFlexGrid ID="FlexGridRecipient" runat="server" />
    </div>
    </li>
    </ul>
    
    

  
    
    </div>
    
     <div class="tip">
    	<div class="tiptop"><span>提示信息</span><a ></a></div>
        
      <div class="tipinfo">
        <%--<span><img src="../../img/ticon.png" /></span>--%>
        <div class="tipright">
        <p id = "content" runat="Server"></p>
      <%--  <cite>如果是请点击确定按钮 ，否则请点取消。</cite>--%>
        </div>
        </div>
        
        <div class="tipbtn">
        <input name="" type="button"  class="sure"  value="确定" />&nbsp;
        <input name="" type="button"  class="cancel"  value="取消" />
        </div>
    
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
 
     <%--加载顺序要放到表格控件的后边,编辑--%>
    <link href="../../Css/ShowWin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery.divbox.js"></script>   
    <script type="text/javascript" src="../../Scripts/jquery.easydrag.handler.beta2.js"></script> 
    <script type="text/javascript" src="../../js/DatePicker.js"></script> 
    <script language="javascript" type="text/javascript">
        function openDiv() {
            var rows = FlexGridRecipient.getSelectedRowsIds();
            if (rows.length != 1) {
                alert("请选择需要修改的一行");
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

            var url = "RecipientUpdate.aspx?id=" + rows + "&randomnumber=" + str;
            $("#flowtitle").text("修改收件人信息信息");
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
            var rows = FlexGridRecipient.getSelectedRowsIds();


            var url = "RecipientGet.aspx?id=" + rows;
            $("#flowtitle").text("添加收件人信息");
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
