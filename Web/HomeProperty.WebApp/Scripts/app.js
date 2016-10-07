// Ajax helper
// @uri - the service uri
// @method - the http verb 
// @data - data to be send to the server
function ajaxHelper(uri, method, data) {
    return $.ajax({
        type: method,
        url: uri,
        dataType: 'json',
        contentType: 'application/json',
        data: data ? JSON.stringify(data) : {}
    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.log(errorThrown);
    });
}

// Gets service endpoint from current url
function getUrl(endpoint) {
    var url = $(location).attr('href').substr(8);
    var baseUrl = url.substr(0, url.indexOf('/') + 1);
    console.log('https:\/\/' + baseUrl + endpoint);
    return 'https:\/\/' + baseUrl + endpoint;
}

// Gets main navigation menu from service
// Build menu html using data from the service
function getMainNavigationMenu() {
    ajaxHelper(getUrl('/Home/MainNavigationMenu'), 'GET').done(function (data) {
        var menuItems = JSON.parse(data);
        console.log(menuItems);
        $("#mainNavTemplate").tmpl(menuItems)
        .appendTo("#mainNavMenu");
    });
}

(function ($) {
    // Get menu data from service 
    getMainNavigationMenu();
})(jQuery);

    



