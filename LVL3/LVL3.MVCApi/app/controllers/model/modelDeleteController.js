//Delete controller
angular.module('appModule').controller('modelDeleteController', ['$scope', '$http', '$stateParams', '$window', '$state', modelDeleteController]);

function modelDeleteController($scope, $http, $stateParams, $window, $state) {

    $scope.delete = function (id) {
        if ($window.confirm('Are you sure?')) {
            $http.delete('/api/model/delete?id=' + id).success(function (data) {
                $scope.response = data;
                $scope.getAllModels();
            })
            .error(function (data) {
                $window.alert("Error! " + data.Message);
            })
        };
        //Refresh data  (had to do it twice to work :P)
        $scope.getAllModels();
    }

}