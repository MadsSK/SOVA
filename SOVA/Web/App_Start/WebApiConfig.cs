using System;
using System.Collections.Generic;
using System.Linq;
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

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: Config.PostsRoute,
                routeTemplate: "api/v1.0.0/annotations/{id}",
                defaults: new { controller = "Annotations", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.PostsRoute,
                routeTemplate: "api/v1.0.0/answers/{id}",
                defaults: new { controller = "Answers", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.CommentsRoute,
                routeTemplate: "api/v1.0.0/comments/{id}",
                defaults: new { controller = "Comments", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.PostsRoute,
                routeTemplate: "api/v1.0.0/posts/{id}",
                defaults: new { controller = "Posts", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.PostsRoute,
                routeTemplate: "api/v1.0.0/questions/{id}",
                defaults: new { controller = "Questions", id = RouteParameter.Optional }
            );
            
            config.Routes.MapHttpRoute(
                name: Config.CommentsRoute,
                routeTemplate: "api/v1.0.0/searches/{id}",
                defaults: new { controller = "Searches", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.CommentsRoute,
                routeTemplate: "api/v1.0.0/searchusers/{id}",
                defaults: new { controller = "SearchUsers", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.CommentsRoute,
                routeTemplate: "api/v1.0.0/tags/{id}",
                defaults: new { controller = "Tags", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: Config.CommentsRoute,
                routeTemplate: "api/v1.0.0/users/{id}",
                defaults: new { controller = "Users", id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver
                = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
