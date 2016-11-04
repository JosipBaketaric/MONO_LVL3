//Controller
angular.module('appModule').controller('getAllModelsController', ['$scope', '$http', getAllModelsController]);

//Controller method
function getAllModelsController($scope, $http) {
    //get all data
    $http.get('http://localhost:50704/api/model/getall').success(function (data) {
        $scope.data = data;
    })
    .error(function () {
        $scope.error = "An Error has occured while trying to get all models";
    });
}