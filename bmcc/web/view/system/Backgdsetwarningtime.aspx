<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Backgdsetwarningtime.aspx.cs" Inherits="view_system_Backgdsetwarningtime" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/DatePicker.js"></script>



    <script language="javascript" type="text/javascript">
// <![CDATA[

        function btnAddOkClick() {

            var hospitalId = $("#hospitalSelect").val();
            var type = $("#type").val();
            
            var checkwarning = $("#checkwarning").val();
            var adjustwarning = $("#adjustwarning").val();
            var recheckwarning = $("#recheckwarning").val();
            var bubblewarning = $("#bubblewarning").val();
            var tisanewarning = $("#tisanewarning").val();
            var packwarning = $("#packwarning").val();
            var deliverwarning = $("#deliverwarning").val();


            if (hospitalId == "") {
                alert('请选择医院');
                return false;
            }
            else if (checkwarning == "") {
                alert('请输入审核预警时间');
                return false;
            }
            else if (adjustwarning == "") {
                alert('请输入调剂预警时间');
                return false;
            }
            else if (recheckwarning == "") {
                alert('请输入复核预警时间');
                return false;
            }
            else if (bubblewarning == "") {
                alert('请输入泡药预警时间');
                return false;
            }
            else if (tisanewarning == "") {
                alert('请输入煎药预警时间');
                return false;
            }
            else if (packwarning == "") {
                alert('请输入包装预警时间');
                return false;
            }
            else if (deliverwarning == "") {
                alert('请输入发货预警时间');
                return false;
            }
           

         
            $.ajax({ type: "POST",
                url: "Backgdsetwarningtime.aspx/addwarningtime",
                data: "{'hospitalId':" + hospitalId + ",'checkwarning':" + checkwarning + ",'adjustwarning':" + adjustwarning + ",'recheckwarning':" + recheckwarning + ",'bubblewarning':" + bubblewarning + ",'tisanewarning':" + tisanewarning + ",'packwarning':" + packwarning + ",'deliverwarning':" + deliverwarning + ",'type':" + type + "}",
               // data: "{'hospitalId':" + hospitalSelect + "}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    if (data.d == 0) {
                        alert('添加失败');
                    } else {
                        alert('添加成功');
                    }
                    var p = [];
                    FlexGrid1.applyQueryReload(p);
                }
            });




           








            return true;





        }


        function typeChange() {

            var value = $("#type").val();
            if (value == 1) {

                $("#checkwarning").val("10");
                $("#checkwarning_li").hide();
            } else {
 
                $("#checkwarning_li").show();
                $("#checkwarning").val("");
            }
        }



function update_onclick() {

}

// ]]>
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
    <li><a href="#">信息录入</a></li>
    </ul>

    </div>--%> 
    
     <div class="formtitle"><span>医院预警时间</span></div>
    
   <ul class="forminfo">
    <li><label>医院</label>
        <select id="hospitalSelect" runat="server" class="dfinput" name="hostpital" onChange="" style="text-align:center">
          <option value="" selected>&nbsp;&nbsp;全部&nbsp;&nbsp;</option>
        </select><i></i></li>
        <li><label>预警类型</label>
        <select id="type" runat="server" class="dfinput" name="hostpital" onchange="typeChange();" style="text-align:center">
          <option value="0" selected>&nbsp;&nbsp;医院预警&nbsp;&nbsp;</option>
          <option value="1">&nbsp;&nbsp;医院滞留预警&nbsp;&nbsp;</option>
        </select><i></i></li>
    <li id="checkwarning_li"><label>审核预警时间(min)</label><input id="checkwarning" runat="server" name="" type="text" class="dfinput"/></li>
    <li><label>调剂预警时间(min)</label><input id = "adjustwarning" runat="Server" name="" type="text" class="dfinput" /></li>
    <li><label>复核预警时间(min)</label><input id ="recheckwarning" runat="Server" name="" type="text" class="dfinput" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')" /></li>
    <li><label>泡药预警时间(min)</label><input id = "bubblewarning" runat="Server" name="" type="text" class="dfinput" /></li>
    <li><label>煎药预警时间(min)</label><input id ="tisanewarning" runat="Server" name="" type="text" class="dfinput" /></li>
    <li><label>包装预警时间(min)</label><input id ="packwarning" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
    <li><label>发货预警时间(min)</label><input id ="deliverwarning" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
    <li><label>&nbsp;</label><input id="update" runat="server" name="" type="button" class="btn" onclick="btnAddOkClick();" value="添加" />&nbsp;&nbsp;&nbsp;&nbsp;<input name="" type="button" class="btn" value="返回上一页"  onclick="javascript:history.go(-1)" /></li> 
    </ul>
    
   
  </form>
</body>
</html>