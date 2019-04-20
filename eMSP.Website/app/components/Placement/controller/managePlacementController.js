'use strict';
angular.module('eMSPApp')
    .controller('managePlacementController', managePlacementController)
function managePlacementController($scope, configJSON, PlacementList, apiCall, APP_CONSTANTS, $state) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.refData = {};
    $scope.placementList = PlacementList;

    $scope.release = function (data) {
        var resAppointmentType = apiCall.delete(APP_CONSTANTS.URL.PLACEMENT.DELETECANDIDATEPLACEMENT + data.PlacementId, { 'PlacementId': data.PlacementId});
        resAppointmentType.then(function (data) {
            $state.reload();
        });
    };

}