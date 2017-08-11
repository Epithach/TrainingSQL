using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TrainingSQL.Models;
using TrainingSQL.Services;

namespace TrainingSQL.Datasource
{
    public sealed class CountriesDatasource
    {
        private static CountriesDatasource Instance = null;
        private static readonly object Padlock = new object();
        private SqlServerService SqlServer = null;

        CountriesDatasource()
        {
            this.SqlServer = SqlServerService.GetInstance();
        }

        public static CountriesDatasource GetInstance()
        {
            lock (Padlock)
            {
                if (Instance == null)
                {
                    Instance = new CountriesDatasource();
                }
                return Instance;
            }
        }

        public List<LanguagePercent> GetLanguagePercent(string code)
        {
            try 
            {
                List<LanguagePercent> percentList = new List<LanguagePercent>();
                using (var command = new SqlCommand("dbo.COUNTRIES_GETLANGUAGEPERCENTILE", this.SqlServer.GetSqlConnection())
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.AddWithValue("@myCode", code);
                    var response = command.ExecuteReader();
                    while (response.Read())
                    {
                        percentList.Add(new LanguagePercent()
                        {
                            Country = ((string)response["Name"]).Trim(),
                            Language = ((string)response["Language"]).Trim(),
                            Percentile = (decimal)response["Percentage"]
                        });
                    }
                    response.Close();
                }
                return percentList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Country GetCountry(string code)
        {
            try
            {
                using (var command = new SqlCommand("dbo.COUNTRIES_GETCOUNTRY", this.SqlServer.GetSqlConnection())
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.AddWithValue("@myCode", code);
                    var response = command.ExecuteReader();

                    response.Read();
                    var country = new Country()
                    {
                        Code = (string)response["Code"],
                        Name = ((string)response["Name"]).Trim(),
                        Continent = ((string)response["Continent"]).Trim(),
                        Region = ((string)response["Region"]).Trim(),
                        SurfaceArea = response["SurfaceArea"] == DBNull.Value ? null : (decimal?)response["SurfaceArea"],
                        IndepYear = response["IndepYear"] == DBNull.Value ? null : (short?)response["IndepYear"],
                        Population = (int)response["Population"],
                        LifeExpectancy = (decimal?)response["LifeExpectancy"],
                        GNP = response["GNP"] == DBNull.Value ? null : (decimal?)response["GNP"],
                        GNPOld = response["GNPOld"] == DBNull.Value ? null : (decimal?)response["GNPOld"],
                        LocalName = ((string)response["LocalName"]).Trim(),
                        GovernmentForm = ((string)response["GovernmentForm"]).Trim(),
                        HeadOfState = ((string)response["HeadOfState"]).Trim(),
                        Capital = (int)response["Capital"],
                        Code2 = ((string)response["Code2"]).Trim()
                    };
                    response.Close();
                    return country;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}