define(['knockout', 'app/config'], function (ko, config) {
    return (function () {
        var currentComponent = ko.observable(config.defaultMenuItem);
        var paramsData = ko.observable();

        ns.postbox.notify(currentComponent, "currentComponent");

        
        ns.postbox.subscribe(function (value) {
            currentComponent(value.component);
            paramsData({ markingStart: value.markingStart, markingEnd: value.markingEnd, url: value.url, prevComponent: value.prevComponent, searchUserId: value.searchUserId });
        }, "currentComponent");

        ns.postbox.subscribe(function () {
        }, "searchBarContent");

        ns.postbox.subscribe(function (value) {
            annotationUrl(value.annotationUrl);
            console.log(annotationUrl());
        }, "annotationUrl");



        return {
            currentComponent: currentComponent,
            menuComponent: config.menuComponent,
            paramsData: paramsData,
            searchBarComponent: config.searchBarComponent,
            startPageComponent: config.startPageComponent
        }
    });
});