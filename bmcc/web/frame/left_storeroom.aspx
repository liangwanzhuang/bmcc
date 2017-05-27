<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left_storeroom.aspx.cs" Inherits="left_search" %>

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
    function init() {
        parent.document.getElementById('right').src = "view/storeroom/MedicineManage.aspx";
    }
</script>


</head>

<body style="background:#f0f9fd;" onload="init();">
	<div class="lefttop"><span></span>库房管理</div>
    
    <dl class="leftmenu">
        
    <dd>
    <div class="title">
    <span><img src="../img/Receive-leftico01.png" /></span>药房管理
    </div>
    	<ul class="menuson">
        <li><cite></cite><a href="../view/storeroom/MedicineManage.aspx" target="rightFrame">药房管理</a><i></i></li>

        </ul>    
    </dd>
        
    
    <dd>
    <div class="title">
    <span><img src="../img/Recipe-leftico02.png.png" /></span>入库管理
    </div>
    <ul class="menuson">
        <li><cite></cite><a href="../view/storeroom/StorageManage.aspx" target="rightFrame">入库管理</a><i></i></li>
        </ul>     
    </dd> 
    
    
    <dd><div class="title"><span><img src="../img/Relief-leftico03.png" /></span>出库数据</div>
    <ul class="menuson">
        <li><cite></cite><a href="../view/storeroom/OutboundData.aspx" target="rightFrame">出库数据</a><i></i></li>
       
    </ul>    
    </dd>  
    <dd><div class="title"><span><img src="../img/Check-leftico04.png" /></span>库存信息</div>
    <ul class="menuson">
        <li><cite></cite><a href="../view/storeroom/InventoryInfor.aspx"target="rightFrame">库存信息</a><i></i></li>
    </ul>
    
    </dd>
    
    <dd><div class="title"><span><img src="../img/Global-leftico05.png" /></span>库房盘点</div>
    <ul class="menuson">
        <li><cite></cite><a href="../view/storeroom/WarehouseInven.aspx"target="rightFrame">库房盘点</a><i></i></li>
    </ul>
    
    </dd>   
        <dd><div class="title"><span><img src="../img/Boil-leftico06.png" /></span>报损信息</div>
    <ul class="menuson">
        <li><cite></cite><a href="../view/storeroom/LossiInfor.aspx" target="rightFrame">报损信息</a><i></i></li>
        
    </ul>
    
    </dd>  
        <dd><div class="title"><span><img src="../img/Pack-leftico07.png" /></span>报单查询</div>
    <ul class="menuson">
        <li><cite></cite><a href="../view/storeroom/ReportQuery.aspx"target="rightFrame">报单查询</a><i></i></li>
        
    </ul>
    
    </dd>  
        <dd><div class="title"><span><img src="../img/Send-leftico08.png" /></span>药品管理</div>
    <ul class="menuson">
        <li><cite></cite><a href="../view/storeroom/DrugAdmin.aspx" target="rightFrame">药品管理</a><i></i></li>

    </ul>
    
    </dd>  

    <dd><div class="title"><span><img src="../img/Other.png" /></span>药品匹配列表</div>
    <ul class="menuson">
        <li><cite></cite><a href="../view/storeroom/DrugMatchingList.aspx"target="rightFrame">药品匹配列表</a><i></i></li>
        
    </ul>
    
    </dd> 
    <dd><div class="title"><span><img src="../img/Other.png" /></span>中药管理</div>
    <ul class="menuson">
        <li><cite></cite><a href="../view/storeroom/ChinMedicineManage.aspx"target="rightFrame">中药管理</a><i></i></li>
        
    </ul>
    
    </dd> 
    </dl>
    
</body>
</html>