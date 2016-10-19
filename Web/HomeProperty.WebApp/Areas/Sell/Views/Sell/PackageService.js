; (function (app, ng) {
    app.PackageService = (function () {
        var PackageService = function (http) {           // this line changed
            this.url = '/Home/GetPackages';
            this.http = http;                            // this line added
        };

        PackageService.parameters = [                   // this line added
            ng.http.Http // this will be passed as arg in the constructor
        ];                                               // this line added

        PackageService.prototype.all = function () {
            return this.http.get(this.url)               // this line changed
                .map(function (response) {
                    return response.json();
                })
                .catch();
        };

        return PackageService;
    })();
})(window.app || (window.app = {}), window.ng);