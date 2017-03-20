jqbs(document).ready(function($) {
	var navClickOptions = {
		click: function() {
			$('a.nav-main',this).removeAttr('href');
			$('a',this).toggleClass('nav-hover');
			$('.nav-dropdown,.nav-dropdown-bottom',this).toggleClass('nav-hover-block');
		}
	}

	var navHoverOptions = {
		mouseenter: function() {
			$('a.nav-main',this).removeAttr('href');
			$('a',this).addClass('nav-hover');
			$('.nav-dropdown,.nav-dropdown-bottom',this).addClass('nav-hover-block');
		},
		mouseleave: function() {
			$('a.nav-main',this).removeAttr('href');
			$('a',this).removeClass('nav-hover');
			$('.nav-dropdown,.nav-dropdown-bottom',this).removeClass('nav-hover-block');
		}
	}

	$('header nav li').bind($(window).width() <= 550 ? navClickOptions : $.extend(navClickOptions,navHoverOptions));

	/* bootstrap.collapse fix */
	$('nav#navigation, #search-block').on('show', function(){
		$(this).css('height','auto');
	});
	$('#navigation').on('shown', function(){
		if ($('#search-block').find('.in')) $('#search-block').collapse('hide');
	});
	$('#search-block').on('shown', function(){
		if ($('#navigation').find('.in')) $('#navigation').collapse('hide');
	});
	/* /bootstrap.collapse fix */
});