using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json.Serialization;
using Web.Util;

namespace Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            const string backEndVersion = "v1.0.0/";

            //String used for searching.
            string searchString="";

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Annotations Routes
            config.Routes.MapHttpRoute(
                name: Config.AnnotationsRoute,
                routeTemplate: "api/" + backEndVersion + "annotations/{id}",
                defaults: new { controller = "Annotations", id = RouteParameter.Optional }
            );

            // Answers Routes
            config.Routes.MapHttpRoute(
                name: Config.AnswersRoute,
                routeTemplate: "api/" + backEndVersion + "answers/{id}",
                defaults: new { controller = "Answers", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.AnswersCommentsRoute,
                routeTemplate: "api/" + backEndVersion + "answers/{answerId}/comments",
                defaults: new { controller = "Answers", answerId = "" }
            );

            config.Routes.MapHttpRoute(
                name: Config.AnswersAnnotationsRoute,
                routeTemplate: "api/" + backEndVersion + "answers/{answerId}/searchUsers/{searchUserId}/annotations",
                defaults: new { controller = "Answers", route = Config.AnswersAnnotationsRoute, answerId = "", searchUserId = "" }
            );

            // Comments Routes
            config.Routes.MapHttpRoute(
                name: Config.CommentsRoute,
                routeTemplate: "api/" + backEndVersion + "comments/{id}",
                defaults: new { controller = "Comments", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.CommentsAnnotationsRoute,
                routeTemplate: "api/" + backEndVersion + "comments/{commentId}/searchUsers/{searchUserId}/annotations",
                defaults: new { controller = "Comments", commentId = "", searchUserId = ""}
            );

            // Questions Route
            config.Routes.MapHttpRoute(
                name: Config.QuestionsRoute,
                routeTemplate: "api/" + backEndVersion + "questions/{id}",
                defaults: new { controller = "Questions", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.QuestionsAnswersRoute,
                routeTemplate: "api/" + backEndVersion + "questions/{questionId}/answers",
                defaults: new { controller = "Questions", questionId = ""}
            );

            config.Routes.MapHttpRoute(
                name: Config.QuestionsCommentsRoute,
                routeTemplate: "api/" + backEndVersion + "questions/{questionId}/comments",
                defaults: new { controller = "QuestionsComments", questionId = ""}
            );

            config.Routes.MapHttpRoute(
                name: Config.QuestionsLinkedPostsRoute,
                routeTemplate: "api/" + backEndVersion + "questions/{questionId}/linkedposts",
                defaults: new { controller = "QuestionsLinkedPosts", questionId = ""}
            );

            config.Routes.MapHttpRoute(
                name: Config.QuestionsTagsRoute,
                routeTemplate: "api/" + backEndVersion + "questions/{questionId}/tags",
                defaults: new { controller = "QuestionsTags", questionId = ""}
            );

            config.Routes.MapHttpRoute(
                name: Config.QuestionsAnnotationsRoute,
                routeTemplate: "api/" + backEndVersion + "questions/{questionId}/searchUsers/{searchUserId}/annotations",
                defaults: new { controller = "Questions", questionId = "", searchUserId = "" }
            );

            //SearchResult Routes
            config.Routes.MapHttpRoute(
                name: Config.SearchAllRoute,
                routeTemplate: "api/" + backEndVersion + "search?=" + searchString,
                defaults: new {controller = "Questions"}//Needs change
                );

            config.Routes.MapHttpRoute(
                name:Config.SearchQuestionsRoute,
                routeTemplate:"api/" + backEndVersion + "Questions/search?=" + searchString,
                defaults: new { controller = "Questions"}
                );

            config.Routes.MapHttpRoute(
                name: Config.SearchAnnotationsRoute,
                routeTemplate: "api/" + backEndVersion + "Annotations/search?=" + searchString,
                defaults: new {controller = "Annotations"}
                );

            config.Routes.MapHttpRoute(
                name: Config.SearchCommentsRoute,
                routeTemplate: "api/" + backEndVersion + "Comments/search?=" + searchString,
                defaults: new {controllers = "Comments"}
                );

            config.Routes.MapHttpRoute(
                name: Config.SearchFavoritesRoute,
                routeTemplate: "api/" + backEndVersion + "Favorites/search?=" + searchString,
                defaults: new {controllers = "Facorites"}
                );

            // Searches Routs
            config.Routes.MapHttpRoute(
                name: Config.SearchesRoute,
                routeTemplate: "api/" + backEndVersion + "searches/{id}",
                defaults: new { controller = "Searches", id = RouteParameter.Optional }
            );

            // SearchUsers Routes
            config.Routes.MapHttpRoute(
                name: Config.SearchUsersRoute,
                routeTemplate: "api/" + backEndVersion + "searchusers/{id}",
                defaults: new { controller = "SearchUsers", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.SearchUsersAnnotationsRoute,
                routeTemplate: "api/" + backEndVersion + "searchusers/{searchUserId}/annotations",
                defaults: new { controller = "SearchUsersAnnotations", searchUserId = "" }
            );

            config.Routes.MapHttpRoute(
                name: Config.SearchUsersFavoritesRoute,
                routeTemplate: "api/" + backEndVersion + "searchusers/{searchUserId}/favorites",
                defaults: new { controller = "SearchUsersFavorites", searchUserId = "" }
            );

            config.Routes.MapHttpRoute(
                name: Config.SearchUsersSearchsRoute,
                routeTemplate: "api/" + backEndVersion + "searchusers/{searchUserId}/searchs",
                defaults: new { controller = "SearchUsersSearchs", searchUserId = "" }
            );

            // Tags Routes
            config.Routes.MapHttpRoute(
                name: Config.TagsRoute,
                routeTemplate: "api/" + backEndVersion + "tags/{id}",
                defaults: new { controller = "Tags", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.TagsQuestionsRoute,
                routeTemplate: "api/" + backEndVersion + "tags/{tagId}/questions",
                defaults: new { controller = "Tags", tagId = ""}
            );

            // Users Routes
            config.Routes.MapHttpRoute(
                name: Config.UsersRoute,
                routeTemplate: "api/" + backEndVersion + "users/{id}",
                defaults: new { controller = "Users", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.UsersAnswersRoute,
                routeTemplate: "api/" + backEndVersion + "users/{userId}answers",
                defaults: new { controller = "UsersAnswers", userId = ""}
            );

            config.Routes.MapHttpRoute(
                name: Config.UsersQuestionsRoute,
                routeTemplate: "api/" + backEndVersion + "users/{userId}questions",
                defaults: new { controller = "UsersQuestions", userId = "" }
            );

            config.Routes.MapHttpRoute(
                name: Config.UsersCommentsRoute,
                routeTemplate: "api/" + backEndVersion + "users/{userId}comments",
                defaults: new { controller = "UsersComments", userId = "" }
            );

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver
                = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
