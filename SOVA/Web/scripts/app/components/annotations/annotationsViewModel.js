define(['knockout', 'app/dataservice'], function (ko, dataservice) {
    return function (params) {
        var annotationdata = ko.observableArray();
        var questionId = "bla";
        var annotationpage = ko.observable();
        var annotationprev = ko.observable();
        var annotationnext = ko.observable();
        var annotationtotal = ko.observable();
        var callback = function(data) {
            annotationdata(data.data);
            annotationpage(data.page);
            annotationprev(data.prev);
            annotationnext(data.next);
            annotationtotal(data.total);
        };

        dataservice.getAnnotations(callback);

        annotationdata().forEach(function(entry) {
            console.log(entry);
        });


        return {
            data: annotationdata,
            prevClick: function () {
                dataservice.getAnnotations(annotationprev, annotationdata);
            },
            nextClick: function () {
                dataservice.getAnnotations(annotationnext, annotationdata);
            },
            questionId: questionId,
            prev: annotationprev,
            next: annotationnext,
            total: annotationtotal,
            page: annotationpage

        }
    };
});