'use strict';
angular.module('eMSPApp')
.controller('createCompanyController', createCompanyController)
function createCompanyController($scope,$state, localStorageService, configJSON, formAction, AppCoutries,apiCall,APP_CONSTANTS) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.refData = {};
    $scope.refData.countryList = AppCoutries;
    $scope.dataJSON.companyType = $scope.configJSON.companyType;
    $scope.edit = false;
    $scope.formAction = formAction;

    $scope.getStateList = function () {
        if ($scope.dataJSON.CountryID) {

            var param={"Id":$scope.dataJSON.CountryID}
            var apires = apiCall.post(APP_CONSTANTS.URL.APP.GETSTATEURL + $scope.dataJSON.CountryID, {});
            apires.then(function (data) {
                $scope.refData.stateList = data;
            });
        }
        
    }
   if ($scope.formAction == "Update") {
       $scope.edit = true;
       $scope.dataJSON = localStorageService.get('editCompanyData');
       $scope.getStateList();
   } 
  
    $scope.submit = function (form) {
        if (form.$valid) {
            
            if ($scope.formAction == "Update") {
                var res = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.UPDATEURL, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    alert("Data Updated Successfully");
                    
                            });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.CREATEURL, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    alert("Data Created Successfully");
                });
            }

           $state.go($scope.configJSON.successURL);
        }
        
    }
}