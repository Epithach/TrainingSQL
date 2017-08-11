using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingSQL.Services;
using TrainingSQL.Models;

namespace TrainingSQL.Datasource
{
    public sealed class CitiesDatasource
    {
        private static CitiesDatasource Instance = null;
        private static readonly object Padlock = new object();
        private SqlServerService SqlServer = null;

        CitiesDatasource()
        {
            this.SqlServer = SqlServerService.GetInstance();
        }

        public static CitiesDatasource GetInstance()
        {
            lock (Padlock)
            {
                if (Instance == null)
                {
                    Instance = new CitiesDatasource();
                }
                return Instance;
            }
        }

        public CityPopulationIndicator GetPopulationIndicator()
        {
            return new CityPopulationIndicator();
        }
    }
}