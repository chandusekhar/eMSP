'use strict';
angular.module('eMSPApp')
    .controller('manageTimeSheetController', manageTimeSheetController)
function manageTimeSheetController($scope, localStorageService, configJSON, apiCall, APP_CONSTANTS, DTOptionsBuilder, CurrentStatusList, toaster) {
    $scope.config = localStorageService.get('pageSettings');
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
        });

    $scope.edit = function (data) {

    };

    $scope.approve = function (d) {
        var status = CurrentStatusList.filter(function (v) { if (v.Name === "Approved") return v; });
        var data = {
            ID: d.ID,
            StatusID: status[0].ID
        };
        apiCall.post(APP_CONSTANTS.URL.TIMESHEET.APPROVETIMESHEETS,data)
            .then(function (data) {
                if (data) {
                    toaster.success({ body: "TimeSheet Approved Successfully." });
                } else {
                    toaster.warning({ body: "TimeSheet Approved Not Successfull." });
                }
            });
    };

    $scope.reject = function (d) {
        var status = CurrentStatusList.filter(function (v) { if (v.Name === "Rejected") return v; });
        var data = {
            ID: d.ID,
            StatusID: status[0].ID
        };
        apiCall.post(APP_CONSTANTS.URL.TIMESHEET.REJECTTIMESHEETS, data)
            .then(function (data) {
                if (data) {
                    toaster.success({ body: "TimeSheet Rejected Successfully." });
                } else {
                    toaster.warning({ body: "TimeSheet Rejected Not Successfully." });
                }
            });
    };
}