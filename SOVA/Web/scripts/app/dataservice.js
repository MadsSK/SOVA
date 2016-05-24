define(['jquery', 'app/config'], function ($, conf) {
    return {
        getAnnotations: function (url, callback) {
            if (callback == undefined) {
                callback = url;
                url = conf.annotationsUrl;
            }
            $.getJSON(url, function(data) {
                console.log("getAnnotations: " + data);
                callback(data);
            });
        },
        getQuestion: function (url, questionid, callback) {
            if (callback == undefined) {
                callback = url;
                url = conf.questionsUrl + "/" + questionid;
            }
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