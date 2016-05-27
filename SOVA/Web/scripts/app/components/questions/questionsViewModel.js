﻿define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function (params) {
        var questionsdata = ko.observableArray();
        var questionId = "bla";
        var questionsprev = ko.observable();
        var questionsnext = ko.observable();
        var questionstotal = ko.observable();
        var questionspage = ko.observable();
        var questionComponent = ko.observable(config.questionComponent);
        
        var callback = function (data) {
            questionsdata(data.data);
            questionspage(data.page);
            questionsprev(data.prev);
            questionsnext(data.next);
            questionstotal(data.total);
        };

        dataservice.getQuestions(callback);

        var prevClick = function () {
            dataservice.getQuestions(questionsprev(), callback);
        };
        var nextClick = function() {
            dataservice.getQuestions(questionsnext(), callback);
        };

        var pageNumber = questionspage;

        var gotoquestion = function (questionUrl) {
            console.log("notify " + questionUrl);
            //ns.postbox.notify(questionUrl, "questionurl");
            ns.postbox.notify({ component: config.questionComponent, url: questionUrl }, "currentComponent");
        };

        return {
            data: questionsdata,
            prevClick: prevClick,
            nextClick: nextClick,
            questionId: questionId,
            prev: questionsprev,
            next: questionsnext,
            total: questionstotal,
            pageNumber: pageNumber,
            gotoquestion: gotoquestion,
            questionComponent: questionComponent
        }
    };
});