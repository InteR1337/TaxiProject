var app = angular.module('mainApp', []);

app.controller('TaxisController', function ($scope, $http) {
    $scope.taxis = [];
    $scope.taxi = null;
    $scope.newTaxi = null;

    $scope.selectTaxi = function (data) {
        $http.get('http://localhost:9000/api/taxis/' + data.Id).then(function (response) {
            $scope.taxi = response.data;
        });
    }
    
    $scope.showNewTaxiForm = function () {
        $scope.newTaxi = {
            carBrand: '',
            carModel: '',
            passSeats: ''
        };
    }

    $scope.submitNewTaxi = function () {
        var newTaxi = {
            CarBrand: $scope.newTaxi.carBrand,
            CarModel: $scope.newTaxi.carModel,
            PassengerSeats: $scope.newTaxi.passSeats,
            UsedFrom: new Date().toISOString()
        }

        $http.post('http://localhost:9000/api/taxis/', newTaxi).then(function (response) {
            $scope.newTaxi = null;
            $scope.updateTaxisList();
        });
    }

    $scope.updateTaxisList = function () {
        $http.get('http://localhost:9000/api/taxis/').then(function (response) {
            $scope.taxis = response.data;
        });
    }

    $scope.updateTaxisList();
});

app.filter('toLocaleDate', function () {
    return function (input) {
        input = new Date(input) || new Date();
        var out = input.toLocaleDateString();
        return out;
    };
})
