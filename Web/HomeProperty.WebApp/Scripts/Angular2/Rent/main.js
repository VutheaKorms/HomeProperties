
;(function (app, ng) {
    app.CommandService = (function () {
        var CommandService = function (http) {           // this line changed
            this.url = '/Scripts/Angular2/Rent/commands.json';
            this.http = http;                            // this line added
        };

        CommandService.parameters = [                   // this line added
            ng.http.Http // this will be passed as arg in the constructor
        ];                                               // this line added

        CommandService.prototype.all = function () {
            return this.http.get(this.url)               // this line changed
                .map(function (response) {
                    return response.json().data;
                })
                .catch();
        };

        return CommandService;
    })();
})(window.app || (window.app = {}), window.ng);

;(function (app, ng) {
    app.CommandComponent = (function () {
        function CommandComponent(commandService) {
            this.commandService = commandService;
            this.commands = [];
        }

        CommandComponent.parameters = [
            app.CommandService
        ];
        CommandComponent.annotations = [
            new ng.core.Component({
                selector: '#command-listing',
                templateUrl: '/Scripts/Angular2/Rent/listings.html',
                providers: [
                    app.CommandService,
                    ng.http.HTTP_PROVIDERS
                ]
            })
        ];

        CommandComponent.prototype.all = function () {
            var self = this;

            this.commandService.all().subscribe(
                function (commands) {
                    self.commands = commands;
                }, function (error) {
                    self.error = error;
                }
            );
        };
        CommandComponent.prototype.ngOnInit = function () {
            this.all();
        };

        return CommandComponent;
    })();
})(window.app || (window.app = {}), window.ng);

; (function (app, ng) {
    document.addEventListener('DOMContentLoaded', function () {
        ng.platform.browser.bootstrap(app.CommandComponent);
    });
})(window.app || (window.app = {}), window.ng);