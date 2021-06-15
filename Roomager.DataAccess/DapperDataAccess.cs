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

        public int CreateData<T>(string sql, T newData)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("RoomagerDb")))
            {
                return connection.Execute(sql, newData);
            }
        }        

        public int EditData<T>(string sql, T editedData)
        {
            throw new NotImplementedException();
        }

        public int DeleteData(string sql, int id)
        {
            throw new NotImplementedException();
        }
    }
}
