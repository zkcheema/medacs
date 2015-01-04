
MedacsAdmin.service('feedBackUserService', ['$http', function ($http) {


    this.AddFeedBackUser = function (addUser) {
        return  $http({
            method: 'POST',
            url: '/Setup/SetupUser',
            data:addUser,

        });
    };
    

    this.SendEmail = function (feedBackUser) {
        return $http({
            method: 'POST',
            url: '/Setup/SendEmail',
            data: feedBackUser,

        });
    };
    this.DeleteFeedBackUser = function (id) {
        return $http.delete('/Setup/DeleteFeedBackUser/'+id);
    };


    this.UpdateFeedBackUser = function (id, feedbackuser) {
        return $http.put('/Setup/UpdateFeedBackUser/' + id, feedbackuser);
    };

    
    this.GetFeedBackUserColleague = function () {
        return $http.get('/Setup/GetFeedBackUserColleague');
    };

    this.GetFeedBackUserPatient = function () {
        return $http.get('/Setup/GetFeedBackUserPatient');
    };

    this.CheckEmailExist = function(email) {
        return $http.get('/Setup/CheckEmailExist?email='+email);
    };

    this.CheckUpdateEmail = function (email) {
        return $http.get('/Setup/CheckUpdateEmail?email=' + email);
    };



}]);