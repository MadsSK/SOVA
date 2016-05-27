define(['knockout', 'app/dataservice', 'app/viewmodel'], function (ko, dataservice, viewmodel) {
    return function (params) {
        var annotations = ko.observableArray();
        var questionId = "bla";
        var curpage = ko.observable();
        var prevpage = ko.observable();
        var nextpage = ko.observable();
        var total = ko.observable();
        var callback = function(data) {
            annotations(data.data);
            curpage(data.page);
            prevpage(data.prev);
            nextpage(data.next);
            total(data.total);
        };

        dataservice.getAnnotations(callback);

        ko.utils.arrayForEach(annotations, function(annotation) {
            console.log(annotation);
        });
        
        var gotoquestion = function(content) {
            ns.postbox.notify(content, "currentComponent");
        }


        return {
            data: annotations,
            prevClick: function () {
                dataservice.getAnnotations(prevpage, annotations);
            },
            nextClick: function () {
                dataservice.getAnnotations(nextpage, annotations);
            },
            questionId: questionId,
            prev: prevpage,
            next: nextpage,
            total: total,
            page: curpage,
            title: "hey hey",
            gotoquestion: gotoquestion

        }
    };
});