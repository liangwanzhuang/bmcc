<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Frameset//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-frameset.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>北京东华原煎药管理系统</title>

    <script type="text/javascript">

    
        function geturlAndlabel() {
//            var page = parent.getPage();
//            if (page == 1) {
//                window.rightFrame.tabsAdd("view/recipe/RecipeGet.aspx", "处方录入");
//            }
//            
        }
        function tabsAdd(url, label) {

            window.rightFrame.tabsAdd(url, label);
        }

        function loginview() {
          
            window.parent.location.href = '../../login.aspx';

        }

    </script>

</head>  <frameset cols="190,*" framespacing="0" frameborder="no" border="0"  id="Frm" name="Frm">
<!-- scrolling="no" -->
    <frame  id = "left" noresize="" frameborder="no" name="left" src="frame/left_recipe.aspx">
	
    <frame id="right" scrolling="auto" noresize="" frameborder="0" name="rightFrame" >
	<!--<frame id="right" scrolling="auto" noresize="" frameborder="0" name="rightFrame" src="view/recipe/RecipeGet.aspx">-->
</frameset>

<noframes>
    <body>
    </body>
</noframes>
</html>
