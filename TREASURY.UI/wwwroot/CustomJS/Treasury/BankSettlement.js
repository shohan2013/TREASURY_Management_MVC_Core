var app = angular.module("App", ['angularUtils.directives.dirPagination']);

app.controller("Ctl", function ($scope, $window, $http) {

    $scope.loading = true;


    $scope.GetData = function (bankid,typeid) {
        $http({
            method: "get",
            url: "BankSettlement/GetData",
            params: { 'bankid': bankid, 'typeid': typeid }
        }).then(function (response) {
            $scope.list = response.data;
            $scope.loading = false;
        });
    };


    $scope.GetLoanNumber = function () {

        $("#txtLoanNumber").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/Common/GetLoanNumber/",
                    type: "Get",
                    dataType: "json",
                    data: {  prefix: request.term },
                    success: function (data) {
                        response($.map(data, function (item) {
                            return { label: item.name, id: item.id };
                        }));
                    }
                });
            },
            select: function (event, ui) {

                $("#txtLoanNumber").val(ui.item.value);
                $("#txtLoanNumberID").val(ui.item.id);


                    $http({
                        method: "GET",
                        url: "/BankLoan/GetDataByID",
                        params: { id: $("#txtLoanNumberID").val() }
                    }).then(function (response) {
                       

                        $('#id').val(response.data[0].id);
                        $('#lenderbankid').val(response.data[0].lenderbankid);
                        $('#borrowerunitid').val(response.data[0].borrowerunitid);
                        $('#loantypeid').val(response.data[0].loantypeid);
                        $('#txtLoanAmt').val(response.data[0].loanamount);
                        $('#txtpayment').val(response.data[0].payment);

                        $('#currencyid').val(response.data[0].currencyid);
                        $('#txtConrate').val(response.data[0].conrate);
                        //$('#txtRescheduledDate').val(response.data[0].rescheduledpaymentdate);
                        //$('#txtMaturityDate').val(response.data[0].maturitydate);
                        //$('#txtInterestRate').val(response.data[0].interestrate);
                        //$('#txtLoanNumber').val(response.data[0].refloannumber);
                        //$('#txtNarration').val(response.data[0].narration);
                    });

                

                $this = $(this);
                setTimeout(function () {
                    $("#txtLoanNumber").val(ui.item.value);
                
                }, 1);

                return false;
            },
            minlength: 3
        });
    }


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
            url: "BankSettlement/GetDataByID",
            params: { 'id': id }
        }).then(function (response) {
 
            $('#eid').val(response.data[0].id);
            $('#elenderbankid').val(response.data[0].lenderbankid);
            $('#eborrowerunitid').val(response.data[0].borrowerunitid);
            $('#eloantypeid').val(response.data[0].typeid);
            $('#etxtLoanAmt').val(response.data[0].amount);
            $('#etxtPaymentAmt').val(response.data[0].payment);

            $('#ecurrencyid').val(response.data[0].currencyid);
            $('#etxtConrate').val(response.data[0].crate);
            $('#etxtRescheduledDate').val(response.data[0].rescheduledpaymentdate);
            $('#etxtPaymentDate').val(response.data[0].paymentdate);
            //$('#etxtInterestRate').val(response.data[0].interestrate);
            $('#etxtLoanNumber').val(response.data[0].refloannumber);
            $('#etxtNarration').val(response.data[0].narration);
        });
    };


    $scope.LoadData = function () {
        $scope.GetData($scope.bankid,$scope.typeid);
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
            url: "/BankSettlement/DeleteMaster",
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

        

        //if ($("#txtPaymentDate").val() === "") {
        //    isAllValid = false;
        //    $("#txtPaymentDate").siblings('span.error').css('visibility', 'visible');
        //}
        //else {
        //    $("#txtPaymentDate").siblings('span.error').css('visibility', 'hidden');
        //}

        if ($("#txtPaymentAmt").val() === "") {
            isAllValid = false;
            $("#txtPaymentAmt").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#txtPaymentAmt").siblings('span.error').css('visibility', 'hidden');
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
                //LENDERBANKID: $('#bankid').val(),
                //BORROWERUNITID: $('#borrowerunitid').val(),
                //LOANTYPEID: $('#loantypeid').val(),
                //LOANAMOUNT: $('#txtLoanAmt').val(),
                //CURRENCYID: $('#currencyid').val(),
                CRATE: $('#txtConrate').val(),
                RESCHEDULEDPAYMENTDATE: $('#txtRescheduledDate').val(),
                PAYMENTDATE: $('#txtPaymentDate').val(),
                PAYMENT: $('#txtPaymentAmt').val(),
                REFLOANNUMBER: $('#txtLoanNumber').val(),
                REFID: $('#txtLoanNumberID').val(),
                NARRATION: $('#txtNarration').val()
            }

            if (isAllValid) {
                $.ajax({
                    type: 'POST',
                    url: "/BankSettlement/Save",
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



        if ($("#etxtPaymentAmt").val() === "") {
            isAllValid = false;
            $("#etxtPaymentAmt").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#etxtPaymentAmt").siblings('span.error').css('visibility', 'hidden');
        }


        if (isAllValid) {
            var master = {
                ID: $('#eid').val(),
                CRATE: $('#etxtConrate').val(),
                RESCHEDULEDPAYMENTDATE: $('#etxtRescheduledDate').val(),
                PAYMENTDATE: $('#etxtPaymentDate').val(),
                PAYMENT: $('#etxtPaymentAmt').val(),
                REFLOANNUMBER: $('#etxtLoanNumber').val(),
                REFID: $('#etxtLoanNumberID').val(),
                NARRATION: $('#etxtNarration').val()
            }


            if (isAllValid) {
                $.ajax({
                    type: 'PUT',
                    url: "/BankSettlement/Update",
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
