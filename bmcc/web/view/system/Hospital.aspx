<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Hospital.aspx.cs" Inherits="view_system_Hospital" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
       <script type="text/javascript" language="javascript">
           function hospitalSelectChange(select) {
            var id = $(select).val();
            $("#recipeSelect option").remove();
            //  alert(id);
            if (id != 0) {
                $.ajax({ type: "POST",
                    url: "Hospital.aspx/getNumByHospitalId",
                    data: "{'hname':" + id + "}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        var datas = data.d.split(";");

                        $("#hnum").val(datas[0]);
                        
                        
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
               var hname = $("#hname");
               var hnum = $("#hnum");
      
               var p = [{ name: "hname", value: hname.val() }, { name: "hnum", value: hnum.val()}];
               FlexGridHospital.applyQueryReload(p);


               //window.location = "printRecipe.aspx?findRrescription=true&hospitalId=" + hospitalSelect.val() + "&recipeNum=" + recipeSelect.val();
           }

           //删除
           function deleteHospitalInfo() {
               var rows = FlexGridHospital.getSelectedRowsIds();
               var strRowIDs = "";
               if (rows.length > 0) {
                   strRowIDs = rows[0];


                   for (var i = 1; i < rows.length; i++) {
                       strRowIDs += "," + rows[i]; // alert(rows[i]);
                   }

                   //alert(strRowIDs);

                   $.ajax({ type: "POST",
                       url: "Hospital.aspx/deleteHospitalById",
                       data: "{'strRowIds':\"" + strRowIDs + "\"}",
                       contentType: "application/json; charset=utf-8",
                       success: function (data) {
                           if (data.d == false) {
                               alert('删除失败');
                           } else {
                               alert('删除成功');
                           }
                           var p = [];
                           FlexGridHospital.applyQueryReload(p);
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
        <li><a href="#">医院管理</a></li>
        </ul>
    </div>--%> 
    <div class="rightinfo">
    <div class="tools">   
    	<ul class="toolbar">

        <li class="click" onclick="findBtn();"><span><img src="../../img/t01.png" /></span>查询</li>
        <li class="click" onclick="addDiv();"><span><img src="../../img/t05.png" /></span>添加</li>

        <li class="click" onclick="openDiv();"><span><img src="../../img/t02.png" /></span>修改</li>
        <li  class="click"     onclick="deleteHospitalInfo();"><span><img src="../../img/t03.png" /></span>删除</li>
         
        </ul>        
    </div>
     <div class="formtitle"><span>医院信息</span></div>
    
    <ul class="forminfo">
    <li><label>医院名称</label><select id="hname" runat="server" class="dfinput2" name="Hospital"  style="text-align:center">

        </select>
   
    <label>医院编号</label>
    
     <input id="hnum" runat="server" name="" type="text" class="dfinput2"  /></li></li>
    <li><div><uc1:dotNetFlexGrid ID="FlexGridHospital" runat="server" /></div></li>
   
    </ul>
    <div>
    
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
            var rows = FlexGridHospital.getSelectedRowsIds();
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



            var url = "HospitalUpdate.aspx?id=" + rows + "&randomnumber=" + str;
            $("#flowtitle").text("修改医院信息");
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
        //添加
        function addDiv() {
            var rows = FlexGridHospital.getSelectedRowsIds();


            var url = "HospitalGet.aspx?id=" + rows;
            $("#flowtitle").text("添加医院信息");
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
