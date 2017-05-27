<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DrugGlobaldistribution.aspx.cs" Inherits="view_recipe_DrugGlobaldistribution" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>处方机组分配</title>
    <script language="javascript" type="text/javascript">

    function gettextvalue(data){
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



        function hospitalSelectChange(select) {
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
    

    <li><label>煎药机</label><select id="tisanenum" runat="server" class="dfinput2" name="" onchange="hospitalSelectChange(this);" style="text-align:center">
    <option value="0" selected>&nbsp;&nbsp;---请选择---&nbsp;&nbsp;</option>    
    </select>   <span style = color:red>注意：当前推荐机组号为</span> <asp:Label id="recommend" runat="server"/></li>

    <li><label>机房号:</label><asp:Label id="teroomid" runat="server"/></li>
    <li><label>状态:</label><asp:Label id="status" runat="server"/></li>
    <li><label>启用状态:</label><asp:Label id="usingstatus" runat="server"/></li>
    <li><label>卫生状态:</label><asp:Label id="tehealthstatus" runat="server"/></li>
    <li><label>消毒状态:</label><asp:Label id="texiaodustatus" runat="server"/></li>
    <li><label>煎药人:</label><input id="tisaneman" runat="Server" name="" type="text" class="dfinput2" /></li>
    <li><label>备注:</label><input id="ps" runat="Server" name="" type="text" class="dfinput2" /></li>

    <li><label>&nbsp</label><input id="update" runat="server" name="" type="button" class="btn" onclick="btnAddOkClick();" value="添加到该机组" /></li>
    </ul>



     </div>
    </form>
</body>
</html>
