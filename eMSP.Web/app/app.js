var module = angular.module("eMSPApp", ["ngRoute", "eMSPApp.Controllers"])

.controller('ctrlMain', ['$scope', '$http', function ($scope, $http) {
    $('html,body').scrollTop(0);
}]);

