using System;
using System.Collections.Generic;
using System.Text;

namespace Roomager.DataAccess
{
    public interface IDataAccess
    {
        IEnumerable<T> GetData<T>(string sql);
        IEnumerable<T> GetData<T>(string sql, int pageSize, int pageNr);
        T GetSingleData<T>(string sql, int id);
        T GetSingleDataJoined<T, Tone, Ttwo, Tthree>(string sql, int id, Func<T, Tone, Ttwo, Tthree, T> mapFunc, string splitOn);
        int CreateData<T>(string sql, T newData);
        int EditData<T>(string sql, T editedData);
        int DeleteData(string sql, int id);
    }
}
