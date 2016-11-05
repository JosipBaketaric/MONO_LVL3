//Details controller
angular.module('appModule').controller('modelDetailsController', ['$scope', '$http', '$stateParams', modelDetailsController]);

function modelDetailsController($scope, $http, $stateParams) {

    $http.get('/api/model/get?id=' + $stateParams.id).success(function (data) {
        $scope.model = data;

        $scope.modelDetailsMakerName(data.VehicleMakeId);
    });

    $scope.modelDetailsMakerName = function (id) {
        $http.get('/api/make/get?id=' + id).success(function (data) {
            $scope.model.VehicleMakeName = data.Name;
        });
    };

}