'use strict';
angular.module('eMSPApp').controller("logoutController", ['$scope','$location', 'authService', function ($scope,$location, authService) {

    $scope.logOut = function () {        
        authService.logOut();
        $location.path('/login');
    };

}]);