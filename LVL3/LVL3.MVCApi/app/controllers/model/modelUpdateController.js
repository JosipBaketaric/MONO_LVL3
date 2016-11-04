//Make add controller
angular.module('appModule').controller('modelUpdateController', ['$scope', '$http', '$stateParams', '$window', '$state', modelUpdateController]);

function modelUpdateController($scope, $http, $stateParams, $window, $state) {
    $scope.updateInit = function () {
        var id = $stateParams.model;
        $http.get('/api/model/get?id=' + id).success(function (data) {
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
                VehicleModelId: $scope.updateData.VehicleModelId
            };

            $http.put('/api/model/update', obj).success(function (data) {
                $window.alert("Updated!");
            });
        }
    }

};