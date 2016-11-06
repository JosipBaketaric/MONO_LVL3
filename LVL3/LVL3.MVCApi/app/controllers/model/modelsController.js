//Get all Controller
angular.module('appModule').controller('modelsController', ['$scope', '$http', '$window', '$state', modelsController]);

//Controller function
function modelsController($scope, $http, $window, $state) {   
    var models;
    var makers;

    $scope.getAllModels = function () {
        console.log("get all models");
        //get all data
        $http.get('/api/model/getall').success(function (data) {
            $scope.dataModel = data;
            models = $scope.dataModel;

            //call fetchMakers
            $scope.fetchMakers();
        })
        .error(function () {
            $scope.error = "An Error has occured while trying to get all models";
        });


        $scope.fetchMakers = function () {
            $http.get('/api/make/getall').success(function (data) {
                makers = data;

                //call injectMakerName
                $scope.injectMakerName();
            })
        }


         
        $scope.injectMakerName = function () {
            //loop
            //add maker name to model object
            for (var i = 0; i < models.length; i++) {   //for each model find his maker
                for (var j = 0; j < makers.length; j++) {
                    if (models[i].VehicleMakeId == makers[j].VehicleMakeId) {
                        $scope.dataModel[i].VehicleMakeName = makers[j].Name;
                        break;
                    }
                }
            }//end of for
            console.log("inject maker name");

        };//End of function

    };

    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }
    
}//End of controller function
