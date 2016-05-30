define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function (params) {
        var question = ko.observable();
        var url = ko.observable();
        var userComponent = ko.observable(config.userComponent);
        var tagsComponent = ko.observable(config.tagsComponent);
        var commentsComponent = ko.observable(config.commentsComponent);
        var answersComponent = ko.observable(config.answersComponent);
        var markingStart = ko.observable(params.markingStart);
        var markingEnd = ko.observable(params.markingEnd);
        var marking = ko.observable();
        var body = ko.observable();

        dataservice.getQuestion(params, function (data) {
            question(data);
            body(data.body);
            marking(body().substring(markingStart(), markingEnd() - markingStart()));
            console.log(body().substring(markingStart(), markingEnd() - markingStart()));
            body(body().replace(marking(), "<div>" + "hey hey" + "</div>"));
            url(data.url);
        });

        return {
            question: question,
            body: body,
            userComponent: userComponent,
            tagsComponent: tagsComponent,
            commentsComponent: commentsComponent,
            answersComponent: answersComponent,
            url: url
        }
    };
});