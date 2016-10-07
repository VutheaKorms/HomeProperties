; (function (app, ng) {
    app.MenuComponent = (function () {
        function MenuComponent(menuService) {
            this.menuService = menuService;
            this.menus = [];
        }

        MenuComponent.parameters = [
            app.MenuService
        ];
        MenuComponent.annotations = [
            new ng.core.Menu({
                selector: '#menu-listing',
                templateUrl: 'api/menu/index.html',
                providers: [
                    app.MenuService,
                    ng.http.HTTP_PROVIDERS
                ]
            })
        ];

        MenuComponent.prototype.all = function () {
            var self = this;

            this.menuService.all().subscribe(
                function (menus) {
                    self.menus = menus;
                }, function (error) {
                    self.error = error;
                }
            );
        };
        MenuComponent.prototype.ngOnInit = function () {
            this.all();
        };

        return MenuComponent;
    })();
})(window.app || (window.app = {}), window.ng);

; (function (app, ng) {
    document.addEventListener('DOMContentLoaded', function () {
        ng.platform.browser.bootstrap(app.MenuComponent);
    });
})(window.app || (window.app = {}), window.ng);