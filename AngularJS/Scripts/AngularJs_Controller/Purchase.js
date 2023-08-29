/// <reference path="../angular.js" />

var app = angular.module("mymodule", []);

app.controller("mycontroller", function ($scope, $http) {
    $scope.init = function () {
        $scope.Users();
        $scope.Materials();
    }
    $scope.MaterialList = [];
   // $scope.PurchaseItems = [];
    $scope.PurchaseItems = [];

    $scope.Users = function () {
        $scope.UserList = [];

        $http({
            method: 'Get',
            url: "/User/GetUserList"
        }).then(function (response) {
            $scope.UserList = response.data;
        })
    }

    $scope.Materials = function () {
        $scope.MaterialList = [];

        $http({
            method: 'Get',
            url: "/Purchase/GetMaterials"
        }).then(function (response) {
            $scope.MaterialList = response.data;
        })
    }

    $scope.MaterialModel = {
        MaterialId: null,
        MaterialName: '',
        initialize: function (data) {
            this.MaterialId = data ? data.MaterialId : null;
            this.MaterialName = data ? data.MaterialName : '';
        }
    }

    $scope.Purchase = {
        UserId: null,
        Status: 0,
        PurchaseDate: '',
        PurchaseItems:[],
        initialize: function (data) {
            this.UserId = data ? data.UserId : null;
            this.Status = data ? data.Status : 0;
            this.PurchaseDate = data ? data.PurchaseDate : '';
            this.PurchaseItems = data ? data.PurchaseItems : [];
        }
    }

    $scope.AddPurchaseItem = function (materialId) {
  
        $scope.MaterialModel.MaterialId = materialId;

        $scope.MaterialModel.MaterialName = $.grep($scope.MaterialList, function (vtype) {
            return vtype.MaterialId == materialId;
        })[0].MaterialName;

        $scope.PurchaseItems.push($scope.MaterialModel);

        $scope.MaterialModel = {
            MaterialId: null,
            MaterialName: '',
        }
    }

    $scope.RemoveItem = function (index) {
        $scope.PurchaseItems.splice(index, 1);
    }

    $scope.SaveData = function (purchase) {
        debugger;
        $scope.Purchase.UserId = purchase.UserId;
        $scope.Purchase.Status = purchase.Status;
        $scope.Purchase.PurchaseDate = purchase.PurchaseDate;
        $scope.Purchase.PurchaseItems = $scope.PurchaseItems;;

        $http({
            method: 'post',
            url: "/Purchase/Insert",
            data: $scope.Purchase
        }).then(function (response) {
            $scope.isEditable = false;
            alert(response.data);
        })
    }
})
