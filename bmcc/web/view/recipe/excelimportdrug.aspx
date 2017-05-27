<%@ Page Language="C#" AutoEventWireup="true" CodeFile="excelimportdrug.aspx.cs" Inherits="view_recipe_excelimportdrug" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>批量导入</title>
    <script language="javascript" type="text/javascript">


        function hospitalSelectChange(select) {
            var id = $(select).val();
            $("#recipeSelect option").remove();
            //  alert(id);
            if (id != 0) {
                $.ajax({ type: "POST",
                    url: "RecipeGet.aspx/getNumByHospitalId",
                    data: "{'hospitalId':" + id + "}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        var datas = data.d.split(";");

                        $("#hospitalnum").val(datas[0]);
                        $("#del").val(datas[1]);

                    }
                });
            }
        }


        function gettextvalue(data) {
            // alert('niaho....');
            var strRows1Id = data.split(',');
            // alert(strRows1Id[0]);


            // alert('ewrewrewr');
            $("#teroomid").text(strRows1Id[1]);
            $("#tehealthstatus").text(strRows1Id[0]);
            $("#texiaodustatus").text(strRows1Id[2]);
            $("#status").text(strRows1Id[3]);
            $("#usingstatus").text(strRows1Id[4]);
            // alert('ewresdfsdfsdafwrewr');


        }



       /* function hospitalSelectChange(select) {
            var id = $(select).val();
            //$("#recipeSelect option").remove();
            // alert(id);
            if (id != 0) {
                $.ajax({ type: "POST",
                    url: "DrugGlobaldistribution.aspx/updateGlobalInfo",
                    data: "{'id':'" + id + "'}",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        // $("#hospitalnum").val(data.d);
                        //alert('123124');
                        //alert(data.d+"1332");
                        gettextvalue(data.d);
                        //alert('123' + data.d)



                    }
                });
            }
        }
        */
        function btnAddOkClick() {
            var id = $("#idnum").val();
            var tisaneid = $("#tisanenum").val();
            var tisaneman = $("#tisaneman").val();
            var ps = $("#ps").val();

            //alert('sdfsdf'+tisaneid);
            $.ajax({ type: "POST",
                url: "DrugGlobaldistribution.aspx/addunit",
                data: "{'id':'" + id + "','tisaneid':'" + tisaneid + "','tisaneman':'" + tisaneman + "','ps':'" + ps + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    //  alert('fdsafdsfdasfdasfdasf');
                    // alert(data.d)

                    if (data.d == "0") {
                        alert('添加失败，可能是由于改处方号已分配给别的煎药机了');

                    } else {
                        alert('添加成功');
                    }
                    var p = [];
                    FlexGridDrugGlobal1.applyQueryReload(p);
                }
            });
        }
    </script>



   </head>
<body>
    <form id="form1" runat="server">
    <div style="overflow:scroll; width:570px; height:430px;">
    <input id ="idnum" runat="server" type="hidden" name="FunName"/> 
    <ul class="forminfo">
    

   <li><label>医院名称</label><select id="hospitalname" runat="server" name="" type="text" class="dfinput2" style="text-align:center" onchange="hospitalSelectChange(this);" readonly="readonly"></select>
    </li>
     <li><label>委托单号</label><input id="del" runat="server" name="" type="text" class="dfinput2"  readonly="readonly"/><i></i></li>
   <br />
   <br />
   
   <li>请选择需要导入的文件（xlsx格式）</li>
      <li ><asp:FileUpload ID="FileUpload2" runat="server" Width="400px" Height="40px"   style="text-align:center; font-size:15px;"/> </li>
    <li> <asp:Button ID="btnToLead" runat="server" type="button"   class="btn" OnClick="Button1_Click" Text="excel导入" /></li>
    </ul>

     </div>
    </form>
</body>
</html>
