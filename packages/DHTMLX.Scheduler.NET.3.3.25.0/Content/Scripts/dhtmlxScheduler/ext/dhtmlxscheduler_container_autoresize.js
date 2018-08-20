/*
@license
dhtmlxScheduler.Net v.3.3.23 Professional Evaluation

This software is covered by DHTMLX Evaluation License. Contact sales@dhtmlx.com to get Commercial or Enterprise license. Usage without proper license is prohibited.

(c) Dinamenta, UAB.
*/
Scheduler.plugin(function(e){!function(){e.config.container_autoresize=!0,e.config.month_day_min_height=90,e.config.min_grid_size=25,e.config.min_map_size=400;var t=e._pre_render_events,a=!0,i=0,n=0;e._pre_render_events=function(l,r){if(!e.config.container_autoresize||!a)return t.apply(this,arguments);var o=this.xy.bar_height,d=this._colsS.heights,s=this._colsS.heights=[0,0,0,0,0,0,0],_=this._els.dhx_cal_data[0];if(l=this._table_view?this._pre_render_events_table(l,r):this._pre_render_events_line(l,r),
this._table_view)if(r)this._colsS.heights=d;else{var c=_.firstChild;if(c.rows){for(var u=0;u<c.rows.length;u++){if(s[u]++,s[u]*o>this._colsS.height-this.xy.month_head_height){var h=c.rows[u].cells,p=this._colsS.height-this.xy.month_head_height;1*this.config.max_month_events!==this.config.max_month_events||s[u]<=this.config.max_month_events?p=s[u]*o:(this.config.max_month_events+1)*o>this._colsS.height-this.xy.month_head_height&&(p=(this.config.max_month_events+1)*o);for(var v=0;v<h.length;v++)h[v].childNodes[1].style.height=p+"px";

s[u]=(s[u-1]||0)+h[0].offsetHeight}s[u]=(s[u-1]||0)+c.rows[u].cells[0].offsetHeight}s.unshift(0),c.parentNode.offsetHeight<c.parentNode.scrollHeight&&!c._h_fix}else if(l.length||"visible"!=this._els.dhx_multi_day[0].style.visibility||(s[0]=-1),l.length||-1==s[0]){var m=(c.parentNode.childNodes,(s[0]+1)*o+1);n!=m+1&&(this._obj.style.height=i-n+m-1+"px"),m+="px",_.style.top=this._els.dhx_cal_navline[0].offsetHeight+this._els.dhx_cal_header[0].offsetHeight+parseInt(m,10)+"px",_.style.height=this._obj.offsetHeight-parseInt(_.style.top,10)-(this.xy.margin_top||0)+"px";

var b=this._els.dhx_multi_day[0];b.style.height=m,b.style.visibility=-1==s[0]?"hidden":"visible",b=this._els.dhx_multi_day[1],b.style.height=m,b.style.visibility=-1==s[0]?"hidden":"visible",b.className=s[0]?"dhx_multi_day_icon":"dhx_multi_day_icon_small",this._dy_shift=(s[0]+1)*o,s[0]=0}}return l};var l=["dhx_cal_navline","dhx_cal_header","dhx_multi_day","dhx_cal_data"],r=function(t){i=0;for(var a=0;a<l.length;a++){var r=l[a],o=e._els[r]?e._els[r][0]:null,d=0;switch(r){case"dhx_cal_navline":case"dhx_cal_header":
d=parseInt(o.style.height,10);break;case"dhx_multi_day":d=o?o.offsetHeight-1:0,n=d;break;case"dhx_cal_data":var s=e.getState().mode;if(d=o.childNodes[1]&&"month"!=s?o.childNodes[1].offsetHeight:Math.max(o.offsetHeight-1,o.scrollHeight),"month"==s){if(e.config.month_day_min_height&&!t){var _=o.getElementsByTagName("tr").length;d=_*e.config.month_day_min_height}t&&(o.style.height=d+"px")}else if("year"==s)d=190*e.config.year_y;else if("agenda"==s){if(d=0,o.childNodes&&o.childNodes.length)for(var c=0;c<o.childNodes.length;c++)d+=o.childNodes[c].offsetHeight;

d+2<e.config.min_grid_size?d=e.config.min_grid_size:d+=2}else if("week_agenda"==s){for(var u,h,p=e.xy.week_agenda_scale_height+e.config.min_grid_size,v=0;v<o.childNodes.length;v++){h=o.childNodes[v];for(var c=0;c<h.childNodes.length;c++){for(var m=0,b=h.childNodes[c].childNodes[1],g=0;g<b.childNodes.length;g++)m+=b.childNodes[g].offsetHeight;u=m+e.xy.week_agenda_scale_height,u=1!=v||2!=c&&3!=c?u:2*u,u>p&&(p=u)}}d=3*p}else if("map"==s){d=0;for(var x=o.querySelectorAll(".dhx_map_line"),c=0;c<x.length;c++)d+=x[c].offsetHeight;

d+2<e.config.min_map_size?d=e.config.min_map_size:d+=2}else if(e._gridView)if(d=0,o.childNodes[1].childNodes[0].childNodes&&o.childNodes[1].childNodes[0].childNodes.length){for(var x=o.childNodes[1].childNodes[0].childNodes[0].childNodes,c=0;c<x.length;c++)d+=x[c].offsetHeight;d+=2,d<e.config.min_grid_size&&(d=e.config.min_grid_size)}else d=e.config.min_grid_size;if(e.matrix&&e.matrix[s])if(t)d+=2,o.style.height=d+"px";else{d=2;for(var y=e.matrix[s],f=y.y_unit,k=0;k<f.length;k++)d+=f[k].children?y.folder_dy||y.dy:y.dy;

}("day"==s||"week"==s||e._props&&e._props[s])&&(d+=2)}i+=d}e._obj.style.height=i+"px",t||e.updateView()},o=function(){if(!e.config.container_autoresize||!a)return!0;var t=e.getState().mode;r(),(e.matrix&&e.matrix[t]||"month"==t)&&window.setTimeout(function(){r(!0)},1)};e.attachEvent("onViewChange",o),e.attachEvent("onXLE",o),e.attachEvent("onEventChanged",o),e.attachEvent("onEventCreated",o),e.attachEvent("onEventAdded",o),e.attachEvent("onEventDeleted",o),e.attachEvent("onAfterSchedulerResize",o),
e.attachEvent("onClearAll",o),e.attachEvent("onBeforeExpand",function(){return a=!1,!0}),e.attachEvent("onBeforeCollapse",function(){return a=!0,!0})}()});