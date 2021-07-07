/// <reference path="../angular.js" />




var app = angular.module("mymodule", []);

app.controller("mycontroller", function ($scope, $http) {
    $scope.userBackupData = [];
    $scope.edit = [];
    $scope.init = function () {
        $scope.GetDivision();
        $scope.error = false;
        $scope.erroMessage = "";
        $scope.isEditable = false;
    };

    /* this is used for calling the method for user list and received the list that is send from controller
     * after receive it, pass it the view page
     */
    $scope.GetUserList = function () {
        $http({
            method: 'Get',
            url: "/User/GetUserList"
        }).then(function (response) {
            $scope.userList = response.data;
            for (var i = 0; i < $scope.userList.length; i++) {
                $scope.GetDistrict(i);
            }
            
            
        })
    };

    $scope.UserModel = {
        UserId: null,
        Phone: null,
        DistrictId: null,
        UserName: '',
        initialize: function (data) {
            this.UserId = data ? data.UserId : null;
            this.Phone = data ? data.Phone : null;
            this.DistrictId = data ? data.DistrictId : null;
            this.UserName = data ? data.UserName : '';
        }
    };

    $scope.userList = [{
        UserId: null,
        Phone: null,
        DistrictId: null,
        UserName: '',
        DivisionId: null,
        DistrictList: [],
        isEdited :false
    }];

    /* create the multiple feild for taking data as input
     */
    $scope.addItem = function () {
        var item = {
            UserId: null,
            Phone: null,
            DistrictId: null,
            UserName: '',
            DivisionId: null,
            DistrictList: []
        };

        $scope.userList.push(item);
    };

    /* this function is used for remove the input feild from view page
     */
    $scope.removeItem = function (index) {
        $scope.userList.splice(index, 1);
        if ($scope.userList.length <= 0) {
            $scope.addItem();
        }
    };
    /* this function is calling for getting the division list and received from controller
     * after recived pass it to the division dropdown 
    */
    $scope.GetDivision = function () {
        $scope.Division = [];

        $http({
            method: 'Get',
            url: "/User/GetDivision"
        }).then(function (response) {
            $scope.Division = response.data;
        })
    };

    /* this function is calling for getting the district list and received from controller
    * after recived pass it to the district dropdown
    * this function is called only when the division is select from the dropdown
   */
    $scope.GetDistrict = function (index) {

        if ($scope.userList[index].DivisionId) {
            $http({
                method: 'get',
                url: "/User/GetDistrict?divisionId=" + $scope.userList[index].DivisionId

            }).then(function (response) {
                $scope.userList[index].DistrictList = response.data;
                console.log("Main IN DISTRICT API- >" + JSON.stringify($scope.userList[index]));
                console.log("Backup IN DISTRICT API- >" + JSON.stringify($scope.userBackupData[index]));

            })
        } else {
            $scope.userList[index].DistrictList = [];
        }

    };
    /* this method received the data from View and  pass it to the controller
     */
    $scope.SaveData = function () {
        $http({
            method: 'post',
            url: "/User/SaveData",
            data: $scope.userList
        }).then(function (response) {
            $scope.userList = [{
                UserId: null,
                Phone: null,
                DistrictId: null,
                UserName: '',
                DivisionId: null,
                DistrictList: []
            }]
            alert(response.data);
            window.location = "/User/Index";
        })
    };

    $scope.SearchData = function (number) {
        $scope.Data = [];
        $http({
            method: 'get',
            url: "/User/SearchData?number=" + number
        }).then(function (response) {

            if (response.data.Phone == number) {
                $scope.error = true;
                $scope.erroMessage = "Phone " + number + " Already Exist in Database! ";
            } else {
                $scope.error = false;
                $scope.erroMessage = "";
            }
        })
    };

    $scope.validatePhone = function (index) {

        $scope.error = false;
        var phoneNumber = $scope.userList[index].Phone;

        if (phoneNumber.length != 11) {
            $scope.error = true;
            $scope.erroMessage = "Phone number must be 11 Digit";
            $scope.userList[index].Phone = "";
            return;
        }
        var phonePrefix = phoneNumber.substring(0, 3);
        if (!angular.equals(phonePrefix, "017") && !angular.equals(phonePrefix, "016") && !angular.equals(phonePrefix, "015") && !angular.equals(phonePrefix, "014") && !angular.equals(phonePrefix, "013")
            && !angular.equals(phonePrefix, "018") && !angular.equals(phonePrefix, "019")
        ) {
            $scope.error = true;
            $scope.erroMessage = "Phone number must start with (013-019)";
            $scope.userList[index].Phone = "";
            return;
        }

        for (var i = 0; i < $scope.userList.length; i++) {
            if (i != index) {
                if (angular.equals(phoneNumber, $scope.userList[i].Phone)) {
                    $scope.userList[index].Phone = "";
                    $scope.error = true;
                    $scope.erroMessage = "Phone " + phoneNumber + " Already Exist! at Serial " + (index + 1);
                    return;
                }
            }

        }
        $scope.SearchData(phoneNumber);
    };
 
    $scope.editData = function (index) {
        console.log(JSON.stringify($scope.userList));
        $scope.edit[index] = true;
    };

    $scope.cncelEditData = function (index) {
        $scope.edit[index] = false;
        $scope.GetUserList();
    };

    $scope.saveEditedData = function () {

        var userModifiedList = [];

        for (var i = 0; i < $scope.userList.length; i++) {
            if (angular.equals($scope.userList[i].isEdited, true)) {
                userModifiedList.push($scope.userList[i]);
            }
        }

        $http({
            method: 'post',
            url: "/User/EditedData",
            data: userModifiedList
        }).then(function (response) {
            $scope.isEditable = false;
            alert(response.data);
            $scope.GetUserList();
            
        })
    };


    $scope.makeEditable = function () {
        $scope.isEditable = true;
        for (var i = 0; i < $scope.userList.length; i++) {
            $scope.userList[i].isEdited = false;
        }

        angular.copy($scope.userList, $scope.userBackupData);
    };

    $scope.cancleEdit = function () {
        $scope.isEditable = false;
    };

    $scope.revertEdit = function (index) {
        $scope.userList[index].isEdited = false;
        angular.copy($scope.userBackupData[index], $scope.userList[index]);
        console.log(JSON.stringify($scope.userList));
    };

    $scope.checkIfChanged = function (index,forWhich) {
        if (forWhich === 'UserName') {
            if (angular.equals($scope.userList[index].UserName, $scope.userBackupData[index].UserName)) {
                $scope.userList[index].isEdited = false;
            } else {
                $scope.userList[index].isEdited = true;
            }
        } else if (forWhich === 'Phone') {
            if (angular.equals($scope.userList[index].Phone, $scope.userBackupData[index].Phone)) {
                $scope.userList[index].isEdited = false;
            } else {
                $scope.userList[index].isEdited = true;
            }
        } else if (forWhich === 'DivisionId') {
            if (angular.equals($scope.userList[index].DivisionId, $scope.userBackupData[index].DivisionId)) {
                $scope.userList[index].isEdited = false;
            } else {
                $scope.userList[index].isEdited = true;
            }
        } else if (forWhich === 'DistrictId') {
            if (angular.equals($scope.userList[index].DistrictId, $scope.userBackupData[index].DistrictId)) {
                $scope.userList[index].isEdited = false;
            } else {
                $scope.userList[index].isEdited = true;
            }
        }

        console.log(JSON.stringify($scope.userList));
    };
})