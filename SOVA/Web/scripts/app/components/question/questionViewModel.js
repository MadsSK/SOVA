define(['knockout', 'app/dataservice'], function (ko, dataservice) {
    return function (params) {
        var question = ko.observable();
        
        dataservice.getQuestion(function(data) {
            question(data);
        }, 19);
        
        return {
            question: question
        }
    };
});