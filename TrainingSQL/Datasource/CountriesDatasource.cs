using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TrainingSQL.Models;

namespace TrainingSQL.Datasource
{
    public class CountriesDatasource
    {
        public Country GetCountry(string code, SqlConnection conn)
        {
            try
            {
                using (var command = new SqlCommand("dbo.COUNTRIES_GETCOUNTRY", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.AddWithValue("@myCode", code);
                    var response = command.ExecuteReader();

                    response.Read();

                    var test = response["GNPOld"];

                    return new Country()
                    {
                        Code = (string)response["Code"],
                        Name = (string)response["Name"],
                        Continent = (string)response["Continent"],
                        Region = (string)response["Region"],
                        SurfaceArea = (decimal?)response["SurfaceArea"],
                        IndepYear = (short?)response["IndepYear"],
                        Population = (int)response["Population"],
                        LifeExpectancy = (decimal?)response["LifeExpectancy"],
                        GNP = (decimal?)response["GNP"],
                        GNPOld = (decimal?)response["GNPOld"],
                        LocalName = (string)response["LocalName"]
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}