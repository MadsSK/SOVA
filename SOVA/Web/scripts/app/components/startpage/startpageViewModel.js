define(['knockout', 'app/dataservice', 'app/config'], function(ko, dataservice, config) {
    return function() {
        var searchdata = ko.observableArray();
        var searchpage = ko.observable();
        var searchprev = ko.observable();
        var searchnext = ko.observable();
        var searchtotal = ko.observable();
        var searchString = ko.observable();

        ns.postbox.subscribe(function(data) {
            searchString(data);
        }, "searchBarContent", "startPageContext");

        var callback = function (data) {
            searchdata(data.data);
            searchpage(data.page);
            searchprev(data.prev);
            searchnext(data.next);
            searchtotal(data.total);
        };

        ko.computed(function() {
            dataservice.search(config.searchUrl + searchString(), callback);
        });
        
        var prevClick = function () {
            dataservice.search(searchprev(), callback);
        };
        var nextClick = function() {
            dataservice.search(searchnext(), callback);
        };

        var gotoquestion = function (questionUrl, root) {
            console.log("startpage:" +searchString());
            ns.postbox.notify({ component: config.questionComponent, url: questionUrl, prevComponent: root.currentComponent(), searchBarContent: searchString() }, "currentComponent");
            ns.postbox.notify("", "searchBarContent");
        };

        return {
            searchBarComponent: config.searchBarComponent,
            data: searchdata,
            total: searchtotal,
            pageNumber: searchpage,
            gotoquestion: gotoquestion,
            prev: searchprev,
            next: searchnext,
            prevClick: prevClick,
            nextClick: nextClick,
            searchString: searchString,
        }
    }
});