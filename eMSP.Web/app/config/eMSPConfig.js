angular.module("eMSPApp").
    config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    
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
        .when('/dashboard', {
            templateUrl: 'app/components/dashboard/dashboardView.html',
            controller: 'dashboardController',
            data: {
                meta: {
                    'title': 'Dashboard Page'
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
            templateUrl: 'app/components/accounts/forgotPassword/forgotPasswordView.html',
            controller: 'forgotPasswordController',
            data: {
                meta: {
                    'title': 'Forgot Password'
                }
            }
        })
        
        .otherwise({
            redirectTo: '/home'
        });
}]);
//Company Routes
angular.module("eMSPApp.Company", ['ui.router']).config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/home');
    $stateProvider
        .state("SearchMSP", {
            url: '/Company/SearchMSP',
            templateUrl: 'app/components/Company/View/searchCompany.html',
            controller: 'searchCompanyController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Company/Config/SearchMSP.json").success(function (data) { return data; });
                }
            }
        })
    .state("SearchSuppliers", {
        url: '/Company/SearchSuppliers',
        templateUrl: 'app/components/Company/View/searchCompany.html',
        controller: 'searchCompanyController',
        resolve: {
            configJSON: function ($http) {
                return $http.get("app/components/Company/Config/SearchSuppliers.json").success(function (data) { return data; });
            }
        }
    })
    .state("SearchCustomers", {
        url: '/Company/SearchCustomers',
        templateUrl: 'app/components/Company/View/searchCompany.html',
        controller: 'searchCompanyController',
        resolve: {
            configJSON: function ($http) {
                return $http.get("app/components/Company/Config/SearchCustomers.json").success(function (data) { return data; });
            }
        }
    })
    .state("CreateMSP", {
        url: '/Company/CreateMSP',
        templateUrl: 'app/components/Company/View/createCompany.html',
        controller: 'createCompanyController',
        resolve: {
            configJSON: function ($http) {
                return $http.get("app/components/Company/Config/CreateMSP.json").success(function (data) { return data; });
            }
        }
    })
    .state("CreateSupplier", {
        url: '/Company/CreateSupplier',
        templateUrl: 'app/components/Company/View/createCompany.html',
        controller: 'createCompanyController',
        resolve: {
            configJSON: function ($http) {
                return $http.get("app/components/Company/Config/CreateSupplier.json").success(function (data) { return data; });
            }
        }
    })
    .state("CreateCustomer", {
        url: '/Company/CreateCustomer',
        templateUrl: 'app/components/Company/View/createCompany.html',
        controller: 'createCompanyController',
        resolve: {
            configJSON: function ($http) {
                return $http.get("app/components/Company/Config/CreateCustomer.json").success(function (data) { return data; });
            }
        }
    })
    .state("EditMSP", {
        url: '/Company/EditMSP',
        templateUrl: 'app/components/Company/View/createCompany.html',
        controller: 'createCompanyController',
        resolve: {
            configJSON: function ($http) {
                return $http.get("app/components/Company/Config/CreateMSP.json").success(function (data) { return data; });
            }
        }
    })
    .state("EditSupplier", {
        url: '/Company/EditSupplier',
        templateUrl: 'app/components/Company/View/createCompany.html',
        controller: 'createCompanyController',
        resolve: {
            configJSON: function ($http) {
                return $http.get("app/components/Company/Config/CreateSupplier.json").success(function (data) { return data; });
            }
        }
    })
    .state("EditCustomer", {
        url: '/Company/EditCustomer',
        templateUrl: 'app/components/Company/View/createCompany.html',
        controller: 'createCompanyController',
        resolve: {
            configJSON: function ($http) {
                return $http.get("app/components/Company/Config/CreateCustomer.json").success(function (data) { return data; });
            }
        }
    })

});


//var serviceBase = 'http://localhost:26264/';
var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';
eMSPApp.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

eMSPApp.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

eMSPApp.run(['authService', function (authService) {
    authService.fillAuthData();
}]);
