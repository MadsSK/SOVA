define(['knockout', 'app/config'], function (ko, config) {
    return (function () {
        var currentComponent = ko.observable(config.defaultMenuItem);


        return {
            currentComponent: currentComponent,
            menuComponent: config.menuComponent,
            searchBarComponent: config.searchBarComponent
        }
    });
});