//事件挂接
function flexigrid_eventHandle(grid) {
    var self = this;//jquery call会改变this的引用，故用self指向当前实例
    this.grid = grid;
    
    this.RowHandle = function(row) {//这里的写法不好。考虑直接在Flexigrid中增加单击、双击事件
        if (row.id) {
            var id = row.id.substr(3);
            if (self.grid.onClick) {
                $(row).click(function() {
                    self.grid.onClick(id);
                });
                //同时也绑定checkbox
                $("input.itemchk", row).each(function(){
                    $(this).click(function() {
                        self.grid.onClick(id);
                    });
                    return false;
                });
            }
            if (self.grid.onDbClick) {
                $(row).dblclick(function() {
                    self.grid.onDbClick(id);
                });
                //同时也绑定checkbox
                $("input.itemchk", row).each(function(){
                    $(this).dblclick(function() {
                        self.grid.onDbClick(id);
                    });
                    return false;
                });
            }
        }
    };
    this.onLoad = function() {
        var $cHide = $('input#' + grid.checkRowsField);
        var $t = $('#' + self.grid.gridId);
        $cHide.val('');
        $("input.itemchk:checked", $t).each(function() {
            $cHide.val($cHide.val() + "," + $(this).val());
        });
        if (self.grid.onLoad) {
            self.grid.onLoad();
        }
    };
    this.onRowChecked = function() {
        var $cHide = $('input#' + self.grid.checkRowsField);
        var id = $(this).val();
        var val = $cHide.val().split(',');
        var index = jQuery.inArray(id, val);
        if (this.checked) {
            if (!(index >= 0))
                $cHide.val($cHide.val() + "," + id);
            if (self.grid.onChecked) {
                self.grid.onChecked(id);
            }
        } else {

            if (index >= 0) {
                //删除指定的值
                val = jQuery.grep(val, function(v, i) {
                    return i != index;
                });
                //重新赋值
                $cHide.val('');
                $(val).each(function() {
                    if (this)
                        $cHide.val($cHide.val() + "," + this);
                });
            }

            if (self.grid.onUnChecked) {
                self.grid.onUnChecked(id);
            }

        }
    };

}
var base64EncodeChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
var base64DecodeChars = new Array(
    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 62, -1, -1, -1, 63,
    52, 53, 54, 55, 56, 57, 58, 59, 60, 61, -1, -1, -1, -1, -1, -1,
    -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
    15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, -1, -1, -1, -1, -1,
    -1, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
    41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, -1, -1, -1, -1, -1);

function base64encode(str) {
    var out, i, len;
    var c1, c2, c3;

    len = str.length;
    i = 0;
    out = "";
    while (i < len) {
        c1 = str.charCodeAt(i++) & 0xff;
        if (i == len) {
            out += base64EncodeChars.charAt(c1 >> 2);
            out += base64EncodeChars.charAt((c1 & 0x3) << 4);
            out += "==";
            break;
        }
        c2 = str.charCodeAt(i++);
        if (i == len) {
            out += base64EncodeChars.charAt(c1 >> 2);
            out += base64EncodeChars.charAt(((c1 & 0x3) << 4) | ((c2 & 0xF0) >> 4));
            out += base64EncodeChars.charAt((c2 & 0xF) << 2);
            out += "=";
            break;
        }
        c3 = str.charCodeAt(i++);
        out += base64EncodeChars.charAt(c1 >> 2);
        out += base64EncodeChars.charAt(((c1 & 0x3) << 4) | ((c2 & 0xF0) >> 4));
        out += base64EncodeChars.charAt(((c2 & 0xF) << 2) | ((c3 & 0xC0) >> 6));
        out += base64EncodeChars.charAt(c3 & 0x3F);
    }
    return out;
}

function base64decode(str) {
    var c1, c2, c3, c4;
    var i, len, out;

    len = str.length;
    i = 0;
    out = "";
    while (i < len) {
        /* c1 */
        do {
            c1 = base64DecodeChars[str.charCodeAt(i++) & 0xff];
        } while (i < len && c1 == -1);
        if (c1 == -1)
            break;

        /* c2 */
        do {
            c2 = base64DecodeChars[str.charCodeAt(i++) & 0xff];
        } while (i < len && c2 == -1);
        if (c2 == -1)
            break;

        out += String.fromCharCode((c1 << 2) | ((c2 & 0x30) >> 4));

        /* c3 */
        do {
            c3 = str.charCodeAt(i++) & 0xff;
            if (c3 == 61)
                return out;
            c3 = base64DecodeChars[c3];
        } while (i < len && c3 == -1);
        if (c3 == -1)
            break;

        out += String.fromCharCode(((c2 & 0XF) << 4) | ((c3 & 0x3C) >> 2));

        /* c4 */
        do {
            c4 = str.charCodeAt(i++) & 0xff;
            if (c4 == 61)
                return out;
            c4 = base64DecodeChars[c4];
        } while (i < len && c4 == -1);
        if (c4 == -1)
            break;
        out += String.fromCharCode(((c3 & 0x03) << 6) | c4);
    }
    return out;
}
function utf16to8(str) {
    var out, i, len, c;

    out = "";
    len = str.length;
    for (i = 0; i < len; i++) {
        c = str.charCodeAt(i);
        if ((c >= 0x0001) && (c <= 0x007F)) {
            out += str.charAt(i);
        } else if (c > 0x07FF) {
            out += String.fromCharCode(0xE0 | ((c >> 12) & 0x0F));
            out += String.fromCharCode(0x80 | ((c >> 6) & 0x3F));
            out += String.fromCharCode(0x80 | ((c >> 0) & 0x3F));
        } else {
            out += String.fromCharCode(0xC0 | ((c >> 6) & 0x1F));
            out += String.fromCharCode(0x80 | ((c >> 0) & 0x3F));
        }
    }
    return out;
}
function utf8to16(str) {
    var out, i, len, c;
    var char2, char3;

    out = "";
    len = str.length;
    i = 0;
    while (i < len) {
        c = str.charCodeAt(i++);
        switch (c >> 4) {
            case 0: case 1: case 2: case 3: case 4: case 5: case 6: case 7:
                // 0xxxxxxx
                out += str.charAt(i - 1);
                break;
            case 12: case 13:
                // 110x xxxx   10xx xxxx
                char2 = str.charCodeAt(i++);
                out += String.fromCharCode(((c & 0x1F) << 6) | (char2 & 0x3F));
                break;
            case 14:
                // 1110 xxxx  10xx xxxx  10xx xxxx
                char2 = str.charCodeAt(i++);
                char3 = str.charCodeAt(i++);
                out += String.fromCharCode(((c & 0x0F) << 12) |
                       ((char2 & 0x3F) << 6) |
                       ((char3 & 0x3F) << 0));
                break;
        }
    }

    return out;
}
//读取指定路径的样式表文件，css的加载大部分浏览器下是阻塞的，故暂时无需考虑加载完成的通知问题。
function loadStyleSheet(path)
{
    var cssHas=false;
    $('link[ref*=style').each(function()
    {
        if (this.getAttribute('href') == +path){
            cssHas=true;
            return false;
        }
        
    });
    if(!cssHas)
    {
        var head=document.getElementsByTagName("head")[0] || document.documentElement;       
        var s=document.createElement('link');
        s.rel="stylesheet";
        s.type="text/css";
        s.href=path;
        head.appendChild(s);  
    }
}
function Dictionary()
{
    this._obj = {};
    this.count = 0;
}
Dictionary.prototype.add = function(key,value)
{
    if(typeof(this._obj[key]) != "undefined")
    {
        throw new Error("关键字[" + key + "]已存在！");
    }
    this._obj[key] = value
    this.count += 1;
};
Dictionary.prototype.remove = function(key)
{
    if(typeof(this._obj[key]) == "undefined")
    {
        //throw new Error("关键字[" + key + "]不存在！");
        this._obj[key]=null;
    }
    delete this._obj[key];
    this.count -= 1;
};
Dictionary.prototype.removeAll = function()
{
    this._obj = {};
    this.count = 0;
};
Dictionary.prototype.exists = function(key)
{
    if(typeof(this._obj[key]) == "undefined")
    {
        return false;
    }
    return true;
};
Dictionary.prototype.item = function(key)
{
    if(typeof(this._obj[key]) == "undefined")
    {
        //throw new Error("关键字[" + key + "]不存在！");
        this._obj[key]=null;
    }
    return this._obj[key];
};
Dictionary.prototype.keys = function()
{
    var keys = [];
    for(var p in this._obj)
    {
        keys[keys.length] = p;
    }
    return keys;
};
Dictionary.prototype.values = function()
{
    var values = [];
    for(var p in this._obj)
    {
        values[values.length] = this._obj[p];
    }
    return values;
};