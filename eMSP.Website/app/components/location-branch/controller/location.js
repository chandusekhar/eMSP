'use strict';
angular.module('eMSPApp').controller("mspLocationController", ['$scope', '$http', function ($scope, $http) {
    $scope.locationData = {
        LocationName: "",
        StreetLine1: "",
        StreetLine2: "",
        City: "",
        StateID: "",
        CountryID: "",
        IsActive: ""
    };

}]);