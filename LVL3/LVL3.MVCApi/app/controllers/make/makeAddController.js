//Make add controller
angular.module('appModule').controller('makeAddController', ['$scope', '$http', '$stateParams', '$window', '$state', makeAddController]);

function makeAddController($scope, $http, $stateParams, $window, $state) {
    $scope.AddMake = function () {

        if ($scope.Name == null || $scope.Abrv == null) {
            $window.alert("Please fill all fields");
        }
        else {
            var obj = {
                Name: $scope.Name,
                Abrv: $scope.Abrv
            };

            $http.post('/api/make/add', obj).success(function (data) {
                $scope.response = data;
                console.log(data);
            });

            //Clear model and form
            $scope.makeAddForm.$setPristine(true);
            $scope.Name = null;
            $scope.Abrv = null;
        }
    }
   
};