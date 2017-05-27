<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left_recipe.aspx.cs" Inherits="left_recipe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script language="JavaScript" src="../js/jquery.js"></script>

<script type="text/javascript">

    $(function () {
        var isShow = $('#isShow').val();

        if (isShow == '1'){
            $('.menu_li').css('display', 'block');
        }

        
        var $dl = $("#recipemanage").next('dl');
        $dl.find('dd').slideDown();

        var $dl = $("#QueryStatistics").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#CentralMonitoring").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#systemmanage").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#StoreroomManagement").next('dl')
        $dl.find('dd').slideUp();
        var $dl = $("#ReconciliationManagement").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#LogisticsManagement").next('dl');
        $dl.find('dd').slideUp();
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



        //点击头部 左边动
        $('.title').click(function () {
            var $ul = $(this).next('ul');

            //$('dd').find('ul').slideUp();
            if ($ul.is(':visible')) {
                $(this).next('ul').slideUp();

            } else {
                $(this).next('ul').slideDown();

            }


        });

        //左边动
        $('.lefttop').click(function () {
            var $dl = $(this).next('dl');

            //$('dl').find('dd').slideUp();
            if ($dl.find('dd').is(':visible')) {
                $dl.find('dd').slideUp();

            } else {
                $dl.find('dd').slideDown();

            }
        });

    })
    //点击头做动
    
    function recipemanage() {

        //parent.document.getElementById('right').src = "view/recipe/RecipeGet.aspx";

      //  parent.tabsAdd("view/recipe/RecipeGet.aspx", "处方录入");
        var $dl = $("#recipemanage").next('dl');
        $dl.find('dd').slideDown();

        var $dl = $("#QueryStatistics").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#CentralMonitoring").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#systemmanage").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#StoreroomManagement").next('dl')
        $dl.find('dd').slideUp();
        var $dl = $("#ReconciliationManagement").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#LogisticsManagement").next('dl');
        $dl.find('dd').slideUp();
    }

    function QueryStatistics() {
        // parent.document.getElementById('right').src = "view/query/ComprehensiveInquiry.aspx";
      //  parent.tabsAdd("view/query/ComprehensiveInquiry.aspx", "综合查询");
        var $dl = $("#recipemanage").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#QueryStatistics").next('dl');
        $dl.find('dd').slideDown();
        var $dl = $("#CentralMonitoring").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#systemmanage").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#StoreroomManagement").next('dl')
        $dl.find('dd').slideUp();
        var $dl = $("#ReconciliationManagement").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#LogisticsManagement").next('dl');
        $dl.find('dd').slideUp();
        
    }
    function CentralMonitoring() {
        // parent.document.getElementById('right').src = "view/central/ComprehenWarning.aspx";
       // parent.tabsAdd("view/central/ComprehenWarning.aspx", "综合预警");
        var $dl = $("#recipemanage").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#CentralMonitoring").next('dl');
        $dl.find('dd').slideDown();
        var $dl = $("#QueryStatistics").next('dl');
        $dl.find('dd').slideUp();
        
        var $dl = $("#systemmanage").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#StoreroomManagement").next('dl')
        $dl.find('dd').slideUp();
        var $dl = $("#ReconciliationManagement").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#LogisticsManagement").next('dl');
        $dl.find('dd').slideUp();
        
    }
   function systemmanage() {
       // parent.document.getElementById('right').src = "view/system/Employee.aspx";
      // parent.tabsAdd("view/system/Employee.aspx", "员工信息");
        var $dl = $("#recipemanage").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#CentralMonitoring").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#QueryStatistics").next('dl');
        $dl.find('dd').slideUp();

        var $dl = $("#systemmanage").next('dl');
        $dl.find('dd').slideDown();
        var $dl = $("#StoreroomManagement").next('dl')
        $dl.find('dd').slideUp();
        var $dl = $("#ReconciliationManagement").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#LogisticsManagement").next('dl');
        $dl.find('dd').slideUp();
        
    }
    function StoreroomManagement() {
        // parent.document.getElementById('right').src = "view/storeroom/StorageManage.aspx";
       // parent.tabsAdd("view/storeroom/StorageManage.aspx", "入库管理");
        var $dl = $("#recipemanage").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#CentralMonitoring").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#QueryStatistics").next('dl');
        $dl.find('dd').slideUp();

        var $dl = $("#systemmanage").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#StoreroomManagement").next('dl');
        $dl.find('dd').slideDown();
        var $dl = $("#ReconciliationManagement").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#LogisticsManagement").next('dl');
        $dl.find('dd').slideUp();
    }
    function ReconciliationManagement() {
        // parent.document.getElementById('right').src = "view/reconciliation/AccountStatement.aspx";
       // parent.tabsAdd("view/reconciliation/AccountStatement.aspx", "对账单");
        var $dl = $("#recipemanage").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#CentralMonitoring").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#QueryStatistics").next('dl');
        $dl.find('dd').slideUp();

        var $dl = $("#systemmanage").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#StoreroomManagement").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#ReconciliationManagement").next('dl');
        $dl.find('dd').slideDown();
        var $dl = $("#LogisticsManagement").next('dl');
        $dl.find('dd').slideUp();
        
    }
    function LogisticsManagement() {
        //  parent.tabsAdd("view/logistics/LogisticsInfor.aspx", aobj.text());
        //parent.document.getElementById('right').src = "cleverTabs.aspx";
      
      //  parent.tabsAdd("view/logistics/LogisticsInfor.aspx", "物流信息");

        var $dl = $("#recipemanage").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#CentralMonitoring").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#QueryStatistics").next('dl');
        $dl.find('dd').slideUp();

        var $dl = $("#systemmanage").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#StoreroomManagement").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#ReconciliationManagement").next('dl');
        $dl.find('dd').slideUp();
        var $dl = $("#LogisticsManagement").next('dl');
        $dl.find('dd').slideDown();
        
    }


  // $(function () {
       //parent.document.getElementById('right').src = "cleverTabs.aspx";
       // parent.tabsAdd("view/logistics/LogisticsInfor.aspx", "物流信息");


   // }

    $(function () {
        parent.document.getElementById('right').src = "cleverTabs.aspx";
        //   parent.tabsAdd("", "处方录入");

        $(".menuson a").click(function () {
            var aobj = $(this);
            parent.tabsAdd(aobj.attr("url"), aobj.text());
            //alert(aobj.attr("url"));
           // alert(aobj);
        });
    })
    $(function () {
        var left_div = $("#left_div");
        var height = window.innerHeight;
        left_div.css('height', height + 'px');
    })

</script>
<style type="text/css"> 
.divcss5-a{  height:100px; float:left; } 
.divcss5-a{ margin-left:0px;overflow-y:scroll; overflow-x:hidden;scrollbar-face-color: white; scrollbar-highlight-color: white; scrollbar-shadow-color: white;scrollbar-3dlight-color: white;scrollbar-arrow-color: white;scrollbar-track-color:white;scrollbar-darkshadow-color: white;scrollbar-base-color: white;} 
/* css注释说明：设置第二个盒子与第一个盒子间距为10px，并设置了横纵滚动条样式 */ 
.menu_li{display:none}
</style> 
 
</head>

<body style="background:#f0f9fd;overflow-y:auto; overflow-x:hidden;"onload="init();">
 <div id="left_div"  >
	<div id="recipemanage" class="lefttop"   style="display:none" runat= "server"><span></span>处方管理</div>
    
    <dl class="leftmenu">
        
    <dd> <div id="tip1" style="display:none" runat= "server">
    <div class="title" >
    <span><img src="../img/Receive-leftico01.png" /></span>接方管理
    </div >
    
    	<ul class="menuson">
        <li id="chufangluru" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/recipe/RecipeGet.aspx" target="rightFrame" >处方录入</a><i></i></li>
        <%--<li><cite></cite><a href="../view/recipe/DrugGet.aspx" target="rightFrame">药品录入</a><i></i></li>--%>
        <li id="jiefangchaxun" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/recipe/RecipeSearch.aspx" target="rightFrame">接方查询</a><i></i></li>
        </ul>  
     </div>     
    </dd>
    
    
    <dd><div id="tip2" style="display:none" runat= "server">
    <div class="title" >
    <span><img src="../img/Recipe-leftico02.png.png" /></span>配方管理
    </div>
     
    <ul class="menuson">
        <li id="yaopinpipei" runat="server" class="menu_li"><cite></cite><a href="javascript:;"" url="view/recipe/DrugMatch.aspx" target="rightFrame">药品匹配</a><i></i></li>
        <li id="chufangshenhe" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/recipe/PspVerify.aspx" target="rightFrame">处方审核</a><i></i></li>
        <li id="chufangdayin" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/recipe/printRecipe.aspx" target="rightFrame">处方打印</a><i></i></li>
        <li id="peifangchaxun" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/recipe/RecipeQuery.aspx" target="rightFrame">配方查询</a><i></i></li>
        </ul> 
      </div>     
    </dd> 
    
    
    <dd><div id="tip3" style="display:none" runat= "server">
    <div class="title" ><span><img src="../img/Relief-leftico03.png" /></span>调剂管理</div>
    
    <ul class="menuson">
      
        <li id="tiaojichaxun" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/recipe/SwapSearch.aspx" target="rightFrame">调剂查询</a><i></i></li>
          <li id="tiaojitongji" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/recipe/SwapStatistics.aspx" target="rightFrame">调剂统计</a><i></i></li>
    </ul> </div> 
    </dd>  
    <dd><div id="tip4" style="display:none" runat= "server">
    <div class="title"><span><img src="../img/Check-leftico04.png" /></span>复核管理</div>
    <ul class="menuson">
        <li id="fuhechaxun" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/recipe/Reviewquery.aspx"target="rightFrame">复核查询</a><i></i></li>
        <li id="gongzuojilu" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/recipe/Workrecordquery.aspx"target="rightFrame">工作记录查询</a><i></i></li>
    </ul>
    </div>
    </dd>
    
    <dd><div id="tip5" style="display:none" runat= "server">
    <div class="title"><span><img src="../img/Global-leftico05.png" /></span>泡药管理</div>
    <ul class="menuson">
        <li id="paoyaoxinxi" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/recipe/DrugGlobalInfo.aspx"target="rightFrame">泡药信息</a><i></i></li>
        <li id="jianyaojizu" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/recipe/TisaneClassDst.aspx"target="rightFrame">煎药机组分配</a><i></i></li>
    </ul>
    </div>

    </dd> 
    <dd><div id="tip6" style="display:none" runat= "server">  
        <div class="title"><span><img src="../img/Boil-leftico06.png" /></span>煎药管理</div>
    <ul class="menuson">
        <li id="jianyaoxinxi" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/recipe/TisaneInfo.aspx"target="rightFrame">煎药信息</a><i></i></li>
        <li id="jizuxinxi" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/recipe/UnitInfo.aspx"target="rightFrame">机组信息</a><i></i></li>
        <li id="chaxungongneng" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/recipe/QueryFunction.aspx"target="rightFrame">查询功能</a><i></i></li>
    </ul>
    </div>
    </dd>  
    

    <dd><div id="tip7" style="display:none" runat= "server">
    <div class="title"><span><img src="../img/Other.png" /></span>其他</div>
    <ul class="menuson">
        <div id="Div1" style="display:none" runat= "server">  <li><cite></cite><a href="javascript:;" url="view/recipe/Packaginginformation.aspx" target="rightFrame">包装管理</a><i></i></li></div>
      <div id="Div2" style="display:none" runat= "server">  <li><cite></cite><a href="javascript:;" url="view/recipe/Deliveryinformation.aspx" target="rightFrame">发货管理</a><i></i></li></div>
    </ul>
    </div>
    </dd> 
    
    </dl>
     <div id="QueryStatistics" class="lefttop"  style="display:none" runat= "server"><span></span>查询统计</div>
    
    <dl class="leftmenu">
        
    <dd><div id="tip8" style="display:none" runat= "server">
    <div class="title">
    <span><img src="../img/Receive-leftico01.png" /></span>综合查询
    </div>
    	<ul class="menuson">
        <li id="zonghechaxun" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/query/ComprehensiveInquiry.aspx" target="rightFrame">综合查询</a><i></i></li>

        </ul>  
        </div>   
    </dd>
       
    
    <dd><div id="tip9" style="display:none" runat= "server">
    <div class="title">
    <span><img src="../img/Recipe-leftico02.png.png" /></span>工作量统计
    </div>
    <ul class="menuson">
        <li id="gongzuoliangtongji" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/query/WorkloadStat.aspx" target="rightFrame">员工工作量统计</a><i></i></li>
        <li id="jianyaogongzuoliangtongji" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/query/tisanestatics.aspx" target="rightFrame">煎药机工作量统计</a><i></i></li>
        <li id="baozhuanggongzuoliangtongji" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/query/packstatics.aspx" target="rightFrame">包装机工作量统计</a><i></i></li>
        </ul>
        </div>     
    </dd> 
    
    
    <%--<dd><div class="title"><span><img src="../img/Relief-leftico03.png" /></span>抽检列表</div>
    <ul class="menuson">
        <li><cite></cite><a href="javascript:;" url="view/query/SamplingList.aspx" target="rightFrame">抽检列表</a><i></i></li>
       
    </ul>    
    </dd> --%> 
    <dd><div id="tip10" style="display:none" runat= "server">
    <div class="title"><span><img src="../img/Check-leftico04.png" /></span>配送统计</div>
    <ul class="menuson">
        <li id="peisongtongji" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/query/DistributionStat.aspx"target="rightFrame">配送统计</a><i></i></li>
    </ul>
    </div>
    </dd>
    
    <dd><div id="tip11" style="display:none" runat= "server">
    <div class="title"><span><img src="../img/Global-leftico05.png" /></span>业务员业绩统计</div>
    <ul class="menuson">
        <li id="yejitongji" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/query/BusiPerforStat.aspx"target="rightFrame">业务员业绩统计</a><i></i></li>
    </ul>
    </div>
    </dd>   
       
    </dl>
    

    <div id="CentralMonitoring" class="lefttop"  style="display:none" runat= "server"><span></span>中心监控</div>
    
    <dl class="leftmenu">
        
    <dd><div id="tip12" style="display:none" runat= "server">
    <div class="title">
    <span><img src="../img/Receive-leftico01.png" /></span>综合预警
    </div>
    	<ul class="menuson">
        <li id="zongheyujing" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/central/ComprehenWarning.aspx" target="rightFrame">综合预警</a><i></i></li>

        </ul>  
        </div>  
    </dd>
        
    
    <dd><div id="tip13" style="display:none" runat= "server">
    <div class="title">
    <span><img src="../img/Recipe-leftico02.png.png" /></span>机组监控
    </div>
    <ul class="menuson">
        <li id="yanyaojijiankong" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/central/DecoctingMonitoring.aspx" target="rightFrame">煎药机监控</a><i></i></li>
        <li id="baozhuangjijiankong" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/central/PackingMonitoring.aspx" target="rightFrame">包装机监控</a><i></i></li>

        </ul>  </div>   
    </dd> 
    
    
    <dd><div id="tip14" style="display:none" runat= "server">
    
    <div class="title"><span><img src="../img/Relief-leftico03.png" /></span>大屏显示</div>
    <ul class="display">
      
        <li id="paoyaoxianshi" runat="server" class="menu_li"><cite></cite><a href="../view/central/DrugDisplay.aspx" target="view_window">泡药显示</a><i></i></li>
        <li id="jianyaoxianshi" runat="server" class="menu_li"><cite></cite><a href="../view/central/DecoctingDisplay.aspx" target="view_window">煎药显示</a><i></i></li>
         <li id="fayaoxianshi" runat="server" class="menu_li"><cite></cite><a href="../view/central/MedicineDisplay.aspx" target="view_window">发药显示</a><i></i></li>

    </ul>
    </div>    
    </dd>  

     <dd><div id="tip15" style="display:none" runat= "server">
     <div class="title"><span><img src="../img/Relief-leftico03.png" /></span>质量管理</div>
    <ul class="menuson">
        <li id="choujianluru" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/central/entercheck.aspx" target="rightFrame">抽检录入</a><i></i></li>
        <li id="choujianchaxun" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/central/querycheck.aspx" target="rightFrame">抽检列表查询</a><i></i></li>
      

    </ul> 
    </div>   
    </dd>  

    
    </dl>


    <div id="systemmanage" class="lefttop"  style="display:none" runat= "server"><span></span>系统设置</div>
    
   <dl class="leftmenu">
        
    <dd>
    <div id="tip16" style="display:none" runat= "server">
    <div class="title">
    <span><img src="../img/Receive-leftico01.png" /></span>系统设置
    </div>
    	<ul class="menuson">
             
        <li id="yuangongxinxi" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/system/Employee.aspx" target="rightFrame">员工信息</a><i></i></li>
        <li id="quanxianguanli" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/system/Authority.aspx" target="rightFrame">权限管理</a><i></i></li>
        <li id="houtaishezhi" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/system/Backgdset.aspx" target="rightFrame">后台设置</a><i></i></li>
        <li id="jiemianguanli" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/system/Interface.aspx" target="rightFrame">界面管理</a><i></i></li>
        <li id="dayinmokuaishezhi" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/system/Print.aspx" target="rightFrame">打印模块设置</a><i></i></li>
        <li id="yiyuanguanli" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/system/Hospital.aspx" target="rightFrame">医院管理</a><i></i></li>
        <li id="jiesuanfangguanli" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/system/Clearingparty.aspx" target="rightFrame">结算方管理</a><i></i></li>
        <li id="shoujianrenguanli" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/system/Recipient.aspx" target="rightFrame">收件人管理</a><i></i></li>
        <li id="kufangyaofangguanli" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/system/Warehousepharmacy.aspx" target="rightFrame">库房药房管理</a><i></i></li>
        <li id="shebeiguanli" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/system/DecoctingMachine.aspx" target="rightFrame">设备管理</a><i></i></li>
        <li id="jianyaoshiguanli" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/system/MedicineRoomMachine.aspx" target="rightFrame">煎药室管理</a><i></i></li>
        <li id="wuliukeyshezhi" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/logistics/setKey.aspx" target="rightFrame">物流key设置</a><i></i></li>
        <li id="zidongdayinkaiguan" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/system/autoPrintOnOff.aspx" target="rightFrame">自动打印开关</a><i></i></li>
        </ul>  
        </div>  
    </dd>
    <dd>
    <div id="tip24" style="display:none" runat= "server">
    <div class="title">
    <span><img src="../img/Receive-leftico01.png" /></span>pda拍照设置
    </div>
    	<ul class="menuson">
            <li id="paizhaoguanli" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/system/pdaImgSetting.aspx" target="rightFrame">拍照设置</a><i></i></li>
        </ul>  
        </div>  
    </dd>
    </dl>
    

    <div id="StoreroomManagement" class="lefttop"  style="display:none" runat= "server"><span></span>库房管理</div>
    
    <dl class="leftmenu">
        
    <dd><div id="tip17" style="display:none" runat= "server">
    <div class="title">
    <span><img src="../img/Receive-leftico01.png" /></span>库房管理
    </div>
    	<ul class="menuson">
       
        <li id="rukuguanli" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/storeroom/StorageManage.aspx" target="rightFrame">入库管理</a><i></i></li>
         <li id="rukuliebiaochaxun" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/storeroom/Storagequery.aspx" target="rightFrame">入库列表查询</a><i></i></li>
         <li id="tiaoboguanli" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/storeroom/OutboundData.aspx" target="rightFrame">调拨管理</a><i></i></li>
         <li id="tiaoboxinxiliebiao" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/storeroom/OutboundDataquery.aspx" target="rightFrame">调拨列表查询</a><i></i></li>
          <li id="kucunxinxi" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/storeroom/InventoryInfor.aspx"target="rightFrame">库存信息</a><i></i></li>
           <li id="kufangpandian" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/storeroom/WarehouseInven.aspx"target="rightFrame">库房盘点</a><i></i></li>
            <li id="baosunxinxi" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/storeroom/LossiInfor.aspx" target="rightFrame">报损信息</a><i></i></li>
           <li id="baodanchaxun" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/storeroom/ReportQuery.aspx"target="rightFrame">报单查询</a><i></i></li>
        </ul>
        </div>    
    </dd>
        
    
    <dd><div id="tip18" style="display:none" runat= "server">
    <div class="title">
    <span><img src="../img/Recipe-leftico02.png.png" /></span>药房管理
    </div>
    <ul class="menuson">
      <li id="yaofangrukuguanli" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/storeroom/MedicineStorageManage.aspx" target="rightFrame">入库管理</a><i></i></li>
       <li id="yaofangtiaoboguanli" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/storeroom/MedicineOutboundData.aspx" target="rightFrame">调拨管理</a><i></i></li>
         <li id="yaofangtiaobodanchaxun" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/storeroom/MedicaloutboundDataquery.aspx" target="rightFrame">调拨单列表查询</a><i></i></li>
          <li id="yaofangkufangxinxi" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/storeroom/MedicineInventoryInfor.aspx"target="rightFrame">库存信息</a><i></i></li>
           <li id="yaofangkufangpandian" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/storeroom/MedicineWarehouseInven.aspx"target="rightFrame">库房盘点</a><i></i></li>
            <li id="yaofangbaosunxinxi" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/storeroom/MedicineLossiInfor.aspx" target="rightFrame">报损信息</a><i></i></li>
           <li id="yaofangbaodanchaxun" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/storeroom/MedicineReportQuery.aspx"target="rightFrame">报单查询</a><i></i></li>
        </ul>
        </div>     
    </dd> 
    
  

        <dd><div id="tip19" style="display:none" runat= "server">
        <div class="title"><span><img src="../img/Send-leftico08.png" /></span>药品管理</div>
    <ul class="menuson">
        <li id="yaopinguanli" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/storeroom/DrugAdmin.aspx" target="rightFrame">药品管理</a><i></i></li>

    </ul>
    </div>
    </dd>  

    <dd><div id="tip20" style="display:none" runat= "server">
    <div class="title"><span><img src="../img/Other.png" /></span>药品匹配列表</div>
    <ul class="menuson">
        <li id="yaopinpipeiliebiao" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/storeroom/DrugMatchingList.aspx"target="rightFrame">药品匹配列表</a><i></i></li>
        
    </ul>
    </div>
    </dd> 
    <%-- <dd><div id="tip21" style="display:none" runat= "server">
    <div class="title"><span><img src="../img/Other.png" /></span>中药管理</div>
    <ul class="menuson">
        <li><cite></cite><a href="javascript:;" url="view/storeroom/ChinMedicineManage.aspx"target="rightFrame">中药管理</a><i></i></li>
        
    </ul>
    </div>
    </dd>--%> </dl>

    <div id="ReconciliationManagement" class="lefttop"  style="display:none" runat= "server"><span></span>对账管理</div>
    
    <dl class="leftmenu">
        
    <dd><div id="tip22" style="display:none" runat= "server">
    <div class="title">
    <span><img src="../img/Receive-leftico01.png" /></span>医院对账管理
    </div>
    	<ul class="menuson">
        <li id="duizhangdan" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/reconciliation/AccountStatement.aspx" target="rightFrame">对账单</a><i></i></li>
        <li id="duizhangliebiao" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/reconciliation/CheckList.aspx" target="rightFrame">对账列表</a><i></i></li>
        <li id="dingdanliebiao" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/reconciliation/OrderList.aspx" target="rightFrame">订单列表</a><i></i></li>

        </ul>   
        </div> 
    </dd>
        
    </dl>
      <div id="LogisticsManagement" class="lefttop" style="display:none" runat= "server"><span></span>物流管理</div>
    
    <dl class="leftmenu">
        
    <dd><div id="tip23" style="display:none" runat= "server">
    <div class="title">
    <span><img src="../img/Receive-leftico01.png" /></span>物流信息管理
    </div>
    	<ul class="menuson">
        <li id="wuliuxinxi" runat="server" class="menu_li"><cite></cite><a href="javascript:;" url="view/logistics/LogisticsInfor.aspx" target="rightFrame">物流信息</a><i></i></li>

        </ul> 
        </div>   
    </dd>
        
    </dl>
   </div> 

   <input id="isShow" type="hidden" value="0" runat="server"/>
</body>
</html>