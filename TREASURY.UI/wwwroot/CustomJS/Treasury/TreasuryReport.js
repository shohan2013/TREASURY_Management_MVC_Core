var app = angular.module("App", ['angularUtils.directives.dirPagination']);

app.controller("Ctl", function ($scope, $window, $http) {

    $scope.loading = true;

    $scope.GetData = function () {
        $scope.GITotal = null;
        $scope.GTotal = null;

        let vgtotal = 0;
        let vinteresttotal = 0;
        $http({
            method: "get",
            url: "TreasuryReport/GetData",
            params: { 'lenderunitid': $scope.lenderunitid, 'startdate': $scope.startdate, 'enddate': $scope.enddate }
        }).then(function (response) {
            if (response.data) {
                $scope.list = response.data;

                $scope.details = response.data;
                $scope.lenderunit = response.data[0].lenderunit;

                $scope.details.forEach(function (item) {
                    vinteresttotal += parseFloat(item.interestamt || 0);
                    vgtotal += parseFloat(item.amount || 0);
                });

                $scope.GITotal =vinteresttotal;
                $scope.GTotal=vgtotal;
            }
            else {
                $scope.GTotal = 0
                
            }
            $scope.loading = false;
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


    $scope.PrintDoc = function () {
        printElement(document.getElementById("printThis"));
    };

    function printElement(elem) {
        var domClone = elem.cloneNode(true);

        var $printSection = document.getElementById("printSection");

        if (!$printSection) {
            var $printSection = document.createElement("div");
            $printSection.id = "printSection";
            document.body.appendChild($printSection);
        }

        $printSection.innerHTML = "";
        $printSection.appendChild(domClone);
        window.print();
    }

    $scope.Print = function () {
        $('#PrintexampleModalFullscreen').modal('hide');
        //var url = rooturl + folder + "&ID=" + id + "&rs:Embed=true&rc:LinkTarget=_self";

        //var base_url = window.location.origin;
        //newwindow = window.open(url, "/DocumentLanding/Print?id=" + id, 'scrollbars=yes,toolbar=0,height=400,width=800,top=70,left=50');
        if (window.focus) { newwindow.focus() }
    };

    
   
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
});
