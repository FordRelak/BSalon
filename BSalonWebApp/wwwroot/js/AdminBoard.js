$(document).ready(function () {
    $('.accordion-item-title').click(function () {
        var $item = $(this).parents('.accordion-item');
        $item.toggleClass('accordion-item--active').siblings('.accordion-item--active').removeClass('accordion-item--active');
    });
});

