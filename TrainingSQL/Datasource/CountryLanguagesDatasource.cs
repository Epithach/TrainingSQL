using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using TrainingSQL.Models;
using TrainingSQL.Services;
using System.Data;

namespace TrainingSQL.Datasource
{
    public class CountryLanguagesDatasource
    {
        private static CountryLanguagesDatasource Instance = null;
        private static readonly object Padlock = new object();
        private SqlServerService SqlServer = null;

        CountryLanguagesDatasource()
        {
            this.SqlServer = SqlServerService.GetInstance();
        }

        public static CountryLanguagesDatasource GetInstance()
        {
            lock (Padlock)
            {
                if (Instance == null)
                {
                    Instance = new CountryLanguagesDatasource();
                }
                return Instance;
            }
        }

        public List<string> CheckOfficialLanguage(string language, bool isOfficial)
        {
            try
            {
                List<string> list = new List<string>();
                using (var command = new SqlCommand("dbo.COUNTRYLANGUAGE_CHECKOFFICIALLANGUAGE", this.SqlServer.GetSqlConnection())
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.AddWithValue("@language", language);
                    var official = isOfficial == true ? "T" : "F"; 
                    command.Parameters.AddWithValue("@isOfficial", official);
                    using (var response = command.ExecuteReader())
                    {
                        while (response.Read())
                        {
                            list.Add(((string)response["Name"]).Trim());
                        }
                        //response.Close();
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}