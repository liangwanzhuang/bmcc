<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Clearingparty.aspx.cs" Inherits="view_system_Clearingparty" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
   <script type="text/javascript" src="../../js/jquery.js"></script>
<script type="text/javascript" src="../../js/DatePicker.js"></script>

<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        //查询

        function findBtn() {
            var ClearPName = $("#ClearPName");
         

            


            var p = [{ name: "ClearPName", value: ClearPName.val() }];
            FlexGridClearingparty.applyQueryReload(p);


            //window.location = "printRecipe.aspx?findRrescription=true&hospitalId=" + hospitalSelect.val() + "&recipeNum=" + recipeSelect.val();
        }

        //删除
        function deleteClearingpartyInfo() {
            var rows = FlexGridClearingparty.getSelectedRowsIds();
            var strRowIDs = "";
            if (rows.length > 0) {
                strRowIDs = rows[0];
            

            for (var i = 1; i < rows.length; i++) {
                strRowIDs += "," + rows[i]; // alert(rows[i]);

                }
                //alert(strRowIDs);

                $.ajax({ type: "POST",
                    url: "Clearingparty.aspx/deleteClearingpartyById",
                    data: "{'strRowIds':\"" + strRowIDs + "\"}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d == false) {
                            alert('删除失败');
                        } else {
                            alert('删除成功');
                        }
                        var p = [];
                        FlexGridClearingparty.applyQueryReload(p);
                    }
                });
            }else {
                 alert('请选中要删除的一行');
             } 
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <%-- <div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">系统设置</a></li>
    <li><a href="#">系统设置</a></li>
    <li><a href="#">结算方管理</a></li>
    </ul>

    </div>--%> 
    <div class="rightinfo">
    <div class="tools">   
    	<ul class="toolbar">
        <li class="click" onclick="findBtn();"><span><img src="../../img/t01.png" /></span>查询</li>

        <li class="click" onclick="addDiv();"><span><img src="../../img/t05.png" /></span>添加</li>
        <li class="click" onclick="openDiv();"><span><img src="../../img/t02.png" /></span>修改</li>
        <li class="click" onclick="deleteClearingpartyInfo();"><span><img src="../../img/t03.png" /></span>删除</li>
      
          
        </ul>        
    </div>
     <div class="formtitle"><span>结算方信息</span></div>
    
  
   
    <ul class="forminfo">
    <li><label>结算方名称</label>
        <select id="ClearPName" runat="server" class="dfinput" name="Clearingparty" onChange="" style="text-align:center">

        </select>
    </li>
   
    <li><div> <uc1:dotNetFlexGrid ID="FlexGridClearingparty" runat="server" /></div></li>
   
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
    </div>
     <%--加载顺序要放到表格控件的后边,编辑--%>
    <link href="../../Css/ShowWin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery.divbox.js"></script>   
    <script type="text/javascript" src="../../Scripts/jquery.easydrag.handler.beta2.js"></script> 
    <script type="text/javascript" src="../../js/DatePicker.js"></script> 
    <script language="javascript" type="text/javascript">
        function openDiv() {
            var rows = FlexGridClearingparty.getSelectedRowsIds();
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

            var url = "ClearingpartyUpdate.aspx?id=" + rows + "&randomnumber=" + str;
            $("#flowtitle").text("修改结算方信息");
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
            var rows = FlexGridClearingparty.getSelectedRowsIds();
            var d = new Date(), str = '';

            t = d.getHours();
            str += (t > 9 ? "" : "0") + t;
            t = d.getMinutes();
            str += (t > 9 ? "" : "0") + t;
            t = d.getSeconds();
            str += (t > 9 ? "" : "0") + t;

            var url = "ClearingpartyGet.aspx?id=" + rows + "&randomnumber=" + str;
            $("#flowtitle").text("添加结算方信息");
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
