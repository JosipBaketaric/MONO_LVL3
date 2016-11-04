//Get all Controller
angular.module('appModule').controller('modelsController', ['$scope', '$http', '$window', '$state', modelsController]);

//Controller method
function modelsController($scope, $http, $window, $state) {

    $scope.getAllModels = function () {
        //get all data
        $http.get('/api/model/getall').success(function (data) {
            $scope.data = data;
        })
        .error(function () {
            $scope.error = "An Error has occured while trying to get all models";
        });
    };
    
}
