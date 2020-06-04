$(window).on("scroll", function() {
    if($(window).scrollTop() > 450) {
        $(".main-menu").addClass("active");
    } else {
        //remove the background property so it comes transparent again (defined in your css)
       $(".main-menu").removeClass("active");
    }
});