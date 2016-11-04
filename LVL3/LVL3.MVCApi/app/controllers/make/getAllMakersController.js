//Controller
angular.module('appModule').controller('getAllMakersController', ['$scope', '$http', getAllMakersController]);

//Controller method
function getAllMakersController($scope, $http) {
    //get all data
    $http.get('http://localhost:50704/api/make/getall').success(function (data) {
        $scope.data = data;
    })
    .error(function () {
        $scope.error = "An Error has occured while trying to get all makers";
    });
}