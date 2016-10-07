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