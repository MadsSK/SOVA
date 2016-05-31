define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function(params) {
        var currentComponent = ko.observable();

        var isMenuSelected = function(content) {
            return content && currentComponent() === content.toLowerCase();
        };

        
        var changeContent = function (content) {
            if (content !== undefined) {

                var tempArray = content;

                console.log(tempArray[0].toLowerCase());

                /*  if (content === "SOVA") {
                    currentComponent(config.defaultMenuItem);
                    ns.postbox.notify({ component: config.defaultMenuItem }, "currentComponent");
                } else {*/
                    currentComponent(content.toLowerCase());
                    ns.postbox.notify({ component: content.toLowerCase() }, "currentComponent");
                //}
            }
        };

        changeContent(config.defaultMenu);

        var searchBarContents = ko.observable("");

        ns.postbox.subscribe(function (value) {
            searchBarContents(value);
        }, "searchBarContent","topBarContext");

        var searchContentLength = ko.computed(function () {
            if (searchBarContents().length === 1) {
                $("#functionalSearchBar").slideDown("fast", function () {
                    console.log("hey");
                    $("#functionalSearchBar").show();
                    $("#functionalSearchBar").focus();
                });
            } else if (searchBarContents().length > 0) {
                $("#functionalSearchBar").show();
                $("#functionalSearchBar").focus();
            } else {
                $("#functionalSearchBar").slideUp("fast", function () {
                    $("#functionalSearchBar").hide();
                    console.log("yo");
                }); 
            }
            
            ns.postbox.notify(searchBarContents(), "searchBarContent");

            return searchBarContents().length;
        });

        return {
            menuElements: config.menuElements,
            currentComponent: currentComponent,
            changeContent: changeContent,
            isMenuSelected: isMenuSelected,
            searchBarContents: searchBarContents,
            searchContentLength: searchContentLength
        }
    };
});