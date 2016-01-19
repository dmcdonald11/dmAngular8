(function () {
    angular.module("myCTLApp", ['dnnuclearDnn'])

    //Directives
   //  .directive("addEditItem", $dnnuclear.AddEditDirective)

    //Controllers
    .controller("mainController", ['$http', '$log', 'AppServiceFramework',  $dnnuclear.mainController])
}());

