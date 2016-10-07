(function (angular, $) {
    angular.module('ngValidate', [])

        .directive('ngValidate', function () {
            return {
                require: 'form',
                restrict: 'A',
                scope: {
                    ngValidate: '='
                },
                link: function (scope, element, attrs, form) {
                    form.validate = function (showErrors) {
                        //fixed to apply rule work only startup controller to work everywhere when change rule
                        var validator = element.validate(scope.ngValidate);
                        
                        if (typeof showErrors === 'undefined') showErrors = true;

                        if (showErrors) {
                            return validator.form();
                        } else {
                            return validator.checkForm();
                        }
                    };

                    form.numberOfInvalids = function () {
                        return validator.numberOfInvalids();
                    };
                }
            };
        })

        .provider('$validator', function () {
            return {
                setDefaults: function (options) {
                    $.validator.setDefaults(options);
                },
                addMethod: function (name, method, message) {
                    $.validator.addMethod(name, method, message);
                },
                $get: function () {
                    return {};
                }
            };
        });
}(angular, jQuery));