MedacsAdmin.controller('FeedBack', ['$scope', '$http', 'feedBackService', function($scope, $http, feedBackService) {
        
    $scope.items = [{ id: 1, name: 'CheckBox' }, { id: 2, name: 'RadioButton' }, { id: 3, name: 'TextBox' }, { id: 4, name: 'Label' }];
        $scope.InputTypeName = null;

        $scope.feedbackId = angular.element(document.getElementsByName('FeedBackId')[0]).val();
       

    $scope.feesbackSectionId = angular.element(document.getElementsByName('FeedBackSectionId')[0]).val();

    feedBackService.GetFeedBacks().success(function(result) {

        return $scope.feedBackList = result.feebackViewList;
    });

        feedBackService.GetFeedBackSections($scope.feedbackId).success(function (result) {

            return $scope.feedBackSectionList = result.feebackSection;

        });
        
      
        $scope.AddFeedBackSection = function (feedBackSectionForm) {
            feedBackSectionForm.FeedBackId = angular.element(document.getElementsByName('FeedBackId')[0]).val();
            feedBackService.AddFeedBackSection(feedBackSectionForm).success(function() {
                
            });

        };
    $scope.AddFeedBack = function (feedBackForm) {
            feedBackService.AddFeedBack(feedBackForm).success(function() {
          });
        };
    $scope.editFeedBack = function (formvalues) {
            $scope.FeedBackEdit.Description = formvalues.Description;
            $scope.FeedBackEdit.Id = formvalues.Id;
            $scope.FeedBackEdit.StartDateTime = formvalues.StartDateTime;
            $scope.FeedBackEdit.EndDateTime = formvalues.EndDateTime;
            $scope.FeedBackEdit.Instruction = formvalues.Instruction;
           $scope.FeedBackEdit.IsOpen = formvalues.IsOpen;
            
        };
        
        $scope.updateFeedBack = function (editFeedBack) {
            feedBackService.EditFeedBack(editFeedBack).success(function() {
                feedBackService.GetFeedBacks().success(function (result) {
                 $scope.feedBackList = result.feebackViewList;
                });

            });
            
        };

        

}]);