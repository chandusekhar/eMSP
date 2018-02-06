'use strict';
angular.module('eMSPApp').factory('mspLocationService', ['$http', '$q', 'localStorageService', 'ngAuthSettings', function ($http, $q, localStorageService, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    var mspRegServiceFactory = {}; 

    var _saveRegistration = function (registration) {        
        //change API
        return $http.post(serviceBase + 'api/mspdetails/register', registration).then(function (response) {
            return response;
        });
    };    

    mspRegServiceFactory.saveRegistration = _saveRegistration;

    return mspRegServiceFactory;
}]);