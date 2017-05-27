<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printmode.aspx.cs" Inherits="view_recipe_printmode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>处方打印</title>
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/CheckActivX.js"></script>
    <object id="LODOP" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" width="0"
        height="0">
    </object>
    <script language="javascript" type="text/javascript">

        //
        var HKEY_Root, HKEY_Path, HKEY_Key;
        HKEY_Root = "HKEY_CURRENT_USER";
        HKEY_Path = "\\Software\\Microsoft\\Internet Explorer\\PageSetup\\";
        //设置网页打印的页眉页脚为空 
        function PageSetup_Null() {
            try {
                var Wsh = new ActiveXObject("WScript.Shell");
                HKEY_Key = "header";
                Wsh.RegWrite(HKEY_Root + HKEY_Path + HKEY_Key, "");
                HKEY_Key = "footer";
                Wsh.RegWrite(HKEY_Root + HKEY_Path + HKEY_Key, "");
            }
            catch (e)
               { }

        }
        function preview() {
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";

            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            // window.document.body.innerHTML = prnhtml;//预览功能
            window.print();
        }
        //
        function hospitalSelectChange(select) {
            var id = $(select).val();

            if (id == 1) {
                style = "display: none;"

                document.getElementById("print2").style.display = "none"; //隐藏
                document.getElementById("print3").style.display = "none"; //隐藏
                document.getElementById("print1").style.display = ""; //显示
            }

            if (id == 2) {
                style = "display: none;"

                document.getElementById("print1").style.display = "none"; //隐藏
                document.getElementById("print3").style.display = "none"; //隐藏
                document.getElementById("print2").style.display = ""; //显示
            }
            if (id == 3) {
                style = "display: none;"

                document.getElementById("print1").style.display = "none"; //隐藏
                document.getElementById("print2").style.display = "none"; //隐藏
                document.getElementById("print3").style.display = ""; //显示
            }
            if (id == 0) {
                document.getElementById("print1").style.display = ""; //显示
                document.getElementById("print2").style.display = ""; //显示
                document.getElementById("print3").style.display = ""; //显示
            }
        }

        function printok() {

            var id = $("#idnum").val();

            $.ajax({ type: "POST",
                url: "printmode.aspx/printokbyid",
                data: "{'id':\"" + id + "\"}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == 1) {
                        alert('打印确认成功');
                    } else {
                        alert('打印确认未成功');
                    }
                }
            });
        }

        $(function () {
            $("#Select1").val(1);
            hospitalSelectChange($("#Select1"));
        })
    </script>
    <script language="VBScript" type="text/vbscript">
            dim hkey_root,hkey_path,hkey_key
            hkey_root="HKEY_CURRENT_USER"
            hkey_path="\Software\Microsoft\Internet Explorer\PageSetup"
            '//设置网页打印的页眉页脚为空
            function pagesetup_null()
            // on error resume next 
                Set RegWsh = CreateObject("WScript.Shell")
                hkey_key="\header"    
                RegWsh.RegWrite hkey_root+hkey_path+hkey_key,""
                hkey_key="\footer"
                RegWsh.RegWrite hkey_root+hkey_path+hkey_key,""
            end function

    </script>
    <script language="javascript" type="text/javascript">
        function prn1_preview() {
            CreateOneFormPage();
            LODOP.PREVIEW();
        };
        function prn1_print() {
            CreateOneFormPage();
            LODOP.PRINT();
        };
        function prn1_printA() {
            CreateOneFormPage();
            LODOP.PRINTA();
        };
        function CreateOneFormPage() {
            LODOP.PRINT_INIT("打印表单一");
            //LODOP.ADD_PRINT_TEXT(50,231,260,39,"打印页面部分内容");
            // LODOP.SET_PRINT_TEXT_STYLE(1,"宋体",18,1,0,0,1);
            LODOP.ADD_PRINT_HTM(10, 20, 350, 600, document.getElementById("form1").innerHTML);
        };	
    </script>
    <style type="text/css" media="print">
        .noprint
        {
            visibility: hidden;
        }
        
        hr
        {
            border: 1px #cccccc dotted;
        }
        .content
        {
            width: 1000px;
            height: 800px;
            position: absolute;
            left: 50%;
            top: 50%;
            margin-left: -200px;
            margin-top: -500px;
        }
        #table-d
        {
            text-align: center;
            margin: 0 auto;
        }
        
        .c
        {
            padding-left: 200px;
        }
        
        .wrap
        {
            margin: 0 auto;
            width: 500px;
        }
        .table-d table
        {
            background: white;
            border: none;
            border-collapse: collapse;
            text-align: center;
        }
        .table-d table td
        {
            background: #FFF;
            border: none;
        }
        
        
        /*.first{ float:left;width:49%;border:1px solid #F00} 
.second{ float:left;width:49%;border:1px solid #000} 
css注释：设置table背景为红色，td背景为白色 */
    </style>
</head>
<body onload="pagesetup_null()">
    <form id="form1" runat="server">
    <%--调配单 --%>
    <!--startprint-->
    <div id="print1" style="display: none;" runat="server">
        <input id="idnum" runat="server" type="hidden" name="FunName" />
        <div class="printdiv" style="text-align: center;">
            <label style="font-size: 40px;">
                调配单</label>
            <div style="text-align: left;">
                <ul style="list-style: none; margin: 0; padding: 0;">
                    <li>取&nbsp;药&nbsp;号&nbsp;:&nbsp;<asp:Label ID="getdrugnum" runat="server" /></li>
                    <li>取药时间:&nbsp;&nbsp;&nbsp;<asp:Label ID="getdrugtime" runat="server" /></li>
                    <li>用&nbsp;&nbsp;&nbsp法:<asp:Label ID="Label1" runat="server" /></li>
                    <li>打印时间:&nbsp;&nbsp;&nbsp;<asp:Label ID="printtime" runat="server" /></li>
                </ul>
            </div>
            <hr size="1" noshade="noshade" />
            <div id="Div20" style="margin: 0 auto; width: 800px; height: 50px;">
                <div id="div41" runat="server" style="display: none; float: left;">
                    <label>
                        姓名:</label><asp:Label ID="namebar3" runat="server" Text="" /></div>
                <div id="div42" runat="server" style="display: none; float: left;">
                    <label>
                        &nbsp;性别:</label><asp:Label ID="sexbar3" runat="server" Text="" /></div>
                <div id="div43" runat="server" style="display: none; float: left;">
                    <label>
                        &nbsp;年龄:</label>
                    <asp:Label ID="agebar3" runat="server" Text="" /></div>
                <div id="div44" runat="server" style="display: none; float: left;">
                    <label>
                        &nbsp;床位号:</label>
                    <asp:Label ID="roomnumbar3" runat="server" Text="" /></div>
                <div id="div45" runat="server" style="display: none; float: left;">
                    <label>
                        &nbsp;医院名称:</label><asp:Label ID="hospitalnamebar3" runat="server" /></div>
                <div id="div46" runat="server" style="display: none; float: left;">
                    <label>
                        &nbsp;处方号:</label><asp:Label ID="pspnumbar3" runat="server" /></div>
                <div id="div47" runat="server" style="display: none; float: left;">
                    <label>
                        &nbsp;煎药方案:</label><asp:Label ID="strSchemebar3" runat="server" /></div>
                <div id="div48" runat="server" style="display: none; float: left;">
                    <label>
                        &nbsp;病区号:</label><asp:Label ID="strInpatientAreaNumbar3" runat="server" /></div>
                <div id="div49" runat="server" style="display: none; float: left;">
                    <label>
                        &nbsp;病房号:</label><asp:Label ID="strWardbar3" runat="server" /></div>
                <div id="div51" runat="server" style="display: none; float: left;">
                    <label>
                        &nbsp;科室:</label><asp:Label ID="strDepartmentbar3" runat="server" /></div>
                <div id="div52" runat="server" style="display: none; float: left;">
                    <label>
                        &nbsp;贴数:</label><asp:Label ID="dosebar3" runat="server" /></div>
                <div id="div53" runat="server" style="display: none; float: left;">
                    <label>
                        &nbsp;次数:</label><asp:Label ID="nNumbar3" runat="server" /></div>
                <div id="div54" runat="server" style="display: none; float: left;">
                    <label>
                        &nbsp;包装量:</label><asp:Label ID="nPackageNumbar3" runat="server" /></div>
                <div id="div55" runat="server" style="display: none; float: left;">
                    <label>
                        &nbsp;取药时间:</label><asp:Label ID="strDrugGetTimebar3" runat="server" /></div>
                <div id="div56" runat="server" style="display: none; float: left;">
                    <label>
                        &nbsp;下单时间:</label><asp:Label ID="ordertimebar3" runat="server" /></div>
                <div id="div57" runat="server" style="display: none; float: left;">
                    <label>
                        &nbsp;取药号:</label><asp:Label ID="strDrugGetNumbar3" runat="server" /></div>
                <div id="div58" runat="server" style="display: none; float: left;">
                    <label>
                        &nbsp;煎药方式:</label><asp:Label ID="decmothedbar3" runat="server" /></div>
                <div id="div59" runat="server" style="display: none; float: left;">
                    <label>
                        &nbsp;服用方式:</label><asp:Label ID="takemethodbar3" runat="server" /></div>
                <div id="div60" runat="server" style="display: none; float: left;">
                    <label>
                        &nbsp;服用方法:</label><asp:Label ID="takewaybar3" runat="server" /></div>
            </div>
            <hr size="1" noshade="noshade" />
            <div class="wrap">
                <asp:Repeater ID="rpTest" runat="server">
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <th style="width: 350px; height: 30px">
                                    序号
                                </th>
                                <th style="width: 350px; height: 30px">
                                    货位
                                </th>
                                <th style="width: 350px; height: 30px">
                                    药品名称
                                </th>
                                <th style="width: 350px; height: 30px">
                                    药品规格
                                </th>
                                <th style="width: 300px; height: 30px">
                                    总量
                                </th>
                                <th style="width: 350px; height: 30px">
                                    单剂量
                                </th>
                                <th style="width: 300px; height: 30px">
                                    脚注
                                </th>
                                <th style="width: 300px; height: 30px">
                                    药师说明
                                </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblID" Text='<%# Eval("ID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="Label2" Text='<%# Eval("ypcdrugPositionNum") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="Label4" Text='<%# Eval("drugname") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblTitle" Text='<%# Eval("DrugPosition") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblText" Text='<%# Eval("DrugWeight") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="Label3" Text='<%# Eval("DrugAllNum") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="Label11" Text='<%# Eval("drugdescription") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="Label7" Text='<%# Eval("description") %>'></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblID" Text='<%# Eval("ID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="Label5" Text='<%# Eval("ypcdrugPositionNum") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="Label6" Text='<%# Eval("drugname") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblTitle" Text='<%# Eval("DrugPosition") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblText" Text='<%# Eval("DrugWeight") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="Label3" Text='<%# Eval("DrugAllNum") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="Label11" Text='<%# Eval("drugdescription") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="Label8" Text='<%# Eval("description") %>'></asp:Label>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <hr size="1" noshade="noshade" />
            <div class="rmarks" style="text-align: left;">
                <ul style="list-style: none;">
                    <li class="a">备注：<br />
                        <br />
                        <br />
                    </li>
                    <li class="b">特殊说明：<br />
                        <br />
                    </li>
                    <li class="c">调剂：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;复核：</li>
                    <%-- <li class ="d">复核：</li>--%>
                </ul>
            </div>
        </div>
    </div>
    <%--调配条码--%>
    <div id="print2" style="display: none; width: 100%;" runat="server">
        <div>
            <ul style="list-style: none; text-align: left; margin: 0; padding: 0;">
                <li>
                    <label style="font-size: 10px;">
                        调配条码</label></li>
                <li>
                    <asp:Image ID="Image1" runat="server" Width="270" Height="36" />
                </li>
                <li>
                    <asp:Label ID="barcode" runat="server" Style="font-size: 10px;"></asp:Label></li>
                <li></li>
            </ul>
        </div>
        <div style="width: 250px; height: 14px;">
            <div id="div16" runat="server" style="display: none; float: left; width: 75px">
                <asp:Label ID="namebar" runat="server" Text="" Style="font-size: 10px;" /></div>
            <div id="div17" runat="server" style="display: none; float: left; width: 15px">
                <asp:Label ID="sexbar" runat="server" Text="" Style="font-size: 10px;" /></div>
            <div id="div18" runat="server" style="display: none; float: left; width: 15px">
                <asp:Label ID="agebar" runat="server" Text="" Style="font-size: 10px;" /></div>
            <div id="div19" runat="server" style="display: none; float: left; width: 40px">
                <asp:Label ID="roomnumbar" runat="server" Text="" Style="font-size: 10px;" /></div>
        </div>
        <div style="width: 250px; height: 12px;">
            <div id="div1" runat="server" style="display: none; position: absolute; left: 10px;
                width: 120px">
                <label style="font-size: 10px;">
                    来源:&nbsp;</label><asp:Label ID="hospitalnamebar" runat="server" Style="font-size: 10px;" />
            </div>
            <div id="div14" runat="server" style="display: none; position: absolute; left: 150px;
                width: 80px">
                <asp:Label ID="takemethodbar" runat="server" Style="font-size: 10px;" />
            </div>
        </div>
        <div id="barcodeinfo" runat="server" style="width: 250px; height: 12px;">
            <div id="div2" runat="server" style="display: none; float: left; width: 150px;">
                <label style="font-size: 10px;">
                    处方号:&nbsp;</label><asp:Label ID="pspnumbar" runat="server" Style="font-size: 10px;" /></div>
            <div id="div3" runat="server" style="display: none; float: left; width: 80px;">
                <label style="font-size: 10px;">
                    煎药方案:&nbsp;</label><asp:Label ID="strSchemebar" runat="server" Style="font-size: 10px;" /></div>
            <div id="div7" runat="server" style="display: none; float: left; width: 60px;">
                <label style="font-size: 10px;">
                    贴数:&nbsp;</label><asp:Label ID="dosebar" runat="server" Style="font-size: 10px;" /></div>
            <div id="div8" runat="server" style="display: none; float: left; width: 60px;">
                <label style="font-size: 10px;">
                    次数:&nbsp;</label><asp:Label ID="nNumbar" runat="server" Style="font-size: 10px;" /></div>
            <div id="div9" runat="server" style="display: none; float: left; width: 80px;">
                <label style="font-size: 10px;">
                    包装量:&nbsp;</label><asp:Label ID="nPackageNumbar" runat="server" Style="font-size: 10px;" /></div>
            <div id="div4" runat="server" style="display: none; float: left; width: 80px;">
                <label style="font-size: 10px;">
                    病区号:&nbsp;</label><asp:Label ID="strInpatientAreaNumbar" runat="server" Style="font-size: 10px;" /></div>
            <div id="div5" runat="server" style="display: none; float: left; width: 80px;">
                <label style="font-size: 10px;">
                    病房号:&nbsp;</label><asp:Label ID="strWardbar" runat="server" Style="font-size: 10px;" /></div>
            <div id="div6" runat="server" style="display: none; float: left; width: 80px;">
                <label style="font-size: 10px;">
                    科室:&nbsp;</label><asp:Label ID="strDepartmentbar" runat="server" Style="font-size: 10px;" /></div>
            <div id="div12" runat="server" style="display: none; float: left; width: 80px;">
                <label style="font-size: 10px;">
                    取药号:&nbsp;</label><asp:Label ID="strDrugGetNumbar" runat="server" Style="font-size: 10px;" /></div>
            <div id="div13" runat="server" style="display: none; float: left; width: 100px;">
                <label style="font-size: 5px;">
                    煎药方式:&nbsp;</label><asp:Label ID="decmothedbar" runat="server" Style="font-size: 10px;" /></div>
            <div id="div15" runat="server" style="display: none; float: left; width: 100px;">
                <label style="font-size: 10px;">
                    服用方法:&nbsp;</label><asp:Label ID="takewaybar" runat="server" Style="font-size: 10px;" /></div>
            <div id="div10" runat="server" style="display: none; float: left; width: 175px;">
                <label style="font-size: 10px;">
                    取药时间:&nbsp;</label><asp:Label ID="strDrugGetTimebar" runat="server" Style="font-size: 10px;" /></div>
            <div id="div11" runat="server" style="display: none; float: left; width: 175px;">
                <label style="font-size: 10px;">
                    下单时间:&nbsp;</label><asp:Label ID="ordertimebar" runat="server" Style="font-size: 10px;" /></div>
        </div>
    </div>
    <div id="print3" style="display: none; width: 100%; float: left; margin-left: 1px;"
        runat="server">
        <div>
            <ul style="list-style: none; text-align: left; margin: 0; padding: 0;">
                <li>
                    <label style="font-size: 10px;">
                        包装条码</label></li>
                <li>
                    <asp:Image ID="Image2" runat="server" Width="270" Height="36" />
                </li>
                <li>
                    <asp:Label ID="packbarcode" runat="server" Style="font-size: 10px;"></asp:Label></li>
            </ul>
        </div>
        <div style="width: 250px; height: 14px;">
            <div id="div22" runat="server" style="display: none; float: left; width: 75px">
                <asp:Label ID="namebar1" runat="server" Text="" Style="font-size: 10px;" /></div>
            <div id="div23" runat="server" style="display: none; float: left; width: 15px">
                <asp:Label ID="sexbar1" runat="server" Text="" Style="font-size: 10px;" /></div>
            <div id="div24" runat="server" style="display: none; float: left; width: 15px">
                <asp:Label ID="agebar1" runat="server" Text="" Style="font-size: 10px;" /></div>
            <div id="div25" runat="server" style="display: none; float: left; width: 40px">
                <asp:Label ID="roomnumbar1" runat="server" Text="" Style="font-size: 10px;" /></div>
        </div>
        <div style="width: 250px; height: 12px;">
            <div id="div26" runat="server" style="display: none; position: absolute; left: 10px;
                width: 120px">
                <label style="font-size: 10px;">
                    来源:&nbsp;</label><asp:Label ID="hospitalnamebar1" runat="server" Style="font-size: 10px;" />
            </div>
            <div id="div39" runat="server" style="display: none; position: absolute; left: 150px;
                width: 80px">
                <asp:Label ID="takemethodbar1" runat="server" Style="font-size: 10px;" />
            </div>
        </div>
        <div style="width: 250px; height: 12px;">
            <div id="div27" runat="server" style="display: none; float: left; width: 150px;">
                <label style="font-size: 10px;">
                    处方号:&nbsp;</label><asp:Label ID="pspnumbar1" runat="server" Style="font-size: 10px;" /></div>
            <div id="div28" runat="server" style="display: none; float: left; width: 80px;">
                <label style="font-size: 10px;">
                    煎药方案:&nbsp;</label><asp:Label ID="strSchemebar1" runat="server" Style="font-size: 10px;" /></div>
            <div id="div32" runat="server" style="display: none; float: left; width: 60px;">
                <label style="font-size: 10px;">
                    贴数:&nbsp;</label><asp:Label ID="dosebar1" runat="server" Style="font-size: 10px;" /></div>
            <div id="div33" runat="server" style="display: none; float: left; width: 60px;">
                <label style="font-size: 10px;">
                    次数:&nbsp;</label><asp:Label ID="nNumbar1" runat="server" Style="font-size: 10px;" /></div>
            <div id="div34" runat="server" style="display: none; float: left; width: 80px;">
                <label style="font-size: 10px;">
                    包装量:&nbsp;</label><asp:Label ID="nPackageNumbar1" runat="server" Style="font-size: 10px;" /></div>
            <div id="div29" runat="server" style="display: none; float: left; width: 80px;">
                <label style="font-size: 10px;">
                    病区号:&nbsp;</label><asp:Label ID="strInpatientAreaNumbar1" runat="server" Style="font-size: 10px;" /></div>
            <div id="div30" runat="server" style="display: none; float: left; width: 80px;">
                <label style="font-size: 10px;">
                    病房号:&nbsp;</label><asp:Label ID="strWardbar1" runat="server" Style="font-size: 10px;" /></div>
            <div id="div31" runat="server" style="display: none; float: left; width: 80px;">
                <label style="font-size: 10px;">
                    科室:&nbsp;</label><asp:Label ID="strDepartmentbar1" runat="server" Style="font-size: 10px;" /></div>
            <div id="div37" runat="server" style="display: none; float: left; width: 80px;">
                <label style="font-size: 10px;">
                    取药号:&nbsp;</label><asp:Label ID="strDrugGetNumbar1" runat="server" Style="font-size: 10px;" /></div>
            <div id="div38" runat="server" style="display: none; float: left; width: 100px;">
                <label style="font-size: 10px;">
                    煎药方式:&nbsp;</label><asp:Label ID="decmothedbar1" runat="server" Style="font-size: 10px;" /></div>
            <div id="div40" runat="server" style="display: none; float: left; width: 100px;">
                <label style="font-size: 10px;">
                    服用方法:&nbsp;</label><asp:Label ID="takewaybar1" runat="server" Style="font-size: 10px;" /></div>
            <div id="div35" runat="server" style="display: none; float: left; width: 175px;">
                <label style="font-size: 10px;">
                    取药时间:&nbsp;</label><asp:Label ID="strDrugGetTimebar1" runat="server" Style="font-size: 10px;" /></div>
            <div id="div36" runat="server" style="display: none; float: left; width: 175px;">
                <label style="font-size: 10px;">
                    下单时间:&nbsp;</label><asp:Label ID="ordertimebar1" runat="server" Style="font-size: 10px;" /></div>
        </div>
    </div>
    <!--endprint-->
    <div style="float: left; margin-left: 30px;" class="noprint">
        <select id="Select1" runat="server" class="dfinput" name="getperson" onchange="hospitalSelectChange(this);">
        </select><label>&nbsp;&nbsp;</label>
        <!-- prn1_preview prn1_printA-->
        <!--<input name="" type="button" class="btn" value="打印"  onclick="prn1_printA()"   rel="external nofollow" target="_self" />-->
        <input name="" type="button" class="btn" value="打印" onclick="preview()" rel="external nofollow"
            target="_self" />
        <input name="" type="button" class="btn" value="确认已打印" onclick="printok()" />
        <input name="" type="button" class="btn" value="返回上一页" onclick="javascript:history.back(-1)" /></div>
    <input type="hidden" name="qingkongyema" id="qingkongyema" class="tab" value="清空页码"
        onclick="pagesetup_null()" />&nbsp;&nbsp;
    </form>
</body>
</html>
