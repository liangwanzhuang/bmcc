<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Adddrugmatching.aspx.cs" Inherits="view_storeroom_Adddrugmatching" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>药品添加信息</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function drugnumSelectChange(select) {
            var id = $(select).val();
            $("#recipeSelect option").remove();
            // alert(id);
            if (id != 0) {
                $.ajax({ type: "POST",
                    url: "Adddrugmatching.aspx/getdruginfobydrugnum",
                    data: "{'drugnum':'" + id + "'}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        //alert('fdsfs');
                        var datas = data.d.split(",");
                        //alert(datas[3]);

                       // $("#DrugCode1").val(datas[1]);
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








        function hospitalSelectChange(select) {
            var id = $(select).val();
            $("#recipeSelect option").remove();
          //   alert(id);
            if (id != 0) {
                $.ajax({ type: "POST",
                    url: "Adddrugmatching.aspx/getNumByHospitalId",
                    data: "{'hospitalId':" + id + "}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        var datas = data.d.split(";");
                      //  alert(datas);

                        $("#hospitalnum").val(datas[0]);
                        // $("#delnum").val(datas[1]);

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
                url: "StorageGet.aspx/getdrugnum",
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
  
    var hospitalname = $("#hospitalname12").val();
    var DrugName12 = $("#DrugName12").val();
    var DrugCode1 = $("#DrugCode1").val();

    var ypcdrugname = $("#DrugName").val();
    var ypcdrugcode = $("#drugnum").val();

    var positionnum = $("#positionnum").val();


   


    if (DrugName12 == "") {
        alert("请输入医院药品名称!");
        return false;

    } else if (DrugCode1 == "") {
        alert("请输入医院药品编号！");
        return false;

    }
    else if (ypcdrugname == "") {
        alert("请输入饮片厂药品名！");
        return false;

    }
    else if (ypcdrugcode == "") {
      alert("请选择饮片厂药品编号！");
       return false;

   }
  //  else if (ypcdrugcode == "") {
  //      alert("请输入饮片厂药品药品编号！");
  //      return false;
  //
 //   }
   // else if (positionnum == "") {
  //      alert("请输入货位号！");
 //       return false;
//    }




    $.ajax({ type: "POST",
        url: "Adddrugmatching.aspx/addmatchingInfo",
        data: "{'hospitalname':'" + hospitalname + "','DrugName12':'" + DrugName12 + "','DrugCode1':'" + DrugCode1 + "','ypcdrugname':'" + ypcdrugname + "','ypcdrugcode':'" + ypcdrugcode + "'}",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d == "0") {
                alert('添加失败');

            } else {
                alert('添加成功');
            }
            var p = [];
            dotNetFlexGrid1.applyQueryReload(p);
        }
    });
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
     <div class="formtitle"><span>医院药品信息</span></div>
     <li> <label style="width:80px;">医院名称</label> <select id="hospitalname12" style="width:182px;" runat="Server" onchange="hospitalSelectChange(this);" class="dfinput2"> 
        </select>
         <label style="width:80px;">医院编号</label><input id="hospitalnum" style="width:180px;" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"  readonly="readonly" />
      </li>

    <li> <label style="width:80px;">医院药品名称</label><input id="DrugName12" style="width:180px;" runat="server" name="" type="text" class="dfinput2"/>
   <label style="width:80px;">医院药品编号</label><input id="DrugCode1" style="width:180px;" runat="server" name="" type="text" class="dfinput2" />  
    
  </li>
  <li></li>
    
    </ul>


   <ul class="forminfo">
     <div class="formtitle"><span>饮片厂药品基本信息</span></div>
    
    <li><label>药品名称</label><input id="DrugName" runat="server" name="" type="text" class="dfinput" autocomplete="off" value="search..." oninput="fuzzySearch();" onblur="if(this.value==''){this.value='search...'}" onfocus="if(this.value=='search...'){this.value=''}" />
     <ul id="drugnameDiv" style="top:290px;left:80px; position:absolute; background:white " list-style-type:none;> </ul>    
  </li>

    <li><label>药品编号</label><select id="drugnum" style="width:202px;" runat="server" name="" type="text" class="dfinput2" onchange="drugnumSelectChange(this);" readonly="readonly"></select>
     

    <label>药品规格</label><input id="DrugSpecificat1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/></li>
   <li><label>货位号</label><input id ="PositionNum1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/>

   <label>基本单位</label><input id="PurUnits1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/></li>

    <li> <label>单&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;价</label><input id ="Univalent1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/>

  
     <label>生产商</label><input id ="Producer1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/></li>


     <li><label>产&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;地</label><input id ="ProducingArea1" runat="Server" name="" type="text" class="dfinput2" readonly="readonly"/>
    </li>

     <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" type="button" class="btn" value="确认"  onclick="return btnok_onclick()" /></li>

    

    </ul>
    
    
   </div>

    
   
     
  


  </form>
</body>
</html>