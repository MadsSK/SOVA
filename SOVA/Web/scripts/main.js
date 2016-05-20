(function () {
    requirejs.config({
        baseUrl: 'Scripts',
        paths: {
            knockout: 'lib/knockout-3.4.0',
            jquery: 'lib/jquery-2.2.3.min',
            text: 'lib/text',
            bootstrap: 'lib/bootstrap.min'
        }
    });
})();

require(['knockout', 'app/viewmodel', 'app/config'], function (ko, viewmodel, config) {

    // Annotations
    ko.components.register(config.questionsComponent, {
        viewModel: { require: 'app/components/menuannotations/annotations' },
        template: { require: 'text!app/components/annotations/annotations.html' }
    });

    // Favorites
    ko.components.register(config.questionsComponent, {
        viewModel: { require: 'app/components/favorites/favorites' },
        template: { require: 'text!app/components/favorites/favorites.html' }
    });

    // Full page post
    ko.components.register(config.questionsComponent, {
        viewModel: { require: 'app/components/fullpagepost/fullpagepost' },
        template: { require: 'text!app/components/fullpagepost/fullpagepost.html' }
    });

    // List element
    ko.components.register(config.questionsComponent, {
        viewModel: { require: 'app/components/listelement/listelement' },
        template: { require: 'text!app/components/listelement/listelement.html' }
    });

    // List of elements with the search bar (essentially, main element)
    ko.components.register(config.questionsComponent, {
        viewModel: { require: 'app/components/listofelementswithsearch/listofelementswithsearch' },
        template: { require: 'text!app/components/listofelementswithsearch/listofelementswithsearch.html' }
    });

    // Questions
    ko.components.register(config.questionsComponent, {
        viewModel: { require: 'app/components/questions/questions' },
        template: { require: 'text!app/components/questions/questions.html' }
    });

    // Top bar menu
    ko.components.register(config.questionsComponent, {
        viewModel: { require: 'app/components/topbarmenu/topbarmenu' },
        template: { require: 'text!app/components/topbarmenu/topbarmenu.html' }
    });

    ko.applyBindings(viewmodel);
});