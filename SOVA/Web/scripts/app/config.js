define([], function () {
    var server = 'http://localhost:55749';

    var frontEndVersion = "/api/v1.0.0/";

    var menuElements = [
        "Questions",                        // 0
        "Favorites",                        // 1
        "Annotations",                      // 2
        "FullPagePost",                     // 3
        "ListElement",                      // 4
        "ListOfElementsWithSearch"          // 5
    ];

    return {
        // back-end routes
        questionsUrl: server + frontEndVersion + menuElements[0].toLowerCase(),
        annotationsUrl: server + frontEndVersion + menuElements[2].toLowerCase(),

        // This one won't work because our favourites are stored on a per searchuser basis :C
        // We need a userId variable that holds the current user
        favoritesUrl: server + frontEndVersion + "searchusers/" + userId + "/" + menuElements[1].toLowerCase(),

        
        // menu
        menuElements: menuElements,
        defaultMenuItem: menuElements[0].toLowerCase(),        


        // components
        menuComponent: "topbarmenu",
        questionsComponent: menuElements[0].toLowerCase(),
        favoritesComponent: menuElements[1].toLowerCase(),
        annotationsComponent: menuElements[2].toLowerCase(),
        fullPagePostComponent: menuElements[3].toLowerCase(),
        listElementComponent: menuElements[4].toLowerCase(),
        listOfElementsWithSearchComponent: menuElements[5].toLowerCase()
    }
});