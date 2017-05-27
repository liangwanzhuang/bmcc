<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Backgdset.aspx.cs" Inherits="view_system_Backgdset" %>

<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>后台设置</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
       <script type="text/javascript" src="../../js/jquery.js"></script>

     <script type="text/javascript">


    function deletewarningInfo(){
       
        var rows = FlexGrid1.getSelectedRowsIds();
            var strRowIDs = "";
            if (rows.length > 0) {
                strRowIDs = rows[0];

                for (var i = 1; i < rows.length; i++) {
                    strRowIDs += "," + rows[i]; // alert(rows[i]);
                }

              
                $.ajax({ type: "POST",
                    url: "Backgdset.aspx/deletewarninginfoById",
                    data: "{'strRowIds':\"" + strRowIDs + "\"}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d == false) {
                            alert('删除失败');
                        } else {
                            alert('删除成功');
                        }
                        var p = [];
                        FlexGrid1.applyQueryReload(p);
                    }
                });

            } else {
                alert('请选中要删除的行');
            }
        }
        function rdeletewarningInfo() {

            var rows = DotNetFlexGrid1.getSelectedRowsIds();
            var strRowIDs = "";
            if (rows.length > 0) {
                strRowIDs = rows[0];

                for (var i = 1; i < rows.length; i++) {
                    strRowIDs += "," + rows[i]; // alert(rows[i]);
                }


                $.ajax({ type: "POST",
                    url: "Backgdset.aspx/deletewarninginfoById",
                    data: "{'strRowIds':\"" + strRowIDs + "\"}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d == false) {
                            alert('删除失败');
                        } else {
                            alert('删除成功');
                        }
                        var p = [];
                        DotNetFlexGrid1.applyQueryReload(p);
                    }
                });

            } else {
                alert('请选中要删除的行');
            }
        }
        
        function updatewarningstatus() {
          
            var rows = FlexGrid1.getSelectedRowsIds();
            var strRowIDs = "";
            if (rows.length > 0) {
                strRowIDs = rows[0];

                for (var i = 1; i < rows.length; i++) {
                    strRowIDs += "," + rows[i]; // alert(rows[i]);
                }

               
                $.ajax({ type: "POST",
                    url: "Backgdset.aspx/updatewarninginfoById",
                    data: "{'strRowIds':\"" + strRowIDs + "\"}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d == false) {
                            alert('修改状态失败');
                        } else {
                            alert('修改状态成功');
                        }
                        var p = [];
                        FlexGrid1.applyQueryReload(p);
                    }
                });

            } else {
                alert('请选中要切换状态的行');
            }

        }

        function rupdatewarningstatus() {

            var rows = DotNetFlexGrid1.getSelectedRowsIds();
            var strRowIDs = "";
            if (rows.length > 0) {
                strRowIDs = rows[0];

                for (var i = 1; i < rows.length; i++) {
                    strRowIDs += "," + rows[i]; // alert(rows[i]);
                }


                $.ajax({ type: "POST",
                    url: "Backgdset.aspx/updatewarninginfoById",
                    data: "{'strRowIds':\"" + strRowIDs + "\"}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d == false) {
                            alert('修改状态失败');
                        } else {
                            alert('修改状态成功');
                        }
                        var p = [];
                        DotNetFlexGrid1.applyQueryReload(p);
                    }
                });

            } else {
                alert('请选中要切换状态的行');
            }

        }
        

        //泡药显示
        function updateDrugDisplayState() {

            var rows = DotNetFlexGrid2.getSelectedRowsIds();
            var strRowIDs = "";
            if (rows.length > 0) {
                strRowIDs = rows[0];

                for (var i = 1; i < rows.length; i++) {
                    strRowIDs += "," + rows[i]; // alert(rows[i]);
                }


                $.ajax({ type: "POST",
                    url: "Backgdset.aspx/updateDrugDisplayStateById",
                    data: "{'strRowIds':\"" + strRowIDs + "\"}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d == false) {
                            alert('修改状态失败');
                        } else {
                            alert('修改状态成功');
                        }
                        var p = [];
                        DotNetFlexGrid2.applyQueryReload(p);
                    }
                });

            } else {
                alert('请选中要切换状态的行');
            }

        }
        //煎药显示
        function updateChineseDisplayState() {

            var rows = DotNetFlexGrid2.getSelectedRowsIds();
            var strRowIDs = "";
            if (rows.length > 0) {
                strRowIDs = rows[0];

                for (var i = 1; i < rows.length; i++) {
                    strRowIDs += "," + rows[i]; // alert(rows[i]);
                }


                $.ajax({ type: "POST",
                    url: "Backgdset.aspx/updateChineseDisplayStateById",
                    data: "{'strRowIds':\"" + strRowIDs + "\"}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d == false) {
                            alert('修改状态失败');
                        } else {
                            alert('修改状态成功');
                        }
                        var p = [];
                        DotNetFlexGrid2.applyQueryReload(p);
                    }
                });

            } else {
                alert('请选中要切换状态的行');
            }

        }
        //发药显示
        function updateDrugSendDisplayState() {

            var rows = DotNetFlexGrid2.getSelectedRowsIds();
            var strRowIDs = "";
            if (rows.length > 0) {
                strRowIDs = rows[0];

                for (var i = 1; i < rows.length; i++) {
                    strRowIDs += "," + rows[i]; // alert(rows[i]);
                }


                $.ajax({ type: "POST",
                    url: "Backgdset.aspx/updateDrugSendDisplayStateById",
                    data: "{'strRowIds':\"" + strRowIDs + "\"}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d == false) {
                            alert('修改状态失败');
                        } else {
                            alert('修改状态成功');
                        }
                        var p = [];
                        DotNetFlexGrid2.applyQueryReload(p);
                    }
                });

            } else {
                alert('请选中要切换状态的行');
            }

        }








        function recipeCheckSelect1(obj) {
            recipeCheckValue = obj.value;
           // $("input[name='check']").eq(0).attr("checked", "checked");
         //   $("input[name='check']").eq(1).removeAttr("checked");

            var cb = document.getElementById('checkbox1'); //checkbox dom
            var cb2 = document.getElementById('checkbox2'); //checkbox dom
            if (cb.checked) {
              
               
                cb2.checked = false;
               
            }else{
           
               // cb.checked = false;
                cb2.checked = true;
            }



            $.ajax({ type: "POST",
                url: "Backgdset.aspx/isneedcheck",
                data: "{'id':'" + recipeCheckValue + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == 0) {

                        alert('修改不成功');
                    } else {
                        alert('修改成功');
                    }


                }
            });
        }


        function recipeCheckSelect2(obj) {
            recipeCheckValue = obj.value;
         //   $("input[name='check']").eq(1).attr("checked", "checked");
          //  $("input[name='check']").eq(0).removeAttr("checked");

            var cb = document.getElementById('checkbox1'); //checkbox dom
            var cb2 = document.getElementById('checkbox2'); //checkbox dom
            if (cb2.checked) {
              
                cb.checked = false;
              //  cb2.checked = false;

            }else{
           
              
                cb.checked = true;
               // cb2.checked = true;
            }


            $.ajax({ type: "POST",
                url: "Backgdset.aspx/isneedcheck",
                data: "{'id':'" + recipeCheckValue + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == 0) {

                        alert('修改不成功');
                    } else {
                        alert('修改成功');
                    }


                }
            });
        }




    </script>
</head>
<body>
    <form id="form1" runat="server">
   <%--医院预警 --%>
    <div class="formtitle"><span>医院预警</span></div>
      <div class="rightinfo">
    <div class="tools">   
    	<ul class="toolbar">
        <li class="click" ><a href="Backgdsetwarningtime.aspx"><span><img src="../../img/t05.png" /></span>添加</a></li>
        <li class="click" onclick="openDiv();"><span><img src="../../img/t02.png" /></span>修改</li>
        <li class="click" onclick="deletewarningInfo();"><span><img src="../../img/t03.png" /></span>删除</li>
        <li class="click" onclick="updatewarningstatus();"><span><img src="../../img/c01.png" /></span>改变开启状态</li>
        </ul>        
    </div>

    <uc1:dotNetFlexGrid ID="FlexGrid1" runat="server" />
    <%--医院滞留预警 --%>
    <div class="formtitle"><span>医院滞留预警</span></div>
      <div class="rightinfo">
    <div class="tools">   
    	<ul class="toolbar">
        <li class="click" ><a href="Backgdsetwarningtime.aspx"><span><img src="../../img/t05.png" /></span>添加</a></li>
        <li class="click" onclick="rOpenDiv();"><span><img src="../../img/t02.png" /></span>修改</li>
        <li class="click" onclick="rdeletewarningInfo();"><span><img src="../../img/t03.png" /></span>删除</li>
        <li class="click" onclick="rupdatewarningstatus();"><span><img src="../../img/c01.png" /></span>改变开启状态</li>
        </ul>        
    </div>

    <uc1:dotNetFlexGrid ID="DotNetFlexGrid1" runat="server" />
      <%--屏显设置 --%>

      <div class="formtitle"><span>屏显设置</span></div>
      <div class="rightinfo">
    <div class="tools">   
    	<ul class="toolbar">
        <li class="click" onclick="updateDrugDisplayState();"><span><img src="../../img/t02.png" /></span>设置医院的泡药屏显状态</li>
        <li class="click" onclick="updateChineseDisplayState();"><span><img src="../../img/t02.png" /></span>设置医院的煎药屏显状态</li>
        <li class="click" onclick="updateDrugSendDisplayState();"><span><img src="../../img/t02.png" /></span>设置医院的发药屏显状态</li>
        </ul>        
    </div>

    
    <uc1:dotNetFlexGrid ID="DotNetFlexGrid2" runat="server" />



     <div class="formtitle"><span>审核设置</span></div>
     <div class="rightinfo">
       <div class="tools"> 
       是否经过审核流程：
    <label class="label"><input class="label" id="checkbox1" runat="server" name="check" type="checkbox" value="1" onclick="recipeCheckSelect1(this);" style="margin-bottom:3px;" />经过审核流程</label> 

    <label class="label"><input class="label" id="checkbox2" runat="server" name="check" type="checkbox" value="2" onclick="recipeCheckSelect2(this);" style="margin-bottom:3px;"/>不经过审核流程</label> 


       </div>
       </div>
       </div>




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



            var url = "Backgdsetwarningupdate.aspx?id=" + rows + "&randomnumber=" + str;
            $("#flowtitle").text("处方信息");
            $("#p_b_body").load(url);

            $("#pop_div").OpenDiv();
        }
        function rOpenDiv() {
            var rows = DotNetFlexGrid1.getSelectedRowsIds();
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



            var url = "Backgdsetwarningupdate.aspx?id=" + rows + "&randomnumber=" + str;
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
        
    </script>





    </form>
</body>
</html>
