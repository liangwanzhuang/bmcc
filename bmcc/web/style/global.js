// JavaScript Document

 function clickme(hideme)
 {
	var AX=document.getElementById(hideme); 
	AX.style.display=AX.style.display=="none"?"":"none"; 

	for (i=1;i<9;i++)
	{
		if(document.getElementById("tree"+i)!=null&& document.getElementById("tree"+i)!=document.getElementById(hideme))
		{
			if(document.getElementById("left_"+i)!=null)
			{
				document.getElementById("left_"+i).className="nav2-off";
			}
			document.getElementById("tree"+i).style.display="none";
		}
		
		else 
		{
				if(document.getElementById("left_"+i)!=null)
			{
				document.getElementById("left_"+i).className="nav2-on";
			}
			document.getElementById("tree"+i).style.display="block";
			}
	}
 }
 function clickmeTJ(hideme)
 {
	var AX=document.getElementById(hideme); 
	AX.style.display=AX.style.display=="none"?"":"none"; 

	for (i=1;i<=7;i++)
	{
		if(document.getElementById("tree"+i)!=null&& document.getElementById("tree"+i)!=document.getElementById(hideme))
		{
			if(document.getElementById("left_"+i)!=null)
			{
				document.getElementById("left_"+i).className="nav2-off";
			}
			document.getElementById("tree"+i).style.display="none";
		}
		
		else 
		{
				if(document.getElementById("left_"+i)!=null)
			{
				document.getElementById("left_"+i).className="nav2-on";
			}
			document.getElementById("tree"+i).style.display="block";
			}
	}
 }
 function clickTree(hideme)
 {
	//var AX=document.getElementById(hideme); 
	//AX.style.display=AX.style.display=="none"?"":"none"; 
	for(var i=1;i<=9;i++)
	{
		if(i!=hideme)
		{
			if(document.getElementById('tree'+i)!=null){
				document.getElementById('tree'+i).style.display="none";
			}
		}
		else
		{
				document.getElementById('tree'+i).style.display="block";
		}
	}
				
	
 }
 
 function clickme2(hideme)
 {
	var AX=document.getElementById(hideme); 
	AX.style.display=AX.style.display=="none"?"":"none"; 

	for (i=1;i<4;i++)
	{
		if(document.getElementById("menu"+i) && document.getElementById("menu"+i)!=document.getElementById(hideme))
		{
			document.getElementById("menu"+i).style.display="none";
		}
	}
 }
 
 
 function changme(nav)
 {
	var AX=document.getElementById(nav); 
	AX.style.display=AX.style.display=="none"?"":"none"; 
	for (i=1;i<22;i++)
	{
		if(document.getElementById("nav2_"+i) && document.getElementById("nav2_"+i)!=document.getElementById(nav))
		{
			document.getElementById("nav2_"+i).className="nav3-off";
		}
		else {
			document.getElementById("nav2_"+i).className="nav3-on";
		}
	}
 }