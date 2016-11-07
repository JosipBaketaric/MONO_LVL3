//Controller
angular.module('appModule').controller('makersController', ['$scope', '$http', '$window', makersController]);

//Controller method
function makersController($scope, $http, $window) {

    var dataSFP;
    var sortingOrder = 'name'; //default sort
        //get all data
        $scope.getAllMakers = function () {
            $http.get('/api/make/getall').success(function (data) {
                $scope.data = data;
            })
        .error(function (data) {
            $scope.error = "An error has occured while trying to get all makers";
            $window.alert("Error! " + data.Message);
        });
    };
    

    $scope.delete = function (id) {
        console.log("Maker delete clicked! id=" + id);
        if ($window.confirm('Are you sure?')) {
            $http.delete('/api/make/delete?id=' + id).success(function (data) {
                $scope.response = data;
            })
            .error(function (data) {
                $window.alert("Error! " + data.Message);
            })
        }       
    };

    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }

}