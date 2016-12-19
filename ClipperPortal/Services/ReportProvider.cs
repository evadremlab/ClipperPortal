using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

using MySql.Data.MySqlClient;

using ClipperPortal.Models;

namespace ClipperPortal.Services
{
    public static class ReportProvider
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static IEnumerable<ReportMatrix> GetMatrix()
        {
            var list = new List<ReportMatrix>();

            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "getmatrix";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var data = new ReportMatrix();

                            data.Populate(reader);

                            list.Add(data);
                        }
                    }

                }
            };

            return list;
        }
    }
}