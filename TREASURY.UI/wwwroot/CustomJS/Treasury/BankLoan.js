var app = angular.module("App", ['angularUtils.directives.dirPagination']);

app.controller("Ctl", function ($scope, $window, $http) {

    $scope.loading = true;

    $scope.GetData = function (lunitid) {
        $http({
            method: "get",
            url: "BankLoan/GetData",
            params: { 'unitid': lunitid }
        }).then(function (response) {
            console.log(response);
            $scope.list = response.data;
            $scope.loading = false;
        });
    };

    $scope.GetLoanType = function () {
        $http({
            method: "get",
            url: "Common/GetLoanType",
        }).then(function (response) {
            console.log(response);
            $scope.loantypelist = response.data;
        });
    };

    $scope.GetCurrency = function () {
        $http({
            method: "get",
            url: "Common/GetCurrency",
        }).then(function (response) {
            console.log(response);
            $scope.currencylist = response.data;
        });
    };


    $scope.ViewMaster = function (sanctionno) {
        ViewImageFromAPI(sanctionno);
    };


    $scope.Edit = function (id) {
        $http({
            method: "get",
            url: "BankLoan/GetDataByID",
            params: { 'id': id }
        }).then(function (response) {
            $('#eid').val(response.data[0].id);
            $('#ebankid').val(response.data[0].lenderbankid);
            $('#eborrowerunitid').val(response.data[0].borrowerunitid);
            $('#eloantypeid').val(response.data[0].loantypeid);
            $('#etxtLoanAmt').val(response.data[0].loanamount);
            $('#ecurrencyid').val(response.data[0].currencyid);
            $('#etxtConrate').val(response.data[0].conrate);
            $('#etxtIssueDate').val(response.data[0].issuedate);
            $('#etxtMaturityDate').val(response.data[0].maturitydate);
            $('#etxtInterestRate').val(response.data[0].interestrate);
            $('#etxtLoanNumber').val(response.data[0].loannumber);
            $('#etxtNarration').val(response.data[0].narration);
        });
    };


    $scope.LoadData = function () {
        $scope.GetData($scope.unitid);
    };

    $scope.GetBankInfoByUnit = function () {
        $http({
            method: "get",
            url: "Common/GetBankInfoByUnit",
            params: { 'unitid': $scope.leadunitid }
        }).then(function (response) {
            $scope.banklist = response.data;
        });
    };

    $scope.GetUnit = function () {
        $http({
            method: "get",
            url: "Common/GetUnit",
        }).then(function (response) {
            $scope.unitlist = response.data;
        });
    };

 

    $scope.Clear = function () {
            $('#bankid').val('0'),
            $('#borrowerunitid').val('0'),
            $('#loantypeid').val('0'),
            $('#txtLoanAmt').val('0'),
            $('#currencyid').val('0'),
            $('#txtConrate').val('0'),
            $('#txtIssueDate').val(''),
            $('#txtMaturityDate').val(''),
            $('#txtInterestRate').val('0'),
            $('#txtLoanNumber').val(''),
            $('#txtNarration').val('')

    }

    $scope.DeleteMaster = function (id) {
        $.ajax({
            type: 'POST',
            url: "/BankLoan/DeleteMaster",
            dataType: "json",
            data: { 'id': id },
            success: function (result) {
                notify(result.item2.trim(), 'Message', result.item1.trim());
                $scope.GetData($scope.unitid);
            },
            error: function (errormessage) {
                notify('error', 'Error Message', errormessage.responseText);
            }
        });
    }



    $scope.Save = function () {
        isAllValid = true;
        var Details = [];

        if ($("#leadunitid").val() === "") {
            isAllValid = false;
            $("#leadunitid").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#leadunitid").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#borrowerunitid").val() === "") {
            isAllValid = false;
            $("#borrowerunitid").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#borrowerunitid").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#loantypeid").val() === "") {
            isAllValid = false;
            $("#loantypeid").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#loantypeid").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#txtLoanAmt").val() === "") {
            isAllValid = false;
            $("#txtLoanAmt").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#txtLoanAmt").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#currencyid").val() === "") {
            isAllValid = false;
            $("#currencyid").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#currencyid").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#txtIssueDate").val() === "") {
            isAllValid = false;
            $("#txtIssueDate").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#txtIssueDate").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#txtMaturityDate").val() === "") {
            isAllValid = false;
            $("#txtMaturityDate").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#txtMaturityDate").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#txtInterestRate").val() === "") {
            isAllValid = false;
            $("#txtInterestRate").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#txtInterestRate").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#txtLoanNumber").val() === "") {
            isAllValid = false;
            $("#txtLoanNumber").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#txtLoanNumber").siblings('span.error').css('visibility', 'hidden');
        }


        if (isAllValid) {
            var master = {
                LENDERBANKID: $('#bankid').val(),
                BORROWERUNITID: $('#borrowerunitid').val(),
                LOANTYPEID: $('#loantypeid').val(),
                LOANAMOUNT: $('#txtLoanAmt').val(),
                CURRENCYID: $('#currencyid').val(),
                CONRATE: $('#txtConrate').val(),
                ISSUEDATE: $('#txtIssueDate').val(),
                MATURITYDATE: $('#txtMaturityDate').val(),
                INTERESTRATE: $('#txtInterestRate').val(),
                LOANNUMBER: $('#txtLoanNumber').val(),
                NARRATION: $('#txtNarration').val()
            }

            if (isAllValid) {
                $.ajax({
                    type: 'POST',
                    url: "/BankLoan/Save",
                    dataType: "json",
                    data: { 'master': master, },
                    success: function (result) {
                        $scope.GetData();

                        notify(result.item2.trim(), 'Message', result.item1.trim());
                        $scope.Clear();
                        UploadFileUsingAPI(result.item1);
                    },
                    error: function (errormessage) {
                        notify('error', 'Error Message', errormessage.responseText);
                    }
                });
            }

        }
    }

    $scope.Update = function () {
        isAllValid = true;
        var Details = [];


        if ($("#elenderunitid").val() === "") {
            isAllValid = false;
            $("#elenderunitid").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#elenderunitid").siblings('span.error').css('visibility', 'hidden');
        }


        if (isAllValid) {
            var master = {
                ID: $('#eid').val(),
                LENDERBANKID: $('#ebankid').val(),
                BORROWERUNITID: $('#eborrowerunitid').val(),
                LOANTYPEID: $('#eloantypeid').val(),
                LOANAMOUNT: $('#etxtLoanAmt').val(),
                CURRENCYID: $('#ecurrencyid').val(),
                CONRATE: $('#etxtConrate').val(),
                ISSUEDATE: $('#etxtIssueDate').val(),
                MATURITYDATE: $('#etxtMaturityDate').val(),
                INTERESTRATE: $('#etxtInterestRate').val(),
                LOANNUMBER: $('#etxtLoanNumber').val(),
                NARRATION: $('#etxtNarration').val()
            }


            if (isAllValid) {
                $.ajax({
                    type: 'POST',
                    url: "/BankLoan/Update",
                    dataType: "json",
                    data: { 'master': master, },
                    success: function (result) {
                        notify(result.item2.trim(), 'Message', result.item1.trim());
                        $scope.GetData();
                        //$scope.Clear();
                    },
                    error: function (errormessage) {
                        notify('error', 'Error Message', errormessage.responseText);
                    }
                });
            }

        }
    }

});
