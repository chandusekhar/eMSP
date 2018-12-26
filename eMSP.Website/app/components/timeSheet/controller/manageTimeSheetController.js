'use strict';
angular.module('eMSPApp')
    .controller('manageTimeSheetController', manageTimeSheetController)
function manageTimeSheetController($scope, localStorageService, configJSON, apiCall, APP_CONSTANTS, DTOptionsBuilder) {

    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};   
    $scope.dtOptions = DTOptionsBuilder.newOptions().withPaginationType('full_numbers');
    
    $scope.compId = localStorageService.get('CurrentUser').companyId;
    
    $scope.TimeSheetList = [];    

    apiCall.get(APP_CONSTANTS.URL.TIMESHEET.GETALLTIMESHEETS)
        .then(function (data) {            
            if (data) {
                console.log(data);
                $scope.TimeSheetList = data;
            }
            $scope.showTimeSheet = true;
        });
}