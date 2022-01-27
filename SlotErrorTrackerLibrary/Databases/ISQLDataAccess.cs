using System.Collections.Generic;

namespace SlotErrorTrackerLibrary.Databases
{
    public interface ISQLDataAccess
    {
        List<T> LoadData<T, U>(string sqlStatement,
                               U parameters,
                               string key,
                               bool isStoredProcedure = false);
        void SaveData<T>(string sqlStatement,
                         T parameters,
                         string key,
                         bool isStoredProcedure = false);
    }
}