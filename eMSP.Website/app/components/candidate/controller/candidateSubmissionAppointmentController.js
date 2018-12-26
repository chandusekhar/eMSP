'use strict';
angular.module('eMSPApp')
    .controller('candidateSubmissionAppointmentController', candidateSubmissionAppointmentController)
function candidateSubmissionAppointmentController($scope, $state, $uibModal, localStorageService, configJSON, apiCall, APP_CONSTANTS, toaster, DTOptionsBuilder) {
    $scope.config = localStorageService.get('pageSettings');
    $scope.vacancyData = localStorageService.get('vacancyData') ? localStorageService.get('vacancyData') : undefined;
    $scope.dtOptions = DTOptionsBuilder.newOptions().withPaginationType('full_numbers');

    var apires = apiCall.post(APP_CONSTANTS.URL.CANDIDATESUBMISSIONURL.GETURL + $scope.vacancyData.Vacancy.id, { "VacancyId": $scope.vacancyData.Vacancy.id });
    apires.then(function (data) {
        $scope.resCandidateSubbmitedLst = data;
    });



}

