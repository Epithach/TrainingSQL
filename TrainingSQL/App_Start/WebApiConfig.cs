﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TrainingSQL
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "CountryLanguagesControl",
                routeTemplate: "countrylanguages/{action}",
                defaults: new
                {
                    title = RouteParameter.Optional,
                    controller = "CountryLanguages",
                }
            );
        }
    }
}
