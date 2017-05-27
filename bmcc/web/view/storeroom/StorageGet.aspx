<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StorageGet.aspx.cs" Inherits="view_storeroom_StorageGet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>药品添加信息</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function hospitalSelectChange(select) {
            var id = $(select).val();
            $("#recipeSelect option").remove();
             // alert(id);
            if (id != 0) {
                $.ajax({ type: "POST",
                    url: "StorageGet.aspx/getdruginfobydrugnum",
                    data: "{'drugnum':'" + id + "'}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        //alert('fdsfs');
                        var datas = data.d.split(",");
                        //alert(datas[3]);

                        $("#DrugCode1").val(datas[1]);
                        $("#DrugName").val(datas[3]);
                        $("#DrugType1").val(datas[0]);
                        $("#DrugSpecificat1").val(datas[4]);
                        $("#PositionNum1").val(datas[5]);
                        $("#PurUnits1").val(datas[2]);
                        $("#Univalent1").val(datas[6]);
                        $("#Mnemonic1").val(datas[7]);
                        $("#Producer1").val(datas[9]);

                        $("#ProducingArea1").val(datas[10]);
                        $("#UpperLimit1").val(datas[12]);
                        $("#LowerLimit1").val(datas[13]);
                        $("#Rmarkes1").val(datas[8]);
                        $("#Rmarkes21").val(datas[14]);
                        $("#Rmarkes31").val(datas[15]);


                    }
                });
            }
        }




        function drugnameDivHide() {
            $("#drugnameDiv").hide();
        }
        function drugnameDivShow() {
            $("#drugnameDiv").show();
        }
       /* $(function () {
            drugnameDivHide();
            $("#DrugName").focusout(function () {
                //  alert($(this).val());

                $.ajax({ type: "POST",
                    url: "StorageGet.aspx/serchDrugInfo",
                    data: "{'text':'" + $(this).val() + "'}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        var result = data.d;
                        if (result.length == 0) {
                            alert('没有查询到该信息');
                        } else {
                            var row = result.split(",");
                            var drugnameDiv = $("#drugnameDiv");
                            drugnameDiv.empty();
                            for (i = 0; i < row.length-1; i++) {

                                drugnameDiv.append('<div class="dfinput2 cursor" onclick="ypcDrugInfoClick(\'' + row[i] + '\');">' + row[i] + '</div>');
                            }

                            drugnameDivShow();

                        }
                    }
                });
            });

        });*/

        function fuzzySearch() {

         
            if ($("#DrugName").val().length == 0 || $("#DrugName").val().length > 10) {
                drugnameDivHide();
                return;
            }



            $.ajax({ type: "POST",
                url: "StorageGet.aspx/serchDrugInfo",
                data: "{'text':'" + $("#DrugName").val() + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var result = data.d;
                  
                    if (result.length == 0) {
                        drugnameDivHide();
                        return;
                    }
                    drugnameDivShow();

                    var row = result.split(",");
                    // var drugnameDiv = $("#drugnameDiv");

                    //drugnameDiv.empty();
                    var contents = "";
                    for (i = 0; i < row.length - 1; i++) {

                        //drugnameDiv.append('<div class="dfinput2 cursor" onclick="ypcDrugInfoClick(\'' + row[i] + '\');">' + row[i] + '</div>');
                        contents = contents + "<li onclick='ypcDrugInfoClick(\"" + row[i] + "\");' class='suggest_li" + (i + 1) + "'>" + row[i] + "</li>";


                    }
                 
                    $("#drugnameDiv").html(contents);


                    // drugnameDivShow();
                }
            });

        }


        $(function () {

            //按下按键后300毫秒显示下拉提示 
            $("#DrugName").keyup(function () {
                setInterval(changehover, 300);
                function changehover() {
                    $("#drugnameDiv li").hover(function () { $(this).css("background", "#eee"); }, function () { $(this).css("background", "#fff"); });
                }
            });

        });






        function ypcDrugInfoClick(dataname) {
            $("#DrugName").val(dataname);
            
            $.ajax({ type: "POST",
                url: "StorageGet.aspx/getproductbatch",
                data: "{'dataname':'" + dataname + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    var datas = data.d.split(",");

                    document.getElementById("drugnum").innerHTML = "";
                    document.getElementById("drugnum").options[document.getElementById("drugnum").length] = new Option("请选择", "0")
                    for (var i = 0; i < datas.length - 1; i++) {

                        document.getElementById("drugnum").options[document.getElementById("drugnum").length] = new Option(datas[i], datas[i]);
                    }

                    //alert(datas[3]);

                    drugnameDivHide();

                }
            });
           

        }

      function btnok_onclick() {

            // var Warehouse = $("#Warehouse1").val();
          var drugnum = $("#drugnum").val();

          var productdate = $("#productdate").val();
          var validdate = $("#validdate").val();
          var permitno = $("#permitno").val();
          var remark = $("#remark").val();
          var num = $("#num").val();
          var quality = $("#quality").val();
          var remark = $("#remark").val();

          //alert(drugnum);
          //alert(productdate);
         // alert(validdate);
          //alert(permitno);
          //alert(remark);
         // alert(num);
          //alert(quality);

          if (num == "") {
                alert("请输入数量!");
                return false;

            } else if (quality == "") {
                alert("请选择质量情况！");
                return false;

            }
            else if (productdate == "") {
                alert("请输入生产日期！");
                return false;

            }
            else if (validdate == "") {
                alert("请输入有效日期！");
                return false;

            }
            else if (permitno == "") {
                alert("请输入批注文号！");
                return false;

            }
           
          
           

         $.ajax({ type: "POST",
             url: "StorageGet.aspx/addtempDrugInfo",
             data: "{'drugnum':'" + drugnum + "','num':'" + num + "','quality':'" + quality + "','productdate':'" + productdate + "','validdate':'" + validdate + "','permitno':'" + permitno + "','remark':'" + remark+ "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == 0) {
                        alert('添加失败,可能原因是，该批次已经被添加了');
                    } else {
                        alert('添加成功');
                    }
                    var p = [];
                    FlexGridStorage.applyQueryReload(p);
                }
            });

            return true;
        }

    </script>



 <style> 
    #drugnameDiv
    {
        border-left:1px solid #a7b5bc;
        border-top:1px solid #a7b5bc;
        border-right:1px solid #a7b5bc;
    }
    #drugnameDiv li 
    {
        margin:0px;
        border-bottom:1px solid #a7b5bc;
        padding-left:5px; 
        height:30px; 
        line-height:30px; 
        font-size:14px; 
        width:195px; 
        cursor:default; 
    } 
</style> 
</head>
<body>
    <form id="form1" runat="server">
   <div style="overflow:scroll; width:570px; height:430px;">
    
   
     
   <ul class="forminfo">
     <div class="formtitle"><span>药品基本信息</span></div>
    
    <li><label>药品名称</label><input id="DrugName" runat="server" name="" type="text" class="dfinput2" autocomplete="off" value="search..." oninput="fuzzySearch();" onblur="if(this.value==''){this.value='search...'}" onfocus="if(this.value=='search...'){this.value=''}" />
     <ul id="drugnameDiv" style="top:137px;left:80px; position:absolute; background:white " list-style-type:none;> </ul> 
    <label>药品批次</label><select id="drugnum" runat="server" name=""  class="dfinput2" onchange="hospitalSelectChange(this);">
     <option value="0" selected>请选择</option>
    </select>
  </li>

    <li>  <label>药品编号</label><input id="DrugCode1" runat="server" name="" type="text" class="dfinput2" readonly="readonly"/>
     <label>药品种类</label> <select id="DrugType1" runat="Server" class="dfinput2" readonly="readonly">
            <option value="西药">西药</option>

            <option value="中药">中药</option>
            <option value="藏药">藏药</option>
            <option value="其他">其他</option>
            
        </select></li>

    <li><label>药品规格</label><input id="DrugSpecificat1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/>
   <label>货位号</label><input id ="PositionNum1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/></li>

   <li> <label>基本单位</label><input id="PurUnits1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/>
     <label>单&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;价</label><input id ="Univalent1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/></li>

     <li><label>助记符</label><input id ="Mnemonic1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/>
     <label>生产商</label><input id ="Producer1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/></li>


     <li><label>产&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;地</label><input id ="ProducingArea1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/>
     <label>上&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;限</label><input id ="UpperLimit1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/></li>

    <li> <label>下&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;限</label><input id ="LowerLimit1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/>
   <label>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注1</label><input id ="Rmarkes1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/></li>

     <li><label>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注2</label><input id ="Rmarkes21" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/>
    <label>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注3</label><input id ="Rmarkes31" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/></li>
    <li><label>&nbsp;&nbsp;</label></li>
    </ul>
    



    <ul class="forminfo">
     <div class="formtitle"><span>入库药品信息添加</span></div>
    
   

    <li><label>数量</label><input id="num" runat="server" name="" type="text" class="dfinput2"/>
     <label>质量情况</label> <select id="quality" runat="Server" class="dfinput2">
            <option value="优">优</option>
            <option value="良">良</option>
            <option value="差">差</option>    
        </select></li>


      <li> <label>生产日期</label><input id="productdate" runat="Server" name="" type="text" class="dfinput2" onfocus="WdatePicker()" />
     <label>有效日期</label><input id ="validdate" runat="Server" name="" type="text" class="dfinput2"  onfocus="WdatePicker()"/></li>


    <li><label>批注文号</label><input id="permitno" runat="Server" name="" type="text" class="dfinput2" />
   <label>备注</label><input id ="remark" runat="Server" name="" type="text" class="dfinput2" /></li>

  


  <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" type="button" class="btn" value="确认" onclick=" btnok_onclick();"/></li>
    </ul>





   </div>
  </form>
</body>
</html>