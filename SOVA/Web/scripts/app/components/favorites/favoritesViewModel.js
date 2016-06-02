define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function (params) {
        var favoritesdata = ko.observableArray();
        var favoritesprev = ko.observable();
        var favoritesnext = ko.observable();
        var favoritestotal = ko.observable();
        var favoritespage = ko.observable();
        var questionComponent = ko.observable(config.questionComponent);
        var lineBodyComponent = ko.observable(config.lineBodyComponent);
        var searchuserid = ko.observable(1);

        var callback = function (data) {
            favoritesdata(data.data);
            favoritespage(data.page);
            favoritesprev(data.prev);
            favoritesnext(data.next);
            favoritestotal(data.total);
        };

        dataservice.getData(config.searchusersurl + searchuserid() + "/favorites", callback);

        var prevClick = function () {
            dataservice.getFavorites(favoritesprev(), callback);
        };
        var nextClick = function () {
            dataservice.getFavorites(favoritesnext(), callback);
        };

        var gotoquestion = function (questionUrl, root) {
            ns.postbox.notify({ component: config.questionComponent, url: questionUrl, prevComponent: root.currentComponent() }, "currentComponent");
        };

        return {
            data: favoritesdata,
            prevClick: prevClick,
            nextClick: nextClick,
            prev: favoritesprev,
            next: favoritesnext,
            total: favoritestotal,
            pageNumber: favoritespage,
            gotoquestion: gotoquestion,
            questionComponent: questionComponent,
            lineBodyComponent: lineBodyComponent
        }
    };
});