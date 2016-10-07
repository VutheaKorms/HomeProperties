
function onMembershipClick() {
    $('#membership').click(function () {
        window.location = getUrl('Membership');
    });
}

function onFinanceClick() {
    $('#finance').click(function () {
        window.location = getUrl('Finance')
    });
}

function onMessageClick() {
    $('#message').click(function () {
        window.location = getUrl('Message');
    });
}

(function ($) {
    onMembershipClick();
    onFinanceClick();
    onMessageClick(); 
})(jQuery);

