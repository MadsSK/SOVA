define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function (params) {
        var question = ko.observable();
        var url = ko.observable(params.url);
        var userComponent = ko.observable(config.userComponent);
        var tagsComponent = ko.observable(config.tagsComponent);
        var commentsComponent = ko.observable(config.commentsComponent);
        var answersComponent = ko.observable(config.answersComponent);
        var searchUserId = ko.observable(params.searchUserId);
        var marking = ko.observable();
        var body = ko.observable();
        var prevComponent = ko.observable(params.prevComponent);
        var annotations = ko.observableArray();

        dataservice.getQuestion(url(), function (data) {
            question(data);
            body(data.body);
            url(data.url);
            if (searchUserId !== undefined || searchUserId !== null) {
                dataservice.getQuestionAnnotations(data.id, searchUserId(), function (annotationData) {
                    annotations(annotationData.data);
                    for (var i = 0; i < annotations().length; i++) {
                        marking(body().substring(annotations()[i].markingStart, annotations()[i].markingEnd));
                        //Dosen't work, we should instead save the part of the body that we want to annotate and then finde it with replace.
                        body(body().replace(marking(), '<em data-bind="click: showAnnotation(' + 'annotations()[i].body' + ')">' + marking() + '</em>'));
                    }
                });
            }
        });

        var goback = function () {
            console.log(prevComponent());
            ns.postbox.notify({ component: prevComponent() }, "currentComponent");
        }

        var showAnnotation = function(body) {
            console.log("blabla");
        }

        return {
            question: question,
            body: body,
            userComponent: userComponent,
            tagsComponent: tagsComponent,
            commentsComponent: commentsComponent,
            answersComponent: answersComponent,
            url: url,
            goback: goback,
            showAnnotation: showAnnotation
        }
    };
});