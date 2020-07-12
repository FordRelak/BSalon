$(document).ready(function () {
    $('.accordion-item').click(function () {
        var $item = $(this).parents('.accordion-item');
        //$(this).toggleClass('accordion-item--active');
        $($(this).children()[1]).slideToggle();
    });

    $(":button").click(function () {
        let btn = this;

        
        console.log(btn.getAttribute("asp-route-id")); //
        let id = btn.getAttribute("asp-route-id");
        var settings = {
            "url": "https://localhost:5001/api/AdminBoardAPI/",
            "method": "DELETE",
            "timeout": 0,
            "headers": {
                "id": id
            },
        };

        var request = $.ajax(settings);

        request.done(function (response) {
            $(btn.closest(".accordion-item")).slideUp();
        });
        request.fail(function (response) {
            console.log(response.status); //
            alert("Произошла ошибка при удалении записи. Попробуйте через неслько минут повторить операцию.")
        })

    })
});

