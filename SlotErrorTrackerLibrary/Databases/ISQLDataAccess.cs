using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlotErrorTrackerLibrary.Databases
{
    public interface ISQLDataAccess
    {
        Task<List<T>> LoadDataAsync<T, U>(string sqlStatement, U parameters, string connectionString, bool isStoredProcedure = false);
        Task SaveDataAsync<T>(string sqlStatement, T parameters, string connectionString, bool isStoredProcedure = false);
    }
}