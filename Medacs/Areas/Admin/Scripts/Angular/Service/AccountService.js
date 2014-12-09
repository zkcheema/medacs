MedacsAdmin.service('AccountService', ['$http', function ($http) {


    this.Register = function (register) {
        return $http({
            method: 'POST',
            url: '/Account/Register',
            data: register,
           });

    }

    this.Login = function (details) {
        return $http({
            method: 'POST',
            url: '/Account/Login',
            data: details,
            
        });

      }
    
    this.forgotEmail= function(email) {
        return $http({
            method: 'Post',
            url: '/Account/ForgotPassword',
            data:email
        });
    }

    

}]);