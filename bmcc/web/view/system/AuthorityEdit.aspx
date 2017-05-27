<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuthorityEdit.aspx.cs" Inherits="view_system_AuthorityEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑角色权限</title>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    
    <style>
        .middle{
            vertical-align:middle;     
        }
        table td
        {
            border:1px solid #aaaaaa;
            padding-left:5px;
        }
        
        
    </style>
    <script>


        $(function () {
            var authorityText = $('#authorityText').val();
            var authorityTexts = authorityText.split('、');
            for (var i = 0; i < authorityTexts.length; i++) {
                $('.checkbox').each(function (k) {
                    if ($(this).val() == authorityTexts[i]) {
                        $(this).attr('checked', 'true');

                    }
                });
            }
        })
        function selectCheckBox(obj, id) {
            $('.' + id).attr('checked', $(obj).attr('checked'))
        }

        function btnSaveOnClick() {
            var vals = '';
            $('.checkbox').each(function (i) {
                if ($(this).attr('checked')) {
                    vals += $(this).val()+ '、';
                }

            });
            if (vals.length > 0) {
                vals = vals.substring(0, vals.length -1);
            }
            var id = $("#aid").val();
            $.ajax({ type: "POST",
                url: "AuthorityEdit.aspx/updateLimits",
                data: "{'id':'" + id + "','limits':'" + vals + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    alert(data.d);
                    findBtn();
                }
            });
         //   alert(vals);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="authorityName" runat="server" style="text-align:center;"></div>
        <table width="100%" cellspacing="0" cellpadding="0">
            <tr>
                <td rowspan='17'>
                    <input id="check_1" onclick="selectCheckBox(this,'check_1');" class="middle" type="checkbox" value="处方管理"/><label class="middle" for="check_1">&nbsp;处方管理</label>
                </td>
                <td rowspan='2'>
                    
                    <input id="check_1_1" onclick="selectCheckBox(this,'check_1_1');" class="middle check_1" type="checkbox" value="接方管理"/><label class="middle" for="check_1_1">&nbsp;接方管理</label>
                </td>
                <td>
                    <input id="check_1_1_1" class="middle check_1 check_1_1 checkbox" type="checkbox" value="处方录入"/><label class="middle" for="check_1_1_1">&nbsp;处方录入</label>
                </td>
            </tr>
            <tr>

                <td>
                    <input id="check_1_1_2" class="middle check_1 check_1_1 checkbox" type="checkbox" value="接方查询"/><label class="middle" for="check_1_1_2">&nbsp;接方查询</label>
                </td>
            </tr>
            <tr>
                <td rowspan='4'>
                    <input id="check_1_2" onclick="selectCheckBox(this,'check_1_2');" class="middle check_1" type="checkbox" value="配方管理"/><label class="middle" for="check_1_2">&nbsp;配方管理</label>
                </td>
                <td>
                    <input id="check_1_2_1" class="middle check_1 check_1_2 checkbox" type="checkbox" value="药品匹配"/><label class="middle" for="check_1_2_1">&nbsp;药品匹配</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_1_2_2" class="middle check_1 check_1_2 checkbox" type="checkbox" value="处方审核"/><label class="middle" for="check_1_2_2">&nbsp;处方审核</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_1_2_3" class="middle check_1 check_1_2 checkbox" type="checkbox" value="处方打印"/><label class="middle" for="check_1_2_3">&nbsp;处方打印</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_1_2_4" class="middle check_1 check_1_2 checkbox" type="checkbox" value="配方查询"/><label class="middle" for="check_1_2_4">&nbsp;配方查询</label>
                </td>
            </tr>
            <tr>
                <td rowspan='2'>
                    <input id="check_1_3" onclick="selectCheckBox(this,'check_1_3');" class="middle check_1" type="checkbox" value="调剂管理"/><label class="middle" for="check_1_3">&nbsp;调剂管理</label>
                </td>
                <td>
                    <input id="check_1_3_1" class="middle check_1 check_1_3 checkbox" type="checkbox" value="调剂查询"/><label class="middle" for="check_1_3_1">&nbsp;调剂查询</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_1_3_2" class="middle check_1 check_1_3 checkbox" type="checkbox" value="调剂统计"/><label class="middle" for="check_1_3_2">&nbsp;调剂统计</label>
                </td>
            </tr>
            <tr>
                <td rowspan='2'>
                    <input id="check_1_4" onclick="selectCheckBox(this,'check_1_4');" class="middle check_1" type="checkbox" value="复核管理"/><label class="middle" for="check_1_4">&nbsp;复核管理</label>
                </td>
                <td>
                    <input id="check_1_4_1" class="middle check_1 check_1_4 checkbox" type="checkbox" value="复核查询"/><label class="middle" for="check_1_4_1">&nbsp;复核查询</label>
                </td>
            </tr>
            <tr>
                <td>
                   <input id="check_1_4_2" class="middle check_1 check_1_4 checkbox" type="checkbox" value="工作记录查询"/><label class="middle" for="check_1_4_2">&nbsp;工作记录查询</label>
                </td>
            </tr>
            <tr>
                <td rowspan='2'>
                    <input id="check_1_5" onclick="selectCheckBox(this,'check_1_5');" class="middle check_1" type="checkbox" value="泡药管理"/><label class="middle" for="check_1_5">&nbsp;泡药管理</label>
                </td>
                <td>
                    <input id="check_1_5_1" class="middle check_1 check_1_5 checkbox" type="checkbox" value="泡药信息"/><label class="middle" for="check_1_5_1">&nbsp;泡药信息</label>
                </td>
            </tr>
            <tr>
                <td>
                   <input id="check_1_5_2" class="middle check_1 check_1_5 checkbox" type="checkbox" value="煎药机组分配"/><label class="middle" for="check_1_5_2">&nbsp;煎药机组分配</label>
                </td>
            </tr>
            <tr>
                <td rowspan='3'>
                    <input id="check_1_6" onclick="selectCheckBox(this,'check_1_6');" class="middle check_1" type="checkbox" value="煎药管理"/><label class="middle" for="check_1_6">&nbsp;煎药管理</label>
                </td>
                <td>
                    <input id="check_1_6_1" class="middle check_1 check_1_6 checkbox" type="checkbox" value="煎药信息"/><label class="middle" for="check_1_6_1">&nbsp;煎药信息</label>
                </td>
            </tr>
            <tr>
                <td>
                   <input id="check_1_6_2" class="middle check_1 check_1_6 checkbox" type="checkbox" value="机组信息"/><label class="middle" for="check_1_6_2">&nbsp;机组信息</label>
                </td>
            </tr>
            <tr>
                <td>
                   <input id="check_1_6_3" class="middle check_1 check_1_6 checkbox" type="checkbox" value="查询功能"/><label class="middle" for="check_1_6_3">&nbsp;查询功能</label>
                </td>
            </tr>
            <tr>
                <td rowspan='2'>
                    <input id="check_1_7" onclick="selectCheckBox(this,'check_1_7');" class="middle check_1" type="checkbox" value="其他"/><label class="middle" for="check_1_7">&nbsp;其他</label>
                </td>
                <td>
                    <input id="check_1_7_1" class="middle check_1 check_1_7 checkbox" type="checkbox" value="包装管理"/><label class="middle" for="check_1_7_1">&nbsp;包装管理</label>
                </td>
            </tr>
            <tr>
                <td>
                   <input id="check_1_7_2" class="middle check_1 check_1_7 checkbox" type="checkbox" value="发货管理"/><label class="middle" for="check_1_7_2">&nbsp;发货管理</label>
                </td>
            </tr>
            <tr>
                <td rowspan='6'>
                    <input id="check_2" onclick="selectCheckBox(this,'check_2');" class="middle" type="checkbox" value="查询统计"/><label class="middle" for="check_2">&nbsp;查询统计</label>
                </td>
                <td>
                    <input id="check_2_1" onclick="selectCheckBox(this,'check_2_1');" class="middle check_2" type="checkbox" value="综合查询"/><label class="middle" for="check_2_1">&nbsp;综合查询</label>
                </td>
                <td>
                    <input id="check_2_1_1" class="middle check_2 check_2_1 checkbox" type="checkbox" value="综合查询"/><label class="middle" for="check_2_1_1">&nbsp;综合查询</label>
                </td>
            </tr>
             <tr>
                <td rowspan='3'>
                    <input id="check_2_2" onclick="selectCheckBox(this,'check_2_2');" class="middle check_2" type="checkbox" value="工作量统计"/><label class="middle" for="check_2_2">&nbsp;工作量统计</label>
                </td>
                <td>
                    <input id="check_2_2_1" class="middle check_2 check_2_2 checkbox" type="checkbox" value="员工工作量统计"/><label class="middle" for="check_2_2_1">&nbsp;员工工作量统计</label>
                </td>
            </tr>
            <tr>
                <td>
                   <input id="check_2_2_2" class="middle check_2 check_2_2 checkbox" type="checkbox" value="员工工作量统计"/><label class="middle" for="check_2_2_2">&nbsp;煎药机工作里统计</label>
                </td>
            </tr>
            <tr>
                <td>
                   <input id="check_2_2_3" class="middle check_2 check_2_2 checkbox" type="checkbox" value="包装机工作里统计"/><label class="middle" for="check_2_2_3">&nbsp;包装机工作里统计</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_2_3" onclick="selectCheckBox(this,'check_2_3');" class="middle check_2" type="checkbox" value="配送统计"/><label class="middle" for="check_2_3">&nbsp;配送统计</label>
                </td>
                <td>
                    <input id="check_2_3_1" class="middle check_2 check_2_3 checkbox" type="checkbox" value="配送统计"/><label class="middle" for="check_2_3_1">&nbsp;配送统计</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_2_4" onclick="selectCheckBox(this,'check_2_4');" class="middle check_2" type="checkbox" value="业务员业务统计"/><label class="middle" for="check_2_4">&nbsp;业务员业务统计</label>
                </td>
                <td>
                    <input id="check_2_4_1" class="middle check_2 check_2_4 checkbox" type="checkbox" value="业务员业务统计"/><label class="middle" for="check_2_4_1">&nbsp;业务员业务统计</label>
                </td>
            </tr>

            <tr>
                <td rowspan='8'>
                    <input id="check_3" onclick="selectCheckBox(this,'check_3');" class="middle" type="checkbox" value="中心监控"/><label class="middle" for="check_3">&nbsp;中心监控</label>
                </td>
                <td>
                    <input id="check_3_1" onclick="selectCheckBox(this,'check_3_1');" class="middle check_3" type="checkbox" value="综合预警"/><label class="middle" for="check_3_1">&nbsp;综合预警</label>
                </td>
                <td>
                    <input id="check_3_1_1" class="middle check_3 check_3_1 checkbox" type="checkbox" value="综合预警"/><label class="middle" for="check_3_1_1">&nbsp;综合预警</label>
                </td>
            </tr>
            <tr>
                <td rowspan='2'>
                    <input id="check_3_2" onclick="selectCheckBox(this,'check_3_2');" class="middle check_3" type="checkbox" value="机组监控"/><label class="middle" for="check_3_2">&nbsp;机组监控</label>
                </td>
                <td>
                    <input id="check_3_2_1" class="middle check_3 check_3_2 checkbox" type="checkbox" value="煎药机监控"/><label class="middle" for="check_3_2_1">&nbsp;煎药机监控</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_3_2_2" class="middle check_3 check_3_2 checkbox" type="checkbox" value="包装机监控"/><label class="middle" for="check_3_2_2">&nbsp;包装机监控</label>
                </td>
            </tr>
            <tr>
                <td rowspan='3'>
                    <input id="check_3_3" onclick="selectCheckBox(this,'check_3_3');" class="middle check_3" type="checkbox" value="大屏显示"/><label class="middle" for="check_3_3">&nbsp;大屏显示</label>
                </td>
                <td>
                    <input id="check_3_3_1" class="middle check_3 check_3_3 checkbox" type="checkbox" value="泡药显示"/><label class="middle" for="check_3_3_1">&nbsp;泡药显示</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_3_3_2" class="middle check_3 check_3_3 checkbox" type="checkbox" value="煎药显示"/><label class="middle" for="check_3_3_2">&nbsp;煎药显示</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_3_3_3" class="middle check_3 check_3_3 checkbox" type="checkbox" value="发药显示"/><label class="middle" for="check_3_3_3">&nbsp;发药显示</label>
                </td>
            </tr>
            <tr>
                <td rowspan='2'>
                   <input id="check_3_4" onclick="selectCheckBox(this,'check_3_4');" class="middle check_3" type="checkbox" value="质量管理"/><label class="middle" for="check_3_4">&nbsp;质量管理</label> 
                </td>
                <td>
                    <input id="check_3_4_1" class="middle check_3 check_3_4 checkbox" type="checkbox" value="抽检录入"/><label class="middle" for="check_3_4_1">&nbsp;抽检录入</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_3_4_2" class="middle check_3 check_3_4 checkbox" type="checkbox" value="抽检列表查询"/><label class="middle" for="check_3_4_2">&nbsp;抽检列表查询</label>
                </td>
            </tr>
            <tr>
                <td rowspan='14'>
                    <input id="check_4" onclick="selectCheckBox(this,'check_4');" class="middle" type="checkbox" value="系统设置"/><label class="middle" for="check_4">&nbsp;系统设置</label>
                </td>
                <td rowspan='13'>
                    <input id="check_4_1" onclick="selectCheckBox(this,'check_4_1');" class="middle check_4" type="checkbox" value="系统设置"/><label class="middle" for="check_4_1">&nbsp;系统设置</label>
                </td>
                <td>
                    <input id="check_4_1_1" class="middle check_4 check_4_1 checkbox" type="checkbox" value="员工信息"/><label class="middle" for="check_4_1_1">&nbsp;员工信息</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_4_1_2" class="middle check_4 check_4_1 checkbox" type="checkbox" value="权限管理"/><label class="middle" for="check_4_1_2">&nbsp;权限管理</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_4_1_3" class="middle check_4 check_4_1 checkbox" type="checkbox" value="后台设置"/><label class="middle" for="check_4_1_3">&nbsp;后台设置</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_4_1_4" class="middle check_4 check_4_1 checkbox" type="checkbox" value="界面管理"/><label class="middle" for="check_4_1_4">&nbsp;界面管理</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_4_1_5" class="middle check_4 check_4_1 checkbox" type="checkbox" value="打印模块设置"/><label class="middle" for="check_4_1_5">&nbsp;打印模块设置</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_4_1_6" class="middle check_4 check_4_1 checkbox" type="checkbox" value="医院管理"/><label class="middle" for="check_4_1_6">&nbsp;医院管理</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_4_1_7" class="middle check_4 check_4_1 checkbox" type="checkbox" value="结算方管理"/><label class="middle" for="check_4_1_7">&nbsp;结算方管理</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_4_1_8" class="middle check_4 check_4_1 checkbox" type="checkbox" value="收件人管理"/><label class="middle" for="check_4_1_8">&nbsp;收件人管理</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_4_1_9" class="middle check_4 check_4_1 checkbox" type="checkbox" value="库房药方管理"/><label class="middle" for="check_4_1_9">&nbsp;库房药方管理</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_4_1_10" class="middle check_4 check_4_1 checkbox" type="checkbox" value="设备管理"/><label class="middle" for="check_4_1_10">&nbsp;设备管理</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_4_1_11" class="middle check_4 check_4_1 checkbox" type="checkbox" value="煎药室管理"/><label class="middle" for="check_4_1_11">&nbsp;煎药室管理</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_4_1_12" class="middle check_4 check_4_1 checkbox" type="checkbox" value="物流key设置"/><label class="middle" for="check_4_1_12">&nbsp;物流key设置</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_4_1_13" class="middle check_4 check_4_1 checkbox" type="checkbox" value="自动打印开关"/><label class="middle" for="check_4_1_13">&nbsp;自动打印开关</label>
                </td>
            </tr>
            <tr>
                <td >
                    <input id="check_4_2" onclick="selectCheckBox(this,'check_4_2');" class="middle check_5" type="checkbox" value="pda拍照设置"/><label class="middle" for="check_4_2">&nbsp;pda拍照设置</label>
                </td>
                <td>
                    <input id="check_4_2_1" class="middle check_4 check_4_2 checkbox" type="checkbox" value="拍照设置"/><label class="middle" for="check_4_2_1">&nbsp;拍照设置</label>
                </td>
            </tr>
            <tr>
                <td rowspan='18'>
                    <input id="check_5" onclick="selectCheckBox(this,'check_5');" class="middle" type="checkbox" value="库房管理"/><label class="middle" for="check_5">&nbsp;库房管理</label>
                </td>
                <td rowspan='9'>
                    <input id="check_5_1" onclick="selectCheckBox(this,'check_5_1');" class="middle check_5" type="checkbox" value="库房管理"/><label class="middle" for="check_5_1">&nbsp;库房管理</label>
                </td>
                <td>
                    <input id="check_5_1_1" class="middle check_5 check_5_1 checkbox" type="checkbox" value="员工信息"/><label class="middle" for="check_5_1_1">&nbsp;员工信息</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_5_1_2" class="middle check_5 check_5_1 checkbox" type="checkbox" value="入库管理"/><label class="middle" for="check_5_1_2">&nbsp;入库管理</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_5_1_3" class="middle check_5 check_5_1 checkbox" type="checkbox" value="入库列表查询"/><label class="middle" for="check_5_1_3">&nbsp;入库列表查询</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_5_1_4" class="middle check_5 check_5_1 checkbox" type="checkbox" value="调拨管理"/><label class="middle" for="check_5_1_4">&nbsp;调拨管理</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_5_1_5" class="middle check_5 check_5_1 checkbox" type="checkbox" value="调拨列表查询"/><label class="middle" for="check_5_1_5">&nbsp;调拨列表查询</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_5_1_6" class="middle check_5 check_5_1 checkbox" type="checkbox" value="库存信息"/><label class="middle" for="check_5_1_6">&nbsp;库存信息</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_5_1_7" class="middle check_5 check_5_1 checkbox" type="checkbox" value="库房盘点"/><label class="middle" for="check_5_1_7">&nbsp;库房盘点</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_5_1_8" class="middle check_5 check_5_1 checkbox" type="checkbox" value="报损信息"/><label class="middle" for="check_5_1_8">&nbsp;报损信息</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_5_1_9" class="middle check_5 check_5_1 checkbox" type="checkbox" value="报单查询"/><label class="middle" for="check_5_1_9">&nbsp;报单查询</label>
                </td>
            </tr>
            <tr>
                <td rowspan="7">
                    <input id="check_5_2" onclick="selectCheckBox(this,'check_5_2');" class="middle check_5" type="checkbox" value="药房管理"/><label class="middle" for="check_5_2">&nbsp;药房管理</label>
                </td>
                <td>
                    <input id="check_5_2_1" class="middle check_5 check_5_2 checkbox" type="checkbox" value="药房入库管理"/><label class="middle" for="check_5_2_1">&nbsp;药房入库管理</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_5_2_2" class="middle check_5 check_5_2 checkbox" type="checkbox" value="药房调拨管理"/><label class="middle" for="check_5_2_2">&nbsp;药房调拨管理</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_5_2_3" class="middle check_5 check_5_2 checkbox" type="checkbox" value="药房调拨单列表查询"/><label class="middle" for="check_5_2_3">&nbsp;药房调拨单列表查询</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_5_2_4" class="middle check_5 check_5_2 checkbox" type="checkbox" value="药房库存信息"/><label class="middle" for="check_5_2_4">&nbsp;药房库存信息</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_5_2_5" class="middle check_5 check_5_2 checkbox" type="checkbox" value="药房库房盘点"/><label class="middle" for="check_5_2_5">&nbsp;药房库房盘点</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_5_2_6" class="middle check_5 check_5_2 checkbox" type="checkbox" value="药房报损信息"/><label class="middle" for="check_5_2_6">&nbsp;药房报损信息</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_5_2_7" class="middle check_5 check_5_2 checkbox" type="checkbox" value="药房报单查询"/><label class="middle" for="check_5_2_7">&nbsp;药房报单查询</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_5_3" onclick="selectCheckBox(this,'check_5_3');" class="middle check_5" type="checkbox" value="药品管理"/><label class="middle" for="check_5_3">&nbsp;药品管理</label>
                </td>
                <td>
                    <input id="check_5_3_1" class="middle check_5 check_5_3 checkbox" type="checkbox" value="药品管理"/><label class="middle" for="check_5_3_1">&nbsp;药品管理</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_5_4" onclick="selectCheckBox(this,'check_5_4');" class="middle check_5" type="checkbox" value="药品匹配列表"/><label class="middle" for="check_5_4">&nbsp;药品匹配列表</label>
                </td>
                <td>
                    <input id="check_5_4_1" class="middle check_5 check_5_4 checkbox" type="checkbox" value="药品匹配列表"/><label class="middle" for="check_5_4_1">&nbsp;药品匹配列表</label>
                </td>
            </tr>
            <tr>
                <td rowspan='3'>
                    <input id="check_6" onclick="selectCheckBox(this,'check_6');" class="middle" type="checkbox" value="对账管理"/><label class="middle" for="check_6">&nbsp;对账管理</label>
                </td>
                <td rowspan='3'>
                    <input id="check_6_1" onclick="selectCheckBox(this,'check_6_1');" class="middle check_6" type="checkbox" value="医院对账管理"/><label class="middle" for="check_6_1">&nbsp;医院对账管理</label>
                </td>
                <td>
                    <input id="check_6_1_1" class="middle check_6 check_6_1 checkbox" type="checkbox" value="对账单"/><label class="middle" for="check_6_1_1">&nbsp;对账单</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_6_1_2" class="middle check_6 check_6_1 checkbox" type="checkbox" value="对账列表"/><label class="middle" for="check_6_1_2">&nbsp;对账列表</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_6_1_3" class="middle check_6 check_6_1 checkbox" type="checkbox" value="订单列表"/><label class="middle" for="check_6_1_3">&nbsp;订单列表</label>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="check_7" onclick="selectCheckBox(this,'check_7');" class="middle" type="checkbox" value="物流管理"/><label class="middle" for="check_7">&nbsp;物流管理</label>
                </td>
                <td>
                    <input id="check_7_1" onclick="selectCheckBox(this,'check_7_1');" class="middle check_7" type="checkbox" value="物流信息管理"/><label class="middle" for="check_7_1">&nbsp;物流信息管理</label>
                </td>
                <td>
                    <input id="check_7_1_1" class="middle check_7 check_7_1 checkbox" type="checkbox" value="物流信息"/><label class="middle" for="check_7_1_1">&nbsp;物流信息</label>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <input id="authorityText" type="hidden" runat="server"/>
                    <input id="aid" type="hidden" runat="server"/>
                    <label>&nbsp;</label><input runat="server" name="" type="button" class="btn" style="margin-top:10px;margin-bottom:10px;" onclick="btnSaveOnClick();" value="保存" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
