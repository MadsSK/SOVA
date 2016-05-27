define(['knockout', 'app/dataservice', 'app/config', 'jquery'], function (ko, dataservice, config, $) {
    return function (params) {
        
        var searchBarContents = ko.observable("");

        var windowHeight = ko.observable($(window).height());

        var windowWidth = ko.observable($(window).width());

        var searchContentLength = ko.computed(function() {
            return searchBarContents().length;
        });

        $(window).resize(function() {
            windowWidth($(window).width());
        });

        $(window).resize(function () {
            windowHeight($(window).height());
        });

        // Fill with fun stuff
        return {
            searchBarContents: searchBarContents,
            windowWidth: windowWidth,
            windowHeight: windowHeight,
            searchContentLength: searchContentLength
    }
    };
});