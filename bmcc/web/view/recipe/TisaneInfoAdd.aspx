<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TisaneInfoAdd.aspx.cs" Inherits="view_recipe_TisaneInfoAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">

        function addOkClick() {
            var num = /^\d{24}$/;

            var tisanebarcode = $("#tisanebarcode").val();
            var tisaneperson = $("#tisaneperson").val();
            var mark = $("#mark").val();

           
            if (tisanebarcode == "") {
                alert('请输入煎药条码');
            } else {
                if (tisaneperson == "") {
                    alert('请输入煎药人');
                }
                else {
                    if (!num.test(document.getElementById("tisanebarcode").value)) {
                        alert("请输入24位数字");
                    } else {

                        //alert('sdfsdf'+tisaneid);
                        $.ajax({ type: "POST",
                            url: "TisaneInfoAdd.aspx/addtisaneinfo",
                            data: "{'tisanebarcode':'" + tisanebarcode + "','tisaneperson':'" + tisaneperson + "','mark':'" + mark + "'}",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                //  alert('fdsafdsfdasfdasfdasf');
                                // alert(data.d)

                                if (data.d == 0) {
                                    alert('添加失败');
                                    for (i = 0; i < document.all.tags("input").length; i++) {
                                        if (document.all.tags("input")[i].type == "text") {
                                            document.all.tags("input")[i].value = "";
                                        }
                                    }  
                                }
                                if (data.d == 1) {
                                    alert('添加成功');
                                    for (i = 0; i < document.all.tags("input").length; i++) {
                                        if (document.all.tags("input")[i].type == "text") {
                                            document.all.tags("input")[i].value = "";
                                        }
                                    }  
                                }
                                if (data.d == 2) {
                                    alert('煎药完成');
                                    for (i = 0; i < document.all.tags("input").length; i++) {
                                        if (document.all.tags("input")[i].type == "text") {
                                            document.all.tags("input")[i].value = "";
                                        }
                                    }  
                                }
                                if (data.d == 3) {
                                    alert('该煎药单号不存在或已作废');
                                    for (i = 0; i < document.all.tags("input").length; i++) {
                                        if (document.all.tags("input")[i].type == "text") {
                                            document.all.tags("input")[i].value = "";
                                        }
                                    }  
                                }
                                if (data.d == 4) {
                                    alert('该煎药单号已被完成');
                                    for (i = 0; i < document.all.tags("input").length; i++) {
                                        if (document.all.tags("input")[i].type == "text") {
                                            document.all.tags("input")[i].value = "";
                                        }
                                    }  
                                }
                                if (data.d == 5) {
                                    alert('煎药未成功');
                                    for (i = 0; i < document.all.tags("input").length; i++) {
                                        if (document.all.tags("input")[i].type == "text") {
                                            document.all.tags("input")[i].value = "";
                                        }
                                    }  
                                }
                                if (data.d == 6) {
                                    alert('该煎药单号还没泡药完成，不能开始煎药');
                                    for (i = 0; i < document.all.tags("input").length; i++) {
                                        if (document.all.tags("input")[i].type == "text") {
                                            document.all.tags("input")[i].value = "";
                                        }
                                    }  
                                }

                                var p = [];
                               dotNetFlexGrid1.applyQueryReload(p);
                            }
                        });
                    }
                }

            }
        }
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
     <div class="formbody">
    
    <div class="formtitle"><span>煎药信息</span></div>
    <input id ="idnum" runat="server" type="hidden" name="FunName"/> 
    <ul class="forminfo">
    
    <li><label>煎药单条码</label>
         <input id="tisanebarcode" runat="server" name="" type="text" class="dfinput"/></li>
    <li><label>煎药人员</label> <select id="tisaneperson" runat="server" name="sect" type="text" class="dfinput" style="text-align:center"  readonly="readonly" ></select></li> 
    <%-- <input id="tisaneperson" runat="Server" name="" type="text"  class="dfinput" /><i></i></li> 
    <li><label>备注</label><input id="mark" runat="Server" name="" type="text"  class="dfinput" /><i></i></li> --%>
    <li><label>&nbsp;</label><input id="add" runat="server" name="" type="button" class="btn" onclick="addOkClick();" value="添加" /></li>
    </ul>
     </div>
    </form>
</body>
</html>
