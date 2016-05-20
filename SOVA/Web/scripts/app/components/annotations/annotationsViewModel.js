define(['knockout', 'app/dataservice'], function (ko, dataservice) {
    return function (params) {
        var annotations = ko.observableArray();

        dataservice.getAnnotations(annotations, params);

        return {
            annotations: annotations
        }

    };
});