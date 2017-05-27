<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Employee.aspx.cs" Inherits="view_system_Employee" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">


<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" language="javascript">
         function EmployeeNameSelectChange(select) {
             var id = $(select).val();
             $("#recipeSelect option").remove();
            // alert(id);
               
             if (id != 0) {
                 $.ajax({ type: "POST",
                     url: "Employee.aspx/getNumByEName",
                     data: "{'EName':" + id + "}",
                     contentType: "application/json; charset=utf-8",
                     success: function (data) {
                         var datas = data.d.split(";");

                         $("#JobNum").val(datas[0]);
                     }
                 });
             }

             if (id == "0") {
                 for (i = 0; i < document.all.tags("input").length; i++) {
                     if (document.all.tags("input")[i].type == "text") {
                         document.all.tags("input")[i].value = "";
                     }
                 }
             }
         }
         //查询

         function findBtn() {
             var EName = $("#EName");
             var JobNum = $("#JobNum");
             var role = $("#role");


             var p = [{ name: "EName", value: EName.val() }, { name: "JobNum", value: JobNum.val() }, { name: "role", value: role.val()}];
             FlexGridEmployee.applyQueryReload(p);

             //window.location = "printRecipe.aspx?findRrescription=true&hospitalId=" + hospitalSelect.val() + "&recipeNum=" + recipeSelect.val();
         }

         //删除
         function deleteEmployeeInfo() {
             var rows = FlexGridEmployee.getSelectedRowsIds();
             var strRowIDs = "";
             if (rows.length > 0) {
                 strRowIDs = rows[0];


                 for (var i = 1; i < rows.length; i++) {
                     strRowIDs += "," + rows[i]; // alert(rows[i]);
                 }

                 //alert(strRowIDs);

                 $.ajax({ type: "POST",
                     url: "Employee.aspx/deleteEmployeeById",
                     data: "{'strRowIds':\"" + strRowIDs + "\"}",
                     contentType: "application/json; charset=utf-8",
                     success: function (data) {
                         if (data.d == false) {
                             alert('删除失败');
                         } else {
                             alert('删除成功');
                         }
                         var p = [];
                         FlexGridEmployee.applyQueryReload(p);
                     }
                 });
             } else {
                 alert('请选中要删除的一行');
             }
         }
         function printBtn() {
             //var id = $(select).val();
             // $("#recipeSelect option").remove();
             //  alert(id);

             var rows = FlexGridEmployee.getSelectedRowsIds();
             if (rows.length != 1) {
                 alert("请选择需要打印的一行");
                 return;
             } else {

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
    <li><a href="#">员工信息</a></li>
    </ul>

    </div>--%> 
    <div class="rightinfo">
    <div class="tools">   
    	<ul class="toolbar">
        <li class="click" onclick="findBtn();" > <span><img src="../../img/t01.png" /></span>搜索</li>
        <li class="click" onclick="addDiv();"><span><img src="../../img/t05.png" /></span>添加</li>
        <li class="click" onclick="openDiv();"><span><img src="../../img/t02.png" /></span>修改</li>
        <li class="click" onclick="print();"><span><img src="../../img/t07.png" /></span>打印员工条码</li>
        <li class="click" onclick="deleteEmployeeInfo();"><span><img src="../../img/t03.png" /></span>删除</li>
        <%-- <li class="click"><span><img src="  " /></span>保存</li>--%>
          
        </ul>        
    </div>
     
    
  
   
    <ul class="forminfo">
    <li><label>员工姓名</label>

    <input id="EName" runat="Server" name="" type="text" class="dfinput2" />
        <%-- <select id="EName" runat="server" class="dfinput" name="Employee" onChange="EmployeeNameSelectChange(this);" style="text-align:center">
        
        </select>--%>

  <label>&nbsp;&nbsp;&nbsp;&nbsp;员工工号</label>
       <%-- <select id="JobNum" runat="server" class="dfinput" name="Employee" onChange="" style="text-align:center">

        </select>--%>
        <input id="JobNum" runat="server" name="" type="text" class="dfinput2"  />
     <label>&nbsp;&nbsp;&nbsp;&nbsp;角色</label>
    
      <select id="role" runat="Server" class="dfinput2">
       <option value="">全部</option>
            <option value="0">管理员</option>

            <option value="7">接方人员</option>
            <option value="8">配方人员</option>
            <option value="1">调剂人员</option>
            <option value="2">复核人员</option>
            <option value="3">泡药人员</option>
            <option value="4">煎药人员</option>
            <option value="5">包装人员</option>
            <option value="6">发货人员</option>
            <option value="9">医院登录人员</option>
            <option value="10">医院人员</option>
        </select></li>
    <%-- <li><label>&nbsp;</label><input id="Search"  onclick="findBtn();" runat="server" name="" type="button" class="btn" value="搜索"  />&nbsp;&nbsp;&nbsp;&nbsp;<input name="" type="button" class="btn" value="取消"/></li>--%>
  <br /><br /><br />
    <uc1:dotNetFlexGrid ID="FlexGridEmployee" runat="server" />
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
            var rows = FlexGridEmployee.getSelectedRowsIds();
            if (rows.length != 1) {
                alert("请选择需要编辑的一行！");
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

            var url = "EmployeeUpdate.aspx?id=" + rows + "&randomnumber=" + str;
            $("#flowtitle").text("修改员工信息");
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
            var rows = FlexGridEmployee.getSelectedRowsIds();

         
            var url = "EmployeeGet.aspx?id=" + rows ;

            $("#flowtitle").text("添加员工信息");
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
        //打印
        function print() {
            var rows = FlexGridEmployee.getSelectedRowsIds();
            if (rows.length != 1) {
                alert("请选择需要打印的一行");
                return;
            } else {

            }

            var url = "EmployeeBarCode.aspx?id=" + rows;

            window.location.href = url;



        }
    </script>
    
    </form>
</body>
</html>
