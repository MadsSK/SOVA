define(['knockout', 'app/dataservice', 'app/config', 'jquery'], function (ko, dataservice, config, $) {
    return function (params) {
        
        var searchBarContents = ko.observable("");

        var windowHeight = ko.observable($(window).height());

        var windowWidth = ko.observable($(window).width());

        var searchContentLength = ko.computed(function () {
            if (searchBarContents().length > 0) {
                $("#primarySearchBar").slideUp("fast", function () {
                    $("#primarySearchBar").hide();
                });
            } else {
                $("#primarySearchBar").slideDown("fast", function () {
                    $("#primarySearchBar").show();
                    $("#primarySearchBar").focus();
                });
            }

            ns.postbox.notify(searchBarContents(), "searchBarContent");

            return searchBarContents().length;
        });

        ns.postbox.subscribe(function(value) {
            searchBarContents(value);
        },"searchBarContent","searchBarContext  ");


        // When the window is resized...
        $(window).resize(function() {
            windowWidth($(window).width());
            windowHeight($(window).height());
            searchBarPositionHandler();
        });

        // Add CSS
        $("#div").css('position', 'fixed');
        searchBarPositionHandler();
        $("#functionalSearchBar").hide();
        
        function searchBarPositionHandler() {

            // Set search bar to vertical middle
            $("#div").css('top', (windowHeight() / 2) + 'px');

            // Small "hack" that handles an apparent bug in jquery-bootstrap interactions in narrow screen resolutions.
            // 667 is the pixel cutoff where col-sm is meant to be triggered, but it doesn't, so...
            if (windowWidth() < 667) {
                $("#div").css('width', (windowWidth() - 40) + 'px');
            }
        };

        return {
            searchBarContents: searchBarContents,
            windowWidth: windowWidth,
            windowHeight: windowHeight,
            horizontalHalf: windowWidth / 2,
            verticalHalf: windowHeight / 2, 
            searchContentLength: searchContentLength
    }
    };
});