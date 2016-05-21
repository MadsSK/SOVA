define(['jquery', 'app/config', 'app/app'], function ($, conf, app) {
    return {
        getSearchUserAnnotations: function (url, searchuserid, callback) {
            if (callback == undefined) {
                callback = url;
                app.ns.postbox.notify(searchuserid, "searchUserId");
                url = conf.searchUserAnnotationsUrl;
            }
            $.getJSON(url, function (data) {
                callback(data);
            });
        },
    }
});