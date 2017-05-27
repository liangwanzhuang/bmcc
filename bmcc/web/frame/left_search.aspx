<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left_search.aspx.cs" Inherits="left_search" %>

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

</script>


</head>

<body style="background:#f0f9fd;">
	<div class="lefttop"><span></span>查询统计</div>
    
    <dl class="leftmenu">
        
    <dd>
    <div class="title">
    <span><img src="../img/Receive-leftico01.png" /></span>接方管理
    </div>
    	<ul class="menuson">
        <li><cite></cite><a href="../view/recipe/RecipeGet.aspx" target="rightFrame">处方录入</a><i></i></li>
        <li><cite></cite><a href="../view/recipe/DrugGet.aspx" target="rightFrame">药品录入</a><i></i></li>
        <li><cite></cite><a href="../view/recipe/RecipeSearch.aspx" target="rightFrame">接方查询</a><i></i></li>
        </ul>    
    </dd>
        
    
    <dd>
    <div class="title">
    <span><img src="../img/Recipe-leftico02.png.png" /></span>配方管理
    </div>
    <ul class="menuson">
        <li><cite></cite><a href="../view/recipe/PspVerify.aspx" target="rightFrame">药品审核</a><i></i></li>
        <li><cite></cite><a href="../view/recipe/DrugMatch.aspx" target="rightFrame">药品匹配</a><i></i></li>
        <li><cite></cite><a href="../view/recipe/printRecipe.aspx" target="rightFrame">处方打印</a><i></i></li>
        <li><cite></cite><a href="../view/recipe/RecipeQuery.aspx" target="rightFrame">配方查询</a><i></i></li>
        </ul>     
    </dd> 
    
    
    <dd><div class="title"><span><img src="../img/Relief-leftico03.png" /></span>调剂管理</div>
    <ul class="menuson">
        <li><cite></cite><a href="../view/recipe/SwapStatistics.aspx" target="rightFrame">调剂统计</a><i></i></li>
        <li><cite></cite><a href="../view/recipe/SwapSearch.aspx" target="rightFrame">调剂查询</a><i></i></li>
    </ul>    
    </dd>  
    <dd><div class="title"><span><img src="../img/Check-leftico04.png" /></span>复核管理</div>
    <ul class="menuson">
        <li><cite></cite><a href="../view/recipe/Reviewquery.aspx"target="rightFrame">复核查询</a><i></i></li>
        <li><cite></cite><a href="../view/recipe/Workrecordquery.aspx"target="rightFrame">工作记录查询</a><i></i></li>
    </ul>
    
    </dd>
    
    <dd><div class="title"><span><img src="../img/Global-leftico05.png" /></span>泡药管理</div>
    <ul class="menuson">
        <li><cite></cite><a href="../view/recipe/DrugGlobalInfo.aspx"target="rightFrame">泡药信息</a><i></i></li>
        <li><cite></cite><a href="../view/recipe/DrugDecoctingMachineDistribution.aspx"target="rightFrame">煎药机组分配</a><i></i></li>
    </ul>
    
    </dd>   
        <dd><div class="title"><span><img src="../img/Boil-leftico06.png" /></span>煎药管理</div>
    <ul class="menuson">
        <li><cite></cite><a href="#">煎药信息</a><i></i></li>
        <li><cite></cite><a href="#">机组信息</a><i></i></li>
        <li><cite></cite><a href="#">查询功能</a><i></i></li>
    </ul>
    
    </dd>  
        <dd><div class="title"><span><img src="../img/Pack-leftico07.png" /></span>包装管理</div>
    <ul class="menuson">
        <li><cite></cite><a href="#">统计显示</a><i></i></li>
        <li><cite></cite><a href="#">查询</a><i></i></li>
        <li><cite></cite><a href="#">预警</a><i></i></li>
    </ul>
    
    </dd>  
        <dd><div class="title"><span><img src="../img/Send-leftico08.png" /></span>发货管理</div>
    <ul class="menuson">
        <li><cite></cite><a href="#">统计显示</a><i></i></li>
        <li><cite></cite><a href="#">查询</a><i></i></li>
        <li><cite></cite><a href="#">预警</a><i></i></li>
    </ul>
    
    </dd>  

    <dd><div class="title"><span><img src="../img/Other.png" /></span>其他</div>
    <ul class="menuson">
        <li><cite></cite><a href="#">包装信息</a><i></i></li>
        <li><cite></cite><a href="#">发货信息</a><i></i></li>
    </ul>
    
    </dd> 
    
    </dl>
    
</body>
</html>