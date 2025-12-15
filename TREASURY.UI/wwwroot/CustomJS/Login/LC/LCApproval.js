var app = angular.module("App", ['angularUtils.directives.dirPagination']);

app.controller("Ctl", function ($scope, $window, $http) {
    //$scope.loading = true;
    $scope.StatusList = function () {
        $http({
            method: "get",
            url: "/AgreementApproval/GetStatusData"
        }).then(function (response) {
            //console.log(response);
            $scope.statuslist = response.data;
        });
    };

    $scope.LCList = function () {
            $http({
                method: "get",
                url: "/LCApproval/GetLCPending",
                params: { statusid: $scope.statusid }
            }).then(function (response) {
                console.log(response.data);
                $scope.LClist = response.data;
                //$scope.loading = false;
            });
    };

    $scope.Rejected = function (id, index) {
        if (confirm('Are You Sure? You Want to Reject this Record.') == true) {

            $http({
                method: "POST",
                url: "/LCApproval/Rejected",
                params: { id: id, remarks: $('#description' + index).val()}
            }).then(function (response) {
                notify('success', 'Success Message', response.data.trim());
                $scope.LCList();
            });
        }
        else {

        }
    };

    $scope.Approved = function (id, index) {
        if (confirm('Are You Sure? You Want to Approve this Record.') == true) {
            $http({
                method: "POST",
                url: "/LCApproval/Approve",
                params: { id: id, remarks: $('#description' + index).val()}
            }).then(function (response) {
                console.log(response);
                notify('success', 'Success Message', response.data.trim());
                $scope.LCList();
            });
        }
        else {

        }
    };

    $scope.ViewCData = function (ID) {
        $scope.ID = ID;
        $http({
            method: "GET",
            url: '/LCApproval/ViewCData',
            params: { id: $scope.ID }
        }).success(function (data) {
            $scope.LClistView = data;
        });

        //$scope.LoadDocument(ID);
        //$scope.ViewByDetailsID(ID);
    };

    $scope.sortBy = function (column) {
        $scope.sortColumn = column;
        $scope.reverse = !$scope.reverse;
    }

    $scope.LoadDocument = function (ID) {
        $scope.ID = ID;
        $http({
            method: "GET",
            url: '/SalesQuatationApproval/LoadDocument',
            params: { id: $scope.ID, }
        }).success(function (result) {
            console.log();
            $scope.imageitem = result;
        });
    }
    $scope.Download = function (ID) {
        $scope.ID = ID;
        $http({
            method: "GET",
            url: '/SalesQuatationApproval/Download',
            params: { id: $scope.ID, }
        }).success(function (result) {
            $scope.imageitem = result;
        });
    }
    //$scope.LoadImge = function () {
    //    $window.open('ftp://10.35.117.134/Screenshot.png', 'C-Sharpcorner', 'width=500,height=400');
    //    //$window.open("file://///10.35.117.134/FTProot/Screenshot.png", '', "scrollbars=yes,toolbar=0,height=550,width=850,top=200,left=300, resizable=yes, title=Preview");
    //}

});