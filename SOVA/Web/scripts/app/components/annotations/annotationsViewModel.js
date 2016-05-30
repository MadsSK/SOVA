define(['knockout', 'app/dataservice', 'app/viewmodel', 'app/config'], function (ko, dataservice, viewmodel, config) {
    return function (params) {
        var annotations = ko.observableArray();
        var questionComponent = ko.observable();
        var lineBodyComponent = ko.observable(config.lineBodyComponent);
        var showMessage = ko.observable(false);
        var curpage = ko.observable();
        var prevpage = ko.observable();
        var nextpage = ko.observable();
        var total = ko.observable();
        
        var callback = function (data) {
            annotations(data.data);
            curpage(data.page);
            prevpage(data.prev);
            nextpage(data.next);
            total(data.total);
        };

        dataservice.getAnnotations(callback);

        var gotoquestion = function (markingStart, markingEnd, questionUrl, root) {
            console.log(questionUrl);
            ns.postbox.notify({ component: config.questionComponent, markingStart: markingStart, markingEnd: markingEnd, url: questionUrl, prevComponent: root.currentComponent() }, "currentComponent");
        };

        return {
            data: annotations,
            prevClick: function() {
                dataservice.getAnnotations(prevpage, annotations);
            },
            nextClick: function() {
                dataservice.getAnnotations(nextpage, annotations);
            },
            prev: prevpage,
            next: nextpage,
            total: total,
            page: curpage,
            title: "hey hey",
            markingComponent: ko.observable(config.markingComponent),
            questionComponent: questionComponent,
            showMessage: showMessage,
            gotoquestion: gotoquestion,
            lineBodyComponent: lineBodyComponent
        }
    };
});