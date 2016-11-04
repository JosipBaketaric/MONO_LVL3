//Details controller
angular.module('appModule').controller('modelDetailsController', ['$scope', '$http', '$stateParams', modelDetailsController]);

function modelDetailsController($scope, $http, $stateParams) {

    $http.get('/api/model/get?id=' + $stateParams.id).success(function (data) {
        $scope.model = data;
    });

}