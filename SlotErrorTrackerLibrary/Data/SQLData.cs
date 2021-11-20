using SlotErrorTrackerLibrary.Databases;
using SlotErrorTrackerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlotErrorTrackerLibrary.Data
{
    
    public class SQLData : ISQLData
    {
        private readonly ISQLDataAccess _db;
        private string ConnectionStringName;

        public SQLData(ISQLDataAccess db)
        {
            _db = db;

            ConnectionStringName = "SQLDb";
        }

        public SQLData()
        {

        }

        public List<ManufacturerModel> GetManufacturers()
        {
            return _db.LoadData<ManufacturerModel, dynamic>("dbo.spGetManufacturers",
                                                            new { },
                                                            ConnectionStringName,
                                                            true);
        }

        public void CreateCabinetByManufacturer(string cabinet, string manufacturer)
        {
            _db.SaveData("dbo.spCreateCabinetByManufacturer",
                          new { Cabinet = cabinet, Manufacturer = manufacturer },
                          ConnectionStringName,
                          true);
        }
        
        public void CreateErrorDescriptionByCabinet(string description, string cabinet)
        {
            _db.SaveData("dbo.spCreateEDByCabinet",
                         new { Description = description, Cabinet = cabinet },
                         ConnectionStringName,
                         true);
        }

        public void CreateSolutionByErrorDescription(string solution, string description, string cabinet)
        {
            _db.SaveData("dbo.spCreateSolutionByED",
                         new { Solution = solution, Description = description, Cabinet = cabinet },
                         ConnectionStringName,
                         true);
        }

        public List<CabinetPlatformModel> GetCabinetsByManufacturer(string manufacturer)
        {
            return _db.LoadData<CabinetPlatformModel, dynamic>("dbo.spGetCabinetsByManufacturer",
                                                                new { Manufacturer = manufacturer },
                                                                ConnectionStringName,
                                                                true);
        }

        public List<ErrorModel> GetErrorsByCabinet(string cabinet)
        {
            return _db.LoadData<ErrorModel, dynamic>("dbo.spGetErrorsByCabinet",
                                                     new { Cabinet = cabinet },
                                                     ConnectionStringName,
                                                     true);
        }

        public List<SolutionModel> GetSolutionsByErrorDescription(string description, string cabinet)
        {
            return _db.LoadData<SolutionModel, dynamic>("dbo.spGetSolutionByErrorDescription",
                                                        new { Description = description, Cabinet = cabinet },
                                                        ConnectionStringName,
                                                        true);
        }

        public void CreateManufacturer(string manufacturer)
        {
            _db.SaveData("dbo.spCreateManufacturer", new { manufacturer }, ConnectionStringName, true);
        }
    }
}
