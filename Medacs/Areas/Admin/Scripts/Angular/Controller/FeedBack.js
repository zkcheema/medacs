MedacsAdmin.controller('FeedBack', [
    '$scope', '$http', 'feedBackService', function($scope, $http, feedBackService) {
        
        $scope.items = [{ id: 1, name: 'CheckBox' }, { id: 2, name: 'RadioButton' }, { id: 3, name: 'TextBox' }];
        $scope.InputTypeName = null;

        $scope.feedbackId = "4FEE0E81-ED4A-E411-ADD7-001999EF2DC2";

    feedBackService.GetFeedBacks().success(function(result) {

        return $scope.feedBackList = result.feebackViewList;
    });

        feedBackService.GetFeedBackSections($scope.feedbackId).success(function (result) {

            return $scope.feedBackSectionList = result.feebackSection;

        });

        var counter = 0;
        $scope.questionelemnt = [{ id: counter, question: 'OptionChoice', OptionChoiceText: '', inline: true }];

        $scope.AddoptionGroup = function($event, optionGroup) {

            if (optionGroup.$invalid)
                return;
            optionGroup.OptionChoicesViewModel = $scope.questionelemnt;
            feedBackService.AddOptionGroup(optionGroup).success(function(result) {

                return result;
            });
        };
        $scope.newItem = function($event) {
            counter++;
            $scope.questionelemnt.push({ id: counter, question: 'OptionChoice', OptionChoiceText: '', inline: true });
            $event.preventDefault();
        }
        $scope.inlinef = function($event, inlinecontrol) {
            var checkbox = $event.target;
            if (checkbox.checked) {
                $('#' + inlinecontrol).css('display', 'inline');
            } else {
                $('#' + inlinecontrol).css('display', '');
            }

        }
        $scope.showitems = function($event) {
            $('#displayitems').css('visibility', 'none');
        }


        feedBackService.GetOptionGroup().success(function(result) {

            return $scope.OptionGroup = result.OptionGroupList;

        });

        feedBackService.GetInputTypes().success(function (result) {

            return $scope.InputType = result.InputTypesList;

        });
        
        $scope.AddQestion = function (questionForm) {

            questionForm.FeedBackSectionId = angular.element(document.getElementsByName('FeedBackSectionId')[0]).val();
            
            feedBackService.AddQestion(questionForm).success(function (result)
            {

            });
        };

        $scope.AddFeedBackSection = function (feedBackSectionForm) {
            feedBackSectionForm.FeedBackId = angular.element(document.getElementsByName('FeedBackId')[0]).val();
            feedBackService.AddFeedBackSection(feedBackSectionForm).success(function() {
                
            });

        };



        $scope.AddFeedBack = function (feedBackForm) {
            feedBackService.AddFeedBack(feedBackForm).success(function() {

            });

        };


}]);