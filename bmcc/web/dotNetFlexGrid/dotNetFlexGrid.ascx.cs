using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

public partial class dotNetFlexGrid : System.Web.UI.UserControl,IPostBackDataHandler
{
    private const string DEFAULT_ControlPathConfig = "/dotNetFlexGrid";// TODO:ControlCurrentPath 配置点：根据控件的实际路径配置
    
    #region 辅助类型定义
    /// <summary>
    /// 字段格式化处理函数
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public delegate string FieldFormatorHandle(DataRow dr);
    /// <summary>
    /// 字段格式化处理器
    /// </summary>
    public class FieldFormator
    {
        public string field;
        public FieldFormatorHandle handle;
    }
    /// <summary>
    /// 字段格式化管理器
    /// </summary>
    public class FieldFormatorManager
    {
        private Dictionary<string, FieldFormator> _FormatorList;
        public Dictionary<string, FieldFormator> FormatorList
        {
            get { return _FormatorList; }
        }
        public FieldFormatorManager()
        {
            _FormatorList = new Dictionary<string, FieldFormator>();
        }
        /// <summary>
        /// 注册一个字段格式化处理函数
        /// </summary>
        /// <param name="field"></param>
        /// <param name="handle"></param>
        public void Register(string field, FieldFormatorHandle handle)
        {
            if (field != null && handle != null)
            {
                FieldFormator f = new FieldFormator();
                f.field = field;
                f.handle = handle;
                if (FormatorList.ContainsKey(field))
                    FormatorList[field] = f;
                else
                    FormatorList.Add(field, f);
            }
        }
    }
    /// <summary>
    /// 扩展的Post传递参数配置，用于InitConfig
    /// </summary>
    public class ExtParamConfig
    {
        public string _name;
        public string _value;
        public ExtParamConfig(string name, string value)
        {
            _name = name;
            _value = value;
        }
    }
    /// <summary>
    /// 快速查询配置的查询操作定义，用于InitConfig
    /// </summary>
    public enum SerchParamConfigOperater
    {
        None=0,
        Eq=1,
        Like=2
    }
    /// <summary>
    /// 快速查询参数配置，用于InitConfig
    /// </summary>
    public class SerchParamConfig
    {
        /// <summary>
        /// 显示名
        /// </summary>
        public string _display;
        /// <summary>
        /// 字段名，用于查询参数名
        /// </summary>
        public string _name;
        /// <summary>
        /// 是否默认查询项
        /// </summary>
        public bool _isdefault;
        /// <summary>
        /// 查询操作
        /// </summary>
        public SerchParamConfigOperater _operater;
        /// <summary>
        /// 验证用正则表达式
        /// </summary>
        public string _reg;

        public SerchParamConfig(string display, string name, bool isdefault, SerchParamConfigOperater operater, string reg)
        {
            _display = display;
            _name = name;
            _isdefault = isdefault;
            _operater = operater;
            _reg = reg;
        }
    }
    /// <summary>
    /// Grid字段配置的字段对齐配置，用于InitConfig
    /// </summary>
    public enum FieldConfigAlign
    {
        Left=0,
        Right=1,
        Center=2

    }
    /// <summary>
    /// Grid字段配置，用于InitConfig
    /// </summary>
    public class FieldConfig
    {
        public string _display;
        public string _name;
        public int _width;
        public bool _sortable;
        public FieldConfigAlign _align;
        public bool _hide;
        public bool _toggle;
        public bool _checkField;
        public string _ItemTemplate;//列的渲染模板

        public FieldConfig(string name, string display, int width, bool sortable, FieldConfigAlign align, bool checkField, bool hide, bool toggle, string itemTemplate)
        {
            this._name = name;
            this._display = display;
            this._width = width;
            this._sortable = sortable;
            this._align = align;
            this._hide = hide;
            this._toggle = toggle;
            this._checkField = checkField;
            this._ItemTemplate = itemTemplate;
        }
        public FieldConfig(string name, string display, int width, bool sortable, FieldConfigAlign align)
            : this(name, display, width, sortable, align, false, false, true, null)
        {
        }
        public FieldConfig(string name, string display, int width, bool sortable, FieldConfigAlign align,bool checkField)
            : this(name, display, width, sortable, align, checkField, false, true, null)
        {
        }
        public FieldConfig(string name, string display, int width, bool sortable, FieldConfigAlign align, bool checkField,bool hide, bool toggle)
            : this(name, display, width, sortable, align, checkField, hide, toggle, null)
        {
        }
    }
    /// <summary>
    /// 数据生成函数的返回结果
    /// </summary>
    public class DataHandlerResult
    {
        /// <summary>
        /// 返回的数据页号
        /// </summary>
        public int page;
        /// <summary>
        /// 返回的总记录行数
        /// </summary>
        public int total;
        /// <summary>
        /// 包含数据的DataTable
        /// </summary>
        public DataTable table;
        private FieldFormatorManager _FieldFormator;
        /// <summary>
        /// 字段格式化管理器
        /// </summary>
        public FieldFormatorManager FieldFormator
        {
            get {
                if (_FieldFormator == null)
                    _FieldFormator = new FieldFormatorManager();
                return _FieldFormator;
            }
            
        }
    }
    /// <summary>
    /// 异步请求的参数信息
    /// </summary>
    public class DataHandlerParams
    {
        /// <summary>
        /// 初始化时的默认查询条件
        /// </summary>
        public Dictionary<string,string> defaultSearch;
        /// <summary>
        /// 请求页，即为分页中需要到达的页
        /// </summary>
        public int page;//请求页
        /// <summary>
        /// 需要返回的行数
        /// </summary>
        public int rp;//行数
        /// <summary>
        /// 快速查询的操作符
        /// </summary>
        public SerchParamConfigOperater qop;//查询操作符
        /// <summary>
        /// 快速查询的字段名
        /// </summary>
        public string qtype;
        /// <summary>
        /// 快速查询的字段值
        /// </summary>
        public string query;//搜索查询的条件
        /// <summary>
        /// 排序字段
        /// </summary>
        public string sortname;
        /// <summary>
        /// 排序方式,asc or desc
        /// </summary>
        public string sortorder;
        /// <summary>
        /// 附加的扩展参数，可以用作表单数据的传递
        /// </summary>
        public Dictionary<string, string> extParam;//扩展参数
        /// <summary>
        /// 控件字段参数配置的字典,key=字段名
        /// </summary>
        public Dictionary<string,dotNetFlexGrid.FieldConfig> fieldConfigs;
    }
    /// <summary>
    /// 数据处理函数的委托定义
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public delegate DataHandlerResult DataHandlerDelegate(DataHandlerParams p);
    #endregion
    #region 提供给页面的方法、属性
    private string _ControlCurrentPath;
    /// <summary>
    /// MODIFY at 8-21:修改为由DEFAULT_ControlPathConfig提供参数，请不要再修改此处代码
    /// </summary>
    protected string ControlCurrentPath
    {
        get
        {
            string result = string.Empty;
            if (_ControlCurrentPath != null && _ControlCurrentPath.Length > 0)
                result = _ControlCurrentPath;
            else
            {
                _ControlCurrentPath = string.Empty;
                if (_BasePath != null && _BasePath.Length > 0)
                {
                    _ControlCurrentPath = _BasePath;
                }
                else
                {
                    _ControlCurrentPath = DEFAULT_ControlPathConfig;
                }
                if (!_ControlCurrentPath.StartsWith("/")) _ControlCurrentPath ="/"+ _ControlCurrentPath;
                if (!_ControlCurrentPath.EndsWith("/")) _ControlCurrentPath = _ControlCurrentPath + "/";
                if(Request.ApplicationPath.Length>0&&Request.ApplicationPath!="/")
                    _ControlCurrentPath = Request.ApplicationPath + _ControlCurrentPath;
                result = _ControlCurrentPath;
            }
            string localDir = string.Empty;
            try
            {
                localDir = Server.MapPath(result);
            }
            catch
            {
                throw new ApplicationException("dotNetFlexGrid.ControlCurrentPath()出现异常，控件目录'" + result + "'映射错误，请检查您的BasePath或DEFAULT_ControlPathConfig配置");
            }
            if (!System.IO.Directory.Exists(localDir))
            {
                throw new ApplicationException("dotNetFlexGrid.ControlCurrentPath()出现异常，控件目录'" + result + "'不存在，请检查您的BasePath或DEFAULT_ControlPathConfig配置");
            }
            if(!System.IO.File.Exists(localDir+"dotNetFlexGrid.ascx"))
            {
                throw new ApplicationException("dotNetFlexGrid.ControlCurrentPath()出现异常，控件文件'" + localDir + "dotNetFlexGrid.ascx" + "'不存在，请检查您的BasePath或DEFAULT_ControlPathConfig配置");
            }
            
            return result;
        }
    }
    private string _BasePath;
    /// <summary>
    /// 提供控件的基础路径配置
    /// </summary>
    public string BasePath
    {
        get
        {
            return _BasePath;
        }
        set
        {
            if (value != null && value.Trim().Length > 0)
            {
                _BasePath = value.Trim();
            }
            else
            {
                _BasePath = null;
            }
        }
    }
    protected string GridRequestUrl 
    {
        get
        {
            string url = string.Empty;
            if(_DataHandler!=null){

                string funcName = (_DataHandler == null) ? "" : _DataHandler.Method.Name;
                string className = this.Page.GetType().BaseType.FullName
                    + ","
                    + this.Page.GetType().BaseType.Assembly.GetName().Name;
                url = ControlCurrentPath + "dotNetFlexGridAsyn.aspx?cid=" + this.ClientID + "&class=" + className + "&func=" + funcName;
                //url= ControlCurrentPath + "dotNetFlexGridAsyn.aspx?cid=" + this.ClientID + "&class=" + ClassName + "&func=" + DataHandlerFunc;
                
            }
            return url;
        }
    }
    /// <summary>
    /// 包含复选值的隐藏控件ClientID
    /// </summary>
    protected string HideCheckedRowsControlId
    {
        get { return this.checkedRows.ClientID; }
    }
    private bool needIncludeCssText ;
    protected string IncludeCssNameText
    {
        get
        {
            string s = string.Empty;
            s = ControlCurrentPath + "Css/flexigrid_blue.css";
            //if (needIncludeCssText)
            //{
            //    string css = Request.ApplicationPath + ControlCurrentPath + "Css/flexigrid_blue.css";
            //    s = "<link href=\"" + css + " type=\"text/css\" rel=\"stylesheet\" />";
            //}
            return s;
        }
    }
    /// <summary>
    /// 用作快速查询的参数数据
    /// </summary>
    protected string SerchParamConfigText
    {
        get {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            if (_SearchParams != null)
            {
                foreach (string key in _SearchParams.Keys)
                {
                    string text = string.Empty;
                    text += "{ display:'"+_SearchParams[key]._display+"',";
                    text += " name:'"+_SearchParams[key]._name+"',";
                    text += " operater:'" + _SearchParams[key]._operater.ToString() + "',";
                    text += " isdefault:" + ((_SearchParams[key]._isdefault) ? "true" : "false") + ",";

                    if (_SearchParams[key]._reg!=null&&_SearchParams[key]._reg.Length > 0)
                        text += " reg:/" + _SearchParams[key]._reg + "/";
                    else if (text.EndsWith(","))
                        text = text.Substring(0, text.Length - 1);
                    text += "},";
                    if (i == _SearchParams.Count - 1)
                        text = text.Substring(0, text.Length - 1);
                    sb.AppendLine(text);
                    i++;
                }
            }
            return sb.ToString();
        }
    }
    private string _FieldConfigsParamName;
    /// <summary>
    /// 输出扩展参数文本
    /// </summary>
    protected string ExtParamConfigText
    {
        get {
            //增加传递表格字段配置参数
            string fields = EncodeBase64ByUtf8("[" + FieldConfigText + "]");
            fields = "{ name:'" + _FieldConfigsParamName + "',value:'" + fields + "' }";

            string extParamTxt=DefaultSearchParamText 
                + ((OtherExtParamText.Length>0)?",\r\n"+OtherExtParamText:""); 
            if(extParamTxt.Trim().Length>0)
            {
                fields+=",\r\n";
            }
            string result = fields + extParamTxt;
            return result;

                
        }
    }
    /// <summary>
    /// 默认查询参数文本，用作初始化传参
    /// </summary>
    private string DefaultSearchParamText
    {
        get {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            if (_DefaultSearch != null)
            {
                foreach (string key in _DefaultSearch.Keys)
                {
                    string text = string.Empty;
                    text += "{ name: '" + _DefaultSearchParamName+ key + "',";
                    text += " value:'" + EncodeBase64ByUtf8(_DefaultSearch[key]) + "' },";
                    if (i == _DefaultSearch.Count - 1)
                        text = text.Substring(0, text.Length - 1);
                    sb.AppendLine(text);
                    i++;
                }
            }
            return sb.ToString(); 
        }
    }
    private string OtherExtParamText
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            if (_PostExtParams != null)
            {
                foreach (string key in _PostExtParams.Keys)
                {
                    string text = string.Empty;
                    text += "{ name: '" + key + "',";
                    text += " value:'" + EncodeBase64ByUtf8(_PostExtParams[key]._value) + "' },";
                    if (i == _PostExtParams.Count - 1)
                        text = text.Substring(0, text.Length - 1);
                    sb.AppendLine(text);
                    i++;
                }
                
            }
            return sb.ToString();
        }
    }
    protected string GridConfigText
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            if (_GridParams != null&&_GridParams.Count>0)
            {
                foreach (string key in _GridParams.Keys)
                {
                    string value = _GridParams[key];
                    int temp=-1;
                    bool isInt = int.TryParse(value, out temp);
                    if (value.Trim().ToLower() == "true" || value.Trim().ToLower() == "false" || isInt||value.TrimStart().StartsWith("["))
                    {
                        ;
                    }
                    else
                    {
                        value = "'" + value + "'";
                    }
                    sb.AppendLine(key + ":" + value  + ",");
                }
            }
            else
            {
                //生成默认的配置

            }

            return sb.ToString();
        }
    }
    protected string FieldConfigText
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            if (_FieldParams != null && _FieldParams.Count > 0)
            {
                int i = 0;
                foreach (string key in _FieldParams.Keys)
                {
                    string value = string.Empty;
                    /*{display: '隐藏列', name : 'Guid', width : 40, sortable : false, align: 'left', hide: true ,toggle : true}*/
                    string text = string.Empty;
                    text += "{";

                    text += "display:'" + _FieldParams[key]._display + "',";
                    text += "name:'" + _FieldParams[key]._name + "',";
                    text += "width:" + _FieldParams[key]._width.ToString() + ",";
                    text += "sortable:" + _FieldParams[key]._sortable.ToString().ToLower() + ",";
                    text += "align:'" + _FieldParams[key]._align.ToString().ToLower() + "',";
                    text += "checkField:" + _FieldParams[key]._checkField.ToString().ToLower() + ",";
                    if (_FieldParams[key]._hide)
                    {
                        text += "hide:" + _FieldParams[key]._hide.ToString().ToLower() + ",";
                        text += "toggle:" + _FieldParams[key]._toggle.ToString().ToLower() + ",";
                    }

                    if (_FieldParams[key]._ItemTemplate!=null&&_FieldParams[key]._ItemTemplate.Length > 0)//展现模板
                    {
                        text += "template:'" + EncodeBase64ByUtf8(_FieldParams[key]._ItemTemplate) + "',";
                    }
                    if (text.EndsWith(","))
                    {
                        text = text.Remove(text.Length - 1, 1);//删除最后的,
                    }
                    text += "},";

                    if (i == _FieldParams.Count - 1)
                    {
                        text = text.Remove(text.Length - 1, 1); ;//删除最后的,
                    }

                    sb.AppendLine(text);
                    i++;

                }
            }
            else
            {
                throw new ApplicationException("dotNetFlexGrid.FieldConfigText().dotNetFlexGrid初始化一个有效的FieldParams，请检查InitConfig（）方法是否正确调用。");
            }
            return sb.ToString();
        }
    }
    #endregion
    #region 事件函数
    private string _EventOnClickFunc;
    /// <summary>
    /// 提供的Javascript OnClick方法的回调函数名
    /// </summary>
    public string EventOnClickFunc
    {
        get { return _EventOnClickFunc; }
        set { _EventOnClickFunc = value; }
    }
    private string _EventOnDbClickFunc;
    /// <summary>
    /// 提供的Javascript OnDbClick方法的回调函数名
    /// </summary>
    public string EventOnDbClickFunc
    {
        get { return _EventOnDbClickFunc; }
        set { _EventOnDbClickFunc = value; }
    }
    private string _EventOnCheckedFunc;
    /// <summary>
    /// 提供的Javascript OnChecked方法的回调函数名
    /// </summary>
    public string EventOnCheckedFunc
    {
        get { return _EventOnCheckedFunc; }
        set { _EventOnCheckedFunc = value; }
    }

    private string _EventOnUnCheckedFunc;
    /// <summary>
    /// 提供的Javascript OnChecked方法的回调函数名
    /// </summary>
    public string EventOnUnCheckedFunc
    {
        get { return _EventOnUnCheckedFunc; }
        set { _EventOnUnCheckedFunc = value; }
    }
    private string _EventOnLoadFunc;
    /// <summary>
    /// 提供的Javascript OnLoad方法的回调函数名
    /// </summary>
    public string EventOnLoadFunc
    {
        get { return _EventOnLoadFunc; }
        set { _EventOnLoadFunc = value; }
    }
    private string _EventOnSelectedFunc;
    /// <summary>
    /// 提供的Javascript OnSelected方法的回调函数名,暂未实现
    /// </summary>
    public string EventOnSelectedFunc
    {
        get { return _EventOnSelectedFunc; }
        set { _EventOnSelectedFunc = value; }
    }
    #endregion
    #region 控件属性
    private DataHandlerDelegate _DataHandler;
    /// <summary>
    /// 绑定的数据生成函数
    /// </summary>
    public DataHandlerDelegate DataHandler
    {
        get {
            return _DataHandler; 
        }
        set
        {
            if (!value.Method.IsPublic)
            {
                throw new ApplicationException("DataHandler绑定的方法" + _DataHandler.Method.Name + "不是Public的.");
            }
            _DataHandler = value;
        }
    }

    private string _DefaultSearchParamName;//传递默认查询参数的名称;
    private Dictionary<string,string> _DefaultSearch;
    public Dictionary<string, string> DefaultSearch
    {
        get {
            if (_DefaultSearch == null)
            {
                _DefaultSearch = new Dictionary<string, string>();
            }
            return _DefaultSearch;
        }
    }
    /// <summary>
    /// 获取当前通过复选框选择的行，必须在开启复选框时出现
    /// </summary>
    public List<string> CheckedRows
    {
        get {
            List<string> result=null;
            string[] array = null;
            if (this.checkedRows.Value != null)
            {
                array = this.checkedRows.Value.Split(',');
                if (array != null)
                {
                    result=new List<string>();
                    foreach(string s in array)
                    {
                        if(s.Length>0)
                            result.Add(s);
                    }
                }
            }
            return result;
        }
    }
    #endregion
    private Dictionary<string, string> _GridParams;
    private Dictionary<string, FieldConfig> _FieldParams;
    private Dictionary<string, SerchParamConfig> _SearchParams;
    private Dictionary<string, ExtParamConfig> _PostExtParams;
    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterScriptAndCss();
        //初始化时置空隐藏域，因为js会重新赋值的
        checkedRows.Value = "";
        
    }
    //注册客户端脚本库
    private void RegisterScriptAndCss()
    {
        string jquery = ControlCurrentPath + "JS/jquery-1.4.2.min.js";
        string flexgrid =  ControlCurrentPath + "JS/jquery.flexigrid.hual.js";
        string utility =  ControlCurrentPath + "JS/jquery.flexigrid.hual.utility.js";
        if(!this.Page.ClientScript.IsClientScriptIncludeRegistered("jquery"))
            this.Page.ClientScript.RegisterClientScriptInclude("jquery", jquery);
        if (!this.Page.ClientScript.IsClientScriptIncludeRegistered("jquery.flexigrid.hual.utility"))
            this.Page.ClientScript.RegisterClientScriptInclude("jquery.flexigrid.hual.utility", utility);
        if (!this.Page.ClientScript.IsClientScriptIncludeRegistered("jquery.flexigrid"))
            this.Page.ClientScript.RegisterClientScriptInclude("jquery.flexigrid", flexgrid);
        

        //注册css
        string css = ControlCurrentPath + "Css/flexigrid_blue.css";
        bool hasCss = false;
        if (Page.Header != null)
        {
            foreach (Control c in Page.Header.Controls)
            {
                if (c is HtmlLink)
                {
                    HtmlLink link = (HtmlLink)c;
                    if (link.Attributes["href"] == css)
                    {
                        hasCss = true;
                        break;
                    }
                }
            }
            if (!hasCss)
            {
                HtmlLink link1 = new HtmlLink();
                link1.Attributes["type"] = "text/css";
                link1.Attributes["rel"] = "stylesheet";
                link1.Attributes["href"] = css;
                try
                {
                    Page.Header.Controls.Add(link1);
                }
                catch (Exception ex)
                {
                    needIncludeCssText = true;
                }
            }
        }
        else
        {
            needIncludeCssText = true;
        }

    }
    #region InitConfig
    /// <summary>
    /// 根据默认参数初始化Grid
    /// </summary>
    /// <param name="fieldparam"></param>
    public void InitConfig(FieldConfig[] fieldparam)
    {
        InitConfig(null, fieldparam, null, null);
    }
    /// <summary>
    /// 根据表格参数，字段配置初始化Grid
    /// </summary>
    /// <param name="gridparam"></param>
    /// <param name="fieldparam"></param>
    public void InitConfig(string[] gridparam, FieldConfig[] fieldparam)
    {
        InitConfig(gridparam, fieldparam, null, null);
    }
    /// <summary>
    /// 根据完整的参数初始化Grid
    /// </summary>
    /// <param name="gridparam"></param>
    /// <param name="fieldparam"></param>
    /// <param name="serchParam"></param>
    /// <param name="postExtParam"></param>
    public void InitConfig(
        string[] gridparam,//表格主控参数，选填时将采用默认值
        FieldConfig[] fieldparam, //表格字段参数，不可选填
        SerchParamConfig[] serchParam, //快速查询参数，用于配置快速查询的项目和操作模式，选填时不显示快速查询
        ExtParamConfig[] postExtParam//附加的Post参数，用于额外的参数传递（用于DataHandler对应的方法）
        )
    {
        this._DefaultSearchParamName= ClientID + "$DefaultSearch$";
        this._FieldConfigsParamName = this.ClientID + "$FieldConfigs$";

        _GridParams = BuildParamsFromArray(gridparam);
        _FieldParams = BuildParamsFromArray(fieldparam);
        _SearchParams = BuildParamsFromArray(serchParam);
        _PostExtParams = BuildParamsFromArray(postExtParam);
        if (_FieldParams == null)
        {
            throw new ApplicationException("dotNetFlexGrid.Init()至少需要合法的fieldparam,请检查您的Grid传参!");
        }
    }
    private Dictionary<string, SerchParamConfig> BuildParamsFromArray(SerchParamConfig[] array)
    {
        Dictionary<string, SerchParamConfig> result = null;

        if (array != null && array.Length > 0)
        {
            result = new Dictionary<string, SerchParamConfig>();
            foreach (SerchParamConfig config in array)
            {
                if (config != null)
                {
                    result.Add(config._name, config);
                }
            }
            if (result.Count == 0)
            {
                throw new ApplicationException("dotNetFlexGrid.BuildParamsFromArray()传递非空的SerchParamConfig[]但没有获取到一条有效的值,请检查您的Grid传参!");
            }
        }
        return result;
    }
    private Dictionary<string,ExtParamConfig> BuildParamsFromArray(ExtParamConfig[] array)
    {
        Dictionary<string, ExtParamConfig> result=null;

        if (array != null && array.Length > 0)
        {
            result = new Dictionary<string, ExtParamConfig>();
            foreach (ExtParamConfig config in array)
            {
                if (config != null)
                {
                    result.Add(config._name, config);
                }
            }
            if (result.Count == 0)
            {
                throw new ApplicationException("dotNetFlexGrid.BuildParamsFromArray()传递非空的ExtParamConfig[]但没有获取到一条有效的值,请检查您的Grid传参!");
            }
        }
        return result;
    }
    private Dictionary<string, FieldConfig> BuildParamsFromArray(FieldConfig[] array)
    {
        Dictionary<string, FieldConfig> result=null;
        if (array != null && array.Length > 0)
        {
            result = new Dictionary<string, FieldConfig>();
            foreach (FieldConfig config in array)
            {
                if(config!=null)
                    result.Add(config._name,config);
            }
            if (result.Count == 0)
            {
                throw new ApplicationException("dotNetFlexGrid.BuildParamsFromArray()传递非空的FieldConfig[]但没有获取到一条有效的值,请检查您的Grid传参!");
            }
        }
        return result;
    }
    private Dictionary<string, string> BuildParamsFromArray(string[] array)
    {
        Dictionary<string, string> result = null;
        if (array != null && array.Length > 0)
        {
            result = new Dictionary<string, string>();
            string[] tmp = null;
            string key = string.Empty;
            string value = string.Empty;
            foreach (string s in array)
            {
                if (s != null)
                {
                    tmp = s.Split('=');
                    if (tmp.Length >= 2)
                    {
                        key = tmp[0];
                        value = tmp[1];
                        result.Add(key, value);
                    }
                    else
                    {
                        tmp = null;
                        key = string.Empty;
                        value = string.Empty;
                    }
                }
            }
            if (result.Count == 0)
            {
                throw new ApplicationException("dotNetFlexGrid.BuildParamsFromArray()传递非空的array但没有获取到一条有效的值,请检查您的Grid传参!");
            }
        }
        return result;
    }
    #endregion
    /// <summary>
    /// 通过默认参数和HSF XML初始化控件
    /// </summary>
    /// <param name="xmlPath"></param>
    public void InitFromXml(string xmlPath)
    {

    }
    private string EncodeBase64ByUtf8(string code)
    {
        string encode = "";
        byte[] bytes = Encoding.UTF8.GetBytes(code);
        try
        {
            encode = Convert.ToBase64String(bytes);
        }
        catch
        {
            encode = code;
        }
        return encode;
    }
    private string DecodeBase64Utf8(string code)
    {
        string decode = "";
        byte[] bytes = Convert.FromBase64String(code);
        try
        {
            decode = Encoding.UTF8.GetString(bytes);
        }
        catch
        {
            decode = code;
        }
        return decode;
    }
    /// <summary>
    /// 服务端加载数据显示
    /// </summary>
    public void ServerShow()
    {
    }

    #region IPostBackDataHandler 成员

    public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
    {
        throw new NotImplementedException();
    }

    public void RaisePostDataChangedEvent()
    {
        throw new NotImplementedException();
    }

    #endregion
    #region 针对添加行的操作
    /// <summary>
    /// 根据DataTable行数据和显示列构建增加字符串
    /// </summary>
    /// <param name="dr">DataTable行</param>
    /// <param name="idFieldName">主键列名</param>
    /// <param name="fieldNames">需要更新显示的列名，对应于父页面GRID中的列声明；如果主键列不需要显示，则显示列中不要包括此主键列名</param>
    /// <returns>string</returns>
    public static string BuildGridRowsObjectText(DataRow dr, string idFieldName, string[] fieldNames)
    {
        string result = string.Empty;
        if (dr != null)
        {
            result += "{\r\n";
            result += "id: '" + dr[idFieldName] + "',";
            result += "cell: [";
            foreach (string fieldName in fieldNames)
            {
                foreach (DataColumn dc in dr.Table.Columns)
                {
                    if (dc.ColumnName == fieldName)
                    {
                        result += "'" + dr[dc.ColumnName].ToString() + "',";
                        break;
                    }
                }
            }
            if (result.EndsWith(","))
                result = result.Substring(0, result.Length - 1);
            result += "]";
            result += "}";
        }
        return result;
    }
    #endregion
    #region 解析getGridJsonData返回的数据
    public Dictionary<string, Dictionary<string, string>> ParseGetGridJsonData(string json)
    {
        Dictionary<string, Dictionary<string, string>> result = new Dictionary<string, Dictionary<string, string>>();
        Newtonsoft.Json.Linq.JArray array = (Newtonsoft.Json.Linq.JArray)JsonConvert.DeserializeObject(json);
        for (int i = 0; i < array.Count; i++)
        {
            Newtonsoft.Json.Linq.JObject o = Newtonsoft.Json.Linq.JObject.Parse(array[i].ToString());
            string id=(string)o["id"];
            Dictionary<string, string> value = new Dictionary<string, string>();
            Newtonsoft.Json.Linq.JArray vl = (Newtonsoft.Json.Linq.JArray)o["cell"];
            int j=0;
            foreach(string key in _FieldParams.Keys)
            {
                string cvalue = (string)vl[j];
                value.Add(_FieldParams[key]._name,DecodeBase64Utf8(cvalue));
                j++;
            }
            result.Add(id, value);
        }
        return result;
    }
    #endregion
    #region 用作调试的数据方法
    public static dotNetFlexGrid.DataHandlerResult DemoDataHandler(dotNetFlexGrid.DataHandlerParams p)
    {
        dotNetFlexGrid.DataHandlerResult result = new dotNetFlexGrid.DataHandlerResult();
        
        result.table = DemoMemoryTable(p.page * 100, p.rp);
        if (p.defaultSearch != null && p.defaultSearch.Count > 0)
        {
            string search=string.Empty;
            foreach(string key in p.defaultSearch.Keys)
                search+="key="+key+"|value="+p.defaultSearch[key]+";";
            result.table.Rows[0][1] = search;
        }
        if (p.qtype.Length > 0 &&p.qop!=dotNetFlexGrid.SerchParamConfigOperater.None&& p.query.Length > 0)
        {
            DataView dv = result.table.DefaultView;
            dv.RowFilter = p.qtype + " " + ((p.qop == dotNetFlexGrid.SerchParamConfigOperater.Eq) ? "=" : "Like ") + " '%" + p.query + "%'";
            result.table = dv.ToTable();
        }
        if (p.sortname.Length > 0 && p.sortorder.Length > 0)
        {
            DataView dv = result.table.DefaultView;
            dv.Sort=(p.sortname + " " + p.sortorder);
            result.table=dv.ToTable();
        }
        result.page = p.page;
        result.total = p.rp*5;//模拟为5页

        return result;
    }
    public static DataTable DemoMemoryTable(int start, int num)
    {
        DataTable result = new DataTable("js_flexigrid");
        result.Columns.Add("Guid", System.Type.GetType("System.String"));
        result.Columns.Add("String1", System.Type.GetType("System.String"));
        result.Columns.Add("String2", System.Type.GetType("System.String"));
        result.Columns.Add("String3", System.Type.GetType("System.String"));
        result.Columns.Add("String4", System.Type.GetType("System.String"));
        result.Columns.Add("Int1", System.Type.GetType("System.Int32"));
        result.Columns.Add("Int2", System.Type.GetType("System.Int32"));
        result.Columns.Add("DateTime", System.Type.GetType("System.DateTime"));
        result.Columns.Add("Checked", System.Type.GetType("System.Boolean"));

        for (int i = start; i < num + start; i++)
        {
            DataRow dr = result.NewRow();

            dr["Guid"] = Guid.NewGuid().ToString();
            dr["String1"] = "测试字段1_" + i.ToString();
            dr["String2"] = "测试字段2_" + i.ToString();
            dr["String3"] = "测试字段3_" + i.ToString();
            dr["String4"] = "测试字段4_" + i.ToString();

            dr["Int1"] = 1 * 1000 + i;
            dr["Int2"] = 2 * 1000 + i;
            dr["DateTime"] = DateTime.Now;

            if (i == start)
                dr["Checked"] = true;
            else
                dr["Checked"] = !true;

            result.Rows.Add(dr);
        }
        return result;
    }
    #endregion
}
