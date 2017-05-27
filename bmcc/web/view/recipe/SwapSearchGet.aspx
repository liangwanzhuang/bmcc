<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SwapSearchGet.aspx.cs" Inherits="view_recipe_SwapSearchGet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        function hospitalSelectChange(select) {
            var id = $(select).val();
            $("#recipeSelect option").remove();
              alert(id);
            if (id != 0) {
                $.ajax({ type: "POST",
                    url: "SwapSearchGet.aspx/getNumByNAMEId",
                    data: "{'SwapPer':" + id + "}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        var datas = data.d.split(";");
                        alert();
                        $("#SwapPer").val(datas[0]);
                        // $("#delnum").val(datas[1]);

                    }
                });
            }
        }

        $(function () {
            var userid = $("#userid").val();
            if (userid.length == 0) {
              //  alert("登录失效,请重新登录");
              //  history.go(-1);
            } else {

                $("#userid").val("0")
            }


        });
        function btnok_onclick() {
            var userid = $("#userid").val();
            var barcode = $("#barcode").val();
            var SwapPer = $("#SwapPer").val();
            //var wordcontent = $("#wordcontent").val();
           // var Workload = $("#Workload").val();
            userid = 1;

            var num = /^\d{24}$/;

            if (barcode == "") {
                alert('请输入煎药条码！');
                return false;
            } else if (!num.test(document.getElementById("barcode").value)) {
                alert("请输入24位数字！");
                return false;

            }/* else if (SwapPer == "") {
                alert("请输入调剂人员！");
                return false;
            } else if (wordcontent == "") {
                alert("请输入工作内容！");
                return false;
            } else if (Workload == "") {
                alert("请输入工作量！")
                return false;
            }*/

            $.ajax({ type: "POST",
                url: "SwapSearchGet.aspx/addAdjust",
                data: "{'userid':'" + userid + "','barcode':'" + barcode + "','SwapPer':'" + SwapPer + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    //  alert('fdsafdsfdasfdasfdasf');
                    // alert(data.d)

                    if (data.d != 0) {
                        alert('添加成功');
                        for (i = 0; i < document.all.tags("input").length; i++) {
                            if (document.all.tags("input")[i].type == "text") {
                                document.all.tags("input")[i].value = "";
                            }

                        }
                    } else {

                        alert('此条码不存在或已调剂完成或未审核完成，添加失败');
                        for (i = 0; i < document.all.tags("input").length; i++) {
                            if (document.all.tags("input")[i].type == "text") {
                                document.all.tags("input")[i].value = "";
                            }

                        }
                    }
                  //  window.location.reload();
                    var p = [];
                    FlexGridRecipe.applyQueryReload(p);
                }
            });

            return true;
        }
        /*function subFun() {
            var userid = $("#userid").val();
            var wordDate = $("#Date").val();
            var barcode = $("#barcode").val();
            var wordcontent = $("#wordcontent").val();
            userid = 1;

            $.ajax({ type: "POST",
                url: "SwapSearchGet.aspx/addAdjust",
                data: "{'userid':'" + userid + "','wordDate':'" + wordDate + "','barcode':'" + barcode + "','wordcontent':'" + wordcontent + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d != 0) {
                        alert('操作成功');
                        history.go(-1);
                    } else {

                        alert('操作失败');
                    }
                }
            });
        }*/
    </script>
</head>
<body>
    <form id="form1" runat="server">
  
    
     <div class="formtitle"><span>调剂查询信息录入</span></div>
    <input id ="userid" runat="server" type="hidden" name="userid"/> 
   <ul class="forminfo">
       <li><label>条码</label><input id="barcode" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
      <li><label>调剂人员</label>
      <select id="SwapPer" runat="server" name="sect" type="text" class="dfinput" style="text-align:center"  readonly="readonly" ></select></li> 
   <%--<li><input id="a" runat="server" name="" type="text" class="dfinput" /></li>

      <li><label>工作内容</label><input id="wordcontent" runat="Server" name="" type="text"  class="dfinput" /><i></i></li>
       <li><label>工作量</label><input id="Workload" runat="Server" name="" type="text"  class="dfinput" /><i></i></li> --%> 
    <li><label>&nbsp;</label><input id="btnok" name="" onclick=" btnok_onclick();" type="button" class="btn" value="确认" /></li>
    </ul>
    
   
  </form>
</body>
</html>
