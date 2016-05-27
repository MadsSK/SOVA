(function () {
    requirejs.config({
        baseUrl: 'Scripts',
        paths: {
            knockout: 'lib/knockout-3.4.0.debug',
            jquery: 'lib/jquery-2.2.3.min',
            text: 'lib/text',
            bootstrap: 'lib/bootstrap.min',
            modernizer: 'lib/modernizr-2.8.3'
        },

        // Explicitly specify that bootstrap is dependant on jquery to avoid dependency errors
        shim: {
            "bootstrap": { "deps": ['jquery'] }
        }
    });
})();


var ns = ns || {};



ns.postbox = {
    subscribers: [],
    subscribe: function (callback, topic, source) {
        console.log("subscribe " + topic);// + " " + JSON.stringify(this.subscribers));
        var found = false;
        for (var i = 0; i < this.subscribers.length; i++) {
            if (this.subscribers[i].source === source && this.subscribers[i].topic === topic) {
                found = true;
                this.subscribers[i].callback = callback;
            }
        }
        if (!found) {
            this.subscribers.push({ topic: topic, callback: callback, source: source });
        }
    },
    notify: function (value, topic) {
        for (var i = 0; i < this.subscribers.length; i++) {
            if (this.subscribers[i].topic === topic) {
                this.subscribers[i].callback(value);
            }
        }
    }
};

require(['knockout', 'app/viewmodel', 'app/config'],
    function (ko, viewmodel, config) {

    // Top bar menu
    ko.components.register(config.menuComponent, {
        viewModel: { require: 'app/components/topbarmenu/topbarmenuViewModel' },
        template: { require: 'text!app/components/topbarmenu/topbarmenu.html' }
    });

    // Annotations
    ko.components.register(config.annotationsComponent, {
        viewModel: { require: 'app/components/annotations/annotationsViewModel' },
        template: { require: 'text!app/components/annotations/annotations.html' }
    });


    // Favorites
    ko.components.register(config.favoritesComponent, {
        viewModel: { require: 'app/components/favorites/favoritesViewModel' },
        template: { require: 'text!app/components/favorites/favorites.html' }
    });

    // Full page post
    ko.components.register(config.fullPagePostComponent, {
        viewModel: { require: 'app/components/fullpagepost/fullpagepostViewModel' },
        template: { require: 'text!app/components/fullpagepost/fullpagepost.html' }
    });

    // List element
    ko.components.register(config.listElementComponent, {
        viewModel: { require: 'app/components/listelement/listelementViewModel' },
        template: { require: 'text!app/components/listelement/listelement.html' }
    });

    // List of elements with the search bar (essentially, main element)
    ko.components.register(config.listOfElementsWithSearchComponent, {
        viewModel: { require: 'app/components/listofelementswithsearch/listofelementswithsearchViewModel' },
        template: { require: 'text!app/components/listofelementswithsearch/listofelementswithsearch.html' }
    });

    // Questions
    ko.components.register(config.questionsComponent, {
        viewModel: { require: 'app/components/questions/questionsViewModel' },
        template: { require: 'text!app/components/questions/questions.html' }
    });

    // Question
    ko.components.register(config.questionComponent, {
        viewModel: { require: 'app/components/question/questionViewModel' },
        template: { require: 'text!app/components/question/question.html' }
    });

    // User
    ko.components.register(config.userComponent, {
        viewModel: { require: 'app/components/user/userViewModel' },
        template: { require: 'text!app/components/user/user.html' }
    });

    // Tags
    ko.components.register(config.tagsComponent, {
        viewModel: { require: 'app/components/tags/tagsViewModel' },
        template: { require: 'text!app/components/tags/tags.html' }
    });

    // Comments
    ko.components.register(config.commentsComponent, {
        viewModel: { require: 'app/components/comments/commentsViewModel' },
        template: { require: 'text!app/components/comments/comments.html' }
    });

    // Answers
    ko.components.register(config.answersComponent, {
        viewModel: { require: 'app/components/answers/answersViewModel' },
        template: { require: 'text!app/components/answers/answers.html' }
    });

       

    ko.applyBindings(viewmodel);


});