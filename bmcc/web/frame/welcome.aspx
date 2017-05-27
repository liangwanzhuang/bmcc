<%@ Page Language="C#" AutoEventWireup="true" CodeFile="welcome.aspx.cs" Inherits="welcome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="../css/welcom.css" rel="stylesheet" type="text/css" />
<script language="JavaScript" src="../js/jquery.js"></script>


<script type="text/javascript">

    //修改密码
    var childWin;
    function FunOpenAddFrm() {
        if (childWin != null) {
            if (!childWin.closed)
                childWin.close();
        }
        var myLeft = (window.screen.width - 460) / 2;
        var myTop = (window.screen.height - 196) / 2;
        childWin = window.open('passwordchange.aspx', '', 'width=460,height=195,top=' + myTop + ',left=' + myLeft + ',scrollbars=no');
        return false;
    }

    $(function () {
        var tabs = parent.tabs;

        $(".iconlist a").click(function () {

            var aobj = $(this);
            // alert(aobj.attr("url"));
            tabs.add({
                url: aobj.attr("url"),
                label: aobj.text()

            });
        });
    });
   
</script>

</head>


<body> 
    <div class="mainindex">
    <div class="welinfo">
    <span><img src="../img/sun.png" alt="天气" /></span>
    <b><asp:Label id="name" runat="server"/><asp:Label id="hello" runat="server"/></b><asp:Label id="tell" runat="server"/>
    <a href="#" onclick="javascript:return FunOpenAddFrm();">修改密码</a>
    </div>
    
    <div class="welinfo">
    <span><img src="../img/time.png" alt="时间" /></span>
    <i><asp:Label id="time" runat="server"/></i> （您需要帮助？<a href="#">请点这里</a>）
    </div>
    
    <div class="xline"></div>
    
    <ul class="iconlist" >
    
    <li id="tip1" style="display:none" runat= "server"><p><a href="javascript:;" url="view/recipe/RecipeGet.aspx" target="rightFrame" >处方录入</a></p></li>  
    <li id="tip2" style="display:none" runat= "server"><p><a href="javascript:;" url="view/recipe/RecipeSearch.aspx" target="rightFrame">接方查询</a></p></li>
    <li id="tip3" style="display:none" runat= "server"><p><a href="javascript:;"" url="view/recipe/DrugMatch.aspx" target="rightFrame">药品匹配</a></p></li>
    <li id="tip4" style="display:none" runat= "server"><p><a href="javascript:;" url="view/recipe/PspVerify.aspx" target="rightFrame">处方审核</a></p></li>
    <li id="tip5" style="display:none" runat= "server"><p><a href="javascript:;" url="view/recipe/printRecipe.aspx" target="rightFrame">处方打印</a></p></li>
    <li id="tip6" style="display:none" runat= "server"><p><a href="javascript:;" url="view/recipe/RecipeQuery.aspx" target="rightFrame">配方查询</a></p></li> 
    <li id="tip7" style="display:none" runat= "server"><p><a href="javascript:;" url="view/recipe/SwapSearch.aspx" target="rightFrame">调剂查询</a></p></li>
    <li id="tip8" style="display:none" runat= "server"><p><a href="javascript:;" url="view/recipe/SwapStatistics.aspx" target="rightFrame">调剂统计</a></p></li>
            
    </ul>
     <ul class="iconlist" >
    
    

        <li id="tip9" style="display:none" runat= "server"><p><a href="javascript:;" url="view/recipe/Reviewquery.aspx"target="rightFrame">复核查询</a></p></li>
    <li id="tip10" style="display:none" runat= "server"><p><a href="javascript:;" url="view/recipe/Workrecordquery.aspx"target="rightFrame">工作记录查询</a></p></li>
    <li id="tip11" style="display:none" runat= "server"><p><a href="javascript:;" url="view/recipe/DrugGlobalInfo.aspx"target="rightFrame">泡药信息</a></p></li>
    <li id="tip12" style="display:none" runat= "server"><p><a href="javascript:;" url="view/recipe/TisaneClassDst.aspx"target="rightFrame">煎药机组分配</a></p></li> 
     <li id="tip19" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/recipe/TisaneInfo.aspx"target="rightFrame">煎药信息</a><i></i></li>
        <li id="tip20" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/recipe/UnitInfo.aspx"target="rightFrame">机组信息</a><i></i></li>
                <li id="tip21" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/recipe/QueryFunction.aspx"target="rightFrame">查询功能</a><i></i></li>
   <li id="tip22" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/recipe/Packaginginformation.aspx" target="rightFrame">包装管理</a><i></i></li>
            
    </ul>
    
     <ul class="iconlist">
    
       <li id="tip23" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/recipe/Deliveryinformation.aspx" target="rightFrame">发货管理</a><i></i></li>
     <li id="tip24" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/query/ComprehensiveInquiry.aspx" target="rightFrame">综合查询</a><i></i></li>
 
   <li id="tip25" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/query/WorkloadStat.aspx" target="rightFrame">员工工作量统计</a><i></i></li>
        <li id="tip26" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/query/tisanestatics.aspx" target="rightFrame">煎药机工作量统计</a><i></i></li>
        <li id="tip27" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/query/packstatics.aspx" target="rightFrame">包装机工作量统计</a><i></i></li>
     <li id="tip28" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/query/DistributionStat.aspx"target="rightFrame">配送统计</a><i></i></li>
       <li id="tip29" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/query/BusiPerforStat.aspx"target="rightFrame">业务员业绩统计</a><i></i></li>
     <li id="tip30" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/central/ComprehenWarning.aspx" target="rightFrame">综合预警</a><i></i></li>
 
            
    </ul>
     <ul class="iconlist">
  
            
  <li id="tip64" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/central/DecoctingMonitoring.aspx" target="rightFrame">煎药机监控</a><i></i></li>
        <li id="tip65" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/central/PackingMonitoring.aspx" target="rightFrame">包装机监控</a><i></i></li>
            
        <li id="tip66" style="display:none" runat= "server"><cite></cite><a href="../view/central/DrugDisplay.aspx" target="view_window">泡药显示</a><i></i></li>
        <li id="tip31" style="display:none" runat= "server"><cite></cite><a href="../view/central/DecoctingDisplay.aspx" target="view_window">煎药显示</a><i></i></li>
         <li id="tip32" style="display:none" runat= "server"><cite></cite><a href="../view/central/MedicineDisplay.aspx" target="view_window">发药显示</a><i></i></li>
          <li id="tip33" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/central/entercheck.aspx" target="rightFrame">抽检录入</a><i></i></li>
           <li id="tip34" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/central/querycheck.aspx" target="rightFrame">抽检列表查询</a><i></i></li>
 <li id="tip35" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/system/Employee.aspx" target="rightFrame">员工信息</a><i></i></li>

      
    </ul>
     
    <ul class="iconlist">
            <li id="tip38" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/system/Interface.aspx" target="rightFrame">界面管理</a><i></i></li>
        <li id="tip39" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/system/Print.aspx" target="rightFrame">打印模块设置</a><i></i></li>
    <li id="tip40" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/system/Hospital.aspx" target="rightFrame">医院管理</a><i></i></li>
        <li id="tip41" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/system/Clearingparty.aspx" target="rightFrame">结算方管理</a><i></i></li>
        <li id="tip42" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/system/Recipient.aspx" target="rightFrame">收件人管理</a><i></i></li>
        <li id="tip43" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/system/Warehousepharmacy.aspx" target="rightFrame">库房药房管理</a><i></i></li>
        <li id="tip44" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/system/DecoctingMachine.aspx" target="rightFrame">设备管理</a><i></i></li>
        <li id="tip45" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/system/MedicineRoomMachine.aspx" target="rightFrame">煎药室管理</a><i></i></li>
    </ul>
    <ul class="iconlist">
    <li id="tip46" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/storeroom/StorageManage.aspx" target="rightFrame">库房入库管理</a><i></i></li>
    <li id="tip70" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/storeroom/Storagequery.aspx" target="rightFrame">库房入库列表查询</a><i></i></li>
    
         <li id="tip47" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/storeroom/OutboundData.aspx" target="rightFrame">库房调拨管理</a><i></i></li>
         <li id="tip71" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/storeroom/OutboundDataquery.aspx" target="rightFrame">库房调拨列表查询</a><i></i></li>
         
          <li id="tip48" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/storeroom/InventoryInfor.aspx"target="rightFrame">库房库存信息</a><i></i></li>
           <li id="tip49" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/storeroom/WarehouseInven.aspx"target="rightFrame">库房库房盘点</a><i></i></li>
            <li id="tip50" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/storeroom/LossiInfor.aspx" target="rightFrame">库房报损信息</a><i></i></li>
           <li id="tip51" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/storeroom/ReportQuery.aspx"target="rightFrame">库房报单查询</a><i></i></li>
    </ul>
      <ul class="iconlist">
    <li id="tip52" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/storeroom/MedicineStorageManage.aspx" target="rightFrame">药房入库管理</a><i></i></li>
       <li id="tip53" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/storeroom/MedicineOutboundData.aspx" target="rightFrame">药房调拨管理</a><i></i></li>
       <li id="tip72" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/storeroom/MedicaloutboundDataquery.aspx" target="rightFrame">药房调拨单列表查询</a><i></i></li>
       
          <li id="tip54" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/storeroom/MedicineInventoryInfor.aspx"target="rightFrame">药房库存信息</a><i></i></li>
           <li id="tip55" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/storeroom/MedicineWarehouseInven.aspx"target="rightFrame">药房库房盘点</a><i></i></li>
            <li id="tip56" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/storeroom/MedicineLossiInfor.aspx" target="rightFrame">药房报损信息</a><i></i></li>
           <li id="tip57" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/storeroom/MedicineReportQuery.aspx"target="rightFrame">药房报单查询</a><i></i></li>
    </ul>
       <ul class="iconlist">
   <li id="tip58" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/storeroom/DrugAdmin.aspx" target="rightFrame">药品管理</a><i></i></li>
        <li id="tip59" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/storeroom/DrugMatchingList.aspx"target="rightFrame">药品匹配列表</a><i></i></li>
        <li id="tip60" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/reconciliation/AccountStatement.aspx" target="rightFrame">对账单</a><i></i></li>
        <li id="tip61" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/reconciliation/CheckList.aspx" target="rightFrame">对账列表</a><i></i></li>
        <li id="tip62" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/reconciliation/OrderList.aspx" target="rightFrame">订单列表</a><i></i></li>
           <li id="tip63" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/logistics/LogisticsInfor.aspx" target="rightFrame">物流信息</a><i></i></li>
                    <li id="tip36" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/system/Authority.aspx" target="rightFrame">权限管理</a><i></i></li>
        <li id="tip37" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/system/Backgdset.aspx" target="rightFrame">后台设置</a><i></i></li>    
        <li id="tip73" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/system/pdaImgSetting.aspx" target="rightFrame">拍照设置</a><i></i></li> 
        <li id="tip74" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/logistics/setKey.aspx" target="rightFrame">物流key设置</a><i></i></li>  
        <li id="tip75" style="display:none" runat= "server"><cite></cite><a href="javascript:;" url="view/system/autoPrintOnOff.aspx" target="rightFrame">自动打印开关</a><i></i></li>      
    </ul>
    </div>
    
    <div class="xline">

</body>

</html>
