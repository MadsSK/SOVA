define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function (params) {
        var answers = ko.observableArray();
        var answersUrl = params.answersUrl;
        var nextAnswers = ko.observable();
        var totalAnswers = ko.observable();
        var userComponent = ko.observable(config.userComponent);
        var commentsComponent = ko.observable(config.commentsComponent);

        var callback = function(data) {
            answers(data.data);
            nextAnswers(data.next);
            totalAnswers(data.total);
        }

        dataservice.getAnswers(answersUrl, callback);

        var moreClick = function (nextAnswersUrl) {
            dataservice.getAnswers(nextAnswersUrl(), function (data) {
                answers(answers().concat(data.data));
                nextAnswers(data.next);
                totalAnswers(data.total);
            });
        }

        return {
            answers: answers,
            total: totalAnswers,
            more: nextAnswers,
            moreClick: moreClick,
            userComponent: userComponent,
            commentsComponent: commentsComponent
        }
    };
});