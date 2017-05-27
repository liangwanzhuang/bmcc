// JavaScript Document

 function clickme(hideme)
 {
	var AX=document.getElementById(hideme); 
	AX.style.display=AX.style.display=="none"?"":"none"; 

	for (var i=1;i<10;i++)
	{
		if(document.getElementById("tree"+i) && document.getElementById("tree"+i)!=document.getElementById(hideme))
		{
			document.getElementById("tree"+i).style.display="none";
		}
	}
 }

 function clickme2(hideme)
 {
	var AX=document.getElementById(hideme); 
	AX.style.display=AX.style.display=="none"?"":"none"; 

	for (i=1;i<45;i++)
	{
		if(document.getElementById("menu"+i) && document.getElementById("menu"+i)!=document.getElementById(hideme))
		{
			document.getElementById("menu"+i).style.display="none";
		}
	}
 }

 function clickme3(hideme)
 {
	var AX=document.getElementById(hideme); 
	AX.style.display=AX.style.display=="none"?"":"none"; 

	for (i=1;i<10;i++)
	{
		if(document.getElementById("dh"+i) && document.getElementById("dh"+i)!=document.getElementById(hideme))
		{
			document.getElementById("dh"+i).style.display="none";
		}
	}
 }

function change_nav(num){
	for(var i=1;i<=10;i++)
	{
	if(i!=num){
			if(document.getElementById('nav_'+i)!=null){
				document.getElementById('nav_'+i).className='';
			}
		}else
		{
			document.getElementById('nav_'+i).className='on';
		}
	}
}

function change_left(num){
	for(var i=0;i<=10;i++)
	{
	if(i!=num){
			if(document.getElementById('left_'+i)!=null){
				document.getElementById('left_'+i).className='left';
			}
		}else
		{
			document.getElementById('left_'+i).className='left-on';
		}
	}
}

function change_nav2(num){
	for(var i=1;i<=45;i++)
	{
	if(i!=num){
			if(document.getElementById('nav2_'+i)!=null){
				document.getElementById('nav2_'+i).className='nav2-off';
			}
		}else
		{
			document.getElementById('nav2_'+i).className='nav2-on';
		}
	}
}

function change_nav3(num){
	for(var i=1;i<=40;i++)
	{
	if(i!=num){
			if(document.getElementById('nav3_'+i)!=null){
				document.getElementById('nav3_'+i).className='nav3-off';
			}
		}else
		{
			document.getElementById('nav3_'+i).className='nav3-on';
		}
	}
}

function change_nav4(num){
	for(var i=1;i<=10;i++)
	{
	if(i!=num){
			if(document.getElementById('nav4_'+i)!=null){
				document.getElementById('nav4_'+i).className='nav4-off';
			}
		}else
		{
			document.getElementById('nav4_'+i).className='nav4-on';
		}
	}
}






