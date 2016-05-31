define(['knockout', 'app/dataservice', 'app/config'], function(ko, dataservice, config) {
    return function() {
        return {
            searchBarComponent: config.searchBarComponent
        }
    }
});