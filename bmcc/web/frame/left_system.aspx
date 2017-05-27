<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left_system.aspx.cs" Inherits="left_search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script language="JavaScript" src="../js/jquery.js"></script>

<script type="text/javascript">
    $(function () {
        //导航切换
        $(".menuson li").click(function () {
            $(".menuson li.active").removeClass("active")
            $(this).addClass("active");
            var $ul = $(this).next('ul');
            if ($ul.is(':visible')) {
                $(this).next('ul').slideUp();
            } else {
                $(this).next('ul').slideDown();
            }
        });

        $('.title').click(function () {
            var $ul = $(this).next('ul');
            $('dd').find('ul').slideUp();
            if ($ul.is(':visible')) {
                $(this).next('ul').slideUp();
            } else {
                $(this).next('ul').slideDown();
            }
        });
    })

    function init() 
    {
        parent.document.getElementById('right').src = "view/system/Employee.aspx";       
    }
</script>


</head>

<body style="background:#f0f9fd;" onload="init();">
	<div class="lefttop"><span></span>系统设置</div>
    
    <dl class="leftmenu">
        
    <dd>
    <div class="title">
    <span><img src="../img/Receive-leftico01.png" /></span>系统设置
    </div>
    	<ul class="menuson">
        
        
        <li><cite></cite><a href="../view/system/Employee.aspx" target="rightFrame">员工信息</a><i></i></li>
        <li><cite></cite><a href="../view/system/Authority.aspx" target="rightFrame">权限管理</a><i></i></li>
        <li><cite></cite><a href="../view/system/Backgdset.aspx" target="rightFrame">后台设置</a><i></i></li>
        <li><cite></cite><a href="../view/system/Interface.aspx" target="rightFrame">界面管理</a><i></i></li>
        <li><cite></cite><a href="../view/system/Print.aspx" target="rightFrame">打印模块设置</a><i></i></li>
        <li><cite></cite><a href="../view/system/Hospital.aspx" target="rightFrame">医院管理</a><i></i></li>
        <li><cite></cite><a href="../view/system/Clearingparty.aspx" target="rightFrame">结算方管理</a><i></i></li>
        <li><cite></cite><a href="../view/system/Recipient.aspx" target="rightFrame">收件人管理</a><i></i></li>
        <li><cite></cite><a href="../view/system/Warehousepharmacy.aspx" target="rightFrame">库房药房管理</a><i></i></li>
        <li><cite></cite><a href="../view/system/DecoctingMachine.aspx" target="rightFrame">煎药机管理</a><i></i></li>

        </ul>    
    </dd>
    
    </dl>
    
</body>
</html>