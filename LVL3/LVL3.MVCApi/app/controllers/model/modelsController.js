//Get all Controller
angular.module('appModule').controller('modelsController', ['$scope', '$http', '$window', '$state', modelsController]);

//Controller function
function modelsController($scope, $http, $window, $state) {   
    var models;
    var makers;

    $scope.getAllModels = function () {
        //get all data
        $http.get('/api/model/getall').success(function (data) {
            $scope.dataModel = data;
            models = $scope.dataModel;
        })
        .error(function (data) {
            $window.alert("Error! " + data.Message);
        });


    };

    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }
    
}//End of controller function
