﻿define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function (params) {
        var question = ko.observable();
        var userComponent = ko.observable(config.userComponent);
        var tagsComponent = ko.observable(config.tagsComponent);
        var commentsComponent = ko.observable(config.commentsComponent);
        var answersComponent = ko.observable(config.answersComponent);

        dataservice.getQuestion(function(data) {
            question(data);
        }, 19);



        return {
            question: question,
            userComponent: userComponent,
            tagsComponent: tagsComponent,
            commentsComponent: commentsComponent,
            answersComponent: answersComponent
        }
    };
});