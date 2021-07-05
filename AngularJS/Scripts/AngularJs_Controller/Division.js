/// <reference path="../angular.js" />
var app = angular.module("mymodule", []);
app.controller("mycontroller", function ($scope, $http,$window) {
    $scope.DivisionList = [];
    $scope.GetDivisionList = function () {
        $http({
            method: 'GET',
            url: "/DivisionJson/GetDivisionList"
        }).then(function (response) {
            $scope.DivisionList = response.data;
        })

    };
    $scope.DivisionModel = {
        DivisionId: null,
        DivisionName: '',
        initilize: function (data) {
            this.DivisionId = data ? data.DivisionId : null;
            this.DivisionName = data ? data.DivisionName : '';
        }
    };

  
    
    $scope.InsertData = function () {
        debugger
        $http({
            method: 'POST',
            url: "/DivisionJson/InsertData",
            data: $scope.DivisionModel
        }).then(function (response) {
            debugger
            if (response.data == "success") {
                alert("Data successfully saved");
                window.location = "/Division/Index";
            }
            else {
                alert("Data is not saved");
                $scope.DivisionModel.initilize();
                window.location = "/Division/Create";
            }

        })
    };

    $scope.GetDivisionById = function (id) {

        if (id) {
            sessionStorage.setItem("divId", id);
            $window.location = "/Division/Edit/" + id;
        }

        /*$scope.dividionInfo = [];
        $http({
            method: 'GET',
            url: "/DivisionJson/GetDivisionById",
            data: { id: id }
        }).then(function (response) {
           
            $scope.DivisionModel.initilize(response.data);
        })*/

    };

    $scope.getDivisionForEditView = function () {
      
        $scope.dividionInfo = [];
        $http({
            method: 'GET',
            url: "/DivisionJson/GetDivisionById/" + parseInt(sessionStorage.getItem("divId"))
          
        }).then(function (response) {
          
            $scope.DivisionModel.initilize(response.data);
        })
    }

})