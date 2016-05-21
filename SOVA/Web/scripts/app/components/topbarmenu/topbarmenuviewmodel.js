define(['knockout', 'app/dataservice'], function (ko, dataservice) {
    return function(params) {
        var currentComponent = params.currentComponent;

        //var menuElements = ko.observableArray();

        return {
            menuElements: config.menuElements,
            currentComponent: currentComponent
        }
    };
});