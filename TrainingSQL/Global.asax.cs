using System.Web.Http;
using TrainingSQL.Models;
using TrainingSQL.Datasource;
using TrainingSQL.Services;

namespace TrainingSQL
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            System.Data.Entity.Database.SetInitializer<TrainingSQLContext>(null);
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var sqlServer = SqlServerService.GetInstance();
            var countryDatasource = CountriesDatasource.GetInstance();
        }
    }
}
