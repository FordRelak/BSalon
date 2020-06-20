$(document).ready(function () {
    // instantiate the dialog on document ready
    $("#dialog-confirm").dialog({
        autoOpen: false,
        resizable: false,
        height: 170,
        width: 350,
        show: {
            effect: 'drop',
            direction: 'up'
        },
        modal: true,
        draggable: true,
        open: function (event, ui) {
            $(".ui-dialog-titlebar-close").hide();
        },
        buttons: {
            "OK": function () {
                $(this).dialog("close");
                window.location.href = url;
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    $("#btn1").click(function () {
        // open the dialog on the submit button click
        $('#dialog-confirm').dialog('open');
    });
});