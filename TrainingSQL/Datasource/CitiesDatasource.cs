using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingSQL.Services;
using TrainingSQL.Models;
using System.Data.SqlClient;
using System.Data;

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

        public ValueIndicator GetPopulationIndicator()
        {
            try
            {
                using (var command = new SqlCommand("dbo.CITIES_GETPOPULATIONINDICATOR", this.SqlServer.GetSqlConnection())
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    var response = command.ExecuteReader();
                    response.Read();

                    var values = new ValueIndicator()
                    {
                        Max = (int)response["Max"],
                        Min = (int)response["Min"],
                        Avg = (int)response["Avg"],
                    };
                    return values;
                }
            }
            catch
            {

            }

            return new ValueIndicator();
        }
    }
}