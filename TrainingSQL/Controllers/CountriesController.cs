using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TrainingSQL.Models;
using TrainingSQL.Services;
using TrainingSQL.Business;

namespace TrainingSQL.Controllers
{
    public class CountriesController : ApiController
    {
        private TrainingSQLContext db = new TrainingSQLContext();

        // GET: api/Countries
        public IQueryable<Country> GetCountries()
        {
            return db.Countries;
        }
        /*
        [HttpGet]
        [Route("api/Countries/{code}")]
        public Country GetCountry(string code)
        {
            var element = db.Countries.Where(e => e.Code.Equals(code)).FirstOrDefault();
            return element;
        }*/

        [HttpGet]
        [Route("api/Countries/Count")]
        public int CountCoutry()
        {
            return db.Countries.Count();
        }
        
        [HttpGet]
        [Route("api/Countries/{code}")]
        public Country GetCountry(string code)
        {
            SqlServerService sqlServer = new SqlServerService();
            CountriesBusiness business = new CountriesBusiness();

            return business.GetCountry(code, sqlServer.GetSqlConnection());
        }

    }
}