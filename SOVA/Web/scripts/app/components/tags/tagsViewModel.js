define(['knockout', 'app/dataservice'], function (ko, dataservice) {
    return function (params) {
        var tags = ko.observable();
        var tagsUrl = params.tagsUrl;
        var nextTags = ko.observable();
        var totalTags = ko.observable();
        var moreTags = ko.observable();

        var callback = function(data) {
            tags(data.data);
            nextTags(data.next);
            totalTags(data.total);
        };

        dataservice.getTags(tagsUrl, callback);

        var moreClick = function(nextTagsUrl) {
            dataservice.getTags(nextTagsUrl, function(data) {
                moreTags(data.data);
                nextTags(data.next);
                totalTags(data.total);
            });
            tags.push(moreTags);
        }

        return {
            tags: tags,
            total: totalTags,
            more: nextTags,
            moreClick: moreClick
        }
    };
});