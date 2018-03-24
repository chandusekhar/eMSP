//'use strict';
angular.module('eMSPApp').factory('apiCall', ['$http', '$q', 'localStorageService', 'ngAuthSettings', function ($http, $q, localStorageService, ngAuthSettings) {

    var addHeader = function () {

    }
    var apicall = function (type, url, param) {
        var apiUrl = ngAuthSettings.apiServiceBaseUri + url;

       return $http({            
            url: apiUrl,
            method: type,
            data: param            
       }).success(function (result) {
            return result;
        })
        .error(function (error, status, x, y, z) {
            console.log('errror status: ', status);
            console.log('error object: ', error);
        });

            
    }
    return {
        get: function (url, param) {            
            return apicall('GET', url, param).then(function (data) { return data.data });
        },
        post: function (url, param) {
            return apicall('POST', url, param).then(function (data) { return data.data });
        }
    };
}]);