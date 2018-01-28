'use strict';
angular.module('eMSPApp')
    .controller('candidateSubmissionController', candidateSubmissionController)
   
function candidateSubmissionController($scope, $state, $uibModal, localStorageService, configJSON, apiCall, APP_CONSTANTS, toaster, $filter) {
    $scope.submitted = false;
    $scope.submit = function (form) {
        $scope.submitted = true;
        if (form.$valid) {
            var suc = false;
            if ($scope.editform) {
                var resUpdate = apiCall.post(APP_CONSTANTS.URL.CANDIDATESUBMISSIONURL.UPDATEURL, $scope.csdataJSON);
                resUpdate.then(function (data) {
                    $scope.csdataJSON = data;
                    toaster.warning({ body: "Data Updated Successfully." });
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.CANDIDATESUBMISSIONURL.CREATEURL, $scope.csdataJSON);
                res.then(function (data) {
                    $scope.csdataJSON = data;
                    toaster.success({ body: "Data Created Successfully." });
                    //angular.forEach($scope.industryList, function (obj) {
                    //    if (obj.id === data.industryId) {
                    //        obj.skillList.unshift(data);
                    //    }
                    //});
                });
            }
            $uibModalInstance.close();
        }
    }

    $scope.reset = function () {
        $scope.submitted = false;
        $state.reload();
        
    }
}

