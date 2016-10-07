; (function (app, ng) {
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