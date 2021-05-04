using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                return connection.Query<T>(sql, new { pageSize, pageNr });
            }
        }

        public T GetSingleData<T>(string sql, int id)
        {
            throw new NotImplementedException();
        }

        public int CreateData<T>(string sql, T newData)
        {
            throw new NotImplementedException();
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
