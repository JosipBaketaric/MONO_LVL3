
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
    .state('make/details/:id', {
        url: '/make/details/:id',
        templateUrl: 'app/views/make/details.html'
    })
    .state('make/add', {
        url: '/make/add',
        templateUrl: 'app/views/make/add.html'
    })


        //Model
    .state('model', {
        url: '/model',
        templateUrl: 'app/views/model/index.html'
    })
    .state('model/details/:id', {
        url: '/model/details/:id',
        templateUrl: 'app/views/model/details.html'
    })
    .state('model/add', {
        url: '/model/add',
        templateUrl: 'app/views/model/add.html'
    })

});