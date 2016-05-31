define(['knockout', 'app/dataservice', 'app/viewmodel'], function (ko, dataservice, viewmodel) {
    return function(params) {
        var marking = ko.observable();
        var annotation = ko.observable(params);
        dataservice.getData(annotation().url, function (data) {
            marking(data.body.substring(annotation().markingStart, annotation().markingEnd));
        });
        
        return {
            marking: marking
        }
    };
});