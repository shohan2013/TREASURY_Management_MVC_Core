var app = angular.module("App", ['angularUtils.directives.dirPagination']);

app.controller("Ctl", function ($scope, $window, $http) {
    $scope.isLoading = false;

    $scope.StatusList = function () {
        $http({
            method: "get",
            url: "/Common/GetStatusData"
        }).then(function (response) {
            $scope.statuslist = response.data;
        });
    };


    $scope.GetData = function () {
        $http({
            method: "get",
            url: "/InterestCalculationApproval/GetApprovalData",
            params: { statusid: $("#statusid").val()}
        }).then(function (response) {
            $scope.list = null;
            $scope.list = response.data;
        });
    };

    $scope.Rejected = function (id, index) {
        if (confirm('Are You Sure? You Want to Reject this Record.') == true) {

            $http({
                method: "POST",
                url: "/InterestCalculationApproval/Rejected",
                params: { id: id, remarks: $('#description' + index).val() }
            }).then(function (response) {
                notify('success', 'Success Message', response.data.trim());
                $scope.GetData();
            });
        }
        else {

        }
    };

    $scope.Approved = function (id, index) {
        if (confirm('Are You Sure? You Want to Approve this Record.') == true) {
            $http({
                method: "POST",
                url: "/InterestCalculationApproval/Approve",
                params: { id: id, remarks: $('#description' + index).val() }
            }).then(function (response) {
                console.log(response);
                notify('success', 'Success Message', response.data.trim());
                $scope.GetData();
            });
        }
        else {

        }
    };
});
