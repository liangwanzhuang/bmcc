<%@ Page Language="C#" AutoEventWireup="true" CodeFile="entercheck.aspx.cs" Inherits="view_central_entercheck" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
      <script type="text/javascript" src="../../js/time.js"></script>
      <script type="text/javascript" src="../../js/jquery.js"></script>
    
    <script language="javascript" type="text/javascript">


       // function onclick() {
       //     alert('fsdafdas');
       // }

        function CheckInputIntFloat(oInput) {
            if ('' != oInput.value.replace(/\d{1,}\.{0,1}\d{0,}/, '')) {
                oInput.value = oInput.value.match(/\d{1,}\.{0,1}\d{0,}/) == null ? '' : oInput.value.match(/\d{1,}\.{0,1}\d{0,}/);
            }
        }

        function doReset() {
           // alert("123");
           // $("select").val("1");
           /* for (i = 0; i < document.all.tags("input").length; i++) {
                if (document.all.tags("input")[i].type == "text") {
                    document.all.tags("input")[i].value = "";
                    
                }
              
            }
            alert("置空成功！");*/
           
            $('#qualitycheckTime').val('');
            $('#pspnum').val('');
            $('#pspnumweight').val('');
            $('#casetodo').val('');
            $('#taste').val('');
            $('#matchperson').val('');
            $('#checkperson').val('');
            $('#remark').val('');
            $('#qualitycheckperson').val('');
            $('#actualweight').val('');
            $('#actualtaste').val('');
            $('#tienum').val('');
            
        }
    </script>
</head>
<body>
<form id="form1" runat="server">
<%--<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">处方管理</a></li>
    <li><a href="#">接方管理</a></li>
    <li><a href="#">药品录入</a></li>
    </ul>
    </div>--%>
    
    <div class="formbody">
    
    <div class="formtitle"><span>抽检录入</span></div>
    
    <ul class="forminfo">

    
    <li><label>质检时间</label> <input id="qualitycheckTime" runat="server" name="" type="text" class="dfinput2" onfocus="SetDate(this,'yyyy-MM-dd hh:mm:ss')" readonly="readonly"/><label>&nbsp;&nbsp;质检人员&nbsp;&nbsp</label><input id="qualitycheckperson" runat="Server" name="" type="text" class="dfinput2" /></li>
    <li><label>煎药单号</label><input id ="pspnum" runat="Server" name="" type="text" class="dfinput" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/><i></i></li>
    <li><label>处方重量</label><input id ="pspnumweight" runat="Server" name="" type="text" class="dfinput2"  onkeyup="javascript:CheckInputIntFloat(this);" /><label>&nbsp;&nbsp;实际重量&nbsp;&nbsp;</label><input id="actualweight" runat="Server" name="" type="text" class="dfinput2" onkeyup="javascript:CheckInputIntFloat(this);"/></li>
    <%--<li><label>误差</label><input id="deviation" runat="Server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/><label>&nbsp;&nbsp;误差百分百</label><input id="deviationpercent" runat="Server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/></li> --%>
    <li><label>处理情况</label><input id="casetodo" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
    <li><label>药味</label><input id="taste" runat="Server" name="" type="text" class="dfinput2" /><label>&nbsp;&nbsp;实际药味&nbsp;&nbsp;</label><input id="actualtaste"  runat="Server" name="" type="text" class="dfinput2" /></li>
    <li><label>是否合格</label> <select id="ischeck" runat="server" class="dfinput2" name="hostpital" onChange="" style="text-align:center">
    <option value="1">合格</option>
          <option value="2">不合格</option>
       </select><label>&nbsp;&nbsp;配方员&nbsp;&nbsp;</label><input id ="matchperson" runat="Server" name="" type="text" class="dfinput2" /></li>
    <li><label>验方员</label><input id="checkperson" runat="Server" name="" type="text" class="dfinput2" /><label>&nbsp;&nbsp;贴数&nbsp;&nbsp;</label><input id="tienum" runat="Server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/></li>
     <li><label>备注</label><input id="remark" runat="Server" name="" type="text" class="dfinput" /></li>
     <li><label>&nbsp;&nbsp</label><asp:Button ID="Button1" runat="server" class="btn" OnClick="Button1_Click" CommandName="A" Text="确认" />&nbsp;&nbsp;&nbsp;&nbsp;<input name="" type="button" onclick="doReset()" class="btn"   value="重置"/></li>
   
    </ul>
    
    
    </div>

    </form>
</body>
</html>
