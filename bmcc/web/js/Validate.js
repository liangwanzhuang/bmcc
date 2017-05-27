

    //20090614 by 奇科：谢丰泽
    //判断字符串的长度包括中文
    String.prototype.getBytes = function() 
    {    
        var cArr = this.match(/[^\x00-\xff]/ig);    
        return this.length + (cArr == null ? 0 : cArr.length);    
    }
    //判断字符串为有效数字不大于8位的数字
    function isReal(num)
    {
        //debugger
        if(isNaN(num)||num.replace('.','').length > 8)
        {  
            return true;
        }
        else
        {
            return false;
        }
    }
    //判断字符串为有效数字不大于4位的整数
    function isSmallint(num)
    {
        //debugger
        var str=/^\\d+$/;
        if(str.test(num)&&num.length <= 4)
        {
           return false;
        }

        return true;
    }
    //判断非法字符的方法
    function InspectUnlawfulStr(strInput,charset)
    {
        var strIsOk = "~!@#$%^&*()_+|/*./?><,';:][{}-";
        if (charset == "")
        {
         charset=strIsOk;
        }
        var i;
        for (i = 0; i < charset.length; i++)
        {
            if(strInput.indexOf(charset.charAt(i)) >= 0)
            {
                return true;
            }
        }
        return false;
    }

    //判断是不是引文字符的方法
    function JudgeIsEnglish(value)
    {
      //value=value.replace(".","");//先把点号替换掉
      var i;
      for (i=0 ; i<value.length; i++)
      {
       
         if(value.charCodeAt(i) > 128)
         {
            return false;
         }
      }
      return true;
    }
    //判断邮件地址是否符合要求
    function JudgeIsEmail(strEmail) 
    {
      if (strEmail.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/) != -1)
      {
       return true;
      }
      return false
    }
    //置换掉有可能会影响回调的非法字符
    function ReplaceCallBackErrorStr(value)
    {
      value.replace('^','');
      return value
    }
     //中文值检测

    function   isChinese(name)  
    {
        if(name.length   ==   0)
        return   false;
        for(i   =   0;   i   <   name.length;   i++)   
        {
           if(name.charCodeAt(i)   >   128)
           return   true;
        }
        return   false;
    }
    //保留两位小数
   function KeepTwoDotDecimel(value)
   {
      var rvalue = "";
      var length=value.length;
      var k = value.indexOf('.');
      if(k == 0)
      {
        value = "0"+value;
      }
      var i = value.indexOf('.');
      if(i < 0)
      {
        rvalue = value +".00"; 
      }
      if(i > 0)
      {
         if((length - i) == 3)
         {
             rvalue = value;
         }
         if((length - i) > 3)
         {
            rvalue = value.substring(0,i+3);
           
         }
         if((length - i) == 2)
         {
            rvalue = value+"0";
           
         }
         if((length - i) == 1)
         {
            rvalue = value+"00";
           
         }
        
      }
      return rvalue;
   }
   
  //限制只能输入数字
  function txt_onKeyPress(e)
  {  
     if(event!=null)
     {  
       if((event.keyCode>=47&&event.keyCode<=58)||event.keyCode==46)
       {          
       }
       else
       {  
          event.keyCode = null;
       }       
    }
  }


   // 剔除非法字符
    function eliminateStr(checkValue)
    {
        var str = "|exec|insert|select|delete|update|count|*|%|chr|mid|master|truncate|declare|;|,|\"\"|--|<|>|?|'|-->|<!--";
               
        var type = str.split('|');
        
        for(var index = 0; index < type.length; index++)
        {
            checkValue = checkValue.toString().replace(type[index],"");
        }
        
        return checkValue;
    }