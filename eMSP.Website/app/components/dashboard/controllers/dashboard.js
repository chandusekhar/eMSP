'use strict';
angular.module('eMSPApp').controller("dashboardController", ['$scope', '$http', 'authService', 'localStorageService', '$location', 'apiCall', 'APP_CONSTANTS', function ($scope, $http, authService, localStorageService,$location, apiCall, APP_CONSTANTS) {

    $scope.config = localStorageService.get('pageSettings');

    if (authService.authentication.isAuth) {
        $scope.userName = authService.authentication.userName;
    } else {
        authService.logOut();
        $location.path('/login');
    }
    var data1 = [
        [gd(2012, 1, 1), 7],
        [gd(2012, 1, 2), 6],
        [gd(2012, 1, 3), 4],
        [gd(2012, 1, 4), 8],
        [gd(2012, 1, 5), 9],
        [gd(2012, 1, 6), 7],
        [gd(2012, 1, 7), 5],
        [gd(2012, 1, 8), 4],
        [gd(2012, 1, 9), 7],
        [gd(2012, 1, 10), 8],
        [gd(2012, 1, 11), 9],
        [gd(2012, 1, 12), 6],
        [gd(2012, 1, 13), 4],
        [gd(2012, 1, 14), 5],
        [gd(2012, 1, 15), 11],
        [gd(2012, 1, 16), 8],
        [gd(2012, 1, 17), 8],
        [gd(2012, 1, 18), 11],
        [gd(2012, 1, 19), 11],
        [gd(2012, 1, 20), 6],
        [gd(2012, 1, 21), 6],
        [gd(2012, 1, 22), 8],
        [gd(2012, 1, 23), 11],
        [gd(2012, 1, 24), 13],
        [gd(2012, 1, 25), 7],
        [gd(2012, 1, 26), 9],
        [gd(2012, 1, 27), 9],
        [gd(2012, 1, 28), 8],
        [gd(2012, 1, 29), 5],
        [gd(2012, 1, 30), 8],
        [gd(2012, 1, 31), 25]
    ];

    var data2 = [
        [gd(2012, 1, 1), 800],
        [gd(2012, 1, 2), 500],
        [gd(2012, 1, 3), 600],
        [gd(2012, 1, 4), 700],
        [gd(2012, 1, 5), 500],
        [gd(2012, 1, 6), 456],
        [gd(2012, 1, 7), 800],
        [gd(2012, 1, 8), 589],
        [gd(2012, 1, 9), 467],
        [gd(2012, 1, 10), 876],
        [gd(2012, 1, 11), 689],
        [gd(2012, 1, 12), 700],
        [gd(2012, 1, 13), 500],
        [gd(2012, 1, 14), 600],
        [gd(2012, 1, 15), 700],
        [gd(2012, 1, 16), 786],
        [gd(2012, 1, 17), 345],
        [gd(2012, 1, 18), 888],
        [gd(2012, 1, 19), 888],
        [gd(2012, 1, 20), 888],
        [gd(2012, 1, 21), 987],
        [gd(2012, 1, 22), 444],
        [gd(2012, 1, 23), 999],
        [gd(2012, 1, 24), 567],
        [gd(2012, 1, 25), 786],
        [gd(2012, 1, 26), 666],
        [gd(2012, 1, 27), 888],
        [gd(2012, 1, 28), 900],
        [gd(2012, 1, 29), 178],
        [gd(2012, 1, 30), 555],
        [gd(2012, 1, 31), 993]
    ];

    var dataset = [
        {
            label: "Number of orders",
            grow: { stepMode: "linear" },
            data: data2,
            color: "#1ab394",
            bars: {
                show: true,
                align: "center",
                barWidth: 24 * 60 * 60 * 600,
                lineWidth: 0
            }

        },
        {
            label: "Payments",
            grow: { stepMode: "linear" },
            data: data1,
            yaxis: 2,
            color: "#1C84C6",
            lines: {
                lineWidth: 1,
                show: true,
                fill: true,
                fillColor: {
                    colors: [
                        {
                            opacity: 0.2
                        },
                        {
                            opacity: 0.2
                        }
                    ]
                }
            }
        }
    ];


    var options = {
        grid: {
            hoverable: true,
            clickable: true,
            tickColor: "#d5d5d5",
            borderWidth: 0,
            color: '#d5d5d5'
        },
        colors: ["#1ab394", "#464f88"],
        tooltip: true,
        xaxis: {
            mode: "time",
            tickSize: [3, "day"],
            tickLength: 0,
            axisLabel: "Date",
            axisLabelUseCanvas: true,
            axisLabelFontSizePixels: 12,
            axisLabelFontFamily: 'Arial',
            axisLabelPadding: 10,
            color: "#d5d5d5"
        },
        yaxes: [
            {
                position: "left",
                max: 1070,
                color: "#d5d5d5",
                axisLabelUseCanvas: true,
                axisLabelFontSizePixels: 12,
                axisLabelFontFamily: 'Arial',
                axisLabelPadding: 3
            },
            {
                position: "right",
                color: "#d5d5d5",
                axisLabelUseCanvas: true,
                axisLabelFontSizePixels: 12,
                axisLabelFontFamily: ' Arial',
                axisLabelPadding: 67
            }
        ],
        legend: {
            noColumns: 1,
            labelBoxBorderColor: "#d5d5d5",
            position: "nw"
        }

    };

    function gd(year, month, day) {
        return new Date(year, month - 1, day).getTime();
    }

    /**
     * Options for Bar chart
     */
    this.barOptions = {
        scaleBeginAtZero: true,
        scaleShowGridLines: true,
        scaleGridLineColor: "rgba(0,0,0,.05)",
        scaleGridLineWidth: 1,
        barShowStroke: true,
        barStrokeWidth: 2,
        barValueSpacing: 5,
        barDatasetSpacing: 1
    };

    /**
     * Data for Bar chart
     */
    this.barData = {
        labels: ["January", "February", "March", "April", "May", "June", "July"],
        datasets: [
            {
                label: "My First dataset",
                fillColor: "rgba(220,220,220,0.5)",
                strokeColor: "rgba(220,220,220,0.8)",
                highlightFill: "rgba(220,220,220,0.75)",
                highlightStroke: "rgba(220,220,220,1)",
                data: [65, 59, 80, 81, 56, 55, 40]
            }
        ]
    };
    this.barData3 = {
        labels: ["January", "February", "March", "April", "May", "June", "July"],
        datasets: [
            {
                label: "My First dataset",
                fillColor: "rgba(20,220,20,0.5)",
                strokeColor: "rgba(20,220,20,0.8)",
                highlightFill: "rgba(20,220,20,0.75)",
                highlightStroke: "rgba(20,220,20,1)",
                data: [65, 59, 80, 81, 56, 55, 40]
            }
        ]
    };
    this.barData2 = {
        labels: ["January", "February", "March", "April", "May", "June", "July"],
        datasets: [
            {
                label: "My First dataset",
                fillColor: "rgba(101,221,221,0.5)",
                strokeColor: "rgba(101,221,221,0.8)",
                highlightFill: "rgba(1011,221,221,0.75)",
                highlightStroke: "rgba(101,221,221,1)",
                data: [65, 59, 80, 81, 56, 55, 40]
            }
        ]
    };

    this.doughnutData = [
        {
            value: 300,
            color: "#a3e1d4",
            highlight: "#1ab394",
            label: "Customer1"
        },
        {
            value: 300,
            color: "orange",
            highlight: "#1ab394",
            label: "Customer2"
        },{
            value: 50,
            color: "#dedede",
            highlight: "#1ab394",
            label: "Customer3"
        }
    ];
    this.doughnutData2 = [
        {
            value: 300,
            color: "red",
            highlight: "#1ab394",
            label: "Active"
        },
        {
            value: 50,
            color: "#dedede",
            highlight: "#1ab394",
            label: "InActive"
        }
    ];
    this.doughnutData3 = [
        {
            value: 300,
            color: "yellow",
            highlight: "#1ab394",
            label: "Supplier1"
        },
        {
            value: 50,
            color: "brown",
            highlight: "#1ab394",
            label: "supplier2"
        }, {
            value: 300,
            color: "green",
            highlight: "#1ab394",
            label: "Supplier3"
        },
        {
            value: 50,
            color: "red",
            highlight: "#1ab394",
            label: "supplier4"
        }
    ];
    /**
     * Options for Doughnut chart
     */
    this.doughnutOptions = {
        segmentShowStroke: true,
        segmentStrokeColor: "#fff",
        segmentStrokeWidth: 2,
        percentageInnerCutout: 45, // This is 0 for Pie charts
        animationSteps: 100,
        animationEasing: "easeOutBounce",
        animateRotate: true,
        animateScale: false
    };

    /**
     * Definition of variables
     * Flot chart
     */
    this.flotData = dataset;
    this.flotOptions = options;
    //var apires = apiCall.post(APP_CONSTANTS.URL.ROLE.GETUSERROLESURL);
    //apires.then(function (data) {
    //    console.log(data);
    //    $scope.userRoles = data;
    //});
    
    //var apires = apiCall.post(APP_CONSTANTS.URL.USER.GETUSERBYNAMEURL + authService.authentication.userName, { "name": authService.authentication.userName});
    //apires.then(function (data) {
    //    console.log(data);
    //    $scope.userDate = data;
    //});


    //setTimeout(function () {
    //    toastr.options = {
    //        closeButton: true,
    //        progressBar: true,
    //        showMethod: 'slideDown',
    //        timeOut: 4000
    //    };
    //    toastr.success('Responsive Admin Theme', 'Welcome to INSPINIA');

    //}, 1300);


    //var data1 = [
    //    [0, 4], [1, 8], [2, 5], [3, 10], [4, 4], [5, 16], [6, 5], [7, 11], [8, 6], [9, 11], [10, 30], [11, 10], [12, 13], [13, 4], [14, 3], [15, 3], [16, 6]
    //];
    //var data2 = [
    //    [0, 1], [1, 0], [2, 2], [3, 0], [4, 1], [5, 3], [6, 1], [7, 5], [8, 2], [9, 3], [10, 2], [11, 1], [12, 0], [13, 2], [14, 8], [15, 0], [16, 0]
    //];
    //$("#flot-dashboard-chart").length && $.plot($("#flot-dashboard-chart"), [
    //    data1, data2
    //],
    //        {
    //            series: {
    //                lines: {
    //                    show: false,
    //                    fill: true
    //                },
    //                splines: {
    //                    show: true,
    //                    tension: 0.4,
    //                    lineWidth: 1,
    //                    fill: 0.4
    //                },
    //                points: {
    //                    radius: 0,
    //                    show: true
    //                },
    //                shadowSize: 2
    //            },
    //            grid: {
    //                hoverable: true,
    //                clickable: true,
    //                tickColor: "#d5d5d5",
    //                borderWidth: 1,
    //                color: '#d5d5d5'
    //            },
    //            colors: ["#1ab394", "#1C84C6"],
    //            xaxis: {
    //            },
    //            yaxis: {
    //                ticks: 4
    //            },
    //            tooltip: false
    //        }
    //);

    //var doughnutData = {
    //    labels: ["App", "Software", "Laptop"],
    //    datasets: [{
    //        data: [300, 50, 100],
    //        backgroundColor: ["#a3e1d4", "#dedede", "#9CC3DA"]
    //    }]
    //};


    //var doughnutOptions = {
    //    responsive: false,
    //    legend: {
    //        display: false
    //    }
    //};


    //var ctx4 = document.getElementById("doughnutChart").getContext("2d");
    //new Chart(ctx4, { type: 'doughnut', data: doughnutData, options: doughnutOptions });

    //var doughnutData = {
    //    labels: ["App", "Software", "Laptop"],
    //    datasets: [{
    //        data: [70, 27, 85],
    //        backgroundColor: ["#a3e1d4", "#dedede", "#9CC3DA"]
    //    }]
    //};


    //var doughnutOptions = {
    //    responsive: false,
    //    legend: {
    //        display: false
    //    }
    //};


    //var ctx4 = document.getElementById("doughnutChart2").getContext("2d");
    //new Chart(ctx4, { type: 'doughnut', data: doughnutData, options: doughnutOptions });

    //$(".bar_dashboard").peity("bar", {
    //    fill: ["#1ab394", "#d7d7d7"],
    //    width: 100
    //});

    //var updatingChart = $(".updating-chart").peity("line", { fill: '#1ab394', stroke: '#169c81', width: 64 })

    //setInterval(function () {
    //    var random = Math.round(Math.random() * 10)
    //    var values = updatingChart.text().split(",")
    //    values.shift()
    //    values.push(random)

    //    updatingChart
    //        .text(values.join(","))
    //        .change()
    //}, 1000);

    //$("#sparkline8").sparkline([5, 6, 7, 2, 0, 4, 2, 4, 5, 7, 2, 4, 12, 14, 4, 2, 14, 12, 7], {
    //    type: 'bar',
    //    barWidth: 8,
    //    height: '150px',
    //    barColor: '#1ab394',
    //    negBarColor: '#c6c6c6'
    //});

}]);