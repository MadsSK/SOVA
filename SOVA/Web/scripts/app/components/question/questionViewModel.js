define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function (params) {
        var question = ko.observable();
        var url = ko.observable(params.url);
        var userComponent = ko.observable(config.userComponent);
        var tagsComponent = ko.observable(config.tagsComponent);
        var commentsComponent = ko.observable(config.commentsComponent);
        var answersComponent = ko.observable(config.answersComponent);
        var annotationUrl = ko.observable();
        var searchUserId = ko.observable(params.searchUserId);
        var body = ko.observable();
        var prevComponent = ko.observable(params.prevComponent);
        var annotations = ko.observableArray();
        var markings = ko.observableArray();
        var annotationBody = ko.observable();
        var isNewAnnotation = ko.observable(false);

        var getSelectionText = function () {
            var text = "";
            if (window.getSelection) {
                text = window.getSelection().toString();
            } else if (document.selection && document.selection.type != "Control") {
                text = document.selection.createRange().text;
            }
            isNewAnnotation(true);
        }

        document.onmouseup = getSelectionText;

        dataservice.getQuestion(url(), function (data) {
            question(data);
            body(data.body);
            url(data.url);
            if (searchUserId !== undefined || searchUserId !== null) {
                dataservice.getQuestionAnnotations(data.id, searchUserId(), function (annotationData) {
                    annotations(annotationData.data);
                    for (var i = 0; i < annotations().length; i++) {
                        //body().substring(annotations()[i].markingStart, annotations()[i].markingEnd);
                        markings.push(body().substring(annotations()[i].markingStart, annotations()[i].markingEnd));
                        console.log(markings());
                    }
                    for (var i = 0; i < annotations().length; i++) {
                        body(body().replace(markings()[i], '<em onClick = \"ns.postbox.notify({annotationUrl: \'' + annotations()[i].url + '\'}, \'annotationUrl\');\">' + markings()[i] + '</em>'));
                    }
                });
            }

        });
        /*$parents(1).showAnnotation(' + 'annotations()[i].url' + ')"*/
        /*onClick = "$root.showAnnotation(\"blablba\")"*/

        var goback = function () {
            ns.postbox.notify({ component: prevComponent() }, "currentComponent");
        }

        var getAnnotationBody = function (content, annotationUrl) {
            dataservice.getAnnotation(annotationUrl().annotationUrl, function (data) {
                isNewAnnotation(false);
                annotationBody(data.body);
            });
        };

        var saveAnnotation = function () {
            console.log("URL: " + annotationUrl().annotationUrl + " Body: " + annotationBody());
            dataservice.getAnnotation(annotationUrl().annotationUrl, function (data) {
                var newAnnotation = ko.toJS({
                    Body: annotationBody(),
                    MarkingStart: data.markingStart,
                    MarkingEnd: data.markingEnd,
                    PostId: data.postId,
                    CommentId: data.commentId,
                    SearchUserId: data.searchUserId
                });
                dataservice.updateData(annotationUrl().annotationUrl, newAnnotation);
            });
        }

        var createAnnotation = function () {
            console.log("Body: " + annotationBody() + " questionId: " + question().id);
            var newAnnotation = ko.toJS({
                Body: annotationBody(),
                MarkingStart: null,
                MarkingEnd: null,
                PostId: question().id,
                CommentId: null,
                SearchUserId: 1
            });
            dataservice.postData(config.annotationsUrl, newAnnotation);
            isNewAnnotation(false);
        }


        ns.postbox.subscribe(function (data) {
            annotationUrl(data);
        }, "annotationUrl");

        return {
            question: question,
            body: body,
            userComponent: userComponent,
            tagsComponent: tagsComponent,
            commentsComponent: commentsComponent,
            answersComponent: answersComponent,
            url: url,
            goback: goback,
            annotationUrl: annotationUrl,
            getAnnotationBody: getAnnotationBody,
            annotationBody: annotationBody,
            saveAnnotation: saveAnnotation,
            isNewAnnotation: isNewAnnotation,
            createAnnotation: createAnnotation
        }
    };
});