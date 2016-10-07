; (function (app, ng) {
    app.MenuService = (function () {
        var MenuService = function (http) {           // this line changed
            this.url = '/Home/MainNavigationMenu';
            this.http = http;                            // this line added
        };

        MenuService.parameters = [                   // this line added
            ng.http.Http // this will be passed as arg in the constructor
        ];                                               // this line added

        MenuService.prototype.all = function () {
            return this.http.get(this.url)               // this line changed
                .map(function (response) {
                    return response.json().data;
                })
                .catch();
        };

        return MenuService;
    })();
})(window.app || (window.app = {}), window.ng);

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
            new ng.core.Component({
                selector: '#menu-listing',
                templateUrl: '/Scripts/Angular2/Agent/api/menu/index.html',
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