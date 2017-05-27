<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeGet.aspx.cs" Inherits="view_system_EmployeeGet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function btnok_onclick() {

            var JobNum = $("#JobNum11").val();
            var EName = $("#EName11").val();
            var Role = $("#Role11").val();
            var Age = $("#Age11").val();
            var Sex = $("#Sex11").val();
            var Nation = $("#Nation11").val();
            var Phone = $("#Phone11").val();
            var Address = $("#Address11").val();
            var Origin = $("#Origin11").val();
            var password = $("#password11").val();
            //alert(JobNum);
            var num = /^\d{4}$/;
            if (JobNum == "") {
                alert('请输入员工工号！');
                return false;
            } else if (!num.test(document.getElementById("JobNum11").value)) {
                alert("请输入4位员工工号！");
                return false;

            } 
            else if (EName =="") {
                alert("请输入员工姓名！");
                return false;

            }
            
            else if (Age=="") {
                alert("请输入年龄！");
                return false;

            }
            else if (Nation=="") {
                alert("请输入民族!");
                return false;

            }
            else if (Phone=="") {
                alert("请输入电话！");
                return false;
            }

            else if (Address=="") {
                alert("请输入地址！");
                return false;

            }
            else if (Origin=="") {
                alert("请输入籍贯！");
                return false;

            } else if (password == "") {
                alert("请输入密码！");
                return false;

            }
            
            $.ajax({ type: "POST",
                url: "EmployeeGet.aspx/addEmployeeinfo",
                data: "{'JobNum':'" + JobNum + "','EName':'" + EName + "','Role':'" + Role + "','Age':'" + Age + "','Sex':'" + Sex + "','Nation':'" + Nation + "','Phone':'" + Phone + "','Address':'" + Address + "','Origin':'" + Origin + "','password':'" + password + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "0") {
                        alert('添加失败');

                    } else {
                        alert('添加成功');
                        for (i = 0; i < document.all.tags("input").length; i++) {
                            if (document.all.tags("input")[i].type == "text") {
                                document.all.tags("input")[i].value = "";
                            }
                        }  
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
    
    <div class="formtitle"><span>员工信息</span></div>
    
   <ul class="forminfo">
    
    <li><label>员工工号</label><input id="JobNum11" runat="Server" name="" type="text" class="dfinput2"   onkeyup="this.value=this.value.replace(/[^\d]/ig,'')" />
    <label>员工姓名</label><input id="EName11" runat="server" name="" type="text" class="dfinput2"/></li>
    <li><label>角&nbsp;&nbsp;&nbsp;&nbsp;色</label>
        <select id="Role11" runat="Server" class="dfinput2">
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
        </select>
       
    
     <label>年&nbsp;&nbsp;&nbsp;&nbsp;龄</label><input id ="Age11" runat="Server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')" /></li>
    <li><label>性&nbsp;&nbsp;&nbsp;&nbsp;别</label>
    <select id="Sex11" runat="server" class="dfinput2" name="Employee" onChange="" style="text-align:center">
        </select>
   
    <label>民&nbsp;&nbsp;&nbsp;&nbsp;族</label><input id="Nation11" runat="Server" name="" type="text" class="dfinput2" /><i></i></li>
    <li><label>电&nbsp;&nbsp;&nbsp;&nbsp;话</label><input id ="Phone11" runat="Server" name="" type="text" class="dfinput2" />
    <label>住&nbsp;&nbsp;&nbsp;&nbsp;址</label><input id ="Address11" runat="Server" name="" type="text" class="dfinput2" /></li>
    <li><label>籍&nbsp;&nbsp;&nbsp;&nbsp;贯</label><input id ="Origin11" runat="Server" name="" type="text" class="dfinput2" />
    <label>默认密码</label><input id ="password11" runat="Server" name="" type="text" class="dfinput2" value = "123"/></li>
    <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" type="button" class="btn" value="确认" onclick=" btnok_onclick();"/></li>
    </ul>
   </div> 
   
  </form>
</body>
</html>