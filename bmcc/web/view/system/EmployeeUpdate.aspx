<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeUpdate.aspx.cs" Inherits="view_system_EmployeeUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>员工信息修改</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
     <script language="javascript" type="text/javascript">

         function btnRecipeOkClick() {
             var id = $("#idnum1").val();
             var JobNum = $("#JobNum1").val();
             var EName = $("#EName1").val();
             var Role = $("#Role1").val();
             var Age = $("#Age1").val();
             var Sex = $("#Sex1").val();
              
             var Nation = $("#Nation1").val();
             var Phone = $("#Phone1").val();
             var Address = $("#Address1").val();
             var Origin = $("#Origin1").val();
             //alert(JobNum);
             var password = $("#password1").val();
             var num = /^\d{4}$/;
             if (!num.test(document.getElementById("JobNum1").value)) {
                 alert("请输入4位员工工号！");
                 return false;

             } 
            

             $.ajax({ type: "POST",
                 url: "EmployeeUpdate.aspx/EmployeeInfo",
                 data: "{'id':'" + id + "','JobNum':'" + JobNum + "','EName':'" + EName + "','Role':'" + Role + "','Age':'" + Age + "','Sex':'" + Sex + "','Nation':'" + Nation + "','Phone':'" + Phone + "','Address':'" + Address + "','Origin':'" + Origin + "','password':'" + password + "'}",
                 contentType: "application/json; charset-=utf-8",
                 success: function (data) {
                     if (data.d == "0") {
                         alert('修改失败,员工号已存在！');

                     } else {
                         alert('修改成功！');
                     }
                     var p = [];
                     FlexGridEmployee.applyQueryReload(p);
                 }
             });
             return true;
         }
       
    </script>
</head>
<body>
   <form id="form1" runat="server">
    <div style="overflow:scroll; width:570px; height:430px;">
    <input id ="idnum1" runat="server" type="hidden" name="FunName"/> 
   
    
   <ul class="forminfo">
    <li><label>员工工号</label><input id="JobNum1" runat="Server" name="" type="text" class="dfinput"  onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/><i></i></li>
    <li><label>员工姓名</label><input id="EName1" runat="server" name="" type="text" class="dfinput"/></li>
    <%-- <li><label>角色</label><input id = "Role1" runat="Server" name="" type="text" class="dfinput" /></li>--%>
    <li><label>角&nbsp;&nbsp;&nbsp;&nbsp;色</label>
        <select id="Role1" runat="Server" class="dfinput">
            <option value="0">管理员</option>

        
            <option value="8">配方人员</option>
            <option value="1">调剂人员</option>
            <option value="2">复核人员</option>
            <option value="3">泡药人员</option>
            <option value="4">煎药人员</option>
            <option value="5">包装人员</option>
            <option value="6">发货人员</option>

            <option value="7">接方人员</option>
            <option value="9">医院人员</option>
            <option value="10">医院登录人员</option>

    </select></li>
    <li><label>年龄</label><input id ="Age1" runat="Server" name="" type="text" class="dfinput" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')" /></li>
    <li><label>性别</label>
    <select id="Sex1" runat="server" class="dfinput" name="Employee" onChange="" style="text-align:center">
        </select>
    </li>
    <li><label>民族</label><input id="Nation1" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
    <li><label>电话</label><input id ="Phone1" runat="Server" name="" type="text" class="dfinput" /></li>
    <li><label>住址</label><input id ="Address1" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
     <li><label>籍贯</label><input id ="Origin1" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
      <li><label>密码</label><input id ="password1" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
    <li><label>&nbsp;</label><input id="btnok1" runat="Server" name="" type="button" class="btn" value="确认" onclick="btnRecipeOkClick();"/></li>
    </ul>
    
   </div>
  </form>
</body>
</html>