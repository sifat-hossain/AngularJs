/// <reference path="../angular.js" />
var app = angular.module("mymodule", []);
app.controller("mycontroller", function ($scope, $http) {

    $scope.divisionBackup = [];

    $scope.divisionList = [{
        DivisionId: null,
        DivisionName: '',
        isEdited: false
    }];

    $scope.GetDivisionList = function () {
        $http({
            method: 'GET',
            url: "/Division/GetDivisionList"
        }).then(function (response) {
            $scope.divisionList = response.data;
            $scope.isEditable = false;
        })

    };

    $scope.addDivisionFeild = function () {
        var divisionItem = {
            DivisionId: null,
            DivisionName: ''
        };
        $scope.divisionList.push(divisionItem);
    };

    $scope.removeItem = function (index) {
        $scope.divisionList.splice(index, 1);
    };
   

  
    
    $scope.InsertData = function () {
        debugger
        $http({
            method: 'post',
            url: "/Division/InsertData",
            data: $scope.divisionList
        }).then(function (response) {

            alert(response.data);
            window.location = "/Division/Index";
           
        })
    };

    $scope.makeEditable = function ()
    {
        $scope.isEditable = true;
        for (var i = 0; i < $scope.divisionList.length; i++) {
            $scope.divisionList[i].isEdited = false;
        }
        angular.copy($scope.divisionList, $scope.divisionBackup);
    };

    $scope.cancelEdit = function () {
        $scope.isEditable = false;
        angular.copy($scope.divisionBackup, $scope.divisionList);
    }
    $scope.revert = function (index) {
        $scope.divisionList[index].isEdited = false;
        angular.copy($scope.divisionBackup[index], $scope.divisionList[index]);
    };
    $scope.checkIfChange = function (index, forWhich) {
        if (forWhich === 'DivisionName') {
            if (angular.equals($scope.divisionBackup[index].DivisionName, $scope.divisionList[index].DivisionName)) {
                $scope.divisionList[index].isEdited = false;
            }
            else {
                $scope.divisionList[index].isEdited = true;
            }
        }
    };
    $scope.saveEditedData = function () {
        debugger
        var modifiedDivision = [];
        for (var i = 0; i < $scope.divisionList.length; i++) {
            if (angular.equals($scope.divisionList[i].isEdited, true)) {
                modifiedDivision.push($scope.divisionList[i]);
            }
        }
        debugger
        $http({
            method: 'post',
            url: "/Division/SaveEditedData",
            data: modifiedDivision
        }).then(function (response) {
            debugger
            $scope.isEditable = false;
            alert(response.data);
            $scope.GetDivisionList();
        })
    };
    //$scope.GetDivisionById = function (id) {

    //    if (id) {
    //        sessionStorage.setItem("divId", id);
    //        $window.location = "/Division/Edit/" + id;
    //    }

    //    /*$scope.dividionInfo = [];
    //    $http({
    //        method: 'GET',
    //        url: "/DivisionJson/GetDivisionById",
    //        data: { id: id }
    //    }).then(function (response) {
           
    //        $scope.DivisionModel.initilize(response.data);
    //    })*/

    //};

    //$scope.getDivisionForEditView = function () {
      
    //    $scope.dividionInfo = [];
    //    $http({
    //        method: 'GET',
    //        url: "/DivisionJson/GetDivisionById/" + parseInt(sessionStorage.getItem("divId"))
          
    //    }).then(function (response) {
          
    //        $scope.DivisionModel.initilize(response.data);
    //    })
    //}

})