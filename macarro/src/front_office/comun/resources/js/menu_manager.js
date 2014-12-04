
$(document).ready(function () {
    
    $(".header_menu_second_ul").hide();
    $("a").click(function () {
        
        $(".header_menu_first_li a").removeClass("active");
        $(this).addClass("active");

        if ($(this).parent().children(".header_menu_second_ul").is(":visible")) {
            $(this).parent().children(".header_menu_second_ul").hide();
            $(".header_menu_first_li a").removeClass("active");
        }
        else {
            if ($(".header_menu_second_ul").is(":visible")) {
                $(".header_menu_second_ul").hide();
            }
            $(this).parent().children(".header_menu_second_ul").show();
        }
    });


});