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

function ViewModel() {
    var self = this;

    self.makes = ko.observableArray();
    self.makeId = ko.observable();
    self.StateId = ko.observable();
    self.States = ko.observableArray();
    

    var authorsUri = getUrl('/Dealer/States/');

    function getMakes() {
        ajaxHelper(getUrl('/Dealer/Makes'), 'GET').done(function (data) {
            var result = JSON.parse(data);
            console.log(result);
            self.makes(result);
        });
    }

    // Gets states from controller 
    function getStates() {
        ajaxHelper(authorsUri, 'GET').done(function (data) {
            var result = JSON.parse(data);
            console.log(result);
            self.States(result);
        });
    }



    function submitLoanForm() {
        $('#dealerForm').submit(function () {
            return false;
        });
        $('#submitdealerForm').click(function () {
            var currentForm = $('#dealerForm');
            if (!currentForm.valid())
                return false;
            window.location = getUrl('Dealer/Result?' + currentForm.serialize());
        });
    }

    getMakes();
    getStates();
    submitLoanForm();
}

// Page load
(function ($) {
    // Get menu data from service 
    ko.applyBindings(new ViewModel());
})(jQuery);

