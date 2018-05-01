'use strict';
angular.module('eMSPApp')
    .controller('manageCandidateSubmissionController', manageCandidateSubmissionController)
    .controller('submitedCandidateListController', submitedCandidateListController)
function manageCandidateSubmissionController($scope, $state, localStorageService, configJSON, APP_CONSTANTS, apiCall, $uibModal, $compile) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.searchResults = [];
    $scope.refData = {};
    $scope.jobData = {};

    var apires = apiCall.post(APP_CONSTANTS.URL.VACANCY.GETVACANCIESURL, $scope.dataJSON);
    apires.then(function (data) {
        $scope.resVacancie = data;
    });    

    $scope.showCandidates = function (data) {
        $scope.jobData = data;
        $("table tbody #submittedCandidates").remove();
        $("table tbody #row_" + data.Vacancy.id).after('<tr id="submittedCandidates"></tr>');
        var html = '<td colspan="8"><div ng-include="\'app/components/candidate/view/submitedCandidateList.html\'"></div></td>';
        var templateGoesHere = angular.element($('#submittedCandidates'));
        templateGoesHere.html(html);
        $compile(templateGoesHere)($scope);
    }    
}
// Controller to get submited Candidate list
function submitedCandidateListController($scope, $state, localStorageService, APP_CONSTANTS, apiCall, $uibModal) {

    $scope = $scope.$parent.$parent;

    var apiCL = apiCall.post(APP_CONSTANTS.URL.CANDIDATESUBMISSIONURL.GETURL + $scope.jobData.Vacancy.id, { 'VacancyId': $scope.jobData.Vacancy.id} );
    apiCL.then(function (data) {        
        $scope.submitedCandidateList = data;
    });

    $scope.submitCandidate = function (data) {
        localStorageService.set('vacancyData', $scope.jobData);
        localStorageService.set('submittedCandidate', data);

        $state.go($scope.configJSON.candidateSubmissionUrl);
    }

    $scope.createAppointment = function (data) {
        localStorageService.set('createSubmissionId', data.ID);
        $state.go('appointment.manageAppointment');
    }
}



