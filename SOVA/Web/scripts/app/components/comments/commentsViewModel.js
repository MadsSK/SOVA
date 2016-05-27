define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function (params) {
        var comments = ko.observableArray();
        var commentsUrl = params.commentsUrl;
        var nextComments = ko.observable();
        var totalComments = ko.observable();
        var userComponent = ko.observable(config.userComponent);

        var callback = function(data) {
            comments(data.data);
            nextComments(data.next);
            totalComments(data.total);
        }

        dataservice.getComments(commentsUrl, callback);

        var moreClick = function(nextCommentsUrl) {
            dataservice.getComments(nextCommentsUrl(), function(data) {
                comments(comments().concat(data.data));
                nextComments(data.next);
                totalComments(data.total);
            });
        }

        return {
            comments: comments,
            total: totalComments,
            more: nextComments,
            moreClick: moreClick,
            userComponent: userComponent
        }
    };
});