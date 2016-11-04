//Delete controller
angular.module('appModule').controller('makeDeleteController', ['$scope', '$http', '$stateParams', '$window', '$state', makeDeleteController]);

function makeDeleteController($scope, $http, $stateParams, $window, $state) {

    $scope.delete = function (id) {
        if ($window.confirm('Are you sure?')) {
            $http.delete('/api/make/delete?id=' + id).success(function (data) {
                $scope.response = data;
                $scope.getAllMakers();
            })
        };
        //Refresh data  (had to do it twice to work :P)
        $scope.getAllMakers();

    }

}