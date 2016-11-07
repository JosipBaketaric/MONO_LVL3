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

        if ($scope.updateData.Name == null || $scope.updateData.Abrv == null) {
            $window.alert("Please fill all fields");
        }
        else {
            var obj = {
                Name: $scope.updateData.Name,
                Abrv: $scope.updateData.Abrv,
                VehicleModelId: $scope.updateData.VehicleModelId
            };

            $http.put('/api/model/update', obj).success(function (data) {
                $window.alert("Updated!");
            })
            .error(function (data) {
                $window.alert("Error! " + data.Message);
            })
        }
    }

};