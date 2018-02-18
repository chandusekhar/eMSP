var apiBaseURL = 'http://localhost:50001/';


var serviceBase = 'http://localhost:50001/';
//var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';
angular
    .module('eMSPApp').constant('ngAuthSettings', {
        apiServiceBaseUri: serviceBase,
        clientId: 'ngAuthApp'
    });

angular
    .module('eMSPApp').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptorService');
    });

angular
    .module('eMSPApp').run(['authService', function (authService) {
        authService.fillAuthData();
        authService.setPermission();
    }]);