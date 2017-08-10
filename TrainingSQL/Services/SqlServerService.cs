using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace TrainingSQL.Services
{
    public class SqlServerService
    {
        private SqlConnection Connection;

        public SqlServerService()
        {
            this.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TrainingSQLContext"].ConnectionString);
            try
            {
                this.Connection.Open();
                Debug.WriteLine("Connection Etablished !");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Connection Failed");
                throw (ex);
            }
        }

        ~SqlServerService()
        {
            this.Connection.Close();
        }

        public SqlConnection GetSqlConnection()
        {
            return this.Connection;
        }

    }
}