using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Web.Util;

namespace Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            const string version = "v1.0.0/";

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Annotations Routes
            config.Routes.MapHttpRoute(
                name: Config.AnnotationsRoute,
                routeTemplate: "api/" + version + "annotations/{id}",
                defaults: new { controller = "Annotations", id = RouteParameter.Optional }
            );

            // Answers Routes
            config.Routes.MapHttpRoute(
                name: Config.AnswersRoute,
                routeTemplate: "api/" + version + "answers/{id}",
                defaults: new { controller = "Answers", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.AnswersCommentsRoute,
                routeTemplate: "api/" + version + "answers/{answerId}/comments",
                defaults: new { controller = "Answers", answerId = "" }
            );

            config.Routes.MapHttpRoute(
                name: Config.AnswersAnnotationsRoute,
                routeTemplate: "api/" + version + "answers/{answerId}/searchUsers/{searchUserId}/annotations",
                defaults: new { controller = "Answers", route = Config.AnswersAnnotationsRoute, answerId = "", searchUserId = "" }
            );

            // Comments Routes
            config.Routes.MapHttpRoute(
                name: Config.CommentsRoute,
                routeTemplate: "api/" + version + "comments/{id}",
                defaults: new { controller = "Comments", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.CommentsAnnotationsRoute,
                routeTemplate: "api/" + version + "comments/{commentId}/searchUsers/{searchUserId}/annotations",
                defaults: new { controller = "Comments", commentId = "", searchUserId = ""}
            );

            // Questions Route
            config.Routes.MapHttpRoute(
                name: Config.QuestionsRoute,
                routeTemplate: "api/" + version + "questions/{id}",
                defaults: new { controller = "Questions", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.QuestionsAnswersRoute,
                routeTemplate: "api/" + version + "questions/{questionId}/answers",
                defaults: new { controller = "Questions", questionId = ""}
            );

            config.Routes.MapHttpRoute(
                name: Config.QuestionsCommentsRoute,
                routeTemplate: "api/" + version + "questions/{questionId}/comments",
                defaults: new { controller = "QuestionsComments", questionId = ""}
            );

            config.Routes.MapHttpRoute(
                name: Config.QuestionsLinkedPostsRoute,
                routeTemplate: "api/" + version + "questions/{questionId}/linkedposts",
                defaults: new { controller = "QuestionsLinkedPosts", questionId = ""}
            );

            config.Routes.MapHttpRoute(
                name: Config.QuestionsTagsRoute,
                routeTemplate: "api/" + version + "questions/{questionId}/tags",
                defaults: new { controller = "QuestionsTags", questionId = ""}
            );

            config.Routes.MapHttpRoute(
                name: Config.QuestionsAnnotationsRoute,
                routeTemplate: "api/" + version + "questions/{questionId}/searchUsers/{searchUserId}/annotations",
                defaults: new { controller = "Questions", questionId = "", searchUserId = "" }
            );

            // Searches Routs
            config.Routes.MapHttpRoute(
                name: Config.SearchesRoute,
                routeTemplate: "api/" + version + "searches/{id}",
                defaults: new { controller = "Searches", id = RouteParameter.Optional }
            );

            // SearchUsers Routes
            config.Routes.MapHttpRoute(
                name: Config.SearchUsersRoute,
                routeTemplate: "api/" + version + "searchusers/{id}",
                defaults: new { controller = "SearchUsers", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.SearchUsersAnnotationsRoute,
                routeTemplate: "api/" + version + "searchusers/{searchUserId}/annotations",
                defaults: new { controller = "SearchUsers", searchUserId = "" }
            );

            config.Routes.MapHttpRoute(
                name: Config.SearchUsersFavoritesRoute,
                routeTemplate: "api/" + version + "searchusers/{searchUserId}/favorites",
                defaults: new { controller = "SearchUsers", searchUserId = "" }
            );

            // Tags Routes
            config.Routes.MapHttpRoute(
                name: Config.TagsRoute,
                routeTemplate: "api/" + version + "tags/{id}",
                defaults: new { controller = "Tags", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.TagsQuestionsRoute,
                routeTemplate: "api/" + version + "tags/{tagId}/questions",
                defaults: new { controller = "Tags", tagId = ""}
            );

            // Users Routes
            config.Routes.MapHttpRoute(
                name: Config.UsersRoute,
                routeTemplate: "api/" + version + "users/{id}",
                defaults: new { controller = "Users", id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver
                = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
