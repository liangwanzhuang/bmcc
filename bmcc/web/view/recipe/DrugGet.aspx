<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DrugGet.aspx.cs" Inherits="view_recipe_DrugGet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">处方管理</a></li>
    <li><a href="#">接方管理</a></li>
    <li><a href="#">药品录入</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    
    <div class="formtitle"><span>录入药品</span></div>
    
    <ul class="forminfo">

    <li><label>委托单号</label><input id="delnum" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
    <li><label>医院编号</label><input id="hospitalid" runat="server" name="" type="text" class="dfinput2" onkeyup="this.value=this.value.replace(/[^\d]/ig,'')"/>&nbsp;&nbsp;医院名称&nbsp;&nbsp;&nbsp;&nbsp;<input id="hospitalname" runat="server" name="" type="text" class="dfinput2" /></li>
    <li><label>电子处方号</label><input id = "pspnum" runat="Server" name="" type="text" class="dfinput2" /></li>
    <li><label>药品编号</label><input id ="drugnum" runat="Server" name="" type="text" class="dfinput2" />&nbsp;&nbsp;药品名称&nbsp;&nbsp;&nbsp;&nbsp;<input id="drugname" runat="Server" name="" type="text" class="dfinput2" /></li>
    <li><label>药品描述</label><input id ="drugdescription" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
    <li><label>药品位置</label><input id ="drugposition" runat="Server" name="" type="text" class="dfinput2" />&nbsp;&nbsp;药品总数量&nbsp;&nbsp;&nbsp;&nbsp;<input id="drugallnum" runat="Server" name="" type="text" class="dfinput2" /></li>
    <li><label>药品重量</label><input id="drugweight" runat="Server" name="" type="text" class="dfinput2" />&nbsp;&nbsp;贴数&nbsp;&nbsp;&nbsp;&nbsp;<input id="tienum" runat="Server" name="" type="text" class="dfinput2" /></li>
    <li><label>说明</label><input id="description" runat="Server" name="" type="text" class="dfinput" /><i></i></li>
    <li><label>批发价格</label><input id="wholesaleprice" runat="Server" name="" type="text" class="dfinput2" />&nbsp;&nbsp;零售价格&nbsp;&nbsp;&nbsp;&nbsp;<input id="retailprice"  runat="Server" name="" type="text" class="dfinput2" /></li>
    <li><label>批发费用</label><input id="wholesalecost" runat="Server" name="" type="text" class="dfinput2" />&nbsp;&nbsp;零售费用&nbsp;&nbsp;&nbsp;&nbsp;<input id ="retailcost" runat="Server" name="" type="text" class="dfinput2" /></li>
    <li><label>含税金额</label><input id="moneywithtax" runat="Server" name="" type="text" class="dfinput2" />&nbsp;&nbsp;扣率&nbsp;&nbsp;&nbsp;&nbsp;<input id="fee" runat="Server" name="" type="text" class="dfinput2" /></li>

    <li><label>&nbsp;</label><input id="btnok" runat="Server" name="" type="button" class="btn" value="确认" onserverclick="btnOkClick"/>&nbsp;&nbsp;&nbsp;&nbsp;<input name="" type="button" class="btn" value="取消"/></li>
    </ul>
    
    
    </div>

    </form>
</body>
</html>
