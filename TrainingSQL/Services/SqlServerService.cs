using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace TrainingSQL.Services
{
    public sealed class SqlServerService
    {
        public static SqlServerService Instance = null;
        private static readonly object Padlock = new object();
        private SqlConnection Connection;

        SqlServerService()
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

        public static SqlServerService GetInstance()
        {
            lock ((Padlock))
            {
                if (Instance == null)
                {
                    Instance = new SqlServerService();
                }
                return Instance;
            }
        }

        public SqlConnection GetSqlConnection()
        {
            lock (Padlock)
            {
                if (Instance == null)
                {
                    return null;
                }
                return this.Connection;
            }
        }

    }
}