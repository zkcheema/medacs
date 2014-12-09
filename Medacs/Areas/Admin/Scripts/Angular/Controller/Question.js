MedacsAdmin.controller('Question', [
    '$scope', '$http', 'feedBackService', function ($scope, $http, feedBackService) {


        feedBackService.GetQuestionBySection($scope.feesbackSectionId).success(function (result) {

            $scope.QuestionList = result.listofQuestion;

        });

        feedBackService.GetOptionGroup().success(function (result) {

            return $scope.OptionGroup = result.OptionGroupList;

        });

        feedBackService.GetInputTypes().success(function (result) {

            return $scope.InputType = result.InputTypesList;

        });
        
        $scope.AddQestion = function (questionForm) {

            questionForm.FeedBackSectionId = angular.element(document.getElementsByName('FeedBackSectionId')[0]).val();

            feedBackService.AddQestion(questionForm).success(function (result) {

            });
        };

        var counter = 0;
        $scope.questionelemnt = [{ id: counter, question: 'OptionChoice', OptionChoiceText: '', inline: true }];

        $scope.AddoptionGroup = function ($event, optionGroup) {

            if (optionGroup.$invalid)
                return;
            optionGroup.OptionChoicesViewModel = $scope.questionelemnt;
            feedBackService.AddOptionGroup(optionGroup).success(function (result) {

                return result;
            });
        };
        $scope.newItem = function ($event) {
            counter++;
            $scope.questionelemnt.push({ id: counter, question: 'OptionChoice', OptionChoiceText: '', inline: true });
            $event.preventDefault();
        }
        $scope.inlinef = function ($event, inlinecontrol) {
            var checkbox = $event.target;
            if (checkbox.checked) {
                $('#' + inlinecontrol).css('display', 'inline');
            } else {
                $('#' + inlinecontrol).css('display', '');
            }

        }
        $scope.showitems = function ($event) {
            $('#displayitems').css('visibility', 'none');
        }



    }]);