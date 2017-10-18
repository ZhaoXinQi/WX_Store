// JavaScript Document
//图片尺寸
$(function(){
	var w1 = $(".index_banner .swiper-slide img").width();
	$(".index_banner .swiper-slide img").height(0.5*w1);
	var w2 = $(".product_details .swiper-slide img").width();
	$(".product_details .swiper-slide img").height(1*w2);
	var w3 = $(".search_list ul li a>img").width();
	$(".search_list ul li a>img").height(1*w3);
	
	
	$(".pro_det>p span:eq(1)").css("background-image","url(images/icon_013.png)");
	$(".pro_bottom span b:eq(0)").css("background-image","url(images/icon_022.png)");
	$(".pro_bottom>p a:eq(0)").css("background-color","#252525");
	
	$(".pro_standard dl:eq(0) dd").click(function(){
		$(".pro_standard dl:eq(0) dd").removeClass("on");
		$(this).addClass("on");
    })
	$(".pro_standard dl:eq(1) dd").click(function(){
		$(".pro_standard dl:eq(1) dd").removeClass("on");
		$(this).addClass("on");
    })
	$(".pro_bottom span b:eq(1)").click(function(){
		$(this).toggleClass("on");
    })
	$(".pro_standard>h2 img").click(function(){
		$(this).parents("h2").siblings(".pro_stand").slideToggle();
    })
	$(".notice ul li p").last().css("border-bottom","0px");
})
//底部固定导航

$(function(){
	var h=$(".ftop").height()+6;
	$("body").css({"padding-top":h+"px"})
})
/***回顶部***/
$(function(){ 
$('.gotop .topshang').click(function(){
	$('html,body').animate({scrollTop: '0px'}, 800);}); 
});