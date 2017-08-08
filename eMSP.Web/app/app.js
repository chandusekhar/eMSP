var eMSPApp = angular.module("eMSPApp", ["ngRoute", "LocalStorageModule"])

.controller('ctrlMain', ['$scope', '$http', function ($scope, $http) {
    $('html,body').scrollTop(0);
}]);

