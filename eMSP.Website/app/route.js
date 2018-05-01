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
    $urlRouterProvider.otherwise("/login");

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
            controller: 'forgotPasswordController',
            data: { pageTitle: 'Forgot Password', specialClass: 'gray-bg' },
            resolve: {
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
                        },
                        {
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        }
                    ]);
                }
            }
        })
        .state('resetPassword', {
            url: "/resetPassword/:UserId?code",
            templateUrl: "app/components/accounts/view/resetPassword.html",
            controller: 'resetPasswordController',
            data: { pageTitle: 'Reset Password', specialClass: 'gray-bg' },
            resolve: {
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
                        },
                        {
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        }
                    ]);
                }
            }
        })
        .state('dashboard', {
            url: "/dashboard",
            templateUrl: "app/components/dashboard/view/dashboard.html",
            data: { pageTitle: 'Dashboard' },
            resolve: {
                dataJSON: function (apiCall, APP_CONSTANTS, localStorageService) {
                    return apiCall.post(APP_CONSTANTS.URL.DASHBOARD.GETDETAILS, {}).
                        then(function (data) {
                            if (data) {
                                localStorageService.set("DashBoardData", data);
                            }
                            return data;
                        });
                },
                loadPlugin: function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {

                            serie: true,
                            name: 'angular-flot',
                            files: ['js/plugins/flot/jquery.flot.js', 'js/plugins/flot/jquery.flot.time.js', 'js/plugins/flot/jquery.flot.tooltip.min.js', 'js/plugins/flot/jquery.flot.spline.js', 'js/plugins/flot/jquery.flot.resize.js', 'js/plugins/flot/jquery.flot.pie.js', 'js/plugins/flot/curvedLines.js', 'js/plugins/flot/angular-flot.js',]
                        },
                        {
                            name: 'angles',
                            files: ['js/plugins/chartJs/angles.js', 'js/plugins/chartJs/Chart.min.js']
                        },
                        {
                            name: 'angular-peity',
                            files: ['js/plugins/peity/jquery.peity.min.js', 'js/plugins/peity/angular-peity.js']
                        },
                        {
                            serie: true,
                            files: ['js/plugins/jvectormap/jquery-jvectormap-2.0.2.min.js', 'js/plugins/jvectormap/jquery-jvectormap-2.0.2.css']
                        },
                        {
                            serie: true,
                            files: ['js/plugins/jvectormap/jquery-jvectormap-world-mill-en.js']
                        },
                        {
                            name: 'ui.checkbox',
                            files: ['js/bootstrap/angular-bootstrap-checkbox.js']
                        },
                        {
                            files: ['js/plugins/chartJs/Chart.min.js']
                        }
                    ]);
                }
            }
        })
        //company Routes starts
        .state('account', {
            abstract: true,
            url: "/account",
            templateUrl: "views/common/content.html",
            controller: "dashboardController",

        })
        .state('account.profile', {
            url: "/profile",
            templateUrl: "app/components/User/view/userProfile.html",
            controller: 'userProfileController',
            resolve: {
                dataJSON: function (apiCall, APP_CONSTANTS, localStorageService) {
                    return apiCall.post(APP_CONSTANTS.URL.USER.GETUSERURL, {}).
                        then(function (data) {

                            return data;
                        });
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
                        },
                        {
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        }
                    ]);
                }
            }
        })
        .state("account.changePassword", {
            url: '/changePassword',
            templateUrl: 'app/components/accounts/view/changePassword.html',
            controller: 'changePasswordController',
            resolve: {
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
                        },
                        {
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
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
            controller: "dashboardController",
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
                        },
                        {
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
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
                        },
                        {
                            name: 'ui.switchery',
                            files: ['css/plugins/switchery/switchery.css', 'js/plugins/switchery/switchery.js', 'js/plugins/switchery/ng-switchery.js']
                        },
                        {
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        }
                        ,
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
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
                        },
                        {
                            name: 'ui.switchery',
                            files: ['css/plugins/switchery/switchery.css', 'js/plugins/switchery/switchery.js', 'js/plugins/switchery/ng-switchery.js']
                        },
                        {
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
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
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
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
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
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
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
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
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
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
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
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
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
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
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        }
                    ]);
                }
            }
        })



        //company Routes end
        .state('vacancy', {
            abstract: true,
            url: "/vacancy",
            templateUrl: "views/common/content.html",
            controller: "dashboardController",
        })
        .state("vacancy.manageVacancieType", {
            url: '/manageVacancieType',
            templateUrl: 'app/components/Job/View/manageVacancieType.html',
            controller: 'manageVacancieTypeController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Job/Config/ManageVacancieType.json").success(function (data) { return data; });
                },
                formAction: function () { return "Create"; },
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
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        },
                        {
                            serie: true,
                            files: ['js/plugins/bootstrap-markdown/bootstrap-markdown.js', 'js/plugins/bootstrap-markdown/markdown.js', 'css/plugins/bootstrap-markdown/bootstrap-markdown.min.css']
                        },
                        {
                            name: 'datePicker',
                            files: ['css/plugins/datapicker/angular-datapicker.css', 'js/plugins/datapicker/angular-datepicker.js']
                        },
                        {
                            name: 'ui.switchery',
                            files: ['css/plugins/switchery/switchery.css', 'js/plugins/switchery/switchery.js', 'js/plugins/switchery/ng-switchery.js']
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        }
                    ]);
                }
            }
        })
        .state("vacancy.manageQuestions", {
            url: '/manageQuestions',
            templateUrl: 'app/components/Job/View/manageQuestions.html',
            controller: 'manageQuestionsController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Job/Config/ManageQuestions.json").success(function (data) { return data; });
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
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        },
                        {
                            serie: true,
                            files: ['js/plugins/bootstrap-markdown/bootstrap-markdown.js', 'js/plugins/bootstrap-markdown/markdown.js', 'css/plugins/bootstrap-markdown/bootstrap-markdown.min.css']
                        },
                        {
                            name: 'datePicker',
                            files: ['css/plugins/datapicker/angular-datapicker.css', 'js/plugins/datapicker/angular-datepicker.js']
                        },
                        {
                            name: 'ui.switchery',
                            files: ['css/plugins/switchery/switchery.css', 'js/plugins/switchery/switchery.js', 'js/plugins/switchery/ng-switchery.js']
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        }
                    ]);
                }
            }
        })
        .state("vacancy.manageDocuments", {
            url: '/manageDocuments',
            templateUrl: 'app/components/Job/View/manageDocuments.html',
            controller: 'manageDocumentsController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Job/Config/ManageDocuments.json").success(function (data) { return data; });
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
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        },
                        {
                            serie: true,
                            files: ['js/plugins/bootstrap-markdown/bootstrap-markdown.js', 'js/plugins/bootstrap-markdown/markdown.js', 'css/plugins/bootstrap-markdown/bootstrap-markdown.min.css']
                        },
                        {
                            name: 'datePicker',
                            files: ['css/plugins/datapicker/angular-datapicker.css', 'js/plugins/datapicker/angular-datepicker.js']
                        },
                        {
                            name: 'ui.switchery',
                            files: ['css/plugins/switchery/switchery.css', 'js/plugins/switchery/switchery.js', 'js/plugins/switchery/ng-switchery.js']
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        }
                    ]);
                }
            }
        })
        .state("vacancy.manageAppointmentType", {
            url: '/manageAppointmentType',
            templateUrl: 'app/components/Appointment/View/manageAppointmentType.html',
            controller: 'manageAppointmentTypeController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Appointment/Config/ManageAppointmentType.json").success(function (data) { return data; });
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
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        },
                        {
                            serie: true,
                            files: ['js/plugins/bootstrap-markdown/bootstrap-markdown.js', 'js/plugins/bootstrap-markdown/markdown.js', 'css/plugins/bootstrap-markdown/bootstrap-markdown.min.css']
                        },
                        {
                            name: 'datePicker',
                            files: ['css/plugins/datapicker/angular-datapicker.css', 'js/plugins/datapicker/angular-datepicker.js']
                        },
                        {
                            name: 'ui.switchery',
                            files: ['css/plugins/switchery/switchery.css', 'js/plugins/switchery/switchery.js', 'js/plugins/switchery/ng-switchery.js']
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        }
                    ]);
                }
            }
        })
        //Vacancies Routes starts
        .state('job', {
            abstract: true,
            url: "/job",
            templateUrl: "views/common/content.html",
            controller: "dashboardController",
        })
        .state("job.searchVacancies", {
            url: '/searchVacancies',
            templateUrl: 'app/components/Job/View/searchVacancies.html',
            controller: 'searchVacanciesController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Job/Config/SearchVacancies.json").success(function (data) { return data; });
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
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        },
                        {
                            name: 'ui.switchery',
                            files: ['css/plugins/switchery/switchery.css', 'js/plugins/switchery/switchery.js', 'js/plugins/switchery/ng-switchery.js']
                        },
                        {
                            name: 'datePicker',
                            files: ['css/plugins/datapicker/angular-datapicker.css', 'js/plugins/datapicker/angular-datepicker.js']
                        }

                    ]);
                }
            }
        })
        .state("job.createVacancy", {
            url: '/createVacancy',
            templateUrl: 'app/components/Job/View/createVacancy.html',
            controller: 'createVacancieController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Job/Config/CreateVacancy.json").success(function (data) { return data; });
                },
                formAction: function () { return "Create"; },
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
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        },
                        {
                            serie: true,
                            files: ['js/plugins/bootstrap-markdown/bootstrap-markdown.js', 'js/plugins/bootstrap-markdown/markdown.js', 'css/plugins/bootstrap-markdown/bootstrap-markdown.min.css']
                        },
                        {
                            name: 'datePicker',
                            files: ['css/plugins/datapicker/angular-datapicker.css', 'js/plugins/datapicker/angular-datepicker.js']
                        }, {
                            serie: true,
                            files: ['js/plugins/daterangepicker/daterangepicker.js', 'css/plugins/daterangepicker/daterangepicker-bs3.css']
                        },
                        {
                            name: 'daterangepicker',
                            files: ['js/plugins/daterangepicker/angular-daterangepicker.js']
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        },
                        {
                            name: 'ui.select',
                            files: ['js/plugins/ui-select/select.min.js', 'css/plugins/ui-select/select.min.css']
                        },
                        {
                            name: 'summernote',
                            files: ['css/plugins/summernote/summernote.css', 'css/plugins/summernote/summernote-bs3.css', 'js/plugins/summernote/summernote.min.js', 'js/plugins/summernote/angular-summernote.min.js']
                        }
                    ]);
                }
            }
        })
        .state("job.editVacancy", {
            url: '/editVacancy',
            templateUrl: 'app/components/Job/View/createVacancy.html',
            controller: 'createVacancieController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Job/Config/CreateVacancy.json").success(function (data) { return data; });
                },
                formAction: function () { return "Update"; },
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
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        },
                        {
                            serie: true,
                            files: ['js/plugins/bootstrap-markdown/bootstrap-markdown.js', 'js/plugins/bootstrap-markdown/markdown.js', 'css/plugins/bootstrap-markdown/bootstrap-markdown.min.css']
                        },
                        {
                            name: 'datePicker',
                            files: ['css/plugins/datapicker/angular-datapicker.css', 'js/plugins/datapicker/angular-datepicker.js']
                        }, {
                            serie: true,
                            files: ['js/plugins/daterangepicker/daterangepicker.js', 'css/plugins/daterangepicker/daterangepicker-bs3.css']
                        },
                        {
                            name: 'daterangepicker',
                            files: ['js/plugins/daterangepicker/angular-daterangepicker.js']
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        },
                        {
                            name: 'ui.select',
                            files: ['js/plugins/ui-select/select.min.js', 'css/plugins/ui-select/select.min.css']
                        },
                        {
                            name: 'summernote',
                            files: ['css/plugins/summernote/summernote.css', 'css/plugins/summernote/summernote-bs3.css', 'js/plugins/summernote/summernote.min.js', 'js/plugins/summernote/angular-summernote.min.js']
                        }
                    ]);
                }
            }
        })
        .state("job.manageVacancy", {
            url: '/manageVacancy',
            templateUrl: 'app/components/Job/View/manageVacancy.html',
            controller: 'manageVacancyController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Job/Config/SearchVacancies.json").success(function (data) { return data; });
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
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        },
                        {
                            name: 'ui.switchery',
                            files: ['css/plugins/switchery/switchery.css', 'js/plugins/switchery/switchery.js', 'js/plugins/switchery/ng-switchery.js']
                        },
                        {
                            name: 'datePicker',
                            files: ['css/plugins/datapicker/angular-datapicker.css', 'js/plugins/datapicker/angular-datepicker.js']
                        },
                        {
                            files: ['css/plugins/dropzone/basic.css', 'css/plugins/dropzone/dropzone.css', 'js/plugins/dropzone/dropzone.js']
                        },
                        {
                            files: ['js/plugins/jasny/jasny-bootstrap.min.js', 'css/plugins/jasny/jasny-bootstrap.min.css']
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        }
                    ]);
                }
            }
        })

        //country Routes starts
        .state('country', {
            abstract: true,
            url: "/country",
            templateUrl: "views/common/content.html",
            controller: "dashboardController",
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
                    return apiCall.get(APP_CONSTANTS.URL.COUNTRY.GETALLCOUNTRIESURL + "?$filter=isDeleted eq false", {})
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
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        },
                        {
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        }
                    ]);
                }
            }
        })
        //country Routes Ends

        //candidate Routes starts
        .state('candidate', {
            abstract: true,
            url: "/candidate",
            templateUrl: "views/common/content.html",
            controller: "dashboardController",
        })
        .state("candidate.manageCandidate", {
            url: '/manageCandidate',
            templateUrl: 'app/components/candidate/view/manageCandidate.html',
            controller: 'createCandidateController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/candidate/config/ManageCandidate.json").success(function (data) { return data; });
                },

                AppCoutries: function (apiCall, APP_CONSTANTS) {
                    return apiCall.get(APP_CONSTANTS.URL.APP.GETCOUNTRYURL, {})
                        .then(function (data) {
                            return data;
                        });

                },
                formAction: function () { return "Manage"; },
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
                            name: 'ui.select',
                            files: ['js/plugins/ui-select/select.min.js', 'css/plugins/ui-select/select.min.css']
                        },
                        {
                            files: ['css/plugins/dropzone/basic.css', 'css/plugins/dropzone/dropzone.css', 'js/plugins/dropzone/dropzone.js']
                        },
                        {
                            files: ['js/plugins/jasny/jasny-bootstrap.min.js', 'css/plugins/jasny/jasny-bootstrap.min.css']
                        },
                        {
                            serie: true,
                            files: ['js/plugins/daterangepicker/daterangepicker.js', 'css/plugins/daterangepicker/daterangepicker-bs3.css']
                        },
                        {
                            name: 'daterangepicker',
                            files: ['js/plugins/daterangepicker/angular-daterangepicker.js']
                        },
                        {
                            name: 'datePicker',
                            files: ['css/plugins/datapicker/angular-datapicker.css', 'js/plugins/datapicker/angular-datepicker.js']
                        }, {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        },
                        {
                            files: ['css/plugins/clockpicker/clockpicker.css', 'js/plugins/clockpicker/clockpicker.js']
                        }
                    ]);
                }
            }
        })
        .state("candidate.create", {
            url: '/create',
            templateUrl: 'app/components/candidate/view/manageCandidate.html',
            controller: 'createCandidateController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/candidate/config/ManageCandidate.json").success(function (data) { return data; });
                },

                AppCoutries: function (apiCall, APP_CONSTANTS) {
                    return apiCall.get(APP_CONSTANTS.URL.APP.GETCOUNTRYURL, {})
                        .then(function (data) {
                            return data;
                        });

                },
                formAction: function () { return "Create"; },
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
                            name: 'ui.select',
                            files: ['js/plugins/ui-select/select.min.js', 'css/plugins/ui-select/select.min.css']
                        },
                        {
                            files: ['css/plugins/dropzone/basic.css', 'css/plugins/dropzone/dropzone.css', 'js/plugins/dropzone/dropzone.js']
                        },
                        {
                            files: ['js/plugins/jasny/jasny-bootstrap.min.js', 'css/plugins/jasny/jasny-bootstrap.min.css']
                        },
                        {
                            serie: true,
                            files: ['js/plugins/daterangepicker/daterangepicker.js', 'css/plugins/daterangepicker/daterangepicker-bs3.css']
                        },
                        {
                            name: 'daterangepicker',
                            files: ['js/plugins/daterangepicker/angular-daterangepicker.js']
                        },
                        {
                            name: 'datePicker',
                            files: ['css/plugins/datapicker/angular-datapicker.css', 'js/plugins/datapicker/angular-datepicker.js']
                        }, {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        },
                        {
                            files: ['css/plugins/clockpicker/clockpicker.css', 'js/plugins/clockpicker/clockpicker.js']
                        }
                    ]);
                }
            }
        })

        .state("candidate.edit", {
            url: '/edit',
            templateUrl: 'app/components/candidate/view/manageCandidate.html',
            controller: 'createCandidateController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/candidate/config/ManageCandidate.json").success(function (data) { return data; });
                },

                AppCoutries: function (apiCall, APP_CONSTANTS) {
                    return apiCall.get(APP_CONSTANTS.URL.APP.GETCOUNTRYURL, {})
                        .then(function (data) {
                            return data;
                        });

                },
                formAction: function () { return "Update"; },
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
                            name: 'ui.select',
                            files: ['js/plugins/ui-select/select.min.js', 'css/plugins/ui-select/select.min.css']
                        },
                        {
                            files: ['css/plugins/dropzone/basic.css', 'css/plugins/dropzone/dropzone.css', 'js/plugins/dropzone/dropzone.js']
                        },
                        {
                            files: ['js/plugins/jasny/jasny-bootstrap.min.js', 'css/plugins/jasny/jasny-bootstrap.min.css']
                        },
                        {
                            serie: true,
                            files: ['js/plugins/daterangepicker/daterangepicker.js', 'css/plugins/daterangepicker/daterangepicker-bs3.css']
                        },
                        {
                            name: 'daterangepicker',
                            files: ['js/plugins/daterangepicker/angular-daterangepicker.js']
                        },
                        {
                            name: 'datePicker',
                            files: ['css/plugins/datapicker/angular-datapicker.css', 'js/plugins/datapicker/angular-datepicker.js']
                        }
                    ]);
                }
            }
        })
        .state("candidate.manageSubmission", {
            url: '/manageSubmission',
            templateUrl: 'app/components/candidate/view/manageCandidateSubmission.html',
            controller: 'manageCandidateSubmissionController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/candidate/config/manageCandidateSubmission.json").success(function (data) { return data; });
                },
                formAction: function () { return "Create"; },
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
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        },
                        {
                            name: 'ui.switchery',
                            files: ['css/plugins/switchery/switchery.css', 'js/plugins/switchery/switchery.js', 'js/plugins/switchery/ng-switchery.js']
                        },
                        {
                            name: 'datePicker',
                            files: ['css/plugins/datapicker/angular-datapicker.css', 'js/plugins/datapicker/angular-datepicker.js']
                        }, {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        }
                    ]);
                }
            }
        })
        .state("candidate.candidateSubmission", {
            url: '/candidateSubmission',
            templateUrl: 'app/components/candidate/view/candidateSubmission.html',
            controller: 'candidateSubmissionController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/candidate/config/manageCandidateSubmission.json").success(function (data) { return data; });
                },
                candidateStatusList: function (apiCall, APP_CONSTANTS) {
                    return apiCall.get(APP_CONSTANTS.URL.CANDIDATESUBMISSIONURL.GETCANDIDATESTATUS).then(function (data) { return data; });
                },
                AppIndustries: function (apiCall, APP_CONSTANTS) {
                    return apiCall.get(APP_CONSTANTS.URL.INDUSTRY.GETALLINDUSTRIESURL + "?$filter=isDeleted eq false", {})
                        .then(function (data) {
                            return data;
                        });
                    return {};
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
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        },
                        {
                            name: 'ui.switchery',
                            files: ['css/plugins/switchery/switchery.css', 'js/plugins/switchery/switchery.js', 'js/plugins/switchery/ng-switchery.js']
                        },
                        {
                            name: 'datePicker',
                            files: ['css/plugins/datapicker/angular-datapicker.css', 'js/plugins/datapicker/angular-datepicker.js']
                        }, {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        },
                        {
                            name: 'ui.select',
                            files: ['js/plugins/ui-select/select.min.js', 'css/plugins/ui-select/select.min.css']
                        },
                        {
                            files: ['css/plugins/dropzone/basic.css', 'css/plugins/dropzone/dropzone.css', 'js/plugins/dropzone/dropzone.js']
                        },
                        {
                            files: ['js/plugins/jasny/jasny-bootstrap.min.js', 'css/plugins/jasny/jasny-bootstrap.min.css']
                        }

                    ]);
                }
            }
        })
        .state("candidate.appointment", {
            url: '/appointment',
            templateUrl: 'app/components/candidate/view/candidateSubmissionAppointment.html',
            controller: 'candidateSubmissionAppointmentController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/candidate/config/manageCandidateSubmissionAppointment.json").success(function (data) { return data; });
                },
                formAction: function () { return "Create"; },
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
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        },
                        {
                            name: 'ui.switchery',
                            files: ['css/plugins/switchery/switchery.css', 'js/plugins/switchery/switchery.js', 'js/plugins/switchery/ng-switchery.js']
                        },
                        {
                            name: 'datePicker',
                            files: ['css/plugins/datapicker/angular-datapicker.css', 'js/plugins/datapicker/angular-datepicker.js']
                        }, {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
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
            controller: "dashboardController",

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
                    return apiCall.get(APP_CONSTANTS.URL.INDUSTRY.GETALLINDUSTRIESURL + "?$filter=isDeleted eq false", {})
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
                        },
                        {
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        },
                        {
                            name: 'ui.select',
                            files: ['js/plugins/ui-select/select.min.js', 'css/plugins/ui-select/select.min.css']
                        }
                    ]);
                }
            }
        })
        //industry Routes Ends

        //role Routes starts
        .state('role', {
            abstract: true,
            url: "/role",
            templateUrl: "views/common/content.html",
            controller: "dashboardController",
        })
        .state("role.manageRoleGroup", {
            url: '/manageRoleGroup',
            templateUrl: 'app/components/Roles/view/manageRoleGroups.html',
            controller: 'manageRolesController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Roles/Config/ManageRoles.json").success(function (data) { return data; });
                },
                formAction: function () { return "Create"; },
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
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        },
                        {
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        }
                    ]);
                }
            }
        })
        .state("role.manageRole", {
            url: '/manageRole',
            templateUrl: 'app/components/Roles/view/manageRoles.html',
            controller: 'manageRolesController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Roles/Config/ManageRoles.json").success(function (data) { return data; });
                },
                formAction: function () { return "Create"; },
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
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        },
                        {
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        }
                    ]);
                }
            }
        })
        .state("role.manageUserRole", {
            url: '/manageUserRole',
            templateUrl: 'app/components/Roles/view/manageUserRole.html',
            controller: 'manageUserRoleController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Roles/Config/ManageUserRoles.json").success(function (data) { return data; });
                },
                formAction: function () { return "Create"; },
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
                        },
                        {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        },
                        {
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        },
                        {
                            name: 'ui.select',
                            files: ['js/plugins/ui-select/select.min.js', 'css/plugins/ui-select/select.min.css']
                        }
                    ]);
                }
            }
        })

        //Appointment
        
        .state('appointment', {
            abstract: true,
            url: "/appointment",
            templateUrl: "views/common/content.html",
            controller: "dashboardController",
        })
        .state("appointment.manageAppointment", {
            url: '/manageAppointment',
            templateUrl: 'app/components/Appointment/view/manageAppointment.html',
            controller: 'manageAppointmentController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/Appointment/config/manageCandidateSubmissionAppointment.json").success(function (data) { return data; });
                },
                AppointmentList: function (apiCall, localStorageService, APP_CONSTANTS) {
                    var id = localStorageService.get('createSubmissionId');
                    return apiCall.post(APP_CONSTANTS.URL.APPOINTMENT.GETALLAPPOINTMENTURL+id, {})
                        .then(function (data) {
                            return data;
                        });
                },
                AppUsers: function (apiCall, APP_CONSTANTS) {
                    return apiCall.get(APP_CONSTANTS.URL.USER.GETALLCUSERSURL, {})
                        .then(function (data) {
                            return data;
                        });
                },
                AppAppointmentTypes: function (apiCall, APP_CONSTANTS) {
                    return apiCall.get(APP_CONSTANTS.URL.APPOINTMENT.GETALLAPPOINTMENTTYPEURL, {})
                        .then(function (data) {
                            return data;
                        });
                },
                AppAppointmentStatus: function (apiCall, APP_CONSTANTS) {
                    return apiCall.get(APP_CONSTANTS.URL.APPOINTMENT.GETALLAPPOINTMENTSTATUSURL, {})
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
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        },
                        {
                            name: 'ui.switchery',
                            files: ['css/plugins/switchery/switchery.css', 'js/plugins/switchery/switchery.js', 'js/plugins/switchery/ng-switchery.js']
                        },
                        {
                            name: 'datePicker',
                            files: ['css/plugins/datapicker/angular-datapicker.css', 'js/plugins/datapicker/angular-datepicker.js']
                        }, {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        },
                        {
                            files: ['css/plugins/clockpicker/clockpicker.css', 'js/plugins/clockpicker/clockpicker.js']
                        },
                        {
                            name: 'ui.select',
                            files: ['js/plugins/ui-select/select.min.js', 'css/plugins/ui-select/select.min.css']
                        },
                        {
                            name: 'daterangepicker',
                            files: ['js/plugins/daterangepicker/angular-daterangepicker.js']
                        }, {
                            serie: true,
                            files: ['js/plugins/daterangepicker/daterangepicker.js', 'css/plugins/daterangepicker/daterangepicker-bs3.css']
                        }
                    ]);
                }
            }
        })

        //payperiod
        .state('payperiod', {
            abstract: true,
            url: "/payperiod",
            templateUrl: "views/common/content.html",
            controller: "dashboardController",
        })
        .state("payperiod.managePayperiod", {
            url: '/managePayperiod',
            templateUrl: 'app/components/payPeriod/view/managePayPeriod.html',
            controller: 'managePayPeriodController',
            resolve: {
                configJSON: function ($http) {
                    return $http.get("app/components/payPeriod/config/payPeriod.json").success(function (data) { return data; });
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
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        },
                        {
                            name: 'ui.switchery',
                            files: ['css/plugins/switchery/switchery.css', 'js/plugins/switchery/switchery.js', 'js/plugins/switchery/ng-switchery.js']
                        },
                        {
                            name: 'datePicker',
                            files: ['css/plugins/datapicker/angular-datapicker.css', 'js/plugins/datapicker/angular-datepicker.js']
                        }, {
                            insertBefore: '#loadBefore',
                            name: 'toaster',
                            files: ['js/plugins/toastr/toastr.min.js', 'css/plugins/toastr/toastr.min.css']
                        },
                        {
                            files: ['css/plugins/clockpicker/clockpicker.css', 'js/plugins/clockpicker/clockpicker.js']
                        },
                        {
                            name: 'ui.select',
                            files: ['js/plugins/ui-select/select.min.js', 'css/plugins/ui-select/select.min.css']
                        },
                        {
                            name: 'daterangepicker',
                            files: ['js/plugins/daterangepicker/angular-daterangepicker.js']
                        }, {
                            serie: true,
                            files: ['js/plugins/daterangepicker/daterangepicker.js', 'css/plugins/daterangepicker/daterangepicker-bs3.css']
                        }
                    ]);
                }
            }
        })

        //country Routes Ends
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




