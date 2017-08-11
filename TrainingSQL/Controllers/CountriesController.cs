using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TrainingSQL.Business;
using TrainingSQL.Models;

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
            CountriesBusiness business = new CountriesBusiness();
            return business.GetCountry(code);
        }

        [HttpGet]
        [Route("api/Countries/GetLanguagePercentile/{code}")]
        public List<LanguagePercent> GetLanguagePercertile(string code)
        {
            CountriesBusiness business = new CountriesBusiness();
            return business.GetLanguagePercentList(code);
        }

    }
}