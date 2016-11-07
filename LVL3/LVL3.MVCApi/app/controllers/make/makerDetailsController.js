//Details controller
angular.module('appModule').controller('makerDetailsController', ['$scope', '$http', '$stateParams', makerDetailsController]);

function makerDetailsController($scope, $http, $stateParams) {

    $http.get('/api/make/get?id=' + $stateParams.id).success(function (data) {
        $scope.make = data;
    })
    .error(function (data) {
        $window.alert("Error! " + data.Message);
    })

}