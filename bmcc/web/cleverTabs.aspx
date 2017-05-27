<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cleverTabs.aspx.cs" Inherits="cleverTabs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="CleverTabs/context/themes/base/style.css" type="text/css" />
    <link rel="Stylesheet" href="CleverTabs/context/themes/base/jquery-ui.css" type="text/css" />
    <script src="CleverTabs/scripts/jquery.js" type="text/javascript"></script>
    <script src="CleverTabs/scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="CleverTabs/scripts/jquery.contextMenu.js" type="text/javascript"></script>
    <script src="CleverTabs/scripts/jquery.cleverTabs.js" type="text/javascript"></script>
    <script type="text/javascript">
        var tabs;
        var tmpCount = 0;

        $(function () {

            tabs = $('#tabs').cleverTabs();
            $(window).bind('resize', function () {
                tabs.resizePanelContainer();
            });
            tabs.add({
                url: "frame/welcome.aspx",
                label:  "欢迎登录煎药系统"
            });
            
          


            $(function () {
                parent.geturlAndlabel();
            })

            /*  $('#btnAddMore').click(function () {
            tabs.add({
            url: 'tmp.htm?' + tmpCount++,
            label: 'tab' + tmpCount
            });
            });*/
        });
        function tabsAdd(url, label) {
          //  alert("url=" + url + ",label=" + label);
            tabs.add({
            url: url,
            label: label
            });

    }
    function loginview (){
        window.parent.loginview();

    }
    </script>
      <style type="text/css">
        html,body
        {
           padding:0px;
           
        }
       
      
    </style>

</head>
<body style="overflow-y:hidden;overflow-x:hidden;" >
    <div id="tabs" style="margin: 0px;height:100%;"   >
        <ul  >
        </ul>
    </div>
</body>
</html>
