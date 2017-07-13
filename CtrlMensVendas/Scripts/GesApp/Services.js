app.service("GesService", function ($http) {
    this.getClientes = function () {
        var url = "api/teste";
        return $http.get(url).then(function (response) {
            alert(response);
            return response.data;
        });
    }
});