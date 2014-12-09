MedacsAdmin.controller('Account', ['$scope', '$http', 'AccountService', '$window', function ($scope, $http, accountService, $window) {

    $scope.emailMessage = "Hello";

        $scope.LoginUser = function (logindetails) {
            accountService.Login(logindetails).success(function (data) {

                if (data.result === 'Success') {
                    
                    $window.location.href='/Home/Index';
                } else {
                    $scope.loginmessage = "UserName Or Password are Incorrect";
                }

            });

        };

        $scope.Signup = function (registerDetails) {
            accountService.Register(registerDetails).success(function(data) {
                
                if (data.result === 'Success') {
                    
                }
            });


        };


        $scope.SubmitEmail = function (email) {

         accountService.forgotEmail(email).success(function (data) {

             if (data.result === 'Success') {
                 $scope.emailMessage = "Please check your email and confirm your Account";
             }
         });


     };

            $scope.professionList = [
             { value: "1",  profession: "Doctor" },
                { value: "2", profession: "Nurse" },
                { value: "2", profession: "Manager" }
            
    ];

}]);