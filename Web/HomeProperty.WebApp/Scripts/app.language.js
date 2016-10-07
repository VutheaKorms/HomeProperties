function onLanguageClick() {
    $("input[type='radio'][name='culture']").click(function () {
        $(this).parents("form").submit();
    });
}

(function ($) {
    onLanguageClick();
})(jQuery);