
$(document).ready(function () {
    
    $(".menu_second_ul").hide();
    $("a").click(function () {
        
        $(".menu_li a").removeClass("active");
        $(this).addClass("active");

        if ($(this).parent().children(".menu_second_ul").is(":visible")) {
            $(this).parent().children(".menu_second_ul").hide();
            $(".menu_li a").removeClass("active");
        }
        else {
            if ($(".menu_second_ul").is(":visible")) {
                $(".menu_second_ul").hide();
            }
            $(this).parent().children(".menu_second_ul").show();
        }
    });


});