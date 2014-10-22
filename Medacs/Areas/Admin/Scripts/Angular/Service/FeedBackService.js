MedacsAdmin.service('feedBackService', ['$http', function ($http) {
    
    this.GetFeedBacks= function() {
        return $http.get('/Admin/FeedBack/GetFeedBacks');
    }

    this.GetFeedBackSections= function (id) {
        return $http.get('/Admin/FeedBack/GetFeedBackSections?id=' + id);
    }

    this.GetOptionGroup = function () {
        return $http.get('/Admin/FeedBack/GetOptionGroup');
    }


    this.GetInputTypes = function () {
        return $http.get('/Admin/FeedBack/GetInputTypes');
    }

    this.AddOptionGroup = function (optionGroup) {
        return $http({
            method: 'POST',
            url: '/Admin/FeedBack/AddOptionGroup',
            data: optionGroup,
        });

    }

    this.AddQestion = function (questionForm) {
        return $http({
            method: 'POST',
            url: '/Admin/FeedBack/CreateQuestion',
            data: questionForm,
        });

    }
    this.AddFeedBackSection = function (feedBackSection) {

        return $http({
            method: 'POST',
            url: '/Admin/FeedBack/AddFeedBackSection',
            data: feedBackSection,

        });

    };

    this.AddFeedBack = function (feedBackForm) {
        return $http({
            method: 'POST',
            url: '/Admin/FeedBack/CreateFeedBack',
            data: feedBackForm,
        });

    }
}]);