'use strict';
angular.module('eMSPApp')
    .controller('managePlacementController', managePlacementController)
function managePlacementController($scope, configJSON, APP_CONSTANTS, apiCall, toaster) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.refData = {};
    $scope.placementList = [];        
    
    var resAppointmentType = apiCall.get(APP_CONSTANTS.URL.APPOINTMENT.GETALLAPPOINTMENTTYPEURL);
    resAppointmentType.then(function (data) {
        $scope.placementList = data;        
    });
    
}