var app = angular.module("App", ['angularUtils.directives.dirPagination']);

app.controller("Ctl", function ($scope, $window, $http) {

    $scope.loading = true;


    $scope.GetData = function (lunitid, bunitid) {
        $http({
            method: "get",
            url: "InterestCalculation/GetData",
            params: { 'lenderunitid': lunitid, 'borrowerunitid': bunitid }
        }).then(function (response) {
            $scope.list = response.data;
            $scope.loading = false;
        });
    };


    $scope.Edit = function (id) {
        $http({
            method: "get",
            url: "InterestCalculation/GetDataByID",
            params: { 'id': id }
        }).then(function (response) {
 
            $("#eid").val(response.data[0].id);
            $("#elenderunitid").val(response.data[0].lenderunitid);
            $("#eborrowerunitid").val(response.data[0].borrowerunitid);

            $("#etxtAmt").val(response.data[0].amount);
            $("#etxtStartDate").val(response.data[0].startdate);

            $("#etxtEndDate").val(response.data[0].enddate);
            $("#etxtNoofDays").val(response.data[0].noofdays);

            $("#etxtInterestRate").val(response.data[0].interestrate);
            $("#etxtInterestAmt").val(response.data[0].interestamt);

            $("#etxtDetails").val(response.data[0].details);
        });
    };


    $scope.LoadData = function (lunitid, bunitid) {
        $scope.GetData($scope.rlenderunitid, $scope.rborrowerunitid);
    };


    $scope.GetUnit = function () {
        $http({
            method: "get",
            url: "Common/GetUnit",
        }).then(function (response) {
            $scope.unitlist = response.data;
        });
    };

    $scope.EnableDisabled = function () {
        if ($("#sqfromtypeid").val() === "1") {
            $("#rfpid").prop('disabled', false);
            $("#txtSupplier").prop('disabled', true);
            $("#txtSupplierID").val('');
            $("#txtSupplier").val('');

        }
        else {

            $("#rfpid").prop('disabled', true);
            $("#txtSupplier").prop('disabled', false);
            $("#rfpid").val('');
            $("#txtSupplier").val('');
            $("#txtIndent").val('');
            $("#txtBuyerName").val('');
            $("#etxtBuyerName").val('');

            $("#hbuyerid").val('');
            $("#ehbuyerid").val('');

            $("#txtBuyerPhone").val('');
            $("#etxtBuyerPhone").val('');

            $("#txtBuyerEmail").val('');
            $("#etxtBuyerEmail").val('');

            $("#txtBuyerTin").val('');
            $("#etxtBuyerTin").val('');

            $("#txtBuyerAddress").val('');
            $("#etxtBuyerAddress").val('');
            $("#txtSellerName").val('');
            $("#txtSellerName").val('');
            $("#txtSupplier").val('');
            $("#txtSupplierID").val('');
            $("#hbuyerid").val('');
            $("#ehbuyerid").val('');

            $("#txtSellerPhone").val('');
            $("#txtSellerPhone").val('');

            $("#txtSellerEmail").val('');
            $("#txtSellerEmail").val('');

            $("#txtSellerTIN").val('');
            $("#txtSellerTIN").val('');

            $("#txtSellerAddress").val('');
            $("#txtSellerAddress").val('');
        }
    }

   


    $scope.Clear = function () {

        $("#eid").val('');
        $("#elenderunitid").val('');

        $("#eborrowerunitid").val('');
        $("#etxtAmt").val('');

        $("#etxtStartDate").val('');
        $("#etxtEndDate").val('');

        $("#etxtInterestRate").val('');
        $("#etxtInterestAmt").val('');

        $("#etxtDetails").val('');

        
        $("#lenderunitid").val('');

        $("#borrowerunitid").val('');
        $("#txtAmt").val('');

        $("#txtStartDate").val('');
        $("#txtEndDate").val('');

        $("#txtInterestRate").val('');
        $("#txtInterestAmt").val('');

        $("#txtDetails").val('');

    }

    $scope.DeleteMaster = function (id) {
        $.ajax({
            type: 'POST',
            url: "/InterestCalculation/DeleteMaster",
            dataType: "json",
            data: { 'id': id },
            success: function (result) {
                notify(result.item2.trim(), 'Message', result.item1.trim());
                $scope.GetData($scope.rlenderunitid, $scope.rborrowerunitid);
            },
            error: function (errormessage) {
                notify('error', 'Error Message', errormessage.responseText);
            }
        });
    }

    $scope.Save = function () {
        isAllValid = true;
        var Details = [];


        if ($("#lenderunitid").val() === "" ) {
            isAllValid = false;
            $("#lenderunitid").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#lenderunitid").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#borrowerunitid").val().trim() == "") {
            isAllValid = false;
            $("#borrowerunitid").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#borrowerunitid").siblings('span.error').css('visibility', 'hidden');
        }


        if ($("#txtAmt").val().trim() == "") {
            isAllValid = false;
            $("#txtAmt").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#txtAmt").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#txtStartDate").val().trim() == "") {
            isAllValid = false;
            $("#txtStartDate").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#txtStartDate").siblings('span.error').css('visibility', 'hidden');
        }


        if ($("#txtEndDate").val().trim() == "") {
            isAllValid = false;
            $("#txtEndDate").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#txtEndDate").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#txtInterestRate").val().trim() == "") {
            isAllValid = false;
            $("#txtInterestRate").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#txtInterestRate").siblings('span.error').css('visibility', 'hidden');
        }

        

        if (isAllValid) {
            var master = {
                LENDERUNITID: $('#lenderunitid').val(),
                BORROWERUNITID: $('#borrowerunitid').val(),
                AMOUNT: $('#txtAmt').val(),
                STARTDATE: $('#txtStartDate').val(),
                ENDDATE: $('#txtEndDate').val(),
                NOOFDAYS: $('#txtNoofDays').val(),
                INTERESTRATE: $('#txtInterestRate').val(),
                INTERESTAMT: $('#txtInterestAmt').val(),
                DETAILS: $('#txtDetails').val()
            }


            if (isAllValid) {
                $.ajax({
                    type: 'POST',
                    url: "/InterestCalculation/Save",
                    dataType: "json",
                    data: { 'master': master, },
                    success: function (result) {
                        $scope.GetData();

                        notify(result.item2.trim(), 'Message', result.item1.trim());
                        $scope.Clear();
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

        if ($("#eborrowerunitid").val().trim() == "") {
            isAllValid = false;
            $("#eborrowerunitid").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#eborrowerunitid").siblings('span.error').css('visibility', 'hidden');
        }


        if ($("#etxtAmt").val().trim() == "") {
            isAllValid = false;
            $("#etxtAmt").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#etxtAmt").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#etxtStartDate").val().trim() == "") {
            isAllValid = false;
            $("#etxtStartDate").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#etxtStartDate").siblings('span.error').css('visibility', 'hidden');
        }


        if ($("#etxtEndDate").val().trim() == "") {
            isAllValid = false;
            $("#etxtEndDate").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#etxtEndDate").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#etxtInterestRate").val().trim() == "") {
            isAllValid = false;
            $("#etxtInterestRate").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#etxtInterestRate").siblings('span.error').css('visibility', 'hidden');
        }



        if (isAllValid) {
            var master = {
                ID: $('#eid').val(),
                LENDERUNITID: $('#elenderunitid').val(),
                BORROWERUNITID: $('#eborrowerunitid').val(),
                AMOUNT: $('#etxtAmt').val(),
                STARTDATE: $('#etxtStartDate').val(),
                ENDDATE: $('#etxtEndDate').val(),
                NOOFDAYS: $('#etxtNoofDays').val(),
                INTERESTRATE: $('#etxtInterestRate').val(),
                INTERESTAMT: $('#etxtInterestAmt').val(),
                DETAILS: $('#etxtDetails').val()
            }


            if (isAllValid) {
                $.ajax({
                    type: 'POST',
                    url: "/InterestCalculation/Update",
                    dataType: "json",
                    data: { 'master': master, },
                    success: function (result) {
                        notify(result.item2.trim(), 'Message', result.item1.trim());
                        $scope.GetData();
                       // $scope.Clear();
                    },
                    error: function (errormessage) {
                        notify('error', 'Error Message', errormessage.responseText);
                    }
                });
            }

        }
    }

    $scope.Calculation = function (index) {
        var total = parseFloat(0.00);
        $('.totalprice').each(function (index, element) {
            total = parseFloat(total) + parseFloat($(element).val());
        });

        $('#txttotal').text(total)
    }

    $scope.calculateTotalPrice = function () {
        var total = 0;
        for (var i = 0; i < $scope.details.length; i++) {
            total += $scope.details[i].totalprice;
        }
        return total.toFixed(4);
    };

    
});
