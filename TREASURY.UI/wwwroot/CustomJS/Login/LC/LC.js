
/*var app = angular.module("PIApp", ['angularUtils.directives.dirPagination']);*/
var app = angular.module("App", ['angularUtils.directives.dirPagination']);

app.controller("Ctl", function ($scope, $window, $http) {

    //$scope.loading = true;

    $scope.GetLCData = function () {
        $http({
            method: "get",
            url: "LC/GetLCData",
        }).then(function (response) {
            console.log(response.data);
            $scope.LClist = response.data;
            //$scope.loading = false;
        });
    };

    $scope.ViewCData = function (ID,PINO) {
        $scope.ID = ID;
        $http({
            method: "GET",
            url: '/LCApproval/ViewCData',
            params: { id: $scope.ID }
        }).success(function (data) {
            $scope.masterdata = data;
        });

        $scope.LoadDocument(ID);
        $scope.ViewLoadDocumentStatus(ID);
        $scope.ViewByDetailsData(PINO);
    };

    $scope.LoadDocument = function (ID) {
        $scope.ID = ID;
        $http({
            method: "GET",
            url: '/SalesQuatationApproval/LoadDocument',
            params: { id: $scope.ID, }
        }).success(function (result) {
            $scope.imageitem = result;
        });
    }

    $scope.ViewByDetailsData = function (ID) {
        $scope.ID = ID;
        $http({
            method: "GET",
            //url: '/AgreementLanding/GetAgreementLine',
            url: '/AgreementApproval/ViewByDetailsID',
            params: { id: $scope.ID }
        }).success(function (data) {
            $scope.pclistdetails = data;
        });
    };

    $scope.ViewLoadDocumentStatus = function (ID) {
        $scope.ID = ID;
        $http({
            method: "GET",
            url: '/LC/GetDocStatus',
            params: { id: $scope.ID, }
        }).success(function (result) {
            console.log(result);
            $scope.docstatusview = result;
        });
    }

    $scope.LoadConfirm = function () {

        $http({
            method: "GET",
            url: '/Common/GetConfirm'
        }).success(function (result) {
            console.log(result);
            $scope.confirmlist = result;
        });
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



    $scope.Clear = function () {
        $("#txtPISCID").val("");
        $("#txtLCNumber").val("");
        $("#txtDateIssue").val("");
        $("#txtExpireDate").val("");
        $("#txtTolerancePer").val("");
        $("#PerformanceInvoiceNo").val("");
        $("#txtPeriodPresentation").val("");
        $("#txtTranshipment").val("");
        $("#txtCreatedPlace").val("");
        $("#txtPeriodPresentation").val("");
        $("#txtPartialShipment").val("");
        $("#txtBuyerDocReq").val("");
        $("#BuyerAdditionCon").val("");
        $("#etxtNotifyParty").val("");
        $("#txtNotifyParty").val("");
        $("#txtPISC").val("");
        //$("#editmycontainer").empty();

        $("#txtComName").val("");
        $("#txtSellerPhone").val("");
        $("#txtSellerEmail").val("");
        $("#txtSellerTIN").val("");
        $("#txtSellerAddress").val("");
        $("#txtBuyerName").val("");
        $("#txtPhone").val("");
        $("#txtEmail").val("");
        $("#txtAddress").val("");
        $scope.detailsbyid = null;
    }


    $scope.sortBy = function (column) {
        $scope.sortColumn = column;
        $scope.reverse = !$scope.reverse;
    }

    $scope.GetSellerData = function (id) {
        $.ajax({
            url: '/LC/GetSellerInfo',
            type: "Get",
            dataType: "json",
            data: { 'id': id },
            success: function (data) {
                
                $("#txtComName").val(data[0].name);
                $("#hsellerid").val(data[0].id);
                $("#txtSellerPhone").val(data[0].phone);
                $("#txtSellerEmail").val(data[0].email);
                $("#txtSellerTIN").val(data[0].tin);
                $("#txtSellerAddress").val(data[0].address);

                //$("#etxtComName").val(data[0].name);
                //$("#ehsellerid").val(data[0].id);
                //$("#etxtSellerPhone").val(data[0].phone);
                //$("#etxtSellerEmail").val(data[0].email);
                //$("#etxtSellerTIN").val(data[0].tin);
                //$("#etxtSellerAddress").val(data[0].address);
            }
        });
    }

    $scope.GetCusData = function (id) {

        $.ajax({
            url: '/LC/GetCusInfo',
            type: "Get",
            dataType: "json",
            data: { 'id': id },
            success: function (data) {
                console.log(data);
                $("#txtBuyerName").val(data[0].name);
                $("#txtCusCode").val(data[0].id);
                $("#txtPhone").val(data[0].phone);
                $("#txtEmail").val(data[0].email);
                $("#txtTIN").val(data[0].tin);
                $("#txtAddress").val(data[0].address);

                //$("#etxtBuyerName").val(data[0].name);
                //$("#etxtCusCode").val(data[0].id);
                //$("#etxtPhone").val(data[0].phone);
                //$("#etxtEmail").val(data[0].email);
                //$("#etxtTIN").val(data[0].tin);
                //$("#etxtAddress").val(data[0].address);
            }
        });
    }

    $scope.GetSellerDataEdit = function (id) {
        $.ajax({
            url: '/LC/GetSellerInfoEdit',
            type: "Get",
            dataType: "json",
            data: { 'id': id },
            success: function (data) {

                //$("#txtComName").val(data[0].name);
                //$("#hsellerid").val(data[0].id);
                //$("#txtSellerPhone").val(data[0].phone);
                //$("#txtSellerEmail").val(data[0].email);
                //$("#txtSellerTIN").val(data[0].tin);
                //$("#txtSellerAddress").val(data[0].address);

                $("#etxtComName").val(data[0].name);
                $("#ehsellerid").val(data[0].id);
                $("#etxtSellerPhone").val(data[0].phone);
                $("#etxtSellerEmail").val(data[0].email);
                $("#etxtSellerTIN").val(data[0].tin);
                $("#etxtSellerAddress").val(data[0].address);
            }
        });
    }

    $scope.GetCusDataEdit = function (id) {

        $.ajax({
            url: '/LC/GetCusInfoEdit',
            type: "Get",
            dataType: "json",
            data: { 'id': id },
            success: function (data) {
                //console.log(data);
                //$("#txtBuyerName").val(data[0].name);
                //$("#txtCusCode").val(data[0].id);
                //$("#txtPhone").val(data[0].phone);
                //$("#txtEmail").val(data[0].email);
                //$("#txtTIN").val(data[0].tin);
                //$("#txtAddress").val(data[0].address);

                $("#etxtBuyerName").val(data[0].name);
                $("#etxtCusCode").val(data[0].id);
                $("#etxtPhone").val(data[0].phone);
                $("#etxtEmail").val(data[0].email);
                $("#etxtTIN").val(data[0].tin);
                $("#etxtAddress").val(data[0].address);
            }
        });
    }

    $scope.SearchPI = function () {
        $("#txtPISC").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: '/LC/GetPIInfo/',
                    type: "Get",
                    dataType: "json",
                    data: { prefix: request.term },
                    success: function (data) {
                        response($.map(data, function (item) {
                            return { label: item.name, id: item.id, Name: item.name };
                        }));
                    }
                });

            },
            select: function (event, ui) {

                $("#txtPISC").val(ui.item.Name);
                $("#txtPISCID").val(ui.item.id);
                $scope.GetCusData(ui.item.id);
                $scope.GetSellerData(ui.item.id);
                $scope.GetPIDetailsData(ui.item.id);
                return false;
            },
            minlength: 2
        });
    }

    $scope.GetPIDetailsData = function (id) {
        $http({
            method: "get",
            params: {id:id},
            url: "LC/GetPIDetailsByID",
        }).then(function (response) {
            $scope.detailsbyid = response.data;
            //$scope.loading = false;
        });
    };

    $scope.GetPIDetailsDataEdit = function (id) {
        $http({
            method: "get",
            params: { id: id },
            url: "LC/GetPIDetailsByIDEdit",
        }).then(function (response) {
            console.log(response);
            $scope.edetailsbyid = response.data;
            //$scope.loading = false;
        });
    };

    $scope.EditbyMasterID = function (id) {
        $("#lcid").val(id);
        
            $http({
                method: "POST",
                url: "/LC/GetLCDetailsByID",
                params: { id: id }
            }).then(function (response) {
                $("#etxtBuyerBank").val(response.data[0].buyerbank);
                $("#etxtLCNumber").val(response.data[0].lcnumber);
                $("#etxtDateIssue").val(response.data[0].lcissuedate);
                $("#etxtExpireDate").val(response.data[0].lcexpiredate);
                $("#etxtTolerancePer").val(response.data[0].toelrancecramtpercentage);
                $("#etxtTranshipment").val(response.data[0].transshipment);
                $("#etxtNotifyParty").val(response.data[0].notifiedpartydetails);

                $("#etxtCreatedPlace").val(response.data[0].lccreatedplace);
                $("#etxtPartialShipment").val(response.data[0].partialshipment);
                $("#etxtPeriodPresentation").val(response.data[0].presentationindate);

                $("#etxtBuyerDocReq").val(response.data[0].buyerdocumentrequired);
                $("#etxtBuyerAdditionCon").val(response.data[0].buyeradditionalcondition);
                $("#etxtBuyerBank").val(response.data[0].buyerbank);
                $("#etxtPISC").val(response.data[0].pisc);

                $("#etxtLatestDate").val(response.data[0].shipmentlatestdate);
                $("#etxtTenore").val(response.data[0].lctenorperiod);
                $("#etxtCreatedPlace").val(response.data[0].lcexpiredplace);

                $scope.GetCusDataEdit(id);
                $scope.GetSellerDataEdit(id);
                $scope.GetPIDetailsData(id);
                $scope.GetPIDetailsDataEdit(id);
                //$scope.GetLCData();
                //notify('success', 'Message', response.data);

            });
        
    };

    $scope.DeleteMaster = function (id) {
        if (confirm('Are You Sure? You Want to Delete this Record.') == true) {
            $http({
                method: "POST",
                url: "/LC/DeleteMasterByID",
                params: { id: id}
            }).then(function (response) {
                $scope.GetLCData();
                notify('success', 'Message', response.data);

            });
        }
        else {

        }
    };


    $scope.Save = function () {


        var Details = [];

        var isAllValid = true;

        if ($("#txtPISCID").val().trim() == "") {
            isAllValid = false;
            $("#txtPISCID").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#txtPISCID").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#txtLCNumber").val().trim() == "") {
            isAllValid = false;
            $("#txtLCNumber").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#txtLCNumber").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#txtDateIssue").val().trim() == "") {
            isAllValid = false;
            $("#txtDateIssue").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#txtDateIssue").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#txtExpireDate").val() == "") {
            isAllValid = false;
            $("#txtExpireDate").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#txtExpireDate").siblings('span.error').css('visibility', 'hidden');
        }


        if ($("#txtTolerancePer").val() == "") {
            isAllValid = false;
            $("#txtTolerancePer").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#txtTolerancePer").siblings('span.error').css('visibility', 'hidden');
        }


        if ($("#PerformanceInvoiceNo").val() == "") {
            isAllValid = false;
            $("#PerformanceInvoiceNo").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#PerformanceInvoiceNo").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#txtPeriodPresentation").val() == "") {
            isAllValid = false;
            $("#txtPeriodPresentation").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#txtPeriodPresentation").siblings('span.error').css('visibility', 'hidden');
        }


        if ($("#txtTranshipment").val() == "") {
            isAllValid = false;
            $("#txtTranshipment").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#txtTranshipment").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#txtCreatedPlace").val() == "") {
            isAllValid = false;
            $("#txtCreatedPlace").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#txtCreatedPlace").siblings('span.error').css('visibility', 'hidden');
        }


        if ($("#txtPeriodPresentation").val() == "") {
            isAllValid = false;
            $("#txtPeriodPresentation").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#txtPeriodPresentation").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#txtPartialShipment").val() == "") {
            isAllValid = false;
            $("#txtPartialShipment").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#txtPartialShipment").siblings('span.error').css('visibility', 'hidden');
        }
       
        if (isAllValid) {
            var master = {

                PROFORMAINVOICEHEADERID: $("#txtLCNumber").val(),
                LCNUMBER: $("#txtLCNumber").val(),
                LCISSUEDATE: $("#txtDateIssue").val(),
                LCEXPIREDATE: $("#txtExpireDate").val(),

                LCEXPIREDPLACE: $("#txtCreatedPlace").val(),
                //CUSTOMERID: $("#hsellerid").val(),
                TOELRANCECRAMTPERCENTAGE: $("#txtTolerancePer").val(),
                PRESENTATIONINDATE: $("#txtPeriodPresentation").val(),
                PARTIALSHIPMENT: $("#txtPartialShipment").val(),

                BUYERDOCUMENTREQUIRED: $("#txtBuyerDocReq").val(),
                BUYERADDITIONALCONDITION: $("#BuyerAdditionCon").val(),
                TRANSSHIPMENT: $("#txtTranshipment").val(),
                NOTIFIEDPARTYDETAILS: $("#txtNotifyParty").val(),
                PISCHEADERID: $("#txtPISCID").val(),
                BUYERBANK: $("#txtBuyerBank").val(),
                DESCRIPTIONS: "",

                LCCREATEDPLACE: $("#txtCreatedPlace").val(),
                SHIPMENTLATESTDATE: $("#txtLatestDate").val(),
                LCTENORPERIOD: $("#txtTenore").val()
            }

            $.ajax({
                type: 'POST',
                url: '/LC/Save',
                dataType: "json",
                data: { 'lc': master },
                success: function (result) {

                    //$scope.UploadFile(result);
                    notify("success", "Success Messsage", result);
                    $scope.edetailsbyid = null;
                    $scope.detailsbyid = null;
                    $scope.GetLCData();
                    $scope.Clear();
                },
                error: function (errormessage) {
                    notify('error', 'Error Message', errormessage.responseText);
                }
            });
        }

    }

    $scope.Update = function () {
        //$scope.UploadFile("335");

        var Details = [];

        var isAllValid = true;

        //if ($("#etxtPISCID").val().trim() == "") {
        //    isAllValid = false;
        //    $("#etxtPISCID").siblings('span.error').css('visibility', 'visible');
        //}
        //else {
        //    $("#etxtPISCID").siblings('span.error').css('visibility', 'hidden');
        //}

        if ($("#etxtLCNumber").val().trim() == "") {
            isAllValid = false;
            $("#etxtLCNumber").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#etxtLCNumber").siblings('span.error').css('visibility', 'hidden');
        }


        if ($("#etxtDateIssue").val().trim() == "") {
            isAllValid = false;
            $("#etxtDateIssue").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#etxtDateIssue").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#etxtExpireDate").val() == "") {
            isAllValid = false;
            $("#etxtExpireDate").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#etxtExpireDate").siblings('span.error').css('visibility', 'hidden');
        }


        if ($("#etxtTolerancePer").val() == "") {
            isAllValid = false;
            $("#etxtTolerancePer").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#etxtTolerancePer").siblings('span.error').css('visibility', 'hidden');
        }


        if ($("#ePerformanceInvoiceNo").val() == "") {
            isAllValid = false;
            $("#ePerformanceInvoiceNo").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#ePerformanceInvoiceNo").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#etxtPeriodPresentation").val() == "") {
            isAllValid = false;
            $("#etxtPeriodPresentation").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#etxtPeriodPresentation").siblings('span.error').css('visibility', 'hidden');
        }


        if ($("#etxtTranshipment").val() == "") {
            isAllValid = false;
            $("#etxtTranshipment").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#etxtTranshipment").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#etxtCreatedPlace").val() == "") {
            isAllValid = false;
            $("#etxtCreatedPlace").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#etxtCreatedPlace").siblings('span.error').css('visibility', 'hidden');
        }


        if ($("#etxtPeriodPresentation").val() == "") {
            isAllValid = false;
            $("#etxtPeriodPresentation").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#etxtPeriodPresentation").siblings('span.error').css('visibility', 'hidden');
        }

        if ($("#etxtPartialShipment").val() == "") {
            isAllValid = false;
            $("#etxtPartialShipment").siblings('span.error').css('visibility', 'visible');
        }
        else {
            $("#etxtPartialShipment").siblings('span.error').css('visibility', 'hidden');
        }

        if (isAllValid) {
            var master = {
                ID: $("#lcid").val(),
                PROFORMAINVOICEHEADERID: $("#etxtLCNumber").val(),
                LCNUMBER: $("#etxtLCNumber").val(),
                LCISSUEDATE: $("#etxtDateIssue").val(),
                LCEXPIREDATE: $("#etxtExpireDate").val(),

                LCEXPIREDPLACE: $("#etxtCreatedPlace").val(),
                //CUSTOMERID: $("#hsellerid").val(),
                TOELRANCECRAMTPERCENTAGE: $("#etxtTolerancePer").val(),
                PRESENTATIONINDATE: $("#etxtPeriodPresentation").val(),
                PARTIALSHIPMENT: $("#etxtPartialShipment").val(),

                BUYERDOCUMENTREQUIRED: $("#etxtBuyerDocReq").val(),
                BUYERADDITIONALCONDITION: $("#etxtBuyerAdditionCon").val(),
                TRANSSHIPMENT: $("#etxtTranshipment").val(),
                NOTIFIEDPARTYDETAILS: $("#etxtNotifyParty").val(),
                PISCHEADERID: $("#etxtPISCID").val(),
                BUYERBANK: $("#etxtBuyerBank").val(),
                DESCRIPTIONS: "",

                LCCREATEDPLACE: $("#etxtCreatedPlace").val(),
                SHIPMENTLATESTDATE: $("#etxtLatestDate").val(),
                LCTENORPERIOD: $("#etxtTenore").val()
            }


            //console.log(master);
            $.ajax({
                type: 'POST',
                url: '/LC/Update',
                dataType: "json",
                data: { 'lc': master },
                success: function (result) {

                    //$scope.UploadFile(result);
                    notify("success", "Success Messsage", result);
                    $scope.GetLCData();
                    //$scope.Clear();
                },
                error: function (errormessage) {
                    notify('error', 'Error Message', errormessage.responseText);
                }
            });
        }

    }

});