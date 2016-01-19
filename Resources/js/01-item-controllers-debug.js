var $dnnuclear = $dnnuclear || {};

$dnnuclear.mainController = function mainController($http, $log, AppServiceFramework) {
    // Set vm to the scope of this controller
    var vm = this;

    // Set API base url
    var serviceRoot = AppServiceFramework.getServiceRoot('DMAngular8');
    //if (AppServiceFramework) {serviceRoot = AppServiceFramework.getServiceRoot('DMAngular8')}

    vm.EditMode = true;
    vm.calls = [];
    vm.regions = [];
    vm.EditIndex = -1;
    //vm.Userlist = $dnnuclear.UserList;

    vm.show = 'default';

    //Get Calls
    $http.get(serviceRoot + 'home/list')
       .success(function (results) {
           vm.calls = results;
       })
       .error(function (data) {
           console.log(data);
       })

    //$http.get(serviceRoot + 'home/GetItems')
    //   .success(function (results) {
    //       vm.calls = results;
    //   })
    //   .error(function (data) {
    //       console.log(data);
    //   })


    vm.newCalls = '';
    //vm.regions = '';
    vm.addCalls = function () {
        vm.show = 'new';
        $http.get(serviceRoot + 'home/RegionList')
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


}