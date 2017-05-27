<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print.aspx.cs" Inherits="view_system_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="../../js/jquery.js"></script>

     <script type="text/javascript">


         $(function () {

             var id = 1;
             //|| txts[i].type=="text"
             var txts = document.getElementsByTagName("input");
             for (var i = 0; i < txts.length; i++) {
                 if (txts[i].type == "checkbox") {

                     txts[i].checked = false;
                 }
             }



             if (id != 0) {
                 $.ajax({ type: "POST",
                     url: "Print.aspx/getstatus",
                     data: "{'bartype':" + id + "}",
                     contentType: "application/json; charset=utf-8",
                     success: function (data) {
                         var datas = data.d.split(",");


                         if (datas[0] == "0") {
                             var cb2 = document.getElementById('checkbox2'); //checkbox dom
                             cb2.checked = true;
                         }
                         if (datas[0] == "1") {
                             var cb1 = document.getElementById('checkbox1'); //checkbox dom
                             cb1.checked = true;

                         }

                         if (datas[1] == "1") {
                             var cb18 = document.getElementById('checkbox18'); //checkbox dom
                             cb18.checked = true;
                         }
                         if (datas[2] == "1") {
                             var cb19 = document.getElementById('checkbox19'); //checkbox dom
                             cb19.checked = true;
                         }
                         if (datas[3] == "1") {
                             var cb3 = document.getElementById('checkbox3'); //checkbox dom
                             cb3.checked = true;
                         }
                         if (datas[4] == "1") {
                             var cb4 = document.getElementById('checkbox4'); //checkbox dom
                             cb4.checked = true;
                         }
                         if (datas[5] == "1") {
                             var cb5 = document.getElementById('checkbox5'); //checkbox dom
                             cb5.checked = true;
                         }
                         if (datas[6] == "1") {
                             var cb6 = document.getElementById('checkbox6'); //checkbox dom
                             cb6.checked = true;
                         }
                         if (datas[7] == "1") {
                             var cb7 = document.getElementById('checkbox7'); //checkbox dom
                             cb7.checked = true;
                         }
                         if (datas[8] == "1") {
                             var cb8 = document.getElementById('checkbox8'); //checkbox dom
                             cb8.checked = true;
                         }
                         if (datas[9] == "1") {
                             var cb9 = document.getElementById('checkbox9'); //checkbox dom
                             cb9.checked = true;
                         }
                         if (datas[10] == "1") {
                             var cb10 = document.getElementById('checkbox10'); //checkbox dom
                             cb10.checked = true;

                         }
                         if (datas[11] == "1") {
                             var cb11 = document.getElementById('checkbox11'); //checkbox dom
                             cb11.checked = true;

                         }
                         if (datas[12] == "1") {
                             var cb12 = document.getElementById('checkbox12'); //checkbox dom
                             cb12.checked = true;

                         }
                         if (datas[13] == "1") {
                             var cb13 = document.getElementById('checkbox13'); //checkbox dom
                             cb13.checked = true;

                         }

                         if (datas[14] == "1") {
                             var cb14 = document.getElementById('checkbox14'); //checkbox dom
                             cb14.checked = true;

                         }
                         if (datas[15] == "1") {
                             var cb15 = document.getElementById('checkbox15'); //checkbox dom
                             cb15.checked = true;

                         }
                         if (datas[16] == "1") {
                             var cb16 = document.getElementById('checkbox16'); //checkbox dom
                             cb16.checked = true;

                         }
                         if (datas[17] == "1") {
                             var cb17 = document.getElementById('checkbox17'); //checkbox dom
                             cb17.checked = true;

                         }

                     }
                 });
             }
         });

         function bartypeSelectChange(select) {
             var id = $(select).val();
             //|| txts[i].type=="text"
            var txts=document.getElementsByTagName("input");  
            for(var i=0;i <txts.length;i++)  
            {
                if (txts[i].type == "checkbox") {

                    txts[i].checked = false;  
                }  
            }  


               
            if (id != 0) {
                $.ajax({ type: "POST",
                    url: "Print.aspx/getstatus",
                    data: "{'bartype':" + id + "}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        var datas = data.d.split(",");


                        if (datas[0] == "0") {
                            var cb2 = document.getElementById('checkbox2'); //checkbox dom
                            cb2.checked = true;
                        }
                        if (datas[0] == "1") {
                            var cb1 = document.getElementById('checkbox1'); //checkbox dom
                            cb1.checked = true;

                        }

                        if (datas[1] == "1") {
                            var cb18 = document.getElementById('checkbox18'); //checkbox dom
                            cb18.checked = true;
                        }
                        if (datas[2] == "1") {
                            var cb19 = document.getElementById('checkbox19'); //checkbox dom
                            cb19.checked = true;
                        }
                        if (datas[3] == "1") {
                            var cb3 = document.getElementById('checkbox3'); //checkbox dom
                            cb3.checked = true;
                        }
                        if (datas[4] == "1") {
                            var cb4 = document.getElementById('checkbox4'); //checkbox dom
                            cb4.checked = true;
                        }
                        if (datas[5] == "1") {
                            var cb5 = document.getElementById('checkbox5'); //checkbox dom
                            cb5.checked = true;
                        }
                        if (datas[6] == "1") {
                            var cb6 = document.getElementById('checkbox6'); //checkbox dom
                            cb6.checked = true;
                        }
                        if (datas[7] == "1") {
                            var cb7 = document.getElementById('checkbox7'); //checkbox dom
                            cb7.checked = true;
                        }
                        if (datas[8] == "1") {
                            var cb8 = document.getElementById('checkbox8'); //checkbox dom
                            cb8.checked = true;
                        }
                        if (datas[9] == "1") {
                            var cb9 = document.getElementById('checkbox9'); //checkbox dom
                            cb9.checked = true;
                        }
                        if (datas[10] == "1") {
                            var cb10 = document.getElementById('checkbox10'); //checkbox dom
                            cb10.checked = true;

                        }
                        if (datas[11] == "1") {
                            var cb11 = document.getElementById('checkbox11'); //checkbox dom
                            cb11.checked = true;

                        }
                        if (datas[12] == "1") {
                            var cb12 = document.getElementById('checkbox12'); //checkbox dom
                            cb12.checked = true;

                        }
                        if (datas[13] == "1") {
                            var cb13 = document.getElementById('checkbox13'); //checkbox dom
                            cb13.checked = true;

                        }
                       
                        if (datas[14] == "1") {
                            var cb14 = document.getElementById('checkbox14'); //checkbox dom
                            cb14.checked = true;

                        }
                        if (datas[15] == "1") {
                            var cb15 = document.getElementById('checkbox15'); //checkbox dom
                            cb15.checked = true;

                        }
                        if (datas[16] == "1") {
                            var cb16 = document.getElementById('checkbox16'); //checkbox dom
                            cb16.checked = true;

                        }
                        if (datas[17] == "1") {
                            var cb17 = document.getElementById('checkbox17'); //checkbox dom
                            cb17.checked = true;

                        }
                        
                    }
                });
             }
         }


         function recipeCheckSelect1(obj) {
            // recipeCheckValue = obj.value;
             // $("input[name='check']").eq(0).attr("checked", "checked");
             //   $("input[name='check']").eq(1).removeAttr("checked");


            // $("#bartype").val();
             var bartype = $("#bartype").val(); //调配单
             var cb1 = document.getElementById('checkbox1'); //checkbox dom
             var cb2 = document.getElementById('checkbox2'); //checkbox dom
           var id="0";
             if (cb1.checked) {
              id= "1";//打印
              cb2.checked = false;

             } else {
              id= "0";//不打印
             cb2.checked =true;
         } 

             $.ajax({ type: "POST",
                 url: "Print.aspx/changeprintstatus",
                 data: "{'id':'"+id+"','bartype':'"+bartype+"'}",
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
             // recipeCheckValue = obj.value;
             // $("input[name='check']").eq(0).attr("checked", "checked");
             //   $("input[name='check']").eq(1).removeAttr("checked");
             var bartype = $("#bartype").val(); //调配单
             var cb1 = document.getElementById('checkbox1'); //checkbox dom
             var cb2 = document.getElementById('checkbox2'); //checkbox dom
             var id = "";
             if (cb2.checked) {
                 id = "0"; //不打印
                 cb1.checked = false;

             } else {
                 id = "1"; //打印
                 cb1.checked = true;
             }

             $.ajax({ type: "POST",
                 url: "print.aspx/changeprintstatus",
                 data: "{'id':'" + id + "','bartype':'" + bartype + "'}",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     if (data.d == 1) {
                         alert('修改成功');
                     } else {
                         alert('修改不成功');
                     }
                 }
             });

         }


         function recipeCheckSelect3(obj) {
             // recipeCheckValue = obj.value;
             // $("input[name='check']").eq(0).attr("checked", "checked");
             //   $("input[name='check']").eq(1).removeAttr("checked");
             var bartype = $("#bartype").val(); //调配单
             var cb18 = document.getElementById('checkbox18'); //checkbox dom
             
             var id ="0";
             if (cb18.checked) {
                 id = "1"; //打印
                 

             } else {
                 id = "0"; //不打印
                 
             }

             $.ajax({ type: "POST",
                 url: "print.aspx/changeprintstatus3",
                 data: "{'id':'" + id + "','bartype':'" + bartype + "'}",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     if (data.d == 1) {
                         alert('修改成功');
                     } else {
                         alert('修改不成功');
                     }
                 }
             });

         }




         function recipeCheckSelect4(obj) {
             // recipeCheckValue = obj.value;
             // $("input[name='check']").eq(0).attr("checked", "checked");
             //   $("input[name='check']").eq(1).removeAttr("checked");
             var bartype = $("#bartype").val(); //调配单
             var cb19 = document.getElementById('checkbox19'); //checkbox dom

             var id = "0";
             if (cb19.checked) {
                 id = "1"; //打印


             } else {
                 id = "0"; //不打印

             }

             $.ajax({ type: "POST",
                 url: "print.aspx/changeprintstatus4",
                 data: "{'id':'" + id + "','bartype':'" + bartype + "'}",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     if (data.d == 1) {
                         alert('修改成功');
                     } else {
                         alert('修改不成功');
                     }
                 }
             });

         }


         function recipeCheckSelect5(obj) {
             // recipeCheckValue = obj.value;
             // $("input[name='check']").eq(0).attr("checked", "checked");
             //   $("input[name='check']").eq(1).removeAttr("checked");
             var bartype = $("#bartype").val(); //调配单
             var cb3 = document.getElementById('checkbox3'); //checkbox dom

             var id = "0";
             if (cb3.checked) {
                 id = "1"; //打印


             } else {
                 id = "0"; //不打印

             }

             $.ajax({ type: "POST",
                 url: "print.aspx/changeprintstatus5",
                 data: "{'id':'" + id + "','bartype':'" + bartype + "'}",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     if (data.d == 1) {
                         alert('修改成功');
                     } else {
                         alert('修改不成功');
                     }
                 }
             });

         }

         function recipeCheckSelect6(obj) {
             // recipeCheckValue = obj.value;
             // $("input[name='check']").eq(0).attr("checked", "checked");
             //   $("input[name='check']").eq(1).removeAttr("checked");
             var bartype = $("#bartype").val(); //调配单
             var cb4 = document.getElementById('checkbox4'); //checkbox dom

             var id = "0";
             if (cb4.checked) {
                 id = "1"; //打印


             } else {
                 id = "0"; //不打印

             }

             $.ajax({ type: "POST",
                 url: "print.aspx/changeprintstatus6",
                 data: "{'id':'" + id + "','bartype':'" + bartype + "'}",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     if (data.d == 1) {
                         alert('修改成功');
                     } else {
                         alert('修改不成功');
                     }
                 }
             });

         }


         function recipeCheckSelect7(obj) {
             // recipeCheckValue = obj.value;
             // $("input[name='check']").eq(0).attr("checked", "checked");
             //   $("input[name='check']").eq(1).removeAttr("checked");
             var bartype = $("#bartype").val(); //调配单
             var cb5 = document.getElementById('checkbox5'); //checkbox dom

             var id = "0";
             if (cb5.checked) {
                 id = "1"; //打印


             } else {
                 id = "0"; //不打印

             }

             $.ajax({ type: "POST",
                 url: "print.aspx/changeprintstatus7",
                 data: "{'id':'" + id + "','bartype':'" + bartype + "'}",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     if (data.d == 1) {
                         alert('修改成功');
                     } else {
                         alert('修改不成功');
                     }
                 }
             });

         }

         function recipeCheckSelect8(obj) {
             // recipeCheckValue = obj.value;
             // $("input[name='check']").eq(0).attr("checked", "checked");
             //   $("input[name='check']").eq(1).removeAttr("checked");
             var bartype = $("#bartype").val(); //调配单
             var cb6 = document.getElementById('checkbox6'); //checkbox dom

             var id = "0";
             if (cb6.checked) {
                 id = "1"; //打印


             } else {
                 id = "0"; //不打印

             }

             $.ajax({ type: "POST",
                 url: "print.aspx/changeprintstatus8",
                 data: "{'id':'" + id + "','bartype':'" + bartype + "'}",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     if (data.d == 1) {
                         alert('修改成功');
                     } else {
                         alert('修改不成功');
                     }
                 }
             });

         }


         function recipeCheckSelect9(obj) {
             // recipeCheckValue = obj.value;
             // $("input[name='check']").eq(0).attr("checked", "checked");
             //   $("input[name='check']").eq(1).removeAttr("checked");
             var bartype = $("#bartype").val(); //调配单
             var cb7 = document.getElementById('checkbox7'); //checkbox dom

             var id = "0";
             if (cb7.checked) {
                 id = "1"; //打印


             } else {
                 id = "0"; //不打印

             }

             $.ajax({ type: "POST",
                 url: "print.aspx/changeprintstatus9",
                 data: "{'id':'" + id + "','bartype':'" + bartype + "'}",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     if (data.d == 1) {
                         alert('修改成功');
                     } else {
                         alert('修改不成功');
                     }
                 }
             });

         }

         function recipeCheckSelect10(obj) {
             // recipeCheckValue = obj.value;
             // $("input[name='check']").eq(0).attr("checked", "checked");
             //   $("input[name='check']").eq(1).removeAttr("checked");
             var bartype = $("#bartype").val(); //调配单
             var cb8 = document.getElementById('checkbox8'); //checkbox dom

             var id = "0";
             if (cb8.checked) {
                 id = "1"; //打印


             } else {
                 id = "0"; //不打印

             }

             $.ajax({ type: "POST",
                 url: "print.aspx/changeprintstatus10",
                 data: "{'id':'" + id + "','bartype':'" + bartype + "'}",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     if (data.d == 1) {
                         alert('修改成功');
                     } else {
                         alert('修改不成功');
                     }
                 }
             });

         }



         function recipeCheckSelect11(obj) {
             // recipeCheckValue = obj.value;
             // $("input[name='check']").eq(0).attr("checked", "checked");
             //   $("input[name='check']").eq(1).removeAttr("checked");
             var bartype = $("#bartype").val(); //调配单
             var cb9 = document.getElementById('checkbox9'); //checkbox dom

             var id = "0";
             if (cb9.checked) {
                 id = "1"; //打印


             } else {
                 id = "0"; //不打印

             }

             $.ajax({ type: "POST",
                 url: "print.aspx/changeprintstatus11",
                 data: "{'id':'" + id + "','bartype':'" + bartype + "'}",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     if (data.d == 1) {
                         alert('修改成功');
                     } else {
                         alert('修改不成功');
                     }
                 }
             });

         }



         function recipeCheckSelect12(obj) {
             // recipeCheckValue = obj.value;
             // $("input[name='check']").eq(0).attr("checked", "checked");
             //   $("input[name='check']").eq(1).removeAttr("checked");
             var bartype = $("#bartype").val(); //调配单
             var cb10 = document.getElementById('checkbox10'); //checkbox dom

             var id = "0";
             if (cb10.checked) {
                 id = "1"; //打印


             } else {
                 id = "0"; //不打印

             }

             $.ajax({ type: "POST",
                 url: "print.aspx/changeprintstatus12",
                 data: "{'id':'" + id + "','bartype':'" + bartype + "'}",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     if (data.d == 1) {
                         alert('修改成功');
                     } else {
                         alert('修改不成功');
                     }
                 }
             });

         }

         function recipeCheckSelect13(obj) {
             // recipeCheckValue = obj.value;
             // $("input[name='check']").eq(0).attr("checked", "checked");
             //   $("input[name='check']").eq(1).removeAttr("checked");
             var bartype = $("#bartype").val(); //调配单
             var cb11 = document.getElementById('checkbox11'); //checkbox dom

             var id = "0";
             if (cb11.checked) {
                 id = "1"; //打印


             } else {
                 id = "0"; //不打印

             }

             $.ajax({ type: "POST",
                 url: "print.aspx/changeprintstatus13",
                 data: "{'id':'" + id + "','bartype':'" + bartype + "'}",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     if (data.d == 1) {
                         alert('修改成功');
                     } else {
                         alert('修改不成功');
                     }
                 }
             });

         }


         function recipeCheckSelect14(obj) {
             // recipeCheckValue = obj.value;
             // $("input[name='check']").eq(0).attr("checked", "checked");
             //   $("input[name='check']").eq(1).removeAttr("checked");
             var bartype = $("#bartype").val(); //调配单
             var cb12 = document.getElementById('checkbox12'); //checkbox dom

             var id = "0";
             if (cb12.checked) {
                 id = "1"; //打印


             } else {
                 id = "0"; //不打印

             }

             $.ajax({ type: "POST",
                 url: "print.aspx/changeprintstatus14",
                 data: "{'id':'" + id + "','bartype':'" + bartype + "'}",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     if (data.d == 1) {
                         alert('修改成功');
                     } else {
                         alert('修改不成功');
                     }
                 }
             });

         }

         function recipeCheckSelect15(obj) {
             // recipeCheckValue = obj.value;
             // $("input[name='check']").eq(0).attr("checked", "checked");
             //   $("input[name='check']").eq(1).removeAttr("checked");
             var bartype = $("#bartype").val(); //调配单
             var cb13 = document.getElementById('checkbox13'); //checkbox dom

             var id = "0";
             if (cb13.checked) {
                 id = "1"; //打印


             } else {
                 id = "0"; //不打印

             }

             $.ajax({ type: "POST",
                 url: "print.aspx/changeprintstatus15",
                 data: "{'id':'" + id + "','bartype':'" + bartype + "'}",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     if (data.d == 1) {
                         alert('修改成功');
                     } else {
                         alert('修改不成功');
                     }
                 }
             });

         }


         function recipeCheckSelect16(obj) {
             // recipeCheckValue = obj.value;
             // $("input[name='check']").eq(0).attr("checked", "checked");
             //   $("input[name='check']").eq(1).removeAttr("checked");
             var bartype = $("#bartype").val(); //调配单
             var cb14 = document.getElementById('checkbox14'); //checkbox dom

             var id = "0";
             if (cb14.checked) {
                 id = "1"; //打印


             } else {
                 id = "0"; //不打印

             }

             $.ajax({ type: "POST",
                 url: "print.aspx/changeprintstatus16",
                 data: "{'id':'" + id + "','bartype':'" + bartype + "'}",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     if (data.d == 1) {
                         alert('修改成功');
                     } else {
                         alert('修改不成功');
                     }
                 }
             });

         }



         function recipeCheckSelect17(obj) {
             // recipeCheckValue = obj.value;
             // $("input[name='check']").eq(0).attr("checked", "checked");
             //   $("input[name='check']").eq(1).removeAttr("checked");
             var bartype = $("#bartype").val(); //调配单
             var cb15 = document.getElementById('checkbox15'); //checkbox dom

             var id = "0";
             if (cb15.checked) {
                 id = "1"; //打印


             } else {
                 id = "0"; //不打印

             }

             $.ajax({ type: "POST",
                 url: "print.aspx/changeprintstatus17",
                 data: "{'id':'" + id + "','bartype':'" + bartype + "'}",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     if (data.d == 1) {
                         alert('修改成功');
                     } else {
                         alert('修改不成功');
                     }
                 }
             });

         }


         function recipeCheckSelect18(obj) {
             // recipeCheckValue = obj.value;
             // $("input[name='check']").eq(0).attr("checked", "checked");
             //   $("input[name='check']").eq(1).removeAttr("checked");
             var bartype = $("#bartype").val(); //调配单
             var cb16 = document.getElementById('checkbox16'); //checkbox dom

             var id = "0";
             if (cb16.checked) {
                 id = "1"; //打印


             } else {
                 id = "0"; //不打印

             }

             $.ajax({ type: "POST",
                 url: "print.aspx/changeprintstatus18",
                 data: "{'id':'" + id + "','bartype':'" + bartype + "'}",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     if (data.d == 1) {
                         alert('修改成功');
                     } else {
                         alert('修改不成功');
                     }
                 }
             });

         }

         function recipeCheckSelect19(obj) {
             // recipeCheckValue = obj.value;
             // $("input[name='check']").eq(0).attr("checked", "checked");
             //   $("input[name='check']").eq(1).removeAttr("checked");
             var bartype = $("#bartype").val(); //调配单
             var cb17 = document.getElementById('checkbox17'); //checkbox dom

             var id = "0";
             if (cb17.checked) {
                 id = "1"; //打印


             } else {
                 id = "0"; //不打印

             }

             $.ajax({ type: "POST",
                 url: "print.aspx/changeprintstatus19",
                 data: "{'id':'" + id + "','bartype':'" + bartype + "'}",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {
                     if (data.d == 1) {
                         alert('修改成功');
                     } else {
                         alert('修改不成功');
                     }
                 }
             });

         }
     </script>




</head>
<body>
    <form id="form1" runat="server">
    <%-- <div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">系统设置</a></li>
    <li><a href="#">系统设置</a></li>
    <li><a href="#">打印模块设置</a></li>
    </ul>
    </div>--%> 
     <div class="formtitle"><span>打印设置</span></div>
     <div class="rightinfo">
     <div><ul class="forminfo"><li>
     <label>条码类型</label> <select id="bartype" runat="server" name="sect" type="text" class="dfinput2" style="text-align:center" onchange="bartypeSelectChange(this);" readonly="readonly" >
      <option value="1" >&nbsp;&nbsp;调配单&nbsp;&nbsp;</option> 
      <option value="2" >&nbsp;&nbsp;调配单条码&nbsp;&nbsp;</option> 
      <option value="3" >&nbsp;&nbsp;包装单条码&nbsp;&nbsp;</option> 
      <option value="4" >&nbsp;&nbsp;煎药单条码&nbsp;&nbsp;</option> 
     </select> 
     </li>
     </ul>
     </div>
     <label>&nbsp;&nbsp;</label>
       <div class="tools">
      <label>&nbsp;&nbsp;</label>
       <label>是否打印：</label>
    <label class="label"><input class="label" id="checkbox1" runat="server" name="check" type="checkbox" value="1" onclick="recipeCheckSelect1(this);" style="margin-bottom:3px;" />打印</label> 

    <label class="label"><input class="label" id="checkbox2" runat="server" name="check" type="checkbox" value="2" onclick="recipeCheckSelect2(this);" style="margin-bottom:3px;"/>不打印</label> 
  

       </div>

   <ul style ="list-style:none;">
<li>
  <label class="label"><input class="label" id="checkbox18" runat="server" name="check" type="checkbox" value="1" onclick="recipeCheckSelect3(this);" style="margin-bottom:3px;" />患者姓名</label> 
  <label class="label"><input class="label" id="checkbox19" runat="server" name="check" type="checkbox" value="1" onclick="recipeCheckSelect4(this);" style="margin-bottom:3px;" />性别</label> 
  <label class="label"><input class="label" id="checkbox3" runat="server" name="check" type="checkbox" value="1" onclick="recipeCheckSelect5(this);" style="margin-bottom:3px;" />年龄</label> 
  <label class="label"><input class="label" id="checkbox4" runat="server" name="check" type="checkbox" value="1" onclick="recipeCheckSelect6(this);" style="margin-bottom:3px;" />病床号</label> 
  <label class="label"><input class="label" id="checkbox5" runat="server" name="check" type="checkbox" value="1" onclick="recipeCheckSelect7(this);" style="margin-bottom:3px;" />医院名称</label> 

</li>


<li>
 <label class="label"><input class="label" id="checkbox6" runat="server" name="check" type="checkbox" value="1" onclick="recipeCheckSelect8(this);" style="margin-bottom:3px;" />处方号</label> 
 <label class="label"><input class="label" id="checkbox7" runat="server" name="check" type="checkbox" value="1" onclick="recipeCheckSelect9(this);" style="margin-bottom:3px;" />煎药方案</label> 
 <label class="label"><input class="label" id="checkbox8" runat="server" name="check" type="checkbox" value="1" onclick="recipeCheckSelect10(this);" style="margin-bottom:3px;" />病区号</label> 
 <label class="label"><input class="label" id="checkbox9" runat="server" name="check" type="checkbox" value="1" onclick="recipeCheckSelect11(this);" style="margin-bottom:3px;" />病房号</label> 
 <label class="label"><input class="label" id="checkbox10" runat="server" name="check" type="checkbox" value="1" onclick="recipeCheckSelect12(this);" style="margin-bottom:3px;" />科室</label> 

</li>

<li>

<label class="label"><input class="label" id="checkbox11" runat="server" name="check" type="checkbox" value="1" onclick="recipeCheckSelect13(this);" style="margin-bottom:3px;" />贴数</label> 
<label class="label"><input class="label" id="checkbox12" runat="server" name="check" type="checkbox" value="1" onclick="recipeCheckSelect14(this);" style="margin-bottom:3px;" />次数</label> 
<label class="label"><input class="label" id="checkbox13" runat="server" name="check" type="checkbox" value="1" onclick="recipeCheckSelect15(this);" style="margin-bottom:3px;" />包装量</label> 
<label class="label"><input class="label" id="checkbox14" runat="server" name="check" type="checkbox" value="1" onclick="recipeCheckSelect16(this);" style="margin-bottom:3px;" />取药时间</label> 
<label class="label"><input class="label" id="checkbox15" runat="server" name="check" type="checkbox" value="1" onclick="recipeCheckSelect17(this);" style="margin-bottom:3px;" />下单时间</label> 
<label class="label"><input class="label" id="checkbox16" runat="server" name="check" type="checkbox" value="1" onclick="recipeCheckSelect18(this);" style="margin-bottom:3px;" />服用方式</label> 
<label class="label"><input class="label" id="checkbox17" runat="server" name="check" type="checkbox" value="1" onclick="recipeCheckSelect19(this);" style="margin-bottom:3px;" />服用方法</label> 

</li>
     </ul>
    

       </div>




      


    </form>
</body>
</html>
