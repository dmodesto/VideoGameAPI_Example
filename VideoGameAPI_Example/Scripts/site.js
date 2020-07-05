$(document).ready(function () {
    // show and hide Summary
    $('#games').on('click', '.dots', function () {
        var self = this;
        $(self).addClass('hidden');
        $(self).parent().children('.more').removeClass('hidden');
    });

    $('#games').on('click', '.less', function () {
        var self = this;
        $(self).parent().parent().children('.dots').removeClass('hidden');
        $(self).parent().addClass('hidden');
    });
})