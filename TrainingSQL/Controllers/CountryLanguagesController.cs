using System.Collections.Generic;
using System.Web.Http;
using TrainingSQL.Business;
using TrainingSQL.Models;
using System.Threading.Tasks;

namespace TrainingSQL.Controllers
{
    public class CountryLanguagesController : ApiController
    {
        [HttpPost]
        public List<string> CheckOfficialLanguage([FromBody]OfficialLanguage content)
        {
            var business = new CountryLanguagesBusiness();
            /*
            List<string> list = new List<string>();

            for (int i = 0; i < 2; i++)
            {
                Task.Run(() =>
                    list.AddRange(business.CheckOfficialLanguage(content.Name, content.IsOfficial))
                );
            }*/

            return business.CheckOfficialLanguage(content.Name, content.IsOfficial);
            //return list;
        }
    }
}
