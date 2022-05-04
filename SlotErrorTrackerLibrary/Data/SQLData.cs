using SlotErrorTrackerLibrary.Databases;
using SlotErrorTrackerLibrary.Models;
using System;
using System.Collections.Generic;

namespace SlotErrorTrackerLibrary.Data
{

    public class SQLData : ISQLData
    {
        private readonly ISQLDataAccess _db;
        private readonly string _connectionString;

        public SQLData(ISQLDataAccess db)
        {
            _db = db;
        }

        public List<ManufacturerModel> GetManufacturers()
        {
            return _db.LoadData<ManufacturerModel, dynamic>("dbo.spGetManufacturers",
                                                            new { },
                                                            _connectionString,
                                                            true);
        }

        public void CreateCabinetByManufacturer(string cabinet,
                                                string manufacturer)
        {
            _db.SaveData("dbo.spCreateCabinetByManufacturer",
                          new { Cabinet = cabinet, Manufacturer = manufacturer },
                          _connectionString,
                          true);
        }

        public void CreateErrorDescriptionByCabinet(string description,
                                                    string cabinet)
        {
            _db.SaveData("dbo.spCreateEDByCabinet",
                         new { Description = description, Cabinet = cabinet },
                         _connectionString,
                         true);
        }

        public void CreateSolutionByErrorDescription(string solution,
                                                     string description,
                                                     string cabinet)
        {
            _db.SaveData("dbo.spCreateSolutionByED",
                         new { Solution = solution, Description = description, Cabinet = cabinet },
                         _connectionString,
                         true);
        }

        public List<CabinetPlatformModel> GetCabinetsByManufacturer(string manufacturer)
        {
            return _db.LoadData<CabinetPlatformModel, dynamic>("dbo.spGetCabinetsByManufacturer",
                                                                new { Manufacturer = manufacturer },
                                                                _connectionString,
                                                                true);
        }

        public List<ErrorModel> GetErrorsByCabinet(string cabinet)
        {
            return _db.LoadData<ErrorModel, dynamic>("dbo.spGetErrorsByCabinet",
                                                     new { Cabinet = cabinet },
                                                     _connectionString,
                                                     true);
        }

        public List<SolutionModel> GetSolutionsByErrorDescription(string description,
                                                                  string cabinet)
        {
            return _db.LoadData<SolutionModel, dynamic>("dbo.spGetSolutionByErrorDescription",
                                                        new { Description = description, Cabinet = cabinet },
                                                        _connectionString,
                                                        true);
        }

        public void CreateManufacturer(string manufacturer)
        {
            _db.SaveData("dbo.spCreateManufacturer", new { manufacturer }, _connectionString, true);
        }

        public void CreateErrorDescription(string errorDescription)
        {
            _db.SaveData("dbo.spCreateErrorDescription", new { errorDescription }, _connectionString, true);
        }

        public void CreatePotentialSolution(string potentialSolution)
        {
            _db.SaveData("dbo.spCreatePotentialSolution", new { potentialSolution }, _connectionString, true);
        }

        public void DeleteManufacturer(string manufacturer)
        {
            //Must delete all associated cabinets and update link tables as well
            throw new NotImplementedException();
        }

        public void DeleteCabinetByManufacturer(string cabinet,
                                                string manufacturer)
        {
            //Must update error description link table as well
            throw new NotImplementedException();
        }

        public void DeleteErrorDescription(string errorDescription)
        {
            //Must update link table as well
            throw new NotImplementedException();
        }

        public void AssignExistingErrorDescToCabinet(string cabinet,
                                                     string errorDescription)
        {
            throw new NotImplementedException();
        }
        public void AssignExistingSolutionToErrorDesc(string potentialSolution,
                                                     string errorDescription)
        {
            throw new NotImplementedException();
        }
        public void DeleteErrorDescriptionByCabinet(string cabinet,
                                                    string errorDescription)
        {
            //Must update link tables as well
            throw new NotImplementedException();
        }

        public void DeletePotentialSolutionByErrorDesc(string potentialSolution,
                                                       string errorDescription)
        {
            //Must update link tables as well
            throw new NotImplementedException();
        }

        public void UpdateExistingManufacturer(string manufacturer)
        {
            throw new NotImplementedException();
        }

        public void UpdateExistingCabinetByManufacturer(string cabinet,
                                                        string manufacturer)
        {
            throw new NotImplementedException();
        }

        public void UpdateExistingErrorDescriptionByCabinet(string cabinet,
                                                            string errorDescription)
        {
            throw new NotImplementedException();
        }

        public void UpdateExistingPotentialSolutionByErrorDesc(string potentialSolution,
                                                               string errorDescription)
        {
            throw new NotImplementedException();
        }

        public void UpdateExistingErrorDescription(string errorDescription)
        {
            throw new NotImplementedException();
        }

        public void UpdateExistingPotentialSolution(string potentialSolution)
        {
            throw new NotImplementedException();
        }
    }
}
