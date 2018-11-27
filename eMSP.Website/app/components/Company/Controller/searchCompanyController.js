'use strict';
angular.module('eMSPApp')
    .controller('searchCompanyController', searchCompanyController)
function searchCompanyController($scope, $state, localStorageService, configJSON, APP_CONSTANTS, apiCall, $uibModal, AppCoutries, toaster, ngAuthSettings) {// APP_CONSTANTS, apiCall
    $scope.config = localStorageService.get('pageSettings');
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.searchResults = [];
    $scope.refData = {};
    $scope.dataJSON.companyType = $scope.configJSON.companyType;
    $scope.IsMSP = false;
    $scope.refData.countryList = AppCoutries;
    $scope.refData.userViewType = "Card";
    $scope.baseUrl = ngAuthSettings.contentURL+"";

    if ($scope.configJSON.companyType === "MSP") {
        $scope.dataJSON.companyName = "";
        $scope.dataJSON.id = 0;
        $scope.IsMSP = true;
        var apires = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.GETURL, $scope.dataJSON);
        apires.then(function (data) {
            $scope.res = data;
            localStorageService.set('editCompanyData', data);
            $scope.loadLocations($scope.res.id);
            $scope.dataJSON.companyId = $scope.res.id;
            $scope.loadUsers($scope.res.id);

            if ($scope.configJSON.companyType === 'Supplier' || $scope.configJSON.companyType === 'Customer') {
                $scope.loadCandidates($scope.res.id);
                $scope.loadJobs();
            }
        });
    } else {
        $scope.dataJSON.companyName = "%";
        var res = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.SEARCHURL, $scope.dataJSON);
        res.then(function (data) {
            $scope.searchResults = data;
        });
    }

    $scope.toggleView = function () {
        if ($scope.refData.userViewType === "Card") {
            $scope.refData.userViewType = "List";
        } else { $scope.refData.userViewType = "Card"; }
    };


    //Function to load Locations
    $scope.loadLocations = function (compId) {
        var apires = apiCall.post(APP_CONSTANTS.URL.LOCATION.GETALLLOCATIONSURL + "?$filter=isDeleted eq false", { companyType: $scope.dataJSON.companyType, companyId: compId });
        apires.then(function (data) {
            $scope.resLocations = data;
        });
    }

    //Function to load Branch by location
    $scope.loadBranches = function (location) {
        $scope.refData.locationData = location;
        var apires = apiCall.post(APP_CONSTANTS.URL.BRANCH.GETALLBRANCHEBYLOCATIONSURL, { locationId: $scope.refData.locationData.locationId });
        apires.then(function (data) {
            $scope.toggleBranches = true;
            $scope.resBranches = data;
        });
    }

    //Function to load candidates
    $scope.loadCandidates = function (compId) {
        var apires = apiCall.post(APP_CONSTANTS.URL.CANDIDATEURL.SEARCHURL + '?SupplierId=' + compId, { 'SupplierId': compId });
        apires.then(function (data) {
            $scope.resCandidates = data;
        });
    }

    //Function to load supplier jobs
    $scope.loadJobs = function () {
        var apires = apiCall.post(APP_CONSTANTS.URL.VACANCY.GETVACANCIESURL, $scope.dataJSON);
        apires.then(function (data) {
            $scope.resVacancie = data;
        });
    }

    //Function to swith back to locations
    $scope.swithLocation = function () {
        $scope.toggleBranches = false;
    }

    $scope.loadUsers = function (compId) {
        var apires = apiCall.post(APP_CONSTANTS.URL.USER.GETALLUSERSURL, { companyType: $scope.dataJSON.companyType, id: compId });
        apires.then(function (data) {
            $scope.resUsers = data;
        });
    }

    $scope.edit = function (data) {
        if (data) {
            localStorageService.set('editCompanyData', data);
            $state.go($scope.configJSON.editUrl);
        }

    }
    $scope.view = function (data) {

        if (data) {
            $scope.IsMSP = true;
            $scope.res = data;
            localStorageService.set('editCompanyData', data);

            $scope.loadLocations(data.id);
            $scope.loadUsers(data.id);

            $scope.dataJSON.id = data.id;
            if ($scope.configJSON.companyType === 'Supplier' || $scope.configJSON.companyType === 'Customer') {
                localStorageService.set('supplierId', data.id);
                $scope.loadCandidates(data.id);
                $scope.loadJobs();
            }
        }

    }
    $scope.submit = function (form) {
        if (form.$valid) {
            //alert("Form submitted");
            var res = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.SEARCHURL, $scope.dataJSON);
            res.then(function (data) {
                $scope.searchResults = data;
            });
        }
    }

    $scope.modelU = function (model) {

        $scope.udataJSON = {};
        if (model) {
            $scope.editform = true;
            $scope.udataJSON = model.user;
            $scope.formAction = "Update";
        }
        else {
            $scope.formAction = "Create";
            $scope.editform = false;
            $scope.udataJSON.companyId = $scope.res.id;
            $scope.udataJSON.companyType = $scope.res.companyType;
            $scope.udataJSON.companyName = $scope.res.companyName;
        }

        var modalInstance = $uibModal.open({
            templateUrl: 'app/components/user/view/manageUser.html',
            scope: $scope,
            controller: 'userController',
            windowClass: 'animated slideInRight'
        });
    }

    $scope.modelRP = function (model) {
       
        if (model) {
            
            $scope.dataJSON.user = model;
            $scope.dataJSON.user.emailAddress = model.user.emailAddress;
        }
        var modalInstance = $uibModal.open({
            templateUrl: 'app/components/accounts/view/changeUserPasswordModel.html',
            scope: $scope,
            controller: 'changeUserPasswordController',
            windowClass: 'animated slideInRight',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/accounts/config/changeUserPassword.json").success(function (data) { return data; });
                },
                formAction: function () { return "Change"; },
            }
        });
    }

    $scope.modelL = function (model) {
        $scope.ldataJSON = {};
        if (model) {
            $scope.editform = true;
            $scope.ldataJSON = model;
        }
        else {
            $scope.editform = false;
            $scope.ldataJSON.companyId = $scope.res.id;
            $scope.ldataJSON.companyType = $scope.res.companyType;
            $scope.ldataJSON.companyName = $scope.res.companyName;
        }

        var modalInstance = $uibModal.open({
            templateUrl: 'app/components/location-branch/view/manageLocation.html',
            scope: $scope,
            controller: 'locationController',
            windowClass: 'animated slideInRight'
        });
    }

    $scope.modalB = function (model) {
        $scope.editform = false;
        $scope.bdataJSON = {};
        if (model.branchId === null) {
            $scope.bdataJSON.locationId = model.id;
            $scope.bdataJSON.locationName = model.locationName;
        } else {
            $scope.editform = true;
            $scope.bdataJSON = model;
        }

        $scope.bdataJSON.companyId = $scope.res.id;
        $scope.bdataJSON.companyType = $scope.res.companyType;
        $scope.bdataJSON.companyName = $scope.res.companyName;

        var modalInstance = $uibModal.open({
            templateUrl: 'app/components/location-branch/view/manageBranch.html',
            scope: $scope,
            controller: 'branchController',
            windowClass: 'animated slideInRight'
        });
    }

    $scope.AddCandidate = function (model) {

        $scope.csdataJSON = {};

        if (model.VacancyId) {
            $scope.editform = true;
            $scope.csdataJSON = model;
        }
        else {
            $scope.editform = false;
            $scope.csdataJSON.VacancyId = model.Vacancy.id;
        }

        var modalInstance = $uibModal.open({
            templateUrl: 'app/components/candidate/view/candidateSubmission.html',
            scope: $scope,
            controller: 'candidateSubmissionController',
            windowClass: 'animated slideInRight',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/candidate/config/manageCandidateSubmission.json").success(function (data) { return data; });
                },
                candidateStatusList: function ($http) {
                    return apiCall.get(APP_CONSTANTS.URL.CANDIDATESUBMISSIONURL.GETCANDIDATESTATUS).then(function (data) { return data; });
                },
                loadPlugin: function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            serie: true,
                            files: ['js/plugins/dataTables/datatables.min.js', 'css/plugins/dataTables/datatables.min.css']
                        },
                        {
                            serie: true,
                            name: 'datatables',
                            files: ['js/plugins/dataTables/angular-datatables.min.js']
                        },
                        {
                            serie: true,
                            name: 'datatables.buttons',
                            files: ['js/plugins/dataTables/angular-datatables.buttons.min.js']
                        },
                        {
                            name: 'ui.select',
                            files: ['js/plugins/ui-select/select.min.js', 'css/plugins/ui-select/select.min.css']
                        }
                    ]);
                }
            }
        });
    }

    $scope.FixAppointment = function (model) {

        localStorageService.set('vacancyData', model);
        $state.go($scope.configJSON.fixAppointment);
    }

    $scope.updateUser = function (model) {
        model.companyId = $scope.res.id;
        model.companyType = $scope.res.companyType;
        model.companyName = $scope.res.companyName;
        $scope.modelU(model);
    }

    $scope.resetPassword = function (model) {
        model.companyId = $scope.res.id;
        model.companyType = $scope.res.companyType;
        model.companyName = $scope.res.companyName;
        $scope.modelRP(model);
    }

    $scope.updateLocation = function (model) {
        model.companyId = $scope.res.id;
        model.companyType = $scope.res.companyType;
        model.companyName = $scope.res.companyName;
        $scope.modelL(model);
    }

    $scope.updateBranch = function (model) {
        $scope.modalB(model);
    }

    $scope.ctoggleActive = function (model) {
        var res = apiCall.post(APP_CONSTANTS.URL.USER.UPDATECOMPANYUSER, model);
        res.then(function (data) {
            toaster.warning({ body: "Completed Successfully." });
        });
    }

    $scope.toggleActiveLocation = function (model) {
        var res = apiCall.post(APP_CONSTANTS.URL.LOCATION.UPDATELOCATIONURL, model);
        res.then(function (data) {
            toaster.warning({ body: "Completed Successfully." });
        });
    }

    $scope.toggleActiveBranch = function (model) {
        var res = apiCall.post(APP_CONSTANTS.URL.BRANCH.UPDATEBRANCHURL, model);
        res.then(function (data) {
            toaster.warning({ body: "Completed Successfully." });
        });
    }

    //Not using this block. This block is use to delete Location
    $scope.deleteLocation = function (model) {
        model.companyId = $scope.res.id;
        model.companyType = $scope.res.companyType;
        model.companyName = $scope.res.companyName;
        var res = apiCall.post(APP_CONSTANTS.URL.LOCATION.DELETELOCATIONURL, model);
        res.then(function (data) {
            alert("Location Removed Successfully");
            $state.reload();
        });
    }

    $scope.editCanditate = function (candidate) {
        localStorageService.set('editCandidateData', candidate);
        $state.go("candidate.edit");
    }
}