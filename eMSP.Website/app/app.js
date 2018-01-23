/**
 * INSPINIA - Responsive Admin Theme
 *
 */
(function () {
    angular.module('eMSPApp', [
        'ui.router',                    // Routing
        'oc.lazyLoad',                  // ocLazyLoad
        'ui.bootstrap',                 // Ui Bootstrap
        'pascalprecht.translate',       // Angular Translate
        'ngIdle',                       // Idle timer
        'ngSanitize',                   // ngSanitize
        'LocalStorageModule',
        'ngLetterAvatar'                // Letter Avathar
        //'daterangepicker'
    ])
})();

// Other libraries are loaded dynamically in the config.js file using the library ocLazyLoad