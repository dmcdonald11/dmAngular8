var $dnnuclear = $dnnuclear || {};


$dnnuclear.myCTLApp = angular.module('$dnnuclear.myCTLApp', ['dnnuclearDnn']);

$dnnuclear.myCTLApp.controller('mainController', function ($http, $log, AppServiceFramework) {

    var vm = this;

    // Set API base url
    var serviceRoot = AppServiceFramework.getServiceRoot('DMAngular8');

    vm.EditMode = true;
    vm.calls = [];
    vm.regions = [];
    vm.EditIndex = -1;

    vm.show = 'default';


    //Get Calls
    $http.get(serviceRoot + 'home/GetCTCalls')
       .success(function (results) {
           vm.calls = results;
       })
       .error(function (data) {
           console.log(data);
       })

    vm.addCalls = function () {
        vm.show = 'new';
        $http.get('/home/GetRegions')
           .success(function (results) {
               vm.regions = results;
           })
           .error(function (data) {
               console.log(data);
           })

    }

    vm.Cancel = function () {
        vm.show = 'default';
    }

});
