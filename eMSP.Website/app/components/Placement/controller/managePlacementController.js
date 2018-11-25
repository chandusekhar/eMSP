'use strict';
angular.module('eMSPApp')
    .controller('managePlacementController', managePlacementController)
function managePlacementController($scope, configJSON, PlacementList) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.refData = {};
    $scope.placementList = PlacementList;

    //var resAppointmentType = apiCall.get(APP_CONSTANTS.URL.PLACEMENT.GETALLPLACEDCANDIDATES);
    //resAppointmentType.then(function (data) {
    //    $scope.placementList = data;
    //    console.log(data);
    //});

    $scope.release = function () {
    };

}