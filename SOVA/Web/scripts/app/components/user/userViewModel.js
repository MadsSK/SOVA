define(['knockout', 'app/dataservice'], function (ko, dataservice) {
    return function (params) {
        var user = ko.observable();
        var userUrl = params.userUrl;
        
        dataservice.getData(userUrl, function(data) {
            user(data);
        });
        
        return {
            user: user
        }
    };
});