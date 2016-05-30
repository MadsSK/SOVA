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
        var prevComponent = ko.observable(params.prevComponent);

        dataservice.getQuestion(params, function (data) {
            question(data);
            body(data.body);
            marking(body().substring(markingStart(), markingEnd() - markingStart()));
            console.log(body().substring(markingStart(), markingEnd() - markingStart()));
            //TODO: we need to figure out how to set a highlight here og make it bold or somehting to show the annotation
            body(body().replace(marking(), "<div>" + "hey hey" + "</div>"));
            url(data.url);
        });

        var goback = function () {
            console.log(prevComponent());
            ns.postbox.notify({ component: prevComponent() }, "currentComponent");
        }

        return {
            question: question,
            body: body,
            userComponent: userComponent,
            tagsComponent: tagsComponent,
            commentsComponent: commentsComponent,
            answersComponent: answersComponent,
            url: url,
            goback: goback
        }
    };
});