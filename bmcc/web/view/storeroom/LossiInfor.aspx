<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LossiInfor.aspx.cs" Inherits="view_storeroom_LossiInfor" %>
<%@ Register src="../../dotNetFlexGrid/dotNetFlexGrid.ascx" tagname="dotNetFlexGrid" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>baos</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
     <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/time.js"></script>
    <link href="../../css/hDate.css" rel="stylesheet" />
     <script type="text/javascript" src="../../js/jquery.date.js"></script>
   <script type="text/javascript" src="../../js/hDate.js"></script>
  <script language="javascript" type="text/javascript" src="../../js/My97DatePicker/WdatePicker.js"></script>
   <script type="text/javascript"language="javascript">
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript">
        //查询
        function searchCompInfo123() {
       
            var Type = $("#Type").val();

            var p = [{ name: "Type", value: Type }];
            FlexGridLossiInfor.applyQueryReload(p);

        }
       
       /* function toexcel() {
            alert('123423');
            function deleteDrugAdminInfo() {
                    $.ajax({ type: "POST",
                        url: "LossiInfor.aspx/toexcel",
                        data: "{'strRowIds':\"" + strRowIDs + "\"}",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            if (data.d == 0) {
                                alert('删除失败');
                            } else {
                                alert('删除成功');
                            }
                          
                        }
                    });          
        }*/

        function doReset() {

            $("select").val("0");
            for (i = 0; i < document.all.tags("input").length; i++) {
                if (document.all.tags("input")[i].type == "text") {
                    document.all.tags("input")[i].value = "";
                }

            }
            alert("置空成功！");
        }
        //作废
        function deleteInventoryInforInfo() {
            var rows = FlexGridLossiInfor.getSelectedRowsIds();
            var strRowIDs = "";
            if (rows.length > 0) {
                strRowIDs = rows[0];
            } else {
                alert("请选择需要作废的一行");
                return;
            }

            for (var i = 1; i < rows.length; i++) {
                strRowIDs += "," + rows[i]; // alert(rows[i]);
            }

            $.ajax({ type: "POST",
                url: "LossiInfor.aspx/deleteLossiInforById",
                data: "{'strRowIds':\"" + strRowIDs + "\"}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "0") {
                        alert('作废失败,');
                    } else {
                        alert('作废成功');
                    }

                    var p = [];
                    FlexGridLossiInfor.applyQueryReload(p);
                }
            });
        }
        //删除报损信息
        function deleteLossiInforInfo() {
      
        var rows = FlexGridLossiInfor.getSelectedRowsIds();
     
        var strRowIDs = "";
        if (rows.length > 0) {
            strRowIDs = rows[0];


            for (var i = 1; i < rows.length; i++) {
                strRowIDs += "," + rows[i]; // alert(rows[i]);
            }
            //alert(rows[i]);
            $.ajax({ type: "POST",
                url: "LossiInfor.aspx/deleteLossiInforById",
                data: "{'strRowIds':\"" + strRowIDs + "\"}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == false) {
                        alert('删除失败');
                    } else {
                        alert('删除成功');
                    }
                   
                    var p = [];
                    FlexGridStorage.applyQueryReload(p);
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

</head>
<body>
    <form id="form1" runat="server">
    
    <div class="rightinfo">
          
    <div class="tools">
    
    	<ul class="toolbar">
        
        <li class="click" onclick="searchCompInfo123();"><span><img src="../../img/t01.png" /></span>查询</li>
        <li class="click" onclick="addDiv();"><span><img src=" ../../img/t05.png " /></span>添加</li>
         <li class="click" onclick="UpdateDiv();"><span><img src="../../img/t02.png" /></span>修改信息</li>
         <li class="click" onclick="deleteLossiInforInfo();"><span><img src="../../img/t03.png" /></span>删除信息</li>
        <li class="click" onclick="doReset();"><span><img src="../../img/r01.png" /></span>重置</li>
       
      <%-- <li class="click" onclick="toexcel();"><span><img src="../../img/t04.png" /></span>导出数据</li> --%> 
   <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text='导出数据' CssClass="btn3"/>
        </ul>         
     
    </div>
    <ul class="forminfo">
     <li>
      
      <label>&nbsp;&nbsp;&nbsp;&nbsp;信息类别</label>
      <select class="dfinput2" id="Type" runat="server" name="hostpitalname" onChange="" style="text-align:center">
       <option value="0">全部</option>

            <option value="库房报损">库房报损单</option>
           
            <option value="库房报溢">库房报溢单</option>
            
         
        </select>
     
     </li>
   

   </ul> </div>
    <br />  
      
     <br />  
     <br />  
     <div >
     <uc1:dotNetFlexGrid ID="FlexGridLossiInfor" runat="server"  
   
      />   
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
        //入库单编辑
        function addDiv() {
            var rows = FlexGridLossiInfor.getSelectedRowsIds();

            var d = new Date(), str = '';

            t = d.getHours();
            str += (t > 9 ? "" : "0") + t;
            t = d.getMinutes();
            str += (t > 9 ? "" : "0") + t;
            t = d.getSeconds();
            str += (t > 9 ? "" : "0") + t;
            var url = "LossiInforGet.aspx?id=" + rows + "&randomnumber=" + str;
            $("#flowtitle").text("报损信息");
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

        //修改报损信息
        function UpdateDiv() {
            var rows = FlexGridLossiInfor.getSelectedRowsIds();
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

            var url = "LossiInforUpdate.aspx?id=" + rows + "&randomnumber=" + str;
            $("#flowtitle").text("修改报损信息");
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

   
