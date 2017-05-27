<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Updatemachine.aspx.cs" Inherits="view_system_Updatemachine" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function btnok_onclick() {

            var meRoomName = $("#meRoomName").val();
            var unitnum = $("#unitnum").val();
            var typeofmachine = $("#typemachine").val();
            var machinenum = $("#machinenum").val();
            var macaddresss = $("#macaddresss").val();
            var idnum = $("#idnum").val();



            var status = $("#status").val();
            var openstatus = $("#openstatus").val();
            var healthystatus = $("#healthystatus").val();
            var disinfectionstatus = $("#disinfectionstatus").val();

            var checkman = $("#checkman").val();
            var checktime = $("#checktime").val();
            var equipmenttype = $("#equipmenttype").val();

          
            if (meRoomName == "0") {
                alert('请选择煎药机室');
                return false;
            } else if (unitnum == "") {
                alert('请输入机组编号');
                return false;
            } else if (typeofmachine == "3") {
                alert('请选择类型');
                return false;
            } else if (machinenum == "") {
                alert('请输入机器编号');
                return false;
            } else if (equipmenttype == "0") {
                alert('设备类型');
                return false;
            }
             else if (macaddresss == "") {
                alert('请输入mac地址');
                return false;
            } else if (status == "0") {
                alert('请选择状态');
                return false;
            } else if (openstatus == "0") {
                alert('请选择开启状态');
                return false;
            } else if (healthystatus == "0") {
                alert('请选择卫生状态');
                return false;
            } else if (disinfectionstatus == "0") {
                alert('请选择消毒状态');
                return false;
            } else if (checkman == "") {
                alert('请选择巡检员');
                return false;
            } else if (checktime == "") {
                alert('请选择巡检时间');
                return false;
            } 



            $.ajax({ type: "POST",
                url: "Updatemachine.aspx/updateMachineinfo",
                data: "{'meRoomName':'" + meRoomName + "','unitnum':'" + unitnum + "','machinenum':'" + machinenum + "','macaddresss':'" + macaddresss + "','typeofmachine':'" + typeofmachine + "','idnum':'" + idnum + "','status':'" + status + "','openstatus':'" + openstatus + "','disinfectionstatus':'" + disinfectionstatus + "','healthystatus':'" + healthystatus + "','checkman':'" + checkman + "','checktime':'" + checktime + "','equipmenttype':'" + equipmenttype + "'}",
                // "','SendTime':'" + SendTime +
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    if (data.d == "2") {
                        alert('修改失败！');

                    } else if (data.d == "3") {
                        alert('没有该记录！');

                    } else if (data.d == "4") {
                        alert('修改失败,该机组已存在包装机');

                    } else {
                        alert('修改成功！');
                        var p = [];
                        FlexGridDrugGlobal.applyQueryReload(p);
                    }
                   
                }
            });


            return true;


        }
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div style="overflow:scroll; width:570px; height:430px;">
   <div class="formbody">
    
     <div class="formtitle"><span>更新机器信息</span></div>
    
    <ul class="forminfo">
    
     <input id ="idnum" runat="server" type="hidden" name="FunName"/> 
    <li><label>煎药室</label><select id="meRoomName" runat="server" class="dfinput" name="" onchange="hospitalSelectChange(this);" style="text-align:center">
    <option value="0" selected>&nbsp;&nbsp;---请选择---&nbsp;&nbsp;</option>    
    </select> </li>

     <li><label>机组编号</label><input id ="unitnum" runat="Server" name="" type="text" class="dfinput" /></li>

    <li><label>类型</label><select id="typemachine" runat="server" class="dfinput" name="" onchange="hospitalSelectChange(this);" style="text-align:center">
    <option value="3" selected>&nbsp;&nbsp;---请选择---&nbsp;&nbsp;</option>    
    </select> </li>


   <li><label>机器编号</label><input id ="machinenum" runat="Server" name="" type="text" class="dfinput" /></li>

    <li><label>设备类型</label><select id="equipmenttype" runat="server" class="dfinput" name="" onchange="hospitalSelectChange(this);" style="text-align:center">
    <option value="0" selected>&nbsp;&nbsp;---请选择---&nbsp;&nbsp;</option>  
     <option value="十功能煎药" >十功能煎药</option>  
     <option value="YB-500包装机" >YB-500包装机</option>  
    </select>
   
   </li>

   <li><label>mac地址</label><input id ="macaddresss" runat="Server" name="" type="text" class="dfinput" /></li>

     <li><label>状态</label><select id="status" runat="server" class="dfinput" name="" onchange="hospitalSelectChange(this);" style="text-align:center">
    <option value="0" selected>&nbsp;&nbsp;---请选择---&nbsp;&nbsp;</option>   
    <option value="空闲" >&nbsp;&nbsp;空闲&nbsp;&nbsp;</option>   
    <option value="忙碌" >&nbsp;&nbsp;忙碌&nbsp;&nbsp;</option>   
    <option value="故障" >&nbsp;&nbsp;故障&nbsp;&nbsp;</option>    
    </select></li>

   <li> <label>启用状态</label><select id="openstatus" runat="server" class="dfinput" name="" onchange="hospitalSelectChange(this);" style="text-align:center">
    <option value="0" selected>&nbsp;&nbsp;---请选择---&nbsp;&nbsp;</option>    
     <option value="启用" >启用</option>   
    <option value="停用" >停用</option>   
    </select></li>

   <li> <label>卫生状态</label><select id="healthystatus" runat="server" class="dfinput" name="" onchange="hospitalSelectChange(this);" style="text-align:center">
    <option value="0" selected>&nbsp;&nbsp;---请选择---&nbsp;&nbsp;</option>  
     <option value="未清洁" >未清洁</option>  
     <option value="已清洁" >已清洁</option>    
    </select></li>

   <li> <label>消毒状态</label><select id="disinfectionstatus" runat="server" class="dfinput" name="" onchange="hospitalSelectChange(this);" style="text-align:center">
    <option value="0" selected>&nbsp;&nbsp;---请选择---&nbsp;&nbsp;</option>    
     <option value="未消毒" >未消毒</option>  
     <option value="已消毒" >已消毒</option>    
    </select>
    </li>

    <li>
    <label>巡检员</label><input id ="checkman" runat="Server" name="" type="text" class="dfinput" /></li>
   <li> <label>巡检时间</label><input id="checktime" runat="server" name="" type="text" class="dfinput" onfocus="calendar.show({ id: this });"/></li>
   
    <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" type="button" class="btn" value="确认" onclick=" btnok_onclick();"/></li>

    </ul>
    </div>
   </div>
  </form>
</body>
</html>