'use strict';
angular.module('eMSPApp')
    .controller('manageVacancyController', manageVacancyController)
    .controller('addVacancySkillController', addVacancySkillController)
function manageVacancyController($scope, $state, localStorageService, configJSON, APP_CONSTANTS, apiCall, $uibModal) {// APP_CONSTANTS, apiCall
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.refData = {};
    $scope.vacancyData = localStorageService.get('vacancyData') ? localStorageService.get('vacancyData') : undefined;
    $scope.dataJSON.companyType = $scope.configJSON.companyType;
    $scope.dataJSON.companyName = $scope.configJSON.companyName;

    var apires = apiCall.post(APP_CONSTANTS.URL.VACANCY.GETVACANCIESURL, $scope.dataJSON);
    apires.then(function (data) {
        $scope.resVacancie = data;
    });

    var apiCL = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.SEARCHURL, $scope.dataJSON);
    apiCL.then(function (data) {
        $scope.refData.customerList = data;
    });
    
    if (!$scope.vacancyData.skillList) {
        var apiSL = apiCall.post(APP_CONSTANTS.URL.VACANCY.GETVACANCYSKILLS + $scope.vacancyData.id, { "id": $scope.vacancyData.id });
        apiSL.then(function (data) {
            $scope.vacancyData.skillList = data;
        });
    }
    if (!$scope.vacancyData.locationList) {
        var apiSL = apiCall.post(APP_CONSTANTS.URL.VACANCY.GETVACANCYLOCATIONS + $scope.vacancyData.id, { "id": $scope.vacancyData.id });
        apiSL.then(function (data) {
            $scope.vacancyData.locationList = data;
        });
    }

    if (!$scope.vacancyData.supplierList) {
        var apiSL = apiCall.post(APP_CONSTANTS.URL.VACANCY.GETVACANCYSUPPLIER + $scope.vacancyData.id, { "id": $scope.vacancyData.id });
        apiSL.then(function (data) {
            $scope.vacancyData.supplierList = data;
            console.log(data);
        });
    }

    $scope.openAddLocation = function (toggleAddLocation, vacancy) {
        this.toggleAddLocation = true;

        var apiSL = apiCall.post(APP_CONSTANTS.URL.LOCATION.GETCUSTOMERLOCATIONBRANCHURL, { companyType: "Customer", companyId: vacancy.customerId, isActive: true });
        apiSL.then(function (data) {
            $scope.refData.locationList = data;
        });
    }

    $scope.addVacancyLocation = function (vacancy) {
        $scope.data = {
            createdUserID: "afcf8230-7878-4e1d-a550-532fd10769ae",
            updatedUserID: "afcf8230-7878-4e1d-a550-532fd10769ae",
            locationId: $scope.refData.locationId,
            vacancyId: vacancy.id,
            isActive: true
        };

        var apiSL = apiCall.post(APP_CONSTANTS.URL.VACANCY.ADDVACANCYLOCATIONS, $scope.data);
        apiSL.then(function (data) {
            alert("Location added Successfully");
        });

    }

    $scope.toggleVLActive = function (location) {
        location.isActive = false;
        var apiupdate = apiCall.post(APP_CONSTANTS.URL.VACANCY.UPDATEVACANCYLOCATIONS, location);
        apiupdate.then(function (data) {
            alert("Data Updated Successfully");
        });
    }

    $scope.removeLocation = function (location) {
        location.isDeleted = true;
        var apiUpdate = apiCall.post(APP_CONSTANTS.URL.VACANCY.UPDATEVACANCYLOCATIONS, location);
        apiUpdate.then(function (data) {
            alert("Location removed Successfully");
        });
    }


    $scope.addSkillsModal = function (model) {
        if (model.industryId) {
            $scope.editform = true;
            $scope.sdataJSON = model;
        }
        else {
            $scope.editform = false;
            $scope.sdataJSON = {};
            $scope.sdataJSON.vacancyId = model.id;
        }

        var modalInstance = $uibModal.open({
            templateUrl: 'app/components/Job/view/manageVacancySkill.html',
            scope: $scope,
            controller: 'addVacancySkillController'
        });
    }

    $scope.removeSkill = function (skill) {
        skill.isDeleted = true;
        var apiUpdate = apiCall.post(APP_CONSTANTS.URL.VACANCY.UPDATEVACANCYSKILLS, skill);
        apiUpdate.then(function (data) {
            alert("Skill removed Successfully");
        });
    }

    $scope.toggleVSActive = function (skill) {
        skill.isActive = false;
        var apiupdate = apiCall.post(APP_CONSTANTS.URL.VACANCY.UPDATEVACANCYSKILLS, skill);
        apiupdate.then(function (data) {
            alert("Data Updated Successfully");
        });
    }


    $scope.openAddSupplier = function (toggleAddSupplier) {
        this.toggleAddSupplier = true;
        var data = {
            companyType: "Supplier",
            companyName: "%"
        }
        var apiSL = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.SEARCHURL, data);
        apiSL.then(function (data) {
            $scope.refData.supplierList = data;
        });
    }

    $scope.addVacancySupplier = function (vacancy) {
        debugger;
        $scope.data = {
            createdUserID: "afcf8230-7878-4e1d-a550-532fd10769ae",
            updatedUserID: "afcf8230-7878-4e1d-a550-532fd10769ae",
            supplierId: $scope.refData.supplierId,
            vacancyId: vacancy.id,
            isActive: true
        };

        var apiSL = apiCall.post(APP_CONSTANTS.URL.VACANCY.ADDVACANCYSUPPLIER, $scope.data);
        apiSL.then(function (data) {
            alert("Supplier added Successfully");
        });
    }

    $scope.removeSupplier = function (supplier) {
        supplier.isDeleted = true;
        var apiUpdate = apiCall.post(APP_CONSTANTS.URL.VACANCY.UPDATEVACANCYSUPPLIER, supplier);
        apiUpdate.then(function (data) {
            alert("Supplier removed Successfully");
        });
    }

    $scope.toggleVSupActive = function (supplier) {
        supplier.isActive = false;
        var apiupdate = apiCall.post(APP_CONSTANTS.URL.VACANCY.UPDATEVACANCYSUPPLIER, supplier);
        apiupdate.then(function (data) {
            alert("Data Updated Successfully");
        });
    }
}

function addVacancySkillController($scope, $state, $uibModalInstance, $filter, apiCall, APP_CONSTANTS) {

    var apiIndustries = apiCall.get(APP_CONSTANTS.URL.INDUSTRY.GETALLINDUSTRIESURL);
    apiIndustries.then(function (data) {
        $scope.refData.industries = data;
    });

    $scope.getSkills = function () {
        var apires = apiCall.post(APP_CONSTANTS.URL.INDUSTRY.GETALLSKILLSURL + $scope.sdataJSON.industryId, { "industryId": $scope.sdataJSON.industryId });
        apires.then(function (data) {
            $scope.refData.skillsList = data;
        });
    }

    $scope.submit = function (form) {
        $scope.sdataJSON.createdUserID = "afcf8230-7878-4e1d-a550-532fd10769ae";
        $scope.sdataJSON.updatedUserID = "afcf8230-7878-4e1d-a550-532fd10769ae";

        if (form.$valid) {
            var suc = false;
            if ($scope.editform) {
                var resUpdate = apiCall.post(APP_CONSTANTS.URL.VACANCY.UPDATESKILLURL, $scope.sdataJSON);
                resUpdate.then(function (data) {
                    $scope.sdataJSON = data;
                    alert("Data Updated Successfully");
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.VACANCY.ADDVACANCYSKILLS, $scope.sdataJSON);
                res.then(function (data) {
                    $scope.sdataJSON = data;
                    alert("Data Created Successfully");
                });
            }
            $uibModalInstance.close();
        }

    }
    $scope.reset = function () {

        $state.reload();
    }
}