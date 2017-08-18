using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using TrainingSQL.Models;
using TrainingSQL.Business;

namespace TrainingSQL.Controllers
{
    public class CitiesController : ApiController
    {
        private TrainingSQLContext db = new TrainingSQLContext();

        // GET: api/Cities
        public IQueryable<City> GetCities()
        {
            return db.Cities;
        }

        // GET: api/Cities/5
        [ResponseType(typeof(City))]
        public IHttpActionResult GetCity(int id)
        {
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        // PUT: api/Cities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCity(int id, City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != city.ID)
            {
                return BadRequest();
            }

            db.Entry(city).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cities
        [ResponseType(typeof(City))]
        public IHttpActionResult PostCity(City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cities.Add(city);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = city.ID }, city);
        }

        // DELETE: api/Cities/5
        [ResponseType(typeof(City))]
        public IHttpActionResult DeleteCity(int id)
        {
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }

            db.Cities.Remove(city);
            db.SaveChanges();

            return Ok(city);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        [Route("api/Cities/Exist")]
        private bool CityExists(int id)
        {
            return db.Cities.Count(e => e.ID == id) > 0;
        }

        [HttpGet]
        [Route("api/Cities/Count")]
        public int CountCities()
        {
            return db.Cities.Count();
        }

        [HttpGet]
        [Route("api/Cities/GetCitiesFromCode/{code}")]
        public IQueryable<City> GetCityFromCode(string code)
        {
            var res = db.Cities.Where(e => e.CountryCode.Equals(code));
            return res;
        }


        #region Without entity framework

        [HttpGet]
        [Route("api/Cities/GetPopulationIndicator")]
        public ValueIndicator GetPopulationIndicator()
        {
            CitiesBusiness business = new CitiesBusiness();
            return business.GetPopulationIndicator();
        }

        [HttpGet]
        [Route("api/Cities/Test")]
        public string Test()
        {
            return "Hello World !";
        }

        #endregion

    }
}