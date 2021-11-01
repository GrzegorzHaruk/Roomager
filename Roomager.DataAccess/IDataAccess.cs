using System;
using System.Collections.Generic;
using System.Text;

namespace Roomager.DataAccess
{
    public interface IDataAccess
    {
        IEnumerable<T> GetData<T>(string sql);
        IEnumerable<T> GetData<T>(string sql, int pageSize, int pageNr);
        IEnumerable<T> GetDataByYear<T>(string sql, int years);
        T GetSingleData<T>(string sql, int id);
        int CreateData<T>(string sql, T newData);
        int EditData<T>(string sql, T editedData);
        int DeleteData(string sql, int id);
    }
}
