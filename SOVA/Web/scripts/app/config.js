define([], function () {
    var server = 'http://localhost:55749';

    var frontEndVersion = "/api/v1.0.0/";

    var applicationName = "SOVA";

    // If you want to add additional menu elements, simply add them to this array, 
    // then define functionality in the view model of the tobarmenu component
    var menuElements = [
        "Questions",                        // 0
        "Favorites",                        // 1
        "Annotations",                      // 2
    ];

    // Array for components that do not belong to the top bar menu
    var nonMenuComponentElements = [
        "Question",                         // 0 
        "FullPagePost",                     // 1
        "Marking",                          // 2
        "LineBody",                         // 3
        "User",                             // 4
        "Tags",                             // 5
        "Comments",                         // 6
        "Answers",                          // 7
        "SearchBar",                        // 8
        "StartPage"                         // 9

    ];

    var searchuserid = 1;

    ns.postbox.subscribe(function(value) {
        searchuserid(value);
    }, "SearchUserId");

    return {
        // back-end routes
        questionsUrl: server + frontEndVersion + menuElements[0].toLowerCase(),
        annotationsUrl: server + frontEndVersion + menuElements[2].toLowerCase(),
        searchuserannotationsurl: server + frontEndVersion + "searchusers/" + 1 + "/" + menuElements[2].toLowerCase(),

        // This one won't work because our favourites are stored on a per searchuser basis :C
        // We need a userId variable that holds the current user
        favoritesUrl: server + frontEndVersion + "searchusers/" + 1 + "/" + menuElements[1].toLowerCase(),
        searchUrl: server + frontEndVersion + "search?searchstring=",

        
        // menu
        menuElements: menuElements,
        defaultMenuItem: nonMenuComponentElements[9].toLowerCase(),        

        // components
        menuComponent: "topbarmenu",
        questionsComponent: menuElements[0].toLowerCase(),
        favoritesComponent: menuElements[1].toLowerCase(),
        annotationsComponent: menuElements[2].toLowerCase(),
        questionComponent: nonMenuComponentElements[0].toLowerCase(),
        fullPagePostComponent: nonMenuComponentElements[1].toLowerCase(),
        markingComponent: nonMenuComponentElements[2].toLowerCase(),
        lineBodyComponent: nonMenuComponentElements[3].toLowerCase(),
        userComponent: nonMenuComponentElements[4].toLowerCase(),
        tagsComponent: nonMenuComponentElements[5].toLowerCase(),
        commentsComponent: nonMenuComponentElements[6].toLowerCase(),
        answersComponent: nonMenuComponentElements[7].toLowerCase(),
        searchBarComponent: nonMenuComponentElements[8].toLowerCase(),
        startPageComponent: nonMenuComponentElements[9].toLowerCase(),
        applicationName: applicationName
    }
});