; (function (app, ng) {
    app.PackageComponent = (function () {
        function PackageComponent(packageService) {
            this.packageService = packageService;
            this.packages = [];
        }

        PackageComponent.parameters = [
            app.PackageService
        ];
        PackageComponent.annotations = [
            new ng.core.Component({
                selector: '#package-listing',
                templateUrl: '/Scripts/Angular2/Agent/api/menu/index.html',
                providers: [
                    app.PackageService,
                    ng.http.HTTP_PROVIDERS
                ]
            })
        ];

        PackageComponent.prototype.all = function () {
            var self = this;

            this.packageService.all().subscribe(
                function (packages) {
                    self.packages = packages;
                }, function (error) {
                    self.error = error;
                }
            );
        };
        PackageComponent.prototype.ngOnInit = function () {
            this.all();
        };

        return PackageComponent;
    })();
})(window.app || (window.app = {}), window.ng);

; (function (app, ng) {
    document.addEventListener('DOMContentLoaded', function () {
        ng.platform.browser.bootstrap(app.PackageComponent);
    });
})(window.app || (window.app = {}), window.ng);