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
        public List<string> CheckOfficialLanguage([FromBody]OfficialLanguage content)
        {
            var business = new CountryLanguagesBusiness();
            return business.CheckOfficialLanguage(content.Name, content.IsOfficial);
        }
    }
}
