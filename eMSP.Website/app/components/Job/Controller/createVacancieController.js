'use strict';
angular.module('eMSPApp')
.controller('createVacancieController', createVacancieController)
function createVacancieController($scope, $state, localStorageService, configJSON, formAction, apiCall, APP_CONSTANTS) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.cdataJSON = {};
    $scope.refData = {};    
    $scope.cdataJSON.companyType = $scope.configJSON.companyType;
    $scope.cdataJSON.companyName = $scope.configJSON.companyName;
    $scope.dataJSON.mspId = localStorageService.get('editCompanyData') ? localStorageService.get('editCompanyData').id : 0;
    $scope.edit = false;
    $scope.formAction = formAction;   

    if ($scope.formAction === "Update") {        
        $scope.edit = true;
        $scope.dataJSON = localStorageService.get('vacancyData');
    }

    var apires = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.SEARCHURL, $scope.cdataJSON);
    apires.then(function (data) {
        $scope.refData.customerList = data;
        
        if ($scope.formAction === "Update") {
            $scope.dataJSON.customerId = $scope.dataJSON.customerId.toString();
        }
    });

    var apivacancyType = apiCall.post(APP_CONSTANTS.URL.VACANCY.GETACTIVEMSPVACANCYTYPEURL, $scope.dataJSON);
    apivacancyType.then(function (data) {        
        $scope.refData.vacancyTypes = data;

        if ($scope.formAction === "Update") {
            $scope.dataJSON.vacancyType = $scope.dataJSON.vacancyType.toString();
        }
    });

    $scope.getUserList = function () {        
        $scope.cdataJSON.id = $scope.dataJSON.customerId;
        var apires = apiCall.post(APP_CONSTANTS.URL.USER.GETALLUSERSURL, $scope.cdataJSON);
        apires.then(function (data) {            
            $scope.refData.usersList = data;  
        });
    }

    $scope.submit = function (form) {        
        $scope.dataJSON.createdUserID = "afcf8230-7878-4e1d-a550-532fd10769ae";
        $scope.dataJSON.updatedUserID = "afcf8230-7878-4e1d-a550-532fd10769ae";
        if (form.$valid) {
            if ($scope.formAction === "Update") {
                var resUpdate = apiCall.post(APP_CONSTANTS.URL.VACANCY.UPDATEBVACANCY, $scope.dataJSON);
                resUpdate.then(function (data) {
                    $scope.dataJSON = data;
                    alert("Data Updated Successfully");
                    
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.VACANCY.CREATEVACANCY, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    alert("Data Created Successfully");
                });
            }
            $state.go($scope.configJSON.successURL);            
        }
    }
}