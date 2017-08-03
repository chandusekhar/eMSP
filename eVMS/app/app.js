var module = angular.module("eVMSApp", ["ngRoute", "eVMSApp.Controllers"])

.controller('ctrlMain', ['$scope', '$http',  function ($scope, $http) {  

    $('html,body').scrollTop(0);
}]);


module.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {    
    $locationProvider.html5Mode(true);
    $routeProvider
        .when('/home', {
            templateUrl: 'app/components/home/homeView.html',
            controller: 'homeController',
            data: {
                meta: {
                    'title': 'Homepage'                    
                }
            }
        })             
        .when('/dashboard', {
            templateUrl: 'app/components/home/homeView.html',
            controller: 'homeController',
            data: {
                meta: {
                    'title': 'Homepage'
                }
            }
        })
        .otherwise({
            redirectTo: '/home'
        });
}]);

