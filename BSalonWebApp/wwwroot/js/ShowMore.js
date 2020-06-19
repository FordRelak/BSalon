$(document).ready(function ($) {
    $("#showMore").click(function (e) {
        $(".imagelist img:hidden").slice(0, 3).fadeIn();
        if ($(".imagelist img:hidden").length < 1) $(this).fadeOut();
    })
})