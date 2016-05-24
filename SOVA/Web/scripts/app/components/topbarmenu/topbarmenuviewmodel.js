define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function(params) {
        var currentComponent = params.currentComponent;

        var backEndRoute = ko.observable();

        var menuElements = ko.observableArray();

        return {
            menuElements: config.menuElements,
            backEndRoute: ko.observable(config.questionsUrl),
            currentComponent: currentComponent
        }
    };
});