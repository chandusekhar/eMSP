'use strict';
angular.module('eMSPApp')
    .controller('appointmentController', appointmentController)
    .controller('manageAppointmentController', manageAppointmentController)

function manageAppointmentController($scope, $state, $filter, localStorageService, ngAuthSettings, apiCall, $uibModal, APP_CONSTANTS, $http, configJSON, toaster, AppointmentList, AppUsers, AppAppointmentTypes, AppAppointmentStatus) {
    $scope.config = localStorageService.get('pageSettings');
    $scope.configJSON = configJSON.data;
    $scope.refData = {};
    $scope.refData.appointmentTypeList = AppAppointmentTypes;
    $scope.refData.appointmentStatusList = AppAppointmentStatus;
    $scope.refData.usersList = AppUsers;
    $scope.dataJSON = {};
    $scope.appointmentList = AppointmentList;
    $scope.AppointmentSlot = {};

    $scope.model = function (model, data) {

        $scope.dataJSON = {};

        if (model) {
            $scope.editform = true;
            $scope.udataJSON = data;
            $scope.formAction = "Update";
        }
        else {
            $scope.formAction = "Create";
            $scope.editform = false;
        }

        var modalInstance = $uibModal.open({
            templateUrl: 'app/components/Appointment/view/appointment.html',
            scope: $scope,
            controller: 'appointmentController',
            windowClass: 'animated slideInRight'
        });
    }

    $scope.date = function (datestr, dateFormat) {
        return $filter('date')(new Date(ele), dateFormat);
    }
}

function appointmentController($scope, $state, localStorageService, ngAuthSettings, apiCall, APP_CONSTANTS, $http, toaster, $uibModalInstance) {
    $scope.config = localStorageService.get('pageSettings');
    $scope.time = new Date().toLocaleTimeString();
    $scope.create = false;
    $scope.dataJSON.Slots = [];
    $scope.dataJSON.UserComments = [];
    $scope.dataJSON.Users = [];

    $scope.LoadUsersData = function () {
        angular.forEach($scope.dataJSON.Users, function (v, k) {
            angular.forEach($scope.refData.usersList, function (value, key) {
                if (value.userId === v.UserID) {
                    $scope.dataJSON.Users[k] = value;
                }
            });
        });
    }    

    $scope.submit = function (form) {

        $scope.dataJSON.CandidateSubmissionID = localStorageService.get('createSubmissionId');//localStorageService.get('supplierId');

        if (form.$valid) {
            var suc = false;
            if ($scope.editform) {
                var res = apiCall.post(APP_CONSTANTS.URL.APPOINTMENT.UPDATEAPPOINTMENTURL, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    toaster.warning({ body: "Data Updated Successfully." });
                    $uibModalInstance.close();
                    
                });
            }
            else {
                var resn = apiCall.post(APP_CONSTANTS.URL.APPOINTMENT.CREATEAPPOINTMENTURL, $scope.dataJSON);
                resn.then(function (data) {
                    $scope.dataJSON = data;
                    toaster.success({ body: "Data Created Successfully." });
                    $uibModalInstance.close();
                });
            }
        }
    }

    $scope.fnAddEditSlot = function (flag, index) {

        if (!flag) {
            $scope.AppointmentSlot = $scope.dataJSON.Slots[index];
            $scope.AppointmentSlot.index = index;
            $scope.dataJSON.dateRange = { startDate: new Date($scope.AppointmentSlot.StartDate), endDate: new Date($scope.AppointmentSlot.EndDate) };
            $scope.slotEdit = true;
        }
        else {
            $scope.slotEdit = false;
        }
        $scope.create = true;
    }

    if ($scope.editform) {
        $scope.dataJSON = $scope.udataJSON;
        $scope.dataJSON.AppintmentTypeID = $scope.udataJSON.AppintmentTypeID.toString();
        $scope.dataJSON.AppointmentStatusID = $scope.udataJSON.AppointmentStatusID.toString();
        $scope.LoadUsersData();
        $scope.fnAddEditSlot(false, 0);
    }       

    $scope.addEditSlot = function (form, create) {

        if (form.$valid) {
            if ($scope.editform) {
                if (create) {
                    $scope.AppointmentSlot.AppintmentID=$scope.dataJSON.ID
                    $scope.AppointmentSlot.StartDate = $scope.dataJSON.dateRange.startDate;
                    $scope.AppointmentSlot.EndDate = $scope.dataJSON.dateRange.endDate;
                    $scope.create = false;
                   
                    var resn = apiCall.post(APP_CONSTANTS.URL.APPOINTMENT.SLOTADDAPPOINTMENTURL, $scope.AppointmentSlot);
                    resn.then(function (data) {
                        $scope.dataJSON.Slots.push($scope.AppointmentSlot);
                    });

                }
                else {

                    $scope.AppointmentSlot = $scope.dataJSON.Slots[$scope.AppointmentSlot.index];
                    $scope.create = false;
                    $scope.AppointmentSlot.StartDate = $scope.dataJSON.dateRange.startDate;
                    $scope.AppointmentSlot.EndDate = $scope.dataJSON.dateRange.endDate;
                    var resn = apiCall.post(APP_CONSTANTS.URL.APPOINTMENT.SLOTUPDATEAPPOINTMENTURL + $scope.AppointmentSlot.ID, $scope.AppointmentSlot);
                    resn.then(function (data) {
                        
                    });
                }
            }
            else {
                if (create) {

                    $scope.AppointmentSlot.StartDate = $scope.dataJSON.dateRange.startDate;
                    $scope.AppointmentSlot.EndDate = $scope.dataJSON.dateRange.endDate;
                    $scope.create = false;
                    $scope.dataJSON.Slots.push($scope.AppointmentSlot);
                }
                else {

                    $scope.AppointmentSlot = $scope.dataJSON.Slots[$scope.AppointmentSlot.index];
                    $scope.create = false;
                    $scope.AppointmentSlot.StartDate = $scope.dataJSON.dateRange.startDate;
                    $scope.AppointmentSlot.EndDate = $scope.dataJSON.dateRange.endDate;
                }
            }
        }

        $scope.AppointmentSlot = {};
        $scope.dataJSON.dateRange = {};
    }

    $scope.validateEndDate = function (form1) {
        if ($scope.AppointmentSlot.EndDate >= $scope.AppointmentSlot.EndDate) {
            form1.$valid = false;
            form1.EndDate.$error.custom = true;
        }
    }
    $scope.cancel = function () {
        $scope.create = false;
        $scope.AppointmentSlot = {};
    }
    $scope.fnRemoveSlot = function (index) {
        $scope.dataJSON.Slots.splice(index, 1);
    }

    $scope.close = function () {
        $uibModalInstance.close();
    }
}

angular.module('eMSPApp').filter('stringToDate', function ($filter) {
    return function (ele, dateFormat) {
        return $filter('date')(new Date(ele), dateFormat);
    }
})