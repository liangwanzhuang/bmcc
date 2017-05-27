<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DrugAdminGet.aspx.cs" Inherits="view_storeroom_DrugAdminGet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>药品添加信息</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function btnok_onclick() {

           // var Warehouse = $("#Warehouse1").val();
             var DrugType = $("#DrugType1").val();
             var DrugCode = $("#DrugCode1").val();
             var PurUnits = $("#PurUnits1").val();
             var DrugName = $("#DrugName12").val();
             var DrugSpecificat = $("#DrugSpecificat1").val();
             var PositionNum = $("#PositionNum1").val();
           // var Amount = $("#Amount1").val();
             var Univalent = $("#Univalent1").val();
           // var Money = $("#Money1").val();
             var Mnemonic = $("#Mnemonic1").val();
            var Rmarkes = $("#Rmarkes1").val();
           // var ProDate = $("#ProDate1").val();
           // var ExpiryDate = $("#ExpiryDate1").val();
          //  var Quality = $("#Quality1").val();
             var Producer = $("#Producer1").val();
             var ProducingArea = $("#ProducingArea1").val();
          //  var LicenseNum = $("#LicenseNum1").val();
         //   var OSingle = $("#OSingle1").val();
           // var OSTime = $("#OSTime1").val();
           // var Warehousing = $("#Warehousing12").val();
            var UpperLimit = $("#UpperLimit1").val();
            var LowerLimit = $("#LowerLimit1").val();
            var Rmarkes2 = $("#Rmarkes21").val();
            var Rmarkes3 = $("#Rmarkes31").val();
             if (DrugName == "") {
                alert("请输入药品名称!");
                return false;

            }else if (DrugCode == "") {
                alert("请输入药品编号！");
                return false;

            }
            else if (DrugSpecificat == "") {
                alert("请输入药品规格！");
                return false;

            }
            else if (PositionNum == "") {
                alert("请输入货位号！");
                return false;

            }
             else if (PurUnits == "") {
                alert("请输入基本单位！");
                return false;

            }
            else if (Univalent == "") {
                alert("请输入单价！");
                return false;

            }
            else if (Mnemonic == "") {
                alert("请输入助记符！");
                return false;

            }
            
            else if (Producer == "") {
                alert("请输入生成商！");
                return false;

            } else if (ProducingArea == "") {
                alert("请输入产地！");
                return false;

            } 
            else if (Rmarkes == "") {
                alert("请输入备注！");
                return false;

            }

            $.ajax({ type: "POST",
                url: "DrugAdminGet.aspx/addDrugAdminInfo",
                data: "{'DrugType':'" + DrugType + "','DrugCode':'" + DrugCode + "','PurUnits':'" + PurUnits + "','DrugName':'" + DrugName + "','DrugSpecificat':'" + DrugSpecificat + "','PositionNum':'" + PositionNum + "','Univalent':'" + Univalent + "','Mnemonic':'" + Mnemonic + "','Rmarkes':'" + Rmarkes + "','Producer':'" + Producer + "','ProducingArea':'" + ProducingArea + "','UpperLimit':'" + UpperLimit + "','LowerLimit':'" + LowerLimit + "','Rmarkes2':'" + Rmarkes2 + "','Rmarkes3':'" + Rmarkes3 + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "0") {
                        alert('添加失败');

                    } if (data.d == "2") {
                        alert('药品编号已存在');

                    } else {
                        alert('添加成功');
                        var p = [];
                        dotNetFlexGrid1.applyQueryReload(p);
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
    
   
     
   <ul class="forminfo">
     <div class="formtitle"><span>药品信息</span></div>
    
    <li><label>药品名称</label><input id="DrugName12" runat="server" name="" type="text" class="dfinput2"/>
    <label>药品编号</label><input id="DrugCode1" runat="server" name="" type="text" class="dfinput2" /></li>
    <li> <label>药品种类</label> <select id="DrugType1" runat="Server" class="dfinput2">
      <option value="中药" selected>中药</option>
            <option value="西药">西药</option>
            <option value="藏药">藏药</option>
            <option value="其他">其他</option>
            
        </select>
    <label>药品规格</label><input id="DrugSpecificat1" runat="Server" name="" type="text" class="dfinput2" /><i></i></li>
    <li><label>货位号</label><input id ="PositionNum1" runat="Server" name="" type="text" class="dfinput2" />
    <label>基本单位</label><input id="PurUnits1" runat="Server" name="" type="text" class="dfinput2" /></li>
     <li><label>单&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;价</label><input id ="Univalent1" runat="Server" name="" type="text" class="dfinput2" />
     <label>助记符</label><input id ="Mnemonic1" runat="Server" name="" type="text" class="dfinput2" /></li>

     
     
     <li>
     <label>生产商</label><input id ="Producer1" runat="Server" name="" type="text" class="dfinput2" /><i></i>
     <label>产&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;地</label><input id ="ProducingArea1" runat="Server" name="" type="text" class="dfinput2" />
     </li>
     
     <li><label>上&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;限</label><input id ="UpperLimit1" runat="Server" name="" type="text" class="dfinput2" />
     <label>下&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;限</label><input id ="LowerLimit1" runat="Server" name="" type="text" class="dfinput2" /><i></i></li>
     <li><label>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注1</label><input id ="Rmarkes1" runat="Server" name="" type="text" class="dfinput2" />
     <label>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注2</label><input id ="Rmarkes21" runat="Server" name="" type="text" class="dfinput2" /><i></i></li>
     <li><label>备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注3</label><input id ="Rmarkes31" runat="Server" name="" type="text" class="dfinput3" /></li>
    <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" type="button" class="btn" value="确认" onclick=" btnok_onclick();"/></li>
    </ul>
    
   </div>
  </form>
</body>
</html>