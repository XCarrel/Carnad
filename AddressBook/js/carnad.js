$(document).ready(function () {
    $('.clickable-row').click(function () {
        window.location = $(this).data('href')
    })

   // Group name validation
    $('#newgroup').keyup(function () {
        $('#cmdNew').prop('disabled', $(this).val().length < 2) // group name must be at least 2 chars long
        $.get("api/Groups/Exists/" + $(this).val(), function (data, status) {
            if (data) { // group name already exists
                $('#cmdNew').prop('disabled', true)
                $('#errgrp').removeClass('hidden')
            }
            else {
                $('#errgrp').addClass('hidden')
            }
        });
    })
})