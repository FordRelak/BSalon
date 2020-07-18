$(document).ready(function () {
    $('.accordion-item').click(function () {
        var $item = $(this).parents('.accordion-item');
        $($(this).children()[1]).slideToggle();
    });

    $(".btn-danger").click(function () {
        let btn = this;
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
            alert("Произошла ошибка при удалении записи. Попробуйте через неслько минут повторить операцию.")
        })

    })
});

