$(document).ready(function () {
    $("#image1").fadeOut(0);
    $("#image2").fadeOut(0);

    $("#tableButton").click(function (e) {
        $("#table1").fadeIn(0);
        $("#image1").fadeOut(0);
        $("#image2").fadeOut(0);
    })

    $("#imageButton1").click(function (e) {
        $("#table1").fadeOut(0);
        $("#image1").fadeIn(0);
        $("#image2").fadeOut(0);
    })

    $("#imageButton1").click(function (e) {
        $("#table1").fadeOut(0);
        $("#image1").fadeOut(0);
        $("#image2").fadeIn(0);
    })

});

