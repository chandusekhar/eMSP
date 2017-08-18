'use strict';
angular.module('eMSPApp')
    .controller("manageMSPBranchController", ['$scope', '$http', 'configJSON', 'formAction',
    function ($scope, $http, configJSON, formAction) {

        $scope.configJSON = configJSON.data;
        $scope.formAction = formAction;
        $scope.edit = $scope.formAction == "Update" ? true : false;
        $scope.submit = function () {
            if ($scope.form.valid) {
                alert("Form submitted");
            }
        }
    }]);