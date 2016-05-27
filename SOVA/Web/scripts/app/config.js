define([], function () {
    var server = 'http://localhost:55749';

    var frontEndVersion = "/api/v1.0.0/";

    // If you want to add additional menu elements, simply add them to this array, 
    // then define functionality in the view model of the tobarmenu component
    var menuElements = [
        "Questions",                        // 0
        "Favorites",                        // 1
        "Annotations"                       // 2
    ];

    // Array for components that do not belong to the top bar menu
    var nonMenuComponentElements = [
        "FullPagePost",                     // 0
        "ListElement",                      // 1
        "ListOfElementsWithSearch"          // 2
    ];

    return {
        // back-end routes
        questionsUrl: server + frontEndVersion + menuElements[0].toLowerCase(),
        annotationsUrl: server + frontEndVersion + menuElements[2].toLowerCase(),

        // This one won't work because our favourites are stored on a per searchuser basis :C
        // We need a userId variable that holds the current user
        favoritesUrl: server + frontEndVersion + "searchusers/" + 1 + "/" + menuElements[1].toLowerCase(),

        
        // menu
        menuElements: menuElements,
        defaultMenuItem: menuElements[0].toLowerCase(),        


        // components
        menuComponent: "topbarmenu",
        questionsComponent: menuElements[0].toLowerCase(),
        favoritesComponent: menuElements[1].toLowerCase(),
        annotationsComponent: menuElements[2].toLowerCase(),
        fullPagePostComponent: nonMenuComponentElements[0].toLowerCase(),
        listElementComponent: nonMenuComponentElements[1].toLowerCase(),
        listOfElementsWithSearchComponent: nonMenuComponentElements[2].toLowerCase()
    }
});