//<reference path="components/accounts/view/login.html" />
//<reference path="config.js" />
//<reference path="app.js" />
//<reference path="app.js" />
/**
 * INSPINIA - Responsive Admin Theme
 *
 * Inspinia theme use AngularUI Router to manage routing and views
 * Each view are defined as state.
 * Initial there are written state for all view in theme.
 *
 */
function config($stateProvider, $urlRouterProvider, $ocLazyLoadProvider, IdleProvider, KeepaliveProvider, $locationProvider) {


    // Configure Idle settings
    IdleProvider.idle(5); // in seconds
    IdleProvider.timeout(120); // in seconds

    //$urlRouterProvider.otherwise("/dashboards/dashboard_1");
    $urlRouterProvider.otherwise("/dashboard");

    //$locationProvider.html5Mode(true);

    $ocLazyLoadProvider.config({
        // Set to true if you want to see what and when is dynamically loaded
        debug: false
    });

    $stateProvider

        .state('login', {
            url: "/login",
            templateUrl: "app/components/accounts/view/login.html",
            data: { pageTitle: 'Login', specialClass: 'gray-bg' }
        })
        .state('registration', {
            url: "/registration",
            templateUrl: "app/components/accounts/view/registration.html",
            data: { pageTitle: 'Registration', specialClass: 'gray-bg' }
        })
        .state('forgot-password', {
            url: "/forgot-password",
            templateUrl: "app/components/accounts/view/forgotPassword.html",
            data: { pageTitle: 'Forgot Password', specialClass: 'gray-bg' }
        })
        .state('dashboard', {
            url: "/dashboard",
            templateUrl: "app/components/dashboard/view/dashboard.html",
            data: { pageTitle: 'Dashboard' },
            resolve: {
                loadPlugin: function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {

                            serie: true,
                            name: 'angular-flot',
                            files: ['js/plugins/flot/jquery.flot.js', 'js/plugins/flot/jquery.flot.time.js', 'js/plugins/flot/jquery.flot.tooltip.min.js', 'js/plugins/flot/jquery.flot.spline.js', 'js/plugins/flot/jquery.flot.resize.js', 'js/plugins/flot/jquery.flot.pie.js', 'js/plugins/flot/curvedLines.js', 'js/plugins/flot/angular-flot.js', ]
                        },
                        {
                            name: 'angles',
                            files: ['js/plugins/chartJs/angles.js', 'js/plugins/chartJs/Chart.min.js']
                        },
                        {
                            name: 'angular-peity',
                            files: ['js/plugins/peity/jquery.peity.min.js', 'js/plugins/peity/angular-peity.js']
                        }
                    ]);
                }
            }
        })



        //company Routes starts
        .state('company', {
            abstract: true,
            url: "/company",
            templateUrl: "views/common/content.html",
        })
        .state("company.searchMSP", {
            url: '/searchMSP',
            templateUrl: 'app/components/Company/View/searchCompany.html',
            controller: 'searchCompanyController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Company/Config/SearchMSP.json").success(function (data) { return data; });
                },
                AppCoutries: function (apiCall, APP_CONSTANTS) {
                    return apiCall.get(APP_CONSTANTS.URL.APP.GETCOUNTRYURL, {})
                    .then(function (data) {
                        return data;
                    });

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
                            name: 'ui.switchery',
                            files: ['css/plugins/switchery/switchery.css', 'js/plugins/switchery/switchery.js', 'js/plugins/switchery/ng-switchery.js']
                        }
                    ]);
                }
            }
        })
        .state("company.searchSuppliers", {
            url: '/searchSuppliers',
            templateUrl: 'app/components/Company/View/searchCompany.html',
            controller: 'searchCompanyController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Company/Config/SearchSuppliers.json").success(function (data) { return data; });
                }, AppCoutries: function (apiCall, APP_CONSTANTS) {
                    return apiCall.get(APP_CONSTANTS.URL.APP.GETCOUNTRYURL, {})
                    .then(function (data) {
                        return data;
                    });

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
                        }
                    ]);
                }
            }
        })
        .state("company.searchCustomers", {
            url: '/searchCustomers',
            templateUrl: 'app/components/Company/View/searchCompany.html',
            controller: 'searchCompanyController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Company/Config/SearchCustomers.json").success(function (data) { return data; });
                }, AppCoutries: function (apiCall, APP_CONSTANTS) {
                    return apiCall.get(APP_CONSTANTS.URL.APP.GETCOUNTRYURL, {})
                    .then(function (data) {
                        return data;
                    });

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
                        }
                    ]);
                }
            }
        })
        //.state("company.createMSP", {
        //    url: '/createMSP',
        //    templateUrl: 'app/components/Company/View/createCompany.html',
        //    controller: 'createCompanyController',
        //    resolve: {
        //        configJSON: function ($http) {
        //            return $http.get("app/components/Company/Config/CreateMSP.json").success(function (data) { return data; });
        //        },
        //        formAction: function () { return "Create"; },
        //        AppCoutries: function (apiCall, APP_CONSTANTS) {
        //            return apiCall.get(APP_CONSTANTS.URL.APP.GETCOUNTRYURL, {})
        //            .then(function (data) {
        //                return data;
        //            });
        //        },
        //        loadPlugin: function ($ocLazyLoad) {
        //            return $ocLazyLoad.load([
        //                {
        //                    serie: true,
        //                    files: ['js/plugins/dataTables/datatables.min.js', 'css/plugins/dataTables/datatables.min.css']
        //                },
        //                {
        //                    serie: true,
        //                    name: 'datatables',
        //                    files: ['js/plugins/dataTables/angular-datatables.min.js']
        //                },
        //                {
        //                    serie: true,
        //                    name: 'datatables.buttons',
        //                    files: ['js/plugins/dataTables/angular-datatables.buttons.min.js']
        //                }
        //            ]);
        //        }
        //    }
        //})
        .state("company.createSupplier", {
            url: '/createSupplier',
            templateUrl: 'app/components/Company/View/createCompany.html',
            controller: 'createCompanyController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Company/Config/CreateSupplier.json").success(function (data) { return data; });
                },
                formAction: function () { return "Create"; },
                AppCoutries: function (apiCall, APP_CONSTANTS) {
                    return apiCall.get(APP_CONSTANTS.URL.APP.GETCOUNTRYURL, {})
                    .then(function (data) {
                        return data;
                    });

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
                        }
                    ]);
                }
            }
        })
        .state("company.createCustomer", {
            url: '/createCustomer',
            templateUrl: 'app/components/Company/View/createCompany.html',
            controller: 'createCompanyController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Company/Config/CreateCustomer.json").success(function (data) { return data; });
                },
                formAction: function () { return "Create"; },
                AppCoutries: function (apiCall, APP_CONSTANTS) {
                    return apiCall.get(APP_CONSTANTS.URL.APP.GETCOUNTRYURL, {})
                    .then(function (data) {
                        return data;
                    });

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
                        }
                    ]);
                }
            }
        })
        .state("company.editMSP", {
            url: '/editMSP',
            templateUrl: 'app/components/Company/View/createCompany.html',
            controller: 'createCompanyController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Company/Config/CreateMSP.json").success(function (data) { return data; });
                },
                formAction: function () { return "Update"; },
                AppCoutries: function (apiCall, APP_CONSTANTS) {
                    return apiCall.get(APP_CONSTANTS.URL.APP.GETCOUNTRYURL, {})
                    .then(function (data) {
                        return data;
                    });

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
                        }
                    ]);
                }
            }
        })

        .state("company.editSupplier", {
            url: '/editSupplier',
            templateUrl: 'app/components/Company/View/createCompany.html',
            controller: 'createCompanyController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Company/Config/CreateSupplier.json").success(function (data) { return data; });
                },
                formAction: function () { return "Update"; },
                AppCoutries: function (apiCall, APP_CONSTANTS) {
                    return apiCall.get(APP_CONSTANTS.URL.APP.GETCOUNTRYURL, {})
                    .then(function (data) {
                        return data;
                    });

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
                        }
                    ]);
                }
            }
        })
        .state("company.editCustomer", {
            url: '/editCustomer',
            templateUrl: 'app/components/Company/View/createCompany.html',
            controller: 'createCompanyController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Company/Config/CreateCustomer.json").success(function (data) { return data; });
                },
                formAction: function () { return "Update"; },
                AppCoutries: function (apiCall, APP_CONSTANTS) {
                    return apiCall.get(APP_CONSTANTS.URL.APP.GETCOUNTRYURL, {})
                    .then(function (data) {
                        return data;
                    });

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
                        }
                    ]);
                }
            }
        })

        //Branch and locations
        .state("company.locations", {
            url: '/locations',
            templateUrl: 'app/components/Company/View/ManageMSPLocation.html',
            controller: 'manageMSPLocationController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Company/Config/ManageLocation.json").success(function (data) { return data; });
                },
                formAction: function () { return "Update"; },
                AppCoutries: function (apiCall, APP_CONSTANTS) {
                    return apiCall.get(APP_CONSTANTS.URL.APP.GETCOUNTRYURL, {})
                    .then(function (data) {
                        return data;
                    });

                },
                loadPlugin: function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            serie: true,
                            name: 'datatables.buttons',
                            files: ['js/plugins/dataTables/angular-datatables.buttons.min.js']
                        }
                    ]);
                }
            }
        })
        .state("company.branches", {
            url: '/branches',
            templateUrl: 'app/components/Company/View/ManageMSPBranch.html',
            controller: 'manageMSPBranchController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Company/Config/ManageBranch.json").success(function (data) { return data; });
                },
                formAction: function () { return "Update"; },
                AppCoutries: function (apiCall, APP_CONSTANTS) {
                    return apiCall.get(APP_CONSTANTS.URL.APP.GETCOUNTRYURL, {})
                    .then(function (data) {
                        return data;
                    });

                },
                loadPlugin: function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            serie: true,
                            name: 'datatables.buttons',
                            files: ['js/plugins/dataTables/angular-datatables.buttons.min.js']
                        }
                    ]);
                }
            }
        })

        //company Routes end

        //country Routes starts
        .state('country', {
            abstract: true,
            url: "/country",
            templateUrl: "views/common/content.html",
        })
        .state("country.manageCountry", {
            url: '/manageCountry',
            templateUrl: 'app/components/country-state/view/manageCountry.html',
            controller: 'countryStateController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/country-state/Config/ManageCountryState.json").success(function (data) { return data; });
                },
                AppCountries: function (apiCall, APP_CONSTANTS) {
                    return apiCall.get(APP_CONSTANTS.URL.COUNTRY.GETALLCOUNTRIESURL, {})
                        .then(function (data) {
                            return data;
                        });

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
                            name: 'ui.switchery',
                            files: ['css/plugins/switchery/switchery.css', 'js/plugins/switchery/switchery.js', 'js/plugins/switchery/ng-switchery.js']
                        }
                    ]);
                }
            }
        })
        //country Routes Ends

        //industry Routes starts
        .state('industry', {
            abstract: true,
            url: "/industry",
            templateUrl: "views/common/content.html",
        })
        .state("industry.manageIndustry", {
            url: '/manageIndustry',
            templateUrl: 'app/components/industry/view/manageIndustry.html',
            controller: 'industrySkilsController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/industry/Config/ManageIndustrySkills.json").success(function (data) { return data; });
                },
                AppIndustries: function (apiCall, APP_CONSTANTS) {
                    return apiCall.get(APP_CONSTANTS.URL.INDUSTRY.GETALLINDUSTRIESURL, {})
                        .then(function (data) {
                            return data;
                        });
                    return {};
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
                            name: 'ui.switchery',
                            files: ['css/plugins/switchery/switchery.css', 'js/plugins/switchery/switchery.js', 'js/plugins/switchery/ng-switchery.js']
                        }
                    ]);
                }
            }
        })
        //industry Routes Ends
        .state('off_canvas', {
            url: "/off_canvas",
            templateUrl: "views/off_canvas.html",
            data: { pageTitle: 'Off canvas menu', specialClass: 'canvas-menu' }
        });

}
angular
    .module('eMSPApp')
    .config(config)
    .run(function ($rootScope, $state) {
        $rootScope.$state = $state;
    });





