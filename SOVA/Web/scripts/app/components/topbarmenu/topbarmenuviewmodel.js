define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function(params) {
        var currentComponent = params.currentComponent;

        //var menuElements = ko.observableArray();

        return {
            menuElements: config.menuElements,
            currentComponent: currentComponent
        }
    };
});