using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Roomager.DataAccess
{
    public class DapperDataAccess : IDataAccess
    {
        IConfiguration configuration;

        public DapperDataAccess(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IEnumerable<T> GetData<T>(string sql)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("RoomagerDb")))
            {
                return connection.Query<T>(sql);
            }
        }

        public IEnumerable<T> GetData<T>(string sql, int pageSize, int pageNr)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("RoomagerDb")))
            {
                return connection.Query<T>(sql, new { pageSize = pageSize, pageNr = pageNr });
            }
        }

        public T GetSingleData<T>(string sql, int id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("RoomagerDb")))
            {
                return connection.Query<T>(sql, new { id = id }).SingleOrDefault();
            }
        }

        public T GetSingleDataJoined<T, Tone, Ttwo, Tthree>(string sql, int id, Func<T, Tone, Ttwo, Tthree, T> mapFunc, string splitOn)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("RoomagerDb")))
            {
                return connection.Query<T, Tone, Ttwo, Tthree, T>(sql, mapFunc, new {id}, splitOn: $"{splitOn}, {splitOn}, {splitOn}").SingleOrDefault();
            }
        }

        public int CreateData<T>(string sql, T newData)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("RoomagerDb")))
            {
                return connection.Execute(sql, newData);
            }
        }        

        public int EditData<T>(string sql, T editedData)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("RoomagerDb")))
            {
                return connection.Execute(sql, editedData);
            }
        }

        public int DeleteData(string sql, int id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("RoomagerDb")))
            {
                return connection.Execute(sql, new { id = id });
            }
        }
    }
}
