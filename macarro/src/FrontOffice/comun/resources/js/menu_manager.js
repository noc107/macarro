
$(document).ready(function () {
    
    $(".header_menu_second_ul").hide();
   
    $("a").click(function () {
        
        $("a").removeClass("active");
        $(this).addClass("active");

        if ($(this).parent().children(".header_menu_second_ul").is(":visible") || ( $(".header_menu_second_ul_Profile").is(":visible") && $("#Profile").attr("class")=="active")) {
            $(this).parent().children(".header_menu_second_ul").hide();
            $(".header_menu_second_ul_Profile").hide();
            $("a").removeClass("active");
        }
        else {
            if ($(".header_menu_second_ul").is(":visible") || $(".header_menu_second_ul_Profile").is(":visible")) {
                $(".header_menu_second_ul").hide();
                $(".header_menu_second_ul_Profile").hide();
            }
            if ($(this).attr('id') == "Profile") {
                $(".header_menu_second_ul_Profile").show();
            }
            else {
                $(this).parent().children(".header_menu_second_ul").show();

            }
        }
    });

   


});