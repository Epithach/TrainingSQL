using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using TrainingSQL.Models;

namespace TrainingSQL
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            System.Data.Entity.Database.SetInitializer<TrainingSQLContext>(null);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
