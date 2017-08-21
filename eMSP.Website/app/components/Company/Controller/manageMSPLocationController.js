'use strict';
angular.module('eMSPApp')
    .controller("manageMSPLocationController", ['$scope', '$http', 'configJSON', 'formAction',
        function ($scope, $http, configJSON, formAction) {           
            
            $scope.configJSON = configJSON.data;
            $scope.formAction = formAction;
            $scope.edit = $scope.formAction == "Update" ? true : false;
            $scope.submit = function () {
                debugger;
                if ($scope.formLocation.$valid) {
                    console.log($scope.formLocation.locationData);
                    alert("Form submitted");
                }
            }

            $scope.locationData = {
                LocationName: "",
                StreetLine1: "",
                StreetLine2: "",
                City: "",
                State: "",
                Country: "",
                IsActive: ""
            };

        }]);