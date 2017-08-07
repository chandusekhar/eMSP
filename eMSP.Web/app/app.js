var module = angular.module("eMSPApp", ["ngRoute", "eMSPApp.Controllers"])

.controller('ctrlMain', ['$scope', '$http', function ($scope, $http) {

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
                    'title': 'Home Page'
                }
            }
        })        
        .when('/login', {
            templateUrl: 'app/components/accounts/login/loginView.html',
            controller: 'loginController',
            data: {
                meta: {
                    'title': 'Login Page'
                }
            }
        })
        .when('/registration', {
            templateUrl: 'app/components/accounts/registration/registrationView.html',
            controller: 'registrationController',
            data: {
                meta: {
                    'title': 'Registration'
                }
            }
        })
        .when('/forgot-password', {
            templateUrl: 'app/components/accounts/login/forgotPasswordView.html',
            controller: 'forgotPasswordController',
            data: {
                meta: {
                    'title': 'Forgot Password'
                }
            }
        })
        .when('/dashboard', {
            templateUrl: 'app/components/home/homeView.html',
            controller: 'homeController',
            data: {
                meta: {
                    'title': 'Home Page'
                }
            }
        })
        .otherwise({
            redirectTo: '/home'
        });
}]);

