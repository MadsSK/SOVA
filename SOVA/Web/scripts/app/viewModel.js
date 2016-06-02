define(['knockout', 'app/config', 'modernizer', 'text'], function (ko, config, md, txt) {
        return (function () {
        var currentComponent = ko.observable(config.defaultMenuItem);
        var paramsData = ko.observable();

        ns.postbox.notify(currentComponent, "currentComponent");

        ns.postbox.subscribe(function(value) {
            currentComponent(value.component);
            paramsData({ url: value.url });
            //ns.postbox.notify(value.url, "questionurl");
        }, "currentComponent");

        ns.postbox.subscribe(function() {
        }, "searchBarContent");

        return {
            currentComponent: currentComponent,
            menuComponent: config.menuComponent,
            paramsData: paramsData,
            searchBarComponent: config.searchBarComponent,
            startPageComponent: config.startPageComponent
        }   
    });
});