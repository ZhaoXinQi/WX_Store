/**
* 初始化加载
* @author EnoND
*/
$.fn.timerInit = function(option){
	$(this).each(function(){
		var timerItem = new Object();
		var obj = $(this);

		timerItem = {
			//返回天、小时、分、秒的方法，循环调用即可
			getTime : function(){
				var result = {"d":timerItem.getPoint("d"), "h":timerItem.getPoint("h"), "m":timerItem.getPoint("m"), "s":timerItem.getPoint("s")};
				var str = obj.attr("data-strBefore");
				if(Date.parse(timerItem.nowDate)>=Date.parse(timerItem.pointDate)){
					str = obj.attr("data-strAfter");
				}
				timerItem.runTime();
				timerItem.showTime(str,result.d,result.h,result.m,result.s);
				return result;
			},

			//字符串转时间格式  
			getDate : function(strDate){
				var reg = /-|:| /;
				var DI = strDate.split(reg);
				return new Date(DI[0], DI[1], DI[2], DI[3], DI[4], DI[5]);
			},
			//当前时间增加一秒
			runTime : function(){
				var parse = Date.parse(timerItem.nowDate);
				parse = eval(parse + 1000);
				timerItem.nowDate = new Date(parse);
			},
			//获得相对时间点的天、小时、分钟和秒
			getPoint : function(op){
				var nowDateParse = Date.parse(timerItem.nowDate);
			    var minsec = nowDateParse >= timerItem.pointDateParse?(nowDateParse-timerItem.pointDateParse):(timerItem.pointDateParse-nowDateParse);
			    var days = 0;
				switch(op){
					case "d":
						days = minsec / 1000 / 60 / 60 / 24;
					break;
					case "h":
						days = (minsec / 1000 / 60 / 60)-parseInt((minsec / 1000 / 60 / 60 / 24))*24;
					break;
					case "m":
						days = (minsec / 1000 / 60) - parseInt((minsec / 1000 / 60 / 60))*60;
					break;
					case "s":
						days = (minsec / 1000 ) - parseInt((minsec / 1000 / 60))*60;
					break;
				}
				return parseInt(days);
			},
			//显示时间
			showTime : function(str,d,h,m,s){
				obj.find(".timer-str").html(str);
				obj.find(".timer-d").html(d);
				obj.find(".timer-h").html(h);
				obj.find(".timer-m").html(m);
				obj.find(".timer-s").html(s);
			}

		}

		timerItem.nowDate = timerItem.getDate(obj.attr("data-nowTime"));		//当前时间date对象
		timerItem.pointDate = timerItem.getDate(obj.attr("data-pointTime"));
		timerItem.pointDateParse = Date.parse(timerItem.pointDate);		//获得时间点的毫秒数
		setInterval(function(){timerItem.getTime();}, 1000);
	});
}