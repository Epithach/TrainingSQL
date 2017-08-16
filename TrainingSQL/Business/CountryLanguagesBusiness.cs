using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingSQL.Datasource;
using System.Threading.Tasks;

namespace TrainingSQL.Business
{
    public class CountryLanguagesBusiness
    {
        public List<string> CheckOfficialLanguage(string language, bool isOfficial)
        {
            var datasource = CountryLanguagesDatasource.GetInstance();
            return datasource.CheckOfficialLanguage(language, isOfficial);
        }

        
    }
}