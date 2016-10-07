; (function (app, ng) {
    app.CommandService = (function () {
        var CommandService = function (http) {           // this line changed
            this.url = '/Home/MainNavigationMenu';
            this.http = http;                            // this line added
        };

        CommandService.parameters = [                   // this line added
            ng.http.Http // this will be passed as arg in the constructor
        ];                                               // this line added

        CommandService.prototype.all = function () {
            return this.http.get(this.url)
                 .map(res => res.json())
                 //.subscribe(users => this.users = users);

                // this line changed
                //.map(function (response) {
                //    return response.json();
                    //response = data;
                    //return response.json().data;
                    //return response.json().data;
                //})
              
               
        };

        return CommandService;
    })();
})(window.app || (window.app = {}), window.ng);
