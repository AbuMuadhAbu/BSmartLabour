
$(document).ready(function () {
    setInterval(function () {

        try {
            var url = "/Home/RunSmartSchedular";
            $.post(url, function (data) {
               
            });

        }
        catch (ex) {
        }
    }, 1000);

    });



$(document).ready(function () {

		$('#mobilemenu').click(function(){			
				$('.main-nav').slideToggle('slow');
		 });	 
		 	$('.fancybox').fancybox();
			
	$('#mainslider').bxSlider({
		auto:true,		 
		controls:true,
		mode:'fade',
		autoHover:true,
		pager:false,
		pause:6000	
	}); 
});
$(window).load(function() {
    /*$("#mainslider").flexisel({
        visibleItems: 1,
        animationSpeed: 1000,
        autoPlay: true,
        autoPlaySpeed: 10000,            
        pauseOnHover: true
		});	*/
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

         $("#js_testimonial1").flexisel({
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
         $("#js_testimonial2").flexisel({
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