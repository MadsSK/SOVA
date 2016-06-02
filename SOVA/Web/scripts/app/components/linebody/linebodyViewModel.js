define(['knockout', 'app/dataservice', 'app/viewmodel'], function (ko, dataservice, viewmodel) {
    return function (params) {
        var linebody = ko.observable(params);

        linebody(linebody().substring(0, 100) + "...</html>");

        return {
            linebody: linebody
        }
    };
});