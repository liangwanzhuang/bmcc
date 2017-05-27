<%@ Page Language="C#" AutoEventWireup="true" CodeFile="top.aspx.cs" Inherits="frame_top" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>北京东华原煎药管理系统</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="JavaScript" src="../js/jquery.js"></script>
<script language="JavaScript" src="../js/jquery.js"></script>
<script type="text/javascript">
     function recipemanage() {
         var i1 = parent.window.frames['middleFrame'].frames['left'];
         //i1.document.getElementById("recipemanage").click();
         i1.window.recipemanage();
        
     }

   
     function QueryStatistics() {
         var i1 = parent.window.frames['middleFrame'].frames['left'];
         // i1.document.getElementById("systemmanage").click();
         i1.window.QueryStatistics();
     }
     function CentralMonitoring() {
         var i1 = parent.window.frames['middleFrame'].frames['left'];
         // i1.document.getElementById("systemmanage").click();
         i1.window.CentralMonitoring();
     }
     function systemmanage() {
         var i1 = parent.window.frames['middleFrame'].frames['left'];
         // i1.document.getElementById("systemmanage").click();
         i1.window.systemmanage();
     }
     function StoreroomManagement() {
         var i1 = parent.window.frames['middleFrame'].frames['left'];
         // i1.document.getElementById("systemmanage").click();
         i1.window.StoreroomManagement();
     }
     function ReconciliationManagement() {
         var i1 = parent.window.frames['middleFrame'].frames['left'];
         // i1.document.getElementById("systemmanage").click();
         i1.window.ReconciliationManagement();
     }
     function LogisticsManagement() {
         var i1 = parent.window.frames['middleFrame'].frames['left'];
         // i1.document.getElementById("systemmanage").click();
         i1.window.LogisticsManagement();
     }


  
    var page = 1;
    $(function () {
        //顶部导航切换
        $(".nav li a").click(function () {
            $(".nav li a.selected").removeClass("selected")
            $(this).addClass("selected");
        })
    })
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


    function FunOpenRecordFrm() {
        if (childWin != null) {
            if (!childWin.closed)
                childWin.close();
        }
        var myLeft = (window.screen.width - 450) / 2;
        var myTop = (window.screen.height - 240) / 2;
        childWin = window.open('../record.aspx', '记录数设置', 'width=450,height=240,top=' + myTop + ',left=' + myLeft + ',scrollbars=no');
        return false;
    }
    function getPage() {

        return page;
    }
    function selectTab(val) {
        page = val;
    }
    $(function () {
       // parent.document.getElementById('right').src = "cleverTabs.aspx";
        //   parent.tabsAdd("", "处方录入");
       // var tabs = parent.tabs;
        $(".mmm a").click(function () {
            var aobj = $(this);
            //alert(aobj);
            parent.tabsAdd(aobj.attr("url"), aobj.text());
            //alert(aobj.attr("url"));
            // alert(aobj);
        });
    })
    
</script>
</head>

<body style="background:url(../img/topbg.gif) repeat-x;">

    <div class="topleft">

    <!--<a href="../home.aspx" target="middleFrame"><img src="../img/logo.png"title="系统首页" /></a>-->
    <a href="javascript:;" target="middleFrame"><img src="../img/logo.png"title="系统首页" /></a>
    </div>
    <ul class="nav">
      
    <li id="tip1" style="display:none" runat= "server"><a href="javascript:;" onclick="recipemanage();" target="left" class="selected"><img src="../img/Pres-treatment.png" title="处方管理" /><h2>处方管理</h2></a></li>
    <li id="tip2" style="display:none" runat= "server"><a href="javascript:;" onclick="QueryStatistics();" target="left"><img src="../img/Query-statistics.png" title="查询统计" /><h2>查询统计</h2></a></li>
    <li id="tip3" style="display:none" runat= "server"><a href="javascript:;"  onclick="CentralMonitoring();" target="left"><img src="../img/Cen-control.png" title="中心监控" /><h2>中心监控</h2></a></li>
    <li id="tip4" style="display:none" runat= "server"><a href="javascript:;" onclick="systemmanage();" target="left"><img src="../img/System.png" title="系统设置" /><h2>系统设置</h2></a></li>
    <li id="tip5" style="display:none" runat= "server"><a href="javascript:;" onclick="StoreroomManagement();" target="left"><img src="../img/Statistics.png" title="库房管理" /><h2>库房管理</h2></a></li>
    <li id="tip6" style="display:none" runat= "server"><a href="javascript:;" onclick="ReconciliationManagement();"  target="left"><img src="../img/Rec-management.png" title="对账管理" /><h2>对账管理</h2></a></li>
    <li id="tip7" style="display:none" runat= "server"><a href="javascript:;" onclick="LogisticsManagement();" target="left"><img src="../img/Logistics.png" title="物流管理" /><h2>物流管理</h2></a></li>
    </ul>
            
    <div class="topright">    
    <ul class ="mmm">
    <li><cite></cite><a href="javascript:;"" url="welcome.aspx" target="rightFrame">首页</a><i></i></li>
    <li><a href="###" onclick="###">帮助</a></li>
    <li><a href="#" onclick="javascript:return FunOpenAddFrm();">密码修改</a></li>
    <li><a href="../quit.aspx" target="_parent">退出</a></li>
    </ul>
    <div class="user">

    <span id="username" runat="server"></span>
    <i></i>
    </div>    
    
    </div>

</body>
</html>
