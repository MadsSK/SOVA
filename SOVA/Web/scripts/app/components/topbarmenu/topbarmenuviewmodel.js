﻿define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function(params) {
        var currentComponent = params.currentComponent;

        var isMenuSelected = function(content) {
            return content && currentComponent() === content.toLowerCase();
        };
        
        var changeContent = function (content) {
            if(content !== undefined)
                currentComponent(content.toLowerCase());
        };

        changeContent(config.defaultMenu);
        
        return {
            menuElements: config.menuElements,
            currentComponent: currentComponent,
            changeContent: changeContent,
            isMenuSelected: isMenuSelected
        }
    };
});