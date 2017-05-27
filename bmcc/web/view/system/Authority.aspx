<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Authority.aspx.cs" Inherits="view_system_Authority" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>权限管理</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery.js"></script>
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
        


          
         


            var p = [{ name:"EName", value: EName.val()}];
            FlexGridAuthority.applyQueryReload(p);

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
</script>
</head>
<body>
    <form id="form1" runat="server">
 
    <div class="rightinfo">
    <div class="tools">   
    	<ul class="toolbar">
        <li class="click" onclick="openDiv();"><span><img src="../../img/t02.png" /></span>编辑</li>
       
         <%--  <li class="click"><a href="AuthorityGet.aspx"><span><img src="../../img/t05.png" /></span>添加</a></li>
       <li class="click" onclick="deletePackingInfo();"><span><img src="../../img/t03.png" /></span>删除</li> --%>
        
     
          
        </ul>        
    </div>
     <div class="formtitle"><span>权限信息</span></div>
    
  
   
    <ul class="forminfo">
    <li><label>人员</label>
        <input id="EName" runat="Server" name="" type="text" class="dfinput" />
    </li>
   
    
    <li><label>&nbsp;</label><input id="Search" onclick="findBtn();" runat="server" name="" type="button" class="btn" value="查询"  />&nbsp;&nbsp;&nbsp;&nbsp;<input name="" type="button" class="btn" value="取消"/></li>
    </ul>
    
    


  
    
    </div>

    <uc1:dotNetFlexGrid ID="FlexGridAuthority" runat="server" />

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
                    <span>权限信息修改</span>
                </div>
                <div class="p_h_x" onclick="closeDiv();" title="关闭">关闭</div>
            </div>
            <div class="p_box_body" id="p_b_body" style="overflow-x:hidden;overflow-y:auto;height:425px;"></div>
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
            var rows = FlexGridAuthority.getSelectedRowsIds();
            if (rows.length != 1) {
                alert("请选择需要编辑的一行");
                return;
            } else {
                var array = FlexGridAuthority.getCellDatas(rows);
                if (array[1] == '管理员') {
                    alert("管理员权限不可以修改");
                    return;
                }
            }

            var url = "AuthorityEdit.aspx?id=" + rows;

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
