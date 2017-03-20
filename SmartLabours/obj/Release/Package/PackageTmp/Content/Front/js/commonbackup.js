$(document).ready(function(){

		$('#mobilemenu').click(function(){			
				$('.main-nav').slideToggle('slow');
		 });	 
		 	$('.fancybox').fancybox();
});
$(window).load(function() {
    $("#mainslider").flexisel({
        visibleItems: 1,
        animationSpeed: 1000,
        autoPlay: true,
        autoPlaySpeed: 10000,            
        pauseOnHover: true
		});	
	 $("#js_testimonial").flexisel({
        visibleItems: 4,
        animationSpeed: 1000,
        autoPlay: false,
        autoPlaySpeed: 3000,            
        pauseOnHover: true,
		enableResponsiveBreakpoints: true,
		responsiveBreakpoints: { 
            portrait: { 
                changePoint:480,
                visibleItems: 1
            }, 
            landscape: { 
                changePoint:640,
                visibleItems: 1
            },
            tablet: { 
                changePoint:768,
                visibleItems: 2
            },
			 tablet: { 
                changePoint:1025,
                visibleItems: 3
            },
        }
		});		
});