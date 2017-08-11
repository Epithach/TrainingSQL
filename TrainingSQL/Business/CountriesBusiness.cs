using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingSQL.Models;
using TrainingSQL.Tools;
using TrainingSQL.Datasource;
using System.Data.SqlClient;

namespace TrainingSQL.Business
{
    public class CountriesBusiness
    {
        public Country GetCountry(string code, SqlConnection conn)
        {
            CountriesDatasource datasource = CountriesDatasource.GetInstance();
            return datasource.GetCountry(code);
        }

        public List<LanguagePercent> GetLanguagePercentList(string code, SqlConnection conn)
        {
            CountriesDatasource datasource = CountriesDatasource.GetInstance();
            return datasource.GetLanguagePercent(code);
        }
    }
}