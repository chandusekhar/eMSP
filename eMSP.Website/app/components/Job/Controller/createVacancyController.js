'use strict';
angular.module('eMSPApp')
.controller('createVacancyController', createVacancyController)
function createVacancyController($scope, $state, localStorageService, configJSON, formAction, apiCall, APP_CONSTANTS) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.refData = {};    
    $scope.dataJSON.companyType = $scope.configJSON.companyType;
    $scope.edit = false;
    $scope.formAction = formAction;
    
    if ($scope.formAction == "Update") {        
        $scope.edit = true;
        $scope.dataJSON = localStorageService.get('editVacancyData');
    }

    var apires = apiCall.post(APP_CONSTANTS.URL.APP.GETSTATEURL + "3", {});
    apires.then(function (data) {
        $scope.refData.stateList = data;
        console.log(data);
    });

    $scope.submit = function (form) {
        if (form.$valid) {
            if ($scope.formAction == "Update") {
                var res = apiCall.post(APP_CONSTANTS.URL.VACANCY.UPDATEURL, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    alert("Data Updated Successfully");

                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.VACANCY.CREATEURL, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    alert("Data Created Successfully");
                });
            }

            $state.go($scope.configJSON.successURL);
        }

    }
}