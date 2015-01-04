MedacsAdmin.controller('Account', ['$scope', '$http', 'AccountService', '$window', function ($scope, $http, accountService, $window) {

    $scope.emailMessage = "Hello";
    var getUrlVars;
    getUrlVars = function() {
        var hash, hashes, i, vars;
        vars = [];
        hash = void 0;
        hashes = $window.location.href.slice($window.location.href.indexOf('?') + 1).split('&');
        i = 0;
        while (i < hashes.length) {
            hash = hashes[i].split('=');
            vars.push(hash[0]);
            vars[hash[0]] = hash[1];
            i++;
        }
        return vars;
    }


    $scope.LoginUser = function (logindetails) {
        if ($scope.LoginForm.$invalid) {
            $scope.Submitted = true;
            return;
        }


            accountService.Login(logindetails).success(function (data) {
                
                if (data.result === 'Success') {
                    
                   $window.location.href='/Home/Index';
                } else {
                    $scope.loginmessage = "UserName Or Password are Incorrect";
                }
                var redirectUrl = decodeURIComponent(getUrlVars()["ReturnUrl"]);
                if (redirectUrl != 'undefined') {
                    $window.location.href = redirectUrl;
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