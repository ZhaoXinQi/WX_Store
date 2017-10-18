// JavaScript Document

//底部固定导航
$(function(){
	var bottom01 = $(".fixft").height();
	var bottom02 = $(".makesure").height();
	var bottom03 = $(".amount").height();

	var top01 = $(".ftop").height();
	var top02 = $(".orderkind").height();

	if(top01){top01=46;}
	if(top02){top02=58;}

	if(bottom01){bottom01=54;}


	var bottom = bottom01 + bottom02 + bottom03;
	var top = top01 + top02;
	$("body").css({"padding-bottom":bottom+"px","padding-top":top+"px"})
})




