define(['jquery', 'app/config'], function ($, conf) {
    return {
        getAnnotation: function(url, callback) {
            $.getJSON(url, function(data) {
                callback(data);
            });
        },
        getAnnotations: function(url, callback) {
            if (callback == undefined) {
                callback = url;
                url = conf.annotationsUrl;
            }
            $.getJSON(url, function(data) {
                callback(data);
            });
        },
        getAnswers: function(url, callback) {
            if (url === undefined) {
                return;
            }
            $.getJSON(url, function(data) {
                callback(data);
            });
        },
        getComments: function(url, callback) {
            if (url === undefined) {
                return;
            }
            $.getJSON(url, function(data) {
                callback(data);
            });
        },
        getData: function(url, callback) {
            if (url == undefined) {
                return;
            }
            $.getJSON(url, function(data) {
                callback(data);
            });
        },
        getTags: function(url, callback) {
            if (url == undefined) {
                return;
            }
            $.getJSON(url, function(data) {
                callback(data);
            });
        },
        getQuestion: function(url, callback) {
            $.getJSON(url, function(data) {
                callback(data);
            });
        },
        getQuestionWithAnnotations: function(url, callback) {
            $.getJSON(url, function(data) {
                callback(data);
            });
        },
        getQuestionAnnotations: function(questionid, searchUserId, callback) {
            var url = conf.questionsUrl + "?questionid=" + questionid + "&searchuserid=" + searchUserId;
            $.getJSON(url, function(data) {
                callback(data);
            });
        },
        getQuestions: function(url, callback) {
            if (callback == undefined) {
                callback = url;
                url = conf.questionsUrl;
            }
            $.getJSON(url, function(data) {
                callback(data);
            });
        },
        updateData: function(url, data) {
            $.ajax({
                type: 'PUT',
                url: url,
                data: data

            });
        },
        postData: function(url, data) {
            $.ajax({
                type: 'POST',
                url: url,
                data: data

            });
        },
        search: function (url, callback) {
            $.getJSON(url, function (data) {
                callback(data);
            });
        }
    }
});