
//Create the module and include ngRoute for routing
var appModule = angular.module('appModule', ['ui.router']);

//configure routes
appModule.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/make');

    $stateProvider
    .state('make', {
        url: '/make',
        templateUrl: 'app/views/make/index.html'
    })
    .state('model', {
        url: '/model',
        templateUrl: 'app/views/model/index.html'
    })

});