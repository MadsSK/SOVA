define(['knockout', 'app/config'], function (ko, config) {
    return (function () {
        var currentComponent = ko.observable(config.defaultMenuItem);
        var clickedComponent = ko.observable(null);
        var currentParamsData = ko.observable();
        var clickParamsData = ko.observable(null);
        var params = ko.observable();

        //ns.postbox.notify(currentComponent, "currentComponent");

        ns.postbox.subscribe(function (value) {
            currentComponent(value.component);
            currentParamsData({ markingStart: value.markingStart, markingEnd: value.markingEnd, url: value.url, prevComponent: value.prevComponent });
        }, "currentComponent");

        ns.postbox.subscribe(function (value) {
            clickedComponent(value.component);
            clickParamsData({ markingStart: value.markingStart, markingEnd: value.markingEnd, url: value.url, prevComponent: value.prevComponent });
        }, "clickedComponent");



        return {
            currentComponent: currentComponent,
            menuComponent: config.menuComponent,
            currentParamsData: currentParamsData,
            searchBarComponent: config.searchBarComponent,
            clickedComponent: clickedComponent,
            clickParamsData: clickParamsData
        }
    });
});