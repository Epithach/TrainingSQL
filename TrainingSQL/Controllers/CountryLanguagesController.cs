using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainingSQL.Models;
using TrainingSQL.Business;

namespace TrainingSQL.Controllers
{
    public class CountryLanguagesController : ApiController
    {
        [HttpPost]
        [Route("api/CountryLanguages/Test")]
        public List<string> Test([FromBody]string test)
        {
            var business = new CountryLanguagesBusiness();
            return business.CheckOfficialLanguage("English", true);
        }

        //[HttpPost]
        //[Route("api/CountryLanguages/CheckOfficialLanguages")]
        public List<string> CheckOfficialLanguage([FromBody]string language, [FromBody]bool isOfficial)
        {
            return new List<string>();
        }
    }
}
