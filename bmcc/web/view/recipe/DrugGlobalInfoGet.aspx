<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DrugGlobalInfoGet.aspx.cs" Inherits="view_recipe_DrugGlobalInfoGet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />

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
             var num = /^\d{24}$/;


             var tisanebarcode = $("#tisanebarcode").val();
             var bubbleperson = $("#bubbleperson").val();
             var mark = $("#mark").val();
             var wateryield = $("#wateryield").val();
            
            if (tisanebarcode == "") {
                alert('请输入煎药条码');
            }else{
            if(bubbleperson==""){
            alert('请输入泡药人');
            }
            else {
                if (!num.test(document.getElementById("tisanebarcode").value)) {
                    alert("请输入24位数字");
                } else {

                    //alert('sdfsdf'+tisaneid);
                    $.ajax({ type: "POST",
                        url: "DrugGlobalInfoGet.aspx/addbubbleinfo",
                        data: "{'tisanebarcode':'" + tisanebarcode + "','bubbleperson':'" + bubbleperson + "','mark':'" + mark + "','wateryield':'" + wateryield + "'}",
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
                                alert('泡药完成，但分配机组失败');
                            }
                            if (data.d == 3) {
                                alert('该煎药单号不存在或已作废');
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
                                alert('泡药未完成');
                                for (i = 0; i < document.all.tags("input").length; i++) {
                                    if (document.all.tags("input")[i].type == "text") {
                                        document.all.tags("input")[i].value = "";
                                    }
                                }
                            }
                            if (data.d == 6) {
                                alert('泡药完成，且分配机组成功');
                                for (i = 0; i < document.all.tags("input").length; i++) {
                                    if (document.all.tags("input")[i].type == "text") {
                                        document.all.tags("input")[i].value = "";
                                    }
                                }
                            }
                            if (data.d == 7) {
                                alert('该煎药单号还没复核完成，不能开始泡药');
                                for (i = 0; i < document.all.tags("input").length; i++) {
                                    if (document.all.tags("input")[i].type == "text") {
                                        document.all.tags("input")[i].value = "";
                                    }
                                }
                            }

                          //  window.location.reload();
                           var p = [];
                            FlexGridDrugGlobal1.applyQueryReload(p);
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
    
    <div class="formtitle"><span>泡药信息</span></div>
    
   <ul class="forminfo">
    <li><input id ="idnum" runat="server" type="hidden" name="FunName"/> </li>
    <li><label>煎药条码</label><input id="tisanebarcode" runat="Server" name="" type="text"  class="dfinput" /><i></i></li> 
    <li><label>泡药人员</label> <select id="bubbleperson" runat="server" name="sect" type="text" class="dfinput" style="text-align:center"  readonly="readonly" ></select></li> 
    <%-- <input id="bubbleperson" runat="Server" name="" type="text"  class="dfinput" /><i></i></li> --%>
    <li><label>实际加水量</label><input id="wateryield" runat="Server" name="" type="text"  class="dfinput" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/><i></i></li> 
    <li><label>备注</label><input id="mark" runat="Server" name="" type="text"  class="dfinput" /><i></i></li> 
      
    <li><label>&nbsp;</label>
    <input id="btnok" runat="server" name="" type="button" class="btn" onclick=" btnok_onclick();" value="确认" />
    
    </li>
    </ul>
    
   </div>
  </form>
</body>
</html>
