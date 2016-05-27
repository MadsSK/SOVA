define(['knockout', 'app/dataservice', 'app/config', 'jquery'], function (ko, dataservice, config, $) {
    return function (params) {
        
        var searchBarContents = ko.observable("Test");

        var windowHeight = ko.computed(function() {
            return $(window).height();
        });

        var windowWidth = ko.computed(function() {
            return $(window).width();
        });

        var searchContentLength = ko.computed(function() {
            return searchBarContents().length;
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