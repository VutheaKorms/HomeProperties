
$.validator.addMethod('selectRequired',
    function (value, element) {
        return value != '';
    },
    'Please select a value');
