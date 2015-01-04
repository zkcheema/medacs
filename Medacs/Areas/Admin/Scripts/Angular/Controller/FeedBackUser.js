MedacsAdmin.controller('FeedBackUser', [
    '$scope', '$http', 'feedBackUserService', function($scope, $http, feedBackUserService) {
        $scope.message = "";
        $scope.professionList = ["GP - Partner",
    "GP - Salaried",
    "GP - Locum",
    "GP - In training",
    "Hospital Doctor - Consultant",
    "Hospital Doctor - SAS",
    "Hospital Doctor - In training",
    "Nurse - Practice",
    "Nurse - Community",
    "Nurse - Hospital",
    "Nurse - Practitioner",
    "Nurse - Manager",
    "Manager - Practice Manager",
    "Manager - Ward Manager",
    "Manager - Other",
    "Admin - PA",
    "Admin - Receptionist",
    "Admin - Secretary",
    "Admin - Other",
    "Other: Clin - Colleague",
    "Other: Clin - Health Care Assistant",
    "Other: Non clin - Colleague"];
       

        feedBackUserService.GetFeedBackUserColleague().success(function(result) {

            $scope.feedBackUsersColleague = result.feedBackUserList;

        });

        feedBackUserService.GetFeedBackUserPatient().success(function (result) {

            $scope.feedBackUsersPatient = result.feedBackUserList;

        });

        $scope.DeleteFeedBackUser = function (feedbackUser) {
            feedBackUserService.DeleteFeedBackUser(feedbackUser.Id).success(function (data) {

                if (data.result === 'Success') {
                    feedBackUserService.GetFeedBackUser().success(function (result) {

                        return $scope.feedBackUsers = result.feedBackUserList;

                    });
                }
                 
            });
            
        };

        $scope.DeleteFeedBackUserPatient = function (feedbackUser) {
            feedBackUserService.DeleteFeedBackUser(feedbackUser.Id).success(function (data) {

                if (data.result === 'Success') {
                    feedBackUserService.GetFeedBackUser().success(function (result) {

                        return $scope.feedBackUsersPatient = result.feedBackUserList;

                    });
                }

            });

        };


        $scope.SendEmail = function (feedBackUser) {
            $scope.Id = feedBackUser.Id;
            $scope.FirstName = feedBackUser.FirstName;
            $scope.LastName = feedBackUser.LastName;
            $scope.Email = feedBackUser.Email;
            $scope.Profession = feedBackUser.Profession;
            feedBackUserService.SendEmail(feedBackUser).success(function (data) {
                if (data.result === 'Success') {
                    $scope.EamilMessage = "Email Sent Successfully";
                }


            });


        };
        
        $scope.editFeedBack = function (feedBackUser) {
           $scope.Id = feedBackUser.Id;
            $scope.FirstName = feedBackUser.FirstName;
            $scope.LastName = feedBackUser.LastName;
            $scope.Email = feedBackUser.Email;
            $scope.Profession = feedBackUser.Profession;
            
        };
        
        $scope.UpdateFeedBackUser = function (firstName, lastName, email, profession) {
            $scope.User = {};
            $scope.User.FirstName = firstName;
            $scope.User.LastName = lastName;
            $scope.User.Email = email;
            $scope.User.profession = profession;
            
            feedBackUserService.UpdateFeedBackUser($scope.Id, $scope.User).success(function (data) {
                if (data.result === 'Success') {
                    feedBackUserService.GetFeedBackUser().success(function (result) {

                        $scope.feedBackUsers = result.feedBackUserList;

                    });
                  }
               });
        };

        $scope.AddFeedBackUser = function (feedBackUser,feedBackUserType) {
            if ($scope.feedBackUser.$invalid) {
                $scope.Submitted = true;
                return;
            }

            feedBackUserService.CheckEmailExist(feedBackUser.Email).success(function (data) {
                if (data.result === 'failed') {
                    $scope.message = "Email Already Exist";
                    return;
                } else {
                    $scope.message = "";
                    feedBackUser.FeedBackUserType = feedBackUserType;
                    feedBackUserService.AddFeedBackUser(feedBackUser).success(function() {
                      
                            //feedBackUserService.GetFeedBackUser().success(function (result) {
                        return $scope.feedBackUsers = feedBackUser.feedBackUserList;
                               //});
                     });
                    
                }
            });
            
        };

        }]);