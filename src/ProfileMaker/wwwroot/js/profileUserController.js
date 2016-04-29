(function () {

    "use strict";

    //Getting the existing module
    angular.module("app-profileUser")
        .controller("profileUserController", profileUserController);

    function profileUserController() {

        var vm = this;

        vm.name = "Mathias";

    }

})();