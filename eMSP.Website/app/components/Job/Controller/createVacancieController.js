'use strict';
angular.module('eMSPApp')
    .controller('createVacancieController', createVacancieController)
function createVacancieController($scope, $state, localStorageService, configJSON, formAction, apiCall, APP_CONSTANTS, toaster) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.cdataJSON = {};
    $scope.refData = {};
    $scope.cdataJSON.companyType = $scope.configJSON.companyType;
    $scope.cdataJSON.companyName = $scope.configJSON.companyName;
    $scope.dataJSON.mspId = localStorageService.get('editCompanyData') ? localStorageService.get('editCompanyData').id : 0;
    $scope.edit = false;
    $scope.formAction = formAction;
    $scope.dataJSON.submitted = false;
    $scope.refData.loginUserId = "afcf8230-7878-4e1d-a550-532fd10769ae";

    $scope.dataJSON.Vacancy = {};
    $scope.dataJSON.dateRange = { startDate: $scope.dataJSON.Vacancy.startDate, endDate: $scope.dataJSON.Vacancy.endDate };
    $scope.dataJSON.VacancySkills = [];
    $scope.dataJSON.VacancyLocations = [];
    $scope.dataJSON.VacancySuppliers = [];
    $scope.dataJSON.VacancyFiles = [];
    $scope.dataJSON.VacancyComment = [];

    if ($scope.formAction === "Update") {
        $scope.edit = true;
        $scope.dataJSON = localStorageService.get('vacancyData');
    }

    $scope.refData.sdataJSON = {
        companyType: "Supplier",
        companyName: "%"
    }
    var apiSL = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.SEARCHURL, $scope.refData.sdataJSON);
    apiSL.then(function (data) {
        $scope.refData.supplierList = data;
    });

    var apires = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.SEARCHURL, $scope.cdataJSON);
    apires.then(function (data) {
        $scope.refData.customerList = data;

        if ($scope.formAction === "Update") {
            $scope.dataJSON.customerId = $scope.dataJSON.customerId.toString();
        }
    });
   

    var apires = apiCall.post(APP_CONSTANTS.URL.INDUSTRY.GETALLSKILLSURL + 0, { "industryId": 0 });
    apires.then(function (data) {
        $scope.refData.skillsList = data;
    });

    var apivacancyType = apiCall.post(APP_CONSTANTS.URL.VACANCY.GETACTIVEMSPVACANCYTYPEURL, $scope.dataJSON);
    apivacancyType.then(function (data) {
        $scope.refData.vacancyTypes = data;

        if ($scope.formAction === "Update") {
            $scope.dataJSON.vacancyType = $scope.dataJSON.vacancyType.toString();
        }
    });
    

    $scope.getUserList = function () {
        
        $scope.cdataJSON.id = $scope.dataJSON.Vacancy.customerId;
        var apires = apiCall.post(APP_CONSTANTS.URL.USER.GETALLUSERSURL, $scope.cdataJSON);
        apires.then(function (data) {
            console.log(data);
            $scope.refData.usersList = data;
        });

        var apiSL = apiCall.post(APP_CONSTANTS.URL.LOCATION.GETCUSTOMERLOCATIONBRANCHURL, { companyType: "Customer", companyId: $scope.dataJSON.Vacancy.customerId, isActive: true });
        apiSL.then(function (data) {
            $scope.refData.locationList = data;
        });
    }

    $scope.submit = function (form) {
        debugger;
        var isFormValid = false;
        if ($scope.dataJSON.VacancySkills.length == 0) {
            $scope.isSkillsEmpty = true;
            isFormValid = true;
        }
        if ($scope.dataJSON.VacancyLocations.length == 0) {
            $scope.isLocationEmpty = true;
            isFormValid = true;
        }
        if ($scope.dataJSON.VacancySuppliers.length == 0) {
            $scope.isSupplierEmpty = true;
            isFormValid = true;
        }
        if ($scope.dataJSON.VacancyFiles.length == 0) {
            $scope.isFilesEmpty = true;
            isFormValid = true;
        }
        $scope.dataJSON.submitted = true;

        $scope.dataJSON.Vacancy.startDate = $scope.dataJSON.dateRange.startDate;
        $scope.dataJSON.Vacancy.endDate = $scope.dataJSON.dateRange.endDate;        

        if (form.$valid && !isFormValid) {
            if ($scope.formAction === "Update") {
                var resUpdate = apiCall.post(APP_CONSTANTS.URL.VACANCY.UPDATEBVACANCY, $scope.dataJSON);
                resUpdate.then(function (data) {
                    $scope.dataJSON = data;
                    toaster.warning({ body: "Data Updated Successfully." });

                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.VACANCY.CREATEVACANCY, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    toaster.warning({ body: "Data Created Successfully." });
                });
            }
            $state.go($scope.configJSON.successURL);
        }
    }
}