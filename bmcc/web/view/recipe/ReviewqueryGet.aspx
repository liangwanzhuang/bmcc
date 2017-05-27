<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReviewqueryGet.aspx.cs" Inherits="view_recipe_ReviewqueryGet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".click").click(function () {
                $(".tip").fadeIn(200);
            });

            $(".tiptop a").click(function () {
                $(".tip").fadeOut(200);
            });

            $(".sure").click(function () {
                $(".tip").fadeOut(100);
            });

            $(".cancel").click(function () {
                $(".tip").fadeOut(100);
            });

        });


        function btnok_onclick() {

            var DecoctingNum = $("#DecoctingNum").val();
            var ReviewPer = $("#ReviewPer").val();
            var num = /^\d{24}$/;

            if (DecoctingNum == "") {
                alert('请输入煎药条码');
                return false;
            } else if (!num.test(document.getElementById("DecoctingNum").value)) {
                alert("请输入24位数字");
                return false;

            } else if (ReviewPer == "") {
                alert("请输入复核人员");
            return false;
            }
            


            //alert(DecoctingNum);
            $.ajax({ type: "POST",
                url: "ReviewqueryGet.aspx/addReviewinfo",
                data: "{'DecoctingNum':'" + DecoctingNum +"','ReviewPer':'"+ReviewPer+"'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    //  alert('fdsafdsfdasfdasfdasf');
                    // alert(data.d)

                    if (data.d == "0") {
                        alert('添加失败，此处方未调剂完成或已添加');

                    } else {
                        alert('添加成功');
                    }
                    var p = [];
                    dotNetFlexGrid3.applyQueryReload(p);
                }
            });

            return true;
        }

    </script>
    
</head>
<body>
    <form id="form1" runat="server">

    
    <div class="formbody">
    
    <div class="formtitle"><span>复核查询信息</span></div>
    
    <ul class="forminfo">
   
   
       <li><label>煎药条码</label><input id="DecoctingNum" runat="Server" name="" type="text"  class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')" /><i></i></li> 
       <li><label>复核人员</label><select id="ReviewPer" runat="server" name="sect" type="text" class="dfinput2" style="text-align:center"  readonly="readonly" ></select></li> 
       
       
       <%-- <input id ="ReviewPer" runat ="server" name="" type="text" class="dfinput2"/></li>--%>
    <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" type="button" class="btn" value="确认" onclick=" btnok_onclick();"/></li>
    </ul>
    
    
    </div>
    </form>
</body>
</html>
