//Make add controller
angular.module('appModule').controller('makeUpdateController', ['$scope', '$http', '$stateParams', '$window', '$state', makeUpdateController]);

function makeUpdateController($scope, $http, $stateParams, $window, $state) {
    $scope.updateInit = function () {
        var id = $stateParams.maker;
        $http.get('/api/make/get?id=' + id).success(function (data) {
            $scope.updateData = data;
        });
    }

    $scope.UpdateMake = function () {
       
        if ($scope.Name == null || $scope.Abrv == null) {
            $window.alert("Please fill all fields");
        }
        else {
            var obj = {
                Name: $scope.Name,
                Abrv: $scope.Abrv,
                VehicleMakeId: $scope.updateData.VehicleMakeId
            };

            $http.put('/api/make/update', obj).success(function (data) {
                $window.alert("Updated!");
            });
        }
    }

};