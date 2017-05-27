function isNumberString(InString,RefString){
	if(InString.length==0) return (false);
	for (Count=0; Count < InString.length; Count++)  {
		TempChar= InString.substring (Count, Count+1);
		if (RefString.indexOf (TempChar, 0)==-1)  
		return (false);
	}
	return true;
}

function  Allhecked(n)
{
	var v = document.getElementsByName(n);
	for(var i=0; i<v.length; i++)
	{
			v[i].checked = true;
	} 
}



function  fanhecked(n)
{
	var v = document.getElementsByName(n);
	for(var i=0; i<v.length; i++)
	{
		if(!v[i].checked)
			v[i].checked = true;
		else
			v[i].checked = false;
	} 
}//fanhecked

 function replaceyh(str)
{
	return str.replace(/(^\s*)|(\s*$)/g, "'"); 
}

 function replacedyh(str)
{
	str=str.replace(/\'/g,""); 
	str=str.replace(/\"/g,"");
	return str;
}

function checkQuote(){ 
	var str=document.forms[0].input.value; 
		if(str.indexOf("'")!=-1){//在字符串中查到了单引号 
			str.replace(/\'/g,""); 
			str.replace(/\"/g,"");
			document.forms[0].input.value=str.replace(/\'/g,"");
			return false; 
		}
  } 



		   function fTrim(str)
	{
		return str.replace(/(^\s*)|(\s*$)/g, ""); 
	}
/*********************************

把输入框的对象的值变成　日期型的数据　2008-02-12

*********************************/
function changeDataToDate(theName,theValue){	
//alert(theValue);
	var theYear ;
	var theMonth;
	var theDay;
	var theDate;
	if(theValue!=""){
		if(theValue.length==8){
			if(isNumberString(theValue,"0123456789")!=1){
				alert("只能填写8位日期数字,格式类似于'20080101'!");
				document.getElementById(theName).value = "";
				document.getElementById(theName).focus();
				return false;
			}else{			
				if(theValue.length!=8){
					alert("填入的日期不规范,请填写8位日期数字,格式类似于'20080101'!");
					document.getElementById(theName).value = "";
					document.getElementById(theName).focus();
					return false;
				}else{
					theYear = theValue.substring(0,4);
					theMonth = theValue.substring(4,6);
					theDay = theValue.substring(6,8);						
					if(isTime(theYear,theMonth,theDay,theName)){					  
						theDate = theYear+"-"+theMonth+"-"+theDay;
						document.getElementById(theName).value = theDate;
						return true;
					}else{
						document.getElementById(theName).value = "";
						document.getElementById(theName).focus();
						return 	false;
					}	
					
					
				}
			}
		}else if(theValue.length==10){	
			theYear = theValue.substring(0,4);
			theMonth = theValue.substring(5,7);
			theDay = theValue.substring(8,10);	
			//alert(theYear+" "+theMonth+" "+theDay);	
			if(isNumberString(theYear,"0123456789")!=1){
				alert("只能填写8位日期数字,格式类似于'20080101'!");
				document.getElementById(theName).value = "";
				document.getElementById(theName).focus();
				return false;
			}
			
			if(isNumberString(theMonth,"0123456789")!=1){
				alert("只能填写8位日期数字,格式类似于'20080101'!");
				document.getElementById(theName).value = "";
				document.getElementById(theName).focus();
				return false;
			}
			if(isNumberString(theDay,"0123456789")!=1){
				alert("只能填写8位日期数字,格式类似于'20080101'!");
				document.getElementById(theName).value = "";
				document.getElementById(theName).focus();
				return false;
			}
			
			if(isTime(theYear,theMonth,theDay,theName)){					  
				theDate = theYear+"-"+theMonth+"-"+theDay;
				document.getElementById(theName).value = theDate;
				return true;
			}else{
				document.getElementById(theName).value = "";
				document.getElementById(theName).focus();
				return 	false;
			}	
			
			
			return true;
		}else{
			alert("填入的时间不规范,请填写8位日期数字,格式类似于'20080101'!");
			document.getElementById(theName).value = "";
			document.getElementById(theName).focus();
			return false;
		}
	
	}else{
		return true;
	}
	
	return false;

}

function checkFormDataToDate(theValue){	
//alert(theValue);
	var theYear ;
	var theMonth;
	var theDay;
	var theDate;
	if(theValue!=""){
		if(theValue.length==8){
			if(isNumberString(theValue,"0123456789")!=1){
				alert("只能填写8位日期数字,格式类似于'20080101'!");		
				return false;
			}else{			
				if(theValue.length!=8){
					alert("填入的日期不规范,请填写8位日期数字,格式类似于'20080101'!");					
					return false;
				}else{
					theYear = theValue.substring(0,4);
					theMonth = theValue.substring(4,6);
					theDay = theValue.substring(6,8);						
					if(isDateTime(theYear,theMonth,theDay)){					  
						theDate = theYear+"-"+theMonth+"-"+theDay;
						
						return true;
					}else{
							return 	false;
					}	
					
					
				}
			}
		}else if(theValue.length==10){	
			theYear = theValue.substring(0,4);
			theMonth = theValue.substring(5,7);
			theDay = theValue.substring(8,10);	
			if(isNumberString(theYear,"0123456789")!=1){
				alert("只能填写8位日期数字,格式类似于'20080101'!");
				
				return false;
			}
			
			if(isNumberString(theMonth,"0123456789")!=1){
				alert("只能填写8位日期数字,格式类似于'20080101'!");
				return false;
			}
			if(isNumberString(theDay,"0123456789")!=1){
				alert("只能填写8位日期数字,格式类似于'20080101'!");
				return false;
			}
			
			if(isDateTime(theYear,theMonth,theDay)){			
				return true;
			}else{
				return 	false;
			}	
			
			
			return true;
		}else{
			alert("填入的时间不规范,请填写8位日期数字,格式类似于'20080101'!");
			return false;
		}
	
	}else{
		return true;
	}
	
	return false;

}
/*********************************

把输入日期是否符合日期格式　

*********************************/
function isTime(y,m,d,theName){	
	  if(m=="02"){
	       var theDay = (0==y%4 && (y%100!=0 || y%400==0)) ? 29 : 28;
	       if(d>theDay){
		       	document.getElementById(theName).value = "";
				document.getElementById(theName).focus();
		       	alert("对不起，你输入了错误的日期,请重新输入！");  
		       	return false;   
	       }
      }else if(m=="01"||m=="03"||m=="05"||m=="07"||m=="08"||m=="10"||m=="12"){
      	
      }else{
      	if(d>30){
      		document.getElementById(theName).value = "";
			document.getElementById(theName).focus();
	       	alert("对不起，你输入了错误的日期,请重新输入！");  
	       	return false;   
      	}
      }

    if (!(y<=9999 && y >= 1900 && parseInt(m, 10)>0 && parseInt(m, 10)<13 && parseInt(d, 10)>0&& parseInt(d, 10)<=31)){
        alert("对不起，你输入了错误的日期,请重新输入！");    
        document.getElementById(theName).value = "";
		document.getElementById(theName).focus();   
        return false;
   }
   
   return true;

}
function isDateTime(y,m,d){	
	  if(m=="02"){
	       var theDay = (0==y%4 && (y%100!=0 || y%400==0)) ? 29 : 28;
	       if(d>theDay){
		       	alert("对不起，你输入了错误的日期,请重新输入！");  
		       	return false;   
	       }
      }else if(m=="01"||m=="03"||m=="05"||m=="07"||m=="08"||m=="10"||m=="12"){
      	
      }else{
      	if(d>30){

	       	alert("对不起，你输入了错误的日期,请重新输入！");  
	       	return false;   
      	}
      }

    if (!(y<=9999 && y >= 1900 && parseInt(m, 10)>0 && parseInt(m, 10)<13 && parseInt(d, 10)>0&& parseInt(d, 10)<=31)){
        alert("对不起，你输入了错误的日期,请重新输入！");    
  
        return false;
   }
   
   return true;

}
// -----------------------------------------------------------------------------
//本函数用于测试字符串sString的长度;
// 注:对本函数来说,1个汉字代表2单位长度;
// -----------------------------------------------------------------------------
 function JHshStrLen(sString)
{
	var sStr,iCount,i,strTemp ; 
	iCount = 0 ;
	sStr = sString.split("");
	for (i = 0 ; i < sStr.length ; i ++)
	{
	strTemp = escape(sStr[i]); 
	if (strTemp.indexOf("%u",0) == -1) // 表示是汉字
	{ 
	iCount = iCount + 1 ;
	} 
	else 
	{
	iCount = iCount + 2 ;
	}
	}
	return iCount ;
}


function checkForms(obj){
       var iu;
       var iuu;
      var regArray=new Array("!","^","*","(",")","-","+","=","[","]","?","~","`","!","‰","→","←","↑","↓","！","@","◎","#","＃","$","…","※","￥","%","&","§","×","｛","｝","％","/","\'","\"");
       iuu=regArray.length;     
       for(iu=1;iu<=iuu;iu++){  
              if (obj.indexOf(regArray[iu])!=-1){
                     alert("输入内容中不可以包含：" + regArray[iu]);                  
                     return false;
              }
       }
return true;              
}


function toMoeny(str){  //JS将浮点型数字转化为货币型格式	
	 if(str.length != 0 ){
		 var strArray = new Array();
		 var strArrayTemp = new Array();
		 var strIndex = -1;
		 var loopC = 0;
		 var len = str.length;
		 var dot = str.indexOf(".");
		 var isComma = 0;
		 
		 for(var i=dot-1; i >= 0; i--){
			 isComma ++;
			 if(isComma % 3 == 0){
			 loopC ++;
			 strIndex = strIndex + 2;
			 strArray[strIndex] = str.substring(dot-isComma,dot-isComma+3);
			 } 
		 }
		 
		 strArray[strIndex+2] = str.substring(0,dot-loopC*3);
		 strArray[0] = str.substring(dot,len);
		 
		 if(strArray[strIndex+2] != undefined){ 
		 	strArray[strIndex+1] = ","; 
		 }else{
			 strArray[strIndex+2] = "";
			 strArray[strIndex+1] = "";
		 }
		 
		 for(var i= 2 ; i < strIndex;i+=2){
		 	strArray[i] = ",";		 
		 } 
		 
		 for(var i=strArray.length-1 ;i >= 0 ;i--){
		 	strArrayTemp = strArrayTemp + strArray[i];
		 }
		  alert("strArrayTemp:  "+strArrayTemp*0.22);
		 return strArrayTemp;
	 }else{
		 alert("String is null"); 
		 return "";
	 }
}
