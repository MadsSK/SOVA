define(['jquery', 'app/config'], function ($, conf) {
    return {
        getAnnotations: function (url, callback) {
            if (callback == undefined) {
                callback = url;
                url = conf.annotationsUrl;
            }
            $.getJSON(url, function (data) {
                callback(data);
            });
        },
        getAnswers: function (url, callback) {
            if (url === undefined) {
                return;
            }
            $.getJSON(url, function (data) {
                callback(data);
            });
        },
        getComments: function (url, callback) {
            if (url === undefined) {
                return;
            }
            $.getJSON(url, function (data) {
                callback(data);
            });
        },
        getData: function (url, callback) {
            if (url == undefined) {
                return;
            }
            $.getJSON(url, function (data) {
                callback(data);
            });
        },
        getTags: function (url, callback) {
            if (url == undefined) {
                return;
            }
            $.getJSON(url, function (data) {
                callback(data);
            });
        },
        getQuestion: function (url, callback) {
            $.getJSON(url, function (data) {
                callback(data);
            });
        },
        getQuestions: function (url, callback) {
        if (callback == undefined) {
            callback = url;
            url = conf.questionsUrl;
        }
        $.getJSON(url, function (data) {
            callback(data);
        });
    }
    }
});