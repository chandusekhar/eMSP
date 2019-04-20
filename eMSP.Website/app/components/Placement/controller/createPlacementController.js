'use strict';
angular.module('eMSPApp')
    .controller('createPlacementController', createPlacementController);
function createPlacementController($scope, configJSON, $uibModalInstance, MSPTimeGroup, localStorageService, apiCall, APP_CONSTANTS, toaster, $state) {
    $scope.configJSON = configJSON.data;
    $scope.parent = $scope.$parent;    
    $scope.vacancyDetails = $scope.$parent.vacancyDetails;
    $scope.candidateDetails = $scope.$parent.candidateDetails.Candidate;
    $scope.submissionId = localStorageService.get('createSubmissionId');
    $scope.placementDetails = $scope.$parent.placementDetails;
    $scope.dataJSON = {
        jobId: $scope.vacancyDetails.Vacancy.id,
        jobTitle: $scope.vacancyDetails.Vacancy.positionTitle,
        jobStart: $scope.vacancyDetails.Vacancy.startDate,
        jobEnd: $scope.vacancyDetails.Vacancy.endDate,
        firstName: $scope.candidateDetails.FirstName,
        lastName: $scope.candidateDetails.LastName,
        email: $scope.candidateDetails.Email,
        payRate: $scope.parent.submitCandidate.BillRate,
        billRate: $scope.parent.submitCandidate.BillRate,
        SubmissionID: $scope.submissionId,
        timeGroup: $scope.placementDetails !== null ? $scope.placementDetails.TimeGroupID.toString():"",
        password: "",
        formIsActive: $scope.placementDetails != null ? $scope.placementDetails.isActive : "",
        placementId: $scope.placementDetails != null ? $scope.placementDetails.ID : ""
    };
    $scope.refData = {};
    $scope.MSPTimeGroup = MSPTimeGroup;

    $scope.createPlacement = function () {

        if ($scope.formAction === "Update") {
            var res = apiCall.post(APP_CONSTANTS.URL.PLACEMENT.UPDATECANDIDATEPLACEMENT, $scope.dataJSON);
            res.then(function (data) {
                toaster.success({ body: "Placement Updated Successfully." });
                $scope.dataJSON = {};
                $uibModalInstance.close();
                $state.reload();
            });
        } else {
            var result = apiCall.post(APP_CONSTANTS.URL.PLACEMENT.CREATEPLACEMENT, $scope.dataJSON);
            result.then(function (data) {
                toaster.success({ body: "Placement Created Successfully." });
                $scope.dataJSON = {};
                $uibModalInstance.close();
                $state.reload();
            });
        }
    };    

    

}