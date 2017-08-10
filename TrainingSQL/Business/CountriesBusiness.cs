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
            CountriesDatasource datasource = new CountriesDatasource();
            return datasource.GetCountry(code, conn);
        }
    }
}