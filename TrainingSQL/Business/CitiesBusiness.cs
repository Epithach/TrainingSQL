using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingSQL.Models;
using TrainingSQL.Datasource;

namespace TrainingSQL.Business
{
    public class CitiesBusiness
    {
        public ValueIndicator GetPopulationIndicator()
        {
            CitiesDatasource datasource = CitiesDatasource.GetInstance();
            return datasource.GetPopulationIndicator();
        }
    }
}