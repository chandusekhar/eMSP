'use strict';
angular.module('eMSPApp')
    .controller("manageMSPLocationController", ['$scope', '$http', 'configJSON', 'formAction',
        function ($scope, $http, configJSON, formAction) {
            debugger;
            console.log(configJSON.data);
            $scope.configJSON = configJSON.data;
            $scope.formAction = formAction;
            $scope.edit = $scope.formAction == "Update" ? true : false;
            $scope.submit = function () {
                if ($scope.form.valid) {
                    alert("Form submitted");
                }
            }

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