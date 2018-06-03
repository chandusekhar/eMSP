'use strict';
angular.module('eMSPApp')
    .controller('manageAppointmentTypeController', manageAppointmentTypeController)
function manageAppointmentTypeController($scope, $state, localStorageService, configJSON, APP_CONSTANTS, apiCall, $filter, toaster) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.refData = {};
    $scope.appointmentTypeList = [];
    $scope.formAction = "Create";
    $scope.refData.submitted = false;
    
    var resAppointmentType = apiCall.get(APP_CONSTANTS.URL.APPOINTMENT.GETALLAPPOINTMENTTYPEURL);
    resAppointmentType.then(function (data) {
        $scope.appointmentTypeList = data;
        console.log(data);
    });

    $scope.create = function () {
        $scope.refData.submitted = false;
        $scope.edit = false;
        $scope.formAction = "Create";
        $scope.search = false;
        $scope.dataJSON = {};
    }

    $scope.reset = function () {
        $scope.edit = false;
        $scope.formAction = "Create";
        $scope.search = true;
    }

    $scope.update = function (model) {
        $scope.edit = true;
        $scope.formAction = "Update";
        $scope.search = false;
        $scope.dataJSON = model;
    }

    $scope.submit = function (form) {
        $scope.refData.submitted = true;
        if (form.$valid) {
            if ($scope.formAction == "Update") {
                var res = apiCall.post(APP_CONSTANTS.URL.APPOINTMENT.UPDATEAPPOINTMENTTYPEURL, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    toaster.warning({ body: "Question Updated Successfully." });
                    $scope.search = true;
                    $state.reload();
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.APPOINTMENT.CREATEAPPOINTMENTTYPEURL, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    toaster.success({ body: "Question Created Successfully." });
                    $scope.appointmentTypeList.unshift(data);
                    $scope.search = true;
                });
            }
        }
    }

    $scope.toggleActive = function (model) {
        var res = apiCall.post(APP_CONSTANTS.URL.APPOINTMENT.UPDATEAPPOINTMENTTYPEURL, model);
        res.then(function (data) {
            toaster.warning({ body: "Question Updated Successfully." });
        });
    }

    $scope.reset();
}