define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function (params) {
        var questionid = ko.observable();
        var question = ko.observable();
        var url = ko.observable();
        var userComponent = ko.observable(config.userComponent);
        var tagsComponent = ko.observable(config.tagsComponent);
        var commentsComponent = ko.observable(config.commentsComponent);
        var answersComponent = ko.observable(config.answersComponent);

        dataservice.getQuestion(params.url, function (data) {
            question(data);
            url(data.url);
        });
        
        return {
            question: question,
            userComponent: userComponent,
            tagsComponent: tagsComponent,
            commentsComponent: commentsComponent,
            answersComponent: answersComponent,
            url: url
        }
    };
});