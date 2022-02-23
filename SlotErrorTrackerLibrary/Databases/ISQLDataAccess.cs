using System.Collections.Generic;

namespace SlotErrorTrackerLibrary.Databases
{
    public interface ISQLDataAccess
    {
        List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionString, bool isStoredProcedure = false);
        void SaveData<T>(string sqlStatement, T parameters, string connectionString, bool isStoredProcedure = false);
    }
}