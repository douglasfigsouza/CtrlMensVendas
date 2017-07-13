app.controller("GesCtrl", function ($scope, GesService) {
    getAllClientes();
    function getAllClientes()
    {
        var servCall = GesService.getClientes();
        servCall.then(function (d) {
            $scope.lstClientes = d;
            alert($scope.lstClientes);
        }, function (error) {
            alert("erro:"+error);
        });
    }
});