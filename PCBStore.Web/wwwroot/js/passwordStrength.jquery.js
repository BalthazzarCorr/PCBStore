(function(c,b,d){var a=this.PasswordStrength=function(f,e){this.options=c.extend(true,{},c.fn.passwordStrength.defaultSettings,e||{});this.$elem=c(f);this.percentage=0;this.complexity=0;this.time=0;this.valid=false;this.divs={targetDiv:null,progressDiv:null,progressBarDiv:null,percentageDiv:null,timeDiv:null};this.init();return this};a.prototype={init:function(){var e=this;e.$elem.keyup(function(){var f=e.$elem.val();e._complexity(f);e._time(f);if(e.options.show===true){e._show()}if(e.options.callback!==d){e.valid=this.minimumChars<f.length?true:false;e.options.callback.call(e)}})},_getTargetDiv:function(h,f,g){if(h===null){var e=c("<div/>",{id:f});if(g!==null){e.insertAfter(g)}return e}if(typeof h==="string"){return c("#"+h)}if(h instanceof c){return h}},_show:function(){if(this.divs.targetDiv===null){this.divs.targetDiv=this._getTargetDiv(this.options.targetDiv,"passwordStrength",this.$elem)}if(this.options.showProgressBar===true){if(this.divs.progressBarDiv===null){this.divs.progressBarDiv=this._getTargetDiv(this.options.progressBarTargetDiv,"progressbar",null);if(this.divs.progressDiv===null){this.divs.progressDiv=this._getTargetDiv(this.options.progressTargetDiv,"progress",null);this.divs.progressDiv.appendTo(this.divs.progressBarDiv)}this.divs.progressBarDiv.appendTo(this.divs.targetDiv)}this.divs.progressDiv.css({width:this.percentage+"%",backgroundColor:"rgb("+Math.floor((100-this.percentage)/50*255)+","+Math.floor((255*(this.percentage/50)))+",0)"})}if(this.options.showPercentage===true){if(this.divs.percentageDiv===null){this.divs.percentageDiv=this._getTargetDiv(this.options.percentageTargetDiv,"percentage",null);if(this.options.showProgressBar===true){this.divs.percentageDiv.appendTo(this.divs.progressBarDiv)}else{this.divs.percentageDiv.appendTo(this.divs.targetDiv)}}this.divs.percentageDiv.html(this.percentage+"%")}if(this.options.showTime===true){if(this.divs.timeDiv===null){this.divs.timeDiv=this._getTargetDiv(this.options.timeTargetDiv,"time",null);this.divs.timeDiv.appendTo(this.divs.targetDiv)}this.divs.timeDiv.html(this.time)}},_additionalComplexityForCharset:function(f,g){for(var e=f.length-1;e>=0;e--){if(g[0]<=f.charCodeAt(e)&&f.charCodeAt(e)<=g[1]){return g[1]-g[0]+1}}return 0},_complexity:function(f){var e=0;if(!this._inBanlist(f)){for(i=this.CHARSET.length-1;i>=0;i--){e+=this._additionalComplexityForCharset(f,this.CHARSET[i])}}else{e=1}this.complexity=e=Math.log(Math.pow(e,f.length));e=(e/this.MAX_COMPLEXITY)*100;e=(e>100)?100:e;this.percentage=Math.round(e)},_inBanlist:function(f){if(this.options.banmode==="strict"){for(var e=1;e<=f.length;e++){if(c.inArray(f.substr(0,e),this.options.bannedPasswords)>-1){return true}}return false}else{return c.inArray(f,this.options.bannedPasswords)>-1?true:false}},_time:function(n){var o=Math.pow(this.complexity,n.length);var v=o/this.options.rate;var r=v/(3600*24*365);var m=Math.floor(r);var l=(r-m)*12;var g=Math.floor(l);var f=(l-g)*30;var u=Math.floor(f);var e=(f-u)*24;var p=Math.floor(e);var k=(e-p)*60;var j=Math.floor(k);var t=(k-j)*60;var q=Math.floor(t);var h=[];if(m>0){if(m===1){h.push("1 "+this.options.text.year.split("|")[0]+", ")}else{h.push(m+" "+this.options.text.year.split("|")[1]+", ")}}if(g>0){if(g===1){h.push("1 "+this.options.text.month.split("|")[0]+", ")}else{h.push(g+" "+this.options.text.month.split("|")[1]+", ")}}if(u>0){if(u===1){h.push("1 "+this.options.text.day.split("|")[0]+", ")}else{h.push(u+" "+this.options.text.day.split("|")[1]+", ")}}if(p>0){if(p===1){h.push("1 "+this.options.text.hour.split("|")[0]+", ")}else{h.push(p+" "+this.options.text.hour.split("|")[1]+", ")}}if(j>0){if(j===1){h.push("1 "+this.options.text.minute.split("|")[0]+", ")}else{h.push(j+" "+this.options.text.minute.split("|")[1]+", ")}}if(q>0){if(q===1){h.push("1 "+this.options.text.second.split("|")[0]+", ")}else{h.push(q+" "+this.options.text.second.split("|")[1]+", ")}}if(h.length<=0){h=this.options.text.lessthanonesecond+", "}else{if(h.length===1){h=h[0]}else{h=h[0]+h[1]}}this.time=this.options.text.canbefound+h.substring(0,h.length-2)},MIN_COMPLEXITY:49,MAX_COMPLEXITY:120,CHARSET:[[48,57],[65,90],[97,122],[33,47],[58,64],[91,96],[123,126],[128,255],[256,383],[384,591],[592,687],[688,767],[768,879],[880,1023],[1024,1279],[1328,1423],[1424,1535],[1536,1791],[1792,1871],[1920,1983],[2304,2431],[2432,2559],[2560,2687],[2688,2815],[2816,2943],[2944,3071],[3072,3199],[3200,3327],[3328,3455],[3456,3583],[3584,3711],[3712,3839],[3840,4095],[4096,4255],[4256,4351],[4352,4607],[4608,4991],[5024,5119],[5120,5759],[5760,5791],[5792,5887],[6016,6143],[6144,6319],[7680,7935],[7936,8191],[8192,8303],[8304,8351],[8352,8399],[8400,8447],[8448,8527],[8528,8591],[8592,8703],[8704,8959],[8960,9215],[9216,9279],[9280,9311],[9312,9471],[9472,9599],[9600,9631],[9632,9727],[9728,9983],[9984,10175],[10240,10495],[11904,12031],[12032,12255],[12272,12287],[12288,12351],[12352,12447],[12448,12543],[12544,12591],[12592,12687],[12688,12703],[12704,12735],[12800,13055],[13056,13311],[13312,19893],[19968,40959],[40960,42127],[42128,42191],[44032,55203],[55296,56191],[56192,56319],[56320,57343],[57344,63743],[63744,64255],[64256,64335],[64336,65023],[65056,65071],[65072,65103],[65104,65135],[65136,65278],[65279,65279],[65280,65519],[65520,65533]]};c.fn.passwordStrength=function(e,f){if(f!==d){e.callback=f}return this.each(function(){if(!c.data(this,"_PasswordStrength")){c.data(this,"_PasswordStrength",new a(this,e))}})};c.fn.passwordStrength.defaultSettings={targetDiv:null,show:true,showProgressBar:true,progressTargetDiv:null,progressBarTargetDiv:null,showPercentage:true,percentageTargetDiv:null,showTime:true,timeTargetDiv:null,minimumChars:8,bannedPasswords:[],banmode:"strict",rate:348000000000,text:{year:"year|years",month:"month|months",day:"day|days",hour:"hour|hours",minute:"minute|minutes",second:"second|seconds",lessthanonesecond:"less than one second",canbefound:"Can be found in: "}}})(jQuery,window);