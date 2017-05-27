<%@ Control Language="C#" AutoEventWireup="true" CodeFile="dotNetFlexGrid.ascx.cs" Inherits="dotNetFlexGrid" %>
<%if (false)
  { %>
<script type="text/javascript" src="JS/jquery-1.4.2.js"></script>
<script type="text/javascript" src="JS/jquery-1.4.2-vsdoc.js"></script>
<%
  }
%>
<asp:HiddenField ID="checkedRows" runat="server" Value="" 
    EnableViewState="False" />
<table id="flexigrid_<%= ClientID %>">
<tr>
<td>
<%if (false)
  { %>
dotNetFlexGrid
<%} %>
</td>
</tr>
</table>
<script type="text/javascript">
/*操作类定义*/
function <%= ClientID %>_class()
{
}
<%= ClientID %>_class.prototype.checkRowsField='<%=HideCheckedRowsControlId %>';
<%= ClientID %>_class.prototype.gridId="flexigrid_<%= ClientID %>";
<%= ClientID %>_class.prototype.getSelectedRowsIds = function(){
    return $("#flexigrid_<%= ClientID %>").getSelectedRowsIds();
};
<%= ClientID %>_class.prototype.getSelectedRows = function(){
    return $("#flexigrid_<%= ClientID %>").getSelectedRows();
};
<%= ClientID %>_class.prototype.deleteRows = function(rows){
    $("#flexigrid_<%= ClientID %>").deleteRow(rows);
};
<%= ClientID %>_class.prototype.insertNewRow = function(row){
    $("#flexigrid_<%= ClientID %>").insertNewRow(row);
};
<%= ClientID %>_class.prototype.reflashData = function(){
    $("#flexigrid_<%= ClientID %>").flexReload();
};
<%= ClientID %>_class.prototype.getCellDatas = function(id){
    return $("#flexigrid_<%= ClientID %>").getCellDatas(id);
};
<%= ClientID %>_class.prototype.getGridJsonData = function(){
    return $("#flexigrid_<%= ClientID %>").getGridJsonData();
};
<%= ClientID %>_class.prototype.updateRowData=function(row){
    $("#flexigrid_<%= ClientID %>").updateRowData(row);
};
<%= ClientID %>_class.prototype.containsRowId=function(rowid){
    return $("#flexigrid_<%= ClientID %>").containsRowId(rowid);
};
<%= ClientID %>_class.prototype.applyQueryReload = function(p){
    $(p).each(function(){
        if(this.value)
            this.value =base64encode(utf16to8(this.value));
    });
    flexigrid_<%= ClientID %>.setNewExtParam(p);
    flexigrid_<%= ClientID %>.flexReload();
};
<%= ClientID %>_class.prototype.clientGridShow =function()
{
    //加载完样式才显示Grid
    /*事件定义和挂接*/
    <%= ClientID %>_class.prototype.onClick = <%=((EventOnClickFunc==null||EventOnClickFunc.Length==0)?"null":EventOnClickFunc) %>;
    <%= ClientID %>_class.prototype.onDbClick = <%=((EventOnDbClickFunc==null||EventOnDbClickFunc.Length==0)?"null":EventOnDbClickFunc) %>;
    <%= ClientID %>_class.prototype.onChecked = <%=((EventOnCheckedFunc==null||EventOnCheckedFunc.Length==0)?"null":EventOnCheckedFunc) %>;
    <%= ClientID %>_class.prototype.onUnChecked = <%=((EventOnUnCheckedFunc==null||EventOnUnCheckedFunc.Length==0)?"null":EventOnUnCheckedFunc) %>;
    <%= ClientID %>_class.prototype.onLoad = <%=((EventOnLoadFunc==null||EventOnLoadFunc.Length==0)?"null":EventOnLoadFunc) %>;
    <%= ClientID %>_class.prototype.onSelected = <%=((EventOnSelectedFunc==null||EventOnSelectedFunc.Length==0)?"null":EventOnSelectedFunc) %>;
    /*事件end*/
    flexigrid_<%= ClientID %>=$("#flexigrid_<%= ClientID %>").flexigrid
    (
	    {
	    url:'<%=GridRequestUrl %>',
	    /*GridConfigText Start*/
<%=GridConfigText %>
	    /*GridConfigText End*/
	    colModel : [
	    /*FieldConfigText Start*/
<%= FieldConfigText%>
	    /*FieldConfigText End*/	
	    ],
	    searchitems: [
	    /*SerchParamConfigText Start*/
<%=SerchParamConfigText %>
	    /*SerchParamConfigText End*/
	        ],
	    extParam: [
	        /*ExtParamConfigText Text Start*/
<%= ExtParamConfigText %>
	        /*ExtParamConfig Text End*/
	        ],
	    rowbinddata:false,
	    rowhandler:flexigrid_<%= ClientID %>_event.RowHandle,
	    onSuccess:flexigrid_<%= ClientID %>_event.onLoad,
	    onrowchecked:flexigrid_<%= ClientID %>_event.onRowChecked
	    }
    );
};
var <%= ClientID %>=new <%= ClientID %>_class();

/*定义end*/

var flexigrid_<%= ClientID %>;
var flexigrid_<%= ClientID %>_event=new flexigrid_eventHandle(<%= ClientID %>);
$(document).ready(function()
{
    var css="<%=IncludeCssNameText %>";
    loadStyleSheet(css);
    <%= ClientID %>.clientGridShow();

});
</script>
